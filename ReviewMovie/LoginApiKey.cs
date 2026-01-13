using Common.Constant;
using Common.Services;
using EasyClip.Infrastructure.Config;
using Lib;
using ReviewMovie.Infrastructure.Config;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.InteropServices;
using System.Net.Http;
using System.Windows.Forms;

namespace ReviewMovie
{
    public partial class LoginApiKey : Form
    {
        private static readonly Color ColorAccent = Color.FromArgb(120, 94, 255);
        private static readonly Color ColorAccentHover = Color.FromArgb(110, 86, 245);
        private static readonly Color ColorAccentPressed = Color.FromArgb(98, 76, 232);
        private static readonly Color ColorBorder = Color.FromArgb(235, 238, 255);
        private static readonly Color ColorPillBorder = Color.FromArgb(232, 236, 255);
        private static readonly Color ColorCloseHover = Color.FromArgb(246, 247, 252);
        private static readonly Color ColorClosePressed = Color.FromArgb(235, 236, 245);
        private static readonly Color ColorDarkBtn = Color.FromArgb(15, 22, 35);
        private static readonly Color ColorDarkBtnHover = Color.FromArgb(22, 31, 48);
        private static readonly Color ColorDarkBtnPressed = Color.FromArgb(10, 15, 26);

        private string AppVersion { get; } = "2.0.0"; // Định nghĩa phiên bản ứng dụng
        private readonly AppCodeService appCodeService;
        private readonly IConfigDataService _configService;
        private bool _apiKeyVisible;

        public LoginApiKey()
        {
            InitializeComponent();
            appCodeService = new AppCodeService(); // Khởi tạo service
            _configService = new ConfigDataService();

            DisplayAppCode();
            LoadApiKey();

            // Đặt sự kiện cho việc đóng form
            this.FormClosing += LoginApiKey_FormClosing;

            // Smooth painting (gradient + shadow)
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            DoubleBuffered = true;
        }

        // --------- Borderless drag support ----------
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;

        private void DragArea_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            try
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
            catch
            {
                // Ignore - best effort for dragging on some environments
            }
        }

        private void LoginApiKey_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void CenterCard()
        {
            if (cardPanel == null) return;
            // New layout: center header + card
            if (pnlHeader != null)
            {
                int gap = 12;
                int totalHeight = pnlHeader.Height + gap + cardPanel.Height + 34;
                int startY = Math.Max(16, (ClientSize.Height - totalHeight) / 2);

                pnlHeader.Left = (ClientSize.Width - pnlHeader.Width) / 2;
                pnlHeader.Top = startY;

                cardPanel.Left = (ClientSize.Width - cardPanel.Width) / 2;
                cardPanel.Top = pnlHeader.Bottom + gap;

                if (lblVersion != null)
                {
                    lblVersion.Width = ClientSize.Width;
                    lblVersion.Left = 0;
                    lblVersion.Top = Math.Min(ClientSize.Height - 26, cardPanel.Bottom + 18);
                }
            }
            else
            {
                int x = (ClientSize.Width - cardPanel.Width) / 2;
                int y = (ClientSize.Height - cardPanel.Height) / 2;
                cardPanel.Location = new Point(Math.Max(0, x), Math.Max(0, y));
            }

            if (btnClose != null)
            {
                btnClose.Left = ClientSize.Width - btnClose.Width - 12;
                btnClose.Top = 12;
            }

            ApplyRoundedRegions();
            Invalidate();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            CenterCard();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // Gradient background like screenshot (purple/grey)
            using (var brush = new LinearGradientBrush(
                ClientRectangle,
                Color.FromArgb(246, 246, 250),
                Color.FromArgb(226, 211, 255),
                LinearGradientMode.Horizontal))
            {
                e.Graphics.FillRectangle(brush, ClientRectangle);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Soft shadow behind the white card
            if (cardPanel != null)
            {
                var shadowRect = new Rectangle(
                    cardPanel.Left - 6,
                    cardPanel.Top - 4,
                    cardPanel.Width + 12,
                    cardPanel.Height + 14);

                DrawShadow(e.Graphics, shadowRect, 24, 16);
            }
        }

        private static void DrawShadow(Graphics g, Rectangle rect, int radius, int depth)
        {
            // Draw multiple blurred strokes with decreasing alpha
            for (int i = depth; i >= 1; i--)
            {
                int alpha = (int)(18f * (i / (float)depth)); // outer lighter
                using (var pen = new Pen(Color.FromArgb(alpha, 0, 0, 0), 1f))
                using (var path = CreateRoundedRectPath(
                    Rectangle.Inflate(rect, i, i),
                    radius + i))
                {
                    g.DrawPath(pen, path);
                }
            }
        }

        private static GraphicsPath CreateRoundedRectPath(Rectangle rect, int radius)
        {
            var path = new GraphicsPath();
            if (radius <= 0)
            {
                path.AddRectangle(rect);
                path.CloseFigure();
                return path;
            }

            int d = radius * 2;
            var arc = new Rectangle(rect.X, rect.Y, d, d);

            path.AddArc(arc, 180, 90);
            arc.X = rect.Right - d;
            path.AddArc(arc, 270, 90);
            arc.Y = rect.Bottom - d;
            path.AddArc(arc, 0, 90);
            arc.X = rect.X;
            path.AddArc(arc, 90, 90);
            path.CloseFigure();
            return path;
        }

        private static void ApplyRoundRegion(Control control, int radius)
        {
            if (control == null || control.Width <= 0 || control.Height <= 0) return;
            using (var path = CreateRoundedRectPath(new Rectangle(0, 0, control.Width, control.Height), radius))
            {
                control.Region = new Region(path);
            }
        }

        private void ApplyRoundedRegions()
        {
            // Rounded window (requested)
            ApplyRoundRegion(this, 26);

            // Card + logo + pills + button
            ApplyRoundRegion(cardPanel, 22);
            ApplyRoundRegion(pnlLogo, 14);
            ApplyRoundRegion(pnlAppCode, 16);
            ApplyRoundRegion(pnlApiKey, 16);
            ApplyRoundRegion(btnLoginApiKey, 14);
            ApplyRoundRegion(btnClose, 15);
            ApplyRoundRegion(pnlHandle, 3);
        }

        // Paint borders for card + pill panels (Designer-safe: standard Panels)
        private void cardPanel_Paint(object sender, PaintEventArgs e)
        {
            var rect = new Rectangle(0, 0, cardPanel.Width - 1, cardPanel.Height - 1);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (var path = CreateRoundedRectPath(rect, 22))
            using (var pen = new Pen(Color.FromArgb(235, 238, 245), 1f))
            {
                e.Graphics.DrawPath(pen, path);
            }
        }

        private void pillPanel_Paint(object sender, PaintEventArgs e)
        {
            if (!(sender is Panel p)) return;
            var rect = new Rectangle(0, 0, p.Width - 1, p.Height - 1);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (var path = CreateRoundedRectPath(rect, 16))
            using (var pen = new Pen(Color.FromArgb(230, 232, 240), 1f))
            {
                e.Graphics.DrawPath(pen, path);
            }
        }

        private void btnLoginApiKey_MouseEnter(object sender, EventArgs e)
        {
            if (btnLoginApiKey.Enabled) btnLoginApiKey.BackColor = ColorDarkBtnHover;
        }

        private void btnLoginApiKey_MouseLeave(object sender, EventArgs e)
        {
            if (btnLoginApiKey.Enabled) btnLoginApiKey.BackColor = ColorDarkBtn;
        }

        private void btnLoginApiKey_MouseDown(object sender, MouseEventArgs e)
        {
            if (btnLoginApiKey.Enabled && e.Button == MouseButtons.Left) btnLoginApiKey.BackColor = ColorDarkBtnPressed;
        }

        private void btnLoginApiKey_MouseUp(object sender, MouseEventArgs e)
        {
            if (!btnLoginApiKey.Enabled) return;
            btnLoginApiKey.BackColor = btnLoginApiKey.ClientRectangle.Contains(e.Location) ? ColorDarkBtnHover : ColorDarkBtn;
        }

        private void btnToggleApiKey_Click(object sender, EventArgs e)
        {
            _apiKeyVisible = !_apiKeyVisible;
            txInsertApiKey.UseSystemPasswordChar = !_apiKeyVisible;
            btnToggleApiKey.Text = _apiKeyVisible ? "" : ""; // eye open / eye
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            btnClose.BackColor = ColorCloseHover;
            btnClose.ForeColor = Color.FromArgb(90, 95, 110);
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.BackColor = Color.White;
            btnClose.ForeColor = Color.FromArgb(140, 145, 165);
        }

        private void btnClose_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) btnClose.BackColor = ColorClosePressed;
        }

        private void btnClose_MouseUp(object sender, MouseEventArgs e)
        {
            btnClose.BackColor = btnClose.ClientRectangle.Contains(e.Location) ? ColorCloseHover : Color.White;
        }

        private void DisplayAppCode()
        {
            // Sử dụng AppCodeService để lấy appCode
            string appCode = appCodeService.GetAppCode();
            txAppCodeShow.Text = appCode;
        }

        private void LoadApiKey()
        {
            var progCOnf = _configService.GetItem(1);

            if (!progCOnf.IsEmpty)
            {
                try
                {
                    string savedApiKey = progCOnf.T2PSoftKey;
                    txInsertApiKey.Text = savedApiKey;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể lấy được T2PKey: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnLoginApiKey_Click(object sender, EventArgs e)
        {
            // Disable nút để tránh click nhiều lần
            btnLoginApiKey.Enabled = false;

            lbstatus.Text = string.Empty;
            lbstatus.ForeColor = Color.Black;
            // Kiểm tra API Key
            string apiKey = txInsertApiKey.Text.Trim();
            if (string.IsNullOrEmpty(apiKey))
            {
                MessageBox.Show("Vui lòng nhập API Key!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnLoginApiKey.Enabled = true; // Bật lại nút nếu lỗi
                return;
            }

            try
            {
                var request = new ApiClientRequest(LibConst.UrlServer, apiKey);
                var response = await request.ReviewMovieVersionAsync();
                if (response.IsSuccess)
                {
                    string currentVersion = AppVersion;
                    string latestVersion = response.Version;
                    var checkver = new CheckVersionServices();
                    if (checkver.IsNewerVersion(latestVersion, currentVersion))
                    {
                        DialogResult result = MessageBox.Show(
                           $"Bạn đang sử dụng phiên bản {currentVersion}. Phiên bản mới nhất là {latestVersion}. Bạn có muốn cập nhật không?",
                           "Cập nhật phiên bản",
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Warning,
                           MessageBoxDefaultButton.Button1);

                        if (result == DialogResult.Yes)
                        {
                            // Mở trang web để người dùng tải phiên bản mới nhất
                            System.Diagnostics.Process.Start("https://www.facebook.com/La.studio.top");
                            Application.Exit(); // Tắt ứng dụng nếu người dùng chọn Yes
                        }
                        // Nếu người dùng chọn No thì tiếp tục cho phép đăng nhập
                    }
                    // Đăng nhập thành công
                    MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Mở form chính và đóng form đăng nhập
                    this.Hide();
                    FormMain mainForm = new FormMain(txAppCodeShow.Text, txInsertApiKey.Text);

                    mainForm.ShowDialog();
                    // Sau khi đóng form chính, thoát ứng dụng
                    Application.Exit();
                }
                else
                {
                    lbstatus.Text = "API Key không hợp lệ, API cần được Kích Hoạt!";
                    lbstatus.ForeColor = Color.Red;
                    //MessageBox.Show("API Key không hợp lệ, API cần được Kích Hoạt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                lbstatus.Text = "Không Kết nối Được, API cần được Kích Hoạt!";
                lbstatus.ForeColor = Color.Red;
                //MessageBox.Show("Không Kết nối Được, API cần được Kích Hoạt!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Bật lại nút dù có lỗi hay không
                btnLoginApiKey.Enabled = true;
            }
        }
        private void lkHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/La.studio.top");
        }

        private void LoginApiKey_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void linklbRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://t2psoft.com/Home/Register");
        }

        private void LoginApiKey_Load(object sender, EventArgs e)
        {
            CenterCard();
            // Ensure initial styles
            btnLoginApiKey.BackColor = ColorDarkBtn;
            btnClose.BackColor = Color.White;

            // Mask api key by default like mock
            _apiKeyVisible = false;
            txInsertApiKey.UseSystemPasswordChar = true;
            if (btnToggleApiKey != null) btnToggleApiKey.Text = "";
        }
    }
}
