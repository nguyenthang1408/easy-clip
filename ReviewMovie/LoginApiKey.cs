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
using MessageBox = ReviewMovie.Base.UiMessageBox;

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
            var windowBackColor = Color.FromArgb(17, 20, 27);
            var cardBackColor = Color.FromArgb(24, 28, 36);
            var cardRaisedColor = Color.FromArgb(33, 38, 49);
            var inputBackColor = Color.FromArgb(36, 42, 54);
            var borderColor = Color.FromArgb(61, 70, 86);
            var accentColor = Color.FromArgb(0, 196, 255);
            var accentHoverColor = Color.FromArgb(33, 209, 255);
            var accentPressedColor = Color.FromArgb(0, 162, 211);
            var textPrimaryColor = Color.FromArgb(237, 242, 249);
            var textSecondaryColor = Color.FromArgb(158, 170, 189);

            BackColor = windowBackColor;

            // Remove outer frame: let the card occupy full form.
            if (cardPanel != null)
            {
                cardPanel.Dock = DockStyle.Fill;
                cardPanel.Location = Point.Empty;
                cardPanel.Margin = Padding.Empty;
                cardPanel.BackColor = cardBackColor;
            }

            if (pnlTopAccent != null)
            {
                pnlTopAccent.Visible = true;
                pnlTopAccent.Height = 3;
                pnlTopAccent.BackColor = accentColor;
            }

            if (pnlLogo != null)
            {
                pnlLogo.BackColor = cardRaisedColor;
            }

            if (lblLogoIcon != null)
            {
                lblLogoIcon.ForeColor = accentColor;
            }

            if (lblTitle != null)
            {
                lblTitle.ForeColor = textPrimaryColor;
            }

            if (lblSubtitle != null)
            {
                lblSubtitle.ForeColor = textSecondaryColor;
            }

            if (materialLabel1 != null)
            {
                materialLabel1.ForeColor = textSecondaryColor;
            }

            if (materialLabel2 != null)
            {
                materialLabel2.ForeColor = textSecondaryColor;
            }

            if (lkHelp != null)
            {
                lkHelp.LinkColor = textSecondaryColor;
                lkHelp.ActiveLinkColor = accentColor;
                lkHelp.VisitedLinkColor = textSecondaryColor;
            }

            if (linklbRegister != null)
            {
                linklbRegister.LinkColor = accentColor;
                linklbRegister.ActiveLinkColor = accentHoverColor;
                linklbRegister.VisitedLinkColor = accentColor;
            }

            if (lbstatus != null)
            {
                lbstatus.ForeColor = Color.FromArgb(255, 111, 111);
            }

            // Commonized UI setup (easy to maintain)
            if (txAppCodeShow is UiTextBox appCode)
            {
                appCode.ReadOnly = true;
                // Make it visually obvious it's read-only
                appCode.BackgroundColor = cardRaisedColor;
                appCode.BorderColor = borderColor;
                appCode.BorderFocusColor = accentColor;
                appCode.HoverColor = Color.FromArgb(40, 46, 58);
                appCode.TextColor = textSecondaryColor;
                appCode.InnerTextBox.BackColor = cardRaisedColor;
                appCode.InnerTextBox.ForeColor = textSecondaryColor;
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

            if (txInsertApiKey is UiTextBox apiKey)
            {
                apiKey.BackgroundColor = inputBackColor;
                apiKey.BorderColor = borderColor;
                apiKey.BorderFocusColor = accentColor;
                apiKey.HoverColor = Color.FromArgb(45, 52, 66);
                apiKey.TextColor = textPrimaryColor;
                apiKey.InnerTextBox.BackColor = inputBackColor;
                apiKey.InnerTextBox.ForeColor = textPrimaryColor;
            }

            if (btnLoginApiKey is PrimaryButton primary)
            {
                primary.FillColor = accentColor;
                primary.HoverFillColor = accentHoverColor;
                primary.PressedFillColor = accentPressedColor;
                primary.CornerRadius = UiTheme.ButtonRadius;
                primary.ForeColor = Color.FromArgb(8, 23, 33);
            }

            if (btnClose is IconCircleButton close)
            {
                close.CornerRadius = UiTheme.CloseRadius;
                close.NormalBackColor = cardRaisedColor;
                close.HoverBackColor = Color.FromArgb(46, 52, 65);
                close.PressedBackColor = Color.FromArgb(56, 63, 78);
                close.ForeColor = textSecondaryColor;
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
            e.Graphics.Clear(Color.FromArgb(17, 20, 27));
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

            // Card + logo (pills/buttons handle their own rounding)
            UiHelpers.ApplyRoundRegion(pnlLogo, 14);
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
            lbstatus.ForeColor = Color.FromArgb(158, 170, 189);
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
                    ShowLoginSuccessPopup("Đăng nhập thành công!");

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

        private void ShowLoginSuccessPopup(string message)
        {
            using (var popup = new Form())
            {
                var overlayColor = Color.FromArgb(17, 20, 27);
                var cardColor = Color.FromArgb(24, 28, 36);
                var raisedColor = Color.FromArgb(33, 38, 49);
                var borderColor = Color.FromArgb(61, 70, 86);
                var accentColor = Color.FromArgb(0, 196, 255);
                var accentHoverColor = Color.FromArgb(33, 209, 255);
                var accentPressedColor = Color.FromArgb(0, 162, 211);
                var textPrimaryColor = Color.FromArgb(237, 242, 249);
                var textSecondaryColor = Color.FromArgb(158, 170, 189);

                popup.FormBorderStyle = FormBorderStyle.None;
                popup.StartPosition = FormStartPosition.CenterParent;
                popup.ShowInTaskbar = false;
                popup.TopMost = true;
                popup.BackColor = overlayColor;
                popup.ClientSize = new Size(360, 190);
                popup.Padding = new Padding(8);
                popup.Text = "Thông báo";
                UiHelpers.EnableSmoothPainting(popup);

                var panelCard = new Panel
                {
                    Dock = DockStyle.Fill,
                    BackColor = cardColor
                };
                popup.Controls.Add(panelCard);

                var panelHeader = new Panel
                {
                    Dock = DockStyle.Top,
                    Height = 42,
                    BackColor = raisedColor
                };
                var lblTitle = new Label
                {
                    AutoSize = true,
                    Text = "Thông báo",
                    Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point),
                    ForeColor = textPrimaryColor,
                    Location = new Point(12, 9)
                };
                panelHeader.Controls.Add(lblTitle);

                var btnClose = new Button
                {
                    Text = "x",
                    Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point),
                    ForeColor = textSecondaryColor,
                    FlatStyle = FlatStyle.Flat,
                    Size = new Size(32, 28),
                    Location = new Point(popup.ClientSize.Width - 52, 7),
                    Anchor = AnchorStyles.Top | AnchorStyles.Right,
                    Cursor = Cursors.Hand,
                    TabStop = false
                };
                btnClose.FlatAppearance.BorderSize = 0;
                btnClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 57, 70);
                btnClose.FlatAppearance.MouseDownBackColor = Color.FromArgb(59, 67, 82);
                btnClose.Click += (_, __) =>
                {
                    popup.DialogResult = DialogResult.OK;
                    popup.Close();
                };
                panelHeader.Controls.Add(btnClose);

                var panelBody = new Panel
                {
                    Dock = DockStyle.Fill,
                    BackColor = cardColor
                };
                panelCard.Controls.Add(panelBody);
                panelCard.Controls.Add(panelHeader);

                var bodyLayout = new TableLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    ColumnCount = 2,
                    RowCount = 3,
                    Padding = new Padding(20, 18, 20, 14),
                    BackColor = cardColor
                };
                bodyLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 56F));
                bodyLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
                bodyLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 58F));
                bodyLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
                bodyLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
                panelBody.Controls.Add(bodyLayout);

                var iconCircle = new RoundedPanel
                {
                    Size = new Size(40, 40),
                    Dock = DockStyle.Fill,
                    FillColor = accentColor,
                    BorderThickness = 0,
                    CornerRadius = 20,
                    Margin = new Padding(0, 12, 12, 6)
                };
                bodyLayout.Controls.Add(iconCircle, 0, 0);

                var lblIcon = new Label
                {
                    Dock = DockStyle.Fill,
                    Text = "i",
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point),
                    ForeColor = Color.White,
                    BackColor = Color.Transparent
                };
                iconCircle.Controls.Add(lblIcon);

                var lblMessage = new Label
                {
                    AutoSize = false,
                    Text = message,
                    Font = new Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point),
                    ForeColor = textPrimaryColor,
                    Dock = DockStyle.Fill,
                    Margin = new Padding(0, 12, 0, 6),
                    TextAlign = ContentAlignment.MiddleLeft,
                    AutoEllipsis = true
                };
                bodyLayout.Controls.Add(lblMessage, 1, 0);

                var btnOk = new PrimaryButton
                {
                    Text = "OK",
                    Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point),
                    ForeColor = Color.FromArgb(8, 23, 33),
                    FillColor = accentColor,
                    HoverFillColor = accentHoverColor,
                    PressedFillColor = accentPressedColor,
                    CornerRadius = 8,
                    Size = new Size(96, 34),
                    Anchor = AnchorStyles.Right,
                    Margin = new Padding(0, 4, 0, 0),
                    Cursor = Cursors.Hand,
                    DialogResult = DialogResult.OK
                };
                bodyLayout.Controls.Add(btnOk, 1, 2);
                popup.AcceptButton = btnOk;
                popup.CancelButton = btnOk;

                panelCard.Paint += (s, e) =>
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    var rect = new Rectangle(0, 0, panelCard.Width - 1, panelCard.Height - 1);
                    using (var pen = new Pen(borderColor, 1f))
                    using (var path = UiHelpers.CreateRoundedRectPath(rect, 10))
                    {
                        e.Graphics.DrawPath(pen, path);
                    }
                };
                panelHeader.Paint += (s, e) =>
                {
                    using (var pen = new Pen(borderColor, 1f))
                    {
                        e.Graphics.DrawLine(pen, 0, panelHeader.Height - 1, panelHeader.Width, panelHeader.Height - 1);
                    }
                };

                MouseEventHandler dragHandler = (s, e) =>
                {
                    if (e.Button != MouseButtons.Left) return;
                    Win32.BeginDrag(popup);
                };
                panelHeader.MouseDown += dragHandler;
                lblTitle.MouseDown += dragHandler;

                popup.Shown += (s, e) =>
                {
                    UiHelpers.ApplyRoundRegion(panelCard, 10);
                };
                popup.Resize += (s, e) =>
                {
                    if (panelCard.Width > 0 && panelCard.Height > 0)
                    {
                        UiHelpers.ApplyRoundRegion(panelCard, 10);
                    }
                };

                popup.ShowDialog(this);
            }
        }

        private void LoginApiKey_Load(object sender, EventArgs e)
        {
            CenterCard();
            SetupLoginUi();
        }
    }
}
