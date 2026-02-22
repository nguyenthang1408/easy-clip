using EasyClip.Infrastructure.Config;
using ReviewMovie.Localization.Resources;
using System;
using System.Collections.Generic;

namespace ReviewMovie.Localization
{
    public static class LanguageManager
    {
        public enum Language { Vi, En }

        public static Language CurrentLanguage { get; private set; } = Language.Vi;

        public static event Action LanguageChanged;

        private static readonly IConfigDataService _configService = new ConfigDataService();

        public static void SetLanguage(Language lang)
        {
            if (CurrentLanguage == lang) return;
            CurrentLanguage = lang;
            SaveLanguageSetting(lang);
            LanguageChanged?.Invoke();
        }

        public static string Get(string key)
        {
            var dict = CurrentLanguage == Language.Vi ? Lang_vi.Texts : Lang_en.Texts;
            return dict.TryGetValue(key, out var val) ? val : $"[{key}]";
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

        public static void LoadSavedLanguage()
        {
            try
            {
                var saved = _configService.GetLanguage();
                if (!string.IsNullOrEmpty(saved) && saved == "en")
                    CurrentLanguage = Language.En;
                else
                    CurrentLanguage = Language.Vi;
            }
            catch
            {
                CurrentLanguage = Language.Vi;
            }
        }

        private static void SaveLanguageSetting(Language lang)
        {
            try
            {
                _configService.UpdateLanguage(lang == Language.En ? "en" : "vi");
            }
            catch
            {
                // Ignore save errors
            }
        }
    }
}
