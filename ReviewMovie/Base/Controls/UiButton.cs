using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using ReviewMovie.Base.Controls.Common;

namespace ReviewMovie.Base.Controls
{
    public class UiButton : Button
    {
        private bool _hovered;
        private bool _pressed;

        private Color _backgroundColor = ThemeManager.Current.Accent;
        private Color _hoverColor = ThemeManager.Current.AccentHover;
        private Color _pressedColor = ThemeManager.Current.AccentPressed;
        private Color _disabledColor = ThemeManager.Current.Disabled;
        private Color _textColor = Color.White;
        private Color _textHoverColor = Color.White;

        private Color _borderColor = Color.Transparent;
        private Color _borderHoverColor = Color.Transparent;
        private int _borderSize;
        private int _borderRadius = 16;
        private UiBorderStyle _borderStyle = UiBorderStyle.None;

        private Image _iconImage;
        private UiIconPosition _iconPosition = UiIconPosition.Left;
        private Size _iconSize = new Size(18, 18);
        private int _iconPadding = 8;

        public UiButton()
        {
            SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw |
                ControlStyles.SupportsTransparentBackColor,
                true);

            AutoSize = false;
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            BackColor = Color.Transparent;
            ForeColor = _textColor;
        }

        [Category("Appearance")]
        public Color BackgroundColor
        {
            get => _backgroundColor;
            set { _backgroundColor = value; Invalidate(); }
        }

        [Category("Appearance")]
        public Color HoverColor
        {
            get => _hoverColor;
            set { _hoverColor = value; Invalidate(); }
        }

        [Category("Appearance")]
        public Color PressedColor
        {
            get => _pressedColor;
            set { _pressedColor = value; Invalidate(); }
        }

        [Category("Appearance")]
        public Color DisabledColor
        {
            get => _disabledColor;
            set { _disabledColor = value; Invalidate(); }
        }

        [Category("Appearance")]
        public Color TextColor
        {
            get => _textColor;
            set { _textColor = value; ForeColor = value; Invalidate(); }
        }

        [Category("Appearance")]
        public Color TextHoverColor
        {
            get => _textHoverColor;
            set { _textHoverColor = value; Invalidate(); }
        }

        [Category("Appearance")]
        public Color BorderColor
        {
            get => _borderColor;
            set { _borderColor = value; Invalidate(); }
        }

        [Category("Appearance")]
        public Color BorderHoverColor
        {
            get => _borderHoverColor;
            set { _borderHoverColor = value; Invalidate(); }
        }

        [Category("Appearance")]
        [DefaultValue(0)]
        public int BorderSize
        {
            get => _borderSize;
            set { _borderSize = Math.Max(0, value); Invalidate(); }
        }

        [Category("Appearance")]
        [DefaultValue(16)]
        public int BorderRadius
        {
            get => _borderRadius;
            set
            {
                _borderRadius = Math.Max(0, value);
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
        public Image IconImage
        {
            get => _iconImage;
            set { _iconImage = value; Invalidate(); }
        }

        [Category("Layout")]
        [DefaultValue(UiIconPosition.Left)]
        public UiIconPosition IconPosition
        {
            get => _iconPosition;
            set { _iconPosition = value; Invalidate(); }
        }

        [Category("Layout")]
        public Size IconSize
        {
            get => _iconSize;
            set { _iconSize = value.Width <= 0 || value.Height <= 0 ? new Size(18, 18) : value; Invalidate(); }
        }

        [Category("Layout")]
        [DefaultValue(8)]
        public int IconPadding
        {
            get => _iconPadding;
            set { _iconPadding = Math.Max(0, value); Invalidate(); }
        }

        [Category("Layout")]
        public ContentAlignment ImageAlignEx
        {
            get => ImageAlign;
            set { ImageAlign = value; Invalidate(); }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            _hovered = true;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _hovered = false;
            _pressed = false;
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);
            if (mevent.Button == MouseButtons.Left)
            {
                _pressed = true;
                Invalidate();
            }
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            _pressed = false;
            Invalidate();
        }

        public override Size GetPreferredSize(Size proposedSize)
        {
            if (!AutoSize && Size.Width > 0 && Size.Height > 0)
            {
                return Size;
            }

            return base.GetPreferredSize(proposedSize);
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            // Avoid default background fill (often white) that causes
            // visible artifacts around rounded corners.
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (e == null) return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            using (var bg = new SolidBrush(GetParentSurfaceColor()))
            {
                e.Graphics.FillRectangle(bg, ClientRectangle);
            }

            var fillRect = new Rectangle(0, 0, Width, Height);
            var borderRect = new Rectangle(0, 0, Width - 1, Height - 1);

            var back = Enabled
                ? (_pressed ? _pressedColor : (_hovered ? _hoverColor : _backgroundColor))
                : _disabledColor;

            using (var path = UiHelpers.CreateRoundedRectPath(fillRect, _borderRadius))
            using (var brush = new SolidBrush(back))
            {
                e.Graphics.FillPath(brush, path);
            }

            var borderColor = _hovered ? _borderHoverColor : _borderColor;
            if (_borderStyle != UiBorderStyle.None && _borderSize > 0)
            {
                using (var pen = new Pen(borderColor, _borderSize))
                {
                    pen.Alignment = PenAlignment.Inset;
                    if (_borderStyle == UiBorderStyle.Dashed) pen.DashStyle = DashStyle.Dash;
                    else if (_borderStyle == UiBorderStyle.Dotted) pen.DashStyle = DashStyle.Dot;
                    using (var path = UiHelpers.CreateRoundedRectPath(borderRect, _borderRadius))
                    {
                        e.Graphics.DrawPath(pen, path);
                    }
                }
            }

            var textColor = Enabled
                ? (_hovered ? _textHoverColor : _textColor)
                : ThemeManager.Current.TextDisabled;

            // Content layout: icon + text centered as a group.
            var contentRect = Rectangle.Inflate(borderRect, -Padding.Horizontal / 2 - 8, -Padding.Vertical / 2 - 4);
            if (contentRect.Width <= 0 || contentRect.Height <= 0) contentRect = borderRect;

            Size iconDrawSize = _iconImage == null ? Size.Empty : _iconSize;
            Size textSize = TextRenderer.MeasureText(e.Graphics, Text ?? string.Empty, Font);

            int totalW = textSize.Width + (iconDrawSize.Width > 0 ? (iconDrawSize.Width + _iconPadding) : 0);
            int startX = contentRect.Left + Math.Max(0, (contentRect.Width - totalW) / 2);
            int centerY = contentRect.Top + contentRect.Height / 2;

            Rectangle iconRect = Rectangle.Empty;
            Rectangle textRect = Rectangle.Empty;

            if (_iconImage != null && _iconPosition == UiIconPosition.Left)
            {
                iconRect = new Rectangle(startX, centerY - iconDrawSize.Height / 2, iconDrawSize.Width, iconDrawSize.Height);
                textRect = new Rectangle(iconRect.Right + _iconPadding, contentRect.Top, contentRect.Right - (iconRect.Right + _iconPadding), contentRect.Height);
            }
            else if (_iconImage != null && _iconPosition == UiIconPosition.Right)
            {
                textRect = new Rectangle(startX, contentRect.Top, textSize.Width, contentRect.Height);
                iconRect = new Rectangle(textRect.Right + _iconPadding, centerY - iconDrawSize.Height / 2, iconDrawSize.Width, iconDrawSize.Height);
            }
            else
            {
                textRect = contentRect;
            }

            if (_iconImage != null && !iconRect.IsEmpty)
            {
                e.Graphics.DrawImage(_iconImage, iconRect);
            }

            TextRenderer.DrawText(
                e.Graphics,
                Text ?? string.Empty,
                Font,
                textRect,
                textColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter | TextFormatFlags.EndEllipsis);
        }

        private Color GetParentSurfaceColor()
        {
            var current = Parent;
            while (current != null)
            {
                if (current.BackColor.A > 0) return current.BackColor;
                current = current.Parent;
            }

            return SystemColors.Control;
        }
    }
}

