using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using ReviewMovie.Base.Controls.Common;

namespace ReviewMovie.Base.Controls
{
    public sealed class UiToolStripColors
    {
        public Color BackColor { get; set; } = ThemeManager.Current.SurfaceColor;
        public Color ItemForeColor { get; set; } = ThemeManager.Current.TextPrimary;
        public Color BorderColor { get; set; } = ThemeManager.Current.Border;
        public int BorderSize { get; set; } = 1;
        public int ItemBorderRadius { get; set; } = 8;
    }

    public class UiToolStripRenderer : ToolStripProfessionalRenderer
    {
        private readonly UiToolStripColors _colors;

        public UiToolStripRenderer(UiToolStripColors colors)
            : base(new ProfessionalColorTable())
        {
            _colors = colors ?? new UiToolStripColors();
            RoundedEdges = false;
        }

        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            if (e?.Graphics == null || e.ToolStrip == null) return;
            e.Graphics.Clear(_colors.BackColor);
        }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            if (e?.Graphics == null || e.ToolStrip == null) return;
            if (_colors.BorderSize <= 0) return;

            var rect = new Rectangle(0, 0, e.ToolStrip.Width - 1, e.ToolStrip.Height - 1);
            using (var pen = new Pen(_colors.BorderColor, _colors.BorderSize))
            {
                pen.Alignment = PenAlignment.Inset;
                e.Graphics.DrawRectangle(pen, rect);
            }
        }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            if (e == null) return;
            e.TextColor = _colors.ItemForeColor;
            base.OnRenderItemText(e);
        }

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            if (e?.Graphics == null || e.Item == null) return;

            var rect = new Rectangle(Point.Empty, e.Item.Size);
            var back = e.Item.Selected ? ThemeManager.Current.Hover : _colors.BackColor;

            using (var path = UiHelpers.CreateRoundedRectPath(Rectangle.Inflate(rect, -2, -2), _colors.ItemBorderRadius))
            using (var b = new SolidBrush(back))
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.FillPath(b, path);
            }
        }
    }
}

