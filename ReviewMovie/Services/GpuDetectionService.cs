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
                    _lastResult.ErrorMessage = GpuDetectionMessages.ERROR_FFMPEG_NOT_FOUND;
                    _lastResult.ErrorType = GpuErrorType.FfmpegNotFound;
                    return false;
                }

                // Bước 1: Kiểm tra h264_nvenc có trong danh sách encoders không
                if (!CheckEncoderExists(ffmpegPath))
                {
                    _lastResult.ErrorMessage = GpuDetectionMessages.ERROR_ENCODER_NOT_FOUND;
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
                _lastResult.ErrorMessage = GpuDetectionMessages.GetUnknownErrorMessage(ex.Message);
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
                    { GpuDetectionMessages.PATTERN_DRIVER_NOT_SUPPORT, (GpuDetectionMessages.ERROR_DRIVER_NOT_SUPPORT, GpuErrorType.DriverTooOld) },
                    { GpuDetectionMessages.PATTERN_NVENC_API_VERSION, (GpuDetectionMessages.ERROR_API_VERSION_MISMATCH, GpuErrorType.ApiVersionMismatch) },
                    { GpuDetectionMessages.PATTERN_MIN_REQUIRED_DRIVER, (GpuDetectionMessages.ERROR_DRIVER_TOO_OLD, GpuErrorType.DriverTooOld) },
                    { GpuDetectionMessages.PATTERN_ERROR_OPENING_ENCODER, (GpuDetectionMessages.ERROR_ENCODER_INIT_FAILED, GpuErrorType.EncoderInitFailed) },
                    { GpuDetectionMessages.PATTERN_COULD_NOT_OPEN_ENCODER, (GpuDetectionMessages.ERROR_ENCODER_OPEN_FAILED, GpuErrorType.EncoderInitFailed) },
                    { GpuDetectionMessages.PATTERN_CONVERSION_FAILED, (GpuDetectionMessages.ERROR_ENCODING_FAILED, GpuErrorType.EncoderInitFailed) },
                    { GpuDetectionMessages.PATTERN_NO_NVENC_DEVICES, (GpuDetectionMessages.ERROR_NO_DEVICE_FOUND, GpuErrorType.NoDeviceFound) },
                    { GpuDetectionMessages.PATTERN_CANNOT_LOAD_NVCUDA, (GpuDetectionMessages.ERROR_CANNOT_LOAD_NVCUDA, GpuErrorType.LibraryLoadFailed) },
                    { GpuDetectionMessages.PATTERN_CANNOT_LOAD_NVENC_API, (GpuDetectionMessages.ERROR_CANNOT_LOAD_NVENC_API, GpuErrorType.LibraryLoadFailed) },
                    { GpuDetectionMessages.PATTERN_FUNCTION_NOT_IMPLEMENTED, (GpuDetectionMessages.ERROR_FUNCTION_NOT_IMPLEMENTED, GpuErrorType.EncoderInitFailed) },
                    { GpuDetectionMessages.PATTERN_INVALID_ARGUMENT, (GpuDetectionMessages.ERROR_INVALID_ARGUMENT, GpuErrorType.EncoderInitFailed) },
                    { GpuDetectionMessages.PATTERN_ERROR_INIT_OUTPUT, (GpuDetectionMessages.ERROR_OUTPUT_STREAM_INIT, GpuErrorType.EncoderInitFailed) },
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
                                var driverLine = lines.FirstOrDefault(l => l.Contains(GpuDetectionMessages.PATTERN_MIN_REQUIRED_DRIVER));
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
                    _lastResult.ErrorMessage = GpuDetectionMessages.GetEncodingFailedMessage(process.ExitCode);
                    _lastResult.ErrorType = GpuErrorType.UnknownError;
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                _lastResult.ErrorMessage = GpuDetectionMessages.GetTestGpuErrorMessage(ex.Message);
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

            string message = GpuDetectionMessages.MSG_GPU_NOT_AVAILABLE + "\n\n";

            if (!string.IsNullOrEmpty(_lastResult.ErrorMessage))
            {
                message += GpuDetectionMessages.MSG_ERROR_PREFIX + _lastResult.ErrorMessage + "\n\n";
            }

            // Thêm hướng dẫn dựa trên loại lỗi
            switch (_lastResult.ErrorType)
            {
                case GpuErrorType.FfmpegNotFound:
                    message += GpuDetectionMessages.GUIDE_FFMPEG_NOT_FOUND;
                    break;

                case GpuErrorType.DriverTooOld:
                case GpuErrorType.ApiVersionMismatch:
                    message += GpuDetectionMessages.GUIDE_DRIVER_TOO_OLD;
                    break;

                case GpuErrorType.NoDeviceFound:
                    message += GpuDetectionMessages.GUIDE_NO_DEVICE_FOUND;
                    break;

                default:
                    message += GpuDetectionMessages.GUIDE_GENERAL;
                    break;
            }

            message += GpuDetectionMessages.MSG_SWITCH_TO_CPU;

            return message;
        }
    }
}
