using System.Drawing;

namespace ReviewMovie.Base.Controls.Common
{
    public sealed class ThemeColors
    {
        // Surface
        public Color WindowBackColor { get; set; } = Color.White;
        public Color SurfaceColor { get; set; } = Color.FromArgb(248, 249, 253);

        // Text
        public Color TextPrimary { get; set; } = Color.FromArgb(55, 60, 80);
        public Color TextSecondary { get; set; } = Color.FromArgb(120, 125, 145);
        public Color TextDisabled { get; set; } = Color.FromArgb(160, 165, 185);

        // Borders
        public Color Border { get; set; } = Color.FromArgb(232, 236, 255);
        public Color BorderFocus { get; set; } = Color.FromArgb(120, 94, 255);

        // Accent
        public Color Accent { get; set; } = Color.FromArgb(120, 94, 255);
        public Color AccentHover { get; set; } = Color.FromArgb(110, 86, 245);
        public Color AccentPressed { get; set; } = Color.FromArgb(98, 76, 232);

        // States
        public Color Hover { get; set; } = Color.FromArgb(246, 247, 252);
        public Color Disabled { get; set; } = Color.FromArgb(195, 195, 210);
    }
}

