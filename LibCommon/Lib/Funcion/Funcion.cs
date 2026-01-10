using System;
using System.IO;
using System.Collections.Generic;
using System.Net;
using System.Linq;
using System.Text;
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
                //var t = Task.Run(() => {
                //    using (WebClient webclient = new WebClient())
                //    {
                //        string localPath = Path.Combine(rec.savepath, rec.filename);
                //        webclient.DownloadFile(rec.uri, localPath);
                //    }
                //});
                //t.Wait();
                //newjob.ResultCode = true;

                var t = Task.Run(() => {
                    using (WebClient webclient = new WebClient())
                    {
                        string localPath = Path.Combine(rec.savepath, rec.filename);
                        try
                        {
                            webclient.DownloadFile(rec.uri, localPath);
                            newjob.ResultCode = true;
                        }
                        catch (WebException webEx)
                        {
                            if (webEx.Response is HttpWebResponse response)
                            {
                                if ((int)response.StatusCode == 402)
                                {
                                    //Console.WriteLine("Lỗi 402: Payment Required. Vui lòng kiểm tra quyền truy cập hoặc thanh toán.");
                                    newjob.ResultCode = false;
                                }
                                else
                                {
                                    //Console.WriteLine($"Lỗi HTTP: {(int)response.StatusCode} - {response.StatusDescription}");
                                    newjob.ResultCode = false;
                                }
                            }
                            else
                            {
                                //Console.WriteLine($"Lỗi mạng: {webEx.Message}");
                                newjob.ResultCode = false;
                            }
                        }
                    }
                });

                // Chờ tác vụ hoàn thành
                t.Wait();
            }
            catch
            {
                newjob.ResultCode = false;
            }
            return newjob;
        }
        public static async Task<Iobject> DownloadFileAsync(Iobject rec)
        {
            Iobject newjob = rec;
            try
            {
                using (WebClient webclient = new WebClient())
                {
                    string localPath = Path.Combine(rec.savepath, rec.filename);
                    try
                    {
                        await webclient.DownloadFileTaskAsync(new Uri(rec.uri), localPath);
                        newjob.ResultCode = true;
                    }
                    catch (WebException webEx)
                    {
                        if (webEx.Response is HttpWebResponse response)
                        {
                            if ((int)response.StatusCode == 402)
                            {
                                //Console.WriteLine("Lỗi 402: Payment Required. Vui lòng kiểm tra quyền truy cập hoặc thanh toán.");
                                newjob.ResultCode = false;
                            }
                            else
                            {
                                //Console.WriteLine($"Lỗi HTTP: {(int)response.StatusCode} - {response.StatusDescription}");
                                newjob.ResultCode = false;
                            }
                        }
                        else
                        {
                            //Console.WriteLine($"Lỗi mạng: {webEx.Message}");
                            newjob.ResultCode = false;
                        }
                    }
                }
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
                cbname.BeginUpdate();
                try
                {
                    cbname.DataSource = datasrc;
                    cbname.DisplayMember = "Display";
                    cbname.ValueMember = "Value";

                    // Safe select: avoid ArgumentException when datasource is empty
                    if (cbname.Items != null && cbname.Items.Count > 0)
                    {
                        int safeIndex = index;
                        if (safeIndex < 0) safeIndex = 0;
                        if (safeIndex >= cbname.Items.Count) safeIndex = cbname.Items.Count - 1;
                        cbname.SelectedIndex = safeIndex;
                    }
                    else
                    {
                        cbname.SelectedIndex = -1;
                    }
                }
                finally
                {
                    cbname.EndUpdate();
                }
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
