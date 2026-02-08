using ReviewMovie.Base.Controls;
using ReviewMovie.Base.Controls.Common;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace EasyClip
{
    public partial class TestControl : Form
    {
        [Category("Behavior")]
        [DefaultValue(false)]
        public bool AutoApplyTheme { get; set; }

        [Category("Behavior")]
        [DefaultValue(true)]
        public bool AutoFillSampleData { get; set; } = true;

        public TestControl()
        {
            InitializeComponent();
            if (AutoApplyTheme)
            {
                ApplyTheme();
            }

            if (AutoFillSampleData)
            {
                BuildSampleData();
            }
        }

        private void ApplyTheme()
        {
            BackColor = ThemeManager.Current.WindowBackColor;
            tlpRoot.BackgroundColor = ThemeManager.Current.WindowBackColor;

            lblTitle.TextColor = ThemeManager.Current.TextPrimary;

            grpInputs.BackgroundColor = ThemeManager.Current.SurfaceColor;
            grpButtons.BackgroundColor = ThemeManager.Current.SurfaceColor;
            grpGrid.BackgroundColor = ThemeManager.Current.SurfaceColor;

            splitMain.BorderColorEx = ThemeManager.Current.Border;
            splitMain.SplitterColor = ThemeManager.Current.Border;

            txtStandard.ApplyStyle(UiPresets.TextBox.Primary);
            txtMultiline.ApplyStyle(UiPresets.TextBox.Multiline);

            btnPrimary.ApplyStyle(UiPresets.Button.Primary);
            btnSecondary.ApplyStyle(UiPresets.Button.Secondary);
            btnDisabled.ApplyStyle(UiPresets.Button.Secondary);
            btnLegacy.FillColor = Color.FromArgb(13, 110, 253);
            btnLegacy.HoverFillColor = Color.FromArgb(11, 94, 215);
            btnLegacy.PressedFillColor = Color.FromArgb(10, 88, 202);

            chkRemember.ApplyStyle(UiPresets.CheckBox.Default);
            numStandard.ApplyStyle(UiPresets.Numeric.Default);
            gridSample.ApplyStyle(UiPresets.Grid.Default);

            btnIcon.NormalBackColor = ThemeManager.Current.SurfaceColor;
            btnIcon.HoverBackColor = ThemeManager.Current.Hover;
            btnIcon.PressedBackColor = ThemeManager.Current.Disabled;
        }

        private void BuildSampleData()
        {
            txtStandard.Text = "Sample text";
            txtMultiline.Text = "Line 1" + Environment.NewLine + "Line 2" + Environment.NewLine + "Line 3";

            cmbStandard.Items.Clear();
            cmbStandard.Items.AddRange(new object[] { "Option A", "Option B", "Option C" });
            if (cmbStandard.Items.Count > 0)
            {
                cmbStandard.SelectedIndex = 0;
            }

            numStandard.Minimum = 0;
            numStandard.Maximum = 100;
            numStandard.Value = 42;

            gridSample.Columns.Clear();
            gridSample.Columns.Add("colName", "Name");
            gridSample.Columns.Add("colValue", "Value");
            gridSample.Rows.Add("Alpha", "100");
            gridSample.Rows.Add("Beta", "200");
            gridSample.Rows.Add("Gamma", "300");
        }
    }
}
