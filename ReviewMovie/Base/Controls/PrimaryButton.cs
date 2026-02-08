using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ReviewMovie.Base.Controls
{
    public class PrimaryButton : Button
    {
        private Color _fillColor = UiTheme.Accent;
        private Color _hoverFillColor = UiTheme.AccentHover;
        private Color _pressedFillColor = UiTheme.AccentPressed;
        private int _cornerRadius = UiTheme.ButtonRadius;

        public PrimaryButton()
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
            BackColor = _fillColor;
            ForeColor = Color.White;
        }

        [Category("Appearance")]
        public Color FillColor
        {
            get => _fillColor;
            set
            {
                _fillColor = value;
                BackColor = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        public Color HoverFillColor
        {
            get => _hoverFillColor;
            set => _hoverFillColor = value;
        }

        [Category("Appearance")]
        public Color PressedFillColor
        {
            get => _pressedFillColor;
            set => _pressedFillColor = value;
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

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            if (Enabled) BackColor = _hoverFillColor;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (Enabled) BackColor = _fillColor;
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);
            if (Enabled && mevent.Button == MouseButtons.Left) BackColor = _pressedFillColor;
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            if (!Enabled) return;
            BackColor = ClientRectangle.Contains(mevent.Location) ? _hoverFillColor : _fillColor;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // Prevent default background to reduce jagged edges.
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

