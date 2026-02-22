using System.Windows.Forms;

namespace EasyClip.View.DialogMessage
{
    /// <summary>
    /// Drop-in replacement for MessageBox.Show() using custom DialogMsg form.
    /// </summary>
    public static class MsgBox
    {
        // ==== Simple overloads (message only) ====

        public static DialogResult Show(string message)
        {
            return Show(message, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult Show(string message, string caption)
        {
            return Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult Show(string message, string caption, MessageBoxButtons buttons)
        {
            return Show(message, caption, buttons, MessageBoxIcon.Information);
        }

        // ==== Main overload ====

        public static DialogResult Show(string message, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            var type = MapIconToType(icon);
            bool showYesNo = (buttons == MessageBoxButtons.YesNo || buttons == MessageBoxButtons.YesNoCancel);

            using (var dlg = new DialogMsg(message, caption, type, showYesNo))
            {
                return dlg.ShowDialog();
            }
        }

        // ==== Overload with owner (IWin32Window) ====

        public static DialogResult Show(IWin32Window owner, string message, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            var type = MapIconToType(icon);
            bool showYesNo = (buttons == MessageBoxButtons.YesNo || buttons == MessageBoxButtons.YesNoCancel);

            using (var dlg = new DialogMsg(message, caption, type, showYesNo))
            {
                return dlg.ShowDialog(owner);
            }
        }

        // ==== Overload with DefaultButton (ignored, for compatibility) ====

        public static DialogResult Show(string message, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {
            return Show(message, caption, buttons, icon);
        }

        // ==== Typed convenience methods ====

        public static void Info(string message, string caption = "")
        {
            using (var dlg = new DialogMsg(message, caption, DialogMsg.MsgType.Info, false))
            {
                dlg.ShowDialog();
            }
        }

        public static void Success(string message, string caption = "")
        {
            using (var dlg = new DialogMsg(message, caption, DialogMsg.MsgType.Success, false))
            {
                dlg.ShowDialog();
            }
        }

        public static void Warn(string message, string caption = "")
        {
            using (var dlg = new DialogMsg(message, caption, DialogMsg.MsgType.Warning, false))
            {
                dlg.ShowDialog();
            }
        }

        public static void Error(string message, string caption = "")
        {
            using (var dlg = new DialogMsg(message, caption, DialogMsg.MsgType.Error, false))
            {
                dlg.ShowDialog();
            }
        }

        public static DialogResult Confirm(string message, string caption = "")
        {
            using (var dlg = new DialogMsg(message, caption, DialogMsg.MsgType.Confirm, true))
            {
                return dlg.ShowDialog();
            }
        }

        // ==== Helper ====

        private static DialogMsg.MsgType MapIconToType(MessageBoxIcon icon)
        {
            switch (icon)
            {
                case MessageBoxIcon.Error:
                    return DialogMsg.MsgType.Error;
                case MessageBoxIcon.Warning:
                case MessageBoxIcon.Exclamation:
                    return DialogMsg.MsgType.Warning;
                case MessageBoxIcon.Question:
                    return DialogMsg.MsgType.Confirm;
                case MessageBoxIcon.Information:
                case MessageBoxIcon.Asterisk:
                    return DialogMsg.MsgType.Info;
                default:
                    return DialogMsg.MsgType.Info;
            }
        }
    }
}
