using System.Drawing;
using System.Windows.Forms;

namespace Sphere.Core.Editor
{
    /// <summary>
    /// A label with a blue-themed background.
    /// </summary>
    public class EditorLabel : Label, IStyleable
    {
        private static readonly Brush BgBrush = new TextureBrush(Properties.Resources.BarImage);

        /// <summary>
        /// Constructs a new instance of an EditorLabel.
        /// </summary>
        public EditorLabel()
        {
            Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TextAlign = ContentAlignment.MiddleLeft;
            Height = 23;
            AutoSize = false;
            Dock = DockStyle.Top;
        }

        /// <summary>
        /// Ensures the EditorLabel is styled properly upon creation.
        /// </summary>
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            UpdateStyle();
        }

        /// <summary>
        /// Overrides the default background to draw a classy blue background.
        /// </summary>
        /// <param name="pevent"></param>
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            UpdateStyle();
            base.OnPaintBackground(pevent);
            //pevent.Graphics.FillRectangle(BgBrush, ClientRectangle);
        }

        /// <summary>
        /// Updates the style of this label to one of the built-in styles.
        /// </summary>
        public void UpdateStyle()
        {
            StyleSettings.ApplyStyle(this);
        }
    }
}
