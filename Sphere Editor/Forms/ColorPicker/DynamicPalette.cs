using System;
using System.Drawing;
using System.Windows.Forms;
using Sphere_Editor.EditorComponents;
using Sphere_Editor.Bitmaps;

namespace Sphere_Editor.Forms.ColorPicker
{
    public partial class DynamicPalette : UserControl
    {
        private ImageEditorControl image_control = null;
        private Color temp = Color.White;

        public DynamicPalette()
        {
            InitializeComponent();
        }

        public ImageEditorControl ImageController
        {
            set { image_control = value; }
        }

        public void OrganizePalette()
        {
            int w = Width / 32;
            int h = Height / 32;
            int index = 0;

            for (int y = 0; y < h; ++y)
            {
                for (int x = 0; x < w; ++x)
                {
                    if (index >= Controls.Count) break;
                    Controls[index++].Location = new Point(x * 32, y * 32);
                }
            }
        }

        private void AddColorControl(Color color)
        {
            ColorBox box = new ColorBox();
            box.SelectedColor = color;
            box.Size = new Size(32, 32);
            box.ColorChanging += new System.EventHandler(box_ColorChanging);
            box.ColorChanged += new System.EventHandler(box_ColorChanged);
            Controls.Add(box);
        }

        // a wrapper, so that organization is called automatically.
        public void AddColor(Color color)
        {
            AddColorControl(color);
            OrganizePalette();
        }

        public bool HasColor(Color c)
        {
            foreach (ColorBox cbox in Controls)
            {
                if (FastBitmap.ColorsEqual(cbox.SelectedColor, c)) return true;
            }
            return false;
        }

        // see: AddColor(), this is why it's a wrapper.
        public void ExtractColors()
        {
            Color c;
            Bitmap bmap = image_control.Image;
            int index = 0;

            Controls.Clear();

            for (int x = 0; x < bmap.Width; ++x)
            {
                for (int y = 0; y < bmap.Height; ++y)
                {
                    if (index > 32) break;
                    c = bmap.GetPixel(x, y);
                    if (!HasColor(c))
                    {
                        AddColorControl(c);
                        ++index;
                    }
                }
            }
            OrganizePalette();
        }

        void box_ColorChanging(object sender, EventArgs e)
        {
            // before the color changes, store it in a temporary positoin.
            temp = ((ColorBox)sender).SelectedColor;
        }

        void box_ColorChanged(object sender, EventArgs e)
        {
            // after the color changes, we can then use temp to repolace it in
            // the parent image control.
            image_control.ReplacePixels(temp, ((ColorBox)sender).SelectedColor);
            Refresh();
        }


    }
}
