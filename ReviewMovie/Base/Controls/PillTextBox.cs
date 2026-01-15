using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ReviewMovie.Base.Controls
{
    public class PillTextBox : UserControl
    {
        private readonly Label _icon;
        private readonly TextBox _textBox;

        private int _cornerRadius = UiTheme.PillRadius;
        private Color _borderColor = UiTheme.PillBorder;
        private Color _fillColor = Color.FromArgb(248, 249, 253);

        public PillTextBox()
        {
            BackColor = Color.Transparent;
            Size = new Size(332, 52);

            _icon = new Label
            {
                AutoSize = false,
                Size = new Size(22, 22),
                Location = new Point(12, 15),
                Font = new Font("Segoe MDL2 Assets", 12F, FontStyle.Regular, GraphicsUnit.Point),
                ForeColor = Color.FromArgb(150, 155, 175),
                TextAlign = ContentAlignment.MiddleCenter
            };

            _textBox = new TextBox
            {
                BorderStyle = BorderStyle.None,
                Location = new Point(42, 16),
                Size = new Size(276, 18),
                Font = new Font("Segoe UI", 11.5F, FontStyle.Regular, GraphicsUnit.Point),
                ForeColor = Color.FromArgb(55, 60, 80),
                BackColor = _fillColor
            };

            Controls.Add(_textBox);
            Controls.Add(_icon);

            UiHelpers.EnableSmoothPainting(this);

            _textBox.TextChanged += (s, e) => OnTextChanged(e);
            _textBox.KeyDown += (s, e) => OnKeyDown(e);
            _textBox.KeyPress += (s, e) => OnKeyPress(e);
            _textBox.KeyUp += (s, e) => OnKeyUp(e);
            _textBox.Enter += (s, e) => OnEnter(e);
            _textBox.Leave += (s, e) => OnLeave(e);
        }

        [Category("Appearance")]
        public string IconGlyph
        {
            get => _icon.Text;
            set => _icon.Text = value ?? string.Empty;
        }

        [Category("Appearance")]
        public Color IconColor
        {
            get => _icon.ForeColor;
            set => _icon.ForeColor = value;
        }

        [Category("Appearance")]
        public int CornerRadius
        {
            get => _cornerRadius;
            set
            {
                _cornerRadius = Math.Max(0, value);
                Invalidate();
                ApplyRound();
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
                _textBox.BackColor = value;
                Invalidate();
            }
        }

        [Category("Behavior")]
        public bool ReadOnly
        {
            get => _textBox.ReadOnly;
            set => _textBox.ReadOnly = value;
        }

        [Category("Behavior")]
        public bool UseSystemPasswordChar
        {
            get => _textBox.UseSystemPasswordChar;
            set => _textBox.UseSystemPasswordChar = value;
        }

        [Category("Behavior")]
        public int MaxLength
        {
            get => _textBox.MaxLength;
            set => _textBox.MaxLength = value;
        }

        [Browsable(true)]
        public override string Text
        {
            get => _textBox.Text;
            set => _textBox.Text = value ?? string.Empty;
        }

        public TextBox InnerTextBox => _textBox;

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            ApplyRound();
            LayoutChildren();
        }

        private void LayoutChildren()
        {
            // Vertically center icon and textbox for current height.
            _icon.Location = new Point(_icon.Left, Math.Max(0, (Height - _icon.Height) / 2));

            int textY = Math.Max(0, (Height - _textBox.Height) / 2);
            _textBox.Location = new Point(_textBox.Left, textY);

            // Stretch textbox to the right edge.
            _textBox.Width = Math.Max(0, Width - _textBox.Left - 14);
        }

        private void ApplyRound()
        {
            UiHelpers.ApplyRoundRegion(this, _cornerRadius);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (var brush = new SolidBrush(_fillColor))
            {
                e.Graphics.FillRectangle(brush, ClientRectangle);
            }

            UiBorder.DrawRounded(
                e.Graphics,
                new Rectangle(0, 0, Width - 1, Height - 1),
                _cornerRadius,
                _borderColor,
                1f);
        }
    }
}

