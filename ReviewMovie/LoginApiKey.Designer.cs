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
            this.tlpRoot = new System.Windows.Forms.TableLayoutPanel();
            this.panelCard = new System.Windows.Forms.Panel();
            this.lblLogo = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.btnLoginApiKey = new MaterialSkin.Controls.MaterialButton();
            this.rpAppCode = new ReviewMovie.Base.RoundedPanel();
            this.txAppCodeShow = new System.Windows.Forms.TextBox();
            this.rpApiKey = new ReviewMovie.Base.RoundedPanel();
            this.txInsertApiKey = new System.Windows.Forms.TextBox();
            this.lkHelp = new System.Windows.Forms.LinkLabel();
            this.lbstatus = new System.Windows.Forms.Label();
            this.linklbRegister = new System.Windows.Forms.LinkLabel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.tlpRoot.SuspendLayout();
            this.panelCard.SuspendLayout();
            this.rpAppCode.SuspendLayout();
            this.rpApiKey.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpRoot
            // 
            this.tlpRoot.ColumnCount = 3;
            this.tlpRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 380F));
            this.tlpRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpRoot.Controls.Add(this.panelCard, 1, 1);
            this.tlpRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRoot.Location = new System.Drawing.Point(0, 0);
            this.tlpRoot.Name = "tlpRoot";
            this.tlpRoot.RowCount = 3;
            this.tlpRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 520F));
            this.tlpRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpRoot.Size = new System.Drawing.Size(440, 560);
            this.tlpRoot.TabIndex = 0;
            // 
            // panelCard
            // 
            this.panelCard.BackColor = System.Drawing.Color.Transparent;
            this.panelCard.Controls.Add(this.lblLogo);
            this.panelCard.Controls.Add(this.lblTitle);
            this.panelCard.Controls.Add(this.lblSubtitle);
            this.panelCard.Controls.Add(this.btnLoginApiKey);
            this.panelCard.Controls.Add(this.rpAppCode);
            this.panelCard.Controls.Add(this.rpApiKey);
            this.panelCard.Controls.Add(this.lkHelp);
            this.panelCard.Controls.Add(this.lbstatus);
            this.panelCard.Controls.Add(this.linklbRegister);
            this.panelCard.Controls.Add(this.materialLabel1);
            this.panelCard.Controls.Add(this.materialLabel2);
            this.panelCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCard.Location = new System.Drawing.Point(33, 23);
            this.panelCard.Name = "panelCard";
            this.panelCard.Padding = new System.Windows.Forms.Padding(28, 26, 28, 22);
            this.panelCard.Size = new System.Drawing.Size(374, 514);
            this.panelCard.TabIndex = 0;
            this.panelCard.Paint += new System.Windows.Forms.PaintEventHandler(this.panelCard_Paint);
            // 
            // lblLogo
            // 
            this.lblLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(97)))), ((int)(((byte)(255)))));
            this.lblLogo.Location = new System.Drawing.Point(28, 26);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(44, 44);
            this.lblLogo.TabIndex = 20;
            this.lblLogo.Text = "✓";
            this.lblLogo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(24)))), ((int)(((byte)(38)))));
            this.lblTitle.Location = new System.Drawing.Point(28, 86);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(173, 32);
            this.lblTitle.TabIndex = 21;
            this.lblTitle.Text = "Welcome Back";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(118)))), ((int)(((byte)(140)))));
            this.lblSubtitle.Location = new System.Drawing.Point(31, 126);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(255, 17);
            this.lblSubtitle.TabIndex = 22;
            this.lblSubtitle.Text = "Enter your credentials to access the studio.";
            // 
            // btnLoginApiKey
            // 
            this.btnLoginApiKey.AutoSize = false;
            this.btnLoginApiKey.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLoginApiKey.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnLoginApiKey.Depth = 0;
            this.btnLoginApiKey.HighEmphasis = true;
            this.btnLoginApiKey.Icon = null;
            this.btnLoginApiKey.Location = new System.Drawing.Point(31, 375);
            this.btnLoginApiKey.Margin = new System.Windows.Forms.Padding(4, 8, 4, 8);
            this.btnLoginApiKey.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnLoginApiKey.Name = "btnLoginApiKey";
            this.btnLoginApiKey.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnLoginApiKey.Size = new System.Drawing.Size(312, 44);
            this.btnLoginApiKey.TabIndex = 1;
            this.btnLoginApiKey.Text = "Đăng nhập  →";
            this.btnLoginApiKey.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnLoginApiKey.UseAccentColor = false;
            this.btnLoginApiKey.UseVisualStyleBackColor = true;
            this.btnLoginApiKey.Click += new System.EventHandler(this.btnLoginApiKey_Click);
            // 
            // rpAppCode
            // 
            this.rpAppCode.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.rpAppCode.BorderRadius = 14;
            this.rpAppCode.BorderThickness = 1;
            this.rpAppCode.FillColor = System.Drawing.Color.White;
            this.rpAppCode.Location = new System.Drawing.Point(31, 200);
            this.rpAppCode.Name = "rpAppCode";
            this.rpAppCode.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.rpAppCode.Size = new System.Drawing.Size(312, 46);
            this.rpAppCode.TabIndex = 2;
            this.rpAppCode.Controls.Add(this.txAppCodeShow);
            // 
            // txAppCodeShow
            // 
            this.txAppCodeShow.BackColor = System.Drawing.Color.White;
            this.txAppCodeShow.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txAppCodeShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txAppCodeShow.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txAppCodeShow.Location = new System.Drawing.Point(12, 10);
            this.txAppCodeShow.MaxLength = 200;
            this.txAppCodeShow.Name = "txAppCodeShow";
            this.txAppCodeShow.ReadOnly = true;
            this.txAppCodeShow.Size = new System.Drawing.Size(288, 19);
            this.txAppCodeShow.TabIndex = 0;
            // 
            // rpApiKey
            // 
            this.rpApiKey.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.rpApiKey.BorderRadius = 14;
            this.rpApiKey.BorderThickness = 1;
            this.rpApiKey.FillColor = System.Drawing.Color.White;
            this.rpApiKey.Location = new System.Drawing.Point(31, 300);
            this.rpApiKey.Name = "rpApiKey";
            this.rpApiKey.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.rpApiKey.Size = new System.Drawing.Size(312, 46);
            this.rpApiKey.TabIndex = 5;
            this.rpApiKey.Controls.Add(this.txInsertApiKey);
            // 
            // txInsertApiKey
            // 
            this.txInsertApiKey.BackColor = System.Drawing.Color.White;
            this.txInsertApiKey.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txInsertApiKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txInsertApiKey.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txInsertApiKey.Location = new System.Drawing.Point(12, 10);
            this.txInsertApiKey.MaxLength = 200;
            this.txInsertApiKey.Name = "txInsertApiKey";
            this.txInsertApiKey.Size = new System.Drawing.Size(288, 19);
            this.txInsertApiKey.TabIndex = 0;
            // 
            // lkHelp
            // 
            this.lkHelp.AutoSize = true;
            this.lkHelp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lkHelp.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(97)))), ((int)(((byte)(255)))));
            this.lkHelp.Location = new System.Drawing.Point(31, 465);
            this.lkHelp.Name = "lkHelp";
            this.lkHelp.Size = new System.Drawing.Size(31, 15);
            this.lkHelp.TabIndex = 7;
            this.lkHelp.Text = "Help";
            this.lkHelp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkHelp_LinkClicked);
            // 
            // lbstatus
            // 
            this.lbstatus.AutoSize = true;
            this.lbstatus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbstatus.Location = new System.Drawing.Point(31, 358);
            this.lbstatus.Name = "lbstatus";
            this.lbstatus.Size = new System.Drawing.Size(13, 13);
            this.lbstatus.TabIndex = 8;
            this.lbstatus.Text = "_";
            // 
            // linklbRegister
            // 
            this.linklbRegister.AutoSize = true;
            this.linklbRegister.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linklbRegister.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(97)))), ((int)(((byte)(255)))));
            this.linklbRegister.Location = new System.Drawing.Point(295, 465);
            this.linklbRegister.Name = "linklbRegister";
            this.linklbRegister.Size = new System.Drawing.Size(52, 15);
            this.linklbRegister.TabIndex = 9;
            this.linklbRegister.Text = "Register";
            this.linklbRegister.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklbRegister_LinkClicked);
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(118)))), ((int)(((byte)(140)))));
            this.materialLabel1.Location = new System.Drawing.Point(31, 176);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(68, 15);
            this.materialLabel1.TabIndex = 4;
            this.materialLabel1.Text = "APP CODE";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(118)))), ((int)(((byte)(140)))));
            this.materialLabel2.Location = new System.Drawing.Point(31, 272);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(52, 15);
            this.materialLabel2.TabIndex = 6;
            this.materialLabel2.Text = "API KEY";
            // 
            // LoginApiKey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(440, 560);
            this.Controls.Add(this.tlpRoot);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginApiKey";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "REVIEW_MOVIE LOGIN";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoginApiKey_FormClosing);
            this.Load += new System.EventHandler(this.LoginApiKey_Load);
            this.tlpRoot.ResumeLayout(false);
            this.panelCard.ResumeLayout(false);
            this.panelCard.PerformLayout();
            this.rpAppCode.ResumeLayout(false);
            this.rpAppCode.PerformLayout();
            this.rpApiKey.ResumeLayout(false);
            this.rpApiKey.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tlpRoot;
        private System.Windows.Forms.Panel panelCard;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private MaterialSkin.Controls.MaterialButton btnLoginApiKey;
        private ReviewMovie.Base.RoundedPanel rpAppCode;
        private System.Windows.Forms.TextBox txAppCodeShow;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private ReviewMovie.Base.RoundedPanel rpApiKey;
        private System.Windows.Forms.TextBox txInsertApiKey;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private System.Windows.Forms.LinkLabel lkHelp;
        private System.Windows.Forms.Label lbstatus;
        private System.Windows.Forms.LinkLabel linklbRegister;
    }
}