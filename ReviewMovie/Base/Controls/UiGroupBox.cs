using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using ReviewMovie.Base.Controls.Common;

namespace ReviewMovie.Base.Controls
{
    public class UiGroupBox : GroupBox
    {
        private Color _backgroundColor = Color.Transparent;
        private Color _titleBackColor = Color.Transparent;
        private Color _titleForeColor = ThemeManager.Current.TextPrimary;
        private Color _borderColor = ThemeManager.Current.Border;
        private int _borderSize = 1;
        private int _borderRadius = 10;
        private UiBorderStyle _borderStyle = UiBorderStyle.Solid;
        private bool _shadowEnabled;
        private Color _shadowColor = Color.FromArgb(55, 38, 27, 92);
        private int _shadowDepth = 4;

        private Font _titleFont;

        public UiGroupBox()
        {
            SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw |
                ControlStyles.SupportsTransparentBackColor,
                true);
            _titleFont = new Font(Font, FontStyle.Bold);
        }

        [Category("Colors")]
        public Color BackgroundColor { get => _backgroundColor; set { _backgroundColor = value; Invalidate(); } }

        [Category("Colors")]
        public Color TitleBackColor { get => _titleBackColor; set { _titleBackColor = value; Invalidate(); } }

        [Category("Colors")]
        public Color TitleForeColor { get => _titleForeColor; set { _titleForeColor = value; Invalidate(); } }

        [Category("Border")]
        public Color BorderColorEx { get => _borderColor; set { _borderColor = value; Invalidate(); } }

        [Category("Border")]
        public int BorderSizeEx { get => _borderSize; set { _borderSize = Math.Max(0, value); Invalidate(); } }

        [Category("Border")]
        public int BorderRadius { get => _borderRadius; set { _borderRadius = Math.Max(0, value); Invalidate(); } }

        [Category("Border")]
        public UiBorderStyle BorderStyleEx { get => _borderStyle; set { _borderStyle = value; Invalidate(); } }

        [Category("Title Style")]
        public Font TitleFont { get => _titleFont; set { _titleFont = value ?? _titleFont; Invalidate(); } }

        [Category("Shadow")]
        public bool ShadowEnabled { get => _shadowEnabled; set { _shadowEnabled = value; Invalidate(); } }

        [Category("Shadow")]
        public Color ShadowColor { get => _shadowColor; set { _shadowColor = value; Invalidate(); } }

        [Category("Shadow")]
        public int ShadowDepth { get => _shadowDepth; set { _shadowDepth = Math.Max(0, value); Invalidate(); } }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (e == null) return;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            UiHelpers.ClearBackground(e.Graphics, this);

            int depth = _shadowEnabled ? _shadowDepth : 0;
            var rect = new Rectangle(
                0,
                0,
                Math.Max(0, Width - 1 - depth),
                Math.Max(0, Height - 1 - depth));
            int textHeight = TextRenderer.MeasureText(Text ?? string.Empty, _titleFont).Height;
            int titlePad = 6;

            if (_shadowEnabled && _shadowDepth > 0 && _shadowColor.A > 0)
            {
                for (int i = 1; i <= _shadowDepth; i++)
                {
                    int alpha = Math.Max(6, _shadowColor.A / (i + 1));
                    var layerRect = new Rectangle(rect.X + i, rect.Y + i, rect.Width, rect.Height);
                    using (var shadowPath = UiHelpers.CreateRoundedRectPath(layerRect, _borderRadius))
                    using (var shadowBrush = new SolidBrush(Color.FromArgb(alpha, _shadowColor)))
                    {
                        e.Graphics.FillPath(shadowBrush, shadowPath);
                    }
                }
            }

            using (var path = UiHelpers.CreateRoundedRectPath(rect, _borderRadius))
            {
                if (_backgroundColor.A > 0)
                {
                    using (var b = new SolidBrush(_backgroundColor))
                        e.Graphics.FillPath(b, path);
                }

                if (_borderStyle != UiBorderStyle.None && _borderSize > 0)
                {
                    using (var pen = new Pen(_borderColor, _borderSize))
                    {
                        pen.Alignment = PenAlignment.Inset;
                        if (_borderStyle == UiBorderStyle.Dashed) pen.DashStyle = DashStyle.Dash;
                        else if (_borderStyle == UiBorderStyle.Dotted) pen.DashStyle = DashStyle.Dot;
                        e.Graphics.DrawPath(pen, path);
                    }
                }
            }

            // Title region
            var titleRect = new Rectangle(titlePad, 0, Math.Max(0, rect.Width - titlePad * 2), textHeight + titlePad);
            if (_titleBackColor.A > 0)
            {
                using (var b = new SolidBrush(_titleBackColor))
                    e.Graphics.FillRectangle(b, titleRect);
            }

            TextRenderer.DrawText(
                e.Graphics,
                Text ?? string.Empty,
                _titleFont,
                titleRect,
                _titleForeColor,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
        }
    }
}

