using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace ReviewMovie.WpfUi.Converters
{
    public sealed class StatusPillForegroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var raw = (value ?? string.Empty).ToString().Trim();
            var s = raw.ToLowerInvariant();

            if (s.Contains("ready") || s.Contains("converted") || s.Contains("done") || s.Contains("xong"))
                return new SolidColorBrush(Color.FromRgb(0x16, 0xA3, 0x4A)); // #16A34A

            if (s.Contains("pending") || s.Contains("wait") || s.Contains("đợi") || s.Contains("dang") || s.Contains("đang"))
                return new SolidColorBrush(Color.FromRgb(0xEA, 0x58, 0x0C)); // #EA580C

            if (s.Contains("error") || s.Contains("fail") || s.Contains("lỗi") || s.Contains("không"))
                return new SolidColorBrush(Color.FromRgb(0xB9, 0x1C, 0x1C)); // #B91C1C

            return new SolidColorBrush(Color.FromRgb(0x4B, 0x55, 0x63)); // #4B5563
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => Binding.DoNothing;
    }
}

