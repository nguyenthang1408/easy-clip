using System.Drawing;

namespace ReviewMovie.Base
{
    internal static class UiTheme
    {
        // Colors
        internal static readonly Color Accent = Color.FromArgb(120, 94, 255);
        internal static readonly Color AccentHover = Color.FromArgb(110, 86, 245);
        internal static readonly Color AccentPressed = Color.FromArgb(98, 76, 232);

        internal static readonly Color PillBorder = Color.FromArgb(232, 236, 255);
        internal static readonly Color WindowBorder = Color.FromArgb(235, 238, 245);

        internal static readonly Color CloseHover = Color.FromArgb(246, 247, 252);
        internal static readonly Color ClosePressed = Color.FromArgb(235, 236, 245);

        // Radii
        internal const int WindowRadius = 18;
        internal const int PillRadius = 16;
        internal const int ButtonRadius = 16;
        internal const int CloseRadius = 15;
    }
}

