using System;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Markup;
using System.Xml;

namespace ReviewMovie.WpfUi
{
    public sealed class ModernSettingsView : UserControl
    {
        private readonly UserControl _root;

        public ComboBox CbProject { get; }
        public Button BtnCreateProject { get; }

        public ComboBox CbVoiceSource { get; }
        public TextBox TxtApiKey { get; }
        public TextBox TxtToken { get; }
        public Button BtnSaveVoice { get; }

        public ComboBox CbZoomUp { get; }
        public ComboBox CbZQuality { get; }
        public TextBox TxtFps { get; }
        public TextBox TxtThread { get; }
        public ComboBox CbQuality { get; }
        public ComboBox CbMode { get; }
        public ComboBox CbEffect { get; }

        public CheckBox ChkZoom { get; }
        public CheckBox ChkRotate { get; }
        public CheckBox ChkFlip { get; }
        public CheckBox ChkFlipRandom { get; }
        public CheckBox ChkMoveLR { get; }
        public CheckBox ChkOpenPlayer { get; }

        public TextBox TxtVolume { get; }
        public TextBox TxtSpeechSpeed { get; }
        public TextBox TxtAudioScaleFrom { get; }
        public TextBox TxtAudioScaleTo { get; }
        public CheckBox ChkMuted { get; }

        public ComboBox CbLanguage { get; }
        public ComboBox CbVoice { get; }
        public ComboBox CbTemplate { get; }
        public Button BtnSaveEffect { get; }

        public Button BtnMergeSegments { get; }
        public TextBlock TxtStatus { get; }

        public ModernSettingsView()
        {
            var root = LoadFromEmbeddedXaml("EasyClip.WpfUi.ModernSettings.xaml");
            _root = root;
            Resources = root.Resources;
            Content = root.Content;

            CbProject = (ComboBox)root.FindName("CbProject");
            BtnCreateProject = (Button)root.FindName("BtnCreateProject");

            CbVoiceSource = (ComboBox)root.FindName("CbVoiceSource");
            TxtApiKey = (TextBox)root.FindName("TxtApiKey");
            TxtToken = (TextBox)root.FindName("TxtToken");
            BtnSaveVoice = (Button)root.FindName("BtnSaveVoice");

            CbZoomUp = (ComboBox)root.FindName("CbZoomUp");
            CbZQuality = (ComboBox)root.FindName("CbZQuality");
            TxtFps = (TextBox)root.FindName("TxtFps");
            TxtThread = (TextBox)root.FindName("TxtThread");
            CbQuality = (ComboBox)root.FindName("CbQuality");
            CbMode = (ComboBox)root.FindName("CbMode");
            CbEffect = (ComboBox)root.FindName("CbEffect");

            ChkZoom = (CheckBox)root.FindName("ChkZoom");
            ChkRotate = (CheckBox)root.FindName("ChkRotate");
            ChkFlip = (CheckBox)root.FindName("ChkFlip");
            ChkFlipRandom = (CheckBox)root.FindName("ChkFlipRandom");
            ChkMoveLR = (CheckBox)root.FindName("ChkMoveLR");
            ChkOpenPlayer = (CheckBox)root.FindName("ChkOpenPlayer");

            TxtVolume = (TextBox)root.FindName("TxtVolume");
            TxtSpeechSpeed = (TextBox)root.FindName("TxtSpeechSpeed");
            TxtAudioScaleFrom = (TextBox)root.FindName("TxtAudioScaleFrom");
            TxtAudioScaleTo = (TextBox)root.FindName("TxtAudioScaleTo");
            ChkMuted = (CheckBox)root.FindName("ChkMuted");

            CbLanguage = (ComboBox)root.FindName("CbLanguage");
            CbVoice = (ComboBox)root.FindName("CbVoice");
            CbTemplate = (ComboBox)root.FindName("CbTemplate");
            BtnSaveEffect = (Button)root.FindName("BtnSaveEffect");

            BtnMergeSegments = (Button)root.FindName("BtnMergeSegments");
            TxtStatus = (TextBlock)root.FindName("TxtStatus");
        }

        public void SetUiScale(double scale)
        {
            if (scale <= 0) scale = 1.0;
            if (scale > 1.0) scale = 1.0;
            if (scale < 0.80) scale = 0.80;

            if (_root?.Content is System.Windows.FrameworkElement fe)
            {
                fe.LayoutTransform = new ScaleTransform(scale, scale);
            }
        }

        public void SetStatus(string text)
        {
            TxtStatus.Text = text ?? string.Empty;
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

