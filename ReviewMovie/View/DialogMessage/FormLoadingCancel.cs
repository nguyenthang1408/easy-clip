using EasyClip.Services.Popup;
using ReviewMovie.Localization;
using System;
using System.Windows.Forms;

namespace EasyClip.View.DialogMessage
{
    public partial class FormLoadingCancel : Form, ILoadingDialog, ILocalizable
    {
        public event Action CancelRequested;

        public FormLoadingCancel()
        {
            InitializeComponent();
            ApplyLanguage();
        }

        public void ApplyLanguage()
        {
            lblStatus.Text = LanguageManager.Get(LangKeys.Loading_Cancelling);
        }

        public void Show(string status)
        {
            UpdateStatus(status);
            // Non-modal, block interaction main form
            this.StartPosition = FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.Show();
        }

        public void UpdateStatus(string status)
        {
            if (this.InvokeRequired)
                this.Invoke(new Action(() => lblStatus.Text = status));
            else
                lblStatus.Text = status;
        }

        public void CloseDialog()
        {
            if (this.InvokeRequired)
                this.Invoke(new Action(() => this.Close()));
            else
                this.Close();
        }
    }
}
