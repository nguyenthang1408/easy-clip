using LibCommon.Lib.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public static class EffectConfigName
    {
        public static string DEFAULT_Des => LibLocalizer.Get("Lib_ConfigDefault");
        public const string DEFAULT_Val = "default";

        public static string CUSTOM_Des => LibLocalizer.Get("Lib_ConfigCustom");
        public const string CUSTOM_Val = "custom";
    }
    public static class EffectConfig
    {
        public static List<ComboboxModel> EffectConfigTemplate()
        {
            List<ComboboxModel> value = new List<ComboboxModel> {
                new ComboboxModel{ Display = EffectConfigName.DEFAULT_Des, Value = EffectConfigName.DEFAULT_Val},
                new ComboboxModel{ Display = EffectConfigName.CUSTOM_Des, Value = EffectConfigName.CUSTOM_Val},
              
            };
            return value;
        }
    }
}
