using System;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Xml;

namespace ReviewMovie.WpfUi
{
    public sealed class ModernTitleBarView : UserControl
    {
        public event EventHandler MinimizeClicked;
        public event EventHandler CloseClicked;
        public event EventHandler DragRequested;

        public ModernTitleBarView()
        {
            var root = LoadFromEmbeddedXaml("EasyClip.WpfUi.ModernTitleBar.xaml");
            Resources = root.Resources;
            Content = root.Content;

            var btnMin = (Button)root.FindName("BtnMinimize");
            var btnClose = (Button)root.FindName("BtnClose");
            var dragArea = (Grid)root.FindName("DragArea");

            btnMin.Click += (_, __) => MinimizeClicked?.Invoke(this, EventArgs.Empty);
            btnClose.Click += (_, __) => CloseClicked?.Invoke(this, EventArgs.Empty);

            dragArea.MouseLeftButtonDown += (_, e) =>
            {
                if (e.ClickCount == 1)
                {
                    DragRequested?.Invoke(this, EventArgs.Empty);
                }
            };
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

