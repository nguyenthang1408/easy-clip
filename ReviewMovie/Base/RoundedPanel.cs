using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ReviewMovie.Base
{
    public class RoundedPanel : Panel
    {
        private int _borderRadius = 12;
        private int _borderThickness = 1;
        private Color _borderColor = Color.FromArgb(229, 231, 235); // #E5E7EB
        private Color _fillColor = Color.White;

        [DefaultValue(12)]
        public int BorderRadius
        {
            get => _borderRadius;
            set
            {
                _borderRadius = Math.Max(0, value);
                Invalidate();
            }
        }

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

        public Color BorderColor
        {
            get => _borderColor;
            set
            {
                _borderColor = value;
                Invalidate();
            }
        }

        public Color FillColor
        {
            get => _fillColor;
            set
            {
                _fillColor = value;
                Invalidate();
            }
        }

        public RoundedPanel()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint
                     | ControlStyles.OptimizedDoubleBuffer
                     | ControlStyles.ResizeRedraw
                     | ControlStyles.UserPaint, true);

            BackColor = Color.Transparent;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            var rect = ClientRectangle;
            rect.Inflate(-1, -1);

            using (var path = CreateRoundedRectPath(rect, _borderRadius))
            using (var fill = new SolidBrush(_fillColor))
            using (var pen = new Pen(_borderColor, _borderThickness))
            {
                e.Graphics.FillPath(fill, path);
                if (_borderThickness > 0)
                    e.Graphics.DrawPath(pen, path);
            }
        }

        private static GraphicsPath CreateRoundedRectPath(Rectangle bounds, int radius)
        {
            var path = new GraphicsPath();
            if (radius <= 0)
            {
                path.AddRectangle(bounds);
                path.CloseFigure();
                return path;
            }

            int d = radius * 2;
            var arc = new Rectangle(bounds.Location, new Size(d, d));

            path.AddArc(arc, 180, 90);                 // TL
            arc.X = bounds.Right - d;
            path.AddArc(arc, 270, 90);                 // TR
            arc.Y = bounds.Bottom - d;
            path.AddArc(arc, 0, 90);                   // BR
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);                  // BL

            path.CloseFigure();
            return path;
        }
    }
}

