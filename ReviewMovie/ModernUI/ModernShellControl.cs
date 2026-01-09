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
        public WindowsFormsHost RecordHost { get; }
        public WindowsFormsHost TextInputHost { get; }
        public WindowsFormsHost VisualsHost { get; }
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

        public ModernShellControl()
        {
            Root = (Grid)LoadEmbeddedXamlBySuffix("ModernUI.ModernShell.xaml");
            Content = Root;

            BtnClearText = (Button)Root.FindName("BtnClearText");

            MainGridHost = (WindowsFormsHost)Root.FindName("MainGridHost");
            SettingsHost = (WindowsFormsHost)Root.FindName("SettingsHost");
            RecordHost = (WindowsFormsHost)Root.FindName("RecordHost");
            TextInputHost = (WindowsFormsHost)Root.FindName("TextInputHost");
            VisualsHost = (WindowsFormsHost)Root.FindName("VisualsHost");
            ToolbarHost = (WindowsFormsHost)Root.FindName("ToolbarHost");

            TopHeader = (Border)Root.FindName("TopHeader");
            TxtStatus = (TextBlock)Root.FindName("TxtStatus");
            TxtRemaining = (TextBlock)Root.FindName("TxtRemaining");
            TxtAvatar = (TextBlock)Root.FindName("TxtAvatar");
            BtnHelp = (Button)Root.FindName("BtnHelp");
            BtnSettings = (Button)Root.FindName("BtnSettings");
            BtnMinimize = (Button)Root.FindName("BtnMinimize");
            BtnClose = (Button)Root.FindName("BtnClose");
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

