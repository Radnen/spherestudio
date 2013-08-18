using System.Drawing;
using System.Windows.Forms;

namespace Sphere.Core.Editor
{
    /// <summary>
    /// A styling object that can be applied when themeing the editor components.
    /// </summary>
    public class Style
    {
        /// <summary>
        /// Gets or sets the Back Color used by this style.
        /// </summary>
        public Color BackColor { get; set; }

        /// <summary>
        /// Gets or sets the Fore Color used by this style.
        /// </summary>
        public Color ForeColor { get; set; }

        /// <summary>
        /// Gets or sets the Image used by this style.
        /// </summary>
        public Image Image { get; set; }

        /// <summary>
        /// Gets or sets the font used by this style.
        /// </summary>
        public Font Font { get; set; }

        /// <summary>
        /// Constructs a new instance of the style object.
        /// </summary>
        public Style()
        {
            BackColor = SystemColors.Control;
            ForeColor = SystemColors.ControlText;
            Font = SystemFonts.DialogFont;
            Image = null;
        }

        /// <summary>
        /// Constructs a new instance of the style object.
        /// </summary>
        /// <param name="back">Back color.</param>
        /// <param name="front">Text color.</param>
        /// <param name="font">Font to use.</param>
        public Style(Color? back, Color? front, Font font)
        {
            if (back.HasValue)
                BackColor = back.Value;
            else
                BackColor = SystemColors.Control;
            if (front.HasValue)
                ForeColor = front.Value;
            else
                ForeColor = SystemColors.ControlText;
            if (font != null)
                Font = font;
            else
                Font = SystemFonts.DefaultFont;
            Image = null;
        }

        static Style()
        {
            Default = new Style();
            Default.BackColor = SystemColors.Control;
            Default.ForeColor = SystemColors.ControlText;
            Default.Font = SystemFonts.DefaultFont;
        }

        /// <summary>
        /// Adds this style to the .NET control.
        /// </summary>
        public void Apply(Control ctrl)
        {
            ctrl.BackColor = BackColor;
            ctrl.ForeColor = ForeColor;
        }

        /// <summary>
        /// Gets the default OS style.
        /// </summary>
        public static readonly Style Default;
    }
}
