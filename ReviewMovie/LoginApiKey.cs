using Common.Constant;
using Common.Services;
using EasyClip.Infrastructure.Config;
using EasyClip.View.DialogMessage;
using Lib;
using LibCommon.Lib;
using ReviewMovie.Base;
using ReviewMovie.Base.Controls;
using ReviewMovie.Infrastructure.Config;
using ReviewMovie.Localization;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Net.Http;
using System.Reflection.Emit;
using System.Windows.Forms;
using MessageBox = ReviewMovie.Base.UiMessageBox;

namespace ReviewMovie
{
    public partial class LoginApiKey : Form
    {
        private string AppVersion { get; } = "2.0.0"; // Định nghĩa phiên bản ứng dụng
        private readonly AppCodeService appCodeService;
        private readonly IConfigDataService _configService;
        private bool _appCodeActionsWired;
        private bool _brandLogoApplied;
        private const string AppCodeCopiedVi = "Đã sao chép App Code.";
        private const string AppCodeCopiedEn = "App code copied.";
        private const string AppCodeCopyFailedVi = "Không thể sao chép App Code.";
        private const string AppCodeCopyFailedEn = "Cannot copy app code.";

        public LoginApiKey()
        {
            InitializeComponent();

            // Designer safety: avoid running runtime services / IO in WinForms designer.
            bool isDesignTime = LicenseManager.UsageMode == LicenseUsageMode.Designtime;

            // Assign readonly fields on all paths (designer/runtime)
            appCodeService = isDesignTime ? null : new AppCodeService(); // Khởi tạo service
            _configService = isDesignTime ? null : new ConfigDataService();

            // Load saved language and set ComboBox
            LanguageManager.LoadSavedLanguage();
            cbAppLanguage.SelectedIndex = LanguageManager.CurrentLanguage == LanguageManager.Language.En ? 1 : 0;

            // Subscribe to language change
            LanguageManager.LanguageChanged += ApplyLanguage;
            ApplyLanguage();

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

        private void cbAppLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbAppLanguage.SelectedIndex == 1)
                LanguageManager.SetLanguage(LanguageManager.Language.En);
            else
                LanguageManager.SetLanguage(LanguageManager.Language.Vi);

            // Ensure copy status text follows current combo selection immediately.
            TranslateCopyStatusIfNeeded();
        }

        public void ApplyLanguage()
        {
            this.Text = "EASY CLIP LOGIN";
            materialLabel1.Text = LanguageManager.Get(LangKeys.Login_AppCode);
            materialLabel2.Text = LanguageManager.Get(LangKeys.Login_ApiKey);
            btnLoginApiKey.Text = LanguageManager.Get(LangKeys.Login_BtnLogin);
            lkHelp.Text = LanguageManager.Get(LangKeys.Login_Help);
            linklbRegister.Text = LanguageManager.Get(LangKeys.Login_Register);
            TranslateCopyStatusIfNeeded();
        }

        private void TranslateCopyStatusIfNeeded()
        {
            string current = lbstatus.Text?.Trim();
            if (string.IsNullOrEmpty(current))
            {
                return;
            }

            bool isCopySuccess = current == AppCodeCopiedVi || current == AppCodeCopiedEn;
            bool isCopyFailed = current == AppCodeCopyFailedVi || current == AppCodeCopyFailedEn;
            if (!isCopySuccess && !isCopyFailed)
            {
                return;
            }

            if (LanguageManager.CurrentLanguage == LanguageManager.Language.En)
            {
                lbstatus.Text = isCopySuccess ? AppCodeCopiedEn : AppCodeCopyFailedEn;
            }
            else
            {
                lbstatus.Text = isCopySuccess ? AppCodeCopiedVi : AppCodeCopyFailedVi;
            }
        }

        private void SetupLoginUi()
        {
            ApplyBrandLogo();

            // Remove outer frame: let the card occupy full form.
            if (cardPanel != null)
            {
                cardPanel.Dock = DockStyle.Fill;
                cardPanel.Location = Point.Empty;
                cardPanel.Margin = Padding.Empty;
            }

            // Commonized UI setup (easy to maintain)
            if (txAppCodeShow is UiTextBox appCode)
            {
                appCode.ReadOnly = true;
                // Make it visually obvious it's read-only
                appCode.BackgroundColor = ColorTranslator.FromHtml("#F1F5F9");
                appCode.BorderColor = ColorTranslator.FromHtml("#E2E8F0");
                appCode.InnerTextBox.ForeColor = ColorTranslator.FromHtml("#64748B");
                appCode.Cursor = Cursors.Hand;
                appCode.InnerTextBox.Cursor = Cursors.Hand;

                if (!_appCodeActionsWired)
                {
                    _appCodeActionsWired = true;
                    appCode.RightIconClick += (_, __) => CopyAppCodeToClipboard();
                    appCode.InnerTextBox.MouseClick += (_, __) => appCode.InnerTextBox.SelectAll();
                }
            }

            if (txInsertApiKey is UiTextBox apiKey)
            {
                // Keep API key textbox on a white background.
                apiKey.BackgroundColor = Color.White;
                apiKey.BorderColor = ColorTranslator.FromHtml("#D6DCEC");
                apiKey.BorderFocusColor = ColorTranslator.FromHtml("#61B0FF");
                apiKey.HoverColor = ColorTranslator.FromHtml("#F2F4F8");
                apiKey.TextColor = ColorTranslator.FromHtml("#212529");
                apiKey.InnerTextBox.ForeColor = ColorTranslator.FromHtml("#212529");
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

        private void ApplyBrandLogo()
        {
            if (_brandLogoApplied || lblLogoIcon == null)
            {
                return;
            }

            // Use iEasyClip.ico directly; fallback only to the static resource image.
            Bitmap logoBitmap = LoadBrandLogoFromIco() ?? EasyClip.Properties.Resources.ivoice;
            if (logoBitmap == null)
            {
                return;
            }

            _brandLogoApplied = true;
            lblLogoIcon.Text = string.Empty;
            lblLogoIcon.BackColor = Color.Transparent;
            lblLogoIcon.ImageAlign = ContentAlignment.MiddleCenter;

            // Make logo more prominent on login screen.
            const int maxDisplaySize = 96;
            float scale = Math.Min((float)maxDisplaySize / logoBitmap.Width, (float)maxDisplaySize / logoBitmap.Height);
            int targetW = Math.Max(1, (int)Math.Round(logoBitmap.Width * scale));
            int targetH = Math.Max(1, (int)Math.Round(logoBitmap.Height * scale));
            var resized = ResizeBitmapHighQuality(logoBitmap, new Size(targetW, targetH));
            lblLogoIcon.Image = CreateHighlightedLogo(resized);
        }

        private Bitmap LoadBrandLogoFromIco()
        {
            try
            {
                string iconPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "iEasyClip.ico");
                if (!File.Exists(iconPath))
                {
                    return null;
                }

                using (var icon = new Icon(iconPath))
                using (var hiDpiIcon = new Icon(icon, new Size(128, 128)))
                {
                    return hiDpiIcon.ToBitmap();
                }
            }
            catch
            {
                return null;
            }
        }

        private static Bitmap ResizeBitmapHighQuality(Bitmap source, Size targetSize)
        {
            var result = new Bitmap(targetSize.Width, targetSize.Height);
            using (var g = Graphics.FromImage(result))
            {
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.DrawImage(source, new Rectangle(Point.Empty, targetSize));
            }
            return result;
        }

        private static Bitmap CreateHighlightedLogo(Bitmap source)
        {
            int pad = 15;
            int width = source.Width + pad * 2;
            int height = source.Height + pad * 2;
            var badge = new Bitmap(width, height);
            using (var g = Graphics.FromImage(badge))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;

                // Soft glow to make logo stand out on purple background.
                using (var outer = new SolidBrush(Color.FromArgb(85, 255, 255, 255)))
                using (var inner = new SolidBrush(Color.FromArgb(145, 255, 255, 255)))
                {
                    g.FillEllipse(outer, 0, 0, width - 1, height - 1);
                    g.FillEllipse(inner, 4, 4, width - 9, height - 9);
                }

                g.DrawImage(source, new Rectangle(pad, pad, source.Width, source.Height));
            }
            return badge;
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
            // Keep a clean white canvas to avoid outer-looking border.
            e.Graphics.Clear(Color.White);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

        private void ApplyRoundedRegions()
        {
            // Keep outer window corners not rounded.
            if (Region != null)
            {
                Region = null;
            }

            // Avoid rounded clipping artifacts on logo host.
            if (pnlLogo != null && pnlLogo.Region != null)
            {
                pnlLogo.Region = null;
            }
        }

        // Paint borders for card + pill panels (Designer-safe: standard Panels)
        private void cardPanel_Paint(object sender, PaintEventArgs e)
        {
            // Intentionally empty.
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
            lbstatus.ForeColor = Color.White;
            // Kiểm tra API Key
            string apiKey = txInsertApiKey.Text.Trim();
            if (string.IsNullOrEmpty(apiKey))
            {
                MsgBox.Show(LanguageManager.Get(LangKeys.Login_EnterApiKey), LanguageManager.Get(LangKeys.Common_Notice), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnLoginApiKey.Enabled = true; // Bật lại nút nếu lỗi
                return;
            }

            try
            {
                // Lấy appCode từ service
                string appCode = appCodeService.GetAppCode();
                string appSlugID = "easy-clip101"; // Mã SlugID của product - {101 là v1.0.1}, confirm admin nếu thấy thay đổi version

                var request = new ApiClientRequest(LibConst.UrlServer, apiKey);
                var response = await request.EasyClipVersionAsync(appCode, appSlugID);
                if (response.IsSuccess)
                {
                    // Code 2001: Tài khoản hợp lệ nhưng chưa kích hoạt gói hoặc gói đã hết hạn
                    if (response.Code == VersionMessageHelper.CodeSuccessNoSubscription)
                    {
                        lbstatus.Text = VersionMessageHelper.GetMessage(response.Code);
                        lbstatus.ForeColor = Color.FromArgb(255, 77, 79);
                        return;
                    }

                    string currentVersion = AppVersion;
                    string latestVersion = response.Version;
                    var checkver = new CheckVersionServices();
                    if (checkver.IsNewerVersion(latestVersion, currentVersion))
                    {
                        DialogResult result = MsgBox.Show(
                           LanguageManager.GetFormat(LangKeys.Login_VersionUpdate, currentVersion, latestVersion),
                           LanguageManager.Get(LangKeys.Login_VersionUpdateTitle),
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
                    // Mở form chính và đóng form đăng nhập, truyền response để tránh gọi API lần 2
                    this.Hide();
                    FormMain mainForm = new FormMain(appCode, appSlugID, txInsertApiKey.Text, response);

                    mainForm.ShowDialog();
                    // Sau khi đóng form chính, thoát ứng dụng
                    Application.Exit();
                }
                else
                {
                    // Hiển thị thông báo dựa trên mã code từ server
                    lbstatus.Text = VersionMessageHelper.GetMessage(response.Code);
                    lbstatus.ForeColor = Color.FromArgb(255, 77, 79);
                }
            }
            catch
            {
                lbstatus.Text = LanguageManager.Get(LangKeys.Login_ConnectionFailed);
                lbstatus.ForeColor = Color.FromArgb(255, 77, 79);
            }
            finally
            {
                // Bật lại nút dù có lỗi hay không
                btnLoginApiKey.Enabled = true;
            }
        }

        private void CopyAppCodeToClipboard()
        {
            string appCode = txAppCodeShow.Text?.Trim();
            if (string.IsNullOrWhiteSpace(appCode))
            {
                return;
            }

            try
            {
                Clipboard.SetText(appCode);
                lbstatus.Text = LanguageManager.CurrentLanguage == LanguageManager.Language.En
                    ? AppCodeCopiedEn
                    : AppCodeCopiedVi;
                lbstatus.ForeColor = Color.FromArgb(185, 246, 202);
            }
            catch
            {
                lbstatus.Text = LanguageManager.CurrentLanguage == LanguageManager.Language.En
                    ? AppCodeCopyFailedEn
                    : AppCodeCopyFailedVi;
                lbstatus.ForeColor = Color.FromArgb(255, 77, 79);
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
