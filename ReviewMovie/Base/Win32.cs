using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ReviewMovie.Base
{
    internal static class Win32
    {
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;

        internal static void BeginDrag(Form form)
        {
            if (form == null) return;
            try
            {
                ReleaseCapture();
                SendMessage(form.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
            catch
            {
                // Best-effort; ignore if not supported in some environments.
            }
        }
    }
}

