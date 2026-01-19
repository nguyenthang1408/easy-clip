using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using ReviewMovie.Base.Controls.Common;

namespace ReviewMovie.Base.Controls
{
    public class UiTableLayoutPanel : TableLayoutPanel
    {
        private Color _backgroundColor = Color.Transparent;
        private Color _borderColor = ThemeManager.Current.Border;
        private int _borderSize = 0;
        private int _borderRadius = 0;
        private UiBorderStyle _borderStyle = UiBorderStyle.None;

        public UiTableLayoutPanel()
        {
            DoubleBuffered = true;
            UiHelpers.EnableSmoothPainting(this);
        }

        [Category("Colors")]
        public Color BackgroundColor { get => _backgroundColor; set { _backgroundColor = value; Invalidate(); } }

        [Category("Border")]
        public Color BorderColorEx { get => _borderColor; set { _borderColor = value; Invalidate(); } }

        [Category("Border")]
        public int BorderSizeEx { get => _borderSize; set { _borderSize = Math.Max(0, value); Invalidate(); } }

        [Category("Border")]
        public int BorderRadius { get => _borderRadius; set { _borderRadius = Math.Max(0, value); UiHelpers.ApplyRoundRegion(this, _borderRadius); Invalidate(); } }

        [Category("Border")]
        public UiBorderStyle BorderStyleEx { get => _borderStyle; set { _borderStyle = value; Invalidate(); } }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            UiHelpers.ApplyRoundRegion(this, _borderRadius);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (e == null) return;
            if (_backgroundColor.A == 0)
            {
                base.OnPaintBackground(e);
                return;
            }

            using (var brush = new SolidBrush(_backgroundColor))
            {
                e.Graphics.FillRectangle(brush, ClientRectangle);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (e == null) return;
            if (_borderStyle == UiBorderStyle.None || _borderSize <= 0) return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            var rect = new Rectangle(0, 0, Width - 1, Height - 1);
            using (var pen = new Pen(_borderColor, _borderSize))
            {
                pen.Alignment = PenAlignment.Inset;
                if (_borderStyle == UiBorderStyle.Dashed) pen.DashStyle = DashStyle.Dash;
                else if (_borderStyle == UiBorderStyle.Dotted) pen.DashStyle = DashStyle.Dot;

                using (var path = UiHelpers.CreateRoundedRectPath(rect, _borderRadius))
                {
                    e.Graphics.DrawPath(pen, path);
                }
            }
        }
    }
}

