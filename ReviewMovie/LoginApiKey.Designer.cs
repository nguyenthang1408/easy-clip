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
            this.pnlTopAccent = new System.Windows.Forms.Panel();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.lblLogoIcon = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.materialLabel1 = new System.Windows.Forms.Label();
            this.txAppCodeShow = new ReviewMovie.Base.Controls.PillTextBox();
            this.materialLabel2 = new System.Windows.Forms.Label();
            this.txInsertApiKey = new ReviewMovie.Base.Controls.PillTextBox();
            this.btnLoginApiKey = new ReviewMovie.Base.Controls.PrimaryButton();
            this.btnClose = new ReviewMovie.Base.Controls.IconCircleButton();
            this.lkHelp = new System.Windows.Forms.LinkLabel();
            this.lbstatus = new System.Windows.Forms.Label();
            this.linklbRegister = new System.Windows.Forms.LinkLabel();
            this.cardPanel.SuspendLayout();
            this.pnlLogo.SuspendLayout();
            this.SuspendLayout();
            // 
            // cardPanel
            // 
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
            this.cardPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardPanel.Location = new System.Drawing.Point(0, 0);
            this.cardPanel.Name = "cardPanel";
            this.cardPanel.Size = new System.Drawing.Size(420, 570);
            this.cardPanel.TabIndex = 0;
            this.cardPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragArea_MouseDown);
            // 
            // pnlTopAccent
            // 
            this.pnlTopAccent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(94)))), ((int)(((byte)(255)))));
            this.pnlTopAccent.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopAccent.Location = new System.Drawing.Point(0, 0);
            this.pnlTopAccent.Name = "pnlTopAccent";
            this.pnlTopAccent.Size = new System.Drawing.Size(420, 0);
            this.pnlTopAccent.TabIndex = 0;
            this.pnlTopAccent.Visible = false;
            this.pnlTopAccent.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragArea_MouseDown);
            // 
            // pnlLogo
            // 
            this.pnlLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(252)))));
            this.pnlLogo.Controls.Add(this.lblLogoIcon);
            this.pnlLogo.Location = new System.Drawing.Point(44, 64);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(48, 48);
            this.pnlLogo.TabIndex = 1;
            this.pnlLogo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragArea_MouseDown);
            // 
            // lblLogoIcon
            // 
            this.lblLogoIcon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLogoIcon.Font = new System.Drawing.Font("Segoe MDL2 Assets", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogoIcon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(94)))), ((int)(((byte)(255)))));
            this.lblLogoIcon.Location = new System.Drawing.Point(0, 0);
            this.lblLogoIcon.Name = "lblLogoIcon";
            this.lblLogoIcon.Size = new System.Drawing.Size(48, 48);
            this.lblLogoIcon.TabIndex = 0;
            this.lblLogoIcon.Text = "\uE70F";
            this.lblLogoIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLogoIcon.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragArea_MouseDown);
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(30)))));
            this.lblTitle.Location = new System.Drawing.Point(44, 124);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(332, 38);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Review Movie";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragArea_MouseDown);
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(125)))), ((int)(((byte)(150)))));
            this.lblSubtitle.Location = new System.Drawing.Point(44, 164);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(332, 0);
            this.lblSubtitle.TabIndex = 3;
            this.lblSubtitle.Text = "";
            this.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblSubtitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragArea_MouseDown);
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(150)))), ((int)(((byte)(175)))));
            this.materialLabel1.Location = new System.Drawing.Point(44, 212);
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(70, 15);
            this.materialLabel1.TabIndex = 4;
            this.materialLabel1.Text = "APP CODE";
            // 
            // txAppCodeShow
            // 
            this.txAppCodeShow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            this.txAppCodeShow.CornerRadius = 16;
            this.txAppCodeShow.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(253)))));
            this.txAppCodeShow.IconGlyph = "";
            this.txAppCodeShow.Location = new System.Drawing.Point(44, 234);
            this.txAppCodeShow.Name = "txAppCodeShow";
            this.txAppCodeShow.ReadOnly = true;
            this.txAppCodeShow.Size = new System.Drawing.Size(332, 52);
            this.txAppCodeShow.TabIndex = 1;
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(150)))), ((int)(((byte)(175)))));
            this.materialLabel2.Location = new System.Drawing.Point(44, 294);
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(51, 15);
            this.materialLabel2.TabIndex = 6;
            this.materialLabel2.Text = "API KEY";
            // 
            // txInsertApiKey
            // 
            this.txInsertApiKey.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            this.txInsertApiKey.CornerRadius = 16;
            this.txInsertApiKey.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(253)))));
            this.txInsertApiKey.IconGlyph = "";
            this.txInsertApiKey.Location = new System.Drawing.Point(44, 316);
            this.txInsertApiKey.Name = "txInsertApiKey";
            this.txInsertApiKey.ReadOnly = false;
            this.txInsertApiKey.Size = new System.Drawing.Size(332, 52);
            this.txInsertApiKey.TabIndex = 7;
            // 
            // lbstatus
            // 
            this.lbstatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbstatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lbstatus.Location = new System.Drawing.Point(44, 390);
            this.lbstatus.Name = "lbstatus";
            this.lbstatus.Size = new System.Drawing.Size(332, 30);
            this.lbstatus.TabIndex = 8;
            this.lbstatus.Text = "";
            // 
            // btnLoginApiKey
            // 
            this.btnLoginApiKey.Font = new System.Drawing.Font("Segoe UI Semibold", 11.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoginApiKey.ForeColor = System.Drawing.Color.White;
            this.btnLoginApiKey.Location = new System.Drawing.Point(44, 430);
            this.btnLoginApiKey.Name = "btnLoginApiKey";
            this.btnLoginApiKey.Size = new System.Drawing.Size(332, 52);
            this.btnLoginApiKey.TabIndex = 9;
            this.btnLoginApiKey.Text = "Login  ➜";
            this.btnLoginApiKey.Click += new System.EventHandler(this.btnLoginApiKey_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(145)))), ((int)(((byte)(165)))));
            this.btnClose.Location = new System.Drawing.Point(378, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "✕";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // linklbRegister
            // 
            this.linklbRegister.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(94)))), ((int)(((byte)(255)))));
            this.linklbRegister.AutoSize = true;
            this.linklbRegister.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linklbRegister.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linklbRegister.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(94)))), ((int)(((byte)(255)))));
            this.linklbRegister.Location = new System.Drawing.Point(317, 486);
            this.linklbRegister.Name = "linklbRegister";
            this.linklbRegister.Size = new System.Drawing.Size(59, 17);
            this.linklbRegister.TabIndex = 10;
            this.linklbRegister.TabStop = true;
            this.linklbRegister.Text = "Register";
            this.linklbRegister.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklbRegister_LinkClicked);
            // 
            // lkHelp
            // 
            this.lkHelp.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(94)))), ((int)(((byte)(255)))));
            this.lkHelp.AutoSize = true;
            this.lkHelp.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lkHelp.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lkHelp.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(125)))), ((int)(((byte)(150)))));
            this.lkHelp.Location = new System.Drawing.Point(44, 486);
            this.lkHelp.Name = "lkHelp";
            this.lkHelp.Size = new System.Drawing.Size(35, 17);
            this.lkHelp.TabIndex = 11;
            this.lkHelp.TabStop = true;
            this.lkHelp.Text = "Help";
            this.lkHelp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkHelp_LinkClicked);
            // 
            // LoginApiKey
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(420, 570);
            this.Controls.Add(this.cardPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.BackColor = System.Drawing.Color.White;
            this.Name = "LoginApiKey";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Welcome";
            this.KeyPreview = true;
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
        private ReviewMovie.Base.Controls.PillTextBox txAppCodeShow;
        private System.Windows.Forms.Label materialLabel2;
        private ReviewMovie.Base.Controls.PillTextBox txInsertApiKey;
        private ReviewMovie.Base.Controls.PrimaryButton btnLoginApiKey;
        private ReviewMovie.Base.Controls.IconCircleButton btnClose;
        private System.Windows.Forms.LinkLabel lkHelp;
        private System.Windows.Forms.Label lbstatus;
        private System.Windows.Forms.LinkLabel linklbRegister;
    }
}