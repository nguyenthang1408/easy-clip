using System;
using LibCommon.Lib.Localization;

namespace Lib
{
    public class FptAIVoiceLanguage
    {
        public static string VietNam_Des => LibLocalizer.IsEnglish ? "Vietnam" : "Việt Nam";
        public const string VietNam = "vi-VN";
    }
    public class FptAIVoicecode
    {
        public static string Banmai_Des => LibLocalizer.IsEnglish ? "banmai (Female, Northern)" : "banmai (Nữ Miền Bắc)";
        public const string Banmai = "banmai";

        public static string Thuminh_Des => LibLocalizer.IsEnglish ? "thuminh (Female, Northern 2)" : "thuminh (Nữ Miền Bắc 2)";
        public const string Thuminh = "thuminh";

        public static string Myan_Des => LibLocalizer.IsEnglish ? "myan (Female, Central)" : "myan (Nữ Miền Trung)";
        public const string Myan = "myan";

        public static string Ngoclam_Des => LibLocalizer.IsEnglish ? "ngoclam (Female, Central 2)" : "ngoclam (Nữ Miền Trung 2)";
        public const string Ngoclam = "ngoclam";

        public static string Linhsan_Des => LibLocalizer.IsEnglish ? "linhsan (Female, Southern)" : "linhsan (Nữ Miền Nam)";
        public const string Linhsan = "linhsan";

        public static string Lannhi_Des => LibLocalizer.IsEnglish ? "lannhi (Female, Southern 2)" : "lannhi (Nữ Miền Nam 2)";
        public const string Lannhi = "lannhi";

        public static string Leminh_Des => LibLocalizer.IsEnglish ? "leminh (Male, Northern)" : "leminh (Nam Miền Bắc)";
        public const string Leminh = "leminh";

        public static string Giahuy_Des => LibLocalizer.IsEnglish ? "giahuy (Male, Central)" : "giahuy (Nam Miền Trung)";
        public const string Giahuy = "giahuy";

        public static string Minhquang_Des => LibLocalizer.IsEnglish ? "minhquang (Male, Southern)" : "minhquang (Nam Miền Nam)";
        public const string Minhquang = "minhquang";
    }
}
