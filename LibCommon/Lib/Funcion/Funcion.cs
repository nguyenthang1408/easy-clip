using System;
using System.IO;
using System.Collections.Generic;
using System.Net;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using NReco.VideoInfo;

namespace Lib
{
    public partial class Funcion 
    {
        public static string GetMediaTime(string mediapath)
        {
            try
            {
                FFProbe probe = new FFProbe();
                return Convert.ToString(Convert.ToInt32((double)(probe.GetMediaInfo(mediapath).Duration.TotalMilliseconds)));
            }
            catch {
                return "0";
            }
        }
        public static decimal GetVideoTime(string mediapath)
        {
            FFProbe probe = new FFProbe();
            return (decimal)probe.GetMediaInfo(mediapath).Duration.TotalMilliseconds;
        }
        public static int[] GetVideoSize(string videopath)
        {
            FFProbe probe = new FFProbe();
            var videoInfo = probe.GetMediaInfo(videopath);
            var sizeinfo = videoInfo.Streams.Single(o => o.CodecType == "video");
            return new int[] { sizeinfo.Width, sizeinfo.Height };
        }
        public static VideoProperties GetVideoSizeV2(string videopath)
        {
            FFProbe probe = new FFProbe();
            var videoInfo = probe.GetMediaInfo(videopath);
            var sizeinfo = videoInfo.Streams.Single(o => o.CodecType == "video");
            return new VideoProperties
            {
                Width = sizeinfo.Width,
                Height = sizeinfo.Height
            };
        }
        public static string selectffmpegversion()
        {
            if (Environment.Is64BitOperatingSystem)
            {
                return Application.StartupPath + "\\bin\\x64";
            }
            return Application.StartupPath + "\\bin\\x86";
        }
        public static Iobject DownloadFileAsync2(Iobject rec)
        {
            Iobject newjob = new Iobject();
            newjob = rec;
            try
            {
                using (var cts = new CancellationTokenSource(NetworkConfig.Timeout))
                {
                    var t = Task.Run(() => {
                        using (WebClient webclient = new WebClient())
                        {
                            string localPath = Path.Combine(rec.savepath, rec.filename);
                            try
                            {
                                // Đăng ký cancel WebClient khi timeout
                                cts.Token.Register(() => webclient.CancelAsync());
                                webclient.DownloadFile(rec.uri, localPath);
                                newjob.ResultCode = true;
                            }
                            catch (WebException webEx)
                            {
                                if (webEx.Response is HttpWebResponse response)
                                {
                                    newjob.ResultCode = false;
                                }
                                else
                                {
                                    newjob.ResultCode = false;
                                }
                            }
                        }
                    }, cts.Token);

                    // Chờ tác vụ hoàn thành
                    t.Wait();
                }
            }
            catch
            {
                newjob.ResultCode = false;
            }
            return newjob;
        }
        public static async Task<Iobject> DownloadFileAsync(Iobject rec, CancellationToken cancellationToken = default)
        {
            Iobject newjob = rec;
            try
            {
                string localPath = Path.Combine(rec.savepath, rec.filename);
                using (var cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken))
                {
                    cts.CancelAfter(NetworkConfig.Timeout);
                    using (var webClient = new WebClient())
                    {
                        cts.Token.Register(() => webClient.CancelAsync());
                        await webClient.DownloadFileTaskAsync(new Uri(rec.uri), localPath);
                        newjob.ResultCode = true;
                    }
                }
            }
            catch (OperationCanceledException) { throw; }
            catch (WebException ex) when (ex.Status == WebExceptionStatus.RequestCanceled)
            {
                throw new OperationCanceledException("Download cancelled", ex, cancellationToken);
            }
            catch
            {
                newjob.ResultCode = false;
            }
            return newjob;
        }

    }
    public static class ComboBoxFuncion
    {
        public static void CbBlinding(ComboBox cbname, object datasrc, int index)
        {
            if (datasrc != null)
            {
                cbname.DataSource = datasrc;
                cbname.DisplayMember = "Display";
                cbname.ValueMember = "Value";
                cbname.SelectedIndex = index;
            }
        }
    }

    public static class RandomEnum
    {
        private static Random _Random = new Random(Environment.TickCount);
        public static T Of<T>(int startindex, int? endindex = null)
        {
            if (!typeof(T).IsEnum)
                throw new InvalidOperationException("Must use Enum type");

            Array enumValues = Enum.GetValues(typeof(T));
            return (T)enumValues.GetValue(_Random.Next(startindex, endindex ?? enumValues.Length));
        }
    }

    public class CheckMedia
    {
        private static readonly string[] _validPictureExtensions = { ".jpg", ".jpeg", ".bmp", ".webp", ".png" };
        private static readonly string[] _validVideoExtensions = { ".avi", ".mp4", ".wmv", ".mkv", ".flv", ".mov" };
        private static readonly string[] _validAudioExtensions = { ".mp3", ".wma", ".wav"};

        public static MediaType GetMediaType(string mediaPath)
        {
            if (IsImageExtension(mediaPath))
                return MediaType.Picture;
            else if (IsVideoExtension(mediaPath))
            {
                return MediaType.Video;
            }
            else
            {
                return MediaType.Other;
            }
        }

        public static string CreateNewExtensionMedia(string mediaPath,string newMediaPath, string newExtension)
        {
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(mediaPath);
            return Path.Combine(newMediaPath, fileNameWithoutExtension + "." + newExtension).ToString();

        }
        public static string CreateNewExtensionMedia(string mediaPath, string newMediaPath, string newExtension, string overrideFileNameWithoutExtension = null)
        {
            string fileNameWithoutExtension = overrideFileNameWithoutExtension ?? Path.GetFileNameWithoutExtension(mediaPath);
            return Path.Combine(newMediaPath, fileNameWithoutExtension + "." + newExtension);
        }

        public static bool IsImageExtension(string ext)
        {
            return ext != null &&  _validPictureExtensions.Contains(Path.GetExtension(ext).ToLower());
        }

        public static bool IsVideoExtension(string ext)
        {
            return ext != null && _validVideoExtensions.Contains(Path.GetExtension(ext).ToLower());
        }
        public static bool IsAudioExtension(string ext)
        {
            return ext != null && _validAudioExtensions.Contains(Path.GetExtension(ext).ToLower());
        }
    }
}
