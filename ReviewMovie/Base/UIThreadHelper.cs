using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using EasyClip.View.DialogMessage;
using MessageBox = ReviewMovie.Base.UiMessageBox;

namespace ReviewMovie
{
    public static class UIThreadHelper
    {
        public static void SetButtonText(Button button, string message, Color color)
        {
            if (button == null || button.IsDisposed) return;

            try
            {
                if (button.InvokeRequired)
                {
                    button.BeginInvoke(new Action(() =>
                    {
                        if (!button.IsDisposed)
                        {
                            button.ForeColor = color;
                            button.Text = message;
                        }
                    }));
                }
                else
                {
                    button.ForeColor = color;
                    button.Text = message;
                }
            }
            catch (ObjectDisposedException)
            {
                // Control đã bị dispose, bỏ qua
            }
        }

        public static void SetMenuItemText(ToolStripMenuItem menuItem, string message, Color color)
        {
            if (menuItem == null || menuItem.IsDisposed) return;

            try
            {
                if (menuItem.Owner.InvokeRequired)
                {
                    menuItem.Owner.BeginInvoke(new Action(() =>
                    {
                        if (!menuItem.IsDisposed)
                        {
                            menuItem.ForeColor = color;
                            menuItem.Text = message;
                        }
                    }));
                }
                else
                {
                    menuItem.ForeColor = color;
                    menuItem.Text = message;
                }
            }
            catch (ObjectDisposedException)
            {
                // Control đã bị dispose, bỏ qua
            }
        }


        public static void SetLabelText(Control label, string message, Color color, ToolTip toolTip = null, string tooltipText = null)
        {
            if (label == null || label.IsDisposed) return;

            try
            {
                if (label.InvokeRequired)
                {
                    label.BeginInvoke(new Action(() =>
                    {
                        if (!label.IsDisposed)
                        {
                            label.ForeColor = color;
                            label.Text = message;
                            if (toolTip != null)
                                toolTip.SetToolTip(label, tooltipText ?? string.Empty);
                        }
                    }));
                }
                else
                {
                    label.ForeColor = color;
                    label.Text = message;
                    if (toolTip != null)
                        toolTip.SetToolTip(label, tooltipText ?? string.Empty);
                }
            }
            catch (ObjectDisposedException)
            {
                // Control đã bị dispose, bỏ qua
            }
        }

        public static void SetTextboxText(TextBox textbox, string message)
        {
            if (textbox == null || textbox.IsDisposed) return;

            try
            {
                if (textbox.InvokeRequired)
                {
                    textbox.BeginInvoke(new Action(() =>
                    {
                        if (!textbox.IsDisposed)
                        {
                            textbox.Text = message;
                        }
                    }));
                }
                else
                {
                    textbox.Text = message;
                }
            }
            catch (ObjectDisposedException)
            {
                // Control đã bị dispose, bỏ qua
            }
        }

        public static DialogResult ShowMessageBoxSafe(
         Form owner,
         string text,
         string caption,
         MessageBoxButtons buttons = MessageBoxButtons.OK,
         MessageBoxIcon icon = MessageBoxIcon.None)
        {
            // Đảm bảo chỉ gọi MessageBox khi owner còn tồn tại
            if (owner == null || owner.IsDisposed || !owner.IsHandleCreated)
                return DialogResult.None;

            if (owner.InvokeRequired)
            {
                return (DialogResult)owner.Invoke(new Func<DialogResult>(() =>
                    MsgBox.Show(owner, text, caption, buttons, icon)
                ));
            }
            else
            {
                // Đảm bảo MessageBox hiển thị đúng context UI
                Application.DoEvents(); // Đảm bảo vẽ lại UI trước khi show MessageBox (tùy chọn)
                return MsgBox.Show(owner, text, caption, buttons, icon);
            }
        }
    }
}
