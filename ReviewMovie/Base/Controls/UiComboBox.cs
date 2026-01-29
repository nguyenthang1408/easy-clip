using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ReviewMovie.Base.Controls.Common;

namespace ReviewMovie.Base.Controls
{
    public class UiComboBox : ComboBox
    {
        private bool _userCustomizedColors;

        public UiComboBox()
        {
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            FlatStyle = FlatStyle.Flat;
            IntegralHeight = false;

            ApplyThemeDefaults();

            ThemeManager.ThemeChanged += (_, __) =>
            {
                if (!_userCustomizedColors)
                {
                    ApplyThemeDefaults();
                }
            };
        }

        private void ApplyThemeDefaults()
        {
            BackColor = ThemeManager.Current.SurfaceColor;
            ForeColor = ThemeManager.Current.TextPrimary;
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

