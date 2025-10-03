using System;
using System.Management;

namespace Common.Services
{
    public  class AppCodeService
    {
        public string GetAppCode()
        {
            string hardDiskSerial = GetHardDiskSerialNumber();
            return $"{hardDiskSerial}";
        }

        private  string GetHardDiskSerialNumber()
        {
            // Lấy số serial của ổ cứng
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
                foreach (ManagementObject wmi_HD in searcher.Get())
                {
                    return wmi_HD["SerialNumber"].ToString().Trim();
                }
            }
            catch
            {
                return "Temp001";
            }
            return "Temp001";
        }
    }
}
