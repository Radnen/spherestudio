using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using Sphere_Editor.Forms;

namespace Sphere_Editor.EditorComponents
{
    public partial class Zone : UserControl
    {
        #region private members
        private short x1, y1;
        private short x2 = 128, y2 = 128;
        private short layer, num_steps = 8;
        private string function = "", name = "";
        private Font font = new Font(FontFamily.GenericMonospace, (float)8.5);
        private int zoom = 1, snap = 16, mode;
        private bool resize = false;
        private int last_x, last_y;
        private int base_height = 16, base_width = 16;
        private int ox, oy = 0;
        private Pen outline = new Pen(Color.Red);
        private Brush fill = new SolidBrush(Color.FromArgb(25, Color.Red));
        #endregion

        public delegate void EventHandler(object sender, EventArgs e);
        public event EventHandler Deleted;

        private void Set()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            outline.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
        }

        public Zone()
        {
            Set();
            InitializeComponent();
        }

        public Zone(BinaryReader stream)
        {
            Set();
            InitializeComponent();

            x1 = stream.ReadInt16();
            y1 = stream.ReadInt16();
            x2 = stream.ReadInt16();
            y2 = stream.ReadInt16();
            layer = stream.ReadInt16();
            num_steps = stream.ReadInt16();
            stream.ReadBytes(4); // reserved

            Int16 len = stream.ReadInt16();
            function = new string(stream.ReadChars(len));
            Location = new Point(x1, y1);
            Size = new Size(x2-x1, y2-y1);
            base_width = x2 - x1; base_height = y2 - y1;
            ox = x1; oy = y1;
            Refresh();
        }

        internal void Save(BinaryWriter binwrite)
        {
            // Write Header //
            binwrite.Write(x1);
            binwrite.Write(y1);
            binwrite.Write(x2);
            binwrite.Write(y2);
            binwrite.Write(layer);
            binwrite.Write(num_steps);
            binwrite.Write(new byte[4]);

            // Write Content //
            binwrite.Write((short)function.Length);
            binwrite.Write(function.ToCharArray());
        }

        public Zone(int x, int y, int width, int height, int layer_num)
        {
            Set();
            InitializeComponent();

            x1 = (short)x;
            y1 = (short)y;
            x2 = (short)(x + width);
            y2 = (short)(y + height);
            layer = (short)layer_num;
            Location = new Point(x, y);
            Size = new Size(width, height);
            base_width = width;
            base_height = height;
            ox = x1; oy = y1;
        }

        public short Layer
        {
            get { return layer; }
            set { layer = value; }
        }

        public string LayerName
        {
            set { name = value; }
        }

        public string Function
        {
            get { return function; }
            set { function = value; }
        }

        public short NumSteps
        {
            get { return num_steps; }
            set { num_steps = value; }
        }

        public int Zoom
        {
            set
            {
                zoom = value;
                Width = base_width * value;
                Height = base_height * value;
                Location = new Point(ox * value, oy * value);
            }
            get { return zoom; }
        }

        public int Snap
        {
            get { return snap; }
            set { snap = value; }
        }

        // nifty getters for origin location x/y
        public int X { get { return oy; } }
        public int Y { get { return ox; } }

        public void DrawZone(Graphics g)
        {
            Rectangle rect = new Rectangle(0, 0, Width-1, Height-1);
            g.DrawRectangle(outline, rect);

            if (Enabled)
            {
                g.FillRectangle(fill, rect);
                g.FillRectangle(Brushes.White, Width / 2 - 3, Height - 6, 6, 6);
                g.DrawRectangle(Pens.Black, Width / 2 - 3, Height - 6, 6, 6);
                g.FillRectangle(Brushes.White, Width - 6, Height / 2 - 3, 6, 6);
                g.DrawRectangle(Pens.Black, Width - 6, Height / 2 - 3, 6, 6);
                g.FillRectangle(Brushes.White, Width - 6, Height - 6, 6, 6);
                g.DrawRectangle(Pens.Black, Width - 6, Height - 6, 6, 6);
                g.DrawString(name, font, Brushes.White, 2, 0);
                if (Height > 16)
                    g.DrawString("Layer: " + layer, font, Brushes.White, 2, Height - 16);
            }
        }

        private void Zone_Paint(object sender, PaintEventArgs e)
        {
            DrawZone(e.Graphics);
        }

        private void Zone_MouseMove(object sender, MouseEventArgs e)
        {
            if (resize)
            {
                int zsnap = snap * zoom;
                if (mode == 0)
                {
                    Left = Left + e.X / zsnap * zsnap - last_x;
                    Top = Top + e.Y / zsnap * zsnap - last_y;
                }
                else if (mode == 1 && e.X > zsnap)
                {
                    Width = e.X / zsnap * zsnap;
                    Invalidate();
                }
                else if (mode == 2 && e.Y > zsnap)
                {
                    Height = e.Y / zsnap * zsnap;
                    Invalidate();
                }
                else if (mode == 3 && e.X > zsnap && e.Y > zsnap)
                {
                    Width = e.X / zsnap * zsnap;
                    Height = e.Y / zsnap * zsnap;
                    Invalidate();
                }
            }
            else
            {
                if (e.X > Width - 6 && e.Y > Height - 6) { Cursor = Cursors.SizeNWSE; mode = 3; }
                else if (e.Y > Height - 6) { Cursor = Cursors.SizeNS; mode = 2; }
                else if (e.X > Width - 6) { Cursor = Cursors.SizeWE; mode = 1; }
                else { Cursor = Cursors.SizeAll; mode = 0; }
            }
        }

        private void Zone_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                resize = true;
                int zsnap = snap * zoom;
                last_x = e.X / zsnap * zsnap;
                last_y = e.Y / zsnap * zsnap;
                BringToFront();
                outline.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                outline.Color = Color.Yellow;
                fill = new SolidBrush(Color.FromArgb(25, Color.Yellow));
                Invalidate();
            }
        }

        private void Zone_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                resize = false;
                ox = Left / zoom;
                oy = Top / zoom;
                base_width = Width / zoom;
                base_height = Height / zoom;

                outline.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                outline.Color = Color.Red;
                fill = new SolidBrush(Color.FromArgb(25, Color.Red));
                Invalidate();
            }
            if (e.Button == MouseButtons.Right)
            {
                BringToFront();
                ZoneMenuStrip.Show(this, e.X, e.Y);
            }
        }

        private void EditZoneItem_Click(object sender, EventArgs e)
        {
            /*ZoneForm newzone = new ZoneForm(this);
            int i = ((MapEditorControl)Parent).Layers.Count;
            while(i-- > 0) newzone.AddString(((MapEditorControl)Parent).Layers[i].Name);
            newzone.SelectedIndex = (int)layer;
            newzone.ShowDialog();*/
        }

        private void DestroyZoneItem_Click(object sender, EventArgs e)
        {
            if (Deleted != null) Deleted(this, new EventArgs());
        }
    }
}
