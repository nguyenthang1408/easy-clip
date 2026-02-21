namespace ReviewMovie
{
    partial class LoginApiKey
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginApiKey));
            this.cardPanel = new System.Windows.Forms.Panel();
            this.linklbRegister = new System.Windows.Forms.LinkLabel();
            this.lkHelp = new System.Windows.Forms.LinkLabel();
            this.lbstatus = new System.Windows.Forms.Label();
            this.materialLabel2 = new System.Windows.Forms.Label();
            this.materialLabel1 = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.lblLogoIcon = new System.Windows.Forms.Label();
            this.pnlTopAccent = new System.Windows.Forms.Panel();
            this.btnLoginApiKey = new ReviewMovie.Base.Controls.PrimaryButton();
            this.btnClose = new ReviewMovie.Base.Controls.IconCircleButton();
            this.txInsertApiKey = new ReviewMovie.Base.Controls.UiTextBox();
            this.txAppCodeShow = new ReviewMovie.Base.Controls.UiTextBox();
            this.cardPanel.SuspendLayout();
            this.pnlLogo.SuspendLayout();
            this.SuspendLayout();
            // 
            // cardPanel
            // 
            this.cardPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardPanel.BackColor = System.Drawing.Color.White;
            this.cardPanel.Controls.Add(this.linklbRegister);
            this.cardPanel.Controls.Add(this.lkHelp);
            this.cardPanel.Controls.Add(this.btnLoginApiKey);
            this.cardPanel.Controls.Add(this.btnClose);
            this.cardPanel.Controls.Add(this.lbstatus);
            this.cardPanel.Controls.Add(this.txInsertApiKey);
            this.cardPanel.Controls.Add(this.materialLabel2);
            this.cardPanel.Controls.Add(this.txAppCodeShow);
            this.cardPanel.Controls.Add(this.materialLabel1);
            this.cardPanel.Controls.Add(this.lblSubtitle);
            this.cardPanel.Controls.Add(this.lblTitle);
            this.cardPanel.Controls.Add(this.pnlLogo);
            this.cardPanel.Controls.Add(this.pnlTopAccent);
            this.cardPanel.Location = new System.Drawing.Point(0, 0);
            this.cardPanel.Name = "cardPanel";
            this.cardPanel.Size = new System.Drawing.Size(450, 600);
            this.cardPanel.TabIndex = 0;
            this.cardPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragArea_MouseDown);
            // 
            // linklbRegister
            // 
            this.linklbRegister.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(59)))), ((int)(((byte)(238)))));
            this.linklbRegister.AutoSize = true;
            this.linklbRegister.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linklbRegister.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linklbRegister.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(59)))), ((int)(((byte)(238)))));
            this.linklbRegister.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.linklbRegister.Location = new System.Drawing.Point(349, 514);
            this.linklbRegister.Name = "linklbRegister";
            this.linklbRegister.Size = new System.Drawing.Size(57, 17);
            this.linklbRegister.TabIndex = 10;
            this.linklbRegister.TabStop = true;
            this.linklbRegister.Text = "Register";
            this.linklbRegister.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(59)))), ((int)(((byte)(238)))));
            this.linklbRegister.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklbRegister_LinkClicked);
            // 
            // lkHelp
            // 
            this.lkHelp.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(95)))), ((int)(((byte)(197)))));
            this.lkHelp.AutoSize = true;
            this.lkHelp.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lkHelp.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lkHelp.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(95)))), ((int)(((byte)(197)))));
            this.lkHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lkHelp.Location = new System.Drawing.Point(44, 514);
            this.lkHelp.Name = "lkHelp";
            this.lkHelp.Size = new System.Drawing.Size(36, 17);
            this.lkHelp.TabIndex = 11;
            this.lkHelp.TabStop = true;
            this.lkHelp.Text = "Help";
            this.lkHelp.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(95)))), ((int)(((byte)(197)))));
            this.lkHelp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkHelp_LinkClicked);
            // 
            // lbstatus
            // 
            this.lbstatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbstatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lbstatus.Location = new System.Drawing.Point(44, 398);
            this.lbstatus.Name = "lbstatus";
            this.lbstatus.Size = new System.Drawing.Size(362, 30);
            this.lbstatus.TabIndex = 8;
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(101)))), ((int)(((byte)(186)))));
            this.materialLabel2.Location = new System.Drawing.Point(44, 314);
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(58, 19);
            this.materialLabel2.TabIndex = 6;
            this.materialLabel2.Text = "API KEY";
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(101)))), ((int)(((byte)(186)))));
            this.materialLabel1.Location = new System.Drawing.Point(44, 228);
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(75, 19);
            this.materialLabel1.TabIndex = 4;
            this.materialLabel1.Text = "APP CODE";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(125)))), ((int)(((byte)(150)))));
            this.lblSubtitle.Location = new System.Drawing.Point(44, 188);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(362, 0);
            this.lblSubtitle.TabIndex = 3;
            this.lblSubtitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragArea_MouseDown);
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(60)))), ((int)(((byte)(147)))));
            this.lblTitle.Location = new System.Drawing.Point(44, 150);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(362, 38);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Review Movie";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragArea_MouseDown);
            // 
            // pnlLogo
            // 
            this.pnlLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(252)))));
            this.pnlLogo.Controls.Add(this.lblLogoIcon);
            this.pnlLogo.Location = new System.Drawing.Point(183, 48);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(84, 84);
            this.pnlLogo.TabIndex = 1;
            this.pnlLogo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragArea_MouseDown);
            // 
            // lblLogoIcon
            // 
            this.lblLogoIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLogoIcon.Font = new System.Drawing.Font("Segoe UI Emoji", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogoIcon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(94)))), ((int)(((byte)(255)))));
            this.lblLogoIcon.Location = new System.Drawing.Point(0, 0);
            this.lblLogoIcon.Name = "lblLogoIcon";
            this.lblLogoIcon.Size = new System.Drawing.Size(84, 84);
            this.lblLogoIcon.TabIndex = 0;
            this.lblLogoIcon.Text = "🎬";
            this.lblLogoIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLogoIcon.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragArea_MouseDown);
            // 
            // pnlTopAccent
            // 
            this.pnlTopAccent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(94)))), ((int)(((byte)(255)))));
            this.pnlTopAccent.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopAccent.Location = new System.Drawing.Point(0, 0);
            this.pnlTopAccent.Name = "pnlTopAccent";
            this.pnlTopAccent.Size = new System.Drawing.Size(450, 0);
            this.pnlTopAccent.TabIndex = 0;
            this.pnlTopAccent.Visible = false;
            this.pnlTopAccent.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragArea_MouseDown);
            // 
            // btnLoginApiKey
            // 
            this.btnLoginApiKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(119)))), ((int)(((byte)(242)))));
            this.btnLoginApiKey.CornerRadius = 12;
            this.btnLoginApiKey.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(119)))), ((int)(((byte)(242)))));
            this.btnLoginApiKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoginApiKey.Font = new System.Drawing.Font("Segoe UI Semibold", 11.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoginApiKey.ForeColor = System.Drawing.Color.White;
            this.btnLoginApiKey.HoverFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(111)))), ((int)(((byte)(229)))));
            this.btnLoginApiKey.Location = new System.Drawing.Point(44, 448);
            this.btnLoginApiKey.Name = "btnLoginApiKey";
            this.btnLoginApiKey.PressedFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(93)))), ((int)(((byte)(191)))));
            this.btnLoginApiKey.Size = new System.Drawing.Size(362, 54);
            this.btnLoginApiKey.TabIndex = 9;
            this.btnLoginApiKey.Text = "Login  ➜";
            this.btnLoginApiKey.UseVisualStyleBackColor = false;
            this.btnLoginApiKey.Click += new System.EventHandler(this.btnLoginApiKey_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.CornerRadius = 15;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(145)))), ((int)(((byte)(165)))));
            this.btnClose.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(408, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.NormalBackColor = System.Drawing.Color.White;
            this.btnClose.PressedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(239)))));
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "✕";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txInsertApiKey
            // 
            this.txInsertApiKey.BackColor = System.Drawing.Color.Transparent;
            this.txInsertApiKey.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(253)))));
            this.txInsertApiKey.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            this.txInsertApiKey.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(122)))), ((int)(((byte)(0)))));
            this.txInsertApiKey.BorderRadius = 4;
            this.txInsertApiKey.DisableTextBox = false;
            this.txInsertApiKey.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txInsertApiKey.IconLeft = null;
            this.txInsertApiKey.IconRight = null;
            this.txInsertApiKey.IconSize = new System.Drawing.Size(18, 18);
            this.txInsertApiKey.Lines = new string[0];
            this.txInsertApiKey.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txInsertApiKey.Location = new System.Drawing.Point(44, 336);
            this.txInsertApiKey.MaxLength = 32767;
            this.txInsertApiKey.Multiline = false;
            this.txInsertApiKey.Name = "txInsertApiKey";
            this.txInsertApiKey.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);
            this.txInsertApiKey.ReadOnly = false;
            this.txInsertApiKey.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txInsertApiKey.SelectionLength = 0;
            this.txInsertApiKey.SelectionStart = 0;
            this.txInsertApiKey.Size = new System.Drawing.Size(362, 54);
            this.txInsertApiKey.TabIndex = 7;
            this.txInsertApiKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txInsertApiKey.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.txInsertApiKey.UseSystemPasswordChar = false;
            // 
            // txAppCodeShow
            // 
            this.txAppCodeShow.BackColor = System.Drawing.Color.Transparent;
            this.txAppCodeShow.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(253)))));
            this.txAppCodeShow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            this.txAppCodeShow.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(122)))), ((int)(((byte)(0)))));
            this.txAppCodeShow.BorderRadius = 4;
            this.txAppCodeShow.DisableTextBox = false;
            this.txAppCodeShow.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txAppCodeShow.IconLeft = null;
            this.txAppCodeShow.IconRight = null;
            this.txAppCodeShow.IconSize = new System.Drawing.Size(18, 18);
            this.txAppCodeShow.Lines = new string[0];
            this.txAppCodeShow.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txAppCodeShow.Location = new System.Drawing.Point(44, 250);
            this.txAppCodeShow.MaxLength = 32767;
            this.txAppCodeShow.Multiline = false;
            this.txAppCodeShow.Name = "txAppCodeShow";
            this.txAppCodeShow.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);
            this.txAppCodeShow.ReadOnly = true;
            this.txAppCodeShow.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txAppCodeShow.SelectionLength = 0;
            this.txAppCodeShow.SelectionStart = 0;
            this.txAppCodeShow.Size = new System.Drawing.Size(362, 54);
            this.txAppCodeShow.TabIndex = 1;
            this.txAppCodeShow.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txAppCodeShow.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.txAppCodeShow.UseSystemPasswordChar = false;
            // 
            // LoginApiKey
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(450, 600);
            this.Controls.Add(this.cardPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "LoginApiKey";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Welcome";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoginApiKey_FormClosing);
            this.Load += new System.EventHandler(this.LoginApiKey_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoginApiKey_KeyDown);
            this.cardPanel.ResumeLayout(false);
            this.cardPanel.PerformLayout();
            this.pnlLogo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel cardPanel;
        private System.Windows.Forms.Panel pnlTopAccent;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.Label lblLogoIcon;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label materialLabel1;
        private ReviewMovie.Base.Controls.UiTextBox txAppCodeShow;
        private System.Windows.Forms.Label materialLabel2;
        private ReviewMovie.Base.Controls.UiTextBox txInsertApiKey;
        private ReviewMovie.Base.Controls.PrimaryButton btnLoginApiKey;
        private ReviewMovie.Base.Controls.IconCircleButton btnClose;
        private System.Windows.Forms.LinkLabel lkHelp;
        private System.Windows.Forms.Label lbstatus;
        private System.Windows.Forms.LinkLabel linklbRegister;
    }
}