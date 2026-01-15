using Common.Constant;
using Common.Services;
using EasyClip.Infrastructure.Config;
using Lib;
using ReviewMovie.Infrastructure.Config;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Net.Http;
using System.Windows.Forms;
using ReviewMovie.Base;

namespace ReviewMovie
{
    public partial class LoginApiKey : Form
    {
        private string AppVersion { get; } = "2.0.0"; // Định nghĩa phiên bản ứng dụng
        private readonly AppCodeService appCodeService;
        private readonly IConfigDataService _configService;

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
            UiHelpers.EnableSmoothPainting(this);
            DoubleBuffered = true;
        }

        private void DragArea_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            Win32.BeginDrag(this);
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
            if (cardPanel.Dock == DockStyle.Fill)
            {
                ApplyRoundedRegions();
                return;
            }
            int x = (ClientSize.Width - cardPanel.Width) / 2;
            int y = (ClientSize.Height - cardPanel.Height) / 2;
            cardPanel.Location = new Point(Math.Max(0, x), Math.Max(0, y));
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
            // Pure white background like screenshot #2
            e.Graphics.Clear(Color.White);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Subtle border for rounded window
            var rect = new Rectangle(0, 0, Width - 1, Height - 1);
            UiHelpers.DrawRoundedBorder(e.Graphics, rect, UiTheme.WindowRadius, UiTheme.WindowBorder);
        }

        private void ApplyRoundedRegions()
        {
            // Rounded window (requested)
            UiHelpers.ApplyRoundRegion(this, UiTheme.WindowRadius);

            // Card + logo + pills + button
            UiHelpers.ApplyRoundRegion(pnlLogo, 14);
            UiHelpers.ApplyRoundRegion(pnlAppCode, UiTheme.PillRadius);
            UiHelpers.ApplyRoundRegion(pnlApiKey, UiTheme.PillRadius);
            UiHelpers.ApplyRoundRegion(btnLoginApiKey, UiTheme.ButtonRadius);
            UiHelpers.ApplyRoundRegion(btnClose, UiTheme.CloseRadius);

            // Auto-align pill icons for any pill height
            UiHelpers.AlignIconLabelVertically(lblAppCodeIcon, pnlAppCode);
            UiHelpers.AlignIconLabelVertically(lblApiKeyIcon, pnlApiKey);
        }

        // Paint borders for card + pill panels (Designer-safe: standard Panels)
        private void cardPanel_Paint(object sender, PaintEventArgs e)
        {
            // Intentionally empty: we only round the window (1 layer)
        }

        private void pillPanel_Paint(object sender, PaintEventArgs e)
        {
            if (!(sender is Panel p)) return;
            UiHelpers.DrawPillBorder(e.Graphics, p);
        }

        private void btnLoginApiKey_MouseEnter(object sender, EventArgs e)
        {
            if (btnLoginApiKey.Enabled) btnLoginApiKey.BackColor = UiTheme.AccentHover;
        }

        private void btnLoginApiKey_MouseLeave(object sender, EventArgs e)
        {
            if (btnLoginApiKey.Enabled) btnLoginApiKey.BackColor = UiTheme.Accent;
        }

        private void btnLoginApiKey_MouseDown(object sender, MouseEventArgs e)
        {
            if (btnLoginApiKey.Enabled && e.Button == MouseButtons.Left) btnLoginApiKey.BackColor = UiTheme.AccentPressed;
        }

        private void btnLoginApiKey_MouseUp(object sender, MouseEventArgs e)
        {
            if (!btnLoginApiKey.Enabled) return;
            btnLoginApiKey.BackColor = btnLoginApiKey.ClientRectangle.Contains(e.Location) ? UiTheme.AccentHover : UiTheme.Accent;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            btnClose.BackColor = UiTheme.CloseHover;
            btnClose.ForeColor = Color.FromArgb(90, 95, 110);
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.BackColor = Color.White;
            btnClose.ForeColor = Color.FromArgb(140, 145, 165);
        }

        private void btnClose_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) btnClose.BackColor = UiTheme.ClosePressed;
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
            btnLoginApiKey.BackColor = UiTheme.Accent;
            btnClose.BackColor = Color.White;
        }
    }
}
