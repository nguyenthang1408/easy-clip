using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ReviewMovie.Base
{
    public class RoundedPanel : Panel
    {
        private int _cornerRadius = 16;
        private int _borderThickness = 1;
        private Color _borderColor = Color.FromArgb(227, 232, 255);
        private Color _fillColor = Color.White;

        public RoundedPanel()
        {
            SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw |
                ControlStyles.SupportsTransparentBackColor,
                true);

            BackColor = Color.Transparent;
        }

        [Category("Appearance")]
        [DefaultValue(16)]
        public int CornerRadius
        {
            get => _cornerRadius;
            set
            {
                _cornerRadius = Math.Max(0, value);
                Invalidate();
            }
        }

        [Category("Appearance")]
        [DefaultValue(1)]
        public int BorderThickness
        {
            get => _borderThickness;
            set
            {
                _borderThickness = Math.Max(0, value);
                Invalidate();
            }
        }

        [Category("Appearance")]
        public Color BorderColor
        {
            get => _borderColor;
            set
            {
                _borderColor = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        public Color FillColor
        {
            get => _fillColor;
            set
            {
                _fillColor = value;
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            var rect = new Rectangle(0, 0, Width - 1, Height - 1);

            using (var path = CreateRoundedRectPath(rect, _cornerRadius))
            using (var fill = new SolidBrush(_fillColor))
            {
                e.Graphics.FillPath(fill, path);

                if (_borderThickness > 0)
                {
                    using (var pen = new Pen(_borderColor, _borderThickness))
                    {
                        pen.Alignment = PenAlignment.Inset;
                        e.Graphics.DrawPath(pen, path);
                    }
                }
            }
        }

        public static GraphicsPath CreateRoundedRectPath(Rectangle rect, int radius)
        {
            var path = new GraphicsPath();
            if (radius <= 0)
            {
                path.AddRectangle(rect);
                path.CloseFigure();
                return path;
            }

            int d = radius * 2;
            var arc = new Rectangle(rect.X, rect.Y, d, d);

            // top-left
            path.AddArc(arc, 180, 90);
            // top-right
            arc.X = rect.Right - d;
            path.AddArc(arc, 270, 90);
            // bottom-right
            arc.Y = rect.Bottom - d;
            path.AddArc(arc, 0, 90);
            // bottom-left
            arc.X = rect.X;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }
    }
}

