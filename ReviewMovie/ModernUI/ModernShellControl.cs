using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Forms.Integration;
using System.Windows;
using System.Windows.Input;

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
        public Button BtnClearText { get; }

        public WindowsFormsHost MainGridHost { get; }
        public WindowsFormsHost SettingsHost { get; }
        public WindowsFormsHost ToolbarHost { get; }

        // Header elements
        public Border TopHeader { get; }
        public TextBlock TxtStatus { get; }
        public TextBlock TxtRemaining { get; }
        public TextBlock TxtAvatar { get; }
        public Button BtnHelp { get; }
        public Button BtnSettings { get; }
        public Button BtnMinimize { get; }
        public Button BtnClose { get; }

        // Top cards (WPF controls)
        public Button BtnRecord { get; }
        public TextBox TextInputBox { get; }
        public TextBlock TextInputPlaceholder { get; }
        public FrameworkElement VisualDropZone { get; }
        public Button BtnConvert { get; }
        public Button BtnSave { get; }
        public Button BtnRender { get; }

        // Actions row
        public Button BtnNewLine { get; }
        public Button BtnAutoSubtitle { get; }
        public Button BtnCancel { get; }
        public TextBox SearchBox { get; }

        public ModernShellControl()
        {
            Root = (Grid)LoadEmbeddedXamlBySuffix("ModernUI.ModernShell.xaml");
            Content = Root;

            BtnClearText = (Button)Root.FindName("BtnClearText");

            MainGridHost = (WindowsFormsHost)Root.FindName("MainGridHost");
            SettingsHost = (WindowsFormsHost)Root.FindName("SettingsHost");
            ToolbarHost = (WindowsFormsHost)Root.FindName("ToolbarHost");

            TopHeader = (Border)Root.FindName("TopHeader");
            TxtStatus = (TextBlock)Root.FindName("TxtStatus");
            TxtRemaining = (TextBlock)Root.FindName("TxtRemaining");
            TxtAvatar = (TextBlock)Root.FindName("TxtAvatar");
            BtnHelp = (Button)Root.FindName("BtnHelp");
            BtnSettings = (Button)Root.FindName("BtnSettings");
            BtnMinimize = (Button)Root.FindName("BtnMinimize");
            BtnClose = (Button)Root.FindName("BtnClose");

            BtnRecord = (Button)Root.FindName("BtnRecord");
            TextInputBox = (TextBox)Root.FindName("TextInputBox");
            TextInputPlaceholder = (TextBlock)Root.FindName("TextInputPlaceholder");
            VisualDropZone = (FrameworkElement)Root.FindName("VisualDropZone");
            BtnConvert = (Button)Root.FindName("BtnConvert");
            BtnSave = (Button)Root.FindName("BtnSave");
            BtnRender = (Button)Root.FindName("BtnRender");

            BtnNewLine = (Button)Root.FindName("BtnNewLine");
            BtnAutoSubtitle = (Button)Root.FindName("BtnAutoSubtitle");
            BtnCancel = (Button)Root.FindName("BtnCancel");
            SearchBox = (TextBox)Root.FindName("SearchBox");

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

