using System;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyClip.Services
{
    public interface IClipPlayerService
    {
        void StartClipPlayer(string videoPath, int easyClipX, int easyClipY, int easyClipWidth, int easyClipHeight);
        void CloseClipPlayer();
        void SendVideoPathToClipPlayer(string videoPath);
        void ListenForClipPlayerMessages(Action<string> onMessageReceived);
        void MoveClipPlayerToRight(int easyClipX, int easyClipY, int easyClipWidth, int easyClipHeight);
    }

    public class ClipPlayerService : IClipPlayerService
    {
        private Process _clipPlayerProcess = null;
        private const string PipeToClipPlayer = "ClipPlayerPipe";
        private const string PipeFromClipPlayer = "EasyClipPipe";
        private readonly object _lock = new object();


        public void StartClipPlayer(string videoPath, int easyClipX, int easyClipY, int easyClipWidth, int easyClipHeight)
        {
            lock (_lock)
            {
                string clipPlayerPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ClipPlayer", "ClipPlayer.exe");
                if (!File.Exists(clipPlayerPath))
                {
                    throw new FileNotFoundException("Không tìm thấy ClipPlayer.exe");
                }

                _clipPlayerProcess = Process.GetProcessesByName("ClipPlayer").FirstOrDefault();
                if (_clipPlayerProcess == null || _clipPlayerProcess.HasExited)
                {
                    _clipPlayerProcess = new Process
                    {
                        StartInfo = new ProcessStartInfo
                        {
                            FileName = clipPlayerPath,
                            Arguments = $"\"{videoPath}\"",
                            UseShellExecute = true
                        }
                    };

                    _clipPlayerProcess.Start();
                    AssignProcessToJobWithAutoKill(_clipPlayerProcess);
                    Task.Delay(500).Wait();

                    MoveClipPlayerToRight(easyClipX, easyClipY, easyClipWidth, easyClipHeight);
                }
                else
                {
                    SendVideoPathToClipPlayer(videoPath);
                }
            }
        }

        public void CloseClipPlayer()
        {
            try
            {
                using (var pipeClient = new NamedPipeClientStream(".", PipeToClipPlayer, PipeDirection.Out))
                {
                    pipeClient.Connect(300); // timeout nhanh
                    using (var writer = new StreamWriter(pipeClient))
                    {
                        writer.WriteLine("__exit__"); // Gửi tín hiệu shutdown
                        writer.Flush();
                    }
                }
            }
            catch
            {
                // Không cần xử lý nếu pipe chưa kết nối được (ClipPlayer đã đóng rồi)
            }
        }


        public void SendVideoPathToClipPlayer(string videoPath)
        {
            try
            {
                using (NamedPipeClientStream pipeClient = new NamedPipeClientStream(".", PipeToClipPlayer, PipeDirection.Out))
                {
                    pipeClient.Connect(500);
                    using (StreamWriter writer = new StreamWriter(pipeClient))
                    {
                        writer.WriteLine(videoPath);
                        writer.Flush();
                    }
                }
            }
            catch (IOException)
            {
                throw new IOException("Pipe đang bận, thử lại sau.");
            }
        }

        public void ListenForClipPlayerMessages(Action<string> onMessageReceived)
        {
            Task.Run(() =>
            {
                while (true)
                {
                    try
                    {
                        using (NamedPipeServerStream pipeServer = new NamedPipeServerStream(PipeFromClipPlayer, PipeDirection.In))
                        {
                            pipeServer.WaitForConnection();
                            using (StreamReader reader = new StreamReader(pipeServer))
                            {
                                string message = reader.ReadLine();
                                if (!string.IsNullOrEmpty(message))
                                {
                                    onMessageReceived?.Invoke(message);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Lỗi nhận dữ liệu từ ClipPlayer: " + ex.Message);
                    }
                }
            });
        }

        public void MoveClipPlayerToRight(int easyClipX, int easyClipY, int easyClipWidth, int easyClipHeight)
        {
            try
            {
                if (_clipPlayerProcess == null || _clipPlayerProcess.HasExited)
                    return;

                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        _clipPlayerProcess.Refresh();

                        if (_clipPlayerProcess.HasExited)
                            return;

                        if (_clipPlayerProcess.MainWindowHandle != IntPtr.Zero)
                            break;
                    }
                    catch (InvalidOperationException)
                    {
                        return; // process đã thoát
                    }

                    Thread.Sleep(100);
                }

                IntPtr hWnd = IntPtr.Zero;
                try
                {
                    hWnd = _clipPlayerProcess.MainWindowHandle;
                }
                catch
                {
                    return; // Đề phòng lỗi khi lấy MainWindowHandle
                }

                if (hWnd == IntPtr.Zero)
                    return;

                int clipPlayerWidth = 800;
                int clipPlayerHeight = 450;
                int clipPlayerX = easyClipX + easyClipWidth + 10;
                int clipPlayerY = easyClipY;

                Screen screen = Screen.FromPoint(new System.Drawing.Point(easyClipX, easyClipY));
                int screenWidth = screen.WorkingArea.Width;
                int screenHeight = screen.WorkingArea.Height;

                if (clipPlayerX + clipPlayerWidth > screenWidth)
                    clipPlayerX = screenWidth - clipPlayerWidth;
                if (clipPlayerY + clipPlayerHeight > screenHeight)
                    clipPlayerY = screenHeight - clipPlayerHeight;
                if (clipPlayerY < 0) clipPlayerY = 0;

                SetWindowPos(hWnd, IntPtr.Zero, clipPlayerX, clipPlayerY, clipPlayerWidth, clipPlayerHeight, 0);
            }
            catch (Exception ex)
            {
                // Log lỗi hoặc thông báo nhẹ nhàng
                Debug.WriteLine("MoveClipPlayerToRight error: " + ex.Message);
            }
        }


        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        #region Job Object (Kill ClipPlayer When Close EasyClip )

        [StructLayout(LayoutKind.Sequential)]
        struct JOBOBJECT_BASIC_LIMIT_INFORMATION
        {
            public long PerProcessUserTimeLimit;
            public long PerJobUserTimeLimit;
            public uint LimitFlags;
            public UIntPtr MinimumWorkingSetSize;
            public UIntPtr MaximumWorkingSetSize;
            public uint ActiveProcessLimit;
            public long Affinity;
            public uint PriorityClass;
            public uint SchedulingClass;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct IO_COUNTERS
        {
            public ulong ReadOperationCount;
            public ulong WriteOperationCount;
            public ulong OtherOperationCount;
            public ulong ReadTransferCount;
            public ulong WriteTransferCount;
            public ulong OtherTransferCount;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct JOBOBJECT_EXTENDED_LIMIT_INFORMATION
        {
            public JOBOBJECT_BASIC_LIMIT_INFORMATION BasicLimitInformation;
            public IO_COUNTERS IoInfo;
            public UIntPtr ProcessMemoryLimit;
            public UIntPtr JobMemoryLimit;
            public UIntPtr PeakProcessMemoryUsed;
            public UIntPtr PeakJobMemoryUsed;
        }

        enum JobObjectInfoType
        {
            ExtendedLimitInformation = 9
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        static extern IntPtr CreateJobObject(IntPtr lpJobAttributes, string lpName);

        [DllImport("kernel32.dll")]
        static extern bool SetInformationJobObject(IntPtr hJob, JobObjectInfoType infoType, IntPtr lpJobObjectInfo, uint cbJobObjectInfoLength);

        [DllImport("kernel32.dll")]
        static extern bool AssignProcessToJobObject(IntPtr job, IntPtr processHandle);

        private static void AssignProcessToJobWithAutoKill(Process process)
        {
            IntPtr hJob = CreateJobObject(IntPtr.Zero, null);

            var info = new JOBOBJECT_EXTENDED_LIMIT_INFORMATION();
            info.BasicLimitInformation.LimitFlags = 0x2000; // JOB_OBJECT_LIMIT_KILL_ON_JOB_CLOSE

            int length = Marshal.SizeOf(typeof(JOBOBJECT_EXTENDED_LIMIT_INFORMATION));
            IntPtr infoPtr = Marshal.AllocHGlobal(length);
            Marshal.StructureToPtr(info, infoPtr, false);

            SetInformationJobObject(hJob, JobObjectInfoType.ExtendedLimitInformation, infoPtr, (uint)length);
            AssignProcessToJobObject(hJob, process.Handle);

            Marshal.FreeHGlobal(infoPtr);
        }

        #endregion

    }
}
