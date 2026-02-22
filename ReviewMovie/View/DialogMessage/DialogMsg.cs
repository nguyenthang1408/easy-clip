using ReviewMovie.Localization;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace EasyClip.View.DialogMessage
{
    public partial class DialogMsg : Form
    {
        public enum MsgType { Info, Success, Warning, Error, Confirm }

        private MsgType _type;

        public DialogMsg(string message, string caption, MsgType type, bool showYesNo)
        {
            InitializeComponent();
            _type = type;

            lblTitle.Text = caption;
            lblMessage.Text = message;

            // Localized button text
            btnOK.Text = LanguageManager.Get(LangKeys.Common_OK);
            btnYes.Text = LanguageManager.Get(LangKeys.Common_Yes);
            btnNo.Text = LanguageManager.Get(LangKeys.Common_No);

            ApplyTheme(type);

            if (showYesNo)
            {
                btnOK.Visible = false;
                btnYes.Visible = true;
                btnNo.Visible = true;
            }
            else
            {
                btnOK.Visible = true;
                btnYes.Visible = false;
                btnNo.Visible = false;
            }

            // Auto-resize height based on message length
            AdjustFormHeight();
        }

        private void ApplyTheme(MsgType type)
        {
            Color headerColor;
            string iconText;

            switch (type)
            {
                case MsgType.Success:
                    headerColor = Color.FromArgb(40, 167, 69);
                    iconText = "\u2714"; // checkmark
                    break;
                case MsgType.Warning:
                    headerColor = Color.FromArgb(255, 152, 0);
                    iconText = "\u26A0"; // warning triangle
                    break;
                case MsgType.Error:
                    headerColor = Color.FromArgb(220, 53, 69);
                    iconText = "\u2716"; // X mark
                    break;
                case MsgType.Confirm:
                    headerColor = Color.FromArgb(23, 162, 184);
                    iconText = "?";
                    break;
                default: // Info
                    headerColor = Color.FromArgb(33, 150, 243);
                    iconText = "\u2139"; // info circle
                    break;
            }

            pnlHeader.BackColor = headerColor;
            lblIcon.Text = iconText;
            lblIcon.ForeColor = Color.White;
            lblTitle.ForeColor = Color.White;

            // Accent line
            pnlAccent.BackColor = headerColor;

            // Button colors
            btnOK.BackColor = headerColor;
            btnOK.FlatAppearance.MouseOverBackColor = DarkenColor(headerColor, 20);

            btnYes.BackColor = Color.FromArgb(40, 167, 69);
            btnYes.FlatAppearance.MouseOverBackColor = DarkenColor(Color.FromArgb(40, 167, 69), 20);

            btnNo.BackColor = Color.FromArgb(108, 117, 125);
            btnNo.FlatAppearance.MouseOverBackColor = DarkenColor(Color.FromArgb(108, 117, 125), 20);
        }

        private void AdjustFormHeight()
        {
            using (Graphics g = lblMessage.CreateGraphics())
            {
                SizeF size = g.MeasureString(lblMessage.Text, lblMessage.Font, lblMessage.Width);
                int textHeight = (int)Math.Ceiling(size.Height);
                int minBodyHeight = 60;
                int bodyHeight = Math.Max(textHeight + 30, minBodyHeight);
                int totalHeight = pnlHeader.Height + bodyHeight + pnlFooter.Height + pnlAccent.Height + 10;
                totalHeight = Math.Max(totalHeight, 200);
                totalHeight = Math.Min(totalHeight, 500);
                this.ClientSize = new Size(this.ClientSize.Width, totalHeight);
            }
        }

        private static Color DarkenColor(Color color, int amount)
        {
            return Color.FromArgb(
                color.A,
                Math.Max(0, color.R - amount),
                Math.Max(0, color.G - amount),
                Math.Max(0, color.B - amount));
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        // Enable form dragging from header
        private bool _dragging;
        private Point _dragCursorPoint;
        private Point _dragFormPoint;

        private void pnlHeader_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;
            _dragCursorPoint = Cursor.Position;
            _dragFormPoint = this.Location;
        }

        private void pnlHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point diff = Point.Subtract(Cursor.Position, new Size(_dragCursorPoint));
                this.Location = Point.Add(_dragFormPoint, new Size(diff));
            }
        }

        private void pnlHeader_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            // Draw border
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
