using Lib;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EasyClip.Services
{
    /// <summary>
    /// Service để validate video files bằng ffprobe
    /// </summary>
    public class VideoValidationService
    {
        private readonly int _maxParallelThreads;

        public VideoValidationService(int maxParallelThreads = 20)
        {
            _maxParallelThreads = maxParallelThreads;
        }

        /// <summary>
        /// Validate video file using ffprobe
        /// </summary>
        public bool ValidateVideo(string videoPath, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                string ffprobePath = Funcion.selectffmpegversion() + "\\ffprobe.exe";
                string arguments = $"-v error -show_entries format=duration -of default=noprint_wrappers=1:nokey=1 \"{videoPath}\"";

                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = ffprobePath,
                    Arguments = arguments,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process process = new Process { StartInfo = psi })
                {
                    process.Start();
                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();
                    process.WaitForExit();

                    if (process.ExitCode != 0)
                    {
                        errorMessage = $"FFprobe error (Exit code: {process.ExitCode})";
                        if (!string.IsNullOrEmpty(error))
                        {
                            errorMessage += $" - {error.Trim()}";
                        }
                        return false;
                    }

                    if (string.IsNullOrWhiteSpace(output))
                    {
                        errorMessage = "No duration found - video may be corrupted";
                        return false;
                    }

                    if (!double.TryParse(output.Trim(), out double duration) || duration <= 0)
                    {
                        errorMessage = "Invalid duration - video may be corrupted";
                        return false;
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                errorMessage = $"Exception: {ex.Message}";
                return false;
            }
        }

        /// <summary>
        /// Validate nhiều video song song với progress callback
        /// </summary>
        public void ValidateVideosParallel(
            List<string> videoFiles,
            out List<string> validVideos,
            out List<string> corruptedVideos,
            CancellationToken cancellationToken,
            Action<int, int> progressCallback = null)
        {
            int totalVideos = videoFiles.Count;
            int processedCount = 0;
            object lockObj = new object();

            progressCallback?.Invoke(0, totalVideos);

            var validVideoList = new ConcurrentBag<(string path, int index)>();
            var corruptedVideoList = new ConcurrentBag<string>();

            var options = new ParallelOptions
            {
                MaxDegreeOfParallelism = _maxParallelThreads,
                CancellationToken = cancellationToken
            };

            Parallel.For(0, videoFiles.Count, options, i =>
            {
                string videoPath = videoFiles[i];
                string fileName = System.IO.Path.GetFileName(videoPath);

                if (ValidateVideo(videoPath, out string errorMessage))
                {
                    validVideoList.Add((videoPath, i));
                }
                else
                {
                    corruptedVideoList.Add(fileName);
                    Console.WriteLine($"[SKIP] Video lỗi: {fileName}");
                }

                lock (lockObj)
                {
                    processedCount++;
                    if (processedCount % 10 == 0 || processedCount == totalVideos)
                    {
                        int currentCount = processedCount;
                        progressCallback?.Invoke(currentCount, totalVideos);
                    }
                }
            });

            validVideos = validVideoList.OrderBy(x => x.index).Select(x => x.path).ToList();
            corruptedVideos = corruptedVideoList.OrderBy(x => x).ToList();
        }
    }
}
