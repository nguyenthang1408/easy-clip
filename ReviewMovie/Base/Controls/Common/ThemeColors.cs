using System.Drawing;

namespace ReviewMovie.Base.Controls.Common
{
    public sealed class ThemeColors
    {
        // Surface
        // App background (light gray like the screenshot)
        public Color WindowBackColor { get; set; } = Color.FromArgb(245, 246, 248);
        // Card / input background (white)
        public Color SurfaceColor { get; set; } = Color.White;

        // Text
        public Color TextPrimary { get; set; } = Color.FromArgb(33, 37, 41);
        public Color TextSecondary { get; set; } = Color.FromArgb(120, 125, 132);
        public Color TextDisabled { get; set; } = Color.FromArgb(170, 175, 182);

        // Borders
        public Color Border { get; set; } = Color.FromArgb(230, 232, 239);
        public Color BorderFocus { get; set; } = Color.FromArgb(255, 122, 0);

        // Accent
        public Color Accent { get; set; } = Color.FromArgb(255, 122, 0);
        public Color AccentHover { get; set; } = Color.FromArgb(255, 138, 26);
        public Color AccentPressed { get; set; } = Color.FromArgb(233, 108, 0);

        // States
        public Color Hover { get; set; } = Color.FromArgb(242, 243, 246);
        public Color Disabled { get; set; } = Color.FromArgb(228, 230, 235);

        // Selection (grid/list)
        public Color SelectionBackColor { get; set; } = Color.FromArgb(230, 243, 255);
        public Color SelectionForeColor { get; set; } = Color.FromArgb(33, 37, 41);
    }
}

