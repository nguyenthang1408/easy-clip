using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using ReviewMovie.Base.Controls.Common;

namespace ReviewMovie.Base.Controls
{
    public class UiDataGridView : DataGridView
    {
        private Color _gridBackColor = ThemeManager.Current.WindowBackColor;
        private Color _gridLineColor = ThemeManager.Current.Border;
        private Color _gridForeColor = ThemeManager.Current.TextPrimary;

        private Color _headerBackColor = ThemeManager.Current.SurfaceColor;
        private Color _headerForeColor = ThemeManager.Current.TextPrimary;
        private Font _headerFont;
        private int _headerHeight = 28;

        private Color _cellBackColor = Color.White;
        private Color _cellForeColor = ThemeManager.Current.TextPrimary;
        private Font _cellFont;
        private int _rowHeight = 26;

        private Color _borderColor = ThemeManager.Current.Border;
        private int _borderSize = 1;
        private int _borderRadius = 0;

        public UiDataGridView()
        {
            DoubleBuffered = true;
            _headerFont = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            _cellFont = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);

            EnableHeadersVisualStyles = false;
            RowHeadersVisible = false;
            BackgroundColor = _gridBackColor;
            GridColor = _gridLineColor;

            ApplyStyles();
        }

        [Category("Colors")]
        public Color GridBackColor { get => _gridBackColor; set { _gridBackColor = value; ApplyStyles(); } }

        [Category("Colors")]
        public Color GridLineColor { get => _gridLineColor; set { _gridLineColor = value; ApplyStyles(); } }

        [Category("Colors")]
        public Color GridForeColor { get => _gridForeColor; set { _gridForeColor = value; ApplyStyles(); } }

        [Category("Header Style")]
        public Color HeaderBackColor { get => _headerBackColor; set { _headerBackColor = value; ApplyStyles(); } }

        [Category("Header Style")]
        public Color HeaderForeColor { get => _headerForeColor; set { _headerForeColor = value; ApplyStyles(); } }

        [Category("Header Style")]
        public Font HeaderFont { get => _headerFont; set { _headerFont = value ?? _headerFont; ApplyStyles(); } }

        [Category("Header Style")]
        public int HeaderHeight { get => _headerHeight; set { _headerHeight = Math.Max(18, value); ApplyStyles(); } }

        [Category("Cell Style")]
        public Color CellBackColor { get => _cellBackColor; set { _cellBackColor = value; ApplyStyles(); } }

        [Category("Cell Style")]
        public Color CellForeColor { get => _cellForeColor; set { _cellForeColor = value; ApplyStyles(); } }

        [Category("Cell Style")]
        public Font CellFont { get => _cellFont; set { _cellFont = value ?? _cellFont; ApplyStyles(); } }

        [Category("Cell Style")]
        public int RowHeight { get => _rowHeight; set { _rowHeight = Math.Max(18, value); ApplyStyles(); } }

        [Category("Border & Grid")]
        public Color BorderColorEx { get => _borderColor; set { _borderColor = value; Invalidate(); } }

        [Category("Border & Grid")]
        public int BorderSizeEx { get => _borderSize; set { _borderSize = Math.Max(0, value); Invalidate(); } }

        [Category("Border & Grid")]
        public int BorderRadius { get => _borderRadius; set { _borderRadius = Math.Max(0, value); UiHelpers.ApplyRoundRegion(this, _borderRadius); Invalidate(); } }

        public void ApplyStyles()
        {
            BackgroundColor = _gridBackColor;
            GridColor = _gridLineColor;
            DefaultCellStyle.BackColor = _cellBackColor;
            DefaultCellStyle.ForeColor = _cellForeColor;
            DefaultCellStyle.Font = _cellFont;
            DefaultCellStyle.SelectionBackColor = ThemeManager.Current.SelectionBackColor;
            DefaultCellStyle.SelectionForeColor = ThemeManager.Current.SelectionForeColor;

            ColumnHeadersDefaultCellStyle.BackColor = _headerBackColor;
            ColumnHeadersDefaultCellStyle.ForeColor = _headerForeColor;
            ColumnHeadersDefaultCellStyle.Font = _headerFont;
            ColumnHeadersHeight = _headerHeight;

            RowTemplate.Height = _rowHeight;
            ForeColor = _gridForeColor;
            Invalidate();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            UiHelpers.ApplyRoundRegion(this, _borderRadius);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (e == null) return;
            if (_borderSize <= 0) return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            var rect = new Rectangle(0, 0, Width - 1, Height - 1);

            using (var pen = new Pen(_borderColor, _borderSize))
            using (var path = UiHelpers.CreateRoundedRectPath(rect, _borderRadius))
            {
                pen.Alignment = PenAlignment.Inset;
                e.Graphics.DrawPath(pen, path);
            }
        }
    }
}

