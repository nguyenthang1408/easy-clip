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

    public sealed class UiCheckBoxStyle
    {
        public Color CheckedColor { get; set; } = ThemeManager.Current.Accent;
        public Color UncheckedColor { get; set; } = ThemeManager.Current.Border;
        public Color TextColor { get; set; } = ThemeManager.Current.TextPrimary;
        public Color HoverColor { get; set; } = ThemeManager.Current.Hover;

        public Color BoxBorderColor { get; set; } = ThemeManager.Current.Border;
        public int BoxBorderSize { get; set; } = 1;
        public int BoxSize { get; set; } = 16;
        public int BoxRadius { get; set; } = 4;
        public UiBoxStyle BoxStyle { get; set; } = UiBoxStyle.Rounded;

        public UiTextPosition TextPosition { get; set; } = UiTextPosition.Right;
    }

    public sealed class UiDataGridViewStyle
    {
        // Grid
        public Color BackgroundColor { get; set; } = ThemeManager.Current.WindowBackColor;
        public Color GridColor { get; set; } = ThemeManager.Current.Border;
        public Color ForeColor { get; set; } = ThemeManager.Current.TextPrimary;

        // Header
        public Color HeaderBackColor { get; set; } = ThemeManager.Current.SurfaceColor;
        public Color HeaderForeColor { get; set; } = ThemeManager.Current.TextPrimary;
        public Font HeaderFont { get; set; }
        public int HeaderHeight { get; set; } = 28;

        // Cell
        public Color CellBackColor { get; set; } = Color.White;
        public Color CellForeColor { get; set; } = ThemeManager.Current.TextPrimary;
        public Font CellFont { get; set; }
        public int RowHeight { get; set; } = 26;

        // Border
        public Color BorderColor { get; set; } = ThemeManager.Current.Border;
        public int BorderSize { get; set; } = 1;
        public int BorderRadius { get; set; } = 0;
    }
}

