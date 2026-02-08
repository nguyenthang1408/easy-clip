using System.Windows.Forms;

namespace EasyClip
{
    partial class TestControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tlpRoot = new ReviewMovie.Base.Controls.UiTableLayoutPanel();
            this.lblTitle = new ReviewMovie.Base.Controls.UiLabel();
            this.tlpBody = new ReviewMovie.Base.Controls.UiTableLayoutPanel();
            this.splitMain = new ReviewMovie.Base.Controls.UiSplitContainer();
            this.grpInputs = new ReviewMovie.Base.Controls.UiGroupBox();
            this.tlpInputs = new ReviewMovie.Base.Controls.UiTableLayoutPanel();
            this.lblTextBox = new ReviewMovie.Base.Controls.UiLabel();
            this.txtStandard = new ReviewMovie.Base.Controls.UiTextBox();
            this.lblMultiline = new ReviewMovie.Base.Controls.UiLabel();
            this.txtMultiline = new ReviewMovie.Base.Controls.UiTextBox();
            this.lblCombo = new ReviewMovie.Base.Controls.UiLabel();
            this.cmbStandard = new ReviewMovie.Base.Controls.UiComboBox();
            this.lblNumeric = new ReviewMovie.Base.Controls.UiLabel();
            this.numStandard = new ReviewMovie.Base.Controls.UiNumericUpDown();
            this.lblOptions = new ReviewMovie.Base.Controls.UiLabel();
            this.pnlOptions = new System.Windows.Forms.FlowLayoutPanel();
            this.chkRemember = new ReviewMovie.Base.Controls.UiCheckBox();
            this.rdoOptionA = new ReviewMovie.Base.Controls.UiRadioButton();
            this.rdoOptionB = new ReviewMovie.Base.Controls.UiRadioButton();
            this.grpButtons = new ReviewMovie.Base.Controls.UiGroupBox();
            this.tlpButtons = new ReviewMovie.Base.Controls.UiTableLayoutPanel();
            this.btnPrimary = new ReviewMovie.Base.Controls.UiButton();
            this.btnSecondary = new ReviewMovie.Base.Controls.UiButton();
            this.btnLegacy = new ReviewMovie.Base.Controls.PrimaryButton();
            this.btnDisabled = new ReviewMovie.Base.Controls.UiButton();
            this.btnIcon = new ReviewMovie.Base.Controls.IconCircleButton();
            this.grpGrid = new ReviewMovie.Base.Controls.UiGroupBox();
            this.gridSample = new ReviewMovie.Base.Controls.UiDataGridView();
            this.tlpRoot.SuspendLayout();
            this.tlpBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            this.grpInputs.SuspendLayout();
            this.tlpInputs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStandard)).BeginInit();
            this.pnlOptions.SuspendLayout();
            this.grpButtons.SuspendLayout();
            this.tlpButtons.SuspendLayout();
            this.grpGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSample)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpRoot
            // 
            this.tlpRoot.BackgroundColor = System.Drawing.Color.Transparent;
            this.tlpRoot.BorderColorEx = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(239)))));
            this.tlpRoot.BorderRadius = 0;
            this.tlpRoot.BorderSizeEx = 0;
            this.tlpRoot.BorderStyleEx = ReviewMovie.Base.Controls.Common.UiBorderStyle.None;
            this.tlpRoot.ColumnCount = 1;
            this.tlpRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRoot.Controls.Add(this.lblTitle, 0, 0);
            this.tlpRoot.Controls.Add(this.tlpBody, 0, 1);
            this.tlpRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRoot.Location = new System.Drawing.Point(0, 0);
            this.tlpRoot.Name = "tlpRoot";
            this.tlpRoot.Padding = new System.Windows.Forms.Padding(16);
            this.tlpRoot.RowCount = 2;
            this.tlpRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tlpRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRoot.Size = new System.Drawing.Size(1200, 720);
            this.tlpRoot.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.BackgroundColor = System.Drawing.Color.Transparent;
            this.lblTitle.BorderColor = System.Drawing.Color.Transparent;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblTitle.Location = new System.Drawing.Point(16, 16);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1168, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "UI Test Control";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            // 
            // tlpBody
            // 
            this.tlpBody.BackgroundColor = System.Drawing.Color.Transparent;
            this.tlpBody.BorderColorEx = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(239)))));
            this.tlpBody.BorderRadius = 0;
            this.tlpBody.BorderSizeEx = 0;
            this.tlpBody.BorderStyleEx = ReviewMovie.Base.Controls.Common.UiBorderStyle.None;
            this.tlpBody.ColumnCount = 1;
            this.tlpBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBody.Controls.Add(this.splitMain, 0, 0);
            this.tlpBody.Controls.Add(this.grpGrid, 0, 1);
            this.tlpBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpBody.Location = new System.Drawing.Point(16, 64);
            this.tlpBody.Margin = new System.Windows.Forms.Padding(0);
            this.tlpBody.Name = "tlpBody";
            this.tlpBody.RowCount = 2;
            this.tlpBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tlpBody.Size = new System.Drawing.Size(1168, 640);
            this.tlpBody.TabIndex = 1;
            // 
            // splitMain
            // 
            this.splitMain.BorderColorEx = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(239)))));
            this.splitMain.BorderRadius = 8;
            this.splitMain.BorderSizeEx = 1;
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Location = new System.Drawing.Point(0, 0);
            this.splitMain.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.splitMain.Name = "splitMain";
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.grpInputs);
            this.splitMain.Panel1MinSize = 380;
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.Controls.Add(this.grpButtons);
            this.splitMain.Panel2MinSize = 260;
            this.splitMain.Size = new System.Drawing.Size(1168, 430);
            this.splitMain.SplitterColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(239)))));
            this.splitMain.SplitterDistance = 740;
            this.splitMain.SplitterWidth = 6;
            this.splitMain.TabIndex = 0;
            // 
            // grpInputs
            // 
            this.grpInputs.BackgroundColor = System.Drawing.Color.Transparent;
            this.grpInputs.BorderColorEx = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(239)))));
            this.grpInputs.BorderRadius = 10;
            this.grpInputs.BorderSizeEx = 1;
            this.grpInputs.BorderStyleEx = ReviewMovie.Base.Controls.Common.UiBorderStyle.Solid;
            this.grpInputs.Controls.Add(this.tlpInputs);
            this.grpInputs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpInputs.Location = new System.Drawing.Point(0, 0);
            this.grpInputs.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.grpInputs.Name = "grpInputs";
            this.grpInputs.Padding = new System.Windows.Forms.Padding(12, 32, 12, 12);
            this.grpInputs.Size = new System.Drawing.Size(740, 430);
            this.grpInputs.TabIndex = 0;
            this.grpInputs.TabStop = false;
            this.grpInputs.Text = "Inputs";
            this.grpInputs.TitleBackColor = System.Drawing.Color.Transparent;
            this.grpInputs.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.grpInputs.TitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            // 
            // tlpInputs
            // 
            this.tlpInputs.BackgroundColor = System.Drawing.Color.Transparent;
            this.tlpInputs.BorderColorEx = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(239)))));
            this.tlpInputs.BorderRadius = 0;
            this.tlpInputs.BorderSizeEx = 0;
            this.tlpInputs.BorderStyleEx = ReviewMovie.Base.Controls.Common.UiBorderStyle.None;
            this.tlpInputs.ColumnCount = 2;
            this.tlpInputs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tlpInputs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpInputs.Controls.Add(this.lblTextBox, 0, 0);
            this.tlpInputs.Controls.Add(this.txtStandard, 1, 0);
            this.tlpInputs.Controls.Add(this.lblMultiline, 0, 1);
            this.tlpInputs.Controls.Add(this.txtMultiline, 1, 1);
            this.tlpInputs.Controls.Add(this.lblCombo, 0, 2);
            this.tlpInputs.Controls.Add(this.cmbStandard, 1, 2);
            this.tlpInputs.Controls.Add(this.lblNumeric, 0, 3);
            this.tlpInputs.Controls.Add(this.numStandard, 1, 3);
            this.tlpInputs.Controls.Add(this.lblOptions, 0, 4);
            this.tlpInputs.Controls.Add(this.pnlOptions, 1, 4);
            this.tlpInputs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpInputs.Location = new System.Drawing.Point(12, 48);
            this.tlpInputs.Margin = new System.Windows.Forms.Padding(0);
            this.tlpInputs.Name = "tlpInputs";
            this.tlpInputs.RowCount = 5;
            this.tlpInputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlpInputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpInputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlpInputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlpInputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlpInputs.Size = new System.Drawing.Size(716, 370);
            this.tlpInputs.TabIndex = 0;
            // 
            // lblTextBox
            // 
            this.lblTextBox.BackColor = System.Drawing.Color.Transparent;
            this.lblTextBox.BackgroundColor = System.Drawing.Color.Transparent;
            this.lblTextBox.BorderColor = System.Drawing.Color.Transparent;
            this.lblTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblTextBox.Location = new System.Drawing.Point(0, 0);
            this.lblTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.lblTextBox.Name = "lblTextBox";
            this.lblTextBox.Size = new System.Drawing.Size(130, 36);
            this.lblTextBox.TabIndex = 0;
            this.lblTextBox.Text = "Text Box";
            this.lblTextBox.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTextBox.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            // 
            // txtStandard
            // 
            this.txtStandard.BackColor = System.Drawing.Color.Transparent;
            this.txtStandard.BackgroundColor = System.Drawing.Color.White;
            this.txtStandard.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(239)))));
            this.txtStandard.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(122)))), ((int)(((byte)(0)))));
            this.txtStandard.BorderRadius = 4;
            this.txtStandard.DisableTextBox = false;
            this.txtStandard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtStandard.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtStandard.IconLeft = null;
            this.txtStandard.IconRight = null;
            this.txtStandard.IconSize = new System.Drawing.Size(18, 18);
            this.txtStandard.Lines = new string[0];
            this.txtStandard.Location = new System.Drawing.Point(130, 4);
            this.txtStandard.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.txtStandard.MaxLength = 32767;
            this.txtStandard.Multiline = false;
            this.txtStandard.Name = "txtStandard";
            this.txtStandard.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);
            this.txtStandard.ReadOnly = false;
            this.txtStandard.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtStandard.SelectionLength = 0;
            this.txtStandard.SelectionStart = 0;
            this.txtStandard.Size = new System.Drawing.Size(586, 28);
            this.txtStandard.TabIndex = 1;
            this.txtStandard.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtStandard.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.txtStandard.UseSystemPasswordChar = false;
            // 
            // lblMultiline
            // 
            this.lblMultiline.BackColor = System.Drawing.Color.Transparent;
            this.lblMultiline.BackgroundColor = System.Drawing.Color.Transparent;
            this.lblMultiline.BorderColor = System.Drawing.Color.Transparent;
            this.lblMultiline.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMultiline.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMultiline.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblMultiline.Location = new System.Drawing.Point(0, 36);
            this.lblMultiline.Margin = new System.Windows.Forms.Padding(0);
            this.lblMultiline.Name = "lblMultiline";
            this.lblMultiline.Size = new System.Drawing.Size(130, 80);
            this.lblMultiline.TabIndex = 2;
            this.lblMultiline.Text = "Multiline";
            this.lblMultiline.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMultiline.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            // 
            // txtMultiline
            // 
            this.txtMultiline.BackColor = System.Drawing.Color.Transparent;
            this.txtMultiline.BackgroundColor = System.Drawing.Color.White;
            this.txtMultiline.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(239)))));
            this.txtMultiline.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(122)))), ((int)(((byte)(0)))));
            this.txtMultiline.BorderRadius = 4;
            this.txtMultiline.DisableTextBox = false;
            this.txtMultiline.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMultiline.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtMultiline.IconLeft = null;
            this.txtMultiline.IconRight = null;
            this.txtMultiline.IconSize = new System.Drawing.Size(18, 18);
            this.txtMultiline.Lines = new string[0];
            this.txtMultiline.Location = new System.Drawing.Point(130, 40);
            this.txtMultiline.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.txtMultiline.MaxLength = 32767;
            this.txtMultiline.Multiline = true;
            this.txtMultiline.Name = "txtMultiline";
            this.txtMultiline.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);
            this.txtMultiline.ReadOnly = false;
            this.txtMultiline.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMultiline.SelectionLength = 0;
            this.txtMultiline.SelectionStart = 0;
            this.txtMultiline.Size = new System.Drawing.Size(586, 72);
            this.txtMultiline.TabIndex = 3;
            this.txtMultiline.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtMultiline.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.txtMultiline.UseSystemPasswordChar = false;
            // lblCombo
            // 
            this.lblCombo.BackColor = System.Drawing.Color.Transparent;
            this.lblCombo.BackgroundColor = System.Drawing.Color.Transparent;
            this.lblCombo.BorderColor = System.Drawing.Color.Transparent;
            this.lblCombo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCombo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCombo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblCombo.Location = new System.Drawing.Point(0, 172);
            this.lblCombo.Margin = new System.Windows.Forms.Padding(0);
            this.lblCombo.Name = "lblCombo";
            this.lblCombo.Size = new System.Drawing.Size(130, 36);
            this.lblCombo.TabIndex = 6;
            this.lblCombo.Text = "Combo Box";
            this.lblCombo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCombo.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            // 
            // cmbStandard
            // 
            this.cmbStandard.BackColor = System.Drawing.Color.White;
            this.cmbStandard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbStandard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStandard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbStandard.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbStandard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.cmbStandard.FormattingEnabled = true;
            this.cmbStandard.IntegralHeight = false;
            this.cmbStandard.Location = new System.Drawing.Point(130, 176);
            this.cmbStandard.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.cmbStandard.Name = "cmbStandard";
            this.cmbStandard.Size = new System.Drawing.Size(586, 23);
            this.cmbStandard.TabIndex = 7;
            // 
            // lblNumeric
            // 
            this.lblNumeric.BackColor = System.Drawing.Color.Transparent;
            this.lblNumeric.BackgroundColor = System.Drawing.Color.Transparent;
            this.lblNumeric.BorderColor = System.Drawing.Color.Transparent;
            this.lblNumeric.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNumeric.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNumeric.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblNumeric.Location = new System.Drawing.Point(0, 264);
            this.lblNumeric.Margin = new System.Windows.Forms.Padding(0);
            this.lblNumeric.Name = "lblNumeric";
            this.lblNumeric.Size = new System.Drawing.Size(130, 36);
            this.lblNumeric.TabIndex = 10;
            this.lblNumeric.Text = "Numeric";
            this.lblNumeric.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNumeric.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            // 
            // numStandard
            // 
            this.numStandard.BackColor = System.Drawing.Color.Transparent;
            this.numStandard.BackgroundColor = System.Drawing.Color.White;
            this.numStandard.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(239)))));
            this.numStandard.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(122)))), ((int)(((byte)(0)))));
            this.numStandard.BorderRadius = 4;
            this.numStandard.BorderSize = 1;
            this.numStandard.ButtonColor = System.Drawing.Color.White;
            this.numStandard.ButtonHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.numStandard.ButtonIconColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(125)))), ((int)(((byte)(132)))));
            this.numStandard.DecimalPlaces = 0;
            this.numStandard.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numStandard.Location = new System.Drawing.Point(130, 268);
            this.numStandard.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.numStandard.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numStandard.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numStandard.Name = "numStandard";
            this.numStandard.Padding = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.numStandard.Size = new System.Drawing.Size(120, 28);
            this.numStandard.TabIndex = 11;
            this.numStandard.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numStandard.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.numStandard.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // lblOptions
            // 
            this.lblOptions.BackColor = System.Drawing.Color.Transparent;
            this.lblOptions.BackgroundColor = System.Drawing.Color.Transparent;
            this.lblOptions.BorderColor = System.Drawing.Color.Transparent;
            this.lblOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOptions.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblOptions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblOptions.Location = new System.Drawing.Point(0, 300);
            this.lblOptions.Margin = new System.Windows.Forms.Padding(0);
            this.lblOptions.Name = "lblOptions";
            this.lblOptions.Size = new System.Drawing.Size(130, 70);
            this.lblOptions.TabIndex = 12;
            this.lblOptions.Text = "Options";
            this.lblOptions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblOptions.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            // 
            // pnlOptions
            // 
            this.pnlOptions.Controls.Add(this.chkRemember);
            this.pnlOptions.Controls.Add(this.rdoOptionA);
            this.pnlOptions.Controls.Add(this.rdoOptionB);
            this.pnlOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOptions.Location = new System.Drawing.Point(130, 304);
            this.pnlOptions.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.pnlOptions.Name = "pnlOptions";
            this.pnlOptions.Size = new System.Drawing.Size(586, 62);
            this.pnlOptions.TabIndex = 13;
            this.pnlOptions.WrapContents = false;
            // 
            // chkRemember
            // 
            this.chkRemember.AutoSize = true;
            this.chkRemember.BoxBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(239)))));
            this.chkRemember.BoxBorderSize = 1;
            this.chkRemember.BoxRadius = 4;
            this.chkRemember.BoxSize = 16;
            this.chkRemember.BoxStyle = ReviewMovie.Base.Controls.Common.UiBoxStyle.Rounded;
            this.chkRemember.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(122)))), ((int)(((byte)(0)))));
            this.chkRemember.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.chkRemember.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.chkRemember.Location = new System.Drawing.Point(0, 4);
            this.chkRemember.Margin = new System.Windows.Forms.Padding(0, 4, 12, 4);
            this.chkRemember.Name = "chkRemember";
            this.chkRemember.Size = new System.Drawing.Size(84, 19);
            this.chkRemember.TabIndex = 0;
            this.chkRemember.Text = "Remember";
            this.chkRemember.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.chkRemember.TextPosition = ReviewMovie.Base.Controls.Common.UiTextPosition.Right;
            this.chkRemember.UncheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(239)))));
            this.chkRemember.UseVisualStyleBackColor = true;
            // 
            // rdoOptionA
            // 
            this.rdoOptionA.AutoSize = true;
            this.rdoOptionA.BoxBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(239)))));
            this.rdoOptionA.BoxBorderSize = 1;
            this.rdoOptionA.BoxRadius = 4;
            this.rdoOptionA.BoxSize = 16;
            this.rdoOptionA.BoxStyle = ReviewMovie.Base.Controls.Common.UiBoxStyle.Circle;
            this.rdoOptionA.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(122)))), ((int)(((byte)(0)))));
            this.rdoOptionA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.rdoOptionA.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.rdoOptionA.Location = new System.Drawing.Point(96, 4);
            this.rdoOptionA.Margin = new System.Windows.Forms.Padding(0, 4, 12, 4);
            this.rdoOptionA.Name = "rdoOptionA";
            this.rdoOptionA.Size = new System.Drawing.Size(73, 19);
            this.rdoOptionA.TabIndex = 1;
            this.rdoOptionA.TabStop = true;
            this.rdoOptionA.Text = "Option A";
            this.rdoOptionA.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.rdoOptionA.TextPosition = ReviewMovie.Base.Controls.Common.UiTextPosition.Right;
            this.rdoOptionA.UncheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(239)))));
            this.rdoOptionA.UseVisualStyleBackColor = true;
            // 
            // rdoOptionB
            // 
            this.rdoOptionB.AutoSize = true;
            this.rdoOptionB.BoxBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(239)))));
            this.rdoOptionB.BoxBorderSize = 1;
            this.rdoOptionB.BoxRadius = 4;
            this.rdoOptionB.BoxSize = 16;
            this.rdoOptionB.BoxStyle = ReviewMovie.Base.Controls.Common.UiBoxStyle.Circle;
            this.rdoOptionB.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(122)))), ((int)(((byte)(0)))));
            this.rdoOptionB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.rdoOptionB.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.rdoOptionB.Location = new System.Drawing.Point(181, 4);
            this.rdoOptionB.Margin = new System.Windows.Forms.Padding(0, 4, 12, 4);
            this.rdoOptionB.Name = "rdoOptionB";
            this.rdoOptionB.Size = new System.Drawing.Size(72, 19);
            this.rdoOptionB.TabIndex = 2;
            this.rdoOptionB.TabStop = true;
            this.rdoOptionB.Text = "Option B";
            this.rdoOptionB.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.rdoOptionB.TextPosition = ReviewMovie.Base.Controls.Common.UiTextPosition.Right;
            this.rdoOptionB.UncheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(239)))));
            this.rdoOptionB.UseVisualStyleBackColor = true;
            // 
            // grpButtons
            // 
            this.grpButtons.BackgroundColor = System.Drawing.Color.Transparent;
            this.grpButtons.BorderColorEx = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(239)))));
            this.grpButtons.BorderRadius = 10;
            this.grpButtons.BorderSizeEx = 1;
            this.grpButtons.BorderStyleEx = ReviewMovie.Base.Controls.Common.UiBorderStyle.Solid;
            this.grpButtons.Controls.Add(this.tlpButtons);
            this.grpButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpButtons.Location = new System.Drawing.Point(0, 0);
            this.grpButtons.Margin = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.grpButtons.Name = "grpButtons";
            this.grpButtons.Padding = new System.Windows.Forms.Padding(12, 32, 12, 12);
            this.grpButtons.Size = new System.Drawing.Size(422, 430);
            this.grpButtons.TabIndex = 0;
            this.grpButtons.TabStop = false;
            this.grpButtons.Text = "Buttons";
            this.grpButtons.TitleBackColor = System.Drawing.Color.Transparent;
            this.grpButtons.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.grpButtons.TitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            // 
            // tlpButtons
            // 
            this.tlpButtons.BackgroundColor = System.Drawing.Color.Transparent;
            this.tlpButtons.BorderColorEx = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(239)))));
            this.tlpButtons.BorderRadius = 0;
            this.tlpButtons.BorderSizeEx = 0;
            this.tlpButtons.BorderStyleEx = ReviewMovie.Base.Controls.Common.UiBorderStyle.None;
            this.tlpButtons.ColumnCount = 1;
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpButtons.Controls.Add(this.btnPrimary, 0, 0);
            this.tlpButtons.Controls.Add(this.btnSecondary, 0, 1);
            this.tlpButtons.Controls.Add(this.btnLegacy, 0, 2);
            this.tlpButtons.Controls.Add(this.btnDisabled, 0, 3);
            this.tlpButtons.Controls.Add(this.btnIcon, 0, 4);
            this.tlpButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpButtons.Location = new System.Drawing.Point(12, 48);
            this.tlpButtons.Margin = new System.Windows.Forms.Padding(0);
            this.tlpButtons.Name = "tlpButtons";
            this.tlpButtons.RowCount = 5;
            this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tlpButtons.Size = new System.Drawing.Size(398, 370);
            this.tlpButtons.TabIndex = 0;
            // 
            // btnPrimary
            // 
            this.btnPrimary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrimary.BackColor = System.Drawing.Color.Transparent;
            this.btnPrimary.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(122)))), ((int)(((byte)(0)))));
            this.btnPrimary.BorderColor = System.Drawing.Color.Transparent;
            this.btnPrimary.BorderHoverColor = System.Drawing.Color.Transparent;
            this.btnPrimary.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.btnPrimary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrimary.ForeColor = System.Drawing.Color.White;
            this.btnPrimary.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(138)))), ((int)(((byte)(26)))));
            this.btnPrimary.IconImage = null;
            this.btnPrimary.IconSize = new System.Drawing.Size(18, 18);
            this.btnPrimary.ImageAlignEx = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnPrimary.Location = new System.Drawing.Point(0, 4);
            this.btnPrimary.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.btnPrimary.Name = "btnPrimary";
            this.btnPrimary.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(108)))), ((int)(((byte)(0)))));
            this.btnPrimary.Size = new System.Drawing.Size(398, 36);
            this.btnPrimary.TabIndex = 0;
            this.btnPrimary.Text = "Primary";
            this.btnPrimary.TextColor = System.Drawing.Color.White;
            this.btnPrimary.TextHoverColor = System.Drawing.Color.White;
            this.btnPrimary.UseVisualStyleBackColor = true;
            // 
            // btnSecondary
            // 
            this.btnSecondary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSecondary.BackColor = System.Drawing.Color.Transparent;
            this.btnSecondary.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(122)))), ((int)(((byte)(0)))));
            this.btnSecondary.BorderColor = System.Drawing.Color.Transparent;
            this.btnSecondary.BorderHoverColor = System.Drawing.Color.Transparent;
            this.btnSecondary.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.btnSecondary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSecondary.ForeColor = System.Drawing.Color.White;
            this.btnSecondary.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(138)))), ((int)(((byte)(26)))));
            this.btnSecondary.IconImage = null;
            this.btnSecondary.IconSize = new System.Drawing.Size(18, 18);
            this.btnSecondary.ImageAlignEx = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSecondary.Location = new System.Drawing.Point(0, 48);
            this.btnSecondary.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.btnSecondary.Name = "btnSecondary";
            this.btnSecondary.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(108)))), ((int)(((byte)(0)))));
            this.btnSecondary.Size = new System.Drawing.Size(398, 36);
            this.btnSecondary.TabIndex = 1;
            this.btnSecondary.Text = "Secondary";
            this.btnSecondary.TextColor = System.Drawing.Color.White;
            this.btnSecondary.TextHoverColor = System.Drawing.Color.White;
            this.btnSecondary.UseVisualStyleBackColor = true;
            // 
            // btnLegacy
            // 
            this.btnLegacy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLegacy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(122)))), ((int)(((byte)(0)))));
            this.btnLegacy.CornerRadius = 12;
            this.btnLegacy.FillColor = System.Drawing.Color.FromArgb(13, 110, 253);
            this.btnLegacy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLegacy.ForeColor = System.Drawing.Color.White;
            this.btnLegacy.HoverFillColor = System.Drawing.Color.FromArgb(11, 94, 215);
            this.btnLegacy.Location = new System.Drawing.Point(0, 92);
            this.btnLegacy.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.btnLegacy.Name = "btnLegacy";
            this.btnLegacy.PressedFillColor = System.Drawing.Color.FromArgb(10, 88, 202);
            this.btnLegacy.Size = new System.Drawing.Size(398, 36);
            this.btnLegacy.TabIndex = 2;
            this.btnLegacy.Text = "PrimaryButton";
            this.btnLegacy.UseVisualStyleBackColor = true;
            // 
            // btnDisabled
            // 
            this.btnDisabled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDisabled.BackColor = System.Drawing.Color.Transparent;
            this.btnDisabled.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(122)))), ((int)(((byte)(0)))));
            this.btnDisabled.BorderColor = System.Drawing.Color.Transparent;
            this.btnDisabled.BorderHoverColor = System.Drawing.Color.Transparent;
            this.btnDisabled.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.btnDisabled.Enabled = false;
            this.btnDisabled.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDisabled.ForeColor = System.Drawing.Color.White;
            this.btnDisabled.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(138)))), ((int)(((byte)(26)))));
            this.btnDisabled.IconImage = null;
            this.btnDisabled.IconSize = new System.Drawing.Size(18, 18);
            this.btnDisabled.ImageAlignEx = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDisabled.Location = new System.Drawing.Point(0, 136);
            this.btnDisabled.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.btnDisabled.Name = "btnDisabled";
            this.btnDisabled.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(108)))), ((int)(((byte)(0)))));
            this.btnDisabled.Size = new System.Drawing.Size(398, 36);
            this.btnDisabled.TabIndex = 3;
            this.btnDisabled.Text = "Disabled";
            this.btnDisabled.TextColor = System.Drawing.Color.White;
            this.btnDisabled.TextHoverColor = System.Drawing.Color.White;
            this.btnDisabled.UseVisualStyleBackColor = true;
            // 
            // btnIcon
            // 
            this.btnIcon.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnIcon.BackColor = System.Drawing.Color.White;
            this.btnIcon.CornerRadius = 15;
            this.btnIcon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIcon.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.btnIcon.Location = new System.Drawing.Point(0, 255);
            this.btnIcon.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.btnIcon.Name = "btnIcon";
            this.btnIcon.NormalBackColor = System.Drawing.Color.White;
            this.btnIcon.PressedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(239)))));
            this.btnIcon.Size = new System.Drawing.Size(36, 36);
            this.btnIcon.TabIndex = 4;
            this.btnIcon.Text = "X";
            this.btnIcon.UseVisualStyleBackColor = true;
            // 
            // grpGrid
            // 
            this.grpGrid.BackgroundColor = System.Drawing.Color.Transparent;
            this.grpGrid.BorderColorEx = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(239)))));
            this.grpGrid.BorderRadius = 10;
            this.grpGrid.BorderSizeEx = 1;
            this.grpGrid.BorderStyleEx = ReviewMovie.Base.Controls.Common.UiBorderStyle.Solid;
            this.grpGrid.Controls.Add(this.gridSample);
            this.grpGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpGrid.Location = new System.Drawing.Point(0, 440);
            this.grpGrid.Margin = new System.Windows.Forms.Padding(0);
            this.grpGrid.Name = "grpGrid";
            this.grpGrid.Padding = new System.Windows.Forms.Padding(12, 32, 12, 12);
            this.grpGrid.Size = new System.Drawing.Size(1168, 200);
            this.grpGrid.TabIndex = 1;
            this.grpGrid.TabStop = false;
            this.grpGrid.Text = "Grid";
            this.grpGrid.TitleBackColor = System.Drawing.Color.Transparent;
            this.grpGrid.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.grpGrid.TitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            // 
            // gridSample
            // 
            this.gridSample.AllowUserToAddRows = false;
            this.gridSample.AllowUserToDeleteRows = false;
            this.gridSample.AllowUserToResizeRows = false;
            this.gridSample.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridSample.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.gridSample.BorderColorEx = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(239)))));
            this.gridSample.BorderRadius = 0;
            this.gridSample.BorderSizeEx = 1;
            this.gridSample.CellBackColor = System.Drawing.Color.White;
            this.gridSample.CellFont = new System.Drawing.Font("Segoe UI", 9F);
            this.gridSample.CellForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridSample.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridSample.ColumnHeadersHeight = 28;
            this.gridSample.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridSample.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridSample.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSample.EnableHeadersVisualStyles = false;
            this.gridSample.GridBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.gridSample.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(239)))));
            this.gridSample.GridForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.gridSample.GridLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(239)))));
            this.gridSample.HeaderBackColor = System.Drawing.Color.White;
            this.gridSample.HeaderFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.gridSample.HeaderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.gridSample.HeaderHeight = 28;
            this.gridSample.Location = new System.Drawing.Point(12, 48);
            this.gridSample.MultiSelect = false;
            this.gridSample.Name = "gridSample";
            this.gridSample.ReadOnly = true;
            this.gridSample.RowHeadersVisible = false;
            this.gridSample.RowHeight = 26;
            this.gridSample.RowTemplate.Height = 26;
            this.gridSample.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridSample.Size = new System.Drawing.Size(1144, 140);
            this.gridSample.TabIndex = 0;
            // 
            // TestControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 720);
            this.Controls.Add(this.tlpRoot);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(1000, 650);
            this.Name = "TestControl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TestControl";
            this.tlpRoot.ResumeLayout(false);
            this.tlpBody.ResumeLayout(false);
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            this.grpInputs.ResumeLayout(false);
            this.tlpInputs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numStandard)).EndInit();
            this.pnlOptions.ResumeLayout(false);
            this.pnlOptions.PerformLayout();
            this.grpButtons.ResumeLayout(false);
            this.tlpButtons.ResumeLayout(false);
            this.grpGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSample)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ReviewMovie.Base.Controls.UiTableLayoutPanel tlpRoot;
        private ReviewMovie.Base.Controls.UiLabel lblTitle;
        private ReviewMovie.Base.Controls.UiTableLayoutPanel tlpBody;
        private ReviewMovie.Base.Controls.UiSplitContainer splitMain;
        private ReviewMovie.Base.Controls.UiGroupBox grpInputs;
        private ReviewMovie.Base.Controls.UiTableLayoutPanel tlpInputs;
        private ReviewMovie.Base.Controls.UiLabel lblTextBox;
        private ReviewMovie.Base.Controls.UiTextBox txtStandard;
        private ReviewMovie.Base.Controls.UiLabel lblMultiline;
        private ReviewMovie.Base.Controls.UiTextBox txtMultiline;
        private ReviewMovie.Base.Controls.UiLabel lblCombo;
        private ReviewMovie.Base.Controls.UiComboBox cmbStandard;
        private ReviewMovie.Base.Controls.UiLabel lblNumeric;
        private ReviewMovie.Base.Controls.UiNumericUpDown numStandard;
        private ReviewMovie.Base.Controls.UiLabel lblOptions;
        private System.Windows.Forms.FlowLayoutPanel pnlOptions;
        private ReviewMovie.Base.Controls.UiCheckBox chkRemember;
        private ReviewMovie.Base.Controls.UiRadioButton rdoOptionA;
        private ReviewMovie.Base.Controls.UiRadioButton rdoOptionB;
        private ReviewMovie.Base.Controls.UiGroupBox grpButtons;
        private ReviewMovie.Base.Controls.UiTableLayoutPanel tlpButtons;
        private ReviewMovie.Base.Controls.UiButton btnPrimary;
        private ReviewMovie.Base.Controls.UiButton btnSecondary;
        private ReviewMovie.Base.Controls.PrimaryButton btnLegacy;
        private ReviewMovie.Base.Controls.UiButton btnDisabled;
        private ReviewMovie.Base.Controls.IconCircleButton btnIcon;
        private ReviewMovie.Base.Controls.UiGroupBox grpGrid;
        private ReviewMovie.Base.Controls.UiDataGridView gridSample;
    }
}