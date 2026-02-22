using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ReviewMovie.Base
{
    internal static class UiMessageBox
    {
        private sealed class ButtonSpec
        {
            public string Text { get; set; }
            public DialogResult Result { get; set; }
        }

        public static DialogResult Show(
            string text,
            string caption = "",
            MessageBoxButtons buttons = MessageBoxButtons.OK,
            MessageBoxIcon icon = MessageBoxIcon.None,
            MessageBoxDefaultButton defaultButton = MessageBoxDefaultButton.Button1)
        {
            return Show(null, text, caption, buttons, icon, defaultButton);
        }

        public static DialogResult Show(
            IWin32Window owner,
            string text,
            string caption = "",
            MessageBoxButtons buttons = MessageBoxButtons.OK,
            MessageBoxIcon icon = MessageBoxIcon.None,
            MessageBoxDefaultButton defaultButton = MessageBoxDefaultButton.Button1)
        {
            using (var popup = new Form())
            {
                popup.FormBorderStyle = FormBorderStyle.None;
                popup.StartPosition = owner == null ? FormStartPosition.CenterScreen : FormStartPosition.CenterParent;
                popup.ShowInTaskbar = false;
                popup.TopMost = true;
                popup.BackColor = Color.FromArgb(238, 243, 251);
                popup.ClientSize = new Size(420, 190);
                popup.Padding = new Padding(8);
                popup.Text = string.IsNullOrWhiteSpace(caption) ? "Thông báo" : caption;
                UiHelpers.EnableSmoothPainting(popup);

                var panelCard = new Panel
                {
                    Dock = DockStyle.Fill,
                    BackColor = Color.White
                };
                popup.Controls.Add(panelCard);

                var panelHeader = new Panel
                {
                    Dock = DockStyle.Top,
                    Height = 40,
                    BackColor = Color.FromArgb(246, 249, 255)
                };
                panelCard.Controls.Add(panelHeader);

                var lblTitle = new Label
                {
                    AutoSize = true,
                    Text = string.IsNullOrWhiteSpace(caption) ? "Thông báo" : caption,
                    Font = new Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point),
                    ForeColor = Color.FromArgb(38, 48, 63),
                    Location = new Point(12, 9)
                };
                panelHeader.Controls.Add(lblTitle);

                var btnClose = new Button
                {
                    Text = "x",
                    Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point),
                    ForeColor = Color.FromArgb(120, 128, 142),
                    FlatStyle = FlatStyle.Flat,
                    Size = new Size(32, 26),
                    Location = new Point(popup.ClientSize.Width - 50, 7),
                    Anchor = AnchorStyles.Top | AnchorStyles.Right,
                    Cursor = Cursors.Hand,
                    TabStop = false
                };
                btnClose.FlatAppearance.BorderSize = 0;
                btnClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(235, 241, 251);
                btnClose.FlatAppearance.MouseDownBackColor = Color.FromArgb(224, 233, 246);
                panelHeader.Controls.Add(btnClose);

                var bodyLayout = new TableLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    ColumnCount = 1,
                    RowCount = 2,
                    Padding = new Padding(14, 10, 14, 10),
                    BackColor = Color.White
                };
                bodyLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
                bodyLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
                panelCard.Controls.Add(bodyLayout);

                var contentLayout = new TableLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    ColumnCount = 2,
                    RowCount = 1,
                    BackColor = Color.White
                };
                contentLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 44F));
                contentLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
                bodyLayout.Controls.Add(contentLayout, 0, 0);

                var iconCircle = new RoundedPanel
                {
                    Size = new Size(30, 30),
                    Anchor = AnchorStyles.Top | AnchorStyles.Left,
                    FillColor = ResolveIconBackColor(icon),
                    BorderThickness = 0,
                    CornerRadius = 15,
                    Margin = new Padding(0, 8, 10, 0)
                };
                contentLayout.Controls.Add(iconCircle, 0, 0);

                var lblIcon = new Label
                {
                    Dock = DockStyle.Fill,
                    Text = ResolveIconGlyph(icon),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point),
                    ForeColor = Color.White,
                    BackColor = Color.Transparent
                };
                iconCircle.Controls.Add(lblIcon);

                var lblMessage = new Label
                {
                    Dock = DockStyle.Fill,
                    AutoSize = false,
                    Text = text ?? string.Empty,
                    Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point),
                    ForeColor = Color.FromArgb(35, 45, 59),
                    TextAlign = ContentAlignment.MiddleLeft
                };
                contentLayout.Controls.Add(lblMessage, 1, 0);

                var buttonFlow = new FlowLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    FlowDirection = FlowDirection.RightToLeft,
                    WrapContents = false,
                    BackColor = Color.White,
                    Padding = new Padding(0, 5, 0, 0)
                };
                bodyLayout.Controls.Add(buttonFlow, 0, 1);

                var specs = BuildButtonSpecs(buttons);
                int defaultIndex = ResolveDefaultIndex(defaultButton, specs.Count);
                Button defaultButtonControl = null;
                Button cancelButtonControl = null;

                for (int i = specs.Count - 1; i >= 0; i--)
                {
                    var spec = specs[i];
                    bool isPrimary = (i == defaultIndex);

                    var btn = new Button
                    {
                        Text = spec.Text,
                        DialogResult = spec.Result,
                        Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point),
                        ForeColor = isPrimary ? Color.White : Color.FromArgb(46, 58, 74),
                        BackColor = isPrimary ? Color.FromArgb(44, 124, 235) : Color.FromArgb(241, 244, 249),
                        FlatStyle = FlatStyle.Flat,
                        Size = new Size(98, 30),
                        Margin = new Padding(8, 0, 0, 0),
                        Cursor = Cursors.Hand
                    };

                    btn.FlatAppearance.BorderSize = 1;
                    btn.FlatAppearance.BorderColor = isPrimary
                        ? Color.FromArgb(37, 111, 216)
                        : Color.FromArgb(214, 221, 232);
                    btn.FlatAppearance.MouseOverBackColor = isPrimary
                        ? Color.FromArgb(37, 111, 216)
                        : Color.FromArgb(231, 237, 246);
                    btn.FlatAppearance.MouseDownBackColor = isPrimary
                        ? Color.FromArgb(32, 99, 197)
                        : Color.FromArgb(220, 229, 242);

                    buttonFlow.Controls.Add(btn);

                    if (i == defaultIndex) defaultButtonControl = btn;
                    if (spec.Result == DialogResult.Cancel || spec.Result == DialogResult.No) cancelButtonControl = btn;
                }

                popup.AcceptButton = defaultButtonControl;
                popup.CancelButton = cancelButtonControl ?? defaultButtonControl;

                var closeResult = ResolveCloseResult(specs);
                btnClose.Click += (_, __) =>
                {
                    popup.DialogResult = closeResult;
                    popup.Close();
                };

                popup.Shown += (s, e) =>
                {
                    UiHelpers.ApplyRoundRegion(panelCard, 10);
                    UiHelpers.ApplyRoundRegion(iconCircle, iconCircle.Width / 2);
                    foreach (Control ctl in buttonFlow.Controls)
                    {
                        UiHelpers.ApplyRoundRegion(ctl, 1);
                    }
                };
                popup.Resize += (s, e) =>
                {
                    if (panelCard.Width > 0 && panelCard.Height > 0)
                    {
                        UiHelpers.ApplyRoundRegion(panelCard, 10);
                    }
                };

                if (owner is Control ownerControl)
                {
                    if (ownerControl.IsDisposed || !ownerControl.IsHandleCreated)
                    {
                        return popup.ShowDialog();
                    }
                }

                return owner == null ? popup.ShowDialog() : popup.ShowDialog(owner);
            }
        }

        private static List<ButtonSpec> BuildButtonSpecs(MessageBoxButtons buttons)
        {
            switch (buttons)
            {
                case MessageBoxButtons.OKCancel:
                    return new List<ButtonSpec>
                    {
                        new ButtonSpec { Text = "OK", Result = DialogResult.OK },
                        new ButtonSpec { Text = "Cancel", Result = DialogResult.Cancel }
                    };
                case MessageBoxButtons.YesNo:
                    return new List<ButtonSpec>
                    {
                        new ButtonSpec { Text = "Yes", Result = DialogResult.Yes },
                        new ButtonSpec { Text = "No", Result = DialogResult.No }
                    };
                case MessageBoxButtons.YesNoCancel:
                    return new List<ButtonSpec>
                    {
                        new ButtonSpec { Text = "Yes", Result = DialogResult.Yes },
                        new ButtonSpec { Text = "No", Result = DialogResult.No },
                        new ButtonSpec { Text = "Cancel", Result = DialogResult.Cancel }
                    };
                case MessageBoxButtons.RetryCancel:
                    return new List<ButtonSpec>
                    {
                        new ButtonSpec { Text = "Retry", Result = DialogResult.Retry },
                        new ButtonSpec { Text = "Cancel", Result = DialogResult.Cancel }
                    };
                case MessageBoxButtons.AbortRetryIgnore:
                    return new List<ButtonSpec>
                    {
                        new ButtonSpec { Text = "Abort", Result = DialogResult.Abort },
                        new ButtonSpec { Text = "Retry", Result = DialogResult.Retry },
                        new ButtonSpec { Text = "Ignore", Result = DialogResult.Ignore }
                    };
                default:
                    return new List<ButtonSpec>
                    {
                        new ButtonSpec { Text = "OK", Result = DialogResult.OK }
                    };
            }
        }

        private static int ResolveDefaultIndex(MessageBoxDefaultButton defaultButton, int buttonCount)
        {
            int idx;
            switch (defaultButton)
            {
                case MessageBoxDefaultButton.Button2:
                    idx = 1;
                    break;
                case MessageBoxDefaultButton.Button3:
                    idx = 2;
                    break;
                default:
                    idx = 0;
                    break;
            }

            if (buttonCount <= 0) return 0;
            if (idx >= buttonCount) return 0;
            return idx;
        }

        private static DialogResult ResolveCloseResult(List<ButtonSpec> specs)
        {
            foreach (var spec in specs)
            {
                if (spec.Result == DialogResult.Cancel) return DialogResult.Cancel;
            }
            foreach (var spec in specs)
            {
                if (spec.Result == DialogResult.No) return DialogResult.No;
            }
            return specs.Count > 0 ? specs[0].Result : DialogResult.OK;
        }

        private static Color ResolveIconBackColor(MessageBoxIcon icon)
        {
            switch (icon)
            {
                case MessageBoxIcon.Error:
                case MessageBoxIcon.Hand:
                case MessageBoxIcon.Stop:
                    return Color.FromArgb(224, 74, 93);
                case MessageBoxIcon.Warning:
                case MessageBoxIcon.Exclamation:
                    return Color.FromArgb(240, 165, 55);
                case MessageBoxIcon.Question:
                    return Color.FromArgb(43, 123, 234);
                case MessageBoxIcon.Information:
                case MessageBoxIcon.Asterisk:
                    return Color.FromArgb(62, 136, 245);
                default:
                    return Color.FromArgb(43, 123, 234);
            }
        }

        private static string ResolveIconGlyph(MessageBoxIcon icon)
        {
            switch (icon)
            {
                case MessageBoxIcon.Error:
                case MessageBoxIcon.Hand:
                case MessageBoxIcon.Stop:
                    return "!";
                case MessageBoxIcon.Warning:
                case MessageBoxIcon.Exclamation:
                    return "!";
                case MessageBoxIcon.Question:
                    return "?";
                case MessageBoxIcon.Information:
                case MessageBoxIcon.Asterisk:
                    return "i";
                default:
                    return "i";
            }
        }
    }
}
