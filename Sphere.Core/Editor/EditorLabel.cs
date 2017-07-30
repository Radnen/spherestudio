using System;
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
            TextAlign = ContentAlignment.MiddleLeft;
            Height = 23;
            AutoSize = false;
            Dock = DockStyle.Top;

            Styler.AutoStyle(this);
        }

        /// <summary>
        /// Ensures the EditorLabel is styled properly upon creation.
        /// </summary>
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
        }

        /// <summary>
        /// Overrides the default background to draw a classy blue background.
        /// </summary>
        /// <param name="pevent"></param>
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            base.OnPaintBackground(pevent);
            //pevent.Graphics.FillRectangle(BgBrush, ClientRectangle);
        }

        public void ApplyStyle(UIStyle style)
        {
            style.AsHeading(this);
        }
    }
}
