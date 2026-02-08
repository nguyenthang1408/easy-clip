using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ReviewMovie.Base.Controls
{
    public class IconCircleButton : Button
    {
        private int _cornerRadius = UiTheme.CloseRadius;
        private Color _hoverBackColor = UiTheme.CloseHover;
        private Color _pressedBackColor = UiTheme.ClosePressed;
        private Color _normalBackColor = Color.White;

        public IconCircleButton()
        {
            SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw |
                ControlStyles.SupportsTransparentBackColor,
                true);

            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            UseVisualStyleBackColor = false;
            BackColor = _normalBackColor;
        }

        [Category("Appearance")]
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
        public Color NormalBackColor
        {
            get => _normalBackColor;
            set
            {
                _normalBackColor = value;
                BackColor = value;
            }
        }

        [Category("Appearance")]
        public Color HoverBackColor
        {
            get => _hoverBackColor;
            set => _hoverBackColor = value;
        }

        [Category("Appearance")]
        public Color PressedBackColor
        {
            get => _pressedBackColor;
            set => _pressedBackColor = value;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            BackColor = _hoverBackColor;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            BackColor = _normalBackColor;
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);
            if (mevent.Button == MouseButtons.Left) BackColor = _pressedBackColor;
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            BackColor = ClientRectangle.Contains(mevent.Location) ? _hoverBackColor : _normalBackColor;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // Avoid default background fill to reduce edge artifacts.
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (e == null) return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            UiHelpers.ClearBackground(e.Graphics, this);

            var fillRect = new Rectangle(0, 0, Width, Height);
            using (var path = UiHelpers.CreateRoundedRectPath(fillRect, _cornerRadius))
            using (var brush = new SolidBrush(BackColor))
            {
                e.Graphics.FillPath(brush, path);
            }

            if (Image != null)
            {
                var imageRect = new Rectangle(
                    (Width - Image.Width) / 2,
                    (Height - Image.Height) / 2,
                    Image.Width,
                    Image.Height);
                e.Graphics.DrawImage(Image, imageRect);
            }
            else
            {
                TextRenderer.DrawText(
                    e.Graphics,
                    Text ?? string.Empty,
                    Font,
                    fillRect,
                    ForeColor,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
            }
        }
    }
}

