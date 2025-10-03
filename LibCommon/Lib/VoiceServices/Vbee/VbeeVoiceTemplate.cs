using System;
using System.Collections.Generic;

namespace Lib
{
    public partial class ApiVbee
    {
        public static List<ComboboxModel> VbeeLanguageTemplate()
        {
            List<ComboboxModel> vBeeLanguageSelect = new List<ComboboxModel> {
                new ComboboxModel{ Display = VbeeVoiceLanguage.VietNam_Des, Value = VbeeVoiceLanguage.VietNam},
                new ComboboxModel{ Display = VbeeVoiceLanguage.German_Des, Value = VbeeVoiceLanguage.German},
                new ComboboxModel{ Display = VbeeVoiceLanguage.Korean_Des, Value = VbeeVoiceLanguage.Korean},
                new ComboboxModel{ Display = VbeeVoiceLanguage.ChineseHK_Des, Value = VbeeVoiceLanguage.ChineseHK},
                new ComboboxModel{ Display = VbeeVoiceLanguage.Russian_Des, Value = VbeeVoiceLanguage.Russian},
                new ComboboxModel{ Display = VbeeVoiceLanguage.Japanese_Des, Value = VbeeVoiceLanguage.Japanese},
                new ComboboxModel{ Display = VbeeVoiceLanguage.French_Des, Value = VbeeVoiceLanguage.French},
                new ComboboxModel{ Display = VbeeVoiceLanguage.FrenchCA_Des, Value = VbeeVoiceLanguage.FrenchCA},
                new ComboboxModel{ Display = VbeeVoiceLanguage.EnglishBritish_Des, Value = VbeeVoiceLanguage.EnglishBritish},
                new ComboboxModel{ Display = VbeeVoiceLanguage.EnglishUK_Des, Value = VbeeVoiceLanguage.EnglishUK},
                new ComboboxModel{ Display = VbeeVoiceLanguage.EnglishUS_Des, Value = VbeeVoiceLanguage.EnglishUS},
                new ComboboxModel{ Display = VbeeVoiceLanguage.MandarinChinese_Des, Value = VbeeVoiceLanguage.MandarinChinese}
            };
            return vBeeLanguageSelect;
        }

        public static List<ComboboxVbeeModel> VbeeVoiceTemplate()
        {
            List<ComboboxVbeeModel> giongDocVbee = new List<ComboboxVbeeModel> {
                // Vietnam
                new ComboboxVbeeModel{ Display = VbeeVoicecode.NgocHuyen_Des, Value = VbeeVoicecode.NgocHuyen, Language = VbeeVoiceLanguage.VietNam},
                new ComboboxVbeeModel{ Display = VbeeVoicecode.MaiPhuong_Des, Value = VbeeVoicecode.MaiPhuong, Language = VbeeVoiceLanguage.VietNam},
                new ComboboxVbeeModel{ Display = VbeeVoicecode.LanTrinh_Des, Value = VbeeVoicecode.LanTrinh, Language = VbeeVoiceLanguage.VietNam},
                new ComboboxVbeeModel{ Display = VbeeVoicecode.HuongGiang_Des, Value = VbeeVoicecode.HuongGiang, Language = VbeeVoiceLanguage.VietNam},
                new ComboboxVbeeModel{ Display = VbeeVoicecode.ThaoTrinh_Des, Value = VbeeVoicecode.ThaoTrinh, Language = VbeeVoiceLanguage.VietNam},
                new ComboboxVbeeModel{ Display = VbeeVoicecode.TrungKien_Des, Value = VbeeVoicecode.TrungKien, Language = VbeeVoiceLanguage.VietNam},
                new ComboboxVbeeModel{ Display = VbeeVoicecode.DuyPhuong_Des, Value = VbeeVoicecode.DuyPhuong, Language = VbeeVoiceLanguage.VietNam},
                new ComboboxVbeeModel{ Display = VbeeVoicecode.MinhHoang_Des, Value = VbeeVoicecode.MinhHoang, Language = VbeeVoiceLanguage.VietNam},
                new ComboboxVbeeModel{ Display = VbeeVoicecode.ManhDung_Des, Value = VbeeVoicecode.ManhDung, Language = VbeeVoiceLanguage.VietNam},

                //German
                new ComboboxVbeeModel{ Display = VbeeVoicecode.Brune_Des, Value = VbeeVoicecode.Brune, Language = VbeeVoiceLanguage.German},
                new ComboboxVbeeModel{ Display = VbeeVoicecode.Brunhilda_Des, Value = VbeeVoicecode.Brunhilda, Language = VbeeVoiceLanguage.German},
                new ComboboxVbeeModel{ Display = VbeeVoicecode.Berrin_Des, Value = VbeeVoicecode.Berrin, Language = VbeeVoiceLanguage.German},
                new ComboboxVbeeModel{ Display = VbeeVoicecode.Bias_Des, Value = VbeeVoicecode.Bias, Language = VbeeVoiceLanguage.German},
                new ComboboxVbeeModel{ Display = VbeeVoicecode.Bertha_Des, Value = VbeeVoicecode.Bertha, Language = VbeeVoiceLanguage.German},
                new ComboboxVbeeModel{ Display = VbeeVoicecode.Bill_Des, Value = VbeeVoicecode.Bill, Language = VbeeVoiceLanguage.German},

                // Korean
                new ComboboxVbeeModel{ Display = VbeeVoicecode.Moon_Des, Value = VbeeVoicecode.Moon, Language = VbeeVoiceLanguage.Korean},
                new ComboboxVbeeModel{ Display = VbeeVoicecode.Emils_Des, Value = VbeeVoicecode.Emils, Language = VbeeVoiceLanguage.Korean},
                new ComboboxVbeeModel{ Display = VbeeVoicecode.Nadia_Des, Value = VbeeVoicecode.Nadia, Language = VbeeVoiceLanguage.Korean},
                new ComboboxVbeeModel{ Display = VbeeVoicecode.Alan_Des, Value = VbeeVoicecode.Alan, Language = VbeeVoiceLanguage.Korean},

                // Chinese (Hong Kong)
                new ComboboxVbeeModel{ Display = VbeeVoicecode.Zhusha_Des, Value = VbeeVoicecode.Zhusha, Language = VbeeVoiceLanguage.ChineseHK},
                new ComboboxVbeeModel{ Display = VbeeVoicecode.HaoXuan_Des, Value = VbeeVoicecode.HaoXuan, Language = VbeeVoiceLanguage.ChineseHK},
                new ComboboxVbeeModel{ Display = VbeeVoicecode.JinYi_Des, Value = VbeeVoicecode.JinYi, Language = VbeeVoiceLanguage.ChineseHK},
                new ComboboxVbeeModel{ Display = VbeeVoicecode.YunXi_Des, Value = VbeeVoicecode.YunXi, Language = VbeeVoiceLanguage.ChineseHK},

                // Russian (Russia)
                new ComboboxVbeeModel{ Display = VbeeVoicecode.Zaur_Des, Value = VbeeVoicecode.Zaur, Language = VbeeVoiceLanguage.Russian},
                new ComboboxVbeeModel{ Display = VbeeVoicecode.Leposava_Des, Value = VbeeVoicecode.Leposava, Language = VbeeVoiceLanguage.Russian},
                new ComboboxVbeeModel{ Display = VbeeVoicecode.Monika_Des, Value = VbeeVoicecode.Monika, Language = VbeeVoiceLanguage.Russian},
                new ComboboxVbeeModel{ Display = VbeeVoicecode.Adoncia_Des, Value = VbeeVoicecode.Adoncia, Language = VbeeVoiceLanguage.Russian},
                new ComboboxVbeeModel{ Display = VbeeVoicecode.Agustin_Des, Value = VbeeVoicecode.Agustin, Language = VbeeVoiceLanguage.Russian},

                // Japanese (Japan)
                new ComboboxVbeeModel{ Display = VbeeVoicecode.Akemi_Des, Value = VbeeVoicecode.Akemi, Language = VbeeVoiceLanguage.Japanese},
                new ComboboxVbeeModel{ Display = VbeeVoicecode.Aas_Des, Value = VbeeVoicecode.Aas, Language = VbeeVoiceLanguage.Japanese},
                new ComboboxVbeeModel{ Display = VbeeVoicecode.Bali_Des, Value = VbeeVoicecode.Bali, Language = VbeeVoiceLanguage.Japanese},
                new ComboboxVbeeModel{ Display = VbeeVoicecode.Anu_Des, Value = VbeeVoicecode.Anu, Language = VbeeVoiceLanguage.Japanese},

                // French (France)
                new ComboboxVbeeModel{ Display = VbeeVoicecode.Adalene_Des, Value = VbeeVoicecode.Adalene, Language = VbeeVoiceLanguage.French},
                new ComboboxVbeeModel{ Display = VbeeVoicecode.Adrien_Des, Value = VbeeVoicecode.Adrien, Language = VbeeVoiceLanguage.French},
                new ComboboxVbeeModel{ Display = VbeeVoicecode.Adalicia_Des, Value = VbeeVoicecode.Adalicia, Language = VbeeVoiceLanguage.French},
                new ComboboxVbeeModel{ Display = VbeeVoicecode.Advent_Des, Value = VbeeVoicecode.Advent, Language = VbeeVoiceLanguage.French},
                new ComboboxVbeeModel{ Display = VbeeVoicecode.Adalie_Des, Value = VbeeVoicecode.Adalie, Language = VbeeVoiceLanguage.French},

                // French (Canada)
                new ComboboxVbeeModel{ Display = VbeeVoicecode.Daphne_Des, Value = VbeeVoicecode.Daphne, Language = VbeeVoiceLanguage.FrenchCA},
                new ComboboxVbeeModel{ Display = VbeeVoicecode.Antoine_Des, Value = VbeeVoicecode.Antoine, Language = VbeeVoiceLanguage.FrenchCA},
                new ComboboxVbeeModel{ Display = VbeeVoicecode.Elisaac_Des, Value = VbeeVoicecode.Elisaac, Language = VbeeVoiceLanguage.FrenchCA},
                new ComboboxVbeeModel{ Display = VbeeVoicecode.Abella_Des, Value = VbeeVoicecode.Abella, Language = VbeeVoiceLanguage.FrenchCA},

                // English (British)
                new ComboboxVbeeModel{ Display = VbeeVoicecode.John_Des, Value = VbeeVoicecode.John, Language = VbeeVoiceLanguage.EnglishBritish},
                new ComboboxVbeeModel{ Display = VbeeVoicecode.Anna_Des, Value = VbeeVoicecode.Anna, Language = VbeeVoiceLanguage.EnglishBritish},

                // English (UK)
                new ComboboxVbeeModel{ Display = VbeeVoicecode.Laura_Des, Value = VbeeVoicecode.Laura, Language = VbeeVoiceLanguage.EnglishUK},
                new ComboboxVbeeModel{ Display = VbeeVoicecode.Brian_Des, Value = VbeeVoicecode.Brian, Language = VbeeVoiceLanguage.EnglishUK},
                new ComboboxVbeeModel{ Display = VbeeVoicecode.Rebecca_Des, Value = VbeeVoicecode.Rebecca, Language = VbeeVoiceLanguage.EnglishUK},
                new ComboboxVbeeModel{ Display = VbeeVoicecode.Christopher_Des, Value = VbeeVoicecode.Christopher, Language = VbeeVoiceLanguage.EnglishUK},
                new ComboboxVbeeModel{ Display = VbeeVoicecode.Sarah_Des, Value = VbeeVoicecode.Sarah, Language = VbeeVoiceLanguage.EnglishUK},
                new ComboboxVbeeModel{ Display = VbeeVoicecode.Emily_Des, Value = VbeeVoicecode.Emily, Language = VbeeVoiceLanguage.EnglishUK},
                new ComboboxVbeeModel{ Display = VbeeVoicecode.James_Des, Value = VbeeVoicecode.James, Language = VbeeVoiceLanguage.EnglishUK},
                new ComboboxVbeeModel{ Display = VbeeVoicecode.Jennifer_Des, Value = VbeeVoicecode.Jennifer, Language = VbeeVoiceLanguage.EnglishUK},
                new ComboboxVbeeModel{ Display = VbeeVoicecode.Robert_Des, Value = VbeeVoicecode.Robert, Language = VbeeVoiceLanguage.EnglishUK},
                new ComboboxVbeeModel{ Display = VbeeVoicecode.Mary_Des, Value = VbeeVoicecode.Mary, Language = VbeeVoiceLanguage.EnglishUK},

                // English (US)
                new ComboboxVbeeModel{ Display = VbeeVoicecode.Maddie_Des, Value = VbeeVoicecode.Maddie, Language = VbeeVoiceLanguage.EnglishUS},
                new ComboboxVbeeModel{ Display = VbeeVoicecode.LucasStandard_Des, Value = VbeeVoicecode.LucasStandard, Language = VbeeVoiceLanguage.EnglishUS},
                new ComboboxVbeeModel{ Display = VbeeVoicecode.OliviaStandard_Des, Value = VbeeVoicecode.OliviaStandard, Language = VbeeVoiceLanguage.EnglishUS},
                new ComboboxVbeeModel{ Display = VbeeVoicecode.LucasPremium_Des, Value = VbeeVoicecode.LucasPremium, Language = VbeeVoiceLanguage.EnglishUS},
                new ComboboxVbeeModel{ Display = VbeeVoicecode.OliviaPremium_Des, Value = VbeeVoicecode.OliviaPremium, Language = VbeeVoiceLanguage.EnglishUS},

                // Trung Quốc (Phổn thể)
                new ComboboxVbeeModel{ Display = VbeeVoicecode.QingYa_Des, Value = VbeeVoicecode.QingYa, Language = VbeeVoiceLanguage.MandarinChinese},
                new ComboboxVbeeModel{ Display = VbeeVoicecode.JunLang_Des, Value = VbeeVoicecode.JunLang, Language = VbeeVoiceLanguage.MandarinChinese},
                new ComboboxVbeeModel{ Display = VbeeVoicecode.YiXuan_Des, Value = VbeeVoicecode.YiXuan, Language = VbeeVoiceLanguage.MandarinChinese},
                new ComboboxVbeeModel{ Display = VbeeVoicecode.WanTong_Des, Value = VbeeVoicecode.WanTong, Language = VbeeVoiceLanguage.MandarinChinese},
                new ComboboxVbeeModel{ Display = VbeeVoicecode.Frida_Des, Value = VbeeVoicecode.Frida, Language = VbeeVoiceLanguage.MandarinChinese},
                new ComboboxVbeeModel{ Display = VbeeVoicecode.Edvard_Des, Value = VbeeVoicecode.Edvard, Language = VbeeVoiceLanguage.MandarinChinese},
                new ComboboxVbeeModel{ Display = VbeeVoicecode.Nikita_Des, Value = VbeeVoicecode.Nikita, Language = VbeeVoiceLanguage.MandarinChinese}
            };
            return giongDocVbee;
        }
    }
}
