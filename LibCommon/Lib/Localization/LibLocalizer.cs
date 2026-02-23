using System;

namespace LibCommon.Lib.Localization
{
    public static class LibLocalizer
    {
        public static Func<string, string> GetText { get; set; }

        /// <summary>
        /// Returns current language code ("vi" or "en"). Set from UI layer.
        /// </summary>
        public static Func<string> GetCurrentLanguage { get; set; }

        public static bool IsEnglish => GetCurrentLanguage?.Invoke() == "en";

        public static string Get(string key)
        {
            return GetText?.Invoke(key) ?? $"[{key}]";
        }

        public static string GetFormat(string key, params object[] args)
        {
            var template = Get(key);
            try
            {
                return string.Format(template, args);
            }
            catch
            {
                return template;
            }
        }
    }
}
