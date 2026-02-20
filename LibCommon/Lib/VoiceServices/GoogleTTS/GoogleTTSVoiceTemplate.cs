using Google.Cloud.TextToSpeech.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.VoiceServices.GoogleTTS
{
    public class GoogleTTSVoiceTemplate
    {
        ListVoicesResponse _listVoicesResponse;
        bool _clientValid = false;

        public GoogleTTSVoiceTemplate(string jsonData) 
        {
            APIGoogleTTS apiTTS = new APIGoogleTTS();
            TextToSpeechClient client = apiTTS.textToSpeechClient(jsonData);
            if (client != null) { 
                _clientValid = true;
                _listVoicesResponse = apiTTS.listVoicesResponse(client);
            }  
        }
        public bool CheckClient()
        {
            return _clientValid;
        }
        public List<ComboboxModel> GetListLanguage()
        {
            if (_listVoicesResponse != null)
            {
                // Tạo danh sách ngôn ngữ (loại bỏ trùng lặp)
                var languages = _listVoicesResponse.Voices
                    .SelectMany(v => v.LanguageCodes)
                    .Distinct()
                    .ToList();

                string languageString = string.Join(", ", languages);
                // Tạo danh sách ComboBoxItem
                var comboBoxItems = new List<ComboboxModel>();
                foreach (var languageCode in languages)
                {
                    // Chuyển mã ngôn ngữ thành tên ngôn ngữ hiển thị
                    string displayName = GoogleTTSVoiceCode.GetLanguageDisplayName(languageCode);
                    comboBoxItems.Add(new ComboboxModel
                    {
                        Display = displayName,
                        Value = languageCode
                    });
                }

                // Trả về danh sách các mục
                return comboBoxItems;
            }
            else
            { return null; }
        }

        public List<ComboboxModel> GetVoicesByLanguage(string selectedLanguageCode)
        {
            if (_listVoicesResponse != null && !string.IsNullOrEmpty(selectedLanguageCode))
            {
                // Lọc danh sách giọng đọc theo mã ngôn ngữ
                var voices = _listVoicesResponse.Voices
                .Where(v => v.LanguageCodes.Contains(selectedLanguageCode))
                .ToList();

                // Tạo danh sách ComboBoxItem cho các giọng đọc
                var comboBoxItems = new List<ComboboxModel>();
                foreach (var voice in voices)
                {
                    comboBoxItems.Add(new ComboboxModel
                    {
                        Display = string.Format("{0} - {1}", voice.Name, voice.SsmlGender), // Hiển thị tên giọng và giới tính
                        Value = voice.Name // Giá trị thực là tên giọng đọc
                    });
                }

                // Trả về danh sách các mục
                return comboBoxItems;
            }
            else
            {
                return null;
            }
        }


    }
}
