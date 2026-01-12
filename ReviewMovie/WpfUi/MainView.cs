using System;
using System.Reflection;
using System.Windows.Forms.Integration;
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
        public event EventHandler MergeSegmentsClicked;

        private readonly WpfControls.TextBox _txtInput;
        private readonly WpfControls.TextBlock _txtPlaceholder;
        private readonly WindowsFormsHost _hostToolStrip;
        private readonly WindowsFormsHost _hostDataGrid;

        public WpfControls.ComboBox CbProject { get; }
        public WpfControls.ComboBox CbVoiceSource { get; }
        public WpfControls.TextBox TxtApiKey { get; }
        public WpfControls.TextBox TxtToken { get; }
        public WpfControls.TextBlock TxtStatus { get; }

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
            _hostToolStrip = (WindowsFormsHost)root.FindName("HostToolStrip");
            _hostDataGrid = (WindowsFormsHost)root.FindName("HostDataGrid");

            // Right settings minimal
            CbProject = (WpfControls.ComboBox)root.FindName("CbProject");
            CbVoiceSource = (WpfControls.ComboBox)root.FindName("CbVoiceSource");
            TxtApiKey = (WpfControls.TextBox)root.FindName("TxtApiKey");
            TxtToken = (WpfControls.TextBox)root.FindName("TxtToken");
            TxtStatus = (WpfControls.TextBlock)root.FindName("TxtStatus");

            var btnCreateProject = (WpfControls.Button)root.FindName("BtnCreateProject");
            var btnSaveVoice = (WpfControls.Button)root.FindName("BtnSaveVoice");
            var btnMerge = (WpfControls.Button)root.FindName("BtnMergeSegments");

            btnCreateProject.Click += (_, __) => CreateProjectClicked?.Invoke(this, EventArgs.Empty);
            btnSaveVoice.Click += (_, __) => SaveVoiceClicked?.Invoke(this, EventArgs.Empty);
            btnMerge.Click += (_, __) => MergeSegmentsClicked?.Invoke(this, EventArgs.Empty);
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

        public void SetToolStrip(WinForms.Control toolStrip)
        {
            if (toolStrip == null) return;
            toolStrip.Dock = WinForms.DockStyle.Fill;
            if (toolStrip.Parent != null) toolStrip.Parent.Controls.Remove(toolStrip);
            _hostToolStrip.Child = toolStrip;
        }

        public void SetDataGrid(WinForms.Control grid)
        {
            if (grid == null) return;
            grid.Dock = WinForms.DockStyle.Fill;
            if (grid.Parent != null) grid.Parent.Controls.Remove(grid);
            _hostDataGrid.Child = grid;
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

