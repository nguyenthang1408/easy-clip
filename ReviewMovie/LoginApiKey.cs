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

            // UI polish (không ảnh hưởng logic)
            lbstatus.MaximumSize = new Size(312, 0);
            lbstatus.AutoEllipsis = true;
            MakeCircle(lblLogo);
        }

        private void panelCard_Paint(object sender, PaintEventArgs e)
        {
            // Vẽ card bo góc + viền nhẹ theo style modern
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            var rect = panelCard.ClientRectangle;
            rect.Inflate(-1, -1);

            using (var path = CreateRoundedRectPath(rect, 22))
            using (var fill = new SolidBrush(Color.White))
            using (var border = new Pen(Color.FromArgb(232, 236, 246), 1f))
            {
                e.Graphics.FillPath(fill, path);
                e.Graphics.DrawPath(border, path);
            }
        }

        private static void MakeCircle(Control c)
        {
            // Tạo badge tròn cho logo (UI-only)
            var diameter = Math.Min(c.Width, c.Height);
            var rect = new Rectangle(0, 0, diameter, diameter);
            using (var path = new GraphicsPath())
            {
                path.AddEllipse(rect);
                c.Region = new Region(path);
            }
        }

        private static GraphicsPath CreateRoundedRectPath(Rectangle bounds, int radius)
        {
            var path = new GraphicsPath();
            int d = radius * 2;
            var arc = new Rectangle(bounds.Location, new Size(d, d));

            // top-left
            path.AddArc(arc, 180, 90);
            // top-right
            arc.X = bounds.Right - d;
            path.AddArc(arc, 270, 90);
            // bottom-right
            arc.Y = bounds.Bottom - d;
            path.AddArc(arc, 0, 90);
            // bottom-left
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
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

        }
    }
}
