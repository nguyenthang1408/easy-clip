using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public partial class ApiFptAI
    {
        public static List<ComboboxModel> FptAILanguageTemplate()
        {
            List<ComboboxModel> fptAILanguageSelect = new List<ComboboxModel> {
                new ComboboxModel{ Display = FptAIVoiceLanguage.VietNam_Des, Value = FptAIVoiceLanguage.VietNam}
            };
            return fptAILanguageSelect;
        }
        public static List<ComboboxModel> FptAIVoiceCodeTemplate()
        {
            List<ComboboxModel> giongDocFptAI = new List<ComboboxModel> {
                new ComboboxModel{ Display = FptAIVoicecode.Banmai_Des, Value = FptAIVoicecode.Banmai},
                new ComboboxModel{ Display = FptAIVoicecode.Thuminh_Des, Value = FptAIVoicecode.Thuminh},
                new ComboboxModel{ Display = FptAIVoicecode.Myan_Des, Value = FptAIVoicecode.Myan},
                new ComboboxModel{ Display = FptAIVoicecode.Ngoclam_Des, Value = FptAIVoicecode.Ngoclam},
                new ComboboxModel{ Display = FptAIVoicecode.Linhsan_Des, Value = FptAIVoicecode.Linhsan},
                new ComboboxModel{ Display = FptAIVoicecode.Lannhi_Des, Value = FptAIVoicecode.Lannhi},
                new ComboboxModel{ Display = FptAIVoicecode.Leminh_Des, Value = FptAIVoicecode.Leminh},
                new ComboboxModel{ Display = FptAIVoicecode.Giahuy_Des, Value = FptAIVoicecode.Giahuy},
                new ComboboxModel{ Display = FptAIVoicecode.Minhquang_Des, Value = FptAIVoicecode.Minhquang}
                };
            return giongDocFptAI;
        }
    }
}
