
namespace ReviewMovie
{
    partial class FormMain
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            ReviewMovie.Base.Controls.Common.ThemeColors themeColors1 = new ReviewMovie.Base.Controls.Common.ThemeColors();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.ctMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuItemConvertTex2Speech = new System.Windows.Forms.ToolStripMenuItem();
            this.ConvertTex2SpeechAll = new System.Windows.Forms.ToolStripMenuItem();
            this.ConvertTex2SpeechSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemDownAudio = new System.Windows.Forms.ToolStripMenuItem();
            this.DownAudioAll = new System.Windows.Forms.ToolStripMenuItem();
            this.DownAudioAllSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemPartRender = new System.Windows.Forms.ToolStripMenuItem();
            this.PartRenderAll = new System.Windows.Forms.ToolStripMenuItem();
            this.PartRenderSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemReloadVideoTime = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuDeleteRow = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new ReviewMovie.Base.Controls.UiLabel();
            this.lblapi = new ReviewMovie.Base.Controls.UiLabel();
            this.txtAppID = new ReviewMovie.Base.Controls.UiTextBox();
            this.btnOpenProject = new ReviewMovie.Base.Controls.UiButton();
            this.lblToken = new ReviewMovie.Base.Controls.UiLabel();
            this.txtToken = new ReviewMovie.Base.Controls.UiTextBox();
            this.grbConfigRender = new System.Windows.Forms.GroupBox();
            this.ckOpenPlayer = new ReviewMovie.Base.Controls.UiCheckBox();
            this.nbSpeechRatio = new ReviewMovie.Base.Controls.UiNumericUpDown();
            this.cbSettingTemplate = new ReviewMovie.Base.Controls.UiComboBox();
            this.label17 = new ReviewMovie.Base.Controls.UiLabel();
            this.btnSaveEffectSetting = new ReviewMovie.Base.Controls.UiButton();
            this.ckRandomMoveLeftRight = new ReviewMovie.Base.Controls.UiCheckBox();
            this.cbLanguageSelect = new ReviewMovie.Base.Controls.UiComboBox();
            this.label16 = new ReviewMovie.Base.Controls.UiLabel();
            this.label15 = new ReviewMovie.Base.Controls.UiLabel();
            this.nScaleAudioRangeEnd = new ReviewMovie.Base.Controls.UiNumericUpDown();
            this.nScaleAudioRangeStart = new ReviewMovie.Base.Controls.UiNumericUpDown();
            this.label14 = new ReviewMovie.Base.Controls.UiLabel();
            this.ckHflipRandom = new ReviewMovie.Base.Controls.UiCheckBox();
            this.nbThread = new ReviewMovie.Base.Controls.UiNumericUpDown();
            this.label13 = new ReviewMovie.Base.Controls.UiLabel();
            this.nbVolumnOrigin = new ReviewMovie.Base.Controls.UiNumericUpDown();
            this.label4 = new ReviewMovie.Base.Controls.UiLabel();
            this.ckNotUseAudio = new ReviewMovie.Base.Controls.UiCheckBox();
            this.label3 = new ReviewMovie.Base.Controls.UiLabel();
            this.cbMode = new ReviewMovie.Base.Controls.UiComboBox();
            this.label12 = new ReviewMovie.Base.Controls.UiLabel();
            this.cbZoomQuality = new ReviewMovie.Base.Controls.UiComboBox();
            this.label11 = new ReviewMovie.Base.Controls.UiLabel();
            this.nFPS = new ReviewMovie.Base.Controls.UiNumericUpDown();
            this.label10 = new ReviewMovie.Base.Controls.UiLabel();
            this.cbZoomRatio = new ReviewMovie.Base.Controls.UiComboBox();
            this.label9 = new ReviewMovie.Base.Controls.UiLabel();
            this.cbEffectType = new ReviewMovie.Base.Controls.UiComboBox();
            this.label8 = new ReviewMovie.Base.Controls.UiLabel();
            this.ckHflip = new ReviewMovie.Base.Controls.UiCheckBox();
            this.ckRotate = new ReviewMovie.Base.Controls.UiCheckBox();
            this.CkZoom = new ReviewMovie.Base.Controls.UiCheckBox();
            this.cbxVideoQuality = new ReviewMovie.Base.Controls.UiComboBox();
            this.label7 = new ReviewMovie.Base.Controls.UiLabel();
            this.cbxSpeechType = new ReviewMovie.Base.Controls.UiComboBox();
            this.label6 = new ReviewMovie.Base.Controls.UiLabel();
            this.label5 = new ReviewMovie.Base.Controls.UiLabel();
            this.btnAddAll = new ReviewMovie.Base.Controls.UiButton();
            this.lblstatus = new ReviewMovie.Base.Controls.UiLabel();
            this.cboSiteNguon = new ReviewMovie.Base.Controls.UiComboBox();
            this.label1 = new ReviewMovie.Base.Controls.UiLabel();
            this.grboxSetting = new System.Windows.Forms.GroupBox();
            this.grbConfigVoice = new System.Windows.Forms.GroupBox();
            this.btnSaveVoiceSource = new ReviewMovie.Base.Controls.UiButton();
            this.grbActionRender = new System.Windows.Forms.GroupBox();
            this.cbProjectName = new ReviewMovie.Base.Controls.UiComboBox();
            this.tlpView = new ReviewMovie.Base.Controls.UiTableLayoutPanel();
            this.dgvMainView = new ReviewMovie.Base.Controls.UiDataGridView();
            this.Column_check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_textlength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_audiolink = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_audioTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_audiostatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_filemediapath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_timevideo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_renderstatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_inputtext = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsMenuView = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSearch = new ReviewMovie.Base.Controls.UiButton();
            this.hostBtnSearch = new System.Windows.Forms.ToolStripControlHost(this.btnSearch);
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.txtTim = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSelectAll = new ReviewMovie.Base.Controls.UiButton();
            this.hostBtnSelectAll = new System.Windows.Forms.ToolStripControlHost(this.btnSelectAll);
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.lbTitle = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAddRow = new ReviewMovie.Base.Controls.UiButton();
            this.hostBtnAddRow = new System.Windows.Forms.ToolStripControlHost(this.btnAddRow);
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnImportSubtitle = new ReviewMovie.Base.Controls.UiButton();
            this.hostBtnImportSubtitle = new System.Windows.Forms.ToolStripControlHost(this.btnImportSubtitle);
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDestroyAction = new ReviewMovie.Base.Controls.UiButton();
            this.hostBtnDestroyAction = new System.Windows.Forms.ToolStripControlHost(this.btnDestroyAction);
            this.grViewHeader = new System.Windows.Forms.GroupBox();
            this.tlpViewHeader = new ReviewMovie.Base.Controls.UiTableLayoutPanel();
            this.tlpImportMedia = new ReviewMovie.Base.Controls.UiTableLayoutPanel();
            this.txtImPortMedia = new ReviewMovie.Base.Controls.UiTextBox();
            this.lbHeaderInputMedia = new ReviewMovie.Base.Controls.UiLabel();
            this.btnRecord = new ReviewMovie.Base.Controls.UiButton();
            this.tlpText = new ReviewMovie.Base.Controls.UiTableLayoutPanel();
            this.lbHeaderText = new ReviewMovie.Base.Controls.UiLabel();
            this.txtTextInput = new ReviewMovie.Base.Controls.UiTextBox();
            this.tlpHeaderButton = new ReviewMovie.Base.Controls.UiTableLayoutPanel();
            this.btnRenderVideoPart = new ReviewMovie.Base.Controls.UiButton();
            this.btnConvertAudio = new ReviewMovie.Base.Controls.UiButton();
            this.btnSaveAudio = new ReviewMovie.Base.Controls.UiButton();
            this.pnlMainTopBar = new System.Windows.Forms.Panel();
            this.flpHeaderOptions = new System.Windows.Forms.FlowLayoutPanel();
            this.lblHeaderActive = new ReviewMovie.Base.Controls.UiLabel();
            this.lblHeaderRemaining = new ReviewMovie.Base.Controls.UiLabel();
            this.btnHeaderHelp = new ReviewMovie.Base.Controls.IconCircleButton();
            this.btnHeaderSettings = new ReviewMovie.Base.Controls.IconCircleButton();
            this.btnHeaderAvatar = new ReviewMovie.Base.Controls.IconCircleButton();
            this.btnWindowMinimize = new ReviewMovie.Base.Controls.IconCircleButton();
            this.btnWindowClose = new ReviewMovie.Base.Controls.IconCircleButton();
            this.lblMainTopSub = new ReviewMovie.Base.Controls.UiLabel();
            this.lblMainTopTitle = new ReviewMovie.Base.Controls.UiLabel();
            this.lblMainTopIcon = new ReviewMovie.Base.Controls.UiLabel();
            this.scMain = new ReviewMovie.Base.Controls.UiSplitContainer();
            this.scView = new ReviewMovie.Base.Controls.UiSplitContainer();
            this.btnExpand = new ReviewMovie.Base.Controls.UiButton();
            this.scSetting = new ReviewMovie.Base.Controls.UiSplitContainer();
            this.btnCollapse = new ReviewMovie.Base.Controls.UiButton();
            this.ctMenu.SuspendLayout();
            this.grbConfigRender.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbSpeechRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nScaleAudioRangeEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nScaleAudioRangeStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbThread)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbVolumnOrigin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nFPS)).BeginInit();
            this.grboxSetting.SuspendLayout();
            this.grbConfigVoice.SuspendLayout();
            this.grbActionRender.SuspendLayout();
            this.tlpView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMainView)).BeginInit();
            this.tsMenuView.SuspendLayout();
            this.grViewHeader.SuspendLayout();
            this.tlpViewHeader.SuspendLayout();
            this.tlpImportMedia.SuspendLayout();
            this.tlpText.SuspendLayout();
            this.tlpHeaderButton.SuspendLayout();
            this.pnlMainTopBar.SuspendLayout();
            this.flpHeaderOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scView)).BeginInit();
            this.scView.Panel1.SuspendLayout();
            this.scView.Panel2.SuspendLayout();
            this.scView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scSetting)).BeginInit();
            this.scSetting.Panel1.SuspendLayout();
            this.scSetting.Panel2.SuspendLayout();
            this.scSetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctMenu
            // 
            this.ctMenu.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemConvertTex2Speech,
            this.MenuItemDownAudio,
            this.MenuItemPartRender,
            this.MenuItemReloadVideoTime,
            this.tsMenuDeleteRow});
            this.ctMenu.Name = "contextMenuStrip1";
            this.ctMenu.Size = new System.Drawing.Size(250, 114);
            // 
            // MenuItemConvertTex2Speech
            // 
            this.MenuItemConvertTex2Speech.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ConvertTex2SpeechAll,
            this.ConvertTex2SpeechSelect});
            this.MenuItemConvertTex2Speech.Name = "MenuItemConvertTex2Speech";
            this.MenuItemConvertTex2Speech.Size = new System.Drawing.Size(249, 22);
            this.MenuItemConvertTex2Speech.Text = "Chuyển Đổi Text -> Voice";
            // 
            // ConvertTex2SpeechAll
            // 
            this.ConvertTex2SpeechAll.Name = "ConvertTex2SpeechAll";
            this.ConvertTex2SpeechAll.Size = new System.Drawing.Size(140, 22);
            this.ConvertTex2SpeechAll.Text = "Chọn Hết";
            this.ConvertTex2SpeechAll.Click += new System.EventHandler(this.ConvertTex2SpeechAll_Click);
            // 
            // ConvertTex2SpeechSelect
            // 
            this.ConvertTex2SpeechSelect.Name = "ConvertTex2SpeechSelect";
            this.ConvertTex2SpeechSelect.Size = new System.Drawing.Size(140, 22);
            this.ConvertTex2SpeechSelect.Text = "Chọn Nhóm";
            this.ConvertTex2SpeechSelect.Click += new System.EventHandler(this.ConvertTex2SpeechSelect_Click);
            // 
            // MenuItemDownAudio
            // 
            this.MenuItemDownAudio.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DownAudioAll,
            this.DownAudioAllSelect});
            this.MenuItemDownAudio.Name = "MenuItemDownAudio";
            this.MenuItemDownAudio.Size = new System.Drawing.Size(249, 22);
            this.MenuItemDownAudio.Text = "Lấy Audio Chuyển Đổi";
            // 
            // DownAudioAll
            // 
            this.DownAudioAll.Name = "DownAudioAll";
            this.DownAudioAll.Size = new System.Drawing.Size(140, 22);
            this.DownAudioAll.Text = "Chọn Hết";
            this.DownAudioAll.Click += new System.EventHandler(this.DownAudioAll_Click);
            // 
            // DownAudioAllSelect
            // 
            this.DownAudioAllSelect.Name = "DownAudioAllSelect";
            this.DownAudioAllSelect.Size = new System.Drawing.Size(140, 22);
            this.DownAudioAllSelect.Text = "Chọn Nhóm";
            this.DownAudioAllSelect.Click += new System.EventHandler(this.DownAudioAllSelect_Click);
            // 
            // MenuItemPartRender
            // 
            this.MenuItemPartRender.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PartRenderAll,
            this.PartRenderSelect});
            this.MenuItemPartRender.Name = "MenuItemPartRender";
            this.MenuItemPartRender.Size = new System.Drawing.Size(249, 22);
            this.MenuItemPartRender.Text = "Tạo Đoạn Video Từ Media, Audio";
            // 
            // PartRenderAll
            // 
            this.PartRenderAll.Name = "PartRenderAll";
            this.PartRenderAll.Size = new System.Drawing.Size(140, 22);
            this.PartRenderAll.Text = "Chọn Hết";
            this.PartRenderAll.Click += new System.EventHandler(this.PartRenderAll_Click);
            // 
            // PartRenderSelect
            // 
            this.PartRenderSelect.Name = "PartRenderSelect";
            this.PartRenderSelect.Size = new System.Drawing.Size(140, 22);
            this.PartRenderSelect.Text = "Chọn Nhóm";
            this.PartRenderSelect.Click += new System.EventHandler(this.PartRenderSelect_Click);
            // 
            // MenuItemReloadVideoTime
            // 
            this.MenuItemReloadVideoTime.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMAll,
            this.tsMSelected});
            this.MenuItemReloadVideoTime.Name = "MenuItemReloadVideoTime";
            this.MenuItemReloadVideoTime.Size = new System.Drawing.Size(249, 22);
            this.MenuItemReloadVideoTime.Text = "Reload Time Video Nhập";
            // 
            // tsMAll
            // 
            this.tsMAll.Name = "tsMAll";
            this.tsMAll.Size = new System.Drawing.Size(140, 22);
            this.tsMAll.Text = "Chọn Hết";
            this.tsMAll.Click += new System.EventHandler(this.ReloadVideoTimeAll);
            // 
            // tsMSelected
            // 
            this.tsMSelected.Name = "tsMSelected";
            this.tsMSelected.Size = new System.Drawing.Size(140, 22);
            this.tsMSelected.Text = "Chọn Nhóm";
            this.tsMSelected.Click += new System.EventHandler(this.ReloadVideoTimeSelect);
            // 
            // tsMenuDeleteRow
            // 
            this.tsMenuDeleteRow.Name = "tsMenuDeleteRow";
            this.tsMenuDeleteRow.Size = new System.Drawing.Size(249, 22);
            this.tsMenuDeleteRow.Text = "Xóa Dòng Chọn";
            this.tsMenuDeleteRow.Click += new System.EventHandler(this.tsMenuDeleteRow_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.BackgroundColor = System.Drawing.Color.Transparent;
            this.label2.BorderColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.label2.Location = new System.Drawing.Point(15, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Dự Án";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            // 
            // lblapi
            // 
            this.lblapi.BackColor = System.Drawing.Color.Transparent;
            this.lblapi.BackgroundColor = System.Drawing.Color.Transparent;
            this.lblapi.BorderColor = System.Drawing.Color.Transparent;
            this.lblapi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblapi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblapi.Location = new System.Drawing.Point(6, 45);
            this.lblapi.Name = "lblapi";
            this.lblapi.Size = new System.Drawing.Size(40, 15);
            this.lblapi.TabIndex = 8;
            this.lblapi.Text = "AppID";
            this.lblapi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblapi.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            // 
            // txtAppID
            // 
            this.txtAppID.BackColor = System.Drawing.Color.Transparent;
            this.txtAppID.BackgroundColor = System.Drawing.Color.White;
            this.txtAppID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(239)))));
            this.txtAppID.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(122)))), ((int)(((byte)(0)))));
            this.txtAppID.BorderRadius = 4;
            this.txtAppID.DisableTextBox = false;
            this.txtAppID.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtAppID.IconLeft = null;
            this.txtAppID.IconRight = null;
            this.txtAppID.IconSize = new System.Drawing.Size(18, 18);
            this.txtAppID.Lines = new string[] {
        "???"};
            this.txtAppID.Location = new System.Drawing.Point(75, 46);
            this.txtAppID.MaxLength = 32767;
            this.txtAppID.Multiline = true;
            this.txtAppID.Name = "txtAppID";
            this.txtAppID.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);
            this.txtAppID.ReadOnly = false;
            this.txtAppID.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAppID.SelectionLength = 0;
            this.txtAppID.SelectionStart = 0;
            this.txtAppID.Size = new System.Drawing.Size(239, 40);
            this.txtAppID.TabIndex = 9;
            this.txtAppID.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtAppID.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.txtAppID.UseSystemPasswordChar = false;
            this.txtAppID.TextChanged += new System.EventHandler(this.txtAppID_TextChanged);
            // 
            // btnOpenProject
            // 
            this.btnOpenProject.BackColor = System.Drawing.SystemColors.Control;
            this.btnOpenProject.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(122)))), ((int)(((byte)(0)))));
            this.btnOpenProject.BorderColor = System.Drawing.Color.Transparent;
            this.btnOpenProject.BorderHoverColor = System.Drawing.Color.Transparent;
            this.btnOpenProject.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.btnOpenProject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenProject.ForeColor = System.Drawing.Color.White;
            this.btnOpenProject.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(138)))), ((int)(((byte)(26)))));
            this.btnOpenProject.IconImage = null;
            this.btnOpenProject.IconSize = new System.Drawing.Size(18, 18);
            this.btnOpenProject.ImageAlignEx = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnOpenProject.Location = new System.Drawing.Point(269, 19);
            this.btnOpenProject.Name = "btnOpenProject";
            this.btnOpenProject.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(108)))), ((int)(((byte)(0)))));
            this.btnOpenProject.Size = new System.Drawing.Size(67, 25);
            this.btnOpenProject.TabIndex = 10;
            this.btnOpenProject.Text = "Create";
            this.btnOpenProject.TextColor = System.Drawing.Color.White;
            this.btnOpenProject.TextHoverColor = System.Drawing.Color.White;
            this.btnOpenProject.UseVisualStyleBackColor = false;
            this.btnOpenProject.Click += new System.EventHandler(this.btnOpenProject_Click);
            // 
            // lblToken
            // 
            this.lblToken.BackColor = System.Drawing.Color.Transparent;
            this.lblToken.BackgroundColor = System.Drawing.Color.Transparent;
            this.lblToken.BorderColor = System.Drawing.Color.Transparent;
            this.lblToken.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToken.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblToken.Location = new System.Drawing.Point(6, 96);
            this.lblToken.Name = "lblToken";
            this.lblToken.Size = new System.Drawing.Size(38, 15);
            this.lblToken.TabIndex = 11;
            this.lblToken.Text = "Token";
            this.lblToken.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblToken.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            // 
            // txtToken
            // 
            this.txtToken.BackColor = System.Drawing.Color.Transparent;
            this.txtToken.BackgroundColor = System.Drawing.Color.White;
            this.txtToken.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(239)))));
            this.txtToken.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(122)))), ((int)(((byte)(0)))));
            this.txtToken.BorderRadius = 4;
            this.txtToken.DisableTextBox = false;
            this.txtToken.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtToken.IconLeft = null;
            this.txtToken.IconRight = null;
            this.txtToken.IconSize = new System.Drawing.Size(18, 18);
            this.txtToken.Lines = new string[] {
        "???"};
            this.txtToken.Location = new System.Drawing.Point(75, 96);
            this.txtToken.MaxLength = 32767;
            this.txtToken.Multiline = true;
            this.txtToken.Name = "txtToken";
            this.txtToken.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);
            this.txtToken.ReadOnly = false;
            this.txtToken.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtToken.SelectionLength = 0;
            this.txtToken.SelectionStart = 0;
            this.txtToken.Size = new System.Drawing.Size(239, 49);
            this.txtToken.TabIndex = 12;
            this.txtToken.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtToken.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.txtToken.UseSystemPasswordChar = false;
            // 
            // grbConfigRender
            // 
            this.grbConfigRender.Controls.Add(this.ckOpenPlayer);
            this.grbConfigRender.Controls.Add(this.nbSpeechRatio);
            this.grbConfigRender.Controls.Add(this.cbSettingTemplate);
            this.grbConfigRender.Controls.Add(this.label17);
            this.grbConfigRender.Controls.Add(this.btnSaveEffectSetting);
            this.grbConfigRender.Controls.Add(this.ckRandomMoveLeftRight);
            this.grbConfigRender.Controls.Add(this.cbLanguageSelect);
            this.grbConfigRender.Controls.Add(this.label16);
            this.grbConfigRender.Controls.Add(this.label15);
            this.grbConfigRender.Controls.Add(this.nScaleAudioRangeEnd);
            this.grbConfigRender.Controls.Add(this.nScaleAudioRangeStart);
            this.grbConfigRender.Controls.Add(this.label14);
            this.grbConfigRender.Controls.Add(this.ckHflipRandom);
            this.grbConfigRender.Controls.Add(this.nbThread);
            this.grbConfigRender.Controls.Add(this.label13);
            this.grbConfigRender.Controls.Add(this.nbVolumnOrigin);
            this.grbConfigRender.Controls.Add(this.label4);
            this.grbConfigRender.Controls.Add(this.ckNotUseAudio);
            this.grbConfigRender.Controls.Add(this.label3);
            this.grbConfigRender.Controls.Add(this.cbMode);
            this.grbConfigRender.Controls.Add(this.label12);
            this.grbConfigRender.Controls.Add(this.cbZoomQuality);
            this.grbConfigRender.Controls.Add(this.label11);
            this.grbConfigRender.Controls.Add(this.nFPS);
            this.grbConfigRender.Controls.Add(this.label10);
            this.grbConfigRender.Controls.Add(this.cbZoomRatio);
            this.grbConfigRender.Controls.Add(this.label9);
            this.grbConfigRender.Controls.Add(this.cbEffectType);
            this.grbConfigRender.Controls.Add(this.label8);
            this.grbConfigRender.Controls.Add(this.ckHflip);
            this.grbConfigRender.Controls.Add(this.ckRotate);
            this.grbConfigRender.Controls.Add(this.CkZoom);
            this.grbConfigRender.Controls.Add(this.cbxVideoQuality);
            this.grbConfigRender.Controls.Add(this.label7);
            this.grbConfigRender.Controls.Add(this.cbxSpeechType);
            this.grbConfigRender.Controls.Add(this.label6);
            this.grbConfigRender.Controls.Add(this.label5);
            this.grbConfigRender.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grbConfigRender.Location = new System.Drawing.Point(11, 203);
            this.grbConfigRender.Name = "grbConfigRender";
            this.grbConfigRender.Size = new System.Drawing.Size(325, 416);
            this.grbConfigRender.TabIndex = 14;
            this.grbConfigRender.TabStop = false;
            this.grbConfigRender.Text = "Lựa Chọn Hiệu Ứng";
            // 
            // ckOpenPlayer
            // 
            this.ckOpenPlayer.AutoSize = true;
            this.ckOpenPlayer.BoxBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(239)))));
            this.ckOpenPlayer.BoxBorderSize = 1;
            this.ckOpenPlayer.BoxRadius = 4;
            this.ckOpenPlayer.BoxSize = 16;
            this.ckOpenPlayer.BoxStyle = ReviewMovie.Base.Controls.Common.UiBoxStyle.Rounded;
            this.ckOpenPlayer.Checked = true;
            this.ckOpenPlayer.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(122)))), ((int)(((byte)(0)))));
            this.ckOpenPlayer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckOpenPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckOpenPlayer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.ckOpenPlayer.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.ckOpenPlayer.Location = new System.Drawing.Point(78, 207);
            this.ckOpenPlayer.Name = "ckOpenPlayer";
            this.ckOpenPlayer.Size = new System.Drawing.Size(157, 20);
            this.ckOpenPlayer.TabIndex = 126;
            this.ckOpenPlayer.Text = "Tự động Mở Player";
            this.ckOpenPlayer.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.ckOpenPlayer.TextPosition = ReviewMovie.Base.Controls.Common.UiTextPosition.Right;
            this.ckOpenPlayer.UncheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(239)))));
            this.ckOpenPlayer.UseVisualStyleBackColor = true;
            this.ckOpenPlayer.CheckedChanged += new System.EventHandler(this.ckOpenPlayer_CheckedChanged);
            // 
            // nbSpeechRatio
            // 
            this.nbSpeechRatio.BackColor = System.Drawing.Color.Transparent;
            this.nbSpeechRatio.BackgroundColor = System.Drawing.Color.White;
            this.nbSpeechRatio.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(239)))));
            this.nbSpeechRatio.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(122)))), ((int)(((byte)(0)))));
            this.nbSpeechRatio.BorderRadius = 4;
            this.nbSpeechRatio.BorderSize = 1;
            this.nbSpeechRatio.ButtonColor = System.Drawing.Color.White;
            this.nbSpeechRatio.ButtonHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.nbSpeechRatio.ButtonIconColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(125)))), ((int)(((byte)(132)))));
            this.nbSpeechRatio.DecimalPlaces = 1;
            this.nbSpeechRatio.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nbSpeechRatio.Location = new System.Drawing.Point(79, 269);
            this.nbSpeechRatio.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nbSpeechRatio.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nbSpeechRatio.Name = "nbSpeechRatio";
            this.nbSpeechRatio.Padding = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.nbSpeechRatio.Size = new System.Drawing.Size(48, 20);
            this.nbSpeechRatio.TabIndex = 125;
            this.nbSpeechRatio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nbSpeechRatio.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.nbSpeechRatio.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // cbSettingTemplate
            // 
            this.cbSettingTemplate.BackColor = System.Drawing.Color.White;
            this.cbSettingTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSettingTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbSettingTemplate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cbSettingTemplate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.cbSettingTemplate.FormattingEnabled = true;
            this.cbSettingTemplate.IntegralHeight = false;
            this.cbSettingTemplate.Location = new System.Drawing.Point(78, 379);
            this.cbSettingTemplate.Name = "cbSettingTemplate";
            this.cbSettingTemplate.Size = new System.Drawing.Size(143, 23);
            this.cbSettingTemplate.TabIndex = 124;
            this.cbSettingTemplate.SelectedIndexChanged += new System.EventHandler(this.cbSettingTemplate_SelectedIndexChanged);
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.BackgroundColor = System.Drawing.Color.Transparent;
            this.label17.BorderColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.label17.Location = new System.Drawing.Point(6, 383);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(57, 13);
            this.label17.TabIndex = 123;
            this.label17.Text = "Cấu Hình :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label17.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            // 
            // btnSaveEffectSetting
            // 
            this.btnSaveEffectSetting.BackColor = System.Drawing.SystemColors.Control;
            this.btnSaveEffectSetting.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(122)))), ((int)(((byte)(0)))));
            this.btnSaveEffectSetting.BorderColor = System.Drawing.Color.Transparent;
            this.btnSaveEffectSetting.BorderHoverColor = System.Drawing.Color.Transparent;
            this.btnSaveEffectSetting.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.btnSaveEffectSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveEffectSetting.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnSaveEffectSetting.ForeColor = System.Drawing.Color.Red;
            this.btnSaveEffectSetting.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(138)))), ((int)(((byte)(26)))));
            this.btnSaveEffectSetting.IconImage = null;
            this.btnSaveEffectSetting.IconSize = new System.Drawing.Size(18, 18);
            this.btnSaveEffectSetting.ImageAlignEx = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSaveEffectSetting.Location = new System.Drawing.Point(244, 377);
            this.btnSaveEffectSetting.Name = "btnSaveEffectSetting";
            this.btnSaveEffectSetting.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(108)))), ((int)(((byte)(0)))));
            this.btnSaveEffectSetting.Size = new System.Drawing.Size(70, 24);
            this.btnSaveEffectSetting.TabIndex = 45;
            this.btnSaveEffectSetting.Text = "Save";
            this.btnSaveEffectSetting.TextColor = System.Drawing.Color.White;
            this.btnSaveEffectSetting.TextHoverColor = System.Drawing.Color.White;
            this.btnSaveEffectSetting.UseVisualStyleBackColor = false;
            this.btnSaveEffectSetting.Click += new System.EventHandler(this.btnSaveEffectSetting_Click);
            // 
            // ckRandomMoveLeftRight
            // 
            this.ckRandomMoveLeftRight.AutoSize = true;
            this.ckRandomMoveLeftRight.BoxBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(239)))));
            this.ckRandomMoveLeftRight.BoxBorderSize = 1;
            this.ckRandomMoveLeftRight.BoxRadius = 4;
            this.ckRandomMoveLeftRight.BoxSize = 16;
            this.ckRandomMoveLeftRight.BoxStyle = ReviewMovie.Base.Controls.Common.UiBoxStyle.Rounded;
            this.ckRandomMoveLeftRight.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(122)))), ((int)(((byte)(0)))));
            this.ckRandomMoveLeftRight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.ckRandomMoveLeftRight.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.ckRandomMoveLeftRight.Location = new System.Drawing.Point(78, 184);
            this.ckRandomMoveLeftRight.Name = "ckRandomMoveLeftRight";
            this.ckRandomMoveLeftRight.Size = new System.Drawing.Size(212, 17);
            this.ckRandomMoveLeftRight.TabIndex = 122;
            this.ckRandomMoveLeftRight.Text = "Layer Tự Động Di Chuyển Trái <-> Phải";
            this.ckRandomMoveLeftRight.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.ckRandomMoveLeftRight.TextPosition = ReviewMovie.Base.Controls.Common.UiTextPosition.Right;
            this.ckRandomMoveLeftRight.UncheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(239)))));
            this.ckRandomMoveLeftRight.UseVisualStyleBackColor = true;
            this.ckRandomMoveLeftRight.CheckedChanged += new System.EventHandler(this.ckRandomMoveLeftRight_CheckedChanged);
            // 
            // cbLanguageSelect
            // 
            this.cbLanguageSelect.BackColor = System.Drawing.Color.White;
            this.cbLanguageSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLanguageSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbLanguageSelect.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cbLanguageSelect.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.cbLanguageSelect.FormattingEnabled = true;
            this.cbLanguageSelect.IntegralHeight = false;
            this.cbLanguageSelect.Location = new System.Drawing.Point(79, 313);
            this.cbLanguageSelect.Name = "cbLanguageSelect";
            this.cbLanguageSelect.Size = new System.Drawing.Size(235, 23);
            this.cbLanguageSelect.TabIndex = 121;
            this.cbLanguageSelect.SelectedIndexChanged += new System.EventHandler(this.cbLanguageSelect_SelectedIndexChanged);
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.BackgroundColor = System.Drawing.Color.Transparent;
            this.label16.BorderColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.label16.Location = new System.Drawing.Point(6, 316);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(62, 13);
            this.label16.TabIndex = 120;
            this.label16.Text = "Ngôn Ngữ :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label16.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.BackgroundColor = System.Drawing.Color.Transparent;
            this.label15.BorderColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.label15.Location = new System.Drawing.Point(247, 244);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(16, 13);
            this.label15.TabIndex = 119;
            this.label15.Text = "->";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label15.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            // 
            // nScaleAudioRangeEnd
            // 
            this.nScaleAudioRangeEnd.BackColor = System.Drawing.Color.Transparent;
            this.nScaleAudioRangeEnd.BackgroundColor = System.Drawing.Color.White;
            this.nScaleAudioRangeEnd.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(239)))));
            this.nScaleAudioRangeEnd.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(122)))), ((int)(((byte)(0)))));
            this.nScaleAudioRangeEnd.BorderRadius = 4;
            this.nScaleAudioRangeEnd.BorderSize = 1;
            this.nScaleAudioRangeEnd.ButtonColor = System.Drawing.Color.White;
            this.nScaleAudioRangeEnd.ButtonHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.nScaleAudioRangeEnd.ButtonIconColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(125)))), ((int)(((byte)(132)))));
            this.nScaleAudioRangeEnd.DecimalPlaces = 1;
            this.nScaleAudioRangeEnd.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nScaleAudioRangeEnd.Location = new System.Drawing.Point(266, 240);
            this.nScaleAudioRangeEnd.Maximum = new decimal(new int[] {
            22,
            0,
            0,
            65536});
            this.nScaleAudioRangeEnd.Minimum = new decimal(new int[] {
            11,
            0,
            0,
            65536});
            this.nScaleAudioRangeEnd.Name = "nScaleAudioRangeEnd";
            this.nScaleAudioRangeEnd.Padding = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.nScaleAudioRangeEnd.Size = new System.Drawing.Size(46, 20);
            this.nScaleAudioRangeEnd.TabIndex = 118;
            this.nScaleAudioRangeEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nScaleAudioRangeEnd.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.nScaleAudioRangeEnd.Value = new decimal(new int[] {
            12,
            0,
            0,
            65536});
            // 
            // nScaleAudioRangeStart
            // 
            this.nScaleAudioRangeStart.BackColor = System.Drawing.Color.Transparent;
            this.nScaleAudioRangeStart.BackgroundColor = System.Drawing.Color.White;
            this.nScaleAudioRangeStart.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(239)))));
            this.nScaleAudioRangeStart.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(122)))), ((int)(((byte)(0)))));
            this.nScaleAudioRangeStart.BorderRadius = 4;
            this.nScaleAudioRangeStart.BorderSize = 1;
            this.nScaleAudioRangeStart.ButtonColor = System.Drawing.Color.White;
            this.nScaleAudioRangeStart.ButtonHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.nScaleAudioRangeStart.ButtonIconColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(125)))), ((int)(((byte)(132)))));
            this.nScaleAudioRangeStart.DecimalPlaces = 1;
            this.nScaleAudioRangeStart.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nScaleAudioRangeStart.Location = new System.Drawing.Point(199, 240);
            this.nScaleAudioRangeStart.Maximum = new decimal(new int[] {
            18,
            0,
            0,
            65536});
            this.nScaleAudioRangeStart.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nScaleAudioRangeStart.Name = "nScaleAudioRangeStart";
            this.nScaleAudioRangeStart.Padding = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.nScaleAudioRangeStart.Size = new System.Drawing.Size(46, 20);
            this.nScaleAudioRangeStart.TabIndex = 117;
            this.nScaleAudioRangeStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nScaleAudioRangeStart.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.nScaleAudioRangeStart.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.BackgroundColor = System.Drawing.Color.Transparent;
            this.label14.BorderColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.label14.Location = new System.Drawing.Point(133, 244);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 13);
            this.label14.TabIndex = 116;
            this.label14.Text = "Audio Scale";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label14.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            // 
            // ckHflipRandom
            // 
            this.ckHflipRandom.AutoSize = true;
            this.ckHflipRandom.BoxBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(239)))));
            this.ckHflipRandom.BoxBorderSize = 1;
            this.ckHflipRandom.BoxRadius = 4;
            this.ckHflipRandom.BoxSize = 16;
            this.ckHflipRandom.BoxStyle = ReviewMovie.Base.Controls.Common.UiBoxStyle.Rounded;
            this.ckHflipRandom.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(122)))), ((int)(((byte)(0)))));
            this.ckHflipRandom.ForeColor = System.Drawing.Color.Red;
            this.ckHflipRandom.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.ckHflipRandom.Location = new System.Drawing.Point(230, 157);
            this.ckHflipRandom.Name = "ckHflipRandom";
            this.ckHflipRandom.Size = new System.Drawing.Size(84, 17);
            this.ckHflipRandom.TabIndex = 115;
            this.ckHflipRandom.Text = "Lật Random";
            this.ckHflipRandom.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.ckHflipRandom.TextPosition = ReviewMovie.Base.Controls.Common.UiTextPosition.Right;
            this.ckHflipRandom.UncheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(239)))));
            this.ckHflipRandom.UseVisualStyleBackColor = true;
            this.ckHflipRandom.CheckedChanged += new System.EventHandler(this.ckHflipRandom_CheckedChanged);
            // 
            // nbThread
            // 
            this.nbThread.BackColor = System.Drawing.Color.Transparent;
            this.nbThread.BackgroundColor = System.Drawing.Color.White;
            this.nbThread.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(239)))));
            this.nbThread.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(122)))), ((int)(((byte)(0)))));
            this.nbThread.BorderRadius = 4;
            this.nbThread.BorderSize = 1;
            this.nbThread.ButtonColor = System.Drawing.Color.White;
            this.nbThread.ButtonHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.nbThread.ButtonIconColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(125)))), ((int)(((byte)(132)))));
            this.nbThread.DecimalPlaces = 0;
            this.nbThread.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nbThread.Location = new System.Drawing.Point(246, 46);
            this.nbThread.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nbThread.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nbThread.Name = "nbThread";
            this.nbThread.Padding = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.nbThread.Size = new System.Drawing.Size(63, 20);
            this.nbThread.TabIndex = 114;
            this.nbThread.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nbThread.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.nbThread.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.BackgroundColor = System.Drawing.Color.Transparent;
            this.label13.BorderColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.label13.Location = new System.Drawing.Point(172, 50);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 13);
            this.label13.TabIndex = 113;
            this.label13.Text = "Thread :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label13.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            // 
            // nbVolumnOrigin
            // 
            this.nbVolumnOrigin.BackColor = System.Drawing.Color.Transparent;
            this.nbVolumnOrigin.BackgroundColor = System.Drawing.Color.White;
            this.nbVolumnOrigin.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(239)))));
            this.nbVolumnOrigin.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(122)))), ((int)(((byte)(0)))));
            this.nbVolumnOrigin.BorderRadius = 4;
            this.nbVolumnOrigin.BorderSize = 1;
            this.nbVolumnOrigin.ButtonColor = System.Drawing.Color.White;
            this.nbVolumnOrigin.ButtonHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.nbVolumnOrigin.ButtonIconColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(125)))), ((int)(((byte)(132)))));
            this.nbVolumnOrigin.DecimalPlaces = 1;
            this.nbVolumnOrigin.Increment = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            this.nbVolumnOrigin.Location = new System.Drawing.Point(79, 240);
            this.nbVolumnOrigin.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nbVolumnOrigin.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nbVolumnOrigin.Name = "nbVolumnOrigin";
            this.nbVolumnOrigin.Padding = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.nbVolumnOrigin.Size = new System.Drawing.Size(48, 20);
            this.nbVolumnOrigin.TabIndex = 112;
            this.nbVolumnOrigin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nbVolumnOrigin.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.nbVolumnOrigin.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.BackgroundColor = System.Drawing.Color.Transparent;
            this.label4.BorderColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.label4.Location = new System.Drawing.Point(6, 244);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 111;
            this.label4.Text = "Volumn gốc :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            // 
            // ckNotUseAudio
            // 
            this.ckNotUseAudio.AutoSize = true;
            this.ckNotUseAudio.BoxBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(239)))));
            this.ckNotUseAudio.BoxBorderSize = 1;
            this.ckNotUseAudio.BoxRadius = 4;
            this.ckNotUseAudio.BoxSize = 16;
            this.ckNotUseAudio.BoxStyle = ReviewMovie.Base.Controls.Common.UiBoxStyle.Rounded;
            this.ckNotUseAudio.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(122)))), ((int)(((byte)(0)))));
            this.ckNotUseAudio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.ckNotUseAudio.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.ckNotUseAudio.Location = new System.Drawing.Point(294, 273);
            this.ckNotUseAudio.Name = "ckNotUseAudio";
            this.ckNotUseAudio.Size = new System.Drawing.Size(15, 14);
            this.ckNotUseAudio.TabIndex = 110;
            this.ckNotUseAudio.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.ckNotUseAudio.TextPosition = ReviewMovie.Base.Controls.Common.UiTextPosition.Right;
            this.ckNotUseAudio.UncheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(239)))));
            this.ckNotUseAudio.UseVisualStyleBackColor = true;
            this.ckNotUseAudio.CheckedChanged += new System.EventHandler(this.ckMuted_CheckedChanged);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.BackgroundColor = System.Drawing.Color.Transparent;
            this.label3.BorderColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.label3.Location = new System.Drawing.Point(196, 274);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 109;
            this.label3.Text = "Ko dùng Audio :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            // 
            // cbMode
            // 
            this.cbMode.BackColor = System.Drawing.SystemColors.Info;
            this.cbMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.cbMode.FormattingEnabled = true;
            this.cbMode.IntegralHeight = false;
            this.cbMode.Location = new System.Drawing.Point(78, 120);
            this.cbMode.Name = "cbMode";
            this.cbMode.Size = new System.Drawing.Size(125, 21);
            this.cbMode.TabIndex = 108;
            this.cbMode.SelectedIndexChanged += new System.EventHandler(this.cbMode_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.BackgroundColor = System.Drawing.Color.Transparent;
            this.label12.BorderColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.label12.Location = new System.Drawing.Point(6, 123);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 13);
            this.label12.TabIndex = 107;
            this.label12.Text = "Lựa Chọn :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label12.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            // 
            // cbZoomQuality
            // 
            this.cbZoomQuality.BackColor = System.Drawing.SystemColors.Info;
            this.cbZoomQuality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbZoomQuality.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbZoomQuality.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbZoomQuality.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.cbZoomQuality.FormattingEnabled = true;
            this.cbZoomQuality.IntegralHeight = false;
            this.cbZoomQuality.Location = new System.Drawing.Point(78, 47);
            this.cbZoomQuality.Name = "cbZoomQuality";
            this.cbZoomQuality.Size = new System.Drawing.Size(83, 20);
            this.cbZoomQuality.TabIndex = 106;
            this.cbZoomQuality.SelectedIndexChanged += new System.EventHandler(this.cbZoomQuality_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.BackgroundColor = System.Drawing.Color.Transparent;
            this.label11.BorderColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(6, 50);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 12);
            this.label11.TabIndex = 105;
            this.label11.Text = "% ZQuality :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label11.TextColor = System.Drawing.Color.Red;
            // 
            // nFPS
            // 
            this.nFPS.BackColor = System.Drawing.Color.Transparent;
            this.nFPS.BackgroundColor = System.Drawing.Color.White;
            this.nFPS.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(239)))));
            this.nFPS.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(122)))), ((int)(((byte)(0)))));
            this.nFPS.BorderRadius = 4;
            this.nFPS.BorderSize = 1;
            this.nFPS.ButtonColor = System.Drawing.Color.White;
            this.nFPS.ButtonHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.nFPS.ButtonIconColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(125)))), ((int)(((byte)(132)))));
            this.nFPS.DecimalPlaces = 0;
            this.nFPS.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nFPS.Location = new System.Drawing.Point(246, 21);
            this.nFPS.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nFPS.Minimum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.nFPS.Name = "nFPS";
            this.nFPS.Padding = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.nFPS.Size = new System.Drawing.Size(63, 20);
            this.nFPS.TabIndex = 104;
            this.nFPS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nFPS.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.nFPS.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.BackgroundColor = System.Drawing.Color.Transparent;
            this.label10.BorderColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.label10.Location = new System.Drawing.Point(172, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 13);
            this.label10.TabIndex = 103;
            this.label10.Text = "FPS (InPut) :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label10.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            // 
            // cbZoomRatio
            // 
            this.cbZoomRatio.BackColor = System.Drawing.SystemColors.Info;
            this.cbZoomRatio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbZoomRatio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbZoomRatio.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbZoomRatio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.cbZoomRatio.FormattingEnabled = true;
            this.cbZoomRatio.IntegralHeight = false;
            this.cbZoomRatio.Location = new System.Drawing.Point(78, 21);
            this.cbZoomRatio.Name = "cbZoomRatio";
            this.cbZoomRatio.Size = new System.Drawing.Size(83, 20);
            this.cbZoomRatio.TabIndex = 102;
            this.cbZoomRatio.SelectedIndexChanged += new System.EventHandler(this.cbZoomRatio_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.BackgroundColor = System.Drawing.Color.Transparent;
            this.label9.BorderColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(6, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 12);
            this.label9.TabIndex = 100;
            this.label9.Text = "% ZoomUp :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label9.TextColor = System.Drawing.Color.Red;
            // 
            // cbEffectType
            // 
            this.cbEffectType.BackColor = System.Drawing.SystemColors.Info;
            this.cbEffectType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEffectType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbEffectType.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEffectType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.cbEffectType.FormattingEnabled = true;
            this.cbEffectType.IntegralHeight = false;
            this.cbEffectType.Location = new System.Drawing.Point(78, 151);
            this.cbEffectType.Name = "cbEffectType";
            this.cbEffectType.Size = new System.Drawing.Size(125, 20);
            this.cbEffectType.TabIndex = 99;
            this.cbEffectType.SelectedIndexChanged += new System.EventHandler(this.cbEffectType_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.BackgroundColor = System.Drawing.Color.Transparent;
            this.label8.BorderColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.label8.Location = new System.Drawing.Point(6, 153);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 98;
            this.label8.Text = "Hiệu ứng :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label8.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            // 
            // ckHflip
            // 
            this.ckHflip.AutoSize = true;
            this.ckHflip.BoxBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(239)))));
            this.ckHflip.BoxBorderSize = 1;
            this.ckHflip.BoxRadius = 4;
            this.ckHflip.BoxSize = 16;
            this.ckHflip.BoxStyle = ReviewMovie.Base.Controls.Common.UiBoxStyle.Rounded;
            this.ckHflip.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(122)))), ((int)(((byte)(0)))));
            this.ckHflip.ForeColor = System.Drawing.Color.Red;
            this.ckHflip.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.ckHflip.Location = new System.Drawing.Point(230, 136);
            this.ckHflip.Name = "ckHflip";
            this.ckHflip.Size = new System.Drawing.Size(71, 17);
            this.ckHflip.TabIndex = 97;
            this.ckHflip.Text = "Lật Video";
            this.ckHflip.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.ckHflip.TextPosition = ReviewMovie.Base.Controls.Common.UiTextPosition.Right;
            this.ckHflip.UncheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(239)))));
            this.ckHflip.UseVisualStyleBackColor = true;
            this.ckHflip.CheckedChanged += new System.EventHandler(this.ckHflip_CheckedChanged);
            // 
            // ckRotate
            // 
            this.ckRotate.AutoSize = true;
            this.ckRotate.BoxBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(239)))));
            this.ckRotate.BoxBorderSize = 1;
            this.ckRotate.BoxRadius = 4;
            this.ckRotate.BoxSize = 16;
            this.ckRotate.BoxStyle = ReviewMovie.Base.Controls.Common.UiBoxStyle.Rounded;
            this.ckRotate.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(122)))), ((int)(((byte)(0)))));
            this.ckRotate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.ckRotate.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.ckRotate.Location = new System.Drawing.Point(230, 112);
            this.ckRotate.Name = "ckRotate";
            this.ckRotate.Size = new System.Drawing.Size(79, 17);
            this.ckRotate.TabIndex = 96;
            this.ckRotate.Text = "Xoay video";
            this.ckRotate.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.ckRotate.TextPosition = ReviewMovie.Base.Controls.Common.UiTextPosition.Right;
            this.ckRotate.UncheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(239)))));
            this.ckRotate.UseVisualStyleBackColor = true;
            this.ckRotate.CheckedChanged += new System.EventHandler(this.ckRotate_CheckedChanged);
            // 
            // CkZoom
            // 
            this.CkZoom.AutoSize = true;
            this.CkZoom.BoxBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(239)))));
            this.CkZoom.BoxBorderSize = 1;
            this.CkZoom.BoxRadius = 4;
            this.CkZoom.BoxSize = 16;
            this.CkZoom.BoxStyle = ReviewMovie.Base.Controls.Common.UiBoxStyle.Rounded;
            this.CkZoom.Checked = true;
            this.CkZoom.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(122)))), ((int)(((byte)(0)))));
            this.CkZoom.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CkZoom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.CkZoom.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.CkZoom.Location = new System.Drawing.Point(230, 89);
            this.CkZoom.Name = "CkZoom";
            this.CkZoom.Size = new System.Drawing.Size(82, 17);
            this.CkZoom.TabIndex = 95;
            this.CkZoom.Text = "Zoom video";
            this.CkZoom.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.CkZoom.TextPosition = ReviewMovie.Base.Controls.Common.UiTextPosition.Right;
            this.CkZoom.UncheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(239)))));
            this.CkZoom.UseVisualStyleBackColor = true;
            this.CkZoom.CheckedChanged += new System.EventHandler(this.CkZoom_CheckedChanged);
            // 
            // cbxVideoQuality
            // 
            this.cbxVideoQuality.BackColor = System.Drawing.SystemColors.Info;
            this.cbxVideoQuality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxVideoQuality.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxVideoQuality.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxVideoQuality.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.cbxVideoQuality.FormattingEnabled = true;
            this.cbxVideoQuality.IntegralHeight = false;
            this.cbxVideoQuality.Location = new System.Drawing.Point(78, 87);
            this.cbxVideoQuality.Name = "cbxVideoQuality";
            this.cbxVideoQuality.Size = new System.Drawing.Size(125, 21);
            this.cbxVideoQuality.TabIndex = 93;
            this.cbxVideoQuality.SelectedIndexChanged += new System.EventHandler(this.cbxVideoQuality_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.BackgroundColor = System.Drawing.Color.Transparent;
            this.label7.BorderColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.label7.Location = new System.Drawing.Point(6, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 92;
            this.label7.Text = "Chất lượng :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label7.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            // 
            // cbxSpeechType
            // 
            this.cbxSpeechType.BackColor = System.Drawing.Color.White;
            this.cbxSpeechType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSpeechType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxSpeechType.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cbxSpeechType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.cbxSpeechType.FormattingEnabled = true;
            this.cbxSpeechType.IntegralHeight = false;
            this.cbxSpeechType.Location = new System.Drawing.Point(79, 343);
            this.cbxSpeechType.Name = "cbxSpeechType";
            this.cbxSpeechType.Size = new System.Drawing.Size(235, 23);
            this.cbxSpeechType.TabIndex = 18;
            this.cbxSpeechType.SelectedIndexChanged += new System.EventHandler(this.cbxSpeechType_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.BackgroundColor = System.Drawing.Color.Transparent;
            this.label6.BorderColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.label6.Location = new System.Drawing.Point(6, 346);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Giọng Đọc :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label6.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.BackgroundColor = System.Drawing.Color.Transparent;
            this.label5.BorderColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.label5.Location = new System.Drawing.Point(6, 274);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Tốc Độ Đọc :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            // 
            // btnAddAll
            // 
            this.btnAddAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnAddAll.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(122)))), ((int)(((byte)(0)))));
            this.btnAddAll.BorderColor = System.Drawing.Color.Transparent;
            this.btnAddAll.BorderHoverColor = System.Drawing.Color.Transparent;
            this.btnAddAll.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.btnAddAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddAll.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddAll.ForeColor = System.Drawing.Color.White;
            this.btnAddAll.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(138)))), ((int)(((byte)(26)))));
            this.btnAddAll.IconImage = null;
            this.btnAddAll.IconSize = new System.Drawing.Size(18, 18);
            this.btnAddAll.ImageAlignEx = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAddAll.Location = new System.Drawing.Point(11, 26);
            this.btnAddAll.Name = "btnAddAll";
            this.btnAddAll.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(108)))), ((int)(((byte)(0)))));
            this.btnAddAll.Size = new System.Drawing.Size(301, 41);
            this.btnAddAll.TabIndex = 15;
            this.btnAddAll.Text = "GHÉP CÁC ĐOẠN";
            this.btnAddAll.TextColor = System.Drawing.Color.White;
            this.btnAddAll.TextHoverColor = System.Drawing.Color.White;
            this.btnAddAll.UseVisualStyleBackColor = false;
            this.btnAddAll.Click += new System.EventHandler(this.btnAddAll_Click);
            // 
            // lblstatus
            // 
            this.lblstatus.BackColor = System.Drawing.Color.Transparent;
            this.lblstatus.BackgroundColor = System.Drawing.Color.Transparent;
            this.lblstatus.BorderColor = System.Drawing.Color.Transparent;
            this.lblstatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblstatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblstatus.Location = new System.Drawing.Point(15, 76);
            this.lblstatus.Name = "lblstatus";
            this.lblstatus.Size = new System.Drawing.Size(16, 13);
            this.lblstatus.TabIndex = 16;
            this.lblstatus.Text = "...";
            this.lblstatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblstatus.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            // 
            // cboSiteNguon
            // 
            this.cboSiteNguon.BackColor = System.Drawing.Color.White;
            this.cboSiteNguon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSiteNguon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboSiteNguon.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboSiteNguon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.cboSiteNguon.FormattingEnabled = true;
            this.cboSiteNguon.IntegralHeight = false;
            this.cboSiteNguon.Location = new System.Drawing.Point(75, 17);
            this.cboSiteNguon.Name = "cboSiteNguon";
            this.cboSiteNguon.Size = new System.Drawing.Size(175, 23);
            this.cboSiteNguon.TabIndex = 40;
            this.cboSiteNguon.SelectedIndexChanged += new System.EventHandler(this.cboSiteNguon_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.BackgroundColor = System.Drawing.Color.Transparent;
            this.label1.BorderColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 41;
            this.label1.Text = "Nguồn Voice";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            // 
            // grboxSetting
            // 
            this.grboxSetting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(216)))), ((int)(((byte)(233)))));
            this.grboxSetting.Controls.Add(this.grbConfigVoice);
            this.grboxSetting.Controls.Add(this.grbActionRender);
            this.grboxSetting.Controls.Add(this.cbProjectName);
            this.grboxSetting.Controls.Add(this.label2);
            this.grboxSetting.Controls.Add(this.grbConfigRender);
            this.grboxSetting.Controls.Add(this.btnOpenProject);
            this.grboxSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grboxSetting.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grboxSetting.Location = new System.Drawing.Point(0, 8);
            this.grboxSetting.Name = "grboxSetting";
            this.grboxSetting.Size = new System.Drawing.Size(347, 684);
            this.grboxSetting.TabIndex = 1;
            this.grboxSetting.TabStop = false;
            this.grboxSetting.Text = "Cài Đặt ";
            // 
            // grbConfigVoice
            // 
            this.grbConfigVoice.Controls.Add(this.label1);
            this.grbConfigVoice.Controls.Add(this.txtToken);
            this.grbConfigVoice.Controls.Add(this.btnSaveVoiceSource);
            this.grbConfigVoice.Controls.Add(this.txtAppID);
            this.grbConfigVoice.Controls.Add(this.lblToken);
            this.grbConfigVoice.Controls.Add(this.cboSiteNguon);
            this.grbConfigVoice.Controls.Add(this.lblapi);
            this.grbConfigVoice.Enabled = false;
            this.grbConfigVoice.Location = new System.Drawing.Point(11, 48);
            this.grbConfigVoice.Name = "grbConfigVoice";
            this.grbConfigVoice.Size = new System.Drawing.Size(325, 155);
            this.grbConfigVoice.TabIndex = 46;
            this.grbConfigVoice.TabStop = false;
            this.grbConfigVoice.Text = "Cài Đặt Voice";
            // 
            // btnSaveVoiceSource
            // 
            this.btnSaveVoiceSource.BackColor = System.Drawing.SystemColors.Control;
            this.btnSaveVoiceSource.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(122)))), ((int)(((byte)(0)))));
            this.btnSaveVoiceSource.BorderColor = System.Drawing.Color.Transparent;
            this.btnSaveVoiceSource.BorderHoverColor = System.Drawing.Color.Transparent;
            this.btnSaveVoiceSource.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.btnSaveVoiceSource.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveVoiceSource.ForeColor = System.Drawing.Color.White;
            this.btnSaveVoiceSource.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(138)))), ((int)(((byte)(26)))));
            this.btnSaveVoiceSource.IconImage = null;
            this.btnSaveVoiceSource.IconSize = new System.Drawing.Size(18, 18);
            this.btnSaveVoiceSource.ImageAlignEx = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSaveVoiceSource.Location = new System.Drawing.Point(258, 16);
            this.btnSaveVoiceSource.Name = "btnSaveVoiceSource";
            this.btnSaveVoiceSource.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(108)))), ((int)(((byte)(0)))));
            this.btnSaveVoiceSource.Size = new System.Drawing.Size(56, 22);
            this.btnSaveVoiceSource.TabIndex = 44;
            this.btnSaveVoiceSource.Text = "Save";
            this.btnSaveVoiceSource.TextColor = System.Drawing.Color.White;
            this.btnSaveVoiceSource.TextHoverColor = System.Drawing.Color.White;
            this.btnSaveVoiceSource.UseVisualStyleBackColor = false;
            this.btnSaveVoiceSource.Click += new System.EventHandler(this.btnSaveVoiceSource_Click);
            // 
            // grbActionRender
            // 
            this.grbActionRender.Controls.Add(this.btnAddAll);
            this.grbActionRender.Controls.Add(this.lblstatus);
            this.grbActionRender.Location = new System.Drawing.Point(11, 625);
            this.grbActionRender.Name = "grbActionRender";
            this.grbActionRender.Size = new System.Drawing.Size(325, 96);
            this.grbActionRender.TabIndex = 45;
            this.grbActionRender.TabStop = false;
            this.grbActionRender.Text = "Xuất Bản Video";
            // 
            // cbProjectName
            // 
            this.cbProjectName.BackColor = System.Drawing.Color.White;
            this.cbProjectName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbProjectName.DropDownHeight = 200;
            this.cbProjectName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbProjectName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cbProjectName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.cbProjectName.FormattingEnabled = true;
            this.cbProjectName.IntegralHeight = false;
            this.cbProjectName.Location = new System.Drawing.Point(86, 21);
            this.cbProjectName.Name = "cbProjectName";
            this.cbProjectName.Size = new System.Drawing.Size(175, 24);
            this.cbProjectName.TabIndex = 43;
            this.cbProjectName.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cbProjectName_DrawItem);
            this.cbProjectName.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.cbProjectName_MeasureItem);
            this.cbProjectName.SelectedIndexChanged += new System.EventHandler(this.cbProjectName_SelectedIndexChanged);
            this.cbProjectName.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbProjectName_MouseMove);
            // 
            // tlpView
            // 
            this.tlpView.BackgroundColor = System.Drawing.Color.Transparent;
            this.tlpView.BorderColorEx = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(239)))));
            this.tlpView.BorderRadius = 0;
            this.tlpView.BorderSizeEx = 0;
            this.tlpView.BorderStyleEx = ReviewMovie.Base.Controls.Common.UiBorderStyle.None;
            this.tlpView.ColumnCount = 1;
            this.tlpView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpView.Controls.Add(this.dgvMainView, 0, 2);
            this.tlpView.Controls.Add(this.tsMenuView, 0, 1);
            this.tlpView.Controls.Add(this.grViewHeader, 0, 0);
            this.tlpView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpView.Location = new System.Drawing.Point(0, 0);
            this.tlpView.Name = "tlpView";
            this.tlpView.RowCount = 3;
            this.tlpView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.22222F));
            this.tlpView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.77778F));
            this.tlpView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 529F));
            this.tlpView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpView.Size = new System.Drawing.Size(877, 692);
            this.tlpView.TabIndex = 2;
            // 
            // pnlMainTopBar
            // 
            this.pnlMainTopBar.BackColor = System.Drawing.Color.White;
            this.pnlMainTopBar.Controls.Add(this.flpHeaderOptions);
            this.pnlMainTopBar.Controls.Add(this.lblMainTopSub);
            this.pnlMainTopBar.Controls.Add(this.lblMainTopTitle);
            this.pnlMainTopBar.Controls.Add(this.lblMainTopIcon);
            this.pnlMainTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMainTopBar.Location = new System.Drawing.Point(0, 0);
            this.pnlMainTopBar.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMainTopBar.Name = "pnlMainTopBar";
            this.pnlMainTopBar.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.pnlMainTopBar.Size = new System.Drawing.Size(1294, 42);
            this.pnlMainTopBar.TabIndex = 44;
            this.pnlMainTopBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlMainTopBar_MouseDown);
            // 
            // flpHeaderOptions
            // 
            this.flpHeaderOptions.AutoSize = true;
            this.flpHeaderOptions.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpHeaderOptions.BackColor = System.Drawing.Color.White;
            this.flpHeaderOptions.Controls.Add(this.lblHeaderActive);
            this.flpHeaderOptions.Controls.Add(this.lblHeaderRemaining);
            this.flpHeaderOptions.Controls.Add(this.btnHeaderHelp);
            this.flpHeaderOptions.Controls.Add(this.btnHeaderSettings);
            this.flpHeaderOptions.Controls.Add(this.btnHeaderAvatar);
            this.flpHeaderOptions.Controls.Add(this.btnWindowMinimize);
            this.flpHeaderOptions.Controls.Add(this.btnWindowClose);
            this.flpHeaderOptions.Dock = System.Windows.Forms.DockStyle.Right;
            this.flpHeaderOptions.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.flpHeaderOptions.Location = new System.Drawing.Point(741, 8);
            this.flpHeaderOptions.Margin = new System.Windows.Forms.Padding(0);
            this.flpHeaderOptions.Name = "flpHeaderOptions";
            this.flpHeaderOptions.Padding = new System.Windows.Forms.Padding(0);
            this.flpHeaderOptions.Size = new System.Drawing.Size(543, 26);
            this.flpHeaderOptions.TabIndex = 47;
            this.flpHeaderOptions.WrapContents = false;
            this.flpHeaderOptions.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlMainTopBar_MouseDown);
            // 
            // lblHeaderActive
            // 
            this.lblHeaderActive.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(179)))), ((int)(((byte)(126)))));
            this.lblHeaderActive.BorderRadius = 12;
            this.lblHeaderActive.BorderSize = 0;
            this.lblHeaderActive.BorderStyleEx = ReviewMovie.Base.Controls.Common.UiBorderStyle.None;
            this.lblHeaderActive.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblHeaderActive.Location = new System.Drawing.Point(0, 2);
            this.lblHeaderActive.Margin = new System.Windows.Forms.Padding(0, 2, 8, 2);
            this.lblHeaderActive.Name = "lblHeaderActive";
            this.lblHeaderActive.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.lblHeaderActive.Size = new System.Drawing.Size(56, 22);
            this.lblHeaderActive.TabIndex = 0;
            this.lblHeaderActive.Text = "Active";
            this.lblHeaderActive.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblHeaderActive.TextColor = System.Drawing.Color.White;
            // 
            // lblHeaderRemaining
            // 
            this.lblHeaderRemaining.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblHeaderRemaining.BorderRadius = 12;
            this.lblHeaderRemaining.BorderSize = 0;
            this.lblHeaderRemaining.BorderStyleEx = ReviewMovie.Base.Controls.Common.UiBorderStyle.None;
            this.lblHeaderRemaining.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular);
            this.lblHeaderRemaining.Location = new System.Drawing.Point(64, 2);
            this.lblHeaderRemaining.Margin = new System.Windows.Forms.Padding(0, 2, 12, 2);
            this.lblHeaderRemaining.Name = "lblHeaderRemaining";
            this.lblHeaderRemaining.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.lblHeaderRemaining.Size = new System.Drawing.Size(112, 22);
            this.lblHeaderRemaining.TabIndex = 1;
            this.lblHeaderRemaining.Text = "1 Day Remaining";
            this.lblHeaderRemaining.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblHeaderRemaining.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(55)))));
            // 
            // btnHeaderHelp
            // 
            this.btnHeaderHelp.CornerRadius = 10;
            this.btnHeaderHelp.Font = new System.Drawing.Font("Segoe MDL2 Assets", 10F);
            this.btnHeaderHelp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(125)))), ((int)(((byte)(132)))));
            this.btnHeaderHelp.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.btnHeaderHelp.Location = new System.Drawing.Point(188, 0);
            this.btnHeaderHelp.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.btnHeaderHelp.Name = "btnHeaderHelp";
            this.btnHeaderHelp.NormalBackColor = System.Drawing.Color.White;
            this.btnHeaderHelp.PressedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(239)))));
            this.btnHeaderHelp.Size = new System.Drawing.Size(26, 26);
            this.btnHeaderHelp.TabIndex = 2;
            this.btnHeaderHelp.Text = "";
            this.btnHeaderHelp.UseVisualStyleBackColor = true;
            // 
            // btnHeaderSettings
            // 
            this.btnHeaderSettings.CornerRadius = 10;
            this.btnHeaderSettings.Font = new System.Drawing.Font("Segoe MDL2 Assets", 10F);
            this.btnHeaderSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(125)))), ((int)(((byte)(132)))));
            this.btnHeaderSettings.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.btnHeaderSettings.Location = new System.Drawing.Point(220, 0);
            this.btnHeaderSettings.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.btnHeaderSettings.Name = "btnHeaderSettings";
            this.btnHeaderSettings.NormalBackColor = System.Drawing.Color.White;
            this.btnHeaderSettings.PressedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(239)))));
            this.btnHeaderSettings.Size = new System.Drawing.Size(26, 26);
            this.btnHeaderSettings.TabIndex = 3;
            this.btnHeaderSettings.Text = "";
            this.btnHeaderSettings.UseVisualStyleBackColor = true;
            // 
            // btnHeaderAvatar
            // 
            this.btnHeaderAvatar.CornerRadius = 13;
            this.btnHeaderAvatar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnHeaderAvatar.ForeColor = System.Drawing.Color.White;
            this.btnHeaderAvatar.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(138)))), ((int)(((byte)(26)))));
            this.btnHeaderAvatar.Location = new System.Drawing.Point(252, 0);
            this.btnHeaderAvatar.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.btnHeaderAvatar.Name = "btnHeaderAvatar";
            this.btnHeaderAvatar.NormalBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(122)))), ((int)(((byte)(0)))));
            this.btnHeaderAvatar.PressedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(108)))), ((int)(((byte)(0)))));
            this.btnHeaderAvatar.Size = new System.Drawing.Size(26, 26);
            this.btnHeaderAvatar.TabIndex = 4;
            this.btnHeaderAvatar.Text = "TN";
            this.btnHeaderAvatar.UseVisualStyleBackColor = true;
            // 
            // btnWindowMinimize
            // 
            this.btnWindowMinimize.CornerRadius = 10;
            this.btnWindowMinimize.Font = new System.Drawing.Font("Segoe MDL2 Assets", 10F);
            this.btnWindowMinimize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(125)))), ((int)(((byte)(132)))));
            this.btnWindowMinimize.Location = new System.Drawing.Point(288, 0);
            this.btnWindowMinimize.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.btnWindowMinimize.Name = "btnWindowMinimize";
            this.btnWindowMinimize.NormalBackColor = System.Drawing.Color.White;
            this.btnWindowMinimize.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.btnWindowMinimize.PressedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(239)))));
            this.btnWindowMinimize.Size = new System.Drawing.Size(26, 26);
            this.btnWindowMinimize.TabIndex = 46;
            this.btnWindowMinimize.Text = "";
            this.btnWindowMinimize.UseVisualStyleBackColor = true;
            this.btnWindowMinimize.Click += new System.EventHandler(this.btnWindowMinimize_Click);
            // 
            // btnWindowClose
            // 
            this.btnWindowClose.CornerRadius = 10;
            this.btnWindowClose.Font = new System.Drawing.Font("Segoe MDL2 Assets", 10F);
            this.btnWindowClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(125)))), ((int)(((byte)(132)))));
            this.btnWindowClose.Location = new System.Drawing.Point(314, 0);
            this.btnWindowClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnWindowClose.Name = "btnWindowClose";
            this.btnWindowClose.NormalBackColor = System.Drawing.Color.White;
            this.btnWindowClose.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.btnWindowClose.PressedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(239)))));
            this.btnWindowClose.Size = new System.Drawing.Size(26, 26);
            this.btnWindowClose.TabIndex = 45;
            this.btnWindowClose.Text = "";
            this.btnWindowClose.UseVisualStyleBackColor = true;
            this.btnWindowClose.Click += new System.EventHandler(this.btnWindowClose_Click);
            // 
            // lblMainTopIcon
            // 
            this.lblMainTopIcon.Font = new System.Drawing.Font("Segoe MDL2 Assets", 12F);
            this.lblMainTopIcon.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
            this.lblMainTopIcon.Location = new System.Drawing.Point(12, 12);
            this.lblMainTopIcon.Name = "lblMainTopIcon";
            this.lblMainTopIcon.Size = new System.Drawing.Size(18, 18);
            this.lblMainTopIcon.TabIndex = 0;
            this.lblMainTopIcon.Text = "";
            this.lblMainTopIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMainTopIcon.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlMainTopBar_MouseDown);
            // 
            // lblMainTopTitle
            // 
            this.lblMainTopTitle.AutoSize = true;
            this.lblMainTopTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblMainTopTitle.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(55)))));
            this.lblMainTopTitle.Location = new System.Drawing.Point(34, 10);
            this.lblMainTopTitle.Name = "lblMainTopTitle";
            this.lblMainTopTitle.Size = new System.Drawing.Size(93, 17);
            this.lblMainTopTitle.TabIndex = 1;
            this.lblMainTopTitle.Text = "EasyClip Studio";
            this.lblMainTopTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlMainTopBar_MouseDown);
            // 
            // lblMainTopSub
            // 
            this.lblMainTopSub.AutoSize = true;
            this.lblMainTopSub.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblMainTopSub.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(145)))), ((int)(((byte)(165)))));
            this.lblMainTopSub.Location = new System.Drawing.Point(34, 26);
            this.lblMainTopSub.Name = "lblMainTopSub";
            this.lblMainTopSub.Size = new System.Drawing.Size(90, 12);
            this.lblMainTopSub.TabIndex = 2;
            this.lblMainTopSub.Text = "TPMEDIA PREMIUM";
            this.lblMainTopSub.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlMainTopBar_MouseDown);
            // 
            // dgvMainView
            // 
            this.dgvMainView.AllowDrop = true;
            this.dgvMainView.AllowUserToAddRows = false;
            this.dgvMainView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MintCream;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.PaleGreen;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgvMainView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMainView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvMainView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.dgvMainView.BorderColorEx = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(239)))));
            this.dgvMainView.BorderRadius = 0;
            this.dgvMainView.BorderSizeEx = 1;
            this.dgvMainView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvMainView.CellBackColor = System.Drawing.Color.White;
            this.dgvMainView.CellFont = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvMainView.CellForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMainView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMainView.ColumnHeadersHeight = 52;
            this.dgvMainView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvMainView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_check,
            this.Column_id,
            this.Column_index,
            this.Column_textlength,
            this.Column_audiolink,
            this.Column_audioTime,
            this.Column_audiostatus,
            this.Column_filemediapath,
            this.Column_timevideo,
            this.Column_renderstatus,
            this.Column_inputtext});
            this.dgvMainView.ContextMenuStrip = this.ctMenu;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(8, 6, 8, 6);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMainView.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMainView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMainView.EnableHeadersVisualStyles = false;
            this.dgvMainView.GridBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.dgvMainView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(239)))));
            this.dgvMainView.GridForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.dgvMainView.GridLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(239)))));
            themeColors1.Accent = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(122)))), ((int)(((byte)(0)))));
            themeColors1.AccentHover = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(138)))), ((int)(((byte)(26)))));
            themeColors1.AccentPressed = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(108)))), ((int)(((byte)(0)))));
            themeColors1.Border = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(239)))));
            themeColors1.BorderFocus = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(122)))), ((int)(((byte)(0)))));
            themeColors1.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            themeColors1.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            themeColors1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            themeColors1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            themeColors1.SurfaceColor = System.Drawing.Color.White;
            themeColors1.TextDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(175)))), ((int)(((byte)(182)))));
            themeColors1.TextPrimary = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            themeColors1.TextSecondary = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(125)))), ((int)(((byte)(132)))));
            themeColors1.WindowBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.dgvMainView.HeaderBackColor = themeColors1.SurfaceColor;
            this.dgvMainView.HeaderFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvMainView.HeaderForeColor = themeColors1.TextPrimary;
            this.dgvMainView.HeaderHeight = 52;
            this.dgvMainView.Location = new System.Drawing.Point(3, 165);
            this.dgvMainView.Name = "dgvMainView";
            this.dgvMainView.RowHeadersVisible = false;
            this.dgvMainView.RowHeadersWidth = 20;
            this.dgvMainView.RowHeight = 34;
            this.dgvMainView.RowTemplate.Height = 34;
            this.dgvMainView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMainView.Size = new System.Drawing.Size(871, 524);
            this.dgvMainView.StandardTab = true;
            this.dgvMainView.TabIndex = 8;
            this.dgvMainView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMainView_CellClick);
            this.dgvMainView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvMainView_DataError);
            this.dgvMainView.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMainView_RowLeave);
            // 
            // Column_check
            // 
            this.Column_check.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column_check.DataPropertyName = "check";
            this.Column_check.FalseValue = "0";
            this.Column_check.Frozen = true;
            this.Column_check.HeaderText = "Check";
            this.Column_check.IndeterminateValue = "0";
            this.Column_check.Name = "Column_check";
            this.Column_check.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column_check.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column_check.ToolTipText = "Check";
            this.Column_check.TrueValue = "1";
            this.Column_check.Width = 45;
            // 
            // Column_id
            // 
            this.Column_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column_id.DataPropertyName = "id";
            this.Column_id.HeaderText = "id";
            this.Column_id.Name = "Column_id";
            this.Column_id.ReadOnly = true;
            this.Column_id.Visible = false;
            this.Column_id.Width = 40;
            // 
            // Column_index
            // 
            this.Column_index.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column_index.DataPropertyName = "idxnumber";
            this.Column_index.Frozen = true;
            this.Column_index.HeaderText = "No.";
            this.Column_index.Name = "Column_index";
            this.Column_index.ReadOnly = true;
            this.Column_index.Width = 40;
            // 
            // Column_textlength
            // 
            this.Column_textlength.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column_textlength.DataPropertyName = "textlength";
            this.Column_textlength.Frozen = true;
            this.Column_textlength.HeaderText = "Length";
            this.Column_textlength.Name = "Column_textlength";
            this.Column_textlength.ReadOnly = true;
            this.Column_textlength.Width = 55;
            // 
            // Column_audiolink
            // 
            this.Column_audiolink.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column_audiolink.DataPropertyName = "audiolink";
            this.Column_audiolink.Frozen = true;
            this.Column_audiolink.HeaderText = "Audio Link";
            this.Column_audiolink.Name = "Column_audiolink";
            this.Column_audiolink.ReadOnly = true;
            this.Column_audiolink.Width = 80;
            // 
            // Column_audioTime
            // 
            this.Column_audioTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column_audioTime.DataPropertyName = "audiotime";
            this.Column_audioTime.Frozen = true;
            this.Column_audioTime.HeaderText = "Audio Time";
            this.Column_audioTime.Name = "Column_audioTime";
            this.Column_audioTime.ReadOnly = true;
            this.Column_audioTime.Width = 75;
            // 
            // Column_audiostatus
            // 
            this.Column_audiostatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column_audiostatus.DataPropertyName = "audiostatus";
            this.Column_audiostatus.HeaderText = "Audio Status";
            this.Column_audiostatus.Name = "Column_audiostatus";
            this.Column_audiostatus.ReadOnly = true;
            this.Column_audiostatus.Width = 80;
            // 
            // Column_filemediapath
            // 
            this.Column_filemediapath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column_filemediapath.DataPropertyName = "filemediapath";
            this.Column_filemediapath.HeaderText = "File Media";
            this.Column_filemediapath.Name = "Column_filemediapath";
            this.Column_filemediapath.ReadOnly = true;
            this.Column_filemediapath.Width = 80;
            // 
            // Column_timevideo
            // 
            this.Column_timevideo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column_timevideo.DataPropertyName = "timevideo";
            this.Column_timevideo.HeaderText = "Time Video";
            this.Column_timevideo.Name = "Column_timevideo";
            this.Column_timevideo.Width = 75;
            // 
            // Column_renderstatus
            // 
            this.Column_renderstatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column_renderstatus.DataPropertyName = "renderstatus";
            this.Column_renderstatus.HeaderText = "Render Status";
            this.Column_renderstatus.Name = "Column_renderstatus";
            this.Column_renderstatus.ReadOnly = true;
            this.Column_renderstatus.Width = 90;
            // 
            // Column_inputtext
            // 
            this.Column_inputtext.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_inputtext.DataPropertyName = "inputtext";
            this.Column_inputtext.HeaderText = "Input Text";
            this.Column_inputtext.Name = "Column_inputtext";
            this.Column_inputtext.ReadOnly = true;
            // 
            // tsMenuView
            // 
            this.tsMenuView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(216)))), ((int)(((byte)(233)))));
            this.tsMenuView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator6,
            this.hostBtnSearch,
            this.toolStripSeparator8,
            this.txtTim,
            this.toolStripSeparator7,
            this.hostBtnSelectAll,
            this.toolStripSeparator4,
            this.lbTitle,
            this.toolStripSeparator1,
            this.hostBtnAddRow,
            this.toolStripSeparator2,
            this.hostBtnImportSubtitle,
            this.toolStripSeparator3,
            this.hostBtnDestroyAction});
            this.tsMenuView.Location = new System.Drawing.Point(0, 142);
            this.tsMenuView.Name = "tsMenuView";
            this.tsMenuView.Size = new System.Drawing.Size(877, 20);
            this.tsMenuView.TabIndex = 1;
            this.tsMenuView.Text = "toolStrip5";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 20);
            // 
            // hostBtnSearch
            // 
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(24, 22);
            this.btnSearch.Text = "";
            this.btnSearch.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnSearch.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(235)))), ((int)(((byte)(245)))));
            this.btnSearch.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.btnSearch.TextColor = System.Drawing.Color.Black;
            this.btnSearch.TextHoverColor = System.Drawing.Color.Black;
            this.btnSearch.BorderRadius = 8;
            this.btnSearch.BorderSize = 0;
            this.btnSearch.IconImage = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            // 
            // hostBtnSearch
            // 
            this.hostBtnSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.hostBtnSearch.AutoSize = false;
            this.hostBtnSearch.BackColor = System.Drawing.Color.Transparent;
            this.hostBtnSearch.ForeColor = System.Drawing.Color.Black;
            this.hostBtnSearch.Margin = new System.Windows.Forms.Padding(0);
            this.hostBtnSearch.Name = "hostBtnSearch";
            this.hostBtnSearch.Size = new System.Drawing.Size(26, 25);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 20);
            // 
            // txtTim
            // 
            this.txtTim.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.txtTim.BackColor = System.Drawing.Color.White;
            this.txtTim.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTim.Font = new System.Drawing.Font("Tahoma", 7F);
            this.txtTim.Name = "txtTim";
            this.txtTim.Size = new System.Drawing.Size(150, 20);
            this.txtTim.ToolTipText = "Nhập thông tin cần tìm vào đây";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 20);
            // 
            // hostBtnSelectAll
            // 
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(24, 22);
            this.btnSelectAll.Tag = "0";
            this.btnSelectAll.Text = "";
            this.btnSelectAll.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnSelectAll.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(235)))), ((int)(((byte)(245)))));
            this.btnSelectAll.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.btnSelectAll.TextColor = System.Drawing.Color.Black;
            this.btnSelectAll.TextHoverColor = System.Drawing.Color.Black;
            this.btnSelectAll.BorderRadius = 8;
            this.btnSelectAll.BorderSize = 0;
            this.btnSelectAll.IconImage = ((System.Drawing.Image)(resources.GetObject("btnSelectAll.Image")));
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // hostBtnSelectAll
            // 
            this.hostBtnSelectAll.AutoSize = false;
            this.hostBtnSelectAll.BackColor = System.Drawing.Color.Transparent;
            this.hostBtnSelectAll.ForeColor = System.Drawing.Color.Black;
            this.hostBtnSelectAll.Margin = new System.Windows.Forms.Padding(0);
            this.hostBtnSelectAll.Name = "hostBtnSelectAll";
            this.hostBtnSelectAll.Size = new System.Drawing.Size(26, 25);
            this.hostBtnSelectAll.ToolTipText = "Chọn/Không chọn tất cả";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 20);
            // 
            // lbTitle
            // 
            this.lbTitle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(71, 17);
            this.lbTitle.Text = "Chọn Tác Vụ";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 20);
            // 
            // hostBtnAddRow
            // 
            this.btnAddRow.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Margin = new System.Windows.Forms.Padding(0);
            this.btnAddRow.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.btnAddRow.Size = new System.Drawing.Size(140, 30);
            this.btnAddRow.Text = "Thêm Dòng Mới";
            this.btnAddRow.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAddRow.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(245)))), ((int)(((byte)(110)))));
            this.btnAddRow.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(230)))), ((int)(((byte)(95)))));
            this.btnAddRow.TextColor = System.Drawing.Color.Black;
            this.btnAddRow.TextHoverColor = System.Drawing.Color.Black;
            this.btnAddRow.BorderRadius = 10;
            this.btnAddRow.BorderSize = 0;
            this.btnAddRow.IconImage = global::EasyClip.Properties.Resources.add_1;
            this.btnAddRow.IconPosition = ReviewMovie.Base.Controls.Common.UiIconPosition.Left;
            this.btnAddRow.IconPadding = 6;
            this.btnAddRow.IconSize = new System.Drawing.Size(16, 16);
            this.btnAddRow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click);
            // 
            // hostBtnAddRow
            // 
            this.hostBtnAddRow.AutoSize = false;
            this.hostBtnAddRow.BackColor = System.Drawing.Color.Transparent;
            this.hostBtnAddRow.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hostBtnAddRow.ForeColor = System.Drawing.Color.Black;
            this.hostBtnAddRow.Margin = new System.Windows.Forms.Padding(0);
            this.hostBtnAddRow.Name = "hostBtnAddRow";
            this.hostBtnAddRow.Size = new System.Drawing.Size(150, 34);
            this.hostBtnAddRow.Text = "Thêm Dòng Mới";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 20);
            // 
            // hostBtnImportSubtitle
            // 
            this.btnImportSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportSubtitle.Name = "btnImportSubtitle";
            this.btnImportSubtitle.Margin = new System.Windows.Forms.Padding(0);
            this.btnImportSubtitle.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.btnImportSubtitle.Size = new System.Drawing.Size(165, 30);
            this.btnImportSubtitle.Text = "Nhập Subtitle (Auto)";
            this.btnImportSubtitle.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnImportSubtitle.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(170)))));
            this.btnImportSubtitle.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(150)))));
            this.btnImportSubtitle.TextColor = System.Drawing.Color.Black;
            this.btnImportSubtitle.TextHoverColor = System.Drawing.Color.Black;
            this.btnImportSubtitle.BorderRadius = 10;
            this.btnImportSubtitle.BorderSize = 0;
            this.btnImportSubtitle.IconImage = global::EasyClip.Properties.Resources.quick_edit;
            this.btnImportSubtitle.IconPosition = ReviewMovie.Base.Controls.Common.UiIconPosition.Left;
            this.btnImportSubtitle.IconPadding = 6;
            this.btnImportSubtitle.IconSize = new System.Drawing.Size(16, 16);
            this.btnImportSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnImportSubtitle.Click += new System.EventHandler(this.btnImportSubtitle_Click);
            // 
            // hostBtnImportSubtitle
            // 
            this.hostBtnImportSubtitle.AutoSize = false;
            this.hostBtnImportSubtitle.BackColor = System.Drawing.Color.Transparent;
            this.hostBtnImportSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hostBtnImportSubtitle.ForeColor = System.Drawing.Color.Black;
            this.hostBtnImportSubtitle.Margin = new System.Windows.Forms.Padding(0);
            this.hostBtnImportSubtitle.Name = "hostBtnImportSubtitle";
            this.hostBtnImportSubtitle.Size = new System.Drawing.Size(175, 34);
            this.hostBtnImportSubtitle.Text = "Nhập Subtitle (Auto)";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 20);
            // 
            // hostBtnDestroyAction
            // 
            this.btnDestroyAction.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDestroyAction.Name = "btnDestroyAction";
            this.btnDestroyAction.Margin = new System.Windows.Forms.Padding(0);
            this.btnDestroyAction.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.btnDestroyAction.Size = new System.Drawing.Size(160, 30);
            this.btnDestroyAction.Text = "&Hủy Mọi Hoạt Động";
            this.btnDestroyAction.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnDestroyAction.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(210)))), ((int)(((byte)(175)))));
            this.btnDestroyAction.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(195)))), ((int)(((byte)(160)))));
            this.btnDestroyAction.TextColor = System.Drawing.Color.Black;
            this.btnDestroyAction.TextHoverColor = System.Drawing.Color.Black;
            this.btnDestroyAction.BorderRadius = 10;
            this.btnDestroyAction.BorderSize = 0;
            this.btnDestroyAction.IconImage = ((System.Drawing.Image)(resources.GetObject("btnDestroyAction.Image")));
            this.btnDestroyAction.IconPosition = ReviewMovie.Base.Controls.Common.UiIconPosition.Left;
            this.btnDestroyAction.IconPadding = 6;
            this.btnDestroyAction.IconSize = new System.Drawing.Size(16, 16);
            this.btnDestroyAction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDestroyAction.Click += new System.EventHandler(this.btnDestroyAction_Click);
            // 
            // hostBtnDestroyAction
            // 
            this.hostBtnDestroyAction.AutoSize = false;
            this.hostBtnDestroyAction.BackColor = System.Drawing.Color.Transparent;
            this.hostBtnDestroyAction.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hostBtnDestroyAction.ForeColor = System.Drawing.Color.Black;
            this.hostBtnDestroyAction.Margin = new System.Windows.Forms.Padding(0);
            this.hostBtnDestroyAction.Name = "hostBtnDestroyAction";
            this.hostBtnDestroyAction.Size = new System.Drawing.Size(170, 34);
            this.hostBtnDestroyAction.Text = "&Hủy Mọi Hoạt Động";
            this.hostBtnDestroyAction.ToolTipText = "&Hủy Mọi Hoạt Động";
            // 
            // grViewHeader
            // 
            this.grViewHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(216)))), ((int)(((byte)(233)))));
            this.grViewHeader.Controls.Add(this.tlpViewHeader);
            this.grViewHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grViewHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grViewHeader.Location = new System.Drawing.Point(3, 3);
            this.grViewHeader.Name = "grViewHeader";
            this.grViewHeader.Size = new System.Drawing.Size(871, 136);
            this.grViewHeader.TabIndex = 0;
            this.grViewHeader.TabStop = false;
            this.grViewHeader.Text = "Mic In";
            // 
            // tlpViewHeader
            // 
            this.tlpViewHeader.BackgroundColor = System.Drawing.Color.Transparent;
            this.tlpViewHeader.BorderColorEx = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(239)))));
            this.tlpViewHeader.BorderRadius = 0;
            this.tlpViewHeader.BorderSizeEx = 0;
            this.tlpViewHeader.BorderStyleEx = ReviewMovie.Base.Controls.Common.UiBorderStyle.None;
            this.tlpViewHeader.ColumnCount = 4;
            this.tlpViewHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.76289F));
            this.tlpViewHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 81.23711F));
            this.tlpViewHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 156F));
            this.tlpViewHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 173F));
            this.tlpViewHeader.Controls.Add(this.tlpImportMedia, 2, 0);
            this.tlpViewHeader.Controls.Add(this.btnRecord, 0, 0);
            this.tlpViewHeader.Controls.Add(this.tlpText, 1, 0);
            this.tlpViewHeader.Controls.Add(this.tlpHeaderButton, 3, 0);
            this.tlpViewHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpViewHeader.Location = new System.Drawing.Point(3, 16);
            this.tlpViewHeader.Name = "tlpViewHeader";
            this.tlpViewHeader.RowCount = 1;
            this.tlpViewHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpViewHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpViewHeader.Size = new System.Drawing.Size(865, 117);
            this.tlpViewHeader.TabIndex = 0;
            // 
            // tlpImportMedia
            // 
            this.tlpImportMedia.BackgroundColor = System.Drawing.Color.Transparent;
            this.tlpImportMedia.BorderColorEx = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(239)))));
            this.tlpImportMedia.BorderRadius = 0;
            this.tlpImportMedia.BorderSizeEx = 0;
            this.tlpImportMedia.BorderStyleEx = ReviewMovie.Base.Controls.Common.UiBorderStyle.None;
            this.tlpImportMedia.ColumnCount = 1;
            this.tlpImportMedia.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpImportMedia.Controls.Add(this.txtImPortMedia, 0, 1);
            this.tlpImportMedia.Controls.Add(this.lbHeaderInputMedia, 0, 0);
            this.tlpImportMedia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpImportMedia.Location = new System.Drawing.Point(538, 3);
            this.tlpImportMedia.Name = "tlpImportMedia";
            this.tlpImportMedia.RowCount = 2;
            this.tlpImportMedia.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpImportMedia.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tlpImportMedia.Size = new System.Drawing.Size(150, 111);
            this.tlpImportMedia.TabIndex = 2;
            // 
            // txtImPortMedia
            // 
            this.txtImPortMedia.AllowDrop = true;
            this.txtImPortMedia.BackColor = System.Drawing.Color.Transparent;
            this.txtImPortMedia.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.txtImPortMedia.BorderColor = themeColors1.Border;
            this.txtImPortMedia.BorderFocusColor = themeColors1.BorderFocus;
            this.txtImPortMedia.BorderRadius = 4;
            this.txtImPortMedia.DisableTextBox = false;
            this.txtImPortMedia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtImPortMedia.HoverColor = themeColors1.Hover;
            this.txtImPortMedia.IconLeft = null;
            this.txtImPortMedia.IconRight = null;
            this.txtImPortMedia.IconSize = new System.Drawing.Size(18, 18);
            this.txtImPortMedia.Lines = new string[0];
            this.txtImPortMedia.Location = new System.Drawing.Point(1, 26);
            this.txtImPortMedia.Margin = new System.Windows.Forms.Padding(1);
            this.txtImPortMedia.MaxLength = 32767;
            this.txtImPortMedia.Multiline = true;
            this.txtImPortMedia.Name = "txtImPortMedia";
            this.txtImPortMedia.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);
            this.txtImPortMedia.ReadOnly = true;
            this.txtImPortMedia.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtImPortMedia.SelectionLength = 0;
            this.txtImPortMedia.SelectionStart = 0;
            this.txtImPortMedia.Size = new System.Drawing.Size(148, 84);
            this.txtImPortMedia.TabIndex = 2;
            this.txtImPortMedia.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtImPortMedia.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.txtImPortMedia.UseSystemPasswordChar = false;
            this.txtImPortMedia.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtImPortMedia_DragDrop);
            this.txtImPortMedia.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtImPortMedia_DragEnter);
            // 
            // lbHeaderInputMedia
            // 
            this.lbHeaderInputMedia.BackColor = System.Drawing.Color.Transparent;
            this.lbHeaderInputMedia.BackgroundColor = System.Drawing.Color.SteelBlue;
            this.lbHeaderInputMedia.BorderColor = System.Drawing.Color.Transparent;
            this.lbHeaderInputMedia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbHeaderInputMedia.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbHeaderInputMedia.ForeColor = System.Drawing.Color.White;
            this.lbHeaderInputMedia.Location = new System.Drawing.Point(1, 1);
            this.lbHeaderInputMedia.Margin = new System.Windows.Forms.Padding(1);
            this.lbHeaderInputMedia.Name = "lbHeaderInputMedia";
            this.lbHeaderInputMedia.Size = new System.Drawing.Size(148, 23);
            this.lbHeaderInputMedia.TabIndex = 1;
            this.lbHeaderInputMedia.Text = "Kéo Thả (Ảnh , Video)";
            this.lbHeaderInputMedia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbHeaderInputMedia.TextColor = System.Drawing.Color.White;
            // 
            // btnRecord
            // 
            this.btnRecord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnRecord.BackgroundColor = System.Drawing.Color.White;
            this.btnRecord.BorderColor = System.Drawing.Color.Transparent;
            this.btnRecord.BorderHoverColor = System.Drawing.Color.Transparent;
            this.btnRecord.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRecord.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.btnRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecord.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecord.ForeColor = System.Drawing.Color.DimGray;
            this.btnRecord.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(138)))), ((int)(((byte)(26)))));
            this.btnRecord.IconImage = null;
            this.btnRecord.IconSize = new System.Drawing.Size(18, 18);
            this.btnRecord.Image = global::EasyClip.Properties.Resources.ivoice;
            this.btnRecord.ImageAlignEx = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnRecord.Location = new System.Drawing.Point(3, 3);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(108)))), ((int)(((byte)(0)))));
            this.btnRecord.Size = new System.Drawing.Size(94, 111);
            this.btnRecord.TabIndex = 0;
            this.btnRecord.Text = "Record";
            this.btnRecord.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRecord.TextColor = System.Drawing.Color.DimGray;
            this.btnRecord.TextHoverColor = System.Drawing.Color.DimGray;
            this.btnRecord.UseVisualStyleBackColor = true;
            this.btnRecord.Click += new System.EventHandler(this.btnRecord_Click);
            // 
            // tlpText
            // 
            this.tlpText.BackgroundColor = System.Drawing.Color.Transparent;
            this.tlpText.BorderColorEx = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(239)))));
            this.tlpText.BorderRadius = 0;
            this.tlpText.BorderSizeEx = 0;
            this.tlpText.BorderStyleEx = ReviewMovie.Base.Controls.Common.UiBorderStyle.None;
            this.tlpText.ColumnCount = 1;
            this.tlpText.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpText.Controls.Add(this.lbHeaderText, 0, 0);
            this.tlpText.Controls.Add(this.txtTextInput, 0, 1);
            this.tlpText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpText.Location = new System.Drawing.Point(103, 3);
            this.tlpText.Name = "tlpText";
            this.tlpText.RowCount = 2;
            this.tlpText.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpText.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tlpText.Size = new System.Drawing.Size(429, 111);
            this.tlpText.TabIndex = 1;
            // 
            // lbHeaderText
            // 
            this.lbHeaderText.BackColor = System.Drawing.Color.Transparent;
            this.lbHeaderText.BackgroundColor = System.Drawing.Color.SteelBlue;
            this.lbHeaderText.BorderColor = System.Drawing.Color.Transparent;
            this.lbHeaderText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbHeaderText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHeaderText.ForeColor = System.Drawing.Color.White;
            this.lbHeaderText.Location = new System.Drawing.Point(1, 1);
            this.lbHeaderText.Margin = new System.Windows.Forms.Padding(1);
            this.lbHeaderText.Name = "lbHeaderText";
            this.lbHeaderText.Size = new System.Drawing.Size(427, 23);
            this.lbHeaderText.TabIndex = 0;
            this.lbHeaderText.Text = "Nhập Text | Hoặc Kéo Audio File Vào !";
            this.lbHeaderText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbHeaderText.TextColor = System.Drawing.Color.White;
            // 
            // txtTextInput
            // 
            this.txtTextInput.AllowDrop = true;
            this.txtTextInput.BackColor = System.Drawing.Color.Transparent;
            this.txtTextInput.BackgroundColor = System.Drawing.Color.White;
            this.txtTextInput.BorderColor = themeColors1.Border;
            this.txtTextInput.BorderFocusColor = themeColors1.BorderFocus;
            this.txtTextInput.BorderRadius = 4;
            this.txtTextInput.DisableTextBox = false;
            this.txtTextInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTextInput.HoverColor = themeColors1.Hover;
            this.txtTextInput.IconLeft = null;
            this.txtTextInput.IconRight = null;
            this.txtTextInput.IconSize = new System.Drawing.Size(18, 18);
            this.txtTextInput.Lines = new string[0];
            this.txtTextInput.Location = new System.Drawing.Point(3, 28);
            this.txtTextInput.MaxLength = 32767;
            this.txtTextInput.Multiline = true;
            this.txtTextInput.Name = "txtTextInput";
            this.txtTextInput.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);
            this.txtTextInput.ReadOnly = false;
            this.txtTextInput.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtTextInput.SelectionLength = 0;
            this.txtTextInput.SelectionStart = 0;
            this.txtTextInput.Size = new System.Drawing.Size(423, 80);
            this.txtTextInput.TabIndex = 1;
            this.txtTextInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtTextInput.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.txtTextInput.UseSystemPasswordChar = false;
            this.txtTextInput.TextChanged += new System.EventHandler(this.txtTextInput_TextChanged);
            this.txtTextInput.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtTextInput_DragDrop);
            this.txtTextInput.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtTextInput_DragEnter);
            // 
            // tlpHeaderButton
            // 
            this.tlpHeaderButton.BackgroundColor = System.Drawing.Color.Transparent;
            this.tlpHeaderButton.BorderColorEx = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(239)))));
            this.tlpHeaderButton.BorderRadius = 0;
            this.tlpHeaderButton.BorderSizeEx = 0;
            this.tlpHeaderButton.BorderStyleEx = ReviewMovie.Base.Controls.Common.UiBorderStyle.None;
            this.tlpHeaderButton.ColumnCount = 1;
            this.tlpHeaderButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpHeaderButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpHeaderButton.Controls.Add(this.btnRenderVideoPart, 0, 2);
            this.tlpHeaderButton.Controls.Add(this.btnConvertAudio, 0, 0);
            this.tlpHeaderButton.Controls.Add(this.btnSaveAudio, 0, 1);
            this.tlpHeaderButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpHeaderButton.Location = new System.Drawing.Point(694, 3);
            this.tlpHeaderButton.Name = "tlpHeaderButton";
            this.tlpHeaderButton.RowCount = 3;
            this.tlpHeaderButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpHeaderButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpHeaderButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tlpHeaderButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpHeaderButton.Size = new System.Drawing.Size(168, 111);
            this.tlpHeaderButton.TabIndex = 3;
            // 
            // btnRenderVideoPart
            // 
            this.btnRenderVideoPart.BackColor = System.Drawing.SystemColors.Control;
            this.btnRenderVideoPart.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(122)))), ((int)(((byte)(0)))));
            this.btnRenderVideoPart.BorderColor = System.Drawing.Color.Transparent;
            this.btnRenderVideoPart.BorderHoverColor = System.Drawing.Color.Transparent;
            this.btnRenderVideoPart.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.btnRenderVideoPart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRenderVideoPart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRenderVideoPart.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRenderVideoPart.ForeColor = System.Drawing.Color.White;
            this.btnRenderVideoPart.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(138)))), ((int)(((byte)(26)))));
            this.btnRenderVideoPart.IconImage = null;
            this.btnRenderVideoPart.IconSize = new System.Drawing.Size(18, 18);
            this.btnRenderVideoPart.ImageAlignEx = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnRenderVideoPart.Location = new System.Drawing.Point(4, 68);
            this.btnRenderVideoPart.Margin = new System.Windows.Forms.Padding(4);
            this.btnRenderVideoPart.Name = "btnRenderVideoPart";
            this.btnRenderVideoPart.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(108)))), ((int)(((byte)(0)))));
            this.btnRenderVideoPart.Size = new System.Drawing.Size(160, 39);
            this.btnRenderVideoPart.TabIndex = 3;
            this.btnRenderVideoPart.Text = "Render Part";
            this.btnRenderVideoPart.TextColor = System.Drawing.Color.White;
            this.btnRenderVideoPart.TextHoverColor = System.Drawing.Color.White;
            this.btnRenderVideoPart.UseVisualStyleBackColor = false;
            this.btnRenderVideoPart.Click += new System.EventHandler(this.btnRenderVideoPart_Click);
            // 
            // btnConvertAudio
            // 
            this.btnConvertAudio.BackColor = System.Drawing.SystemColors.Control;
            this.btnConvertAudio.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(122)))), ((int)(((byte)(0)))));
            this.btnConvertAudio.BorderColor = System.Drawing.Color.Transparent;
            this.btnConvertAudio.BorderHoverColor = System.Drawing.Color.Transparent;
            this.btnConvertAudio.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.btnConvertAudio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnConvertAudio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConvertAudio.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConvertAudio.ForeColor = System.Drawing.Color.White;
            this.btnConvertAudio.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(138)))), ((int)(((byte)(26)))));
            this.btnConvertAudio.IconImage = null;
            this.btnConvertAudio.IconSize = new System.Drawing.Size(18, 18);
            this.btnConvertAudio.ImageAlignEx = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnConvertAudio.Location = new System.Drawing.Point(4, 4);
            this.btnConvertAudio.Margin = new System.Windows.Forms.Padding(4);
            this.btnConvertAudio.Name = "btnConvertAudio";
            this.btnConvertAudio.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(108)))), ((int)(((byte)(0)))));
            this.btnConvertAudio.Size = new System.Drawing.Size(160, 24);
            this.btnConvertAudio.TabIndex = 1;
            this.btnConvertAudio.Text = "Convert Audio";
            this.btnConvertAudio.TextColor = System.Drawing.Color.White;
            this.btnConvertAudio.TextHoverColor = System.Drawing.Color.White;
            this.btnConvertAudio.UseVisualStyleBackColor = false;
            this.btnConvertAudio.Click += new System.EventHandler(this.btnConvertAudio_Click);
            // 
            // btnSaveAudio
            // 
            this.btnSaveAudio.BackColor = System.Drawing.SystemColors.Control;
            this.btnSaveAudio.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(122)))), ((int)(((byte)(0)))));
            this.btnSaveAudio.BorderColor = System.Drawing.Color.Transparent;
            this.btnSaveAudio.BorderHoverColor = System.Drawing.Color.Transparent;
            this.btnSaveAudio.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.btnSaveAudio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSaveAudio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveAudio.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveAudio.ForeColor = System.Drawing.Color.White;
            this.btnSaveAudio.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(138)))), ((int)(((byte)(26)))));
            this.btnSaveAudio.IconImage = null;
            this.btnSaveAudio.IconSize = new System.Drawing.Size(18, 18);
            this.btnSaveAudio.ImageAlignEx = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSaveAudio.Location = new System.Drawing.Point(4, 36);
            this.btnSaveAudio.Margin = new System.Windows.Forms.Padding(4);
            this.btnSaveAudio.Name = "btnSaveAudio";
            this.btnSaveAudio.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(108)))), ((int)(((byte)(0)))));
            this.btnSaveAudio.Size = new System.Drawing.Size(160, 24);
            this.btnSaveAudio.TabIndex = 2;
            this.btnSaveAudio.Text = "Save Audio";
            this.btnSaveAudio.TextColor = System.Drawing.Color.White;
            this.btnSaveAudio.TextHoverColor = System.Drawing.Color.White;
            this.btnSaveAudio.UseVisualStyleBackColor = false;
            this.btnSaveAudio.Click += new System.EventHandler(this.btnSaveAudio_Click);
            // 
            // pnlMainTopBar
            // 
            this.pnlMainTopBar.BackColor = System.Drawing.Color.White;
            this.pnlMainTopBar.Controls.Add(this.flpHeaderOptions);
            this.pnlMainTopBar.Controls.Add(this.lblMainTopSub);
            this.pnlMainTopBar.Controls.Add(this.lblMainTopTitle);
            this.pnlMainTopBar.Controls.Add(this.lblMainTopIcon);
            this.pnlMainTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMainTopBar.Location = new System.Drawing.Point(0, 0);
            this.pnlMainTopBar.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMainTopBar.Name = "pnlMainTopBar";
            this.pnlMainTopBar.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.pnlMainTopBar.Size = new System.Drawing.Size(1294, 42);
            this.pnlMainTopBar.TabIndex = 44;
            this.pnlMainTopBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlMainTopBar_MouseDown);
            // 
            // flpHeaderOptions
            // 
            this.flpHeaderOptions.AutoSize = true;
            this.flpHeaderOptions.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpHeaderOptions.BackColor = System.Drawing.Color.White;
            this.flpHeaderOptions.Controls.Add(this.lblHeaderActive);
            this.flpHeaderOptions.Controls.Add(this.lblHeaderRemaining);
            this.flpHeaderOptions.Controls.Add(this.btnHeaderHelp);
            this.flpHeaderOptions.Controls.Add(this.btnHeaderSettings);
            this.flpHeaderOptions.Controls.Add(this.btnHeaderAvatar);
            this.flpHeaderOptions.Controls.Add(this.btnWindowMinimize);
            this.flpHeaderOptions.Controls.Add(this.btnWindowClose);
            this.flpHeaderOptions.Dock = System.Windows.Forms.DockStyle.Right;
            this.flpHeaderOptions.Location = new System.Drawing.Point(944, 8);
            this.flpHeaderOptions.Margin = new System.Windows.Forms.Padding(0);
            this.flpHeaderOptions.Name = "flpHeaderOptions";
            this.flpHeaderOptions.Size = new System.Drawing.Size(340, 26);
            this.flpHeaderOptions.TabIndex = 47;
            this.flpHeaderOptions.WrapContents = false;
            this.flpHeaderOptions.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlMainTopBar_MouseDown);
            // 
            // lblHeaderActive
            // 
            this.lblHeaderActive.BackColor = System.Drawing.Color.Transparent;
            this.lblHeaderActive.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(179)))), ((int)(((byte)(126)))));
            this.lblHeaderActive.BorderColor = System.Drawing.Color.Transparent;
            this.lblHeaderActive.BorderRadius = 4;
            this.lblHeaderActive.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblHeaderActive.ForeColor = System.Drawing.Color.White;
            this.lblHeaderActive.Location = new System.Drawing.Point(0, 2);
            this.lblHeaderActive.Margin = new System.Windows.Forms.Padding(0, 2, 8, 2);
            this.lblHeaderActive.Name = "lblHeaderActive";
            this.lblHeaderActive.Size = new System.Drawing.Size(56, 22);
            this.lblHeaderActive.TabIndex = 0;
            this.lblHeaderActive.Text = "Active";
            this.lblHeaderActive.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblHeaderActive.TextColor = System.Drawing.Color.White;
            // 
            // lblHeaderRemaining
            // 
            this.lblHeaderRemaining.BackColor = System.Drawing.Color.Transparent;
            this.lblHeaderRemaining.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblHeaderRemaining.BorderColor = System.Drawing.Color.Transparent;
            this.lblHeaderRemaining.BorderRadius = 4;
            this.lblHeaderRemaining.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblHeaderRemaining.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(55)))));
            this.lblHeaderRemaining.Location = new System.Drawing.Point(64, 2);
            this.lblHeaderRemaining.Margin = new System.Windows.Forms.Padding(0, 2, 12, 2);
            this.lblHeaderRemaining.Name = "lblHeaderRemaining";
            this.lblHeaderRemaining.Size = new System.Drawing.Size(112, 22);
            this.lblHeaderRemaining.TabIndex = 1;
            this.lblHeaderRemaining.Text = "1 Day Remaining";
            this.lblHeaderRemaining.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblHeaderRemaining.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(55)))));
            // 
            // btnHeaderHelp
            // 
            this.btnHeaderHelp.BackColor = System.Drawing.Color.White;
            this.btnHeaderHelp.CornerRadius = 10;
            this.btnHeaderHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHeaderHelp.Font = new System.Drawing.Font("Segoe MDL2 Assets", 10F);
            this.btnHeaderHelp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(125)))), ((int)(((byte)(132)))));
            this.btnHeaderHelp.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.btnHeaderHelp.Location = new System.Drawing.Point(188, 0);
            this.btnHeaderHelp.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.btnHeaderHelp.Name = "btnHeaderHelp";
            this.btnHeaderHelp.NormalBackColor = System.Drawing.Color.White;
            this.btnHeaderHelp.PressedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(239)))));
            this.btnHeaderHelp.Size = new System.Drawing.Size(26, 26);
            this.btnHeaderHelp.TabIndex = 2;
            this.btnHeaderHelp.Text = "";
            this.btnHeaderHelp.UseVisualStyleBackColor = true;
            // 
            // btnHeaderSettings
            // 
            this.btnHeaderSettings.BackColor = System.Drawing.Color.White;
            this.btnHeaderSettings.CornerRadius = 10;
            this.btnHeaderSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHeaderSettings.Font = new System.Drawing.Font("Segoe MDL2 Assets", 10F);
            this.btnHeaderSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(125)))), ((int)(((byte)(132)))));
            this.btnHeaderSettings.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.btnHeaderSettings.Location = new System.Drawing.Point(220, 0);
            this.btnHeaderSettings.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.btnHeaderSettings.Name = "btnHeaderSettings";
            this.btnHeaderSettings.NormalBackColor = System.Drawing.Color.White;
            this.btnHeaderSettings.PressedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(239)))));
            this.btnHeaderSettings.Size = new System.Drawing.Size(26, 26);
            this.btnHeaderSettings.TabIndex = 3;
            this.btnHeaderSettings.Text = "";
            this.btnHeaderSettings.UseVisualStyleBackColor = true;
            // 
            // btnHeaderAvatar
            // 
            this.btnHeaderAvatar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(122)))), ((int)(((byte)(0)))));
            this.btnHeaderAvatar.CornerRadius = 13;
            this.btnHeaderAvatar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHeaderAvatar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnHeaderAvatar.ForeColor = System.Drawing.Color.White;
            this.btnHeaderAvatar.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(138)))), ((int)(((byte)(26)))));
            this.btnHeaderAvatar.Location = new System.Drawing.Point(252, 0);
            this.btnHeaderAvatar.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.btnHeaderAvatar.Name = "btnHeaderAvatar";
            this.btnHeaderAvatar.NormalBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(122)))), ((int)(((byte)(0)))));
            this.btnHeaderAvatar.PressedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(108)))), ((int)(((byte)(0)))));
            this.btnHeaderAvatar.Size = new System.Drawing.Size(26, 26);
            this.btnHeaderAvatar.TabIndex = 4;
            this.btnHeaderAvatar.Text = "TN";
            this.btnHeaderAvatar.UseVisualStyleBackColor = true;
            // 
            // btnWindowMinimize
            // 
            this.btnWindowMinimize.BackColor = System.Drawing.Color.White;
            this.btnWindowMinimize.CornerRadius = 10;
            this.btnWindowMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWindowMinimize.Font = new System.Drawing.Font("Segoe MDL2 Assets", 10F);
            this.btnWindowMinimize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(125)))), ((int)(((byte)(132)))));
            this.btnWindowMinimize.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.btnWindowMinimize.Location = new System.Drawing.Point(288, 0);
            this.btnWindowMinimize.Margin = new System.Windows.Forms.Padding(0);
            this.btnWindowMinimize.Name = "btnWindowMinimize";
            this.btnWindowMinimize.NormalBackColor = System.Drawing.Color.White;
            this.btnWindowMinimize.PressedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(239)))));
            this.btnWindowMinimize.Size = new System.Drawing.Size(26, 26);
            this.btnWindowMinimize.TabIndex = 46;
            this.btnWindowMinimize.Text = "";
            this.btnWindowMinimize.UseVisualStyleBackColor = true;
            this.btnWindowMinimize.Click += new System.EventHandler(this.btnWindowMinimize_Click);
            // 
            // btnWindowClose
            // 
            this.btnWindowClose.BackColor = System.Drawing.Color.White;
            this.btnWindowClose.CornerRadius = 10;
            this.btnWindowClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWindowClose.Font = new System.Drawing.Font("Segoe MDL2 Assets", 10F);
            this.btnWindowClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(125)))), ((int)(((byte)(132)))));
            this.btnWindowClose.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.btnWindowClose.Location = new System.Drawing.Point(314, 0);
            this.btnWindowClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnWindowClose.Name = "btnWindowClose";
            this.btnWindowClose.NormalBackColor = System.Drawing.Color.White;
            this.btnWindowClose.PressedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(239)))));
            this.btnWindowClose.Size = new System.Drawing.Size(26, 26);
            this.btnWindowClose.TabIndex = 45;
            this.btnWindowClose.Text = "";
            this.btnWindowClose.UseVisualStyleBackColor = true;
            this.btnWindowClose.Click += new System.EventHandler(this.btnWindowClose_Click);
            // 
            // lblMainTopSub
            // 
            this.lblMainTopSub.BackColor = System.Drawing.Color.Transparent;
            this.lblMainTopSub.BackgroundColor = System.Drawing.Color.Transparent;
            this.lblMainTopSub.BorderColor = System.Drawing.Color.Transparent;
            this.lblMainTopSub.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblMainTopSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(145)))), ((int)(((byte)(165)))));
            this.lblMainTopSub.Location = new System.Drawing.Point(34, 26);
            this.lblMainTopSub.Name = "lblMainTopSub";
            this.lblMainTopSub.Size = new System.Drawing.Size(90, 12);
            this.lblMainTopSub.TabIndex = 2;
            this.lblMainTopSub.Text = "TPMEDIA PREMIUM";
            this.lblMainTopSub.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMainTopSub.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(145)))), ((int)(((byte)(165)))));
            this.lblMainTopSub.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlMainTopBar_MouseDown);
            // 
            // lblMainTopTitle
            // 
            this.lblMainTopTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblMainTopTitle.BackgroundColor = System.Drawing.Color.Transparent;
            this.lblMainTopTitle.BorderColor = System.Drawing.Color.Transparent;
            this.lblMainTopTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblMainTopTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(55)))));
            this.lblMainTopTitle.Location = new System.Drawing.Point(34, 10);
            this.lblMainTopTitle.Name = "lblMainTopTitle";
            this.lblMainTopTitle.Size = new System.Drawing.Size(93, 17);
            this.lblMainTopTitle.TabIndex = 1;
            this.lblMainTopTitle.Text = "EasyClip Studio";
            this.lblMainTopTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMainTopTitle.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(55)))));
            this.lblMainTopTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlMainTopBar_MouseDown);
            // 
            // lblMainTopIcon
            // 
            this.lblMainTopIcon.BackColor = System.Drawing.Color.Transparent;
            this.lblMainTopIcon.BackgroundColor = System.Drawing.Color.Transparent;
            this.lblMainTopIcon.BorderColor = System.Drawing.Color.Transparent;
            this.lblMainTopIcon.Font = new System.Drawing.Font("Segoe MDL2 Assets", 12F);
            this.lblMainTopIcon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
            this.lblMainTopIcon.Location = new System.Drawing.Point(12, 12);
            this.lblMainTopIcon.Name = "lblMainTopIcon";
            this.lblMainTopIcon.Size = new System.Drawing.Size(18, 18);
            this.lblMainTopIcon.TabIndex = 0;
            this.lblMainTopIcon.Text = "";
            this.lblMainTopIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMainTopIcon.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
            this.lblMainTopIcon.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlMainTopBar_MouseDown);
            // 
            // scMain
            // 
            this.scMain.BorderColorEx = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(239)))));
            this.scMain.BorderRadius = 0;
            this.scMain.BorderSizeEx = 0;
            this.scMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.scMain.IsSplitterFixed = true;
            this.scMain.Location = new System.Drawing.Point(0, 42);
            this.scMain.Name = "scMain";
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.scView);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.scSetting);
            this.scMain.Size = new System.Drawing.Size(1294, 694);
            this.scMain.SplitterColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(239)))));
            this.scMain.SplitterDistance = 910;
            this.scMain.TabIndex = 43;
            // 
            // scView
            // 
            this.scView.BorderColorEx = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(239)))));
            this.scView.BorderRadius = 0;
            this.scView.BorderSizeEx = 0;
            this.scView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scView.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.scView.IsSplitterFixed = true;
            this.scView.Location = new System.Drawing.Point(0, 0);
            this.scView.Name = "scView";
            // 
            // scView.Panel1
            // 
            this.scView.Panel1.Controls.Add(this.tlpView);
            // 
            // scView.Panel2
            // 
            this.scView.Panel2.Controls.Add(this.btnExpand);
            this.scView.Size = new System.Drawing.Size(910, 694);
            this.scView.SplitterColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(239)))));
            this.scView.SplitterDistance = 879;
            this.scView.TabIndex = 47;
            // 
            // btnExpand
            // 
            this.btnExpand.BackColor = System.Drawing.SystemColors.Info;
            this.btnExpand.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(122)))), ((int)(((byte)(0)))));
            this.btnExpand.BorderColor = System.Drawing.Color.Transparent;
            this.btnExpand.BorderHoverColor = System.Drawing.Color.Transparent;
            this.btnExpand.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.btnExpand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExpand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExpand.ForeColor = System.Drawing.Color.White;
            this.btnExpand.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(138)))), ((int)(((byte)(26)))));
            this.btnExpand.IconImage = null;
            this.btnExpand.IconSize = new System.Drawing.Size(18, 18);
            this.btnExpand.ImageAlignEx = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnExpand.Location = new System.Drawing.Point(0, 0);
            this.btnExpand.Margin = new System.Windows.Forms.Padding(0);
            this.btnExpand.Name = "btnExpand";
            this.btnExpand.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(108)))), ((int)(((byte)(0)))));
            this.btnExpand.Size = new System.Drawing.Size(25, 692);
            this.btnExpand.TabIndex = 46;
            this.btnExpand.Text = ">";
            this.btnExpand.TextColor = System.Drawing.Color.White;
            this.btnExpand.TextHoverColor = System.Drawing.Color.White;
            this.btnExpand.UseVisualStyleBackColor = false;
            this.btnExpand.Visible = false;
            this.btnExpand.Click += new System.EventHandler(this.btnExpand_Click);
            // 
            // scSetting
            // 
            this.scSetting.BorderColorEx = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(239)))));
            this.scSetting.BorderRadius = 0;
            this.scSetting.BorderSizeEx = 0;
            this.scSetting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scSetting.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scSetting.IsSplitterFixed = true;
            this.scSetting.Location = new System.Drawing.Point(0, 0);
            this.scSetting.Name = "scSetting";
            // 
            // scSetting.Panel1
            // 
            this.scSetting.Panel1.Controls.Add(this.btnCollapse);
            // 
            // scSetting.Panel2
            // 
            this.scSetting.Panel2.Controls.Add(this.grboxSetting);
            this.scSetting.Panel2.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.scSetting.Size = new System.Drawing.Size(380, 694);
            this.scSetting.SplitterColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(239)))));
            this.scSetting.SplitterDistance = 27;
            this.scSetting.TabIndex = 46;
            // 
            // btnCollapse
            // 
            this.btnCollapse.BackColor = System.Drawing.SystemColors.Info;
            this.btnCollapse.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(122)))), ((int)(((byte)(0)))));
            this.btnCollapse.BorderColor = System.Drawing.Color.Transparent;
            this.btnCollapse.BorderHoverColor = System.Drawing.Color.Transparent;
            this.btnCollapse.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.btnCollapse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCollapse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCollapse.ForeColor = System.Drawing.Color.White;
            this.btnCollapse.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(138)))), ((int)(((byte)(26)))));
            this.btnCollapse.IconImage = null;
            this.btnCollapse.IconSize = new System.Drawing.Size(18, 18);
            this.btnCollapse.ImageAlignEx = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCollapse.Location = new System.Drawing.Point(0, 0);
            this.btnCollapse.Margin = new System.Windows.Forms.Padding(0);
            this.btnCollapse.Name = "btnCollapse";
            this.btnCollapse.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(108)))), ((int)(((byte)(0)))));
            this.btnCollapse.Size = new System.Drawing.Size(25, 692);
            this.btnCollapse.TabIndex = 45;
            this.btnCollapse.Text = "<";
            this.btnCollapse.TextColor = System.Drawing.Color.White;
            this.btnCollapse.TextHoverColor = System.Drawing.Color.White;
            this.btnCollapse.UseVisualStyleBackColor = false;
            this.btnCollapse.Click += new System.EventHandler(this.btnCollapse_Click);
            // 
            // FormMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(216)))), ((int)(((byte)(233)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1294, 736);
            this.Controls.Add(this.scMain);
            this.Controls.Add(this.pnlMainTopBar);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ctMenu.ResumeLayout(false);
            this.grbConfigRender.ResumeLayout(false);
            this.grbConfigRender.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbSpeechRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nScaleAudioRangeEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nScaleAudioRangeStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbThread)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbVolumnOrigin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nFPS)).EndInit();
            this.grboxSetting.ResumeLayout(false);
            this.grboxSetting.PerformLayout();
            this.grbConfigVoice.ResumeLayout(false);
            this.grbConfigVoice.PerformLayout();
            this.grbActionRender.ResumeLayout(false);
            this.grbActionRender.PerformLayout();
            this.tlpView.ResumeLayout(false);
            this.tlpView.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMainView)).EndInit();
            this.tsMenuView.ResumeLayout(false);
            this.tsMenuView.PerformLayout();
            this.grViewHeader.ResumeLayout(false);
            this.tlpViewHeader.ResumeLayout(false);
            this.tlpImportMedia.ResumeLayout(false);
            this.tlpText.ResumeLayout(false);
            this.tlpHeaderButton.ResumeLayout(false);
            this.pnlMainTopBar.ResumeLayout(false);
            this.pnlMainTopBar.PerformLayout();
            this.flpHeaderOptions.ResumeLayout(false);
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.scView.Panel1.ResumeLayout(false);
            this.scView.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scView)).EndInit();
            this.scView.ResumeLayout(false);
            this.scSetting.Panel1.ResumeLayout(false);
            this.scSetting.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scSetting)).EndInit();
            this.scSetting.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private ReviewMovie.Base.Controls.UiLabel label2;
        private ReviewMovie.Base.Controls.UiLabel lblapi;
        private ReviewMovie.Base.Controls.UiTextBox txtAppID;
        private ReviewMovie.Base.Controls.UiButton btnOpenProject;
        private ReviewMovie.Base.Controls.UiLabel lblToken;
        private ReviewMovie.Base.Controls.UiTextBox txtToken;
        private System.Windows.Forms.GroupBox grbConfigRender;
        private ReviewMovie.Base.Controls.UiLabel label5;
        private ReviewMovie.Base.Controls.UiComboBox cbxSpeechType;
        private ReviewMovie.Base.Controls.UiLabel label6;
        private ReviewMovie.Base.Controls.UiButton btnAddAll;
        private ReviewMovie.Base.Controls.UiLabel lblstatus;
        private ReviewMovie.Base.Controls.UiComboBox cboSiteNguon;
        private ReviewMovie.Base.Controls.UiLabel label1;
        private ReviewMovie.Base.Controls.UiComboBox cbMode;
        private ReviewMovie.Base.Controls.UiLabel label12;
        private ReviewMovie.Base.Controls.UiComboBox cbZoomQuality;
        private ReviewMovie.Base.Controls.UiLabel label11;
        private ReviewMovie.Base.Controls.UiNumericUpDown nFPS;
        private ReviewMovie.Base.Controls.UiLabel label10;
        private ReviewMovie.Base.Controls.UiComboBox cbZoomRatio;
        private ReviewMovie.Base.Controls.UiLabel label9;
        private ReviewMovie.Base.Controls.UiComboBox cbEffectType;
        private ReviewMovie.Base.Controls.UiLabel label8;
        private ReviewMovie.Base.Controls.UiCheckBox ckHflip;
        private ReviewMovie.Base.Controls.UiCheckBox ckRotate;
        private ReviewMovie.Base.Controls.UiCheckBox CkZoom;
        private ReviewMovie.Base.Controls.UiComboBox cbxVideoQuality;
        private ReviewMovie.Base.Controls.UiLabel label7;
        private System.Windows.Forms.GroupBox grboxSetting;
        private ReviewMovie.Base.Controls.UiCheckBox ckNotUseAudio;
        private ReviewMovie.Base.Controls.UiLabel label3;
        private System.Windows.Forms.ContextMenuStrip ctMenu;
        private System.Windows.Forms.ToolStripMenuItem MenuItemConvertTex2Speech;
        private System.Windows.Forms.ToolStripMenuItem MenuItemDownAudio;
        private System.Windows.Forms.ToolStripMenuItem MenuItemPartRender;
        private System.Windows.Forms.ToolStripMenuItem ConvertTex2SpeechAll;
        private System.Windows.Forms.ToolStripMenuItem DownAudioAll;
        private System.Windows.Forms.ToolStripMenuItem PartRenderAll;
        private ReviewMovie.Base.Controls.UiTableLayoutPanel tlpView;
        private System.Windows.Forms.GroupBox grViewHeader;
        private ReviewMovie.Base.Controls.UiTableLayoutPanel tlpViewHeader;
        private ReviewMovie.Base.Controls.UiButton btnRecord;
        private ReviewMovie.Base.Controls.UiTableLayoutPanel tlpImportMedia;
        private ReviewMovie.Base.Controls.UiTableLayoutPanel tlpText;
        private ReviewMovie.Base.Controls.UiLabel lbHeaderInputMedia;
        private ReviewMovie.Base.Controls.UiLabel lbHeaderText;
        private ReviewMovie.Base.Controls.UiTextBox txtImPortMedia;
        private ReviewMovie.Base.Controls.UiTableLayoutPanel tlpHeaderButton;
        private ReviewMovie.Base.Controls.UiButton btnRenderVideoPart;
        private ReviewMovie.Base.Controls.UiButton btnConvertAudio;
        private ReviewMovie.Base.Controls.UiButton btnSaveAudio;
        private ReviewMovie.Base.Controls.UiDataGridView dgvMainView;
        private System.Windows.Forms.ToolStrip tsMenuView;
        private System.Windows.Forms.ToolStripTextBox txtTim;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private ReviewMovie.Base.Controls.UiButton btnSelectAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripLabel lbTitle;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column_check;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_index;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_textlength;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_audiolink;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_audioTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_audiostatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_filemediapath;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_timevideo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_renderstatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_inputtext;
        private ReviewMovie.Base.Controls.UiTextBox txtTextInput;
        private ReviewMovie.Base.Controls.UiNumericUpDown nbVolumnOrigin;
        private ReviewMovie.Base.Controls.UiLabel label4;
        private ReviewMovie.Base.Controls.UiNumericUpDown nbThread;
        private ReviewMovie.Base.Controls.UiLabel label13;
        private System.Windows.Forms.ToolStripMenuItem tsMenuDeleteRow;
        private System.Windows.Forms.ToolStripMenuItem ConvertTex2SpeechSelect;
        private System.Windows.Forms.ToolStripMenuItem DownAudioAllSelect;
        private ReviewMovie.Base.Controls.UiComboBox cbProjectName;
        private System.Windows.Forms.ToolStripMenuItem PartRenderSelect;
        private ReviewMovie.Base.Controls.UiCheckBox ckHflipRandom;
        private ReviewMovie.Base.Controls.UiNumericUpDown nScaleAudioRangeStart;
        private ReviewMovie.Base.Controls.UiLabel label14;
        private ReviewMovie.Base.Controls.UiLabel label15;
        private ReviewMovie.Base.Controls.UiNumericUpDown nScaleAudioRangeEnd;
        private System.Windows.Forms.ToolStripMenuItem MenuItemReloadVideoTime;
        private System.Windows.Forms.ToolStripMenuItem tsMAll;
        private System.Windows.Forms.ToolStripMenuItem tsMSelected;
        private ReviewMovie.Base.Controls.UiComboBox cbLanguageSelect;
        private ReviewMovie.Base.Controls.UiLabel label16;
        private ReviewMovie.Base.Controls.UiButton btnSaveVoiceSource;
        private ReviewMovie.Base.Controls.UiSplitContainer scMain;
        private ReviewMovie.Base.Controls.UiButton btnCollapse;
        private ReviewMovie.Base.Controls.UiButton btnExpand;
        private ReviewMovie.Base.Controls.UiSplitContainer scView;
        private ReviewMovie.Base.Controls.UiSplitContainer scSetting;
        private ReviewMovie.Base.Controls.UiCheckBox ckRandomMoveLeftRight;
        private ReviewMovie.Base.Controls.UiButton btnSaveEffectSetting;
        private ReviewMovie.Base.Controls.UiComboBox cbSettingTemplate;
        private ReviewMovie.Base.Controls.UiLabel label17;
        private System.Windows.Forms.GroupBox grbActionRender;
        private System.Windows.Forms.GroupBox grbConfigVoice;
        private ReviewMovie.Base.Controls.UiNumericUpDown nbSpeechRatio;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private ReviewMovie.Base.Controls.UiButton btnAddRow;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private ReviewMovie.Base.Controls.UiButton btnImportSubtitle;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private ReviewMovie.Base.Controls.UiButton btnDestroyAction;
        private System.Windows.Forms.Panel pnlMainTopBar;
        private System.Windows.Forms.FlowLayoutPanel flpHeaderOptions;
        private ReviewMovie.Base.Controls.UiLabel lblHeaderActive;
        private ReviewMovie.Base.Controls.UiLabel lblHeaderRemaining;
        private ReviewMovie.Base.Controls.IconCircleButton btnHeaderHelp;
        private ReviewMovie.Base.Controls.IconCircleButton btnHeaderSettings;
        private ReviewMovie.Base.Controls.IconCircleButton btnHeaderAvatar;
        private ReviewMovie.Base.Controls.IconCircleButton btnWindowMinimize;
        private ReviewMovie.Base.Controls.IconCircleButton btnWindowClose;
        private ReviewMovie.Base.Controls.UiLabel lblMainTopSub;
        private ReviewMovie.Base.Controls.UiLabel lblMainTopTitle;
        private ReviewMovie.Base.Controls.UiLabel lblMainTopIcon;
        private ReviewMovie.Base.Controls.UiButton btnSearch;
        private ReviewMovie.Base.Controls.UiCheckBox ckOpenPlayer;
        private ReviewMovie.Base.Controls.UiButton btnSelectAll;
        private System.Windows.Forms.ToolStripControlHost hostBtnSearch;
        private System.Windows.Forms.ToolStripControlHost hostBtnSelectAll;
        private System.Windows.Forms.ToolStripControlHost hostBtnAddRow;
        private System.Windows.Forms.ToolStripControlHost hostBtnImportSubtitle;
        private System.Windows.Forms.ToolStripControlHost hostBtnDestroyAction;
    }
}

