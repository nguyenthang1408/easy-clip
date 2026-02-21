using ReviewMovie.Localization;
using System;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;

namespace ReviewMovie.Base
{
    public partial class CustomTextBox : System.Windows.Forms.TextBox
    {
        private bool isPlaceHolder = true;
        private string placeHolderText = LanguageManager.Get(LangKeys.Svc_TextPlaceholder);

        public string PlaceHolderText
        {
            get { return placeHolderText; }
            set
            {
                placeHolderText = value;
            }
        }

        public CustomTextBox()
        {
            InitializeComponent();
            TextChanged += OnTextChanged;
        }

        private void SetPlaceholder()
        {
            if (!isPlaceHolder)
            {
                this.Text = placeHolderText;
                this.ForeColor = Color.Gray;
                isPlaceHolder = true;
            }
        }

        private void RemovePlaceHolder()
        {
            if (isPlaceHolder)
            {
                if (this.Text.Contains(placeHolderText)) this.Text = this.Text[0].ToString(); // Remove placeHolder text, but keep the character we just entered
                else
                {
                    this.Text = this.Text.ToString();
                }
                this.Select(1, 0); // Place the caret after the character we just entered
                this.ForeColor = System.Drawing.SystemColors.WindowText;
                this.Font = new Font(this.Font, FontStyle.Regular);
                isPlaceHolder = false;
            }
        }

        private void OnTextChanged(object sender, EventArgs e)
        {
            if (this.Text.Length == 0)
            {
                SetPlaceholder();
            }
            else
            {
                RemovePlaceHolder();
            }
        }
    }
}
