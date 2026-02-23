using ReviewMovie.Localization;
using System.Drawing;
using System.Windows.Forms;

namespace EasyClip.View.DialogMessage
{
    public class FormExportMode : Form
    {
        public enum ExportMode { OriginalTime, VideoTime, Cancel }

        private ExportMode _result = ExportMode.Cancel;

        private FormExportMode()
        {
            BuildUI();
        }

        public static ExportMode Show(IWin32Window owner)
        {
            using (var form = new FormExportMode())
            {
                form.ShowDialog(owner);
                return form._result;
            }
        }

        private void BuildUI()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterParent;
            this.ShowInTaskbar = false;
            this.BackColor = Color.White;
            this.Font = new Font("Segoe UI", 9F);
            this.ClientSize = new Size(420, 205);
            this.KeyPreview = true;
            this.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Escape)
                {
                    _result = ExportMode.Cancel;
                    this.Close();
                }
            };

            var headerColor = Color.FromArgb(33, 150, 243);

            // === Header ===
            var pnlHeader = new Panel
            {
                BackColor = headerColor,
                Dock = DockStyle.Top,
                Size = new Size(420, 55)
            };

            var lblIcon = new Label
            {
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(12, 5),
                Size = new Size(45, 45),
                Text = "\u2193",
                TextAlign = ContentAlignment.MiddleCenter
            };

            var lblTitle = new Label
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(58, 5),
                Size = new Size(320, 45),
                Text = LanguageManager.Get(LangKeys.Main_ExportSubtitleModeTitle),
                TextAlign = ContentAlignment.MiddleLeft
            };

            var btnClose = new Label
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Cursor = Cursors.Hand,
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(385, 5),
                Size = new Size(30, 30),
                Text = "\u00D7",
                TextAlign = ContentAlignment.MiddleCenter
            };
            btnClose.Click += (s, e) => { _result = ExportMode.Cancel; this.Close(); };

            pnlHeader.Controls.AddRange(new Control[] { lblIcon, lblTitle, btnClose });

            // Drag support
            bool dragging = false;
            Point dragCursorPoint = Point.Empty;
            Point dragFormPoint = Point.Empty;

            MouseEventHandler mouseDown = (s, e) =>
            {
                dragging = true;
                dragCursorPoint = Cursor.Position;
                dragFormPoint = this.Location;
            };
            MouseEventHandler mouseMove = (s, e) =>
            {
                if (dragging)
                {
                    Point diff = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                    this.Location = Point.Add(dragFormPoint, new Size(diff));
                }
            };
            MouseEventHandler mouseUp = (s, e) => { dragging = false; };

            pnlHeader.MouseDown += mouseDown;
            pnlHeader.MouseMove += mouseMove;
            pnlHeader.MouseUp += mouseUp;
            lblIcon.MouseDown += mouseDown;
            lblIcon.MouseMove += mouseMove;
            lblIcon.MouseUp += mouseUp;
            lblTitle.MouseDown += mouseDown;
            lblTitle.MouseMove += mouseMove;
            lblTitle.MouseUp += mouseUp;

            // === Accent Line ===
            var pnlAccent = new Panel
            {
                BackColor = headerColor,
                Dock = DockStyle.Top,
                Size = new Size(420, 3)
            };

            // === Body ===
            var pnlBody = new Panel
            {
                BackColor = Color.White,
                Dock = DockStyle.Fill,
                Padding = new Padding(20, 15, 20, 10)
            };

            var lblMessage = new Label
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(50, 50, 50),
                Text = LanguageManager.Get(LangKeys.Main_ExportSubtitleModeMsg),
                TextAlign = ContentAlignment.MiddleLeft
            };
            pnlBody.Controls.Add(lblMessage);

            // === Footer ===
            var pnlFooter = new Panel
            {
                BackColor = Color.FromArgb(245, 245, 245),
                Dock = DockStyle.Bottom,
                Size = new Size(420, 55)
            };

            // 3 buttons evenly spaced: x=25, 150, 275 | width=110
            var btnOriginal = new Button
            {
                BackColor = Color.FromArgb(40, 167, 69),
                Cursor = Cursors.Hand,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(25, 10),
                Size = new Size(110, 35),
                Text = LanguageManager.Get(LangKeys.Main_ExportSubtitleBtnOriginal),
                UseVisualStyleBackColor = false
            };
            btnOriginal.FlatAppearance.BorderSize = 0;
            btnOriginal.Click += (s, e) => { _result = ExportMode.OriginalTime; this.Close(); };

            var btnVideoTime = new Button
            {
                BackColor = Color.FromArgb(33, 150, 243),
                Cursor = Cursors.Hand,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(150, 10),
                Size = new Size(110, 35),
                Text = LanguageManager.Get(LangKeys.Main_ExportSubtitleBtnVideoTime),
                UseVisualStyleBackColor = false
            };
            btnVideoTime.FlatAppearance.BorderSize = 0;
            btnVideoTime.Click += (s, e) => { _result = ExportMode.VideoTime; this.Close(); };

            var btnCancel = new Button
            {
                BackColor = Color.FromArgb(108, 117, 125),
                Cursor = Cursors.Hand,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(275, 10),
                Size = new Size(110, 35),
                Text = LanguageManager.Get(LangKeys.Common_Cancel),
                UseVisualStyleBackColor = false
            };
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Click += (s, e) => { _result = ExportMode.Cancel; this.Close(); };

            pnlFooter.Controls.AddRange(new Control[] { btnOriginal, btnVideoTime, btnCancel });

            // Add panels — order matters for docking
            this.Controls.Add(pnlBody);
            this.Controls.Add(pnlFooter);
            this.Controls.Add(pnlAccent);
            this.Controls.Add(pnlHeader);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Pen pen = new Pen(Color.FromArgb(200, 200, 200), 1))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= 0x20000; // CS_DROPSHADOW
                return cp;
            }
        }
    }
}
