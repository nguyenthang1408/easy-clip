using System;
using System.Collections.Generic;

namespace Lib
{
    public class VideoProperties
    {
        public int Width { get; set; }
        public int Height { get; set; }
    }

    public static class SizeVideo
    {
        public const string Quality240_Des = "240";
        public const string Quality240_Value = "426x240";
        public const string Quality240Short_Des = "240-short";
        public const string Quality240Short_Value = "240x426";

        public const string Quality360_Des = "360";
        public const string Quality360_Value = "640x360";
        public const string Quality360Short_Des = "360-short";
        public const string Quality360Short_Value = "360x640";

        public const string Quality480_Des = "480";
        public const string Quality480_Value = "854x480";
        public const string Quality480Short_Des = "480-short";
        public const string Quality480Short_Value = "480x854";

        public const string Quality720_Des = "720";
        public const string Quality720_Value = "1280x720";
        public const string Quality720Short_Des = "720-short";
        public const string Quality720Short_Value = "720x1280";

        public const string Quality1080_Des = "1080";
        public const string Quality1080_Value = "1920x1080";
        public const string Quality1080Short_Des = "1080-short";
        public const string Quality1080Short_Value = "1080x1920";
    }

    public static class ComboboxSizeVideo
    {
        public static List<ComboboxModel> SizeVideoTemplate()
        {
            List<ComboboxModel> value = new List<ComboboxModel> {
                new ComboboxModel{ Display = SizeVideo.Quality240_Des, Value = SizeVideo.Quality240_Value},
                new ComboboxModel{ Display = SizeVideo.Quality240Short_Des, Value = SizeVideo.Quality240Short_Value},
                new ComboboxModel{ Display = SizeVideo.Quality360_Des, Value = SizeVideo.Quality360_Value},
                new ComboboxModel{ Display = SizeVideo.Quality360Short_Des, Value = SizeVideo.Quality360Short_Value},
                new ComboboxModel{ Display = SizeVideo.Quality480_Des, Value = SizeVideo.Quality480_Value},
                new ComboboxModel{ Display = SizeVideo.Quality480Short_Des, Value = SizeVideo.Quality480Short_Value},
                new ComboboxModel{ Display = SizeVideo.Quality720_Des, Value = SizeVideo.Quality720_Value},
                new ComboboxModel{ Display = SizeVideo.Quality720Short_Des, Value = SizeVideo.Quality720Short_Value},
                new ComboboxModel{ Display = SizeVideo.Quality1080_Des, Value = SizeVideo.Quality1080_Value},
                new ComboboxModel{ Display = SizeVideo.Quality1080Short_Des, Value = SizeVideo.Quality1080Short_Value}
                };
            return value;
        }
    }
}
