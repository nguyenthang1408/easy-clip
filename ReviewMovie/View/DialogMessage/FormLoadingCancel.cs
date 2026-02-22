using EasyClip.Services.Popup;
using ReviewMovie.Localization;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace EasyClip.View.DialogMessage
{
    public partial class FormLoadingCancel : Form, ILoadingDialog, ILocalizable
    {
        public event Action CancelRequested;

        // For drag support
        private bool _dragging;
        private Point _dragOffset;

        public FormLoadingCancel()
        {
            InitializeComponent();
            ApplyLanguage();
            ApplyBorderEffect();
        }

        public void ApplyLanguage()
        {
            lblStatus.Text = LanguageManager.Get(LangKeys.Loading_Cancelling);
            btnCancel.Text = LanguageManager.Get(LangKeys.Common_Cancel);
        }

        public void Show(string status)
        {
            UpdateStatus(status);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.Show();
        }

        public void UpdateStatus(string status)
        {
            if (this.InvokeRequired)
                this.Invoke(new Action(() => lblStatus.Text = status));
            else
                lblStatus.Text = status;
        }

        public void CloseDialog()
        {
            if (this.InvokeRequired)
                this.Invoke(new Action(() => this.Close()));
            else
                this.Close();
        }

        // ── Cancel button ──────────────────────────────────────────────────────
        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnCancel.Enabled = false;
            CancelRequested?.Invoke();
        }

        // ── Drag to move (borderless form) ─────────────────────────────────────
        private void pnlHeader_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _dragging = true;
                _dragOffset = new Point(e.X, e.Y);
            }
        }

        private void pnlHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point screenPos = ((Control)sender).PointToScreen(e.Location);
                this.Location = new Point(screenPos.X - _dragOffset.X, screenPos.Y - _dragOffset.Y);
            }
        }

        private void pnlHeader_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        // ── Subtle 1px border drawn over the form edge ─────────────────────────
        private void ApplyBorderEffect()
        {
            this.Paint += (s, e) =>
            {
                using (var pen = new Pen(Color.FromArgb(180, 180, 180), 1))
                    e.Graphics.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
            };
        }
    }
}
