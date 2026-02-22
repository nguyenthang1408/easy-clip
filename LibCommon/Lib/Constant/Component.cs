using LibCommon.Lib.Localization;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Lib
{
    public static class EffectName
    {
        public const string EffectRandom_Des = "Random";
        public const string EffectRandom_Val = nameof(EffectTypeSelect.RandomAll);

        public const string EffectRandomInAndOut_Des = "Random Zoom (In & Out)";
        public const string EffectRandomInAndOut_Val = nameof(EffectTypeSelect.RandomInOut);

        public const string EffectRandomMove_Des = "Random Move (Left | Right)";
        public const string EffectRandomMove_Val = nameof(EffectTypeSelect.RandomMove);

        public static string EffectZoomIn_Des => LibLocalizer.Get("Lib_EffectZoomIn");
        public const string EffectZoomIn_Val = nameof(EffectTypeSelect.ZoomIn);

        public static string EffectZoomOut_Des => LibLocalizer.Get("Lib_EffectZoomOut");
        public const string EffectZoomOut_Val = nameof(EffectTypeSelect.ZoomOut);

        public static string EffectMoveX_Des => LibLocalizer.Get("Lib_EffectMoveVertical");
        public const string EffectMoveX_Val = nameof(EffectTypeSelect.MoveX);

        public static string EffectMoveY_Des => LibLocalizer.Get("Lib_EffectMoveHorizontal");
        public const string EffectMoveY_Val = nameof(EffectTypeSelect.MoveY);

    }
    public static class ComboboxEffectType
    {
        public static List<ComboboxModel> EffectTypeTemplate()
        {
            List<ComboboxModel> value = new List<ComboboxModel> {
                new ComboboxModel{ Display = EffectName.EffectRandom_Des, Value = EffectName.EffectRandom_Val},
                new ComboboxModel{ Display = EffectName.EffectRandomInAndOut_Des, Value = EffectName.EffectRandomInAndOut_Val},
                new ComboboxModel{ Display = EffectName.EffectRandomMove_Des, Value = EffectName.EffectRandomMove_Val},
                new ComboboxModel{ Display = EffectName.EffectZoomIn_Des, Value = EffectName.EffectZoomIn_Val},
                new ComboboxModel{ Display = EffectName.EffectZoomOut_Des, Value = EffectName.EffectZoomOut_Val},
                new ComboboxModel{ Display = EffectName.EffectMoveX_Des, Value = EffectName.EffectMoveX_Val},
                new ComboboxModel{ Display = EffectName.EffectMoveY_Des, Value = EffectName.EffectMoveY_Val}
            };
            return value;
        }
    }

    public static class ModeName
    {
        public const string ShortType = "Short";
        public const string WideType = "Wide";

        public const string Mode_ScaleAll_Des = "Scale All";
        public const string Mode_ScaleAll_Val = nameof(ModeTypeSelect.ScaleAll);

        public const string Mode_InputShort_Origin_Des = "InputShort Origin";
        public const string Mode_InputShort_Origin_Val = nameof(ModeTypeSelect.InputShortOrigin);

        public const string Mode_InputWide_Special_Des = "InputWide Special (Beta)";
        public const string Mode_InputWide_Special_Val = nameof(ModeTypeSelect.InputWideSpecial);
    }
    public static class ComboboxMode
    {
        public static List<ComboboxCmodeModel> ModeTypeTemplate()
        {
            List<ComboboxCmodeModel> value = new List<ComboboxCmodeModel> {
                // Video short
                new ComboboxCmodeModel{ Display = ModeName.Mode_ScaleAll_Des, Value = ModeName.Mode_ScaleAll_Val, Type = ModeName.ShortType},
                new ComboboxCmodeModel{ Display = ModeName.Mode_InputWide_Special_Des, Value = ModeName.Mode_InputWide_Special_Val, Type = ModeName.ShortType},

                // Video wide
                new ComboboxCmodeModel{ Display = ModeName.Mode_ScaleAll_Des, Value = ModeName.Mode_ScaleAll_Val, Type = ModeName.WideType},
                new ComboboxCmodeModel{ Display = ModeName.Mode_InputShort_Origin_Des, Value = ModeName.Mode_InputShort_Origin_Val, Type = ModeName.WideType}
            };
            return value;
           
        }
    }

    public static class ZoomRatiotName
    {
        public const string ZoomRatio0_Des = "0%";
        public const string ZoomRatio0_Val = "1.001";

        public const string ZoomRatio10_Des = "10%";
        public const string ZoomRatio10_Val = "1.1";

        public static string ZoomRatio25_Des => LibLocalizer.Get("Lib_Zoom25Short");
        public const string ZoomRatio25_Val = "1.25";

        public const string ZoomRatio50_Des = "50%";
        public const string ZoomRatio50_Val = "1.5";

        public static string ZoomRatio75_Des => LibLocalizer.Get("Lib_Zoom75Normal");
        public const string ZoomRatio75_Val = "1.75";

        public const string ZoomRatio100_Des = "100%";
        public const string ZoomRatio100_Val = "2";

        public const string ZoomRatio125_Des = "125%";
        public const string ZoomRatio125_Val = "2.25";

        public const string ZoomRatio150_Des = "150%";
        public const string ZoomRatio150_Val = "2.50";
    }
    public static class ComboboxZoomRatio
    {
        public static List<ComboboxModel> ZoomRatioTemplate()
        {
            List<ComboboxModel> value = new List<ComboboxModel> {
                new ComboboxModel{ Display = ZoomRatiotName.ZoomRatio0_Des, Value = ZoomRatiotName.ZoomRatio0_Val},
                new ComboboxModel{ Display = ZoomRatiotName.ZoomRatio10_Des, Value = ZoomRatiotName.ZoomRatio10_Val},
                new ComboboxModel{ Display = ZoomRatiotName.ZoomRatio25_Des, Value = ZoomRatiotName.ZoomRatio25_Val},
                new ComboboxModel{ Display = ZoomRatiotName.ZoomRatio50_Des, Value = ZoomRatiotName.ZoomRatio50_Val},
                new ComboboxModel{ Display = ZoomRatiotName.ZoomRatio75_Des, Value = ZoomRatiotName.ZoomRatio75_Val},
                new ComboboxModel{ Display = ZoomRatiotName.ZoomRatio100_Des, Value = ZoomRatiotName.ZoomRatio100_Val},
                new ComboboxModel{ Display = ZoomRatiotName.ZoomRatio125_Des, Value = ZoomRatiotName.ZoomRatio125_Val},
                new ComboboxModel{ Display = ZoomRatiotName.ZoomRatio150_Des, Value = ZoomRatiotName.ZoomRatio150_Val}
            };
            return value;
        }
    }

    public static class ZoomQualitytName
    {
        public static string ZoomQuality_Low_Des => LibLocalizer.IsEnglish ? "Low" : "Thấp";
        public const string ZoomQuality_Low_Val = "3000";

        public static string ZoomQuality_Normal_Des => LibLocalizer.IsEnglish ? "Normal" : "Bình thường";
        public const string ZoomQuality_Normal_Val = "4000";

        public static string ZoomQuality_Medium_Des => LibLocalizer.IsEnglish ? "Medium" : "Trung bình";
        public const string ZoomQuality_Medium_Val = "6000";

        public static string ZoomQuality_High_Des => LibLocalizer.IsEnglish ? "High" : "Cao";
        public const string ZoomQuality_High_Val = "8000";

    }
    public static class ComboboxZoomQuality
    {
        public static List<ComboboxModel> ZoomQualityTemplate()
        {
            List<ComboboxModel> value = new List<ComboboxModel> {
                new ComboboxModel{ Display = ZoomQualitytName.ZoomQuality_Low_Des, Value = ZoomQualitytName.ZoomQuality_Low_Val},
                new ComboboxModel{ Display = ZoomQualitytName.ZoomQuality_Normal_Des, Value = ZoomQualitytName.ZoomQuality_Normal_Val},
                new ComboboxModel{ Display = ZoomQualitytName.ZoomQuality_Medium_Des, Value = ZoomQualitytName.ZoomQuality_Medium_Val},
                new ComboboxModel{ Display = ZoomQualitytName.ZoomQuality_High_Des, Value = ZoomQualitytName.ZoomQuality_High_Val}
            };
            return value;
        }
    }
}
