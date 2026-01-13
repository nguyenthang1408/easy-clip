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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.lblLogoIcon = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.cardPanel = new System.Windows.Forms.Panel();
            this.pnlHandle = new System.Windows.Forms.Panel();
            this.materialLabel1 = new System.Windows.Forms.Label();
            this.pnlAppCode = new System.Windows.Forms.Panel();
            this.lblAppCodeIcon = new System.Windows.Forms.Label();
            this.txAppCodeShow = new System.Windows.Forms.TextBox();
            this.materialLabel2 = new System.Windows.Forms.Label();
            this.pnlApiKey = new System.Windows.Forms.Panel();
            this.btnToggleApiKey = new System.Windows.Forms.Button();
            this.lblApiKeyIcon = new System.Windows.Forms.Label();
            this.txInsertApiKey = new System.Windows.Forms.TextBox();
            this.btnLoginApiKey = new System.Windows.Forms.Button();
            this.lkHelp = new System.Windows.Forms.LinkLabel();
            this.lbstatus = new System.Windows.Forms.Label();
            this.linklbRegister = new System.Windows.Forms.LinkLabel();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblVersion = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlLogo.SuspendLayout();
            this.cardPanel.SuspendLayout();
            this.pnlAppCode.SuspendLayout();
            this.pnlApiKey.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.Transparent;
            this.pnlHeader.Controls.Add(this.pnlLogo);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Location = new System.Drawing.Point(24, 20);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(372, 170);
            this.pnlHeader.TabIndex = 0;
            this.pnlHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragArea_MouseDown);
            // 
            // pnlLogo
            // 
            this.pnlLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(92)))), ((int)(((byte)(240)))));
            this.pnlLogo.Controls.Add(this.lblLogoIcon);
            this.pnlLogo.Location = new System.Drawing.Point(158, 6);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(56, 56);
            this.pnlLogo.TabIndex = 1;
            this.pnlLogo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragArea_MouseDown);
            // 
            // lblLogoIcon
            // 
            this.lblLogoIcon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLogoIcon.Font = new System.Drawing.Font("Segoe MDL2 Assets", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogoIcon.ForeColor = System.Drawing.Color.White;
            this.lblLogoIcon.Location = new System.Drawing.Point(0, 0);
            this.lblLogoIcon.Name = "lblLogoIcon";
            this.lblLogoIcon.Size = new System.Drawing.Size(56, 56);
            this.lblLogoIcon.TabIndex = 0;
            this.lblLogoIcon.Text = "";
            this.lblLogoIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLogoIcon.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragArea_MouseDown);
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(35)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 74);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(332, 34);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Studio Access";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragArea_MouseDown);
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(125)))), ((int)(((byte)(150)))));
            this.lblSubtitle.Location = new System.Drawing.Point(20, 110);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(332, 38);
            this.lblSubtitle.TabIndex = 3;
            this.lblSubtitle.Text = "Log in to your editing workspace";
            this.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblSubtitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragArea_MouseDown);
            // 
            // cardPanel
            // 
            this.cardPanel.BackColor = System.Drawing.Color.White;
            this.cardPanel.Controls.Add(this.pnlHandle);
            this.cardPanel.Controls.Add(this.linklbRegister);
            this.cardPanel.Controls.Add(this.lkHelp);
            this.cardPanel.Controls.Add(this.btnLoginApiKey);
            this.cardPanel.Controls.Add(this.lbstatus);
            this.cardPanel.Controls.Add(this.pnlApiKey);
            this.cardPanel.Controls.Add(this.materialLabel2);
            this.cardPanel.Controls.Add(this.pnlAppCode);
            this.cardPanel.Controls.Add(this.materialLabel1);
            this.cardPanel.Location = new System.Drawing.Point(30, 188);
            this.cardPanel.Name = "cardPanel";
            this.cardPanel.Size = new System.Drawing.Size(360, 360);
            this.cardPanel.TabIndex = 1;
            this.cardPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragArea_MouseDown);
            this.cardPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.cardPanel_Paint);
            // 
            // pnlHandle
            // 
            this.pnlHandle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlHandle.Location = new System.Drawing.Point(160, 14);
            this.pnlHandle.Name = "pnlHandle";
            this.pnlHandle.Size = new System.Drawing.Size(40, 4);
            this.pnlHandle.TabIndex = 99;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(150)))), ((int)(((byte)(175)))));
            this.materialLabel1.Location = new System.Drawing.Point(26, 40);
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(70, 15);
            this.materialLabel1.TabIndex = 4;
            this.materialLabel1.Text = "APP CODE";
            // 
            // pnlAppCode
            // 
            this.pnlAppCode.BackColor = System.Drawing.Color.White;
            this.pnlAppCode.Controls.Add(this.txAppCodeShow);
            this.pnlAppCode.Controls.Add(this.lblAppCodeIcon);
            this.pnlAppCode.Location = new System.Drawing.Point(24, 60);
            this.pnlAppCode.Name = "pnlAppCode";
            this.pnlAppCode.Size = new System.Drawing.Size(312, 46);
            this.pnlAppCode.TabIndex = 5;
            this.pnlAppCode.Paint += new System.Windows.Forms.PaintEventHandler(this.pillPanel_Paint);
            // 
            // lblAppCodeIcon
            // 
            this.lblAppCodeIcon.Font = new System.Drawing.Font("Segoe MDL2 Assets", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppCodeIcon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(155)))), ((int)(((byte)(175)))));
            this.lblAppCodeIcon.Location = new System.Drawing.Point(12, 10);
            this.lblAppCodeIcon.Name = "lblAppCodeIcon";
            this.lblAppCodeIcon.Size = new System.Drawing.Size(22, 22);
            this.lblAppCodeIcon.TabIndex = 0;
            this.lblAppCodeIcon.Text = "";
            this.lblAppCodeIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txAppCodeShow
            // 
            this.txAppCodeShow.BackColor = System.Drawing.Color.White;
            this.txAppCodeShow.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txAppCodeShow.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txAppCodeShow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.txAppCodeShow.Location = new System.Drawing.Point(42, 13);
            this.txAppCodeShow.Name = "txAppCodeShow";
            this.txAppCodeShow.ReadOnly = true;
            this.txAppCodeShow.Size = new System.Drawing.Size(256, 18);
            this.txAppCodeShow.TabIndex = 1;
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(150)))), ((int)(((byte)(175)))));
            this.materialLabel2.Location = new System.Drawing.Point(26, 118);
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(51, 15);
            this.materialLabel2.TabIndex = 6;
            this.materialLabel2.Text = "API KEY";
            // 
            // pnlApiKey
            // 
            this.pnlApiKey.BackColor = System.Drawing.Color.White;
            this.pnlApiKey.Controls.Add(this.btnToggleApiKey);
            this.pnlApiKey.Controls.Add(this.txInsertApiKey);
            this.pnlApiKey.Controls.Add(this.lblApiKeyIcon);
            this.pnlApiKey.Location = new System.Drawing.Point(24, 138);
            this.pnlApiKey.Name = "pnlApiKey";
            this.pnlApiKey.Size = new System.Drawing.Size(312, 46);
            this.pnlApiKey.TabIndex = 7;
            this.pnlApiKey.Paint += new System.Windows.Forms.PaintEventHandler(this.pillPanel_Paint);
            // 
            // btnToggleApiKey
            // 
            this.btnToggleApiKey.BackColor = System.Drawing.Color.White;
            this.btnToggleApiKey.FlatAppearance.BorderSize = 0;
            this.btnToggleApiKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggleApiKey.Font = new System.Drawing.Font("Segoe MDL2 Assets", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToggleApiKey.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(155)))), ((int)(((byte)(175)))));
            this.btnToggleApiKey.Location = new System.Drawing.Point(280, 8);
            this.btnToggleApiKey.Name = "btnToggleApiKey";
            this.btnToggleApiKey.Size = new System.Drawing.Size(26, 30);
            this.btnToggleApiKey.TabIndex = 2;
            this.btnToggleApiKey.Text = "";
            this.btnToggleApiKey.UseVisualStyleBackColor = false;
            this.btnToggleApiKey.Click += new System.EventHandler(this.btnToggleApiKey_Click);
            // 
            // lblApiKeyIcon
            // 
            this.lblApiKeyIcon.Font = new System.Drawing.Font("Segoe MDL2 Assets", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApiKeyIcon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(155)))), ((int)(((byte)(175)))));
            this.lblApiKeyIcon.Location = new System.Drawing.Point(12, 10);
            this.lblApiKeyIcon.Name = "lblApiKeyIcon";
            this.lblApiKeyIcon.Size = new System.Drawing.Size(22, 22);
            this.lblApiKeyIcon.TabIndex = 0;
            this.lblApiKeyIcon.Text = "";
            this.lblApiKeyIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txInsertApiKey
            // 
            this.txInsertApiKey.BackColor = System.Drawing.Color.White;
            this.txInsertApiKey.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txInsertApiKey.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txInsertApiKey.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.txInsertApiKey.Location = new System.Drawing.Point(42, 13);
            this.txInsertApiKey.Name = "txInsertApiKey";
            this.txInsertApiKey.Size = new System.Drawing.Size(232, 18);
            this.txInsertApiKey.TabIndex = 1;
            // 
            // lbstatus
            // 
            this.lbstatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbstatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lbstatus.Location = new System.Drawing.Point(24, 190);
            this.lbstatus.Name = "lbstatus";
            this.lbstatus.Size = new System.Drawing.Size(312, 30);
            this.lbstatus.TabIndex = 8;
            this.lbstatus.Text = "";
            // 
            // btnLoginApiKey
            // 
            this.btnLoginApiKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(22)))), ((int)(((byte)(35)))));
            this.btnLoginApiKey.FlatAppearance.BorderSize = 0;
            this.btnLoginApiKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoginApiKey.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoginApiKey.ForeColor = System.Drawing.Color.White;
            this.btnLoginApiKey.Location = new System.Drawing.Point(24, 236);
            this.btnLoginApiKey.Name = "btnLoginApiKey";
            this.btnLoginApiKey.Size = new System.Drawing.Size(312, 46);
            this.btnLoginApiKey.TabIndex = 9;
            this.btnLoginApiKey.Text = "Login to Dashboard  ➜";
            this.btnLoginApiKey.UseVisualStyleBackColor = false;
            this.btnLoginApiKey.Click += new System.EventHandler(this.btnLoginApiKey_Click);
            this.btnLoginApiKey.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnLoginApiKey_MouseDown);
            this.btnLoginApiKey.MouseEnter += new System.EventHandler(this.btnLoginApiKey_MouseEnter);
            this.btnLoginApiKey.MouseLeave += new System.EventHandler(this.btnLoginApiKey_MouseLeave);
            this.btnLoginApiKey.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnLoginApiKey_MouseUp);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(145)))), ((int)(((byte)(165)))));
            this.btnClose.Location = new System.Drawing.Point(378, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "✕";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.MouseEnter += new System.EventHandler(this.btnClose_MouseEnter);
            this.btnClose.MouseLeave += new System.EventHandler(this.btnClose_MouseLeave);
            this.btnClose.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnClose_MouseDown);
            this.btnClose.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnClose_MouseUp);
            // 
            // linklbRegister
            // 
            this.linklbRegister.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(94)))), ((int)(((byte)(255)))));
            this.linklbRegister.AutoSize = true;
            this.linklbRegister.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linklbRegister.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linklbRegister.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(94)))), ((int)(((byte)(255)))));
            this.linklbRegister.Location = new System.Drawing.Point(228, 302);
            this.linklbRegister.Name = "linklbRegister";
            this.linklbRegister.Size = new System.Drawing.Size(101, 17);
            this.linklbRegister.TabIndex = 10;
            this.linklbRegister.TabStop = true;
            this.linklbRegister.Text = "Create Account";
            this.linklbRegister.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklbRegister_LinkClicked);
            // 
            // lkHelp
            // 
            this.lkHelp.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(94)))), ((int)(((byte)(255)))));
            this.lkHelp.AutoSize = true;
            this.lkHelp.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lkHelp.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lkHelp.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(125)))), ((int)(((byte)(150)))));
            this.lkHelp.Location = new System.Drawing.Point(24, 302);
            this.lkHelp.Name = "lkHelp";
            this.lkHelp.Size = new System.Drawing.Size(80, 17);
            this.lkHelp.TabIndex = 11;
            this.lkHelp.TabStop = true;
            this.lkHelp.Text = "Help Center";
            this.lkHelp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkHelp_LinkClicked);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(145)))), ((int)(((byte)(165)))));
            this.btnClose.Location = new System.Drawing.Point(374, 18);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(34, 34);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "✕";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnClose_MouseDown);
            this.btnClose.MouseEnter += new System.EventHandler(this.btnClose_MouseEnter);
            this.btnClose.MouseLeave += new System.EventHandler(this.btnClose_MouseLeave);
            this.btnClose.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnClose_MouseUp);
            // 
            // lblVersion
            // 
            this.lblVersion.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(150)))), ((int)(((byte)(175)))));
            this.lblVersion.Location = new System.Drawing.Point(20, 606);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(380, 16);
            this.lblVersion.TabIndex = 13;
            this.lblVersion.Text = "v2.4.0 • Build 202310";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LoginApiKey
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(420, 640);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.cardPanel);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.BackColor = System.Drawing.Color.White;
            this.Name = "LoginApiKey";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Studio Access";
            this.KeyPreview = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoginApiKey_FormClosing);
            this.Load += new System.EventHandler(this.LoginApiKey_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoginApiKey_KeyDown);
            this.pnlHeader.ResumeLayout(false);
            this.pnlLogo.ResumeLayout(false);
            this.pnlLogo.ResumeLayout(false);
            this.cardPanel.ResumeLayout(false);
            this.cardPanel.PerformLayout();
            this.pnlAppCode.ResumeLayout(false);
            this.pnlAppCode.PerformLayout();
            this.pnlApiKey.ResumeLayout(false);
            this.pnlApiKey.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel cardPanel;
        private System.Windows.Forms.Panel pnlHandle;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.Label lblLogoIcon;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label materialLabel1;
        private System.Windows.Forms.Panel pnlAppCode;
        private System.Windows.Forms.Label lblAppCodeIcon;
        private System.Windows.Forms.TextBox txAppCodeShow;
        private System.Windows.Forms.Label materialLabel2;
        private System.Windows.Forms.Panel pnlApiKey;
        private System.Windows.Forms.Label lblApiKeyIcon;
        private System.Windows.Forms.TextBox txInsertApiKey;
        private System.Windows.Forms.Button btnLoginApiKey;
        private System.Windows.Forms.LinkLabel lkHelp;
        private System.Windows.Forms.Label lbstatus;
        private System.Windows.Forms.LinkLabel linklbRegister;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Button btnToggleApiKey;
    }
}