using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ReviewMovie.Base.Controls
{
    public class CardPanel : UserControl
    {
        private int _cornerRadius = 14;
        private Color _borderColor = Color.FromArgb(230, 232, 240);
        private Color _fillColor = Color.White;
        private bool _initialized;

        public CardPanel()
        {
            _initialized = false;
            BackColor = Color.Transparent;
            Padding = new Padding(10);

            UiHelpers.EnableSmoothPainting(this);
            Size = new Size(200, 150);

            ApplyRound();
            _initialized = true;
        }

        [Category("Appearance")]
        public int CornerRadius
        {
            get => _cornerRadius;
            set
            {
                _cornerRadius = Math.Max(0, value);
                ApplyRound();
                Invalidate();
            }
        }

        [Category("Appearance")]
        public Color BorderColor
        {
            get => _borderColor;
            set
            {
                _borderColor = value;
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

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (!_initialized) return;
            ApplyRound();
            Invalidate();
        }

        private void ApplyRound()
        {
            UiHelpers.ApplyRoundRegion(this, _cornerRadius);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (e == null) return;
            using (var brush = new SolidBrush(_fillColor))
            {
                e.Graphics.FillRectangle(brush, ClientRectangle);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            UiBorder.DrawRounded(
                e.Graphics,
                new Rectangle(0, 0, Width - 1, Height - 1),
                _cornerRadius,
                _borderColor,
                1f);
        }
    }
}

