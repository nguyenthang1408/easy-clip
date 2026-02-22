using EasyClip;
using System;
using System.Threading;
using System.Windows.Forms;
using MessageBox = ReviewMovie.Base.UiMessageBox;

namespace ReviewMovie
{
    static class Program
    {
        // Mutex để kiểm tra xem ứng dụng đã chạy hay chưa
        static Mutex mutex = new Mutex(true, "{868B3366-2A9A-40B5-9BB8-64475CC34735}");

        ///// <summary>
        ///// The main entry point for the application.
        ///// </summary>
        //[STAThread]
        //static void Main()
        //{
        //    Application.EnableVisualStyles();
        //    Application.SetCompatibleTextRenderingDefault(false);
        //    Application.Run(new FormMain());
        //}

        [STAThread]
        static void Main()
        {
            // Kiểm tra xem ứng dụng đã chạy hay chưa
            if (mutex.WaitOne(TimeSpan.Zero, true))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new LoginApiKey());
                mutex.ReleaseMutex();
            }
            else
            {
                // Nếu ứng dụng đã chạy, hiển thị hộp thoại xác nhận
                DialogResult result = MessageBox.Show(
                    "Ứng dụng đã chạy. Bạn có muốn mở thêm một phiên bản không?",
                    "Thông báo",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new LoginApiKey());
                }
                else
                {
                    Application.Exit();
                }
            }
        }
    }
}
