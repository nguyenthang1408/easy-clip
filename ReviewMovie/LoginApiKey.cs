using Common.Constant;
using Common.Services;
using EasyClip.Infrastructure.Config;
using Lib;
using LibCommon.Lib;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ReviewMovie
{
    public partial class LoginApiKey : Form
    {
        private string AppVersion { get; } = "1.0.1"; // Định nghĩa phiên bản ứng dụng
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
                        lbstatus.Text = VersionMessageHelper.GetVietnameseMessage(response.Code);
                        lbstatus.ForeColor = Color.OrangeRed;
                        return;
                    }

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

                    // Mở form chính và đóng form đăng nhập, truyền response để tránh gọi API lần 2
                    this.Hide();
                    FormMain mainForm = new FormMain(appCode, appSlugID, txInsertApiKey.Text, response);

                    mainForm.ShowDialog();
                    // Sau khi đóng form chính, thoát ứng dụng
                    Application.Exit();
                }
                else
                {
                    // Hiển thị thông báo tiếng Việt dựa trên mã code từ server
                    lbstatus.Text = VersionMessageHelper.GetVietnameseMessage(response.Code);
                    lbstatus.ForeColor = Color.Red;
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
