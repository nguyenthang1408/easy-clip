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
using System.ComponentModel;
using System.Windows.Forms;
using ReviewMovie.Base;
using ReviewMovie.Base.Controls;

namespace ReviewMovie
{
    public partial class LoginApiKey : Form
    {
        private string AppVersion { get; } = "2.0.0"; // Định nghĩa phiên bản ứng dụng
        private readonly AppCodeService appCodeService;
        private readonly IConfigDataService _configService;
        private bool _readOnlyFocusWired;

        public LoginApiKey()
        {
            InitializeComponent();

            // Designer safety: avoid running runtime services / IO in WinForms designer.
            bool isDesignTime = LicenseManager.UsageMode == LicenseUsageMode.Designtime;

            // Assign readonly fields on all paths (designer/runtime)
            appCodeService = isDesignTime ? null : new AppCodeService(); // Khởi tạo service
            _configService = isDesignTime ? null : new ConfigDataService();

            if (isDesignTime)
            {
                SetupLoginUi();
                return;
            }

            DisplayAppCode();
            LoadApiKey();

            // Đặt sự kiện cho việc đóng form
            this.FormClosing += LoginApiKey_FormClosing;

            // Smooth painting (gradient + shadow)
            UiHelpers.EnableSmoothPainting(this);
            DoubleBuffered = true;

            // Allow dragging the borderless window from background
            this.MouseDown += DragArea_MouseDown;

            SetupLoginUi();
        }

        private void SetupLoginUi()
        {
            // Commonized UI setup (easy to maintain)
            if (txAppCodeShow is PillTextBox appCode)
            {
                appCode.IconGlyph = "";
                appCode.ReadOnly = true;
                // Make it visually obvious it's read-only
                appCode.FillColor = ColorTranslator.FromHtml("#F1F5F9");
                appCode.BorderColor = ColorTranslator.FromHtml("#E2E8F0");
                appCode.IconColor = ColorTranslator.FromHtml("#94A3B8");
                appCode.InnerTextBox.ForeColor = ColorTranslator.FromHtml("#64748B");
                appCode.InnerTextBox.Cursor = Cursors.Default;

                // Prevent focusing/tabbing into AppCode field
                appCode.TabStop = false;
                appCode.InnerTextBox.TabStop = false;
                if (!_readOnlyFocusWired)
                {
                    _readOnlyFocusWired = true;
                    appCode.InnerTextBox.GotFocus += (_, __) =>
                    {
                        try { txInsertApiKey?.Focus(); } catch { }
                    };
                }
            }

            if (txInsertApiKey is PillTextBox apiKey)
            {
                apiKey.IconGlyph = "";
                apiKey.FillColor = Color.White;
                apiKey.BorderColor = ColorTranslator.FromHtml("#E2E8F0");
            }

            if (btnLoginApiKey is PrimaryButton primary)
            {
                // Facebook-style primary CTA
                primary.FillColor = ColorTranslator.FromHtml("#1877F2");
                primary.HoverFillColor = ColorTranslator.FromHtml("#166FE5");
                primary.PressedFillColor = ColorTranslator.FromHtml("#145DBF");
                primary.CornerRadius = UiTheme.ButtonRadius;
                primary.ForeColor = Color.White;
            }

            if (btnClose is IconCircleButton close)
            {
                close.CornerRadius = UiTheme.CloseRadius;
                close.NormalBackColor = Color.White;
                close.HoverBackColor = UiTheme.CloseHover;
                close.PressedBackColor = UiTheme.ClosePressed;
            }
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
            // Very light orange background (as requested)
            e.Graphics.Clear(ColorTranslator.FromHtml("#FFF7ED"));
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

            // Card + logo (pills/buttons handle their own rounding)
            UiHelpers.ApplyRoundRegion(pnlLogo, 14);
        }

        // Paint borders for card + pill panels (Designer-safe: standard Panels)
        private void cardPanel_Paint(object sender, PaintEventArgs e)
        {
            // Intentionally empty: we only round the window (1 layer)
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
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
            SetupLoginUi();
        }
    }
}
