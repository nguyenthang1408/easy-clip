using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Lib
{
    public class RecordAudio
    {
        public RecordAudio(){ }

        [DllImport("winmm.dll", EntryPoint = "mciSendStringA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int mciSendString(string lpstrCommand, string lpstrReturnString, int uReturnLength, int hwndCallback);

        public static void DestroyRecord()
        {
            mciSendString("close recsound", "", 0, 0);
        }
        public static bool StartRecord()
        {
            mciSendString("open new Type waveaudio Alias recsound", null, 0, 0);
            mciSendString("set recsound time format ms bitspersample 16 channels 1 samplespersec 48000 bytespersec 192000 alignment 4", null, 0, 0);
            mciSendString("record recsound", null, 0, 0);
            return true;
        }
        public static void EndRecord(string savefilePath)
        {
            mciSendString("save recsound " + savefilePath, "", 0, 0);
            mciSendString("close recsound", "", 0, 0);
        }
        public static void RemoveNoise(string infile , string outfile)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(string.Format(" -y -i \"{0}\" -af \"afftdn=nr=10:nf=-30:tn = 1\" \"{1}\" ", infile, outfile));
            string str2 = builder.ToString();
            Process process = new Process();
            ProcessStartInfo info = new ProcessStartInfo
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = Funcion.selectffmpegversion() + "\\ffmpeg.exe",
                Arguments = str2
            };
            process.StartInfo = info;
            try
            {
                process.Start();
                process.WaitForExit();
            }
            catch
            {
            }
        }
    }
}
