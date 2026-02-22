
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.grbConfigRender = new ReviewMovie.Base.Controls.UiGroupBox();
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
            this.grboxSetting = new ReviewMovie.Base.Controls.UiGroupBox();
            this.grbConfigVoice = new ReviewMovie.Base.Controls.UiGroupBox();
            this.btnSaveVoiceSource = new ReviewMovie.Base.Controls.UiButton();
            this.grbActionRender = new ReviewMovie.Base.Controls.UiGroupBox();
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
            this.btnSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.txtTim = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSelectAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.lbTitle = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAddRow = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnImportSubtitle = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDestroyAction = new System.Windows.Forms.ToolStripButton();
            this.grViewHeader = new ReviewMovie.Base.Controls.UiGroupBox();
            this.tlpViewHeader = new ReviewMovie.Base.Controls.UiTableLayoutPanel();
            this.tlpImportMedia = new ReviewMovie.Base.Controls.UiTableLayoutPanel();
            this.txtImPortMedia = new System.Windows.Forms.TextBox();
            this.lbHeaderInputMedia = new ReviewMovie.Base.Controls.UiLabel();
            this.btnRecord = new ReviewMovie.Base.Controls.UiButton();
            this.tlpText = new ReviewMovie.Base.Controls.UiTableLayoutPanel();
            this.lbHeaderText = new ReviewMovie.Base.Controls.UiLabel();
            this.txtTextInput = new ReviewMovie.Base.Controls.UiTextBox();
            this.tlpHeaderButton = new ReviewMovie.Base.Controls.UiTableLayoutPanel();
            this.btnRenderVideoPart = new ReviewMovie.Base.Controls.UiButton();
            this.btnConvertAudio = new ReviewMovie.Base.Controls.UiButton();
            this.btnSaveAudio = new ReviewMovie.Base.Controls.UiButton();
            this.scMain = new ReviewMovie.Base.Controls.UiSplitContainer();
            this.scView = new ReviewMovie.Base.Controls.UiSplitContainer();
            this.btnExpand = new ReviewMovie.Base.Controls.UiButton();
            this.scSetting = new ReviewMovie.Base.Controls.UiSplitContainer();
            this.btnCollapse = new ReviewMovie.Base.Controls.UiButton();
            this.rbCPUused = new ReviewMovie.Base.Controls.UiRadioButton();
            this.rbGPUused = new ReviewMovie.Base.Controls.UiRadioButton();
            this.pnlHeaderTitle = new System.Windows.Forms.Panel();
            this.pnlHeaderBrand = new System.Windows.Forms.Panel();
            this.lblHeaderSubtitle = new System.Windows.Forms.Label();
            this.lblHeaderMainTitle = new System.Windows.Forms.Label();
            this.lblHeaderLogo = new System.Windows.Forms.Label();
            this.tlpHeaderRight = new System.Windows.Forms.TableLayoutPanel();
            this.lblHeaderActive = new System.Windows.Forms.Label();
            this.lblHeaderRemaining = new System.Windows.Forms.Label();
            this.btnHeaderHelp = new System.Windows.Forms.Button();
            this.btnHeaderSetting = new System.Windows.Forms.Button();
            this.lblHeaderAvatar = new System.Windows.Forms.Label();
            this.btnHeaderClose = new System.Windows.Forms.Button();
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
            this.pnlHeaderTitle.SuspendLayout();
            this.pnlHeaderBrand.SuspendLayout();
            this.tlpHeaderRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctMenu
            // 
            this.ctMenu.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctMenu.Renderer = new ReviewMovie.Base.Controls.UiToolStripRenderer(new ReviewMovie.Base.Controls.UiToolStripColors());
            this.ctMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemConvertTex2Speech,
            this.MenuItemDownAudio,
            this.MenuItemPartRender,
            this.MenuItemReloadVideoTime,
            this.tsMenuDeleteRow});
            this.ctMenu.Name = "contextMenuStrip1";
            this.ctMenu.Size = new System.Drawing.Size(248, 114);
            // 
            // MenuItemConvertTex2Speech
            // 
            this.MenuItemConvertTex2Speech.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ConvertTex2SpeechAll,
            this.ConvertTex2SpeechSelect});
            this.MenuItemConvertTex2Speech.Name = "MenuItemConvertTex2Speech";
            this.MenuItemConvertTex2Speech.Size = new System.Drawing.Size(247, 22);
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
            this.MenuItemDownAudio.Size = new System.Drawing.Size(247, 22);
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
            this.MenuItemPartRender.Size = new System.Drawing.Size(247, 22);
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
            this.MenuItemReloadVideoTime.Size = new System.Drawing.Size(247, 22);
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
            this.tsMenuDeleteRow.Size = new System.Drawing.Size(247, 22);
            this.tsMenuDeleteRow.Text = "Xóa Dòng Chọn";
            this.tsMenuDeleteRow.Click += new System.EventHandler(this.tsMenuDeleteRow_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Dự Án";
            // 
            // lblapi
            // 
            this.lblapi.AutoSize = true;
            this.lblapi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblapi.Location = new System.Drawing.Point(6, 45);
            this.lblapi.Name = "lblapi";
            this.lblapi.Size = new System.Drawing.Size(40, 15);
            this.lblapi.TabIndex = 8;
            this.lblapi.Text = "AppID";
            // 
            // txtAppID
            // 
            this.txtAppID.Location = new System.Drawing.Point(75, 46);
            this.txtAppID.Multiline = true;
            this.txtAppID.Name = "txtAppID";
            this.txtAppID.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAppID.Size = new System.Drawing.Size(239, 40);
            this.txtAppID.TabIndex = 9;
            this.txtAppID.Text = "???";
            this.txtAppID.TextChanged += new System.EventHandler(this.txtAppID_TextChanged);
            // 
            // btnOpenProject
            // 
            this.btnOpenProject.BackColor = System.Drawing.SystemColors.Control;
            this.btnOpenProject.Location = new System.Drawing.Point(310, 19);
            this.btnOpenProject.Name = "btnOpenProject";
            this.btnOpenProject.Size = new System.Drawing.Size(67, 25);
            this.btnOpenProject.TabIndex = 10;
            this.btnOpenProject.Text = "Create";
            this.btnOpenProject.UseVisualStyleBackColor = false;
            this.btnOpenProject.Click += new System.EventHandler(this.btnOpenProject_Click);
            // 
            // lblToken
            // 
            this.lblToken.AutoSize = true;
            this.lblToken.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToken.Location = new System.Drawing.Point(6, 96);
            this.lblToken.Name = "lblToken";
            this.lblToken.Size = new System.Drawing.Size(38, 15);
            this.lblToken.TabIndex = 11;
            this.lblToken.Text = "Token";
            // 
            // txtToken
            // 
            this.txtToken.Location = new System.Drawing.Point(75, 96);
            this.txtToken.Multiline = true;
            this.txtToken.Name = "txtToken";
            this.txtToken.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtToken.Size = new System.Drawing.Size(239, 49);
            this.txtToken.TabIndex = 12;
            this.txtToken.Text = "???";
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
            this.grbConfigRender.Location = new System.Drawing.Point(11, 209);
            this.grbConfigRender.Name = "grbConfigRender";
            this.grbConfigRender.Size = new System.Drawing.Size(365, 416);
            this.grbConfigRender.TabIndex = 14;
            this.grbConfigRender.TabStop = false;
            this.grbConfigRender.Text = "Lựa Chọn Hiệu Ứng";
            // 
            // ckOpenPlayer
            // 
            this.ckOpenPlayer.AutoSize = true;
            this.ckOpenPlayer.Checked = true;
            this.ckOpenPlayer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckOpenPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckOpenPlayer.Location = new System.Drawing.Point(84, 207);
            this.ckOpenPlayer.Name = "ckOpenPlayer";
            this.ckOpenPlayer.Size = new System.Drawing.Size(157, 20);
            this.ckOpenPlayer.TabIndex = 126;
            this.ckOpenPlayer.Text = "Tự động Mở Player";
            this.ckOpenPlayer.UseVisualStyleBackColor = true;
            this.ckOpenPlayer.CheckedChanged += new System.EventHandler(this.ckOpenPlayer_CheckedChanged);
            // 
            // nbSpeechRatio
            // 
            this.nbSpeechRatio.DecimalPlaces = 1;
            this.nbSpeechRatio.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nbSpeechRatio.Location = new System.Drawing.Point(84, 269);
            this.nbSpeechRatio.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nbSpeechRatio.Name = "nbSpeechRatio";
            this.nbSpeechRatio.Padding = new System.Windows.Forms.Padding(2);
            this.nbSpeechRatio.Size = new System.Drawing.Size(48, 22);
            this.nbSpeechRatio.TabIndex = 125;
            this.nbSpeechRatio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nbSpeechRatio.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // cbSettingTemplate
            // 
            this.cbSettingTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSettingTemplate.FormattingEnabled = true;
            this.cbSettingTemplate.Location = new System.Drawing.Point(84, 379);
            this.cbSettingTemplate.Name = "cbSettingTemplate";
            this.cbSettingTemplate.Size = new System.Drawing.Size(176, 21);
            this.cbSettingTemplate.TabIndex = 124;
            this.cbSettingTemplate.SelectedIndexChanged += new System.EventHandler(this.cbSettingTemplate_SelectedIndexChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = false;
            this.label17.Location = new System.Drawing.Point(8, 378);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(72, 22);
            this.label17.TabIndex = 123;
            this.label17.Text = "Cấu Hình :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSaveEffectSetting
            // 
            this.btnSaveEffectSetting.BackColor = System.Drawing.SystemColors.Control;
            this.btnSaveEffectSetting.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnSaveEffectSetting.ForeColor = System.Drawing.Color.Red;
            this.btnSaveEffectSetting.Location = new System.Drawing.Point(268, 377);
            this.btnSaveEffectSetting.Name = "btnSaveEffectSetting";
            this.btnSaveEffectSetting.Size = new System.Drawing.Size(70, 24);
            this.btnSaveEffectSetting.TabIndex = 45;
            this.btnSaveEffectSetting.Text = "Save";
            this.btnSaveEffectSetting.UseVisualStyleBackColor = false;
            this.btnSaveEffectSetting.Click += new System.EventHandler(this.btnSaveEffectSetting_Click);
            // 
            // ckRandomMoveLeftRight
            // 
            this.ckRandomMoveLeftRight.AutoSize = true;
            this.ckRandomMoveLeftRight.Location = new System.Drawing.Point(84, 184);
            this.ckRandomMoveLeftRight.Name = "ckRandomMoveLeftRight";
            this.ckRandomMoveLeftRight.Size = new System.Drawing.Size(212, 17);
            this.ckRandomMoveLeftRight.TabIndex = 122;
            this.ckRandomMoveLeftRight.Text = "Layer Tự Động Di Chuyển Trái <-> Phải";
            this.ckRandomMoveLeftRight.UseVisualStyleBackColor = true;
            this.ckRandomMoveLeftRight.CheckedChanged += new System.EventHandler(this.ckRandomMoveLeftRight_CheckedChanged);
            // 
            // cbLanguageSelect
            // 
            this.cbLanguageSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLanguageSelect.FormattingEnabled = true;
            this.cbLanguageSelect.Location = new System.Drawing.Point(84, 313);
            this.cbLanguageSelect.Name = "cbLanguageSelect";
            this.cbLanguageSelect.Size = new System.Drawing.Size(270, 21);
            this.cbLanguageSelect.TabIndex = 121;
            this.cbLanguageSelect.SelectedIndexChanged += new System.EventHandler(this.cbLanguageSelect_SelectedIndexChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = false;
            this.label16.Location = new System.Drawing.Point(8, 313);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(72, 22);
            this.label16.TabIndex = 120;
            this.label16.Text = "Ngôn Ngữ :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.AutoSize = false;
            this.label15.Location = new System.Drawing.Point(251, 240);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(14, 20);
            this.label15.TabIndex = 119;
            this.label15.Text = "->";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nScaleAudioRangeEnd
            // 
            this.nScaleAudioRangeEnd.DecimalPlaces = 1;
            this.nScaleAudioRangeEnd.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nScaleAudioRangeEnd.Location = new System.Drawing.Point(268, 240);
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
            this.nScaleAudioRangeEnd.Padding = new System.Windows.Forms.Padding(2);
            this.nScaleAudioRangeEnd.Size = new System.Drawing.Size(46, 22);
            this.nScaleAudioRangeEnd.TabIndex = 118;
            this.nScaleAudioRangeEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nScaleAudioRangeEnd.Value = new decimal(new int[] {
            12,
            0,
            0,
            65536});
            // 
            // nScaleAudioRangeStart
            // 
            this.nScaleAudioRangeStart.DecimalPlaces = 1;
            this.nScaleAudioRangeStart.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nScaleAudioRangeStart.Location = new System.Drawing.Point(202, 240);
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
            this.nScaleAudioRangeStart.Padding = new System.Windows.Forms.Padding(2);
            this.nScaleAudioRangeStart.Size = new System.Drawing.Size(46, 22);
            this.nScaleAudioRangeStart.TabIndex = 117;
            this.nScaleAudioRangeStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nScaleAudioRangeStart.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label14
            // 
            this.label14.AutoSize = false;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(134, 240);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 20);
            this.label14.TabIndex = 116;
            this.label14.Text = "Audio Scale";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ckHflipRandom
            // 
            this.ckHflipRandom.AutoSize = true;
            this.ckHflipRandom.ForeColor = System.Drawing.Color.Red;
            this.ckHflipRandom.Location = new System.Drawing.Point(246, 157);
            this.ckHflipRandom.Name = "ckHflipRandom";
            this.ckHflipRandom.Size = new System.Drawing.Size(84, 17);
            this.ckHflipRandom.TabIndex = 115;
            this.ckHflipRandom.Text = "Lật Random";
            this.ckHflipRandom.UseVisualStyleBackColor = true;
            this.ckHflipRandom.CheckedChanged += new System.EventHandler(this.ckHflipRandom_CheckedChanged);
            // 
            // nbThread
            // 
            this.nbThread.Location = new System.Drawing.Point(246, 47);
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
            this.nbThread.Padding = new System.Windows.Forms.Padding(2);
            this.nbThread.Size = new System.Drawing.Size(70, 22);
            this.nbThread.TabIndex = 114;
            this.nbThread.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nbThread.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label13
            // 
            this.label13.AutoSize = false;
            this.label13.Location = new System.Drawing.Point(173, 45);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(68, 22);
            this.label13.TabIndex = 113;
            this.label13.Text = "Thread :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nbVolumnOrigin
            // 
            this.nbVolumnOrigin.DecimalPlaces = 1;
            this.nbVolumnOrigin.Increment = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            this.nbVolumnOrigin.Location = new System.Drawing.Point(84, 240);
            this.nbVolumnOrigin.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nbVolumnOrigin.Name = "nbVolumnOrigin";
            this.nbVolumnOrigin.Padding = new System.Windows.Forms.Padding(2);
            this.nbVolumnOrigin.Size = new System.Drawing.Size(48, 22);
            this.nbVolumnOrigin.TabIndex = 112;
            this.nbVolumnOrigin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nbVolumnOrigin.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // label4
            // 
            this.label4.AutoSize = false;
            this.label4.Location = new System.Drawing.Point(8, 240);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 22);
            this.label4.TabIndex = 111;
            this.label4.Text = "Volumn gốc :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ckNotUseAudio
            // 
            this.ckNotUseAudio.AutoSize = true;
            this.ckNotUseAudio.Location = new System.Drawing.Point(296, 272);
            this.ckNotUseAudio.Name = "ckNotUseAudio";
            this.ckNotUseAudio.Size = new System.Drawing.Size(15, 14);
            this.ckNotUseAudio.TabIndex = 110;
            this.ckNotUseAudio.UseVisualStyleBackColor = true;
            this.ckNotUseAudio.CheckedChanged += new System.EventHandler(this.ckMuted_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = false;
            this.label3.Location = new System.Drawing.Point(198, 269);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 20);
            this.label3.TabIndex = 109;
            this.label3.Text = "Ko dùng Audio :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbMode
            // 
            this.cbMode.BackColor = System.Drawing.SystemColors.Info;
            this.cbMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMode.FormattingEnabled = true;
            this.cbMode.Location = new System.Drawing.Point(84, 120);
            this.cbMode.Name = "cbMode";
            this.cbMode.Size = new System.Drawing.Size(150, 21);
            this.cbMode.TabIndex = 108;
            this.cbMode.SelectedIndexChanged += new System.EventHandler(this.cbMode_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = false;
            this.label12.Location = new System.Drawing.Point(8, 120);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 22);
            this.label12.TabIndex = 107;
            this.label12.Text = "Lựa Chọn :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbZoomQuality
            // 
            this.cbZoomQuality.BackColor = System.Drawing.SystemColors.Info;
            this.cbZoomQuality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbZoomQuality.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbZoomQuality.FormattingEnabled = true;
            this.cbZoomQuality.Location = new System.Drawing.Point(84, 47);
            this.cbZoomQuality.Name = "cbZoomQuality";
            this.cbZoomQuality.Size = new System.Drawing.Size(90, 20);
            this.cbZoomQuality.TabIndex = 106;
            this.cbZoomQuality.SelectedIndexChanged += new System.EventHandler(this.cbZoomQuality_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = false;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(8, 45);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 22);
            this.label11.TabIndex = 105;
            this.label11.Text = "% ZQuality :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nFPS
            // 
            this.nFPS.Location = new System.Drawing.Point(246, 21);
            this.nFPS.Minimum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.nFPS.Name = "nFPS";
            this.nFPS.Padding = new System.Windows.Forms.Padding(2);
            this.nFPS.Size = new System.Drawing.Size(70, 22);
            this.nFPS.TabIndex = 104;
            this.nFPS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nFPS.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = false;
            this.label10.Location = new System.Drawing.Point(173, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 20);
            this.label10.TabIndex = 103;
            this.label10.Text = "FPS (InPut) :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbZoomRatio
            // 
            this.cbZoomRatio.BackColor = System.Drawing.SystemColors.Info;
            this.cbZoomRatio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbZoomRatio.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbZoomRatio.FormattingEnabled = true;
            this.cbZoomRatio.Location = new System.Drawing.Point(84, 21);
            this.cbZoomRatio.Name = "cbZoomRatio";
            this.cbZoomRatio.Size = new System.Drawing.Size(90, 20);
            this.cbZoomRatio.TabIndex = 102;
            this.cbZoomRatio.SelectedIndexChanged += new System.EventHandler(this.cbZoomRatio_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = false;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(8, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 20);
            this.label9.TabIndex = 100;
            this.label9.Text = "% ZoomUp :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbEffectType
            // 
            this.cbEffectType.BackColor = System.Drawing.SystemColors.Info;
            this.cbEffectType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEffectType.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEffectType.FormattingEnabled = true;
            this.cbEffectType.Location = new System.Drawing.Point(84, 151);
            this.cbEffectType.Name = "cbEffectType";
            this.cbEffectType.Size = new System.Drawing.Size(150, 20);
            this.cbEffectType.TabIndex = 99;
            this.cbEffectType.SelectedIndexChanged += new System.EventHandler(this.cbEffectType_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = false;
            this.label8.Location = new System.Drawing.Point(8, 149);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 22);
            this.label8.TabIndex = 98;
            this.label8.Text = "Hiệu ứng :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ckHflip
            // 
            this.ckHflip.AutoSize = true;
            this.ckHflip.ForeColor = System.Drawing.Color.Red;
            this.ckHflip.Location = new System.Drawing.Point(246, 136);
            this.ckHflip.Name = "ckHflip";
            this.ckHflip.Size = new System.Drawing.Size(71, 17);
            this.ckHflip.TabIndex = 97;
            this.ckHflip.Text = "Lật Video";
            this.ckHflip.UseVisualStyleBackColor = true;
            this.ckHflip.CheckedChanged += new System.EventHandler(this.ckHflip_CheckedChanged);
            // 
            // ckRotate
            // 
            this.ckRotate.AutoSize = true;
            this.ckRotate.Location = new System.Drawing.Point(246, 113);
            this.ckRotate.Name = "ckRotate";
            this.ckRotate.Size = new System.Drawing.Size(79, 17);
            this.ckRotate.TabIndex = 96;
            this.ckRotate.Text = "Xoay video";
            this.ckRotate.UseVisualStyleBackColor = true;
            this.ckRotate.CheckedChanged += new System.EventHandler(this.ckRotate_CheckedChanged);
            // 
            // CkZoom
            // 
            this.CkZoom.AutoSize = true;
            this.CkZoom.Checked = true;
            this.CkZoom.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CkZoom.Location = new System.Drawing.Point(246, 89);
            this.CkZoom.Name = "CkZoom";
            this.CkZoom.Size = new System.Drawing.Size(82, 17);
            this.CkZoom.TabIndex = 95;
            this.CkZoom.Text = "Zoom video";
            this.CkZoom.UseVisualStyleBackColor = true;
            this.CkZoom.CheckedChanged += new System.EventHandler(this.CkZoom_CheckedChanged);
            // 
            // cbxVideoQuality
            // 
            this.cbxVideoQuality.BackColor = System.Drawing.SystemColors.Info;
            this.cbxVideoQuality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxVideoQuality.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxVideoQuality.FormattingEnabled = true;
            this.cbxVideoQuality.Location = new System.Drawing.Point(84, 87);
            this.cbxVideoQuality.Name = "cbxVideoQuality";
            this.cbxVideoQuality.Size = new System.Drawing.Size(150, 21);
            this.cbxVideoQuality.TabIndex = 93;
            this.cbxVideoQuality.SelectedIndexChanged += new System.EventHandler(this.cbxVideoQuality_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = false;
            this.label7.Location = new System.Drawing.Point(8, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 22);
            this.label7.TabIndex = 92;
            this.label7.Text = "Chất lượng :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbxSpeechType
            // 
            this.cbxSpeechType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSpeechType.FormattingEnabled = true;
            this.cbxSpeechType.Location = new System.Drawing.Point(84, 343);
            this.cbxSpeechType.Name = "cbxSpeechType";
            this.cbxSpeechType.Size = new System.Drawing.Size(270, 21);
            this.cbxSpeechType.TabIndex = 18;
            this.cbxSpeechType.SelectedIndexChanged += new System.EventHandler(this.cbxSpeechType_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = false;
            this.label6.Location = new System.Drawing.Point(8, 342);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 22);
            this.label6.TabIndex = 17;
            this.label6.Text = "Giọng Đọc :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = false;
            this.label5.Location = new System.Drawing.Point(8, 269);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 22);
            this.label5.TabIndex = 15;
            this.label5.Text = "Tốc Độ Đọc :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnAddAll
            // 
            this.btnAddAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnAddAll.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddAll.Location = new System.Drawing.Point(136, 26);
            this.btnAddAll.Name = "btnAddAll";
            this.btnAddAll.Size = new System.Drawing.Size(176, 41);
            this.btnAddAll.TabIndex = 15;
            this.btnAddAll.Text = "GHÉP CÁC ĐOẠN";
            this.btnAddAll.UseVisualStyleBackColor = false;
            this.btnAddAll.Click += new System.EventHandler(this.btnAddAll_Click);
            // 
            // lblstatus
            // 
            this.lblstatus.AutoSize = true;
            this.lblstatus.Location = new System.Drawing.Point(15, 76);
            this.lblstatus.Name = "lblstatus";
            this.lblstatus.Size = new System.Drawing.Size(16, 13);
            this.lblstatus.TabIndex = 16;
            this.lblstatus.Text = "...";
            // 
            // cboSiteNguon
            // 
            this.cboSiteNguon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSiteNguon.FormattingEnabled = true;
            this.cboSiteNguon.Location = new System.Drawing.Point(75, 17);
            this.cboSiteNguon.Name = "cboSiteNguon";
            this.cboSiteNguon.Size = new System.Drawing.Size(220, 21);
            this.cboSiteNguon.TabIndex = 40;
            this.cboSiteNguon.SelectedIndexChanged += new System.EventHandler(this.cboSiteNguon_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 41;
            this.label1.Text = "Nguồn Voice";
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
            this.grboxSetting.Location = new System.Drawing.Point(0, 0);
            this.grboxSetting.Name = "grboxSetting";
            this.grboxSetting.Size = new System.Drawing.Size(387, 734);
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
            this.grbConfigVoice.Size = new System.Drawing.Size(365, 155);
            this.grbConfigVoice.TabIndex = 46;
            this.grbConfigVoice.TabStop = false;
            this.grbConfigVoice.Text = "Cài Đặt Voice";
            // 
            // btnSaveVoiceSource
            // 
            this.btnSaveVoiceSource.BackColor = System.Drawing.SystemColors.Control;
            this.btnSaveVoiceSource.Location = new System.Drawing.Point(302, 16);
            this.btnSaveVoiceSource.Name = "btnSaveVoiceSource";
            this.btnSaveVoiceSource.Size = new System.Drawing.Size(56, 22);
            this.btnSaveVoiceSource.TabIndex = 44;
            this.btnSaveVoiceSource.Text = "Save";
            this.btnSaveVoiceSource.UseVisualStyleBackColor = false;
            this.btnSaveVoiceSource.Click += new System.EventHandler(this.btnSaveVoiceSource_Click);
            // 
            // grbActionRender
            // 
            this.grbActionRender.Controls.Add(this.rbGPUused);
            this.grbActionRender.Controls.Add(this.rbCPUused);
            this.grbActionRender.Controls.Add(this.btnAddAll);
            this.grbActionRender.Controls.Add(this.lblstatus);
            this.grbActionRender.Location = new System.Drawing.Point(11, 631);
            this.grbActionRender.Name = "grbActionRender";
            this.grbActionRender.Size = new System.Drawing.Size(365, 96);
            this.grbActionRender.TabIndex = 45;
            this.grbActionRender.TabStop = false;
            this.grbActionRender.Text = "Xuất Bản Video";
            // 
            // cbProjectName
            // 
            this.cbProjectName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbProjectName.DropDownHeight = 200;
            this.cbProjectName.FormattingEnabled = true;
            this.cbProjectName.IntegralHeight = false;
            this.cbProjectName.Location = new System.Drawing.Point(86, 21);
            this.cbProjectName.Name = "cbProjectName";
            this.cbProjectName.Size = new System.Drawing.Size(220, 21);
            this.cbProjectName.TabIndex = 43;
            this.cbProjectName.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cbProjectName_DrawItem);
            this.cbProjectName.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.cbProjectName_MeasureItem);
            this.cbProjectName.SelectedIndexChanged += new System.EventHandler(this.cbProjectName_SelectedIndexChanged);
            // 
            // tlpView
            // 
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
            this.tlpView.Size = new System.Drawing.Size(877, 734);
            this.tlpView.TabIndex = 2;
            // 
            // dgvMainView
            // 
            this.dgvMainView.AllowDrop = true;
            this.dgvMainView.AllowUserToAddRows = false;
            this.dgvMainView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(44)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(147)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.dgvMainView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvMainView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvMainView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvMainView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.dgvMainView.BorderColorEx = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(186)))), ((int)(((byte)(214)))));
            this.dgvMainView.BorderRadius = 6;
            this.dgvMainView.BorderSizeEx = 1;
            this.dgvMainView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMainView.CellBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(254)))), ((int)(((byte)(255)))));
            this.dgvMainView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(102)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(102)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMainView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvMainView.ColumnHeadersHeight = 32;
            this.dgvMainView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvMainView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
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
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(254)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(44)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(147)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMainView.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvMainView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMainView.EnableHeadersVisualStyles = false;
            this.dgvMainView.GridBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.dgvMainView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(210)))), ((int)(((byte)(230)))));
            this.dgvMainView.GridForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(44)))), ((int)(((byte)(64)))));
            this.dgvMainView.GridLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(210)))), ((int)(((byte)(230)))));
            this.dgvMainView.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(102)))), ((int)(((byte)(160)))));
            this.dgvMainView.HeaderForeColor = System.Drawing.Color.White;
            this.dgvMainView.HeaderHeight = 32;
            this.dgvMainView.Location = new System.Drawing.Point(3, 207);
            this.dgvMainView.Name = "dgvMainView";
            this.dgvMainView.RowHeadersVisible = false;
            this.dgvMainView.RowHeadersWidth = 20;
            this.dgvMainView.RowHeight = 30;
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
            this.Column_check.Width = 58;
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
            this.Column_index.Width = 46;
            // 
            // Column_textlength
            // 
            this.Column_textlength.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column_textlength.DataPropertyName = "textlength";
            this.Column_textlength.Frozen = true;
            this.Column_textlength.HeaderText = "Length";
            this.Column_textlength.Name = "Column_textlength";
            this.Column_textlength.ReadOnly = true;
            this.Column_textlength.Width = 72;
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
            this.tsMenuView.Renderer = new ReviewMovie.Base.Controls.UiToolStripRenderer(new ReviewMovie.Base.Controls.UiToolStripColors());
            this.tsMenuView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator6,
            this.btnSearch,
            this.toolStripSeparator8,
            this.txtTim,
            this.toolStripSeparator7,
            this.btnSelectAll,
            this.toolStripSeparator4,
            this.lbTitle,
            this.toolStripSeparator1,
            this.btnAddRow,
            this.toolStripSeparator2,
            this.btnImportSubtitle,
            this.toolStripSeparator3,
            this.btnDestroyAction});
            this.tsMenuView.Location = new System.Drawing.Point(0, 178);
            this.tsMenuView.Name = "tsMenuView";
            this.tsMenuView.Size = new System.Drawing.Size(877, 25);
            this.tsMenuView.TabIndex = 1;
            this.tsMenuView.Text = "toolStrip5";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // btnSearch
            // 
            this.btnSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(23, 22);
            this.btnSearch.Text = "toolStripButton1";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
            // 
            // txtTim
            // 
            this.txtTim.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.txtTim.BackColor = System.Drawing.Color.White;
            this.txtTim.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTim.Font = new System.Drawing.Font("Tahoma", 7F);
            this.txtTim.Name = "txtTim";
            this.txtTim.Size = new System.Drawing.Size(150, 25);
            this.txtTim.ToolTipText = "Nhập thông tin cần tìm vào đây";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSelectAll.Image = ((System.Drawing.Image)(resources.GetObject("btnSelectAll.Image")));
            this.btnSelectAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(23, 22);
            this.btnSelectAll.Tag = "0";
            this.btnSelectAll.Text = "Chọn/Không chọn tất cả";
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // lbTitle
            // 
            this.lbTitle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(71, 22);
            this.lbTitle.Text = "Chọn Tác Vụ";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnAddRow
            // 
            this.btnAddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAddRow.Image = global::EasyClip.Properties.Resources.add_1;
            this.btnAddRow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(113, 22);
            this.btnAddRow.Text = "Thêm Dòng Mới";
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnImportSubtitle
            // 
            this.btnImportSubtitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnImportSubtitle.Image = global::EasyClip.Properties.Resources.quick_edit;
            this.btnImportSubtitle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImportSubtitle.Name = "btnImportSubtitle";
            this.btnImportSubtitle.Size = new System.Drawing.Size(136, 22);
            this.btnImportSubtitle.Text = "Nhập Subtitle (Auto)";
            this.btnImportSubtitle.Click += new System.EventHandler(this.btnImportSubtitle_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnDestroyAction
            // 
            this.btnDestroyAction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnDestroyAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDestroyAction.Image = ((System.Drawing.Image)(resources.GetObject("btnDestroyAction.Image")));
            this.btnDestroyAction.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDestroyAction.Name = "btnDestroyAction";
            this.btnDestroyAction.Size = new System.Drawing.Size(121, 22);
            this.btnDestroyAction.Text = "&Hủy Mọi Hoạt Động";
            this.btnDestroyAction.Click += new System.EventHandler(this.btnDestroyAction_Click);
            // 
            // grViewHeader
            // 
            this.grViewHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(216)))), ((int)(((byte)(233)))));
            this.grViewHeader.Controls.Add(this.tlpViewHeader);
            this.grViewHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grViewHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grViewHeader.Location = new System.Drawing.Point(3, 3);
            this.grViewHeader.Name = "grViewHeader";
            this.grViewHeader.Size = new System.Drawing.Size(871, 172);
            this.grViewHeader.TabIndex = 0;
            this.grViewHeader.TabStop = false;
            this.grViewHeader.Text = "Mic In";
            // 
            // tlpViewHeader
            // 
            this.tlpViewHeader.ColumnCount = 4;
            this.tlpViewHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.76289F));
            this.tlpViewHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 81.23711F));
            this.tlpViewHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 156F));
            this.tlpViewHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 174F));
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
            this.tlpViewHeader.Size = new System.Drawing.Size(865, 153);
            this.tlpViewHeader.TabIndex = 0;
            // 
            // tlpImportMedia
            // 
            this.tlpImportMedia.ColumnCount = 1;
            this.tlpImportMedia.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpImportMedia.Controls.Add(this.txtImPortMedia, 0, 1);
            this.tlpImportMedia.Controls.Add(this.lbHeaderInputMedia, 0, 0);
            this.tlpImportMedia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpImportMedia.Location = new System.Drawing.Point(537, 3);
            this.tlpImportMedia.Name = "tlpImportMedia";
            this.tlpImportMedia.RowCount = 2;
            this.tlpImportMedia.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlpImportMedia.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tlpImportMedia.Size = new System.Drawing.Size(150, 147);
            this.tlpImportMedia.TabIndex = 2;
            // 
            // txtImPortMedia
            // 
            this.txtImPortMedia.AllowDrop = true;
            this.txtImPortMedia.BackColor = System.Drawing.SystemColors.Menu;
            this.txtImPortMedia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtImPortMedia.Location = new System.Drawing.Point(1, 23);
            this.txtImPortMedia.Margin = new System.Windows.Forms.Padding(1);
            this.txtImPortMedia.Multiline = true;
            this.txtImPortMedia.Name = "txtImPortMedia";
            this.txtImPortMedia.ReadOnly = true;
            this.txtImPortMedia.Size = new System.Drawing.Size(148, 123);
            this.txtImPortMedia.TabIndex = 2;
            this.txtImPortMedia.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtImPortMedia_DragDrop);
            this.txtImPortMedia.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtImPortMedia_DragEnter);
            // 
            // lbHeaderInputMedia
            // 
            this.lbHeaderInputMedia.AutoSize = true;
            this.lbHeaderInputMedia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(132)))), ((int)(((byte)(214)))));
            this.lbHeaderInputMedia.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(132)))), ((int)(((byte)(214)))));
            this.lbHeaderInputMedia.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(98)))), ((int)(((byte)(170)))));
            this.lbHeaderInputMedia.BorderRadius = 2;
            this.lbHeaderInputMedia.BorderSize = 1;
            this.lbHeaderInputMedia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbHeaderInputMedia.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbHeaderInputMedia.ForeColor = System.Drawing.Color.White;
            this.lbHeaderInputMedia.Location = new System.Drawing.Point(1, 1);
            this.lbHeaderInputMedia.Margin = new System.Windows.Forms.Padding(1);
            this.lbHeaderInputMedia.Name = "lbHeaderInputMedia";
            this.lbHeaderInputMedia.Size = new System.Drawing.Size(148, 20);
            this.lbHeaderInputMedia.TabIndex = 1;
            this.lbHeaderInputMedia.Text = "Kéo Thả (Ảnh , Video)";
            this.lbHeaderInputMedia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbHeaderInputMedia.TextColor = System.Drawing.Color.White;
            // 
            // btnRecord
            // 
            this.btnRecord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnRecord.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecord.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecord.Image = global::EasyClip.Properties.Resources.ivoice;
            this.btnRecord.Location = new System.Drawing.Point(3, 3);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(94, 147);
            this.btnRecord.TabIndex = 0;
            this.btnRecord.Text = "Record";
            this.btnRecord.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRecord.UseVisualStyleBackColor = true;
            this.btnRecord.Click += new System.EventHandler(this.btnRecord_Click);
            // 
            // tlpText
            // 
            this.tlpText.ColumnCount = 1;
            this.tlpText.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpText.Controls.Add(this.lbHeaderText, 0, 0);
            this.tlpText.Controls.Add(this.txtTextInput, 0, 1);
            this.tlpText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpText.Location = new System.Drawing.Point(103, 3);
            this.tlpText.Name = "tlpText";
            this.tlpText.RowCount = 2;
            this.tlpText.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlpText.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tlpText.Size = new System.Drawing.Size(428, 147);
            this.tlpText.TabIndex = 1;
            // 
            // lbHeaderText
            // 
            this.lbHeaderText.AutoSize = true;
            this.lbHeaderText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(132)))), ((int)(((byte)(214)))));
            this.lbHeaderText.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(132)))), ((int)(((byte)(214)))));
            this.lbHeaderText.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(98)))), ((int)(((byte)(170)))));
            this.lbHeaderText.BorderRadius = 2;
            this.lbHeaderText.BorderSize = 1;
            this.lbHeaderText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbHeaderText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHeaderText.ForeColor = System.Drawing.Color.White;
            this.lbHeaderText.Location = new System.Drawing.Point(1, 1);
            this.lbHeaderText.Margin = new System.Windows.Forms.Padding(1);
            this.lbHeaderText.Name = "lbHeaderText";
            this.lbHeaderText.Size = new System.Drawing.Size(426, 20);
            this.lbHeaderText.TabIndex = 0;
            this.lbHeaderText.Text = "Nhập Text | Hoặc Kéo Audio File Vào !";
            this.lbHeaderText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbHeaderText.TextColor = System.Drawing.Color.White;
            // 
            // txtTextInput
            // 
            this.txtTextInput.AllowDrop = true;
            this.txtTextInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTextInput.Location = new System.Drawing.Point(3, 25);
            this.txtTextInput.Multiline = true;
            this.txtTextInput.Name = "txtTextInput";
            this.txtTextInput.Size = new System.Drawing.Size(422, 119);
            this.txtTextInput.TabIndex = 1;
            this.txtTextInput.TextChanged += new System.EventHandler(this.txtTextInput_TextChanged);
            this.txtTextInput.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtTextInput_DragDrop);
            this.txtTextInput.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtTextInput_DragEnter);
            // 
            // tlpHeaderButton
            // 
            this.tlpHeaderButton.ColumnCount = 1;
            this.tlpHeaderButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpHeaderButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpHeaderButton.Controls.Add(this.btnRenderVideoPart, 0, 2);
            this.tlpHeaderButton.Controls.Add(this.btnConvertAudio, 0, 0);
            this.tlpHeaderButton.Controls.Add(this.btnSaveAudio, 0, 1);
            this.tlpHeaderButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpHeaderButton.Location = new System.Drawing.Point(693, 3);
            this.tlpHeaderButton.Name = "tlpHeaderButton";
            this.tlpHeaderButton.RowCount = 3;
            this.tlpHeaderButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpHeaderButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpHeaderButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tlpHeaderButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpHeaderButton.Size = new System.Drawing.Size(169, 147);
            this.tlpHeaderButton.TabIndex = 3;
            // 
            // btnRenderVideoPart
            // 
            this.btnRenderVideoPart.BackColor = System.Drawing.SystemColors.Control;
            this.btnRenderVideoPart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRenderVideoPart.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRenderVideoPart.Location = new System.Drawing.Point(4, 104);
            this.btnRenderVideoPart.Margin = new System.Windows.Forms.Padding(4);
            this.btnRenderVideoPart.Name = "btnRenderVideoPart";
            this.btnRenderVideoPart.Size = new System.Drawing.Size(161, 39);
            this.btnRenderVideoPart.TabIndex = 3;
            this.btnRenderVideoPart.Text = "Render Part";
            this.btnRenderVideoPart.UseVisualStyleBackColor = false;
            this.btnRenderVideoPart.Click += new System.EventHandler(this.btnRenderVideoPart_Click);
            // 
            // btnConvertAudio
            // 
            this.btnConvertAudio.BackColor = System.Drawing.SystemColors.Control;
            this.btnConvertAudio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnConvertAudio.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConvertAudio.Location = new System.Drawing.Point(4, 4);
            this.btnConvertAudio.Margin = new System.Windows.Forms.Padding(4);
            this.btnConvertAudio.Name = "btnConvertAudio";
            this.btnConvertAudio.Size = new System.Drawing.Size(161, 42);
            this.btnConvertAudio.TabIndex = 1;
            this.btnConvertAudio.Text = "Convert Audio";
            this.btnConvertAudio.UseVisualStyleBackColor = false;
            this.btnConvertAudio.Click += new System.EventHandler(this.btnConvertAudio_Click);
            // 
            // btnSaveAudio
            // 
            this.btnSaveAudio.BackColor = System.Drawing.SystemColors.Control;
            this.btnSaveAudio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSaveAudio.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveAudio.Location = new System.Drawing.Point(4, 54);
            this.btnSaveAudio.Margin = new System.Windows.Forms.Padding(4);
            this.btnSaveAudio.Name = "btnSaveAudio";
            this.btnSaveAudio.Size = new System.Drawing.Size(161, 42);
            this.btnSaveAudio.TabIndex = 2;
            this.btnSaveAudio.Text = "Save Audio";
            this.btnSaveAudio.UseVisualStyleBackColor = false;
            this.btnSaveAudio.Click += new System.EventHandler(this.btnSaveAudio_Click);
            // 
            // pnlHeaderTitle
            // 
            this.pnlHeaderTitle.BackColor = System.Drawing.Color.White;
            this.pnlHeaderTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHeaderTitle.Controls.Add(this.pnlHeaderBrand);
            this.pnlHeaderTitle.Controls.Add(this.tlpHeaderRight);
            this.pnlHeaderTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeaderTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlHeaderTitle.Name = "pnlHeaderTitle";
            this.pnlHeaderTitle.Size = new System.Drawing.Size(1334, 46);
            this.pnlHeaderTitle.TabIndex = 44;
            this.pnlHeaderTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HeaderArea_MouseDown);
            // 
            // pnlHeaderBrand
            // 
            this.pnlHeaderBrand.Controls.Add(this.lblHeaderSubtitle);
            this.pnlHeaderBrand.Controls.Add(this.lblHeaderMainTitle);
            this.pnlHeaderBrand.Controls.Add(this.lblHeaderLogo);
            this.pnlHeaderBrand.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlHeaderBrand.Location = new System.Drawing.Point(0, 0);
            this.pnlHeaderBrand.Name = "pnlHeaderBrand";
            this.pnlHeaderBrand.Size = new System.Drawing.Size(320, 44);
            this.pnlHeaderBrand.TabIndex = 0;
            this.pnlHeaderBrand.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HeaderArea_MouseDown);
            // 
            // lblHeaderSubtitle
            // 
            this.lblHeaderSubtitle.AutoSize = true;
            this.lblHeaderSubtitle.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(136)))), ((int)(((byte)(149)))));
            this.lblHeaderSubtitle.Location = new System.Drawing.Point(48, 23);
            this.lblHeaderSubtitle.Name = "lblHeaderSubtitle";
            this.lblHeaderSubtitle.Size = new System.Drawing.Size(99, 12);
            this.lblHeaderSubtitle.TabIndex = 2;
            this.lblHeaderSubtitle.Text = "TPMEDIA PREMIUM";
            this.lblHeaderSubtitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HeaderArea_MouseDown);
            // 
            // lblHeaderMainTitle
            // 
            this.lblHeaderMainTitle.AutoSize = true;
            this.lblHeaderMainTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderMainTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(66)))));
            this.lblHeaderMainTitle.Location = new System.Drawing.Point(48, 6);
            this.lblHeaderMainTitle.Name = "lblHeaderMainTitle";
            this.lblHeaderMainTitle.Size = new System.Drawing.Size(95, 19);
            this.lblHeaderMainTitle.TabIndex = 1;
            this.lblHeaderMainTitle.Text = "EasyClip Studio";
            this.lblHeaderMainTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HeaderArea_MouseDown);
            // 
            // lblHeaderLogo
            // 
            this.lblHeaderLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(227)))));
            this.lblHeaderLogo.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblHeaderLogo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(120)))), ((int)(((byte)(48)))));
            this.lblHeaderLogo.Location = new System.Drawing.Point(12, 8);
            this.lblHeaderLogo.Name = "lblHeaderLogo";
            this.lblHeaderLogo.Size = new System.Drawing.Size(28, 28);
            this.lblHeaderLogo.TabIndex = 0;
            this.lblHeaderLogo.Text = "EC";
            this.lblHeaderLogo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblHeaderLogo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HeaderArea_MouseDown);
            // 
            // tlpHeaderRight
            // 
            this.tlpHeaderRight.ColumnCount = 6;
            this.tlpHeaderRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tlpHeaderRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 116F));
            this.tlpHeaderRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlpHeaderRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlpHeaderRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpHeaderRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlpHeaderRight.Controls.Add(this.lblHeaderActive, 0, 0);
            this.tlpHeaderRight.Controls.Add(this.lblHeaderRemaining, 1, 0);
            this.tlpHeaderRight.Controls.Add(this.btnHeaderHelp, 2, 0);
            this.tlpHeaderRight.Controls.Add(this.btnHeaderSetting, 3, 0);
            this.tlpHeaderRight.Controls.Add(this.lblHeaderAvatar, 4, 0);
            this.tlpHeaderRight.Controls.Add(this.btnHeaderClose, 5, 0);
            this.tlpHeaderRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.tlpHeaderRight.Location = new System.Drawing.Point(972, 0);
            this.tlpHeaderRight.Name = "tlpHeaderRight";
            this.tlpHeaderRight.RowCount = 1;
            this.tlpHeaderRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpHeaderRight.Size = new System.Drawing.Size(320, 44);
            this.tlpHeaderRight.TabIndex = 1;
            // 
            // lblHeaderActive
            // 
            this.lblHeaderActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(248)))), ((int)(((byte)(238)))));
            this.lblHeaderActive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHeaderActive.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblHeaderActive.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(138)))), ((int)(((byte)(86)))));
            this.lblHeaderActive.Location = new System.Drawing.Point(4, 10);
            this.lblHeaderActive.Margin = new System.Windows.Forms.Padding(4, 10, 4, 10);
            this.lblHeaderActive.Name = "lblHeaderActive";
            this.lblHeaderActive.Size = new System.Drawing.Size(54, 24);
            this.lblHeaderActive.TabIndex = 0;
            this.lblHeaderActive.Text = "Active";
            this.lblHeaderActive.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHeaderRemaining
            // 
            this.lblHeaderRemaining.AutoSize = true;
            this.lblHeaderRemaining.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHeaderRemaining.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderRemaining.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(100)))), ((int)(((byte)(112)))));
            this.lblHeaderRemaining.Location = new System.Drawing.Point(66, 0);
            this.lblHeaderRemaining.Name = "lblHeaderRemaining";
            this.lblHeaderRemaining.Size = new System.Drawing.Size(110, 44);
            this.lblHeaderRemaining.TabIndex = 1;
            this.lblHeaderRemaining.Text = "1 Day Remaining";
            this.lblHeaderRemaining.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnHeaderHelp
            // 
            this.btnHeaderHelp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHeaderHelp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHeaderHelp.FlatAppearance.BorderSize = 0;
            this.btnHeaderHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHeaderHelp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnHeaderHelp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(99)))), ((int)(((byte)(114)))));
            this.btnHeaderHelp.Location = new System.Drawing.Point(182, 6);
            this.btnHeaderHelp.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.btnHeaderHelp.Name = "btnHeaderHelp";
            this.btnHeaderHelp.Size = new System.Drawing.Size(28, 32);
            this.btnHeaderHelp.TabIndex = 2;
            this.btnHeaderHelp.Text = "?";
            this.btnHeaderHelp.UseVisualStyleBackColor = true;
            // 
            // btnHeaderSetting
            // 
            this.btnHeaderSetting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHeaderSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHeaderSetting.FlatAppearance.BorderSize = 0;
            this.btnHeaderSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHeaderSetting.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHeaderSetting.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(99)))), ((int)(((byte)(114)))));
            this.btnHeaderSetting.Location = new System.Drawing.Point(216, 6);
            this.btnHeaderSetting.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.btnHeaderSetting.Name = "btnHeaderSetting";
            this.btnHeaderSetting.Size = new System.Drawing.Size(28, 32);
            this.btnHeaderSetting.TabIndex = 3;
            this.btnHeaderSetting.Text = "⚙";
            this.btnHeaderSetting.UseVisualStyleBackColor = true;
            // 
            // lblHeaderAvatar
            // 
            this.lblHeaderAvatar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(136)))), ((int)(((byte)(57)))));
            this.lblHeaderAvatar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHeaderAvatar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblHeaderAvatar.ForeColor = System.Drawing.Color.White;
            this.lblHeaderAvatar.Location = new System.Drawing.Point(252, 6);
            this.lblHeaderAvatar.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.lblHeaderAvatar.Name = "lblHeaderAvatar";
            this.lblHeaderAvatar.Size = new System.Drawing.Size(30, 32);
            this.lblHeaderAvatar.TabIndex = 4;
            this.lblHeaderAvatar.Text = "TN";
            this.lblHeaderAvatar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnHeaderClose
            // 
            this.btnHeaderClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHeaderClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHeaderClose.FlatAppearance.BorderSize = 0;
            this.btnHeaderClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHeaderClose.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnHeaderClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btnHeaderClose.Location = new System.Drawing.Point(289, 6);
            this.btnHeaderClose.Margin = new System.Windows.Forms.Padding(2, 6, 2, 6);
            this.btnHeaderClose.Name = "btnHeaderClose";
            this.btnHeaderClose.Size = new System.Drawing.Size(32, 32);
            this.btnHeaderClose.TabIndex = 5;
            this.btnHeaderClose.Text = "X";
            this.btnHeaderClose.UseVisualStyleBackColor = true;
            this.btnHeaderClose.Click += new System.EventHandler(this.btnHeaderClose_Click);
            // 
            // scMain
            // 
            this.scMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.scMain.IsSplitterFixed = true;
            this.scMain.Location = new System.Drawing.Point(0, 0);
            this.scMain.Name = "scMain";
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.scView);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.scSetting);
            this.scMain.Size = new System.Drawing.Size(1334, 736);
            this.scMain.SplitterDistance = 910;
            this.scMain.TabIndex = 43;
            // 
            // scView
            // 
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
            this.scView.Size = new System.Drawing.Size(910, 736);
            this.scView.SplitterDistance = 879;
            this.scView.TabIndex = 47;
            // 
            // btnExpand
            // 
            this.btnExpand.BackColor = System.Drawing.SystemColors.Info;
            this.btnExpand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExpand.Location = new System.Drawing.Point(0, 0);
            this.btnExpand.Margin = new System.Windows.Forms.Padding(0);
            this.btnExpand.Name = "btnExpand";
            this.btnExpand.Size = new System.Drawing.Size(25, 734);
            this.btnExpand.TabIndex = 46;
            this.btnExpand.Text = ">";
            this.btnExpand.UseVisualStyleBackColor = false;
            this.btnExpand.Visible = false;
            this.btnExpand.Click += new System.EventHandler(this.btnExpand_Click);
            // 
            // scSetting
            // 
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
            this.scSetting.Size = new System.Drawing.Size(420, 736);
            this.scSetting.SplitterDistance = 27;
            this.scSetting.TabIndex = 46;
            // 
            // btnCollapse
            // 
            this.btnCollapse.BackColor = System.Drawing.SystemColors.Info;
            this.btnCollapse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCollapse.Location = new System.Drawing.Point(0, 0);
            this.btnCollapse.Margin = new System.Windows.Forms.Padding(0);
            this.btnCollapse.Name = "btnCollapse";
            this.btnCollapse.Size = new System.Drawing.Size(25, 734);
            this.btnCollapse.TabIndex = 45;
            this.btnCollapse.Text = "<";
            this.btnCollapse.UseVisualStyleBackColor = false;
            this.btnCollapse.Click += new System.EventHandler(this.btnCollapse_Click);
            // 
            // rbCPUused
            // 
            this.rbCPUused.AutoSize = true;
            this.rbCPUused.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCPUused.ForeColor = System.Drawing.Color.Red;
            this.rbCPUused.Location = new System.Drawing.Point(18, 26);
            this.rbCPUused.Name = "rbCPUused";
            this.rbCPUused.Size = new System.Drawing.Size(76, 17);
            this.rbCPUused.TabIndex = 17;
            this.rbCPUused.TabStop = true;
            this.rbCPUused.Text = "Use CPU";
            this.rbCPUused.UseVisualStyleBackColor = true;
            // 
            // rbGPUused
            // 
            this.rbGPUused.AutoSize = true;
            this.rbGPUused.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbGPUused.ForeColor = System.Drawing.Color.ForestGreen;
            this.rbGPUused.Location = new System.Drawing.Point(18, 49);
            this.rbGPUused.Name = "rbGPUused";
            this.rbGPUused.Size = new System.Drawing.Size(77, 17);
            this.rbGPUused.TabIndex = 18;
            this.rbGPUused.TabStop = true;
            this.rbGPUused.Text = "Use GPU";
            this.rbGPUused.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(216)))), ((int)(((byte)(233)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1334, 782);
            this.Controls.Add(this.scMain);
            this.Controls.Add(this.pnlHeaderTitle);
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
            this.tlpImportMedia.PerformLayout();
            this.tlpText.ResumeLayout(false);
            this.tlpText.PerformLayout();
            this.tlpHeaderButton.ResumeLayout(false);
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
            this.pnlHeaderTitle.ResumeLayout(false);
            this.pnlHeaderBrand.ResumeLayout(false);
            this.pnlHeaderBrand.PerformLayout();
            this.tlpHeaderRight.ResumeLayout(false);
            this.tlpHeaderRight.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private ReviewMovie.Base.Controls.UiLabel label2;
        private ReviewMovie.Base.Controls.UiLabel lblapi;
        private ReviewMovie.Base.Controls.UiTextBox txtAppID;
        private ReviewMovie.Base.Controls.UiButton btnOpenProject;
        private ReviewMovie.Base.Controls.UiLabel lblToken;
        private ReviewMovie.Base.Controls.UiTextBox txtToken;
        private ReviewMovie.Base.Controls.UiGroupBox grbConfigRender;
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
        private ReviewMovie.Base.Controls.UiGroupBox grboxSetting;
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
        private ReviewMovie.Base.Controls.UiGroupBox grViewHeader;
        private ReviewMovie.Base.Controls.UiTableLayoutPanel tlpViewHeader;
        private ReviewMovie.Base.Controls.UiButton btnRecord;
        private ReviewMovie.Base.Controls.UiTableLayoutPanel tlpImportMedia;
        private ReviewMovie.Base.Controls.UiTableLayoutPanel tlpText;
        private ReviewMovie.Base.Controls.UiLabel lbHeaderInputMedia;
        private ReviewMovie.Base.Controls.UiLabel lbHeaderText;
        private System.Windows.Forms.TextBox txtImPortMedia;
        private ReviewMovie.Base.Controls.UiTableLayoutPanel tlpHeaderButton;
        private ReviewMovie.Base.Controls.UiButton btnRenderVideoPart;
        private ReviewMovie.Base.Controls.UiButton btnConvertAudio;
        private ReviewMovie.Base.Controls.UiButton btnSaveAudio;
        private ReviewMovie.Base.Controls.UiDataGridView dgvMainView;
        private System.Windows.Forms.ToolStrip tsMenuView;
        private System.Windows.Forms.ToolStripTextBox txtTim;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton btnSelectAll;
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
        private ReviewMovie.Base.Controls.UiGroupBox grbActionRender;
        private ReviewMovie.Base.Controls.UiGroupBox grbConfigVoice;
        private ReviewMovie.Base.Controls.UiNumericUpDown nbSpeechRatio;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnAddRow;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnImportSubtitle;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnDestroyAction;
        private System.Windows.Forms.ToolStripButton btnSearch;
        private ReviewMovie.Base.Controls.UiCheckBox ckOpenPlayer;
        private ReviewMovie.Base.Controls.UiRadioButton rbCPUused;
        private ReviewMovie.Base.Controls.UiRadioButton rbGPUused;
        private System.Windows.Forms.Panel pnlHeaderTitle;
        private System.Windows.Forms.Panel pnlHeaderBrand;
        private System.Windows.Forms.Label lblHeaderSubtitle;
        private System.Windows.Forms.Label lblHeaderMainTitle;
        private System.Windows.Forms.Label lblHeaderLogo;
        private System.Windows.Forms.TableLayoutPanel tlpHeaderRight;
        private System.Windows.Forms.Label lblHeaderActive;
        private System.Windows.Forms.Label lblHeaderRemaining;
        private System.Windows.Forms.Button btnHeaderHelp;
        private System.Windows.Forms.Button btnHeaderSetting;
        private System.Windows.Forms.Label lblHeaderAvatar;
        private System.Windows.Forms.Button btnHeaderClose;
    }
}

