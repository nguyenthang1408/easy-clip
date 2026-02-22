using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ReviewMovie.Base;
using ReviewMovie.Base.Controls.Common;

namespace ReviewMovie.Base.Controls
{
    public class UiComboBox : ComboBox
    {
        private bool _userCustomizedColors;
        private int _borderRadius = 4;
        private bool _disableHoverEffects = true;

        public UiComboBox()
        {
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            FlatStyle = FlatStyle.Standard;
            IntegralHeight = false;

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
        [DefaultValue(4)]
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

        [Category("Behavior")]
        [DefaultValue(true)]
        public bool DisableHoverEffects
        {
            get => _disableHoverEffects;
            set => _disableHoverEffects = value;
        }

        private void ApplyThemeDefaults()
        {
            BackColor = ThemeManager.Current.SurfaceColor;
            ForeColor = ThemeManager.Current.TextPrimary;
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            ApplyRoundRegionIfNeeded();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            ApplyRoundRegionIfNeeded();
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_MOUSEMOVE = 0x0200;
            const int WM_MOUSEHOVER = 0x02A1;
            const int WM_MOUSELEAVE = 0x02A3;

            if (_disableHoverEffects &&
                (m.Msg == WM_MOUSEMOVE || m.Msg == WM_MOUSEHOVER || m.Msg == WM_MOUSELEAVE))
            {
                return;
            }

            base.WndProc(ref m);
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

