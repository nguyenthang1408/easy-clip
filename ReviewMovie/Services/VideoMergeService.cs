using Lib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;

namespace EasyClip.Services
{
    /// <summary>
    /// Service để merge video files bằng FFmpeg
    /// </summary>
    public class VideoMergeService
    {
        /// <summary>
        /// Run FFmpeg với progress tracking cho merge video
        /// </summary>
        public int RunFFmpegMerge(
            string ffmpegPath,
            string arguments,
            int validVideoCount,
            CancellationToken cancellationToken,
            Action<string> progressCallback = null)
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
                var timeRegex = new Regex(@"time=(\d+):(\d+):(\d+\.\d+)");

                process.ErrorDataReceived += (sender, e) =>
                {
                    if (!string.IsNullOrEmpty(e.Data))
                    {
                        var match = timeRegex.Match(e.Data);
                        if (match.Success)
                        {
                            string hours = match.Groups[1].Value;
                            string minutes = match.Groups[2].Value;
                            string seconds = match.Groups[3].Value;
                            string timeStr = $"{hours}:{minutes}:{seconds.Split('.')[0]}";

                            try
                            {
                                progressCallback?.Invoke($"Đang ghép {validVideoCount} video - Time: {timeStr}");
                            }
                            catch { }
                        }
                    }
                };

                using (cancellationToken.Register(() =>
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

                        while (!process.WaitForExit(200))
                        {
                            if (cancellationToken.IsCancellationRequested)
                            {
                                return -1;
                            }
                        }

                        process.WaitForExit();
                        return process.ExitCode;
                    }
                    catch
                    {
                        return -1;
                    }
                }
            }
        }

        /// <summary>
        /// Tạo file danh sách video cho FFmpeg concat
        /// </summary>
        public void CreateConcatFile(string filePath, List<string> videoList)
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Dispose();
            }
            File.WriteAllText(filePath, "");

            foreach (string videoPath in videoList)
            {
                using (StreamWriter w = File.AppendText(filePath))
                {
                    w.WriteLine("file '" + videoPath + "'");
                    w.Close();
                }
            }
        }

        /// <summary>
        /// Ghi log file cho video lỗi
        /// </summary>
        public bool WriteErrorLog(
            string logFilePath,
            string outputFolderName,
            string outputFileName,
            string outputVideoPath,
            int totalVideos,
            int validVideos,
            List<string> corruptedVideos)
        {
            try
            {
                using (StreamWriter log = new StreamWriter(logFilePath, false, System.Text.Encoding.UTF8))
                {
                    log.WriteLine("=== LOG GHÉP VIDEO ===");
                    log.WriteLine($"Thời gian: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                    log.WriteLine($"Output folder: {outputFolderName}");
                    log.WriteLine($"Output file: {outputFileName}");
                    log.WriteLine($"Output path: {outputVideoPath}");
                    log.WriteLine();
                    log.WriteLine($"=== THỐNG KÊ ===");
                    log.WriteLine($"Tổng số video: {totalVideos}");
                    log.WriteLine($"Video hợp lệ: {validVideos}");
                    log.WriteLine($"Video lỗi: {corruptedVideos.Count}");
                    log.WriteLine();
                    log.WriteLine($"=== DANH SÁCH VIDEO LỖI ({corruptedVideos.Count}) ===");
                    for (int i = 0; i < corruptedVideos.Count; i++)
                    {
                        log.WriteLine($"{i + 1}. {corruptedVideos[i]}");
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Không thể ghi log file: {ex.Message}");
                return false;
            }
        }
    }
}
