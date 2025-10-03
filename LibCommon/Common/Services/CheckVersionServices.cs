using System;

namespace Common.Services
{
    public class CheckVersionServices
    {
        public CheckVersionServices(){}

        public bool IsNewerVersion(string latestVersion, string currentVersion)
        {
            try
            {
                Version latest = new Version(latestVersion);
                Version current = new Version(currentVersion);

                return latest > current;
            }
            catch
            {
                // Nếu có lỗi trong quá trình so sánh phiên bản, giả sử rằng cần cập nhật
                return true;
            }
        }
    }
}
