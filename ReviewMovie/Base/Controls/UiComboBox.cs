using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using ReviewMovie.Base;
using ReviewMovie.Base.Controls.Common;

namespace ReviewMovie.Base.Controls
{
    public class UiComboBox : ComboBox
    {
        private bool _userCustomizedColors;
        private bool _userCustomizedBorderColors;
        private int _borderRadius = 1;
        private bool _disableHoverEffects = true;
        private bool _centerTextInItems = false;
        private bool _focused;
        private Color _borderColor = ThemeManager.Current.Border;
        private Color _borderFocusColor = ThemeManager.Current.BorderFocus;
        private Color _selectionBackColor = Color.Empty;
        private Color _selectionForeColor = Color.Empty;
        private int _borderSize = 1;

        public UiComboBox()
        {
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            FlatStyle = FlatStyle.Flat;
            IntegralHeight = false;
            DrawMode = DrawMode.OwnerDrawFixed;

            ApplyThemeDefaults();

            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                ThemeManager.ThemeChanged += (_, __) =>
                {
                    if (!_userCustomizedColors)
                    {
                        ApplyThemeDefaults();
                    }
                };
            }
        }

        [Category("Appearance")]
        [DefaultValue(1)]
        public int BorderRadius
        {
            get => _borderRadius;
            set
            {
                _borderRadius = Math.Max(0, value);
                ApplyRoundRegionIfNeeded();
                Invalidate();
            }
        }

        [Category("Appearance")]
        public Color BorderColor
        {
            get => _borderColor;
            set
            {
                _userCustomizedBorderColors = true;
                _borderColor = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        public Color BorderFocusColor
        {
            get => _borderFocusColor;
            set
            {
                _userCustomizedBorderColors = true;
                _borderFocusColor = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        [DefaultValue(1)]
        public int BorderSize
        {
            get => _borderSize;
            set
            {
                _borderSize = Math.Max(1, value);
                Invalidate();
            }
        }

        [Category("Appearance")]
        public Color SelectionBackColor
        {
            get => _selectionBackColor;
            set
            {
                _selectionBackColor = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        public Color SelectionForeColor
        {
            get => _selectionForeColor;
            set
            {
                _selectionForeColor = value;
                Invalidate();
            }
        }

        [Category("Behavior")]
        [DefaultValue(true)]
        public bool DisableHoverEffects
        {
            get => _disableHoverEffects;
            set => _disableHoverEffects = value;
        }

        [Category("Layout")]
        [DefaultValue(false)]
        public bool CenterTextInItems
        {
            get => _centerTextInItems;
            set
            {
                _centerTextInItems = value;
                Invalidate();
            }
        }

        private void ApplyThemeDefaults()
        {
            base.BackColor = ThemeManager.Current.SurfaceColor;
            base.ForeColor = ThemeManager.Current.TextPrimary;
            if (!_userCustomizedBorderColors)
            {
                _borderColor = ThemeManager.Current.Border;
                _borderFocusColor = ThemeManager.Current.BorderFocus;
            }
            Invalidate();
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            ApplyRoundRegionIfNeeded();
            Invalidate();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            ApplyRoundRegionIfNeeded();
            Invalidate();
        }

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            _focused = true;
            Invalidate();
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            _focused = false;
            Invalidate();
        }

        protected override void OnDropDown(EventArgs e)
        {
            base.OnDropDown(e);
            _focused = true;
            Invalidate();
        }

        protected override void OnDropDownClosed(EventArgs e)
        {
            base.OnDropDownClosed(e);
            Invalidate();
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_MOUSEMOVE = 0x0200;
            const int WM_MOUSEHOVER = 0x02A1;
            const int WM_MOUSELEAVE = 0x02A3;
            const int WM_PAINT = 0x000F;
            const int WM_NCPAINT = 0x0085;

            if (_disableHoverEffects &&
                (m.Msg == WM_MOUSEMOVE || m.Msg == WM_MOUSEHOVER || m.Msg == WM_MOUSELEAVE))
            {
                return;
            }

            base.WndProc(ref m);

            if (m.Msg == WM_PAINT || m.Msg == WM_NCPAINT)
            {
                DrawComboBorder();
            }
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            // Keep existing custom owner-draw behavior for project combobox.
            if (string.Equals(Name, "cbProjectName", StringComparison.Ordinal))
            {
                base.OnDrawItem(e);
                return;
            }

            if (e.Index < 0)
            {
                bool isCurrentSelected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
                bool isCurrentHot = (e.State & DrawItemState.HotLight) == DrawItemState.HotLight;
                bool shouldHighlightCurrent = (isCurrentSelected || isCurrentHot) && !_selectionBackColor.IsEmpty;
                if (shouldHighlightCurrent)
                {
                    using (var bgBrush = new SolidBrush(_selectionBackColor))
                    {
                        e.Graphics.FillRectangle(bgBrush, e.Bounds);
                    }
                }
                else
                {
                    e.DrawBackground();
                }

                var flagsCurrent = GetItemTextFlags();
                var bounds = GetItemTextBounds(e.Bounds);
                var currentFore = Enabled ? ForeColor : SystemColors.GrayText;
                if (shouldHighlightCurrent && !_selectionForeColor.IsEmpty)
                {
                    currentFore = _selectionForeColor;
                }

                TextRenderer.DrawText(e.Graphics, Text ?? string.Empty, Font, bounds, currentFore, flagsCurrent);
                e.DrawFocusRectangle();
                return;
            }

            if (e.Index >= Items.Count)
            {
                base.OnDrawItem(e);
                return;
            }

            bool isSelected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
            bool isHot = (e.State & DrawItemState.HotLight) == DrawItemState.HotLight;
            bool shouldHighlight = (isSelected || isHot) && !_selectionBackColor.IsEmpty;
            if (shouldHighlight)
            {
                using (var bgBrush = new SolidBrush(_selectionBackColor))
                {
                    e.Graphics.FillRectangle(bgBrush, e.Bounds);
                }
            }
            else
            {
                e.DrawBackground();
            }

            var fore = Enabled ? ForeColor : SystemColors.GrayText;
            if (shouldHighlight && !_selectionForeColor.IsEmpty)
            {
                fore = _selectionForeColor;
            }
            var flags = GetItemTextFlags();
            var boundsItem = GetItemTextBounds(e.Bounds);
            string text = GetItemText(Items[e.Index]);
            TextRenderer.DrawText(e.Graphics, text ?? string.Empty, Font, boundsItem, fore, flags);
            e.DrawFocusRectangle();
        }

        private TextFormatFlags GetItemTextFlags()
        {
            return (_centerTextInItems ? TextFormatFlags.HorizontalCenter : TextFormatFlags.Left)
                   | TextFormatFlags.VerticalCenter
                   | TextFormatFlags.EndEllipsis;
        }

        private Rectangle GetItemTextBounds(Rectangle bounds)
        {
            if (_centerTextInItems) return bounds;
            return new Rectangle(bounds.X + 4, bounds.Y, Math.Max(0, bounds.Width - 6), bounds.Height);
        }

        private void DrawComboBorder()
        {
            if (!IsHandleCreated || Width <= 0 || Height <= 0) return;

            using (var g = Graphics.FromHwnd(Handle))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;

                Color color = (_focused || DroppedDown) ? _borderFocusColor : _borderColor;
                int thickness = Math.Max(1, _borderSize);
                var rect = new Rectangle(0, 0, Width - 1, Height - 1);

                using (var pen = new Pen(color, thickness))
                {
                    pen.Alignment = PenAlignment.Inset;
                    pen.LineJoin = LineJoin.Round;

                    if (_borderRadius > 0)
                    {
                        using (var path = UiHelpers.CreateRoundedRectPath(rect, _borderRadius))
                        {
                            g.DrawPath(pen, path);
                        }
                    }
                    else
                    {
                        g.DrawRectangle(pen, rect);
                    }
                }
            }
        }

        private void ApplyRoundRegionIfNeeded()
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;

            if (_borderRadius <= 0)
            {
                // Reset any previous region.
                Region = null;
                return;
            }

            UiHelpers.ApplyRoundRegion(this, _borderRadius);
        }

        [Category("Appearance")]
        public new Color BackColor
        {
            get => base.BackColor;
            set
            {
                _userCustomizedColors = true;
                base.BackColor = value;
            }
        }

        [Category("Appearance")]
        public new Color ForeColor
        {
            get => base.ForeColor;
            set
            {
                _userCustomizedColors = true;
                base.ForeColor = value;
            }
        }
    }
}

