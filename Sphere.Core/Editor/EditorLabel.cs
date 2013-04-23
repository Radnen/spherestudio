using System.Drawing;
using System.Windows.Forms;

namespace Sphere.Core.Editor
{
    public class EditorLabel : Label
    {
        private static Brush bgBrush = new TextureBrush(Properties.Resources.BarImage);
        public EditorLabel() { }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            TextAlign = ContentAlignment.MiddleLeft;
            Height = 23;
            AutoSize = false;
            ForeColor = Color.MidnightBlue;
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            base.OnPaintBackground(pevent);
            pevent.Graphics.FillRectangle(bgBrush, ClientRectangle);
        }
    }
}
