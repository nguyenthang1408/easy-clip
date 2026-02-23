using System;
using System.Collections.Generic;

namespace Lib
{
    public class ListVoiceSite
    {
        public const string T2Psoft_Des = "https://t2psoft.com/";
        public const string T2Psoft = "T2Psoft";

        public const string FptAI_Des = "https://fpt.ai/";
        public const string FptAI = "FptAI";

        public const string Vbee_Des = "https://vbee.vn/";
        public const string Vbee = "Vbee";

        public const string GoogleTTS_Des = "https://cloud.google.com/";
        public const string GoogleTTS = "Google";

        public const string Elevenlabs_Des = "https://api.elevenlabs.io/v1/";
        public const string Elevenlab = "Elevenlab";
    }
    public class AISiteSource
    {
        public AISiteSource() { }

        public static List<ComboboxModel> VoiceSiteSelectTemplate()
        {
            List<ComboboxModel> voiceSiteList = new List<ComboboxModel> {
                new ComboboxModel{ Display = ListVoiceSite.FptAI_Des, Value = ListVoiceSite.FptAI},
                new ComboboxModel{ Display = ListVoiceSite.GoogleTTS_Des, Value = ListVoiceSite.GoogleTTS},
                new ComboboxModel{ Display = ListVoiceSite.Elevenlabs_Des, Value = ListVoiceSite.Elevenlab},
                new ComboboxModel{ Display = ListVoiceSite.Vbee_Des, Value = ListVoiceSite.Vbee}
                };
            return voiceSiteList;
        }

    }
}
