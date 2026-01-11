using System;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Xml;

namespace ReviewMovie.WpfUi
{
    public sealed class ModernActionBarView : UserControl
    {
        public event EventHandler NewLineClicked;
        public event EventHandler AutoSubtitleClicked;
        public event EventHandler CancelClicked;

        public ModernActionBarView()
        {
            var root = LoadFromEmbeddedXaml("EasyClip.WpfUi.ModernActionBar.xaml");
            Resources = root.Resources;
            Content = root.Content;

            var btnNewLine = (Button)root.FindName("BtnNewLine");
            var btnAuto = (Button)root.FindName("BtnAutoSubtitle");
            var btnCancel = (Button)root.FindName("BtnCancel");

            btnNewLine.Click += (_, __) => NewLineClicked?.Invoke(this, EventArgs.Empty);
            btnAuto.Click += (_, __) => AutoSubtitleClicked?.Invoke(this, EventArgs.Empty);
            btnCancel.Click += (_, __) => CancelClicked?.Invoke(this, EventArgs.Empty);
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

