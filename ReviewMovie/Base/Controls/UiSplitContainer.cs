using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using ReviewMovie.Base.Controls.Common;

namespace ReviewMovie.Base.Controls
{
    public class UiSplitContainer : SplitContainer
    {
        private Color _splitterColor = ThemeManager.Current.Border;
        private int _borderRadius;
        private int _borderSize;
        private Color _borderColor = ThemeManager.Current.Border;

        public UiSplitContainer()
        {
            DoubleBuffered = true;
            UiHelpers.EnableSmoothPainting(this);
        }

        [Category("Colors")]
        public Color SplitterColor
        {
            get => _splitterColor;
            set { _splitterColor = value; Invalidate(); }
        }

        [Category("Border")]
        public Color BorderColorEx { get => _borderColor; set { _borderColor = value; Invalidate(); } }

        [Category("Border")]
        public int BorderSizeEx { get => _borderSize; set { _borderSize = Math.Max(0, value); Invalidate(); } }

        [Category("Border")]
        public int BorderRadius { get => _borderRadius; set { _borderRadius = Math.Max(0, value); UiHelpers.ApplyRoundRegion(this, _borderRadius); Invalidate(); } }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            UiHelpers.ApplyRoundRegion(this, _borderRadius);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (e == null) return;

            // Splitter
            var splitterRect = GetSplitterRectangle();
            if (!splitterRect.IsEmpty)
            {
                using (var b = new SolidBrush(_splitterColor))
                {
                    e.Graphics.FillRectangle(b, splitterRect);
                }
            }

            // Outer border
            if (_borderSize > 0)
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                var rect = new Rectangle(0, 0, Width - 1, Height - 1);
                using (var pen = new Pen(_borderColor, _borderSize))
                using (var path = UiHelpers.CreateRoundedRectPath(rect, _borderRadius))
                {
                    pen.Alignment = PenAlignment.Inset;
                    e.Graphics.DrawPath(pen, path);
                }
            }
        }

        private Rectangle GetSplitterRectangle()
        {
            try
            {
                if (Orientation == Orientation.Vertical)
                {
                    return new Rectangle(SplitterDistance, 0, SplitterWidth, Height);
                }
                return new Rectangle(0, SplitterDistance, Width, SplitterWidth);
            }
            catch
            {
                return Rectangle.Empty;
            }
        }
    }
}

