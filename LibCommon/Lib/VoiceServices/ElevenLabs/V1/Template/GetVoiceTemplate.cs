using Lib.VoiceServices.ElevenLabs.V1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.VoiceServices.ElevenLabs.V1
{
    public class GetVoiceTemplate
    {
        public static List<ComboboxModel> ElevenLabsLanguageTemplate_old(List<Voice> voices)
        {
            var groupedLanguage = voices
            .Where(v => v.Labels != null && !string.IsNullOrEmpty(v.Labels.Accent)) // Lọc những đối tượng có Accent không null
            .GroupBy(v => v.Labels.Accent)
            .Select(g => new ComboboxModel
            {
                Display = g.Key, // Sử dụng giá trị Accent làm Display
                Value = g.Key // Bạn có thể thay đổi Value thành một giá trị khác nếu cần
            })
            .ToList();

            return groupedLanguage;
        }

        public static List<ComboboxModel> SearchVoicesByAccent_old(List<Voice> voices, string accentSearchTerm)
        {
            var filteredVoices = voices
                .Where(v => v.Labels != null &&
                            !string.IsNullOrEmpty(v.Labels.Accent) &&
                            !string.IsNullOrEmpty(accentSearchTerm) && // Đảm bảo accentSearchTerm không null hoặc rỗng

                            //v.Labels.Accent.IndexOf(accentSearchTerm, StringComparison.OrdinalIgnoreCase) >= 0) // So sánh Accent theo cách không phân biệt chữ hoa, chữ thường
                            v.Labels.Accent.IndexOf(accentSearchTerm) >= 0) // Phân biệt chữ hoa, chữ thường
                .Select(v => new ComboboxModel
                {
                    // Tạo chuỗi Display bao gồm Name, Gender, Age, và UseCase
                    Display = $"Name: {v.Name} | {v.Labels.Gender} | {v.Labels.Age} | {v.Labels.UseCase}",
                    Value = v.VoiceId // Gán VoiceId cho Value
                })
                .ToList();

            return filteredVoices;
        }

        public static List<ComboboxModel> ElevenLabsLanguageTemplate(List<Voice> voices)
        {
            var groupedLanguage = voices
            .Where(v => v.Labels != null)
            .GroupBy(v => v.Labels.Language + "*" + v.Labels.Accent)
            .Select(g => new ComboboxModel
            {
                Display = g.Key, // Sử dụng giá trị Accent làm Display
                Value = g.Key // Bạn có thể thay đổi Value thành một giá trị khác nếu cần
            })
            .ToList();

            return groupedLanguage;
        }

        public static List<ComboboxModel> SearchVoicesByLanguageAccent(List<Voice> voices, string languageAccentSearchTerm)
        {
            var filteredVoices = voices
                .Where(v => v.Labels != null &&
                            !string.IsNullOrEmpty(languageAccentSearchTerm) && // Đảm bảo languageAccentSearchTerm không null hoặc rỗng
                             (v.Labels.Language + "*" + v.Labels.Accent).IndexOf(languageAccentSearchTerm) >= 0) // Phân biệt chữ hoa, chữ thường
                .Select(v => new ComboboxModel
                {
                    // Tạo chuỗi Display bao gồm Name, Gender, Age, và UseCase
                    Display = $"Name: {v.Name} | {v.Labels.Gender} | {v.Labels.Age} | {v.Labels.UseCase}",
                    Value = v.VoiceId // Gán VoiceId cho Value
                })
                .ToList();

            return filteredVoices;
        }

        public static float? GetStabilityByVoiceId(IReadOnlyList<Voice> voices, string voiceId)
        {
            // Tìm kiếm đối tượng Voice với VoiceId được cung cấp
            var voice = voices.FirstOrDefault(v => v.VoiceId == voiceId);

            // Nếu tìm thấy và có thuộc tính Settings, trả về giá trị Stability
            if (voice != null && voice.Settings != null)
            {
                return voice.Settings.Stability;
            }

            // Trả về null nếu không tìm thấy hoặc Settings là null
            return null;
        }

        public static VoiceSettings GetVoiceSettingByVoiceId(IReadOnlyList<Voice> voices, string voiceId)
        {
            if(voices == null || voiceId == null) return null;
            var voice = voices.FirstOrDefault(v => v.VoiceId == voiceId);

            if (voice != null && voice.Settings != null)
            {
                return voice.Settings;
            }
            return null;
        }
    }
}
