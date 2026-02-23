using Lib;
using NReco.VideoInfo;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace LibCommon.Common
{
    public static class FFmpegFuncion
    {
        public static int GetaudioTime(string string_0)
        {
            FFProbe probe = new FFProbe();
            return Convert.ToInt32((double)(probe.GetMediaInfo(string_0).Duration.TotalSeconds));
        }
        public static string timecutvideo(string string_0, string string_1)
        {
            FFProbe probe = new FFProbe();
            return Convert.ToString((probe.GetMediaInfo(string_0).Duration.TotalMilliseconds / 1000) - Convert.ToDouble(string_1));
        }
        public static string timesplitvideo(string string_0)
        {
            FFProbe probe = new FFProbe();
            return Convert.ToString(Convert.ToInt32((double)(probe.GetMediaInfo(string_0).Duration.TotalSeconds)));
        }
        public static string timesplitvideopart(string string_0)
        {
            FFProbe probe = new FFProbe();
            return Convert.ToString(probe.GetMediaInfo(string_0).Duration.TotalMilliseconds);
        }
        public static decimal timeOfVideoPart(string filePath)
        {
            FFProbe probe = new FFProbe();
            return (decimal)(probe.GetMediaInfo(filePath).Duration.TotalMilliseconds / 1000);
        }
        public static bool CheckIfVideoHasAudio(string videoPath)
        {
            try
            {
                var ffProbe = new FFProbe();
                var videoInfo = ffProbe.GetMediaInfo(videoPath);

                // Check audio
                return videoInfo.Streams.Any(s => s.CodecType == "audio");
            }
            catch
            {
                return false;
            }
        }
    }
    public static class CFuncion
    {
        private static readonly string[] _validPictureExtensions = { ".jpg", ".jpeg", ".bmp", ".webp", ".png" };
        private static readonly string[] _validVideoExtensions = { ".avi", ".mp4", ".wmv", ".mkv", ".flv", ".mov" };
        private static readonly string[] _validAudioExtensions = { ".mp3", ".wma", ".wav" };

        public static string ConvertSecondsToTime(int seconds)
        {
            int hours = seconds / 3600;
            int minutes = (seconds % 3600) / 60;
            int remainingSeconds = (seconds % 3600) % 60;

            string time = $"{hours:00}:{minutes:00}:{remainingSeconds:00}";
            return time;
        }
        public static decimal ConvertTimetoString(string s)
        {
            var match = Regex.Match(s, "[0-9]+:[0-9]+:[0-9]+([,\\.][0-9]+)?");
            if (match.Success)
            {
                s = match.Value;
                TimeSpan result;
                if (TimeSpan.TryParse(s.Replace(',', '.'), out result))
                {
                    var nbOfMs = (decimal)result.TotalMilliseconds;
                    return nbOfMs;
                }
            }
            return -1;
        }
        public static decimal ConvertTimetoString(TimeSpan s)
        {
            var nbOfMs = (decimal)s.TotalMilliseconds / 1000;
            return nbOfMs;
        }

        public static bool CheckMediaType(string mediaPath)
        {
            if (IsImageExtension(mediaPath))
                return true;
            else if (IsVideoExtension(mediaPath))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool IsImageExtension(string ext)
        {
            return _validPictureExtensions.Contains(Path.GetExtension(ext).ToLower());
        }

        public static bool IsVideoExtension(string ext)
        {
            return _validVideoExtensions.Contains(Path.GetExtension(ext).ToLower());
        }

        public static string FindFullNameMediaPath(string folderPath, string fileNameWithoutExtension)
        {
            // Kiểm tra xem thư mục tồn tại hay không
            if (Directory.Exists(folderPath))
            {
                // Tìm kiếm tất cả các tập tin trong thư mục
                var files = Directory.EnumerateFiles(folderPath);

                // Lọc các tập tin có tên trùng khớp (không phân biệt hoa thường)
                var matchingFiles = files.Where(file =>
                    Path.GetFileNameWithoutExtension(file)
                        .Equals(fileNameWithoutExtension, StringComparison.OrdinalIgnoreCase)).ToList();

                if (matchingFiles.Any())
                {
                    return matchingFiles[0];
                }
                else
                {
                    return string.Empty;
                }
            }
            else
            {
                return string.Empty;
            }
        }

        public static bool AddSilentAudio(string inputVideo, string outputVideo)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = Funcion.selectffmpegversion() + "\\ffmpeg.exe",
                    Arguments = $"-y -i \"{inputVideo}\" -f lavfi -i anullsrc -c:v copy -c:a aac -shortest \"{outputVideo}\"",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process process = new Process { StartInfo = psi })
                {
                    process.Start();
                    string output = process.StandardError.ReadToEnd();
                    process.WaitForExit();

                    if (process.ExitCode == 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        public static bool RunFFmpeg_Old(string ffmpegPath, string arguments)
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = ffmpegPath,
                    Arguments = arguments,
                    RedirectStandardError = true, // FFmpeg log vào stderr
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };

            StringBuilder error = new StringBuilder();

            process.ErrorDataReceived += (sender, e) => { if (e.Data != null) error.AppendLine(e.Data); };

            process.Start();
            process.BeginErrorReadLine();
            process.WaitForExit(); // Chờ FFmpeg kết thúc

            string finalError = error.ToString().ToLower(); // Chuyển log về lowercase để so sánh dễ hơn

            // Kiểm tra nếu có lỗi nghiêm trọng
            if (process.ExitCode != 0 ||
                finalError.Contains("conversion failed") ||
                finalError.Contains("nothing was written into output file") ||
                finalError.Contains("error") ||
                finalError.Contains("invalid argument"))
            {
                return false; // Quá trình render thất bại
            }

            // Kiểm tra có frame được encode không
            if (finalError.Contains("frame="))
            {
                return true; // Thành công
            }

            return false; // Nếu không có "frame=", coi như thất bại
        }

        public static bool RunFFmpeg(string ffmpegPath, string arguments, CancellationToken token)
        {
            return RunFFmpeg(ffmpegPath, arguments, token, null);
        }

        /// <summary>
        /// Chạy FFmpeg với progress callback để hiển thị tốc độ render
        /// </summary>
        /// <param name="ffmpegPath">Đường dẫn FFmpeg</param>
        /// <param name="arguments">Arguments</param>
        /// <param name="token">CancellationToken</param>
        /// <param name="progressCallback">Callback nhận speed (vd: "2.23x")</param>
        public static bool RunFFmpeg(string ffmpegPath, string arguments, CancellationToken token, Action<string> progressCallback)
        {
            using (var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = ffmpegPath,
                    Arguments = arguments,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            })
            {
                StringBuilder error = new StringBuilder();
                process.ErrorDataReceived += (sender, e) =>
                {
                    if (!string.IsNullOrEmpty(e.Data))
                    {
                        error.AppendLine(e.Data);

                        // Parse và gọi progress callback nếu có
                        if (progressCallback != null)
                        {
                            string speed = ParseRenderSpeed(e.Data);
                            if (!string.IsNullOrEmpty(speed))
                            {
                                progressCallback(speed);
                            }
                        }
                    }
                };

                // Đăng ký callback cho token: nếu Cancel thì kill process
                using (token.Register(() =>
                {
                    try
                    {
                        if (!process.HasExited)
                            process.Kill();
                    }
                    catch { }
                }))
                {
                    try
                    {
                        process.Start();
                        process.BeginErrorReadLine();

                        // Lặp chờ process kết thúc hoặc bị cancel
                        while (!process.WaitForExit(200))
                        {
                            if (token.IsCancellationRequested)
                            {
                                // Đã cancel, process đã bị kill bởi token.Register callback
                                // Chờ process thoát hẳn trước khi return
                                try { process.WaitForExit(3000); } catch { }
                                return false;
                            }
                        }

                        // Process đã kết thúc - kiểm tra có phải do cancel kill không
                        if (token.IsCancellationRequested)
                        {
                            return false;
                        }
                    }
                    catch
                    {
                        return false;
                    }
                }

                string finalError = error.ToString().ToLowerInvariant();

                if (process.ExitCode != 0 ||
                    finalError.Contains("conversion failed") ||
                    finalError.Contains("nothing was written into output file") ||
                    finalError.Contains("error") ||
                    finalError.Contains("invalid argument"))
                {
                    return false;
                }

                if (finalError.Contains("frame="))
                {
                    return true;
                }

                return false;
            }
        }

        /// <summary>
        /// Parse tốc độ render từ FFmpeg output
        /// Example: "frame=  283 fps= 67 q=25.0 size=3840KiB time=00:00:09.36 bitrate=3358.5kbits/s speed=2.23x"
        /// </summary>
        private static string ParseRenderSpeed(string ffmpegOutput)
        {
            if (string.IsNullOrEmpty(ffmpegOutput))
                return null;

            try
            {
                // Tìm "speed=" trong output
                int speedIndex = ffmpegOutput.IndexOf("speed=");
                if (speedIndex >= 0)
                {
                    // Lấy phần sau "speed="
                    string speedPart = ffmpegOutput.Substring(speedIndex + 6); // 6 = length of "speed="

                    // Tìm khoảng trắng hoặc ký tự không phải số/dấu chấm/'x' đầu tiên
                    int endIndex = 0;
                    for (int i = 0; i < speedPart.Length; i++)
                    {
                        char c = speedPart[i];
                        if (char.IsDigit(c) || c == '.' || c == 'x')
                        {
                            endIndex = i + 1;
                        }
                        else
                        {
                            break;
                        }
                    }

                    if (endIndex > 0)
                    {
                        string speed = speedPart.Substring(0, endIndex);
                        return speed; // Trả về "2.23x"
                    }
                }
            }
            catch
            {
                // Ignore parsing errors
            }

            return null;
        }

    }
}
