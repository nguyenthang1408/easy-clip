using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using ReviewMovie.Base.Controls.Common;

namespace ReviewMovie.Base.Controls
{
    [DefaultProperty(nameof(Text))]
    public class UiLabel : Control
    {
        private Color _backgroundColor = Color.Transparent;
        private Color _textColor = ThemeManager.Current.TextPrimary;
        private Color _borderColor = Color.Transparent;
        private int _borderSize;
        private int _borderRadius;
        private UiBorderStyle _borderStyle = UiBorderStyle.None;
        private ContentAlignment _textAlign = ContentAlignment.MiddleLeft;
        private Padding _padding = new Padding(0);

        public UiLabel()
        {
            SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw |
                ControlStyles.SupportsTransparentBackColor,
                true);

            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = _textColor;
            BackColor = Color.Transparent;
            AutoSize = true;
            UpdateAutoSize();
        }

        [Category("Appearance")]
        public Color BackgroundColor
        {
            get => _backgroundColor;
            set { _backgroundColor = value; Invalidate(); }
        }

        [Category("Appearance")]
        public Color TextColor
        {
            get => _textColor;
            set { _textColor = value; ForeColor = value; Invalidate(); }
        }

        [Category("Appearance")]
        public Color BorderColor
        {
            get => _borderColor;
            set { _borderColor = value; Invalidate(); }
        }

        [Category("Appearance")]
        [DefaultValue(0)]
        public int BorderSize
        {
            get => _borderSize;
            set { _borderSize = Math.Max(0, value); Invalidate(); }
        }

        [Category("Appearance")]
        [DefaultValue(0)]
        public int BorderRadius
        {
            get => _borderRadius;
            set
            {
                _borderRadius = Math.Max(0, value);
                UiHelpers.ApplyRoundRegion(this, _borderRadius);
                Invalidate();
            }
        }

        [Category("Appearance")]
        [DefaultValue(UiBorderStyle.None)]
        public UiBorderStyle BorderStyleEx
        {
            get => _borderStyle;
            set { _borderStyle = value; Invalidate(); }
        }

        [Category("Layout")]
        public ContentAlignment TextAlign
        {
            get => _textAlign;
            set { _textAlign = value; Invalidate(); }
        }

        [Category("Layout")]
        public new Padding Padding
        {
            get => _padding;
            set { _padding = value; Invalidate(); }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            UiHelpers.ApplyRoundRegion(this, _borderRadius);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            UpdateAutoSize();
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            UpdateAutoSize();
        }

        protected override void OnAutoSizeChanged(EventArgs e)
        {
            base.OnAutoSizeChanged(e);
            UpdateAutoSize();
        }

        private void UpdateAutoSize()
        {
            if (!AutoSize || Dock != DockStyle.None) return;

            var preferred = GetPreferredSize(Size.Empty);
            if (preferred.Width <= 0 || preferred.Height <= 0) return;

            if (Size != preferred)
            {
                Size = preferred;
            }
        }

        public override Size GetPreferredSize(Size proposedSize)
        {
            string content = Text ?? string.Empty;
            Size text = TextRenderer.MeasureText(content.Length == 0 ? " " : content, Font);
            int width = Math.Max(1, text.Width + _padding.Horizontal + (_borderSize * 2));
            // Add a small vertical buffer so descenders (g, p, y, q) are not clipped
            // when controls run with AutoSize=true on different DPI/font render paths.
            int height = Math.Max(1, text.Height + _padding.Vertical + (_borderSize * 2) + 2);
            return new Size(width, height);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (e == null) return;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            UiHelpers.ClearBackground(e.Graphics, this);

            var rect = new Rectangle(0, 0, Width - 1, Height - 1);

            using (var path = UiHelpers.CreateRoundedRectPath(rect, _borderRadius))
            {
                if (_backgroundColor.A > 0)
                {
                    using (var brush = new SolidBrush(_backgroundColor))
                    {
                        e.Graphics.FillPath(brush, path);
                    }
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

            var textRect = Rectangle.Inflate(rect, -_padding.Left - _padding.Right, -_padding.Top - _padding.Bottom);
            textRect = new Rectangle(rect.Left + _padding.Left, rect.Top + _padding.Top, rect.Width - _padding.Horizontal, rect.Height - _padding.Vertical);

            // Avoid NoPadding because it can clip descenders (g, p, y, q)
            // on some fonts/sizes when controls are auto-sized.
            TextFormatFlags flags = TextFormatFlags.EndEllipsis;
            switch (_textAlign)
            {
                case ContentAlignment.TopLeft: flags |= TextFormatFlags.Top | TextFormatFlags.Left; break;
                case ContentAlignment.TopCenter: flags |= TextFormatFlags.Top | TextFormatFlags.HorizontalCenter; break;
                case ContentAlignment.TopRight: flags |= TextFormatFlags.Top | TextFormatFlags.Right; break;
                case ContentAlignment.MiddleLeft: flags |= TextFormatFlags.VerticalCenter | TextFormatFlags.Left; break;
                case ContentAlignment.MiddleCenter: flags |= TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter; break;
                case ContentAlignment.MiddleRight: flags |= TextFormatFlags.VerticalCenter | TextFormatFlags.Right; break;
                case ContentAlignment.BottomLeft: flags |= TextFormatFlags.Bottom | TextFormatFlags.Left; break;
                case ContentAlignment.BottomCenter: flags |= TextFormatFlags.Bottom | TextFormatFlags.HorizontalCenter; break;
                case ContentAlignment.BottomRight: flags |= TextFormatFlags.Bottom | TextFormatFlags.Right; break;
            }

            TextRenderer.DrawText(e.Graphics, Text ?? string.Empty, Font, textRect, _textColor, flags);
        }
    }
}

