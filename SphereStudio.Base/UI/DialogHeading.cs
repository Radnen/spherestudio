using System;
using System.Drawing;
using System.Windows.Forms;

using SphereStudio.Base;

namespace SphereStudio.UI
{
    /// <summary>
    /// A dialog header which automatically adapts to the UI style.
    /// </summary>
    public class DialogHeader : Label, IStyleAware
    {
        private static readonly Brush BgBrush = new TextureBrush(Properties.Resources.BarImage);

        /// <summary>
        /// Constructs a new instance of a DialogHeader.
        /// </summary>
        public DialogHeader()
        {
            TextAlign = ContentAlignment.MiddleLeft;
            Height = 23;
            AutoSize = false;
            Dock = DockStyle.Top;

            StyleManager.AutoStyle(this);
        }

        /// <summary>
        /// Called by the IDE to style the control.
        /// </summary>
        /// <param name="style"></param>
        public void ApplyStyle(UIStyle style)
        {
            style.AsHeading(this);
        }
    }
}
