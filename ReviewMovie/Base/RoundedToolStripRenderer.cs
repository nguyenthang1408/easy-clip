using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ReviewMovie.Base
{
    public sealed class RoundedToolStripRenderer : ToolStripProfessionalRenderer
    {
        public RoundedToolStripRenderer() : base(new RoundedColorTable())
        {
            RoundedEdges = true;
        }

        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            var r = new Rectangle(0, 0, e.ToolStrip.Width - 1, e.ToolStrip.Height - 1);
            using (var path = CreateRoundRectPath(r, 12))
            using (var bg = new SolidBrush(Color.White))
            using (var border = new Pen(Color.FromArgb(229, 231, 235)))
            {
                g.FillPath(bg, path);
                g.DrawPath(border, path);
            }
        }

        protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
        {
            if (!(e.Item is ToolStripButton btn))
            {
                base.OnRenderButtonBackground(e);
                return;
            }

            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            var r = new Rectangle(0, 0, btn.Bounds.Width - 1, btn.Bounds.Height - 1);
            r.Inflate(-2, -2);

            var baseColor = btn.BackColor;
            if (baseColor.IsEmpty || baseColor == Color.Transparent)
                baseColor = Color.White;

            var fill = baseColor;
            var border = Color.FromArgb(229, 231, 235);

            if (btn.Pressed)
            {
                fill = ControlPaint.Dark(fill, 0.08f);
                border = ControlPaint.Dark(border, 0.10f);
            }
            else if (btn.Selected)
            {
                fill = ControlPaint.Light(fill, 0.08f);
            }

            using (var path = CreateRoundRectPath(r, 10))
            using (var b = new SolidBrush(fill))
            using (var p = new Pen(border))
            {
                g.FillPath(b, path);
                g.DrawPath(p, path);
            }
        }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            // Keep existing colors but improve readability
            if (e.Item is ToolStripButton btn && (btn.ForeColor == Color.Empty || btn.ForeColor == Color.Black))
                e.TextColor = Color.FromArgb(17, 24, 39);

            base.OnRenderItemText(e);
        }

        protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
        {
            // Hide separators for a cleaner "pill button" look
            // (the original layout still keeps spacing via padding/margins)
        }

        private static GraphicsPath CreateRoundRectPath(Rectangle rect, int radius)
        {
            var path = new GraphicsPath();
            var d = radius * 2;

            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();

            return path;
        }

        private sealed class RoundedColorTable : ProfessionalColorTable
        {
            public override Color ToolStripBorder => Color.Transparent;
            public override Color ToolStripGradientBegin => Color.White;
            public override Color ToolStripGradientMiddle => Color.White;
            public override Color ToolStripGradientEnd => Color.White;
        }
    }
}

