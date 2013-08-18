using System;
using System.Windows.Forms;

namespace Sphere.Core.Editor
{
    /// <summary>
    /// Styles different .NET controls with different styles.
    /// </summary>
    public class StyleGroup
    {
        /// <summary>
        /// Used for Labels.
        /// </summary>
        public Style Label { get; set; }

        /// <summary>
        /// Used for Panels, TabPages, and Panes.
        /// </summary>
        public Style Panel { get; set; }

        /// <summary>
        /// Used for PictureBoxes.
        /// </summary>
        public Style Image { get; set; }

        /// <summary>
        /// Used for Buttons.
        /// </summary>
        public Style Button { get; set; }

        /// <summary>
        /// Applies a set style to the type of control.
        /// </summary>
        /// <param name="ctrl">The .NET control to style.</param>
        public void Apply(Control ctrl)
        {
            if (ctrl is Label && Label != null) Label.Apply(ctrl);
            if (ctrl is Panel || ctrl is TabPage && Panel != null) Panel.Apply(ctrl);
            if (ctrl is PictureBox && Image != null) Image.Apply(ctrl);
            if (ctrl is Button && Button != null) Button.Apply(ctrl);
        }
    }
}
