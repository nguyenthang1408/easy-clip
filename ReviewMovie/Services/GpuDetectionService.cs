using Lib;
using ReviewMovie.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace EasyClip.Services
{
    /// <summary>
    /// Service để kiểm tra GPU NVIDIA có khả dụng cho encoding không
    /// </summary>
    public class GpuDetectionService
    {
        private GpuDetectionResult _lastResult;

        public GpuDetectionService()
        {
            _lastResult = new GpuDetectionResult();
        }

        /// <summary>
        /// Lấy kết quả kiểm tra GPU gần nhất
        /// </summary>
        public GpuDetectionResult GetLastResult()
        {
            return _lastResult;
        }

        /// <summary>
        /// Kiểm tra GPU có khả dụng không
        /// Test thực tế bằng cách tạo video ngắn để phát hiện lỗi driver/API version
        /// </summary>
        public bool CheckGpuAvailability()
        {
            _lastResult = new GpuDetectionResult();

            try
            {
                string ffmpegPath = Funcion.selectffmpegversion() + "\\ffmpeg.exe";
                if (!File.Exists(ffmpegPath))
                {
                    _lastResult.ErrorMessage = "Không tìm thấy FFmpeg.exe";
                    _lastResult.ErrorType = GpuErrorType.FfmpegNotFound;
                    return false;
                }

                // Bước 1: Kiểm tra h264_nvenc có trong danh sách encoders không
                if (!CheckEncoderExists(ffmpegPath))
                {
                    _lastResult.ErrorMessage = "h264_nvenc không có trong danh sách encoders";
                    _lastResult.ErrorType = GpuErrorType.EncoderNotFound;
                    return false;
                }

                // Bước 2: Test thực tế encode để phát hiện lỗi driver/API version
                bool testResult = TestGpuEncode(ffmpegPath);

                if (testResult)
                {
                    _lastResult.IsAvailable = true;
                    _lastResult.ErrorMessage = string.Empty;
                    _lastResult.ErrorType = GpuErrorType.None;
                }

                return testResult;
            }
            catch (Exception ex)
            {
                _lastResult.ErrorMessage = $"Lỗi không xác định: {ex.Message}";
                _lastResult.ErrorType = GpuErrorType.UnknownError;
                return false;
            }
        }

        /// <summary>
        /// Kiểm tra h264_nvenc có trong danh sách encoders không
        /// </summary>
        private bool CheckEncoderExists(string ffmpegPath)
        {
            try
            {
                var process = new Process();
                process.StartInfo = new ProcessStartInfo
                {
                    FileName = ffmpegPath,
                    Arguments = "-encoders",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden
                };

                process.Start();
                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();

                return output.Contains("h264_nvenc");
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Test thực tế GPU encode để phát hiện lỗi driver, API version
        /// </summary>
        private bool TestGpuEncode(string ffmpegPath)
        {
            try
            {
                // Tạo test với testsrc (không cần file input) - encode 1 frame duy nhất
                string arguments = "-f lavfi -i testsrc=duration=0.1:size=320x240:rate=1 -vcodec h264_nvenc -frames:v 1 -f null -";

                var process = new Process();
                process.StartInfo = new ProcessStartInfo
                {
                    FileName = ffmpegPath,
                    Arguments = arguments,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden
                };

                process.Start();
                string stderr = process.StandardError.ReadToEnd();
                string stdout = process.StandardOutput.ReadToEnd();
                process.WaitForExit();

                // Kiểm tra các pattern lỗi phổ biến và lưu thông tin chi tiết
                var errorPatterns = new Dictionary<string, (string message, GpuErrorType type)>
                {
                    { "Driver does not support", ("Driver NVIDIA không hỗ trợ phiên bản NVENC API yêu cầu", GpuErrorType.DriverTooOld) },
                    { "nvenc API version", ("Phiên bản NVENC API không tương thích", GpuErrorType.ApiVersionMismatch) },
                    { "minimum required Nvidia driver", ("Driver NVIDIA quá cũ, cần cập nhật driver", GpuErrorType.DriverTooOld) },
                    { "Error while opening encoder", ("Không thể khởi tạo encoder NVENC", GpuErrorType.EncoderInitFailed) },
                    { "Could not open encoder", ("Không thể mở encoder NVENC", GpuErrorType.EncoderInitFailed) },
                    { "Conversion failed", ("GPU encoding thất bại", GpuErrorType.EncoderInitFailed) },
                    { "No NVENC capable devices found", ("Không tìm thấy GPU hỗ trợ NVENC", GpuErrorType.NoDeviceFound) },
                    { "Cannot load nvcuda.dll", ("Không load được nvcuda.dll", GpuErrorType.LibraryLoadFailed) },
                    { "Cannot load nvEncodeAPI", ("Không load được nvEncodeAPI", GpuErrorType.LibraryLoadFailed) },
                    { "Function not implemented", ("Chức năng không được hỗ trợ", GpuErrorType.EncoderInitFailed) },
                    { "Invalid argument", ("Tham số không hợp lệ", GpuErrorType.EncoderInitFailed) },
                    { "Error initializing output stream", ("Lỗi khởi tạo output stream", GpuErrorType.EncoderInitFailed) },
                };

                foreach (var errorPattern in errorPatterns)
                {
                    if (stderr.Contains(errorPattern.Key))
                    {
                        // Lưu lỗi chi tiết
                        _lastResult.ErrorMessage = errorPattern.Value.message;
                        _lastResult.ErrorType = errorPattern.Value.type;

                        // Tìm dòng chứa thông tin driver version nếu có
                        if (stderr.Contains("Required:") && stderr.Contains("Found:"))
                        {
                            try
                            {
                                var lines = stderr.Split('\n');
                                var driverLine = lines.FirstOrDefault(l => l.Contains("minimum required Nvidia driver"));
                                if (!string.IsNullOrEmpty(driverLine))
                                {
                                    _lastResult.ErrorMessage += $"\n\n{driverLine.Trim()}";
                                }
                            }
                            catch { }
                        }

                        return false;
                    }
                }

                // Kiểm tra exit code
                if (process.ExitCode != 0)
                {
                    _lastResult.ErrorMessage = "GPU encoding test thất bại (exit code: " + process.ExitCode + ")";
                    _lastResult.ErrorType = GpuErrorType.UnknownError;
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                _lastResult.ErrorMessage = $"Lỗi test GPU: {ex.Message}";
                _lastResult.ErrorType = GpuErrorType.UnknownError;
                return false;
            }
        }

        /// <summary>
        /// Lấy message box message cho user
        /// </summary>
        public string GetUserFriendlyErrorMessage()
        {
            if (_lastResult.IsAvailable)
                return string.Empty;

            string message = "GPU NVIDIA không khả dụng!\n\n";

            if (!string.IsNullOrEmpty(_lastResult.ErrorMessage))
            {
                message += $"Lỗi: {_lastResult.ErrorMessage}\n\n";
            }

            // Thêm hướng dẫn dựa trên loại lỗi
            switch (_lastResult.ErrorType)
            {
                case GpuErrorType.FfmpegNotFound:
                    message += "FFmpeg chưa được cài đặt hoặc không tìm thấy.\n" +
                              "Vui lòng tải và cài đặt FFmpeg.";
                    break;

                case GpuErrorType.DriverTooOld:
                case GpuErrorType.ApiVersionMismatch:
                    message += "Vui lòng cập nhật driver NVIDIA lên phiên bản mới nhất.";
                    break;

                case GpuErrorType.NoDeviceFound:
                    message += "Không tìm thấy GPU NVIDIA hỗ trợ NVENC.\n" +
                              "Cần card đồ họa NVIDIA GTX 600 series trở lên.";
                    break;

                default:
                    message += "Vui lòng kiểm tra:\n" +
                              "- Card đồ họa NVIDIA có hỗ trợ NVENC (GTX 600 series trở lên)\n" +
                              "- Driver NVIDIA đã được cài đặt và cập nhật\n" +
                              "- FFmpeg được build với hỗ trợ NVENC";
                    break;
            }

            message += "\n\nHệ thống sẽ chuyển về sử dụng CPU.";

            return message;
        }
    }
}
