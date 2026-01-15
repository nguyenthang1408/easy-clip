using System.Drawing;
using System.Drawing.Drawing2D;

namespace ReviewMovie.Base
{
    internal static class UiBorder
    {
        internal static void DrawRounded(Graphics g, Rectangle rect, int radius, Color borderColor, float thickness = 1f)
        {
            if (g == null) return;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            UiHelpers.DrawRoundedBorder(g, rect, radius, borderColor, thickness);
        }
    }
}

