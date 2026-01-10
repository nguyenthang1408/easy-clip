using System;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Xml;

namespace ReviewMovie.WpfUi
{
    public sealed class ModernHeaderView : UserControl
    {
        private readonly TextBox _txtInput;
        private readonly TextBlock _txtPlaceholder;

        public event EventHandler StartRecordClicked;
        public event EventHandler ConvertClicked;
        public event EventHandler SaveClicked;
        public event EventHandler RenderClicked;
        public event EventHandler ClearClicked;
        public event EventHandler TextChanged;

        public ModernHeaderView()
        {
            var root = LoadFromEmbeddedXaml("EasyClip.WpfUi.ModernHeader.xaml");
            // Keep styles/resources declared in XAML root
            Resources = root.Resources;
            Content = root.Content;

            _txtInput = (TextBox)root.FindName("TxtInput");
            _txtPlaceholder = (TextBlock)root.FindName("TxtPlaceholder");

            var btnStart = (Button)root.FindName("BtnStartRecord");
            var btnConvert = (Button)root.FindName("BtnConvert");
            var btnSave = (Button)root.FindName("BtnSave");
            var btnRender = (Button)root.FindName("BtnRender");
            var btnClear = (Button)root.FindName("BtnClearText");

            btnStart.Click += (_, __) => StartRecordClicked?.Invoke(this, EventArgs.Empty);
            btnConvert.Click += (_, __) => ConvertClicked?.Invoke(this, EventArgs.Empty);
            btnSave.Click += (_, __) => SaveClicked?.Invoke(this, EventArgs.Empty);
            btnRender.Click += (_, __) => RenderClicked?.Invoke(this, EventArgs.Empty);
            btnClear.Click += (_, __) => ClearClicked?.Invoke(this, EventArgs.Empty);

            _txtInput.TextChanged += (_, __) =>
            {
                UpdatePlaceholderVisibility();
                TextChanged?.Invoke(this, EventArgs.Empty);
            };

            UpdatePlaceholderVisibility();
        }

        public string Text
        {
            get => _txtInput.Text ?? string.Empty;
            set
            {
                _txtInput.Text = value ?? string.Empty;
                UpdatePlaceholderVisibility();
            }
        }

        private void UpdatePlaceholderVisibility()
        {
            _txtPlaceholder.Visibility = string.IsNullOrWhiteSpace(_txtInput.Text)
                ? System.Windows.Visibility.Visible
                : System.Windows.Visibility.Collapsed;
        }

        private static UserControl LoadFromEmbeddedXaml(string resourceName)
        {
            var asm = Assembly.GetExecutingAssembly();
            using (var stream = asm.GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                {
                    throw new InvalidOperationException(
                        $"Không tìm thấy embedded resource XAML: '{resourceName}'.");
                }

                using (var reader = XmlReader.Create(stream))
                {
                    return (UserControl)XamlReader.Load(reader);
                }
            }
        }
    }
}

