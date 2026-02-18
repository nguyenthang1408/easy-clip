
namespace Common.Constant
{
    public class LibConst
    {
#if DEBUG
        public const string UrlServer = "http://localhost:5000"; // URL dành cho debug
        //public const string UrlServer = "https://t2psoft.com"; // URL dành cho môi trường release
#else
                public const string UrlServer = "https://t2psoft.com"; // URL dành cho môi trường release
#endif

        public const string AppName = "EasyClip";
        public const string DBName = "config.db";
        public const string DBNameBackup = "config_backup.bak";

        /// <summary>
        /// Source identifier gửi lên server khi log TTS usage
        /// </summary>
        public const string TtsSourceApp = "easy-clip101";
    }

}
