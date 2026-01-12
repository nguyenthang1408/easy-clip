using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace ReviewMovie.WpfUi.Converters
{
    public sealed class StatusPillBackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var raw = (value ?? string.Empty).ToString().Trim();
            var s = raw.ToLowerInvariant();

            // green / ready
            if (s.Contains("ready") || s.Contains("converted") || s.Contains("done") || s.Contains("xong"))
                return new SolidColorBrush(Color.FromRgb(0xDC, 0xFC, 0xE7)); // #DCFCE7

            // orange / pending
            if (s.Contains("pending") || s.Contains("wait") || s.Contains("đợi") || s.Contains("dang") || s.Contains("đang"))
                return new SolidColorBrush(Color.FromRgb(0xFF, 0xED, 0xD5)); // #FFEDD5

            // red / error / missing
            if (s.Contains("error") || s.Contains("fail") || s.Contains("lỗi") || s.Contains("không"))
                return new SolidColorBrush(Color.FromRgb(0xFE, 0xE2, 0xE2)); // #FEE2E2

            // default gray
            return new SolidColorBrush(Color.FromRgb(0xF3, 0xF4, 0xF6)); // #F3F4F6
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => Binding.DoNothing;
    }
}

