using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Windows.Forms;

namespace ReviewMovie.Base
{
    internal static class UiHelpers
    {
        internal static void EnableSmoothPainting(Control control)
        {
            if (control == null) return;
            // Avoid slowing down WinForms Designer.
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;

            // Control.SetStyle is protected, so invoke via reflection (Designer-safe).
            var setStyle = typeof(Control).GetMethod(
                "SetStyle",
                BindingFlags.Instance | BindingFlags.NonPublic,
                null,
                new[] { typeof(ControlStyles), typeof(bool) },
                null);

            if (setStyle != null)
            {
                setStyle.Invoke(
                    control,
                    new object[]
                    {
                        ControlStyles.AllPaintingInWmPaint |
                        ControlStyles.OptimizedDoubleBuffer |
                        ControlStyles.ResizeRedraw |
                        ControlStyles.UserPaint |
                        ControlStyles.SupportsTransparentBackColor,
                        true
                    });
            }

            // Apply immediately
            var updateStyles = typeof(Control).GetMethod("UpdateStyles", BindingFlags.Instance | BindingFlags.NonPublic);
            updateStyles?.Invoke(control, null);
        }

        internal static void ClearBackground(Graphics g, Control control)
        {
            if (g == null || control == null) return;

            var back = control.BackColor;
            if (back.A == 0 && control.Parent != null)
            {
                back = control.Parent.BackColor;
            }

            using (var brush = new SolidBrush(back))
            {
                g.FillRectangle(brush, control.ClientRectangle);
            }
        }

        internal static GraphicsPath CreateRoundedRectPath(Rectangle rect, int radius)
        {
            var path = new GraphicsPath();
            int maxRadius = Math.Max(0, Math.Min(rect.Width, rect.Height) / 2);
            if (radius > maxRadius) radius = maxRadius;
            if (radius <= 0)
            {
                path.AddRectangle(rect);
                path.CloseFigure();
                return path;
            }

            int d = radius * 2;
            var arc = new Rectangle(rect.X, rect.Y, d, d);

            path.AddArc(arc, 180, 90);
            arc.X = rect.Right - d;
            path.AddArc(arc, 270, 90);
            arc.Y = rect.Bottom - d;
            path.AddArc(arc, 0, 90);
            arc.X = rect.X;
            path.AddArc(arc, 90, 90);
            path.CloseFigure();
            return path;
        }

        internal static void ApplyRoundRegion(Control control, int radius)
        {
            if (control == null || control.Width <= 0 || control.Height <= 0) return;

            var rect = new Rectangle(
                0,
                0,
                Math.Max(1, control.Width - 1),
                Math.Max(1, control.Height - 1));

            using (var path = CreateRoundedRectPath(rect, radius))
            {
                control.Region = new Region(path);
            }
        }

        internal static void DrawRoundedBorder(Graphics g, Rectangle rect, int radius, Color color, float thickness = 1f)
        {
            if (g == null) return;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (var path = CreateRoundedRectPath(rect, radius))
            using (var pen = new Pen(color, thickness))
            {
                g.DrawPath(pen, path);
            }
        }

        internal static void DrawPillBorder(Graphics g, Control pillPanel)
        {
            if (g == null || pillPanel == null) return;
            var rect = new Rectangle(0, 0, pillPanel.Width - 1, pillPanel.Height - 1);
            DrawRoundedBorder(g, rect, UiTheme.PillRadius, UiTheme.PillBorder, 1f);
        }

        internal static void DrawShadow(Graphics g, Rectangle rect, int radius, int depth, int maxAlpha = 18)
        {
            if (g == null) return;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            for (int i = depth; i >= 1; i--)
            {
                int alpha = (int)(maxAlpha * (i / (float)depth));
                using (var pen = new Pen(Color.FromArgb(alpha, 0, 0, 0), 1f))
                using (var path = CreateRoundedRectPath(Rectangle.Inflate(rect, i, i), radius + i))
                {
                    g.DrawPath(pen, path);
                }
            }
        }

        internal static void AlignIconLabelVertically(Label iconLabel, Control pillPanel)
        {
            if (iconLabel == null || pillPanel == null) return;

            // Keep current X, only adjust Y so it stays centered for any pill height.
            int y = (pillPanel.Height - iconLabel.Height) / 2;
            iconLabel.Location = new Point(iconLabel.Left, Math.Max(0, y));
        }
    }
}

