using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Forms.Integration;

namespace ReviewMovie.ModernUI
{
    /// <summary>
    /// WPF UI shell loaded from embedded XAML (no WPF build targets needed).
    /// This control is UI-only; logic remains in WinForms (FormMain).
    /// </summary>
    public sealed class ModernShellControl : UserControl
    {
        public Grid Root { get; }

        // Named elements we need to wire up
        public TextBox TextInputBox { get; }
        public TextBox SearchBox { get; }

        public Button BtnRecord { get; }
        public Button BtnNewLine { get; }
        public Button BtnAutoSubtitle { get; }
        public Button BtnCancel { get; }
        public Button BtnConvert { get; }
        public Button BtnSave { get; }
        public Button BtnRender { get; }
        public Button BtnClearText { get; }

        public WindowsFormsHost MainGridHost { get; }
        public WindowsFormsHost SettingsHost { get; }

        public ModernShellControl()
        {
            Root = (Grid)LoadEmbeddedXamlBySuffix("ModernUI.ModernShell.xaml");
            Content = Root;

            TextInputBox = (TextBox)Root.FindName("TextInputBox");
            SearchBox = (TextBox)Root.FindName("SearchBox");

            BtnRecord = (Button)Root.FindName("BtnRecord");
            BtnNewLine = (Button)Root.FindName("BtnNewLine");
            BtnAutoSubtitle = (Button)Root.FindName("BtnAutoSubtitle");
            BtnCancel = (Button)Root.FindName("BtnCancel");
            BtnConvert = (Button)Root.FindName("BtnConvert");
            BtnSave = (Button)Root.FindName("BtnSave");
            BtnRender = (Button)Root.FindName("BtnRender");
            BtnClearText = (Button)Root.FindName("BtnClearText");

            MainGridHost = (WindowsFormsHost)Root.FindName("MainGridHost");
            SettingsHost = (WindowsFormsHost)Root.FindName("SettingsHost");
        }

        private static object LoadEmbeddedXamlBySuffix(string suffix)
        {
            var asm = Assembly.GetExecutingAssembly();
            var name = asm.GetManifestResourceNames()
                .FirstOrDefault(n => n.EndsWith(suffix, StringComparison.OrdinalIgnoreCase));

            if (name == null)
                throw new InvalidOperationException($"Embedded XAML resource not found (suffix: {suffix}).");

            using (Stream stream = asm.GetManifestResourceStream(name))
            {
                if (stream == null)
                    throw new InvalidOperationException($"Failed to open embedded XAML resource: {name}");

                return XamlReader.Load(stream);
            }
        }
    }
}

