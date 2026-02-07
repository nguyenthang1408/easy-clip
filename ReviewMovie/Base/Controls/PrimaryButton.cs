using System;
using System.ComponentModel;
using System.Drawing;
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
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
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
                UiHelpers.ApplyRoundRegion(this, _cornerRadius);
                Invalidate();
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            UiHelpers.ApplyRoundRegion(this, _cornerRadius);
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
    }
}

