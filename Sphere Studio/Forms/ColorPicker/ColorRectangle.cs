using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace SphereStudio.Forms.ColorPicker
{
    public partial class ColorRectangle : UserControl
    {
        private Color color = Color.Blue;
        private Color selected_color = Color.White;
        private Rectangle region;
        private Bitmap field;
        private LinearGradientBrush brush;
        private int mx = 0;
        private int my = 0;

        public delegate void EventHandler(object sender, EventArgs e);
        public event EventHandler ColorSelected;

        public ColorRectangle()
        {
            InitializeComponent();
            UpdateField();
        }

        public Color FillColor
        {
            get { return color; }
            set { color = value; UpdateField(); }
        }

        public Color SelectedColor
        {
            get { return selected_color; }
        }

        private void UpdateField()
        {
            field = new Bitmap(Width, Height);
            region = new Rectangle(0, 0, Width, Height);
            brush = new LinearGradientBrush(region, Color.White, color, 45);
            Graphics g = Graphics.FromImage(field);
            g.FillRectangle(brush, region);
            g.Dispose();
            Refresh();
        }

        private void ColorRectangle_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImageUnscaled(field, 0, 0);
            DrawSelector(e.Graphics, mx, my);
        }

        private void DrawSelector(Graphics g, int x, int y)
        {
            g.DrawRectangle(Pens.Black, x - 1, y - 1, 3, 3);
            g.DrawRectangle(Pens.Yellow, x - 2, y - 2, 5, 5);
            g.DrawRectangle(Pens.Black, x - 3, y - 3, 7, 7);
        }

        private void ColorRectangle_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mx = Math.Max(0, Math.Min(e.X, Width - 1));
                my = Math.Max(0, Math.Min(e.Y, Height - 1));
                selected_color = field.GetPixel(mx, my);
                if (ColorSelected != null) ColorSelected(this, new EventArgs());
            }
            Refresh();
        }

        private void ColorRectangle_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mx = Math.Max(0, Math.Min(e.X, Width - 1));
                my = Math.Max(0, Math.Min(e.Y, Height - 1));
                selected_color = field.GetPixel(mx, my);
                if (ColorSelected != null) ColorSelected(this, new EventArgs());
            }
        }

        private void ColorRectangle_Resize(object sender, EventArgs e)
        {
            UpdateField();
            Refresh();
        }
    }
}
