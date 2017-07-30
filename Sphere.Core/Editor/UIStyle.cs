using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sphere.Core.Editor
{
    /// <summary>
    /// Represents a theme used for styling the IDE's UI elements.
    /// </summary>
    public class UIStyle
    {
        /// <summary>
        /// Constructs a new UI style using OS default settings.
        /// </summary>
        /// <param name="name">A name to use for the theme.</param>
        public UIStyle(string name = null)
        {
            Name = name;

            AccentColor = SystemColors.Control;
            BackColor = SystemColors.Window;
            Font = new Font("Segoe UI", 8);
            FixedFont = new Font("Consolas", 10);
            TextColor = SystemColors.ControlText;
            LabelColor = SystemColors.ControlDarkDark;
            ToolColor = SystemColors.Control;
        }

        /// <summary>
        /// Gets the display name of the UI style.
        /// </summary>
        public string Name { get; private set; }        
        
        /// <summary>
        /// Gets or sets the accent color for the UI.
        /// </summary>
        public Color AccentColor { get; set; }

        /// <summary>
        /// Gets or sets the background color for text-based controls.
        /// </summary>
        public Color BackColor { get; set; }

        /// <summary>
        /// Gets or sets the font to use for fixed-width text, e.g. JS code.
        /// </summary>
        public Font FixedFont { get; set; }

        /// <summary>
        /// Gets or sets the font to use for UI elements.
        /// </summary>
        public Font Font { get; set; }

        /// <summary>
        /// Gets or sets the color to use for UI text.
        /// </summary>
        public Color TextColor { get; set; }

        public Color LabelColor { get; set; }

        public Color ToolColor { get; set; }

        /// <summary>
        /// Styles a UI control meant to display code or other fixed-width text.
        /// </summary>
        /// <param name="control">The control to be styled.</param>
        public void AsCodeView(Control control)
        {
            control.Font = this.FixedFont;
            control.ForeColor = this.TextColor;
            control.BackColor = this.BackColor;
        }

        /// <summary>
        /// Styles a control as a standard UI element.
        /// </summary>
        /// <param name="control">The control to be styled.</param>
        public void AsHeading(Control control)
        {
            control.Font = this.Font;
            control.ForeColor = this.TextColor;
            control.BackColor = this.LabelColor;
        }

        /// <summary>
        /// Styles a control as a text-based UI element.
        /// </summary>
        /// <param name="control">The control to be styled.</param>
        public void AsTextView(Control control)
        {
            control.Font = this.Font;
            control.ForeColor = this.TextColor;
            control.BackColor = this.BackColor;
        }

        /// <summary>
        /// Styles a control as a standard UI element.
        /// </summary>
        /// <param name="control">The control to be styled.</param>
        public void AsUIElement(Control control)
        {
            control.Font = this.Font;
            control.ForeColor = this.TextColor;
            control.BackColor = this.ToolColor;
        }
    }
}
