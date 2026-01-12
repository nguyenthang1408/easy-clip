using System;
using System.Reflection;
using System.Windows.Markup;
using System.Windows;
using System.Xml;
using WpfControls = System.Windows.Controls;
using WinForms = System.Windows.Forms;

namespace ReviewMovie.WpfUi
{
    public sealed class MainView : WpfControls.UserControl
    {
        // Title bar
        public event EventHandler MinimizeClicked;
        public event EventHandler MaximizeClicked;
        public event EventHandler CloseClicked;
        public event EventHandler DragRequested;

        // Header actions
        public event EventHandler StartRecordClicked;
        public event EventHandler ConvertClicked;
        public event EventHandler SaveClicked;
        public event EventHandler RenderClicked;
        public event EventHandler ClearClicked;
        public event EventHandler TextChanged;

        // Right actions
        public event EventHandler CreateProjectClicked;
        public event EventHandler SaveVoiceClicked;
        public event EventHandler SaveEffectClicked;
        public event EventHandler MergeSegmentsClicked;
        public event EventHandler NewLineClicked;
        public event EventHandler AutoSubtitleClicked;
        public event EventHandler CancelClicked;
        public event EventHandler<int> RowSelected;

        private readonly WpfControls.TextBox _txtInput;
        private readonly WpfControls.TextBlock _txtPlaceholder;
        private readonly WpfControls.DataGrid _mainGrid;

        public WpfControls.ComboBox CbProject { get; }
        public WpfControls.ComboBox CbVoiceSource { get; }
        public WpfControls.TextBox TxtApiKey { get; }
        public WpfControls.TextBox TxtToken { get; }
        public WpfControls.TextBlock TxtStatus { get; }

        // Restored settings controls
        public WpfControls.ComboBox CbZoomUp { get; }
        public WpfControls.ComboBox CbZQuality { get; }
        public WpfControls.TextBox TxtFps { get; }
        public WpfControls.TextBox TxtThread { get; }
        public WpfControls.ComboBox CbQuality { get; }
        public WpfControls.ComboBox CbMode { get; }
        public WpfControls.ComboBox CbEffect { get; }

        public WpfControls.CheckBox ChkZoom { get; }
        public WpfControls.CheckBox ChkRotate { get; }
        public WpfControls.CheckBox ChkFlip { get; }
        public WpfControls.CheckBox ChkFlipRandom { get; }
        public WpfControls.CheckBox ChkMoveLR { get; }
        public WpfControls.CheckBox ChkOpenPlayer { get; }
        public WpfControls.CheckBox ChkMuted { get; }

        public WpfControls.TextBox TxtVolume { get; }
        public WpfControls.TextBox TxtSpeechSpeed { get; }
        public WpfControls.TextBox TxtAudioScaleFrom { get; }
        public WpfControls.TextBox TxtAudioScaleTo { get; }

        public WpfControls.ComboBox CbLanguage { get; }
        public WpfControls.ComboBox CbVoice { get; }
        public WpfControls.ComboBox CbTemplate { get; }

        public MainView()
        {
            var theme = LoadResourceDictionary("EasyClip.WpfUi.Theme.xaml");
            var root = LoadUserControl("EasyClip.WpfUi.MainView.xaml");

            // Merge theme into root resources
            root.Resources.MergedDictionaries.Add(theme);
            Resources = root.Resources;
            Content = root.Content;

            // Title bar wiring
            var dragArea = (WpfControls.Grid)root.FindName("DragArea");
            var btnMin = (WpfControls.Button)root.FindName("BtnMinimize");
            var btnMax = (WpfControls.Button)root.FindName("BtnMaximize");
            var btnClose = (WpfControls.Button)root.FindName("BtnClose");

            btnMin.Click += (_, __) => MinimizeClicked?.Invoke(this, EventArgs.Empty);
            btnMax.Click += (_, __) => MaximizeClicked?.Invoke(this, EventArgs.Empty);
            btnClose.Click += (_, __) => CloseClicked?.Invoke(this, EventArgs.Empty);

            dragArea.MouseLeftButtonDown += (_, e) =>
            {
                if (e.ClickCount == 2)
                {
                    MaximizeClicked?.Invoke(this, EventArgs.Empty);
                    return;
                }
                DragRequested?.Invoke(this, EventArgs.Empty);
            };

            // Header controls
            _txtInput = (WpfControls.TextBox)root.FindName("TxtInput");
            _txtPlaceholder = (WpfControls.TextBlock)root.FindName("TxtPlaceholder");

            var btnStartRecord = (WpfControls.Button)root.FindName("BtnStartRecord");
            var btnConvert = (WpfControls.Button)root.FindName("BtnConvert");
            var btnSave = (WpfControls.Button)root.FindName("BtnSave");
            var btnRender = (WpfControls.Button)root.FindName("BtnRender");
            var btnClear = (WpfControls.Button)root.FindName("BtnClearText");

            btnStartRecord.Click += (_, __) => StartRecordClicked?.Invoke(this, EventArgs.Empty);
            btnConvert.Click += (_, __) => ConvertClicked?.Invoke(this, EventArgs.Empty);
            btnSave.Click += (_, __) => SaveClicked?.Invoke(this, EventArgs.Empty);
            btnRender.Click += (_, __) => RenderClicked?.Invoke(this, EventArgs.Empty);
            btnClear.Click += (_, __) => ClearClicked?.Invoke(this, EventArgs.Empty);

            _txtInput.TextChanged += (_, __) =>
            {
                UpdatePlaceholder();
                TextChanged?.Invoke(this, EventArgs.Empty);
            };
            UpdatePlaceholder();

            // Hosts
            _mainGrid = (WpfControls.DataGrid)root.FindName("MainGrid");
            if (_mainGrid != null)
            {
                _mainGrid.SelectionChanged += (_, __) =>
                {
                    if (_mainGrid.SelectedIndex >= 0)
                        RowSelected?.Invoke(this, _mainGrid.SelectedIndex);
                };
            }

            var btnNewLine = root.FindName("BtnNewLine") as WpfControls.Button;
            var btnAutoSubtitle = root.FindName("BtnAutoSubtitle") as WpfControls.Button;
            var btnCancel = root.FindName("BtnCancel") as WpfControls.Button;
            if (btnNewLine != null) btnNewLine.Click += (_, __) => NewLineClicked?.Invoke(this, EventArgs.Empty);
            if (btnAutoSubtitle != null) btnAutoSubtitle.Click += (_, __) => AutoSubtitleClicked?.Invoke(this, EventArgs.Empty);
            if (btnCancel != null) btnCancel.Click += (_, __) => CancelClicked?.Invoke(this, EventArgs.Empty);

            // Right settings minimal
            CbProject = (WpfControls.ComboBox)root.FindName("CbProject");
            CbVoiceSource = (WpfControls.ComboBox)root.FindName("CbVoiceSource");
            TxtApiKey = (WpfControls.TextBox)root.FindName("TxtApiKey");
            TxtToken = (WpfControls.TextBox)root.FindName("TxtToken");
            TxtStatus = (WpfControls.TextBlock)root.FindName("TxtStatus");

            var btnCreateProject = (WpfControls.Button)root.FindName("BtnCreateProject");
            var btnSaveVoice = (WpfControls.Button)root.FindName("BtnSaveVoice");
            var btnMerge = (WpfControls.Button)root.FindName("BtnMergeSegments");
            var btnSaveEffect = root.FindName("BtnSaveEffect") as WpfControls.Button;

            btnCreateProject.Click += (_, __) => CreateProjectClicked?.Invoke(this, EventArgs.Empty);
            btnSaveVoice.Click += (_, __) => SaveVoiceClicked?.Invoke(this, EventArgs.Empty);
            btnMerge.Click += (_, __) => MergeSegmentsClicked?.Invoke(this, EventArgs.Empty);
            if (btnSaveEffect != null) btnSaveEffect.Click += (_, __) => SaveEffectClicked?.Invoke(this, EventArgs.Empty);

            // Restored settings controls
            CbZoomUp = root.FindName("CbZoomUp") as WpfControls.ComboBox;
            CbZQuality = root.FindName("CbZQuality") as WpfControls.ComboBox;
            TxtFps = root.FindName("TxtFps") as WpfControls.TextBox;
            TxtThread = root.FindName("TxtThread") as WpfControls.TextBox;
            CbQuality = root.FindName("CbQuality") as WpfControls.ComboBox;
            CbMode = root.FindName("CbMode") as WpfControls.ComboBox;
            CbEffect = root.FindName("CbEffect") as WpfControls.ComboBox;

            ChkZoom = root.FindName("ChkZoom") as WpfControls.CheckBox;
            ChkRotate = root.FindName("ChkRotate") as WpfControls.CheckBox;
            ChkFlip = root.FindName("ChkFlip") as WpfControls.CheckBox;
            ChkFlipRandom = root.FindName("ChkFlipRandom") as WpfControls.CheckBox;
            ChkMoveLR = root.FindName("ChkMoveLR") as WpfControls.CheckBox;
            ChkOpenPlayer = root.FindName("ChkOpenPlayer") as WpfControls.CheckBox;
            ChkMuted = root.FindName("ChkMuted") as WpfControls.CheckBox;

            TxtVolume = root.FindName("TxtVolume") as WpfControls.TextBox;
            TxtSpeechSpeed = root.FindName("TxtSpeechSpeed") as WpfControls.TextBox;
            TxtAudioScaleFrom = root.FindName("TxtAudioScaleFrom") as WpfControls.TextBox;
            TxtAudioScaleTo = root.FindName("TxtAudioScaleTo") as WpfControls.TextBox;

            CbLanguage = root.FindName("CbLanguage") as WpfControls.ComboBox;
            CbVoice = root.FindName("CbVoice") as WpfControls.ComboBox;
            CbTemplate = root.FindName("CbTemplate") as WpfControls.ComboBox;
        }

        public string InputText
        {
            get => _txtInput.Text ?? string.Empty;
            set
            {
                _txtInput.Text = value ?? string.Empty;
                UpdatePlaceholder();
            }
        }

        public void SetItemsSource(object itemsSource)
        {
            if (_mainGrid == null) return;
            _mainGrid.ItemsSource = itemsSource as System.Collections.IEnumerable;
        }

        public void SelectRow(int index)
        {
            if (_mainGrid == null) return;
            if (index < 0 || index >= _mainGrid.Items.Count) return;
            _mainGrid.SelectedIndex = index;
            _mainGrid.ScrollIntoView(_mainGrid.SelectedItem);
        }

        public void SetStatus(string text) => TxtStatus.Text = text ?? string.Empty;

        private void UpdatePlaceholder()
        {
            _txtPlaceholder.Visibility = string.IsNullOrWhiteSpace(_txtInput.Text)
                ? Visibility.Visible
                : Visibility.Collapsed;
        }

        private static ResourceDictionary LoadResourceDictionary(string resourceName)
        {
            var asm = Assembly.GetExecutingAssembly();
            using (var stream = asm.GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                    throw new InvalidOperationException($"Không tìm thấy embedded resource: '{resourceName}'.");
                using (var reader = XmlReader.Create(stream))
                {
                    return (ResourceDictionary)XamlReader.Load(reader);
                }
            }
        }

        private static WpfControls.UserControl LoadUserControl(string resourceName)
        {
            var asm = Assembly.GetExecutingAssembly();
            using (var stream = asm.GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                    throw new InvalidOperationException($"Không tìm thấy embedded resource: '{resourceName}'.");
                using (var reader = XmlReader.Create(stream))
                {
                    return (WpfControls.UserControl)XamlReader.Load(reader);
                }
            }
        }
    }
}

