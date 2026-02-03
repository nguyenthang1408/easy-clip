using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ReviewMovie.Base.Controls
{
    /// <summary>
    /// Hosts a <see cref="UiButton"/> inside a <see cref="ToolStrip"/> as a <see cref="ToolStripItem"/>.
    /// This is used to keep UI common styling while remaining ToolStrip-compatible.
    /// </summary>
    [ToolboxItem(true)]
    public class UiToolStripButtonHost : ToolStripControlHost
    {
        public UiToolStripButtonHost()
            : base(new UiButton())
        {
            // ToolStrip prefers explicit sizing for hosted controls in many layouts.
            base.AutoSize = false;

            // Forward hosted button click to ToolStripItem click.
            InnerButton.Click += (_, e) =>
            {
                if (base.Enabled) base.PerformClick();
            };
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public UiButton InnerButton => (UiButton)Control;

        // ---- Pass-through properties (used by Form designer) ----

        public new string AccessibleName
        {
            get => InnerButton.AccessibleName;
            set => InnerButton.AccessibleName = value;
        }

        public new Color BackColor
        {
            get => InnerButton.BackColor;
            set
            {
                base.BackColor = value;
                InnerButton.BackColor = value;
            }
        }

        public Color BackgroundColor
        {
            get => InnerButton.BackgroundColor;
            set => InnerButton.BackgroundColor = value;
        }

        public Color BorderColor
        {
            get => InnerButton.BorderColor;
            set => InnerButton.BorderColor = value;
        }

        public Color BorderHoverColor
        {
            get => InnerButton.BorderHoverColor;
            set => InnerButton.BorderHoverColor = value;
        }

        public int BorderRadius
        {
            get => InnerButton.BorderRadius;
            set => InnerButton.BorderRadius = value;
        }

        public Color DisabledColor
        {
            get => InnerButton.DisabledColor;
            set => InnerButton.DisabledColor = value;
        }

        public new FlatStyle FlatStyle
        {
            get => InnerButton.FlatStyle;
            set => InnerButton.FlatStyle = value;
        }

        public new Font Font
        {
            get => InnerButton.Font;
            set
            {
                base.Font = value;
                InnerButton.Font = value;
            }
        }

        public new Color ForeColor
        {
            get => InnerButton.ForeColor;
            set
            {
                base.ForeColor = value;
                InnerButton.ForeColor = value;
            }
        }

        public Color HoverColor
        {
            get => InnerButton.HoverColor;
            set => InnerButton.HoverColor = value;
        }

        public Image IconImage
        {
            get => InnerButton.IconImage;
            set => InnerButton.IconImage = value;
        }

        public int IconPadding
        {
            get => InnerButton.IconPadding;
            set => InnerButton.IconPadding = value;
        }

        public Size IconSize
        {
            get => InnerButton.IconSize;
            set => InnerButton.IconSize = value;
        }

        public ContentAlignment ImageAlignEx
        {
            get => InnerButton.ImageAlignEx;
            set => InnerButton.ImageAlignEx = value;
        }

        /// <summary>
        /// Designer may set Location even though ToolStrip ignores it; we forward to the hosted control.
        /// </summary>
        public Point Location
        {
            get => InnerButton.Location;
            set => InnerButton.Location = value;
        }

        public new Padding Margin
        {
            get => base.Margin;
            set
            {
                base.Margin = value;
                InnerButton.Margin = value;
            }
        }

        public new string Name
        {
            get => base.Name;
            set
            {
                base.Name = value;
                InnerButton.Name = value;
            }
        }

        public new Padding Padding
        {
            get => InnerButton.Padding;
            set => InnerButton.Padding = value;
        }

        public Color PressedColor
        {
            get => InnerButton.PressedColor;
            set => InnerButton.PressedColor = value;
        }

        public new Size Size
        {
            get => base.Size;
            set
            {
                base.Size = value;
                InnerButton.Size = value;
            }
        }

        /// <summary>
        /// Designer may set TabIndex; we forward to hosted control.
        /// </summary>
        public int TabIndex
        {
            get => InnerButton.TabIndex;
            set => InnerButton.TabIndex = value;
        }

        public new object Tag
        {
            get => InnerButton.Tag;
            set
            {
                base.Tag = value;
                InnerButton.Tag = value;
            }
        }

        public new string Text
        {
            get => InnerButton.Text;
            set
            {
                base.Text = value;
                InnerButton.Text = value;
            }
        }

        public Color TextColor
        {
            get => InnerButton.TextColor;
            set => InnerButton.TextColor = value;
        }

        public Color TextHoverColor
        {
            get => InnerButton.TextHoverColor;
            set => InnerButton.TextHoverColor = value;
        }

        public bool UseVisualStyleBackColor
        {
            get => InnerButton.UseVisualStyleBackColor;
            set => InnerButton.UseVisualStyleBackColor = value;
        }

        public new bool Enabled
        {
            get => base.Enabled;
            set
            {
                base.Enabled = value;
                InnerButton.Enabled = value;
            }
        }
    }
}

