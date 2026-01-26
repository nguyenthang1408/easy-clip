using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using ReviewMovie.Base.Controls.Common;

namespace ReviewMovie.Base.Controls
{
    public class UiCheckBox : CheckBox
    {
        private bool _hovered;

        private Color _checkedColor = ThemeManager.Current.Accent;
        private Color _uncheckedColor = ThemeManager.Current.Border;
        private Color _textColor = ThemeManager.Current.TextPrimary;
        private Color _hoverColor = ThemeManager.Current.Hover;

        private Color _boxBorderColor = ThemeManager.Current.Border;
        private int _boxBorderSize = 1;
        private int _boxSize = 16;
        private int _boxRadius = 4;
        private UiBoxStyle _boxStyle = UiBoxStyle.Rounded;
        private UiTextPosition _textPosition = UiTextPosition.Right;

        public UiCheckBox()
        {
            SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw,
                true);

            AutoSize = true;
            ForeColor = _textColor;
        }

        [Category("Colors")]
        public Color CheckedColor { get => _checkedColor; set { _checkedColor = value; Invalidate(); } }

        [Category("Colors")]
        public Color UncheckedColor { get => _uncheckedColor; set { _uncheckedColor = value; Invalidate(); } }

        [Category("Colors")]
        public Color TextColor { get => _textColor; set { _textColor = value; ForeColor = value; Invalidate(); } }

        [Category("Colors")]
        public Color HoverColor { get => _hoverColor; set { _hoverColor = value; Invalidate(); } }

        [Category("Box Style")]
        public Color BoxBorderColor { get => _boxBorderColor; set { _boxBorderColor = value; Invalidate(); } }

        [Category("Box Style")]
        public int BoxBorderSize { get => _boxBorderSize; set { _boxBorderSize = Math.Max(0, value); Invalidate(); } }

        [Category("Box Style")]
        public int BoxSize { get => _boxSize; set { _boxSize = Math.Max(10, value); Invalidate(); } }

        [Category("Box Style")]
        public int BoxRadius { get => _boxRadius; set { _boxRadius = Math.Max(0, value); Invalidate(); } }

        [Category("Box Style")]
        public UiBoxStyle BoxStyle { get => _boxStyle; set { _boxStyle = value; Invalidate(); } }

        [Category("Layout")]
        public UiTextPosition TextPosition { get => _textPosition; set { _textPosition = value; Invalidate(); } }

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
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (e == null) return;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            var rect = ClientRectangle;
            e.Graphics.Clear(BackColor);

            int box = _boxSize;
            int boxY = (rect.Height - box) / 2;
            Rectangle boxRect;
            Rectangle textRect;

            if (_textPosition == UiTextPosition.Right)
            {
                boxRect = new Rectangle(0, boxY, box, box);
                textRect = new Rectangle(box + 8, 0, rect.Width - box - 8, rect.Height);
            }
            else
            {
                boxRect = new Rectangle(rect.Width - box, boxY, box, box);
                textRect = new Rectangle(0, 0, rect.Width - box - 8, rect.Height);
            }

            // Hover background for the box area
            if (_hovered && _hoverColor.A > 0)
            {
                using (var hb = new SolidBrush(Color.FromArgb(70, _hoverColor)))
                {
                    var hoverRect = Rectangle.Inflate(boxRect, 4, 4);
                    e.Graphics.FillRectangle(hb, hoverRect);
                }
            }

            int radius = _boxStyle == UiBoxStyle.Square ? 0 : (_boxStyle == UiBoxStyle.Circle ? box / 2 : _boxRadius);

            using (var path = UiHelpers.CreateRoundedRectPath(boxRect, radius))
            {
                using (var fill = new SolidBrush(Checked ? _checkedColor : Color.Transparent))
                {
                    if (Checked) e.Graphics.FillPath(fill, path);
                }

                using (var pen = new Pen(_boxBorderColor, _boxBorderSize))
                {
                    pen.Alignment = PenAlignment.Inset;
                    e.Graphics.DrawPath(pen, path);
                }
            }

            if (Checked)
            {
                // Simple check mark
                using (var pen = new Pen(Color.White, 2f))
                {
                    pen.StartCap = LineCap.Round;
                    pen.EndCap = LineCap.Round;
                    var p1 = new Point(boxRect.Left + boxRect.Width / 4, boxRect.Top + boxRect.Height / 2);
                    var p2 = new Point(boxRect.Left + boxRect.Width / 2 - 1, boxRect.Bottom - boxRect.Height / 4);
                    var p3 = new Point(boxRect.Right - boxRect.Width / 5, boxRect.Top + boxRect.Height / 4);
                    e.Graphics.DrawLines(pen, new[] { p1, p2, p3 });
                }
            }

            TextRenderer.DrawText(
                e.Graphics,
                Text ?? string.Empty,
                Font,
                textRect,
                _textColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.EndEllipsis);
        }
    }
}

