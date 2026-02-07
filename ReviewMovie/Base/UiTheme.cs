using System.Drawing;

namespace ReviewMovie.Base
{
    internal static class UiTheme
    {
        // Colors
        // Align with common theme (screenshot: orange accent)
        internal static readonly Color Accent = Color.FromArgb(255, 122, 0);
        internal static readonly Color AccentHover = Color.FromArgb(255, 138, 26);
        internal static readonly Color AccentPressed = Color.FromArgb(233, 108, 0);

        internal static readonly Color PillBorder = Color.FromArgb(230, 232, 239);
        internal static readonly Color WindowBorder = Color.FromArgb(230, 232, 239);

        internal static readonly Color CloseHover = Color.FromArgb(242, 243, 246);
        internal static readonly Color ClosePressed = Color.FromArgb(230, 232, 239);

        // Radii
        internal const int WindowRadius = 18;
        internal const int PillRadius = 12;
        internal const int ButtonRadius = 12;
        internal const int CloseRadius = 15;
    }
}

