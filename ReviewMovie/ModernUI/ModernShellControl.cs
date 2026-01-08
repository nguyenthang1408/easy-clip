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

        public Button BtnNewLine { get; }
        public Button BtnAutoSubtitle { get; }
        public Button BtnCancel { get; }
        public Button BtnConvert { get; }
        public Button BtnSave { get; }
        public Button BtnRender { get; }
        public Button BtnMerge { get; }
        public Button BtnCreateProject { get; }
        public Button BtnClearText { get; }

        public ComboBox ProjectCombo { get; }
        public ComboBox VoiceSourceCombo { get; }
        public ComboBox QualityCombo { get; }
        public ComboBox LanguageCombo { get; }
        public ComboBox VoiceCombo { get; }

        public TextBox ZoomBox { get; }
        public TextBox FpsBox { get; }

        public RadioButton RbCpu { get; }
        public RadioButton RbGpu { get; }

        public WindowsFormsHost MainGridHost { get; }

        public ModernShellControl()
        {
            Root = (Grid)LoadEmbeddedXamlBySuffix("ModernUI.ModernShell.xaml");
            Content = Root;

            TextInputBox = (TextBox)Root.FindName("TextInputBox");
            SearchBox = (TextBox)Root.FindName("SearchBox");

            BtnNewLine = (Button)Root.FindName("BtnNewLine");
            BtnAutoSubtitle = (Button)Root.FindName("BtnAutoSubtitle");
            BtnCancel = (Button)Root.FindName("BtnCancel");
            BtnConvert = (Button)Root.FindName("BtnConvert");
            BtnSave = (Button)Root.FindName("BtnSave");
            BtnRender = (Button)Root.FindName("BtnRender");
            BtnMerge = (Button)Root.FindName("BtnMerge");
            BtnCreateProject = (Button)Root.FindName("BtnCreateProject");
            BtnClearText = (Button)Root.FindName("BtnClearText");

            ProjectCombo = (ComboBox)Root.FindName("ProjectCombo");
            VoiceSourceCombo = (ComboBox)Root.FindName("VoiceSourceCombo");
            QualityCombo = (ComboBox)Root.FindName("QualityCombo");
            LanguageCombo = (ComboBox)Root.FindName("LanguageCombo");
            VoiceCombo = (ComboBox)Root.FindName("VoiceCombo");

            ZoomBox = (TextBox)Root.FindName("ZoomBox");
            FpsBox = (TextBox)Root.FindName("FpsBox");

            RbCpu = (RadioButton)Root.FindName("RbCpu");
            RbGpu = (RadioButton)Root.FindName("RbGpu");

            MainGridHost = (WindowsFormsHost)Root.FindName("MainGridHost");
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

