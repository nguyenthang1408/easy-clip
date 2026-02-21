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
                popup.FormBorderStyle = FormBorderStyle.None;
                popup.StartPosition = FormStartPosition.CenterParent;
                popup.ShowInTaskbar = false;
                popup.TopMost = true;
                popup.BackColor = Color.FromArgb(243, 246, 252);
                popup.ClientSize = new Size(360, 190);
                popup.Padding = new Padding(8);
                popup.Text = "Thông báo";
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
                    Height = 42,
                    BackColor = Color.FromArgb(248, 250, 255)
                };
                panelCard.Controls.Add(panelHeader);

                var lblTitle = new Label
                {
                    AutoSize = true,
                    Text = "Thông báo",
                    Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point),
                    ForeColor = Color.FromArgb(45, 53, 66),
                    Location = new Point(12, 9)
                };
                panelHeader.Controls.Add(lblTitle);

                var btnClose = new Button
                {
                    Text = "x",
                    Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point),
                    ForeColor = Color.FromArgb(118, 126, 140),
                    FlatStyle = FlatStyle.Flat,
                    Size = new Size(32, 28),
                    Location = new Point(popup.ClientSize.Width - 52, 7),
                    Anchor = AnchorStyles.Top | AnchorStyles.Right,
                    Cursor = Cursors.Hand,
                    TabStop = false
                };
                btnClose.FlatAppearance.BorderSize = 0;
                btnClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(240, 244, 252);
                btnClose.FlatAppearance.MouseDownBackColor = Color.FromArgb(229, 235, 246);
                btnClose.Click += (_, __) =>
                {
                    popup.DialogResult = DialogResult.OK;
                    popup.Close();
                };
                panelHeader.Controls.Add(btnClose);

                var panelBody = new Panel
                {
                    Dock = DockStyle.Fill,
                    BackColor = Color.White
                };
                panelCard.Controls.Add(panelBody);

                var bodyLayout = new TableLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    ColumnCount = 2,
                    RowCount = 3,
                    Padding = new Padding(20, 14, 20, 14),
                    BackColor = Color.White
                };
                bodyLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 56F));
                bodyLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
                bodyLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 58F));
                bodyLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
                bodyLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
                panelBody.Controls.Add(bodyLayout);

                var iconCircle = new Panel
                {
                    Size = new Size(40, 40),
                    Dock = DockStyle.Fill,
                    BackColor = Color.FromArgb(43, 123, 234),
                    Margin = new Padding(0, 8, 12, 8)
                };
                bodyLayout.Controls.Add(iconCircle, 0, 0);

                var lblIcon = new Label
                {
                    Dock = DockStyle.Fill,
                    Text = "i",
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point),
                    ForeColor = Color.White
                };
                iconCircle.Controls.Add(lblIcon);

                var lblMessage = new Label
                {
                    AutoSize = false,
                    Text = message,
                    Font = new Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point),
                    ForeColor = Color.FromArgb(45, 53, 66),
                    Dock = DockStyle.Fill,
                    Margin = new Padding(0, 8, 0, 8),
                    TextAlign = ContentAlignment.MiddleLeft,
                    AutoEllipsis = true
                };
                bodyLayout.Controls.Add(lblMessage, 1, 0);

                var btnOk = new Button
                {
                    Text = "OK",
                    Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point),
                    ForeColor = Color.White,
                    BackColor = Color.FromArgb(43, 123, 234),
                    FlatStyle = FlatStyle.Flat,
                    Size = new Size(96, 34),
                    Anchor = AnchorStyles.Right,
                    Margin = new Padding(0, 4, 0, 0),
                    Cursor = Cursors.Hand,
                    DialogResult = DialogResult.OK
                };
                btnOk.FlatAppearance.BorderSize = 0;
                btnOk.FlatAppearance.MouseOverBackColor = Color.FromArgb(38, 111, 214);
                btnOk.FlatAppearance.MouseDownBackColor = Color.FromArgb(33, 98, 190);
                bodyLayout.Controls.Add(btnOk, 1, 2);
                popup.AcceptButton = btnOk;
                popup.CancelButton = btnOk;

                panelCard.Paint += (s, e) =>
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    var rect = new Rectangle(0, 0, panelCard.Width - 1, panelCard.Height - 1);
                    using (var pen = new Pen(Color.FromArgb(216, 223, 236), 1f))
                    using (var path = UiHelpers.CreateRoundedRectPath(rect, 10))
                    {
                        e.Graphics.DrawPath(pen, path);
                    }
                };
                panelHeader.Paint += (s, e) =>
                {
                    using (var pen = new Pen(Color.FromArgb(230, 235, 245), 1f))
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
                    UiHelpers.ApplyRoundRegion(iconCircle, iconCircle.Width / 2);
                    UiHelpers.ApplyRoundRegion(btnOk, 8);
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
