using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ReviewMovie.Base.Controls
{
    public class TagButton : Button
    {
        private int _cornerRadius = 10;
        private Color _fillColor = Color.FromArgb(245, 246, 252);
        private Color _hoverFillColor = Color.FromArgb(238, 240, 248);
        private Color _pressedFillColor = Color.FromArgb(230, 232, 240);
        private Color _textColor = Color.FromArgb(55, 60, 80);

        public TagButton()
        {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            BackColor = _fillColor;
            ForeColor = _textColor;
            Padding = new Padding(10, 0, 10, 0);
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
        public Color TextColor
        {
            get => _textColor;
            set
            {
                _textColor = value;
                ForeColor = value;
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
            BackColor = _hoverFillColor;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            BackColor = _fillColor;
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);
            if (mevent.Button == MouseButtons.Left) BackColor = _pressedFillColor;
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            BackColor = ClientRectangle.Contains(mevent.Location) ? _hoverFillColor : _fillColor;
        }
    }
}

