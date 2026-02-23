using ReviewMovie.Localization;
using System.Drawing;
using System.Windows.Forms;

namespace EasyClip.View.DialogMessage
{
    public partial class FormExportMode : Form
    {
        public enum ExportMode { OriginalTime, VideoTime, Cancel }

        private ExportMode _result = ExportMode.Cancel;

        private FormExportMode()
        {
            InitializeComponent();

            // Set localized text
            lblTitle.Text = LanguageManager.Get(LangKeys.Main_ExportSubtitleModeTitle);
            lblMessage.Text = LanguageManager.Get(LangKeys.Main_ExportSubtitleModeMsg);
            btnOriginal.Text = LanguageManager.Get(LangKeys.Main_ExportSubtitleBtnOriginal);
            btnVideoTime.Text = LanguageManager.Get(LangKeys.Main_ExportSubtitleBtnVideoTime);
            btnCancel.Text = LanguageManager.Get(LangKeys.Common_Cancel);
        }

        public static ExportMode Show(IWin32Window owner)
        {
            using (var form = new FormExportMode())
            {
                form.ShowDialog(owner);
                return form._result;
            }
        }

        private void btnOriginal_Click(object sender, System.EventArgs e)
        {
            _result = ExportMode.OriginalTime;
            this.Close();
        }

        private void btnVideoTime_Click(object sender, System.EventArgs e)
        {
            _result = ExportMode.VideoTime;
            this.Close();
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            _result = ExportMode.Cancel;
            this.Close();
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            _result = ExportMode.Cancel;
            this.Close();
        }

        private void FormExportMode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                _result = ExportMode.Cancel;
                this.Close();
            }
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
