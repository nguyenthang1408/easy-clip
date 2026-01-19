using System.Drawing;
using System.Windows.Forms;

namespace ReviewMovie.Base.Controls.Common
{
    public sealed class UiTextBoxStyle
    {
        public Color BackgroundColor { get; set; } = ThemeManager.Current.SurfaceColor;
        public Color TextColor { get; set; } = ThemeManager.Current.TextPrimary;
        public Color BorderColor { get; set; } = ThemeManager.Current.Border;
        public Color BorderFocusColor { get; set; } = ThemeManager.Current.BorderFocus;
        public Color HoverColor { get; set; } = ThemeManager.Current.Hover;
        public int BorderRadius { get; set; } = 16;
        public int BorderSize { get; set; } = 1;
        public UiBorderStyle BorderStyle { get; set; } = UiBorderStyle.Solid;
        public Size IconSize { get; set; } = new Size(18, 18);
    }

    public sealed class UiButtonStyle
    {
        public Color BackgroundColor { get; set; } = ThemeManager.Current.Accent;
        public Color HoverColor { get; set; } = ThemeManager.Current.AccentHover;
        public Color DisabledColor { get; set; } = ThemeManager.Current.Disabled;
        public Color TextColor { get; set; } = Color.White;
        public Color TextHoverColor { get; set; } = Color.White;
        public Color BorderColor { get; set; } = Color.Transparent;
        public Color BorderHoverColor { get; set; } = Color.Transparent;
        public int BorderSize { get; set; } = 0;
        public int BorderRadius { get; set; } = 16;
        public UiBorderStyle BorderStyle { get; set; } = UiBorderStyle.None;
        public Size IconSize { get; set; } = new Size(18, 18);
        public int IconPadding { get; set; } = 8;
        public ContentAlignment TextAlign { get; set; } = ContentAlignment.MiddleCenter;
    }

    public sealed class UiLabelStyle
    {
        public Color BackgroundColor { get; set; } = Color.Transparent;
        public Color TextColor { get; set; } = ThemeManager.Current.TextPrimary;
        public Color BorderColor { get; set; } = Color.Transparent;
        public int BorderSize { get; set; } = 0;
        public int BorderRadius { get; set; } = 0;
        public UiBorderStyle BorderStyle { get; set; } = UiBorderStyle.None;
        public ContentAlignment TextAlign { get; set; } = ContentAlignment.MiddleLeft;
        public Padding Padding { get; set; } = new Padding(0);
    }
}

