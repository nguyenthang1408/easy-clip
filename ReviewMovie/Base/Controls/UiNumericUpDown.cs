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
        private readonly UpDownButtonPanel _buttonPanel;
        private bool _focused;
        private bool _layouting;

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
                AutoSize = false,
                BorderStyle = BorderStyle.None,
                Location = new Point(10, 8),
                Width = 80,
                TextAlign = HorizontalAlignment.Center
            };

            _buttonPanel = new UpDownButtonPanel();
            _buttonPanel.UpClicked += (_, __) =>
            {
                if (!_numeric.Enabled || _numeric.ReadOnly) return;
                _numeric.UpButton();
                _numeric.Focus();
            };
            _buttonPanel.DownClicked += (_, __) =>
            {
                if (!_numeric.Enabled || _numeric.ReadOnly) return;
                _numeric.DownButton();
                _numeric.Focus();
            };

            Controls.Add(_numeric);
            Controls.Add(_buttonPanel);
            UiHelpers.EnableSmoothPainting(this);

            Size = new Size(90, 30);
            Padding = new Padding(10, 6, 10, 6);

            _numeric.Enter += (s, e) => { _focused = true; Invalidate(); };
            _numeric.Leave += (s, e) => { _focused = false; Invalidate(); };
            _numeric.ValueChanged += (s, e) => ValueChanged?.Invoke(this, e);
            _numeric.EnabledChanged += (s, e) => _buttonPanel.Enabled = _numeric.Enabled;

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
            HideInnerButtons();
            UpdateButtonPanelTheme();
        }

        private void HideInnerButtons()
        {
            if (_numeric.Controls.Count <= 0) return;
            var buttons = _numeric.Controls[0];
            buttons.Visible = false;
            buttons.Enabled = false;
        }

        private void UpdateButtonPanelTheme()
        {
            _buttonPanel.ButtonColor = _buttonColor;
            _buttonPanel.HoverColor = _buttonHoverColor;
            _buttonPanel.IconColor = _buttonIconColor;
            _buttonPanel.Enabled = _numeric.Enabled;
            _buttonPanel.Invalidate();
        }

        private void LayoutChildren()
        {
            if (_layouting) return;
            _layouting = true;
            try
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

            int buttonWidth = Math.Max(22, innerH / 2);
            buttonWidth = Math.Min(buttonWidth, Math.Max(22, innerW / 2));
            int spacing = 4;
            int textWidth = Math.Max(0, innerW - buttonWidth - spacing);

            _numeric.Location = new Point(x, y);
            _numeric.Size = new Size(textWidth, innerH);

            _buttonPanel.Location = new Point(x + textWidth + spacing, y);
            _buttonPanel.Size = new Size(buttonWidth, innerH);
            }
            finally
            {
                _layouting = false;
            }
        }

        [Category("Colors")]
        public Color BackgroundColor { get => _backgroundColor; set { _backgroundColor = value; ApplyThemeToInner(); Invalidate(); } }

        [Category("Colors")]
        public Color TextColor { get => _textColor; set { _textColor = value; ApplyThemeToInner(); Invalidate(); } }

        [Category("Colors")]
        public Color ButtonColor { get => _buttonColor; set { _buttonColor = value; ApplyThemeToInner(); UpdateButtonPanelTheme(); Invalidate(); } }

        [Category("Colors")]
        public Color ButtonHoverColor { get => _buttonHoverColor; set { _buttonHoverColor = value; UpdateButtonPanelTheme(); Invalidate(); } }

        [Category("Colors")]
        public Color ButtonIconColor { get => _buttonIconColor; set { _buttonIconColor = value; ApplyThemeToInner(); UpdateButtonPanelTheme(); Invalidate(); } }

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

        protected override void OnPaddingChanged(EventArgs e)
        {
            base.OnPaddingChanged(e);
            LayoutChildren();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            LayoutChildren();
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            HideInnerButtons();
            UpdateButtonPanelTheme();
            LayoutChildren();
        }

        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            base.SetBoundsCore(x, y, width, height, specified);
            LayoutChildren();
        }

        protected override void OnLayout(LayoutEventArgs e)
        {
            base.OnLayout(e);
            LayoutChildren();
        }

        private sealed class UpDownButtonPanel : Control
        {
            private bool _hoverUp;
            private bool _hoverDown;
            private bool _pressedUp;
            private bool _pressedDown;

            public Color ButtonColor { get; set; } = Color.White;
            public Color HoverColor { get; set; } = Color.Gainsboro;
            public Color IconColor { get; set; } = Color.Gray;

            public event EventHandler UpClicked;
            public event EventHandler DownClicked;

            public UpDownButtonPanel()
            {
                SetStyle(
                    ControlStyles.UserPaint |
                    ControlStyles.AllPaintingInWmPaint |
                    ControlStyles.OptimizedDoubleBuffer |
                    ControlStyles.ResizeRedraw,
                    true);
                TabStop = false;
            }

            protected override void OnMouseMove(MouseEventArgs e)
            {
                base.OnMouseMove(e);
                bool isUp = e.Y < Height / 2;
                if (_hoverUp != isUp || _hoverDown != !isUp)
                {
                    _hoverUp = isUp;
                    _hoverDown = !isUp;
                    Invalidate();
                }
            }

            protected override void OnMouseLeave(EventArgs e)
            {
                base.OnMouseLeave(e);
                _hoverUp = false;
                _hoverDown = false;
                Invalidate();
            }

            protected override void OnMouseDown(MouseEventArgs e)
            {
                base.OnMouseDown(e);
                if (e.Button != MouseButtons.Left) return;
                bool isUp = e.Y < Height / 2;
                _pressedUp = isUp;
                _pressedDown = !isUp;
                Invalidate();
            }

            protected override void OnMouseUp(MouseEventArgs e)
            {
                base.OnMouseUp(e);
                if (e.Button != MouseButtons.Left) return;
                bool isUp = e.Y < Height / 2;

                if (_pressedUp && isUp) UpClicked?.Invoke(this, EventArgs.Empty);
                if (_pressedDown && !isUp) DownClicked?.Invoke(this, EventArgs.Empty);

                _pressedUp = false;
                _pressedDown = false;
                Invalidate();
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                if (e == null) return;
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                var rect = new Rectangle(0, 0, Width, Height);
                var topRect = new Rectangle(0, 0, Width, Height / 2);
                var bottomRect = new Rectangle(0, Height / 2, Width, Height - Height / 2);

                using (var b = new SolidBrush(ButtonColor))
                {
                    e.Graphics.FillRectangle(b, rect);
                }

                if (_hoverUp)
                {
                    using (var hb = new SolidBrush(_pressedUp ? ControlPaint.Dark(HoverColor, 0.15f) : HoverColor))
                    {
                        e.Graphics.FillRectangle(hb, topRect);
                    }
                }

                if (_hoverDown)
                {
                    using (var hb = new SolidBrush(_pressedDown ? ControlPaint.Dark(HoverColor, 0.15f) : HoverColor))
                    {
                        e.Graphics.FillRectangle(hb, bottomRect);
                    }
                }

                using (var pen = new Pen(ControlPaint.Dark(ButtonColor, 0.1f), 1f))
                {
                    e.Graphics.DrawLine(pen, 0, bottomRect.Top, Width, bottomRect.Top);
                }

                int triW = Math.Max(6, Math.Min(Width, Height / 2) / 3);
                int triH = Math.Max(4, triW / 2);

                var upCenter = new Point(Width / 2, topRect.Top + topRect.Height / 2);
                var upPts = new[]
                {
                    new Point(upCenter.X - triW / 2, upCenter.Y + triH / 2),
                    new Point(upCenter.X + triW / 2, upCenter.Y + triH / 2),
                    new Point(upCenter.X, upCenter.Y - triH / 2)
                };

                var downCenter = new Point(Width / 2, bottomRect.Top + bottomRect.Height / 2);
                var downPts = new[]
                {
                    new Point(downCenter.X - triW / 2, downCenter.Y - triH / 2),
                    new Point(downCenter.X + triW / 2, downCenter.Y - triH / 2),
                    new Point(downCenter.X, downCenter.Y + triH / 2)
                };

                using (var ib = new SolidBrush(IconColor))
                {
                    e.Graphics.FillPolygon(ib, upPts);
                    e.Graphics.FillPolygon(ib, downPts);
                }
            }
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
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            UiHelpers.ClearBackground(e.Graphics, this);

            var fillRect = new RectangleF(0f, 0f, Width, Height);
            var borderRect = new RectangleF(
                _borderSize / 2f,
                _borderSize / 2f,
                Math.Max(0, Width - _borderSize),
                Math.Max(0, Height - _borderSize));
            using (var path = UiHelpers.CreateRoundedRectPath(fillRect, _borderRadius))
            using (var fill = new SolidBrush(_backgroundColor))
            {
                e.Graphics.FillPath(fill, path);
            }

            var border = _focused ? _borderFocusColor : _borderColor;
            if (_borderSize > 0)
            {
                using (var pen = new Pen(border, _borderSize))
                {
                    pen.Alignment = PenAlignment.Center;
                    pen.LineJoin = LineJoin.Round;
                    pen.StartCap = LineCap.Round;
                    pen.EndCap = LineCap.Round;
                    using (var path = UiHelpers.CreateRoundedRectPath(borderRect, _borderRadius))
                    {
                        e.Graphics.DrawPath(pen, path);
                    }
                }
            }
        }
    }
}

