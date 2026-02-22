using Common.Constant;
using Common.Services;
using EasyClip.Infrastructure.Config;
using Lib;
using LibCommon.Lib;
using ReviewMovie.Localization;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ReviewMovie
{
    public partial class LoginApiKey : Form, ILocalizable
    {
        private string AppVersion { get; } = "1.0.1"; // Định nghĩa phiên bản ứng dụng
        private readonly AppCodeService appCodeService;
        private readonly IConfigDataService _configService;

        public LoginApiKey()
        {
            InitializeComponent();
            appCodeService = new AppCodeService(); // Khởi tạo service
            _configService = new ConfigDataService();

            // Load saved language and set ComboBox
            LanguageManager.LoadSavedLanguage();
            cbAppLanguage.SelectedIndex = LanguageManager.CurrentLanguage == LanguageManager.Language.En ? 1 : 0;

            // Subscribe to language change
            LanguageManager.LanguageChanged += ApplyLanguage;
            ApplyLanguage();

            DisplayAppCode();
            LoadApiKey();

            // Đặt sự kiện cho việc đóng form
            this.FormClosing += LoginApiKey_FormClosing;
        }

        public void ApplyLanguage()
        {
            this.Text = LanguageManager.Get(LangKeys.Login_Title);
            materialLabel1.Text = LanguageManager.Get(LangKeys.Login_AppCode);
            materialLabel2.Text = LanguageManager.Get(LangKeys.Login_ApiKey);
            btnLoginApiKey.Text = LanguageManager.Get(LangKeys.Login_BtnLogin);
            lkHelp.Text = LanguageManager.Get(LangKeys.Login_Help);
            linklbRegister.Text = LanguageManager.Get(LangKeys.Login_Register);
        }

        private void cbAppLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbAppLanguage.SelectedIndex == 1)
                LanguageManager.SetLanguage(LanguageManager.Language.En);
            else
                LanguageManager.SetLanguage(LanguageManager.Language.Vi);
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
                    MessageBox.Show(LanguageManager.Get(LangKeys.Login_CannotGetKey) + ex.Message, LanguageManager.Get(LangKeys.Common_Error), MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(LanguageManager.Get(LangKeys.Login_EnterApiKey), LanguageManager.Get(LangKeys.Common_Notice), MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        lbstatus.ForeColor = Color.OrangeRed;
                        return;
                    }

                    string currentVersion = AppVersion;
                    string latestVersion = response.Version;
                    var checkver = new CheckVersionServices();
                    if (checkver.IsNewerVersion(latestVersion, currentVersion))
                    {
                        DialogResult result = MessageBox.Show(
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
                    lbstatus.ForeColor = Color.Red;
                }
            }
            catch
            {
                lbstatus.Text = LanguageManager.Get(LangKeys.Login_ConnectionFailed);
                lbstatus.ForeColor = Color.Red;
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
            LanguageManager.LanguageChanged -= ApplyLanguage;
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
