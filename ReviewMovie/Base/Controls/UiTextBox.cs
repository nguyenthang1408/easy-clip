using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using ReviewMovie.Base.Controls.Common;

namespace ReviewMovie.Base.Controls
{
    [DefaultEvent(nameof(TextChanged))]
    public class UiTextBox : UserControl
    {
        private readonly TextBox _textBox;
        private readonly PictureBox _iconLeft;
        private readonly PictureBox _iconRight;

        private bool _hovered;
        private bool _focused;

        private Color _backgroundColor = ThemeManager.Current.SurfaceColor;
        private Color _textColor = ThemeManager.Current.TextPrimary;
        private Color _borderColor = ThemeManager.Current.Border;
        private Color _borderFocusColor = ThemeManager.Current.BorderFocus;
        private Color _hoverColor = ThemeManager.Current.Hover;
        private int _borderRadius = 16;
        private int _borderSize = 1;
        private UiBorderStyle _borderStyle = UiBorderStyle.Solid;
        private Size _iconSize = new Size(18, 18);

        public UiTextBox()
        {
            BackColor = Color.Transparent;
            DoubleBuffered = true;

            _iconLeft = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.CenterImage,
                Visible = false,
                BackColor = Color.Transparent
            };

            _iconRight = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.CenterImage,
                Visible = false,
                BackColor = Color.Transparent
            };

            _textBox = new TextBox
            {
                BorderStyle = BorderStyle.None,
                Multiline = false,
                BackColor = _backgroundColor,
                ForeColor = _textColor
            };

            Controls.Add(_textBox);
            Controls.Add(_iconLeft);
            Controls.Add(_iconRight);

            UiHelpers.EnableSmoothPainting(this);

            Size = new Size(240, 36);
            Padding = new Padding(12, 8, 12, 8);

            HookInnerEvents();
            ApplyThemeToInner();
            LayoutChildren();

            ThemeManager.ThemeChanged += (_, __) =>
            {
                // Only update defaults if user hasn't overridden colors explicitly.
                Invalidate();
            };
        }

        private void HookInnerEvents()
        {
            _textBox.TextChanged += (s, e) => OnTextChanged(e);
            _textBox.Enter += (s, e) => { _focused = true; Invalidate(); OnEnter(e); };
            _textBox.Leave += (s, e) => { _focused = false; Invalidate(); OnLeave(e); };
            _textBox.KeyDown += (s, e) => OnKeyDown(e);
            _textBox.KeyPress += (s, e) => OnKeyPress(e);
            _textBox.KeyUp += (s, e) => OnKeyUp(e);
            _textBox.MouseEnter += (s, e) => { _hovered = true; Invalidate(); };
            _textBox.MouseLeave += (s, e) => { _hovered = false; Invalidate(); };

            // Drag events should bubble from inner textbox.
            _textBox.DragEnter += (s, e) => OnDragEnter(e);
            _textBox.DragDrop += (s, e) => OnDragDrop(e);
            _textBox.DragOver += (s, e) => OnDragOver(e);
            _textBox.DragLeave += (s, e) => OnDragLeave(e);
        }

        private void ApplyThemeToInner()
        {
            _textBox.BackColor = _backgroundColor;
            _textBox.ForeColor = _textColor;
            _textBox.Font = Font;
        }

        private Rectangle GetBorderRect() => new Rectangle(0, 0, Width - 1, Height - 1);

        private void LayoutChildren()
        {
            int left = Padding.Left;
            int right = Width - Padding.Right;

            int iconY = (Height - _iconSize.Height) / 2;

            if (_iconLeft.Visible)
            {
                _iconLeft.Bounds = new Rectangle(left, iconY, _iconSize.Width, _iconSize.Height);
                left = _iconLeft.Right + 8;
            }

            if (_iconRight.Visible)
            {
                _iconRight.Bounds = new Rectangle(right - _iconSize.Width, iconY, _iconSize.Width, _iconSize.Height);
                right = _iconRight.Left - 8;
            }

            int textY = Padding.Top;
            int textHeight = Math.Max(0, Height - Padding.Vertical);

            _textBox.Bounds = new Rectangle(
                left,
                textY,
                Math.Max(0, right - left),
                textHeight);
        }

        [Category("Appearance")]
        public Color BackgroundColor
        {
            get => _backgroundColor;
            set
            {
                _backgroundColor = value;
                ApplyThemeToInner();
                Invalidate();
            }
        }

        [Category("Appearance")]
        public Color TextColor
        {
            get => _textColor;
            set
            {
                _textColor = value;
                ApplyThemeToInner();
                Invalidate();
            }
        }

        [Category("Appearance")]
        public Color BorderColor
        {
            get => _borderColor;
            set { _borderColor = value; Invalidate(); }
        }

        [Category("Appearance")]
        public Color BorderFocusColor
        {
            get => _borderFocusColor;
            set { _borderFocusColor = value; Invalidate(); }
        }

        [Category("Appearance")]
        public Color HoverColor
        {
            get => _hoverColor;
            set { _hoverColor = value; Invalidate(); }
        }

        [Category("Appearance")]
        [DefaultValue(16)]
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

        [Category("Appearance")]
        [DefaultValue(1)]
        public int BorderSize
        {
            get => _borderSize;
            set { _borderSize = Math.Max(0, value); Invalidate(); }
        }

        [Category("Appearance")]
        [DefaultValue(UiBorderStyle.Solid)]
        public UiBorderStyle BorderStyleEx
        {
            get => _borderStyle;
            set { _borderStyle = value; Invalidate(); }
        }

        [Category("Appearance")]
        public Image IconLeft
        {
            get => _iconLeft.Image;
            set
            {
                _iconLeft.Image = value;
                _iconLeft.Visible = value != null;
                LayoutChildren();
                Invalidate();
            }
        }

        [Category("Appearance")]
        public Image IconRight
        {
            get => _iconRight.Image;
            set
            {
                _iconRight.Image = value;
                _iconRight.Visible = value != null;
                LayoutChildren();
                Invalidate();
            }
        }

        [Category("Appearance")]
        public Size IconSize
        {
            get => _iconSize;
            set
            {
                _iconSize = value.Width <= 0 || value.Height <= 0 ? new Size(18, 18) : value;
                LayoutChildren();
                Invalidate();
            }
        }

        // ---- Forward commonly-used TextBox properties (Designer-safe) ----

        [Browsable(true)]
        public override string Text
        {
            get => _textBox.Text;
            set => _textBox.Text = value ?? string.Empty;
        }

        [Category("Behavior")]
        public bool ReadOnly
        {
            get => _textBox.ReadOnly;
            set => _textBox.ReadOnly = value;
        }

        [Category("Behavior")]
        public bool Multiline
        {
            get => _textBox.Multiline;
            set
            {
                _textBox.Multiline = value;
                LayoutChildren();
            }
        }

        [Category("Behavior")]
        public ScrollBars ScrollBars
        {
            get => _textBox.ScrollBars;
            set => _textBox.ScrollBars = value;
        }

        [Category("Behavior")]
        public HorizontalAlignment TextAlign
        {
            get => _textBox.TextAlign;
            set => _textBox.TextAlign = value;
        }

        [Category("Behavior")]
        public int MaxLength
        {
            get => _textBox.MaxLength;
            set => _textBox.MaxLength = value;
        }

        [Category("Behavior")]
        public bool UseSystemPasswordChar
        {
            get => _textBox.UseSystemPasswordChar;
            set => _textBox.UseSystemPasswordChar = value;
        }

        [Browsable(false)]
        public string[] Lines
        {
            get => _textBox.Lines;
            set => _textBox.Lines = value ?? Array.Empty<string>();
        }

        [Browsable(false)]
        public int SelectionStart
        {
            get => _textBox.SelectionStart;
            set => _textBox.SelectionStart = value;
        }

        [Browsable(false)]
        public int SelectionLength
        {
            get => _textBox.SelectionLength;
            set => _textBox.SelectionLength = value;
        }

        public TextBox InnerTextBox => _textBox;

        [Category("Behavior")]
        public bool DisableTextBox
        {
            get => !_textBox.Enabled;
            set => _textBox.Enabled = !value;
        }

        public void EnableTextBox() => _textBox.Enabled = true;
        public void DisableTextBoxNow() => _textBox.Enabled = false;

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
            UiHelpers.ApplyRoundRegion(this, _borderRadius);
            LayoutChildren();
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
            Invalidate();
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            _textBox.Focus();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // Prevent flicker: we fully paint ourselves.
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (e == null) return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            var rect = GetBorderRect();
            using (var path = UiHelpers.CreateRoundedRectPath(rect, _borderRadius))
            using (var fill = new SolidBrush(_backgroundColor))
            {
                e.Graphics.FillPath(fill, path);
            }

            Color border = _focused ? _borderFocusColor : _borderColor;
            if (_hovered && !_focused && _hoverColor.A > 0)
            {
                // Subtle hover: blend border toward hover color (simple overlay)
                border = Color.FromArgb(
                    (border.A + _hoverColor.A) / 2,
                    (border.R + _hoverColor.R) / 2,
                    (border.G + _hoverColor.G) / 2,
                    (border.B + _hoverColor.B) / 2);
            }

            if (_borderStyle != UiBorderStyle.None && _borderSize > 0)
            {
                using (var pen = new Pen(border, _borderSize))
                {
                    pen.Alignment = PenAlignment.Inset;
                    if (_borderStyle == UiBorderStyle.Dashed) pen.DashStyle = DashStyle.Dash;
                    else if (_borderStyle == UiBorderStyle.Dotted) pen.DashStyle = DashStyle.Dot;

                    using (var path = UiHelpers.CreateRoundedRectPath(rect, _borderRadius))
                    {
                        e.Graphics.DrawPath(pen, path);
                    }
                }
            }
        }
    }
}

