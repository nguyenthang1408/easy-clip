using System;
using System.Drawing;
using ReviewMovie.Base.Controls;

namespace ReviewMovie.Base.Controls.Common
{
    public static class UiStyleExtensions
    {
        public static void ApplyStyle(this UiTextBox tb, UiTextBoxStyle style)
        {
            if (tb == null || style == null) return;
            tb.BackgroundColor = style.BackgroundColor;
            tb.TextColor = style.TextColor;
            tb.BorderColor = style.BorderColor;
            tb.BorderFocusColor = style.BorderFocusColor;
            tb.HoverColor = style.HoverColor;
            tb.BorderRadius = style.BorderRadius;
            tb.BorderSize = style.BorderSize;
            tb.BorderStyleEx = style.BorderStyle;
            tb.IconSize = style.IconSize;
        }

        public static void ApplyStyle(this UiButton btn, UiButtonStyle style)
        {
            if (btn == null || style == null) return;
            btn.BackgroundColor = style.BackgroundColor;
            btn.HoverColor = style.HoverColor;
            btn.DisabledColor = style.DisabledColor;
            btn.TextColor = style.TextColor;
            btn.TextHoverColor = style.TextHoverColor;
            btn.BorderColor = style.BorderColor;
            btn.BorderHoverColor = style.BorderHoverColor;
            btn.BorderSize = style.BorderSize;
            btn.BorderRadius = style.BorderRadius;
            btn.BorderStyleEx = style.BorderStyle;
            btn.IconSize = style.IconSize;
            btn.IconPadding = style.IconPadding;
            btn.TextAlign = style.TextAlign;
        }

        public static void ApplyStyle(this UiLabel lbl, UiLabelStyle style)
        {
            if (lbl == null || style == null) return;
            lbl.BackgroundColor = style.BackgroundColor;
            lbl.TextColor = style.TextColor;
            lbl.BorderColor = style.BorderColor;
            lbl.BorderSize = style.BorderSize;
            lbl.BorderRadius = style.BorderRadius;
            lbl.BorderStyleEx = style.BorderStyle;
            lbl.TextAlign = style.TextAlign;
            lbl.Padding = style.Padding;
        }

        public static void ApplyStyle(this UiCheckBox cb, UiCheckBoxStyle style)
        {
            if (cb == null || style == null) return;
            cb.CheckedColor = style.CheckedColor;
            cb.UncheckedColor = style.UncheckedColor;
            cb.TextColor = style.TextColor;
            cb.HoverColor = style.HoverColor;

            cb.BoxBorderColor = style.BoxBorderColor;
            cb.BoxBorderSize = style.BoxBorderSize;
            cb.BoxSize = style.BoxSize;
            cb.BoxRadius = style.BoxRadius;
            cb.BoxStyle = style.BoxStyle;
            cb.TextPosition = style.TextPosition;
        }

        public static void ApplyStyle(this UiDataGridView grid, UiDataGridViewStyle style)
        {
            if (grid == null || style == null) return;

            // Fonts: if preset doesn't specify, keep existing.
            if (style.HeaderFont == null)
                style.HeaderFont = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            if (style.CellFont == null)
                style.CellFont = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);

            grid.GridBackColor = style.BackgroundColor;
            grid.GridLineColor = style.GridColor;
            grid.GridForeColor = style.ForeColor;

            grid.HeaderBackColor = style.HeaderBackColor;
            grid.HeaderForeColor = style.HeaderForeColor;
            grid.HeaderFont = style.HeaderFont;
            grid.HeaderHeight = style.HeaderHeight;

            grid.CellBackColor = style.CellBackColor;
            grid.CellForeColor = style.CellForeColor;
            grid.CellFont = style.CellFont;
            grid.RowHeight = style.RowHeight;

            grid.BorderColorEx = style.BorderColor;
            grid.BorderSizeEx = style.BorderSize;
            grid.BorderRadius = style.BorderRadius;

            grid.ApplyStyles();
        }
    }
}

