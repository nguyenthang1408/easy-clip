using System.Drawing;

namespace ReviewMovie.Base.Controls.Common
{
    /// <summary>
    /// Preset styles (named + reusable) for easier maintenance.
    /// Each property returns a NEW instance to avoid shared mutations.
    /// </summary>
    public static class UiPresets
    {
        public static class TextBox
        {
            public static UiTextBoxStyle Primary => new UiTextBoxStyle
            {
                BackgroundColor = ThemeManager.Current.SurfaceColor,
                TextColor = ThemeManager.Current.TextPrimary,
                BorderColor = ThemeManager.Current.Border,
                BorderFocusColor = ThemeManager.Current.BorderFocus,
                HoverColor = ThemeManager.Current.Hover,
                BorderRadius = 12,
                BorderSize = 1,
                BorderStyle = UiBorderStyle.Solid,
                IconSize = new Size(16, 16)
            };

            public static UiTextBoxStyle Multiline => new UiTextBoxStyle
            {
                BackgroundColor = ThemeManager.Current.SurfaceColor,
                TextColor = ThemeManager.Current.TextPrimary,
                BorderColor = ThemeManager.Current.Border,
                BorderFocusColor = ThemeManager.Current.BorderFocus,
                HoverColor = ThemeManager.Current.Hover,
                BorderRadius = 12,
                BorderSize = 1,
                BorderStyle = UiBorderStyle.Solid,
                IconSize = new Size(16, 16)
            };

            public static UiTextBoxStyle Danger => new UiTextBoxStyle
            {
                BackgroundColor = ThemeManager.Current.SurfaceColor,
                TextColor = ThemeManager.Current.TextPrimary,
                BorderColor = Color.IndianRed,
                BorderFocusColor = Color.Red,
                HoverColor = ThemeManager.Current.Hover,
                BorderRadius = 12,
                BorderSize = 1,
                BorderStyle = UiBorderStyle.Solid
            };
        }

        public static class Button
        {
            public static UiButtonStyle Primary => new UiButtonStyle
            {
                BackgroundColor = ThemeManager.Current.Accent,
                HoverColor = ThemeManager.Current.AccentHover,
                PressedColor = ThemeManager.Current.AccentPressed,
                DisabledColor = ThemeManager.Current.Disabled,
                TextColor = Color.White,
                TextHoverColor = Color.White,
                BorderColor = Color.Transparent,
                BorderHoverColor = Color.Transparent,
                BorderRadius = 10,
                BorderSize = 0,
                BorderStyle = UiBorderStyle.None,
                IconSize = new Size(18, 18),
                IconPadding = 8,
                TextAlign = ContentAlignment.MiddleCenter
            };

            public static UiButtonStyle Secondary => new UiButtonStyle
            {
                BackgroundColor = ThemeManager.Current.SurfaceColor,
                HoverColor = ThemeManager.Current.Hover,
                PressedColor = ThemeManager.Current.Hover,
                DisabledColor = ThemeManager.Current.Disabled,
                TextColor = ThemeManager.Current.TextPrimary,
                TextHoverColor = ThemeManager.Current.TextPrimary,
                BorderColor = ThemeManager.Current.Border,
                BorderHoverColor = ThemeManager.Current.BorderFocus,
                BorderRadius = 10,
                BorderSize = 1,
                BorderStyle = UiBorderStyle.Solid,
                IconSize = new Size(18, 18),
                IconPadding = 8,
                TextAlign = ContentAlignment.MiddleCenter
            };
        }

        public static class CheckBox
        {
            public static UiCheckBoxStyle Default => new UiCheckBoxStyle
            {
                CheckedColor = ThemeManager.Current.Accent,
                UncheckedColor = ThemeManager.Current.Border,
                TextColor = ThemeManager.Current.TextPrimary,
                HoverColor = ThemeManager.Current.Hover,
                BoxBorderColor = ThemeManager.Current.Border,
                BoxBorderSize = 1,
                BoxSize = 16,
                BoxRadius = 4,
                BoxStyle = UiBoxStyle.Rounded,
                TextPosition = UiTextPosition.Right
            };
        }

        public static class Grid
        {
            public static UiDataGridViewStyle Default => new UiDataGridViewStyle
            {
                BackgroundColor = ThemeManager.Current.WindowBackColor,
                GridColor = ThemeManager.Current.Border,
                ForeColor = ThemeManager.Current.TextPrimary,
                HeaderBackColor = ThemeManager.Current.SurfaceColor,
                HeaderForeColor = ThemeManager.Current.TextPrimary,
                HeaderHeight = 28,
                CellBackColor = Color.White,
                CellForeColor = ThemeManager.Current.TextPrimary,
                RowHeight = 26,
                BorderColor = ThemeManager.Current.Border,
                BorderSize = 1,
                BorderRadius = 0
            };
        }

        public static class Numeric
        {
            public static UiNumericUpDownStyle Default => new UiNumericUpDownStyle
            {
                BackgroundColor = ThemeManager.Current.SurfaceColor,
                TextColor = ThemeManager.Current.TextPrimary,
                ButtonColor = ThemeManager.Current.SurfaceColor,
                ButtonHoverColor = ThemeManager.Current.Hover,
                ButtonIconColor = ThemeManager.Current.TextSecondary,
                BorderColor = ThemeManager.Current.Border,
                BorderFocusColor = ThemeManager.Current.BorderFocus,
                BorderSize = 1,
                BorderRadius = 10
            };
        }
    }
}

