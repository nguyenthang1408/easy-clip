using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ReviewMovie.Base.Controls
{
    public class PillComboBox : UserControl
    {
        private readonly Label _icon;
        private readonly ComboBox _comboBox;
        private bool _initialized;

        private int _cornerRadius = UiTheme.PillRadius;
        private Color _borderColor = UiTheme.PillBorder;
        private Color _fillColor = Color.FromArgb(248, 249, 253);

        public PillComboBox()
        {
            _initialized = false;
            BackColor = Color.Transparent;

            _icon = new Label
            {
                AutoSize = false,
                Size = new Size(22, 22),
                Location = new Point(12, 15),
                Font = new Font("Segoe MDL2 Assets", 12F, FontStyle.Regular, GraphicsUnit.Point),
                ForeColor = Color.FromArgb(150, 155, 175),
                TextAlign = ContentAlignment.MiddleCenter
            };

            _comboBox = new ComboBox
            {
                FlatStyle = FlatStyle.Flat,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Location = new Point(40, 12),
                Width = 276,
                Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point),
                ForeColor = Color.FromArgb(55, 60, 80),
                BackColor = _fillColor,
                IntegralHeight = false
            };

            Controls.Add(_comboBox);
            Controls.Add(_icon);

            UiHelpers.EnableSmoothPainting(this);

            // Default size after children exist (Designer-safe)
            Size = new Size(332, 52);
            ApplyRound();
            LayoutChildren();
            _initialized = true;

            // Bubble common events
            _comboBox.SelectedIndexChanged += (s, e) => OnSelectedIndexChanged(e);
            _comboBox.TextChanged += (s, e) => OnTextChanged(e);
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
                _comboBox.BackColor = value;
                Invalidate();
            }
        }

        [Category("Behavior")]
        public ComboBoxStyle DropDownStyle
        {
            get => _comboBox.DropDownStyle;
            set => _comboBox.DropDownStyle = value;
        }

        [Category("Data")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ComboBox.ObjectCollection Items => _comboBox.Items;

        [Category("Data")]
        public object DataSource
        {
            get => _comboBox.DataSource;
            set => _comboBox.DataSource = value;
        }

        [Category("Data")]
        public string DisplayMember
        {
            get => _comboBox.DisplayMember;
            set => _comboBox.DisplayMember = value;
        }

        [Category("Data")]
        public string ValueMember
        {
            get => _comboBox.ValueMember;
            set => _comboBox.ValueMember = value;
        }

        [Browsable(false)]
        public int SelectedIndex
        {
            get => _comboBox.SelectedIndex;
            set => _comboBox.SelectedIndex = value;
        }

        [Browsable(false)]
        public object SelectedItem
        {
            get => _comboBox.SelectedItem;
            set => _comboBox.SelectedItem = value;
        }

        [Browsable(false)]
        public object SelectedValue
        {
            get => _comboBox.SelectedValue;
            set => _comboBox.SelectedValue = value;
        }

        [Browsable(true)]
        public override string Text
        {
            get => _comboBox.Text;
            set => _comboBox.Text = value ?? string.Empty;
        }

        public ComboBox InnerComboBox => _comboBox;

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (!_initialized) return;
            ApplyRound();
            LayoutChildren();
        }

        private void LayoutChildren()
        {
            if (_icon == null || _comboBox == null) return;

            _icon.Location = new Point(_icon.Left, Math.Max(0, (Height - _icon.Height) / 2));

            // ComboBox height is managed by Windows; we center it visually
            int comboY = Math.Max(0, (Height - _comboBox.Height) / 2);
            _comboBox.Location = new Point(_comboBox.Left, comboY);
            _comboBox.Width = Math.Max(0, Width - _comboBox.Left - 14);
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

