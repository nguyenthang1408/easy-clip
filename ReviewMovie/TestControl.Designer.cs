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
            this.components = new System.ComponentModel.Container();
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
            this.lblPillText = new ReviewMovie.Base.Controls.UiLabel();
            this.pillText = new ReviewMovie.Base.Controls.PillTextBox();
            this.lblCombo = new ReviewMovie.Base.Controls.UiLabel();
            this.cmbStandard = new ReviewMovie.Base.Controls.UiComboBox();
            this.lblPillCombo = new ReviewMovie.Base.Controls.UiLabel();
            this.pillCombo = new ReviewMovie.Base.Controls.PillComboBox();
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
            this.pnlOptions.SuspendLayout();
            this.grpButtons.SuspendLayout();
            this.tlpButtons.SuspendLayout();
            this.grpGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSample)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpRoot
            // 
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
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.Location = new System.Drawing.Point(16, 16);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblTitle.Size = new System.Drawing.Size(1168, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "UI Test Control";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlpBody
            // 
            this.tlpBody.ColumnCount = 1;
            this.tlpBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBody.Controls.Add(this.splitMain, 0, 0);
            this.tlpBody.Controls.Add(this.grpGrid, 0, 1);
            this.tlpBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpBody.Location = new System.Drawing.Point(16, 72);
            this.tlpBody.Margin = new System.Windows.Forms.Padding(0);
            this.tlpBody.Name = "tlpBody";
            this.tlpBody.RowCount = 2;
            this.tlpBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlpBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpBody.Size = new System.Drawing.Size(1168, 632);
            this.tlpBody.TabIndex = 1;
            // 
            // splitMain
            // 
            this.splitMain.BorderRadius = 8;
            this.splitMain.BorderSizeEx = 1;
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Location = new System.Drawing.Point(0, 0);
            this.splitMain.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.splitMain.Name = "splitMain";
            this.splitMain.Orientation = System.Windows.Forms.Orientation.Vertical;
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.grpInputs);
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.Controls.Add(this.grpButtons);
            this.splitMain.Panel1MinSize = 380;
            this.splitMain.Panel2MinSize = 260;
            this.splitMain.Size = new System.Drawing.Size(1168, 369);
            this.splitMain.SplitterDistance = 740;
            this.splitMain.SplitterWidth = 6;
            this.splitMain.TabIndex = 0;
            // 
            // grpInputs
            // 
            this.grpInputs.Controls.Add(this.tlpInputs);
            this.grpInputs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpInputs.Location = new System.Drawing.Point(0, 0);
            this.grpInputs.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.grpInputs.Name = "grpInputs";
            this.grpInputs.Padding = new System.Windows.Forms.Padding(12, 32, 12, 12);
            this.grpInputs.Size = new System.Drawing.Size(740, 369);
            this.grpInputs.TabIndex = 0;
            this.grpInputs.Text = "Inputs";
            // 
            // tlpInputs
            // 
            this.tlpInputs.ColumnCount = 2;
            this.tlpInputs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tlpInputs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpInputs.Controls.Add(this.lblTextBox, 0, 0);
            this.tlpInputs.Controls.Add(this.txtStandard, 1, 0);
            this.tlpInputs.Controls.Add(this.lblMultiline, 0, 1);
            this.tlpInputs.Controls.Add(this.txtMultiline, 1, 1);
            this.tlpInputs.Controls.Add(this.lblPillText, 0, 2);
            this.tlpInputs.Controls.Add(this.pillText, 1, 2);
            this.tlpInputs.Controls.Add(this.lblCombo, 0, 3);
            this.tlpInputs.Controls.Add(this.cmbStandard, 1, 3);
            this.tlpInputs.Controls.Add(this.lblPillCombo, 0, 4);
            this.tlpInputs.Controls.Add(this.pillCombo, 1, 4);
            this.tlpInputs.Controls.Add(this.lblNumeric, 0, 5);
            this.tlpInputs.Controls.Add(this.numStandard, 1, 5);
            this.tlpInputs.Controls.Add(this.lblOptions, 0, 6);
            this.tlpInputs.Controls.Add(this.pnlOptions, 1, 6);
            this.tlpInputs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpInputs.Location = new System.Drawing.Point(12, 32);
            this.tlpInputs.Margin = new System.Windows.Forms.Padding(0);
            this.tlpInputs.Name = "tlpInputs";
            this.tlpInputs.RowCount = 7;
            this.tlpInputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlpInputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpInputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tlpInputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlpInputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tlpInputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlpInputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlpInputs.Size = new System.Drawing.Size(716, 325);
            this.tlpInputs.TabIndex = 0;
            // 
            // lblTextBox
            // 
            this.lblTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTextBox.Location = new System.Drawing.Point(0, 0);
            this.lblTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.lblTextBox.Name = "lblTextBox";
            this.lblTextBox.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblTextBox.Size = new System.Drawing.Size(130, 36);
            this.lblTextBox.TabIndex = 0;
            this.lblTextBox.Text = "Text Box";
            this.lblTextBox.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtStandard
            // 
            this.txtStandard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtStandard.Location = new System.Drawing.Point(130, 4);
            this.txtStandard.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.txtStandard.Name = "txtStandard";
            this.txtStandard.Size = new System.Drawing.Size(586, 28);
            this.txtStandard.TabIndex = 1;
            // 
            // lblMultiline
            // 
            this.lblMultiline.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMultiline.Location = new System.Drawing.Point(0, 36);
            this.lblMultiline.Margin = new System.Windows.Forms.Padding(0);
            this.lblMultiline.Name = "lblMultiline";
            this.lblMultiline.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblMultiline.Size = new System.Drawing.Size(130, 80);
            this.lblMultiline.TabIndex = 2;
            this.lblMultiline.Text = "Multiline";
            this.lblMultiline.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMultiline
            // 
            this.txtMultiline.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMultiline.Location = new System.Drawing.Point(130, 40);
            this.txtMultiline.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.txtMultiline.Multiline = true;
            this.txtMultiline.Name = "txtMultiline";
            this.txtMultiline.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMultiline.Size = new System.Drawing.Size(586, 72);
            this.txtMultiline.TabIndex = 3;
            // 
            // lblPillText
            // 
            this.lblPillText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPillText.Location = new System.Drawing.Point(0, 116);
            this.lblPillText.Margin = new System.Windows.Forms.Padding(0);
            this.lblPillText.Name = "lblPillText";
            this.lblPillText.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblPillText.Size = new System.Drawing.Size(130, 56);
            this.lblPillText.TabIndex = 4;
            this.lblPillText.Text = "Pill Text";
            this.lblPillText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pillText
            // 
            this.pillText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pillText.Location = new System.Drawing.Point(130, 120);
            this.pillText.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.pillText.Name = "pillText";
            this.pillText.Size = new System.Drawing.Size(586, 48);
            this.pillText.TabIndex = 5;
            // 
            // lblCombo
            // 
            this.lblCombo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCombo.Location = new System.Drawing.Point(0, 172);
            this.lblCombo.Margin = new System.Windows.Forms.Padding(0);
            this.lblCombo.Name = "lblCombo";
            this.lblCombo.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblCombo.Size = new System.Drawing.Size(130, 36);
            this.lblCombo.TabIndex = 6;
            this.lblCombo.Text = "Combo Box";
            this.lblCombo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbStandard
            // 
            this.cmbStandard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbStandard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStandard.FormattingEnabled = true;
            this.cmbStandard.IntegralHeight = false;
            this.cmbStandard.Location = new System.Drawing.Point(130, 176);
            this.cmbStandard.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.cmbStandard.Name = "cmbStandard";
            this.cmbStandard.Size = new System.Drawing.Size(586, 23);
            this.cmbStandard.TabIndex = 7;
            // 
            // lblPillCombo
            // 
            this.lblPillCombo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPillCombo.Location = new System.Drawing.Point(0, 208);
            this.lblPillCombo.Margin = new System.Windows.Forms.Padding(0);
            this.lblPillCombo.Name = "lblPillCombo";
            this.lblPillCombo.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblPillCombo.Size = new System.Drawing.Size(130, 56);
            this.lblPillCombo.TabIndex = 8;
            this.lblPillCombo.Text = "Pill Combo";
            this.lblPillCombo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pillCombo
            // 
            this.pillCombo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pillCombo.Location = new System.Drawing.Point(130, 212);
            this.pillCombo.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.pillCombo.Name = "pillCombo";
            this.pillCombo.Size = new System.Drawing.Size(586, 48);
            this.pillCombo.TabIndex = 9;
            // 
            // lblNumeric
            // 
            this.lblNumeric.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNumeric.Location = new System.Drawing.Point(0, 264);
            this.lblNumeric.Margin = new System.Windows.Forms.Padding(0);
            this.lblNumeric.Name = "lblNumeric";
            this.lblNumeric.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblNumeric.Size = new System.Drawing.Size(130, 36);
            this.lblNumeric.TabIndex = 10;
            this.lblNumeric.Text = "Numeric";
            this.lblNumeric.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numStandard
            // 
            this.numStandard.Location = new System.Drawing.Point(130, 268);
            this.numStandard.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.numStandard.Name = "numStandard";
            this.numStandard.Size = new System.Drawing.Size(120, 30);
            this.numStandard.TabIndex = 11;
            // 
            // lblOptions
            // 
            this.lblOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOptions.Location = new System.Drawing.Point(0, 300);
            this.lblOptions.Margin = new System.Windows.Forms.Padding(0);
            this.lblOptions.Name = "lblOptions";
            this.lblOptions.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblOptions.Size = new System.Drawing.Size(130, 36);
            this.lblOptions.TabIndex = 12;
            this.lblOptions.Text = "Options";
            this.lblOptions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlOptions
            // 
            this.pnlOptions.Controls.Add(this.chkRemember);
            this.pnlOptions.Controls.Add(this.rdoOptionA);
            this.pnlOptions.Controls.Add(this.rdoOptionB);
            this.pnlOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOptions.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.pnlOptions.Location = new System.Drawing.Point(130, 304);
            this.pnlOptions.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.pnlOptions.Name = "pnlOptions";
            this.pnlOptions.Size = new System.Drawing.Size(586, 28);
            this.pnlOptions.TabIndex = 13;
            this.pnlOptions.WrapContents = false;
            // 
            // chkRemember
            // 
            this.chkRemember.AutoSize = true;
            this.chkRemember.Location = new System.Drawing.Point(0, 4);
            this.chkRemember.Margin = new System.Windows.Forms.Padding(0, 4, 12, 4);
            this.chkRemember.Name = "chkRemember";
            this.chkRemember.Size = new System.Drawing.Size(86, 19);
            this.chkRemember.TabIndex = 0;
            this.chkRemember.Text = "Remember";
            this.chkRemember.UseVisualStyleBackColor = true;
            // 
            // rdoOptionA
            // 
            this.rdoOptionA.AutoSize = true;
            this.rdoOptionA.Location = new System.Drawing.Point(98, 4);
            this.rdoOptionA.Margin = new System.Windows.Forms.Padding(0, 4, 12, 4);
            this.rdoOptionA.Name = "rdoOptionA";
            this.rdoOptionA.Size = new System.Drawing.Size(77, 19);
            this.rdoOptionA.TabIndex = 1;
            this.rdoOptionA.TabStop = true;
            this.rdoOptionA.Text = "Option A";
            this.rdoOptionA.UseVisualStyleBackColor = true;
            // 
            // rdoOptionB
            // 
            this.rdoOptionB.AutoSize = true;
            this.rdoOptionB.Location = new System.Drawing.Point(187, 4);
            this.rdoOptionB.Margin = new System.Windows.Forms.Padding(0, 4, 12, 4);
            this.rdoOptionB.Name = "rdoOptionB";
            this.rdoOptionB.Size = new System.Drawing.Size(76, 19);
            this.rdoOptionB.TabIndex = 2;
            this.rdoOptionB.TabStop = true;
            this.rdoOptionB.Text = "Option B";
            this.rdoOptionB.UseVisualStyleBackColor = true;
            // 
            // grpButtons
            // 
            this.grpButtons.Controls.Add(this.tlpButtons);
            this.grpButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpButtons.Location = new System.Drawing.Point(0, 0);
            this.grpButtons.Margin = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.grpButtons.Name = "grpButtons";
            this.grpButtons.Padding = new System.Windows.Forms.Padding(12, 32, 12, 12);
            this.grpButtons.Size = new System.Drawing.Size(422, 369);
            this.grpButtons.TabIndex = 0;
            this.grpButtons.Text = "Buttons";
            // 
            // tlpButtons
            // 
            this.tlpButtons.ColumnCount = 1;
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpButtons.Controls.Add(this.btnPrimary, 0, 0);
            this.tlpButtons.Controls.Add(this.btnSecondary, 0, 1);
            this.tlpButtons.Controls.Add(this.btnLegacy, 0, 2);
            this.tlpButtons.Controls.Add(this.btnDisabled, 0, 3);
            this.tlpButtons.Controls.Add(this.btnIcon, 0, 4);
            this.tlpButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpButtons.Location = new System.Drawing.Point(12, 32);
            this.tlpButtons.Margin = new System.Windows.Forms.Padding(0);
            this.tlpButtons.Name = "tlpButtons";
            this.tlpButtons.RowCount = 5;
            this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tlpButtons.Size = new System.Drawing.Size(398, 325);
            this.tlpButtons.TabIndex = 0;
            // 
            // btnPrimary
            // 
            this.btnPrimary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPrimary.Location = new System.Drawing.Point(0, 4);
            this.btnPrimary.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.btnPrimary.Name = "btnPrimary";
            this.btnPrimary.Size = new System.Drawing.Size(398, 36);
            this.btnPrimary.TabIndex = 0;
            this.btnPrimary.Text = "Primary";
            this.btnPrimary.UseVisualStyleBackColor = true;
            // 
            // btnSecondary
            // 
            this.btnSecondary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSecondary.Location = new System.Drawing.Point(0, 48);
            this.btnSecondary.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.btnSecondary.Name = "btnSecondary";
            this.btnSecondary.Size = new System.Drawing.Size(398, 36);
            this.btnSecondary.TabIndex = 1;
            this.btnSecondary.Text = "Secondary";
            this.btnSecondary.UseVisualStyleBackColor = true;
            // 
            // btnLegacy
            // 
            this.btnLegacy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLegacy.Location = new System.Drawing.Point(0, 92);
            this.btnLegacy.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.btnLegacy.Name = "btnLegacy";
            this.btnLegacy.Size = new System.Drawing.Size(398, 36);
            this.btnLegacy.TabIndex = 2;
            this.btnLegacy.Text = "PrimaryButton";
            this.btnLegacy.UseVisualStyleBackColor = true;
            // 
            // btnDisabled
            // 
            this.btnDisabled.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDisabled.Enabled = false;
            this.btnDisabled.Location = new System.Drawing.Point(0, 136);
            this.btnDisabled.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.btnDisabled.Name = "btnDisabled";
            this.btnDisabled.Size = new System.Drawing.Size(398, 36);
            this.btnDisabled.TabIndex = 3;
            this.btnDisabled.Text = "Disabled";
            this.btnDisabled.UseVisualStyleBackColor = true;
            // 
            // btnIcon
            // 
            this.btnIcon.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnIcon.Location = new System.Drawing.Point(0, 184);
            this.btnIcon.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.btnIcon.Name = "btnIcon";
            this.btnIcon.Size = new System.Drawing.Size(36, 36);
            this.btnIcon.TabIndex = 4;
            this.btnIcon.Text = "X";
            this.btnIcon.UseVisualStyleBackColor = true;
            // 
            // grpGrid
            // 
            this.grpGrid.Controls.Add(this.gridSample);
            this.grpGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpGrid.Location = new System.Drawing.Point(0, 379);
            this.grpGrid.Margin = new System.Windows.Forms.Padding(0);
            this.grpGrid.Name = "grpGrid";
            this.grpGrid.Padding = new System.Windows.Forms.Padding(12, 32, 12, 12);
            this.grpGrid.Size = new System.Drawing.Size(1168, 253);
            this.grpGrid.TabIndex = 1;
            this.grpGrid.Text = "Grid";
            // 
            // gridSample
            // 
            this.gridSample.AllowUserToAddRows = false;
            this.gridSample.AllowUserToDeleteRows = false;
            this.gridSample.AllowUserToResizeRows = false;
            this.gridSample.AutoGenerateColumns = false;
            this.gridSample.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridSample.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridSample.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSample.Location = new System.Drawing.Point(12, 32);
            this.gridSample.MultiSelect = false;
            this.gridSample.Name = "gridSample";
            this.gridSample.ReadOnly = true;
            this.gridSample.RowHeadersVisible = false;
            this.gridSample.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridSample.Size = new System.Drawing.Size(1144, 209);
            this.gridSample.TabIndex = 0;
            // 
            // TestControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 720);
            this.Controls.Add(this.tlpRoot);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
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
        private ReviewMovie.Base.Controls.UiLabel lblPillText;
        private ReviewMovie.Base.Controls.PillTextBox pillText;
        private ReviewMovie.Base.Controls.UiLabel lblCombo;
        private ReviewMovie.Base.Controls.UiComboBox cmbStandard;
        private ReviewMovie.Base.Controls.UiLabel lblPillCombo;
        private ReviewMovie.Base.Controls.PillComboBox pillCombo;
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