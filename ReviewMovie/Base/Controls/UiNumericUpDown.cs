using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using ReviewMovie.Base.Controls.Common;

namespace ReviewMovie.Base.Controls
{
    [DefaultEvent(nameof(ValueChanged))]
    public class UiNumericUpDown : UserControl, ISupportInitialize
    {
        private readonly NumericUpDown _numeric;
        private bool _focused;

        private Color _backgroundColor = ThemeManager.Current.SurfaceColor;
        private Color _textColor = ThemeManager.Current.TextPrimary;
        private Color _buttonColor = ThemeManager.Current.SurfaceColor;
        private Color _buttonHoverColor = ThemeManager.Current.Hover;
        private Color _buttonIconColor = ThemeManager.Current.TextSecondary;

        private Color _borderColor = ThemeManager.Current.Border;
        private Color _borderFocusColor = ThemeManager.Current.BorderFocus;
        private int _borderSize = 1;
        private int _borderRadius = 4;

        public event EventHandler ValueChanged;

        public UiNumericUpDown()
        {
            BackColor = Color.Transparent;
            DoubleBuffered = true;

            _numeric = new NumericUpDown
            {
                BorderStyle = BorderStyle.None,
                Location = new Point(10, 8),
                Width = 80,
                TextAlign = HorizontalAlignment.Center
            };

            Controls.Add(_numeric);
            UiHelpers.EnableSmoothPainting(this);

            Size = new Size(90, 30);
            Padding = new Padding(10, 6, 10, 6);

            _numeric.Enter += (s, e) => { _focused = true; Invalidate(); };
            _numeric.Leave += (s, e) => { _focused = false; Invalidate(); };
            _numeric.ValueChanged += (s, e) => ValueChanged?.Invoke(this, e);

            ApplyThemeToInner();
            LayoutChildren();
        }

        // Designer compatibility (FormMain.Designer.cs uses BeginInit/EndInit pattern)
        public void BeginInit()
        {
            // no-op
        }

        public void EndInit()
        {
            // ensure layout after designer sets properties
            ApplyThemeToInner();
            LayoutChildren();
            Invalidate();
        }

        private void ApplyThemeToInner()
        {
            _numeric.BackColor = _backgroundColor;
            _numeric.ForeColor = _textColor;
            _numeric.Font = Font;
            UpdateInnerButtonColors();
        }

        private void UpdateInnerButtonColors()
        {
            // WinForms NumericUpDown contains an UpDownButtons child.
            if (_numeric.Controls.Count <= 0) return;
            var buttons = _numeric.Controls[0];
            buttons.BackColor = _buttonColor;
            buttons.ForeColor = _buttonIconColor;

            // Hover is not directly supported; we keep properties for API completeness.
        }

        private void LayoutChildren()
        {
            int innerW = Math.Max(0, Width - Padding.Horizontal);

            // If the designer sets a small Height but keeps large vertical Padding
            // (common in legacy forms), ensure the inner NumericUpDown still has
            // a usable height and stays vertically centered.
            int requestedInnerH = Height - Padding.Vertical;
            int innerH = Math.Max(18, requestedInnerH);
            if (innerH > Height) innerH = Height;

            int x = Padding.Left;
            int y = Math.Max(0, (Height - innerH) / 2);

            _numeric.Location = new Point(x, y);
            _numeric.Size = new Size(innerW, innerH);
        }

        [Category("Colors")]
        public Color BackgroundColor { get => _backgroundColor; set { _backgroundColor = value; ApplyThemeToInner(); Invalidate(); } }

        [Category("Colors")]
        public Color TextColor { get => _textColor; set { _textColor = value; ApplyThemeToInner(); Invalidate(); } }

        [Category("Colors")]
        public Color ButtonColor { get => _buttonColor; set { _buttonColor = value; ApplyThemeToInner(); Invalidate(); } }

        [Category("Colors")]
        public Color ButtonHoverColor { get => _buttonHoverColor; set { _buttonHoverColor = value; Invalidate(); } }

        [Category("Colors")]
        public Color ButtonIconColor { get => _buttonIconColor; set { _buttonIconColor = value; ApplyThemeToInner(); Invalidate(); } }

        [Category("Border")]
        public Color BorderColor { get => _borderColor; set { _borderColor = value; Invalidate(); } }

        [Category("Border")]
        public Color BorderFocusColor { get => _borderFocusColor; set { _borderFocusColor = value; Invalidate(); } }

        [Category("Border")]
        public int BorderSize { get => _borderSize; set { _borderSize = Math.Max(0, value); Invalidate(); } }

        [Category("Border")]
        public int BorderRadius
        {
            get => _borderRadius;
            set
            {
                _borderRadius = Math.Max(0, value);
                UiHelpers.ApplyRoundRegion(this, _borderRadius);
                Invalidate();
            }
        }

        // ---- Forward NumericUpDown API (Designer-safe) ----
        [Browsable(false)]
        public decimal Value { get => _numeric.Value; set => _numeric.Value = value; }

        [Category("Data")]
        public decimal Minimum { get => _numeric.Minimum; set => _numeric.Minimum = value; }

        [Category("Data")]
        public decimal Maximum { get => _numeric.Maximum; set => _numeric.Maximum = value; }

        [Category("Data")]
        public decimal Increment { get => _numeric.Increment; set => _numeric.Increment = value; }

        [Category("Data")]
        public int DecimalPlaces { get => _numeric.DecimalPlaces; set => _numeric.DecimalPlaces = value; }

        [Category("Layout")]
        public HorizontalAlignment TextAlign { get => _numeric.TextAlign; set => _numeric.TextAlign = value; }

        public NumericUpDown InnerNumeric => _numeric;

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            ApplyThemeToInner();
            LayoutChildren();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            UiHelpers.ApplyRoundRegion(this, _borderRadius);
            LayoutChildren();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // we fully paint ourselves
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (e == null) return;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            var rect = new Rectangle(0, 0, Width - 1, Height - 1);
            using (var path = UiHelpers.CreateRoundedRectPath(rect, _borderRadius))
            using (var fill = new SolidBrush(_backgroundColor))
            {
                e.Graphics.FillPath(fill, path);
            }

            var border = _focused ? _borderFocusColor : _borderColor;
            if (_borderSize > 0)
            {
                using (var pen = new Pen(border, _borderSize))
                {
                    pen.Alignment = PenAlignment.Inset;
                    using (var path = UiHelpers.CreateRoundedRectPath(rect, _borderRadius))
                    {
                        e.Graphics.DrawPath(pen, path);
                    }
                }
            }
        }
    }
}

