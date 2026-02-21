using LibCommon.Lib;
using LibCommon.Lib.Localization;
using ReviewMovie.Localization;
using System;
using System.Threading;
using System.Windows.Forms;

namespace ReviewMovie
{
    static class Program
    {
        // Mutex để kiểm tra xem ứng dụng đã chạy hay chưa
        static Mutex mutex = new Mutex(true, "{868B3366-2A9A-40B5-9BB8-64475CC34735}");

        [STAThread]
        static void Main()
        {
            // Load ngôn ngữ đã lưu
            LanguageManager.LoadSavedLanguage();

            // Wire up localization delegates
            VersionMessageHelper.GetLocalizedText = LanguageManager.Get;
            LibLocalizer.GetText = LanguageManager.Get;
            LibLocalizer.GetCurrentLanguage = () => LanguageManager.CurrentLanguage == LanguageManager.Language.En ? "en" : "vi";

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
                    LanguageManager.Get(LangKeys.Program_AlreadyRunning),
                    LanguageManager.Get(LangKeys.Common_Notice),
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
