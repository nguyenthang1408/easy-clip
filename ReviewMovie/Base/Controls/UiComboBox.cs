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

        public UiComboBox()
        {
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            FlatStyle = FlatStyle.Flat;
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

