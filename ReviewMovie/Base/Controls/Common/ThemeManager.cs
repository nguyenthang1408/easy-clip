using System;

namespace ReviewMovie.Base.Controls.Common
{
    public static class ThemeManager
    {
        private static ThemeColors _current = new ThemeColors();

        public static event EventHandler ThemeChanged;

        public static ThemeColors Current
        {
            get => _current;
            set
            {
                if (value == null) return;
                _current = value;
                ThemeChanged?.Invoke(null, EventArgs.Empty);
            }
        }
    }
}

