using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ReviewMovie.Base
{
    public class RoundedButton : Button
    {
        private int _cornerRadius = 14;
        private Color _fillColor = Color.FromArgb(98, 95, 255);
        private Color _hoverFillColor = Color.FromArgb(90, 88, 245);
        private Color _pressedFillColor = Color.FromArgb(78, 76, 232);
        private Color _disabledFillColor = Color.FromArgb(195, 195, 210);
        private bool _hovered;
        private bool _pressed;

        public RoundedButton()
        {
            SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw,
                true);

            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            ForeColor = Color.White;
            BackColor = Color.Transparent;
        }

        [Category("Appearance")]
        [DefaultValue(14)]
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
        public Color FillColor
        {
            get => _fillColor;
            set
            {
                _fillColor = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        public Color HoverFillColor
        {
            get => _hoverFillColor;
            set
            {
                _hoverFillColor = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        public Color PressedFillColor
        {
            get => _pressedFillColor;
            set
            {
                _pressedFillColor = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        public Color DisabledFillColor
        {
            get => _disabledFillColor;
            set
            {
                _disabledFillColor = value;
                Invalidate();
            }
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
            _pressed = true;
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            _pressed = false;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            var rect = new Rectangle(0, 0, Width - 1, Height - 1);
            Color fill = Enabled
                ? (_pressed ? _pressedFillColor : (_hovered ? _hoverFillColor : _fillColor))
                : _disabledFillColor;

            using (var path = RoundedPanel.CreateRoundedRectPath(rect, _cornerRadius))
            using (var brush = new SolidBrush(fill))
            {
                e.Graphics.FillPath(brush, path);
            }

            TextRenderer.DrawText(
                e.Graphics,
                Text,
                Font,
                rect,
                ForeColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPadding);
        }
    }
}

