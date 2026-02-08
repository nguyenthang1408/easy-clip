using System;
using System.ComponentModel;
using System.Drawing;
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
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            FlatAppearance.BorderColor = Color.Transparent;
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
                UiHelpers.ApplyRoundRegion(this, _cornerRadius);
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
            UiHelpers.ApplyRoundRegion(this, _cornerRadius);
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
    }
}

