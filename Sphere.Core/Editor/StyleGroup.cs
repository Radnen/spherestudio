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
        public Style LabelStyle { get; set; }

        /// <summary>
        /// Used for Panels, TabPages, and Panes.
        /// </summary>
        public Style PanelStyle { get; set; }

        /// <summary>
        /// Used for any other control that needs a different style.
        /// Usually reserved for sub-headings or sub-controls.
        /// </summary>
        public Style SecondaryStyle { get; set; }

        /// <summary>
        /// Used for PictureBoxes.
        /// </summary>
        public Style ImageStyle { get; set; }

        /// <summary>
        /// Used for Buttons.
        /// </summary>
        public Style ButtonStyle { get; set; }

        /// <summary>
        /// Used to style text-entry controls.
        /// </summary>
        public Style TextBoxStyle { get; set; }
        
        /// <summary>
        /// Used for styling dialog window backgrounds.
        /// </summary>
        public Style WindowStyle { get; set; }

        /// <summary>
        /// Used for styling the status bar.
        /// </summary>
        public Style StatusBarStyle { get; set; }

        /// <summary>
        /// Used for styling menubars.
        /// </summary>
        public Style MenuBarStyle { get; set; }

        /// <summary>
        /// Used for styling toolbars.
        /// </summary>
        public Style ToolBarStyle { get; set; }

        /// <summary>
        /// Applies a set style to the type of control.
        /// </summary>
        /// <param name="ctrl">The .NET control to style.</param>
        public void ApplyPrimary(Control ctrl)
        {
            if (ctrl is Label && LabelStyle != null) LabelStyle.Apply(ctrl);
            else if ((ctrl is Panel || ctrl is TabPage || ctrl is ListView) && PanelStyle != null) PanelStyle.Apply(ctrl);
            else if (ctrl is PictureBox && ImageStyle != null) ImageStyle.Apply(ctrl);
            else if (ctrl is TextBox && TextBoxStyle != null) TextBoxStyle.Apply(ctrl);
            else if (ctrl is Button && ButtonStyle != null) ButtonStyle.Apply(ctrl);
            else if (ctrl is MenuStrip && MenuBarStyle != null) MenuBarStyle.Apply(ctrl);
            else if (ctrl is StatusBar && StatusBarStyle != null) StatusBarStyle.Apply(ctrl);
            else if (ctrl is ToolStrip && ToolBarStyle != null) ToolBarStyle.Apply(ctrl);
            else if (ctrl is Form && WindowStyle != null) WindowStyle.Apply(ctrl);
        }

        /// <summary>
        /// Applies a secondary style to a tertiary control or form.
        /// </summary>
        /// <param name="ctrl"></param>
        public void ApplySecondary(Control ctrl)
        {
            if (SecondaryStyle != null)
                SecondaryStyle.Apply(ctrl);
        }
    }
}
