using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace ReviewMovie.ModernUI
{
    public sealed class ModernTopCardsControl : UserControl
    {
        public Button BtnRecord { get; }
        public Button BtnClearText { get; }
        public TextBox TextInputBox { get; }
        public TextBlock TextInputPlaceholder { get; }
        public FrameworkElement VisualDropZone { get; }
        public Button BtnConvert { get; }
        public Button BtnSave { get; }
        public Button BtnRender { get; }

        public ModernTopCardsControl()
        {
            var root = (Grid)LoadEmbeddedXamlBySuffix("ModernUI.ModernTopCards.xaml");
            Content = root;

            BtnRecord = (Button)root.FindName("BtnRecord");
            BtnClearText = (Button)root.FindName("BtnClearText");
            TextInputBox = (TextBox)root.FindName("TextInputBox");
            TextInputPlaceholder = (TextBlock)root.FindName("TextInputPlaceholder");
            VisualDropZone = (FrameworkElement)root.FindName("VisualDropZone");
            BtnConvert = (Button)root.FindName("BtnConvert");
            BtnSave = (Button)root.FindName("BtnSave");
            BtnRender = (Button)root.FindName("BtnRender");

            if (TextInputBox != null && TextInputPlaceholder != null)
            {
                TextInputBox.TextChanged += (_, __) =>
                {
                    TextInputPlaceholder.Visibility = string.IsNullOrEmpty(TextInputBox.Text)
                        ? Visibility.Visible
                        : Visibility.Collapsed;
                };
                TextInputPlaceholder.Visibility = Visibility.Visible;
            }
        }

        private static object LoadEmbeddedXamlBySuffix(string suffix)
        {
            var asm = Assembly.GetExecutingAssembly();
            var name = asm.GetManifestResourceNames()
                .FirstOrDefault(n => n.EndsWith(suffix, StringComparison.OrdinalIgnoreCase));

            if (name == null)
                throw new InvalidOperationException("Embedded XAML resource not found (suffix: " + suffix + ").");

            using (Stream stream = asm.GetManifestResourceStream(name))
            {
                if (stream == null)
                    throw new InvalidOperationException("Failed to open embedded XAML resource: " + name);

                return XamlReader.Load(stream);
            }
        }
    }
}

