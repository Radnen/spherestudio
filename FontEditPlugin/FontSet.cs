using Sphere.Core.Utility;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace SphereStudio.Plugins
{
    partial class FontSet : UserControl
    {
        string signature = ".rfn";
        Int16 version = 2;
        Int16 num_chars = 0;
        short selection = 0;
        int _zoom = 1;
        Font draw_font = new Font(FontFamily.GenericMonospace, (float)8, FontStyle.Bold);

        public Character[] Characters { get; set; }

        public delegate void EventHandler(object sender, EventArgs e);
        public event EventHandler CharSelected;
        public event EventHandler LayoutZoomed;

        public FontSet()
        {
            num_chars = 256;
            Characters = new Character[num_chars];
            for (int i = 0; i < num_chars; ++i) Characters[i] = new Character();
            InitializeComponent();
            UpdateWidth();
        }

        public void LoadFromFile(string filename)
        {
            BinaryReader reader = new BinaryReader(File.Open(filename, FileMode.Open));
            signature = new string(reader.ReadChars(4));
            version = reader.ReadInt16();
            num_chars = reader.ReadInt16();
            reader.ReadBytes(248);

            InitializeComponent();

            for (short i = 0; i < num_chars; ++i)
                Characters[i] = new Character(reader, version);

            reader.Close();
            UpdateWidth();
        }

        public void SaveToFile(string filename)
        {
            BinaryWriter writer = new BinaryWriter(File.Open(filename, FileMode.Create));
            writer.Write(signature.ToCharArray());
            writer.Write(version);
            writer.Write(num_chars);
            writer.Write(new byte[248]);

            for (short i = 0; i < num_chars; ++i) Characters[i].Save(writer, version);
            writer.Flush();
            writer.Close();
        }

        public short Selection
        {
            get { return selection; }
            set
            {
                selection = value;
                Refresh();
                CharSelected?.Invoke(this, new EventArgs());
            }
        }

        public int GetStringWidth(string text)
        {
            int w = 0;
            for (int i = 0; i < text.Length; ++i)
                w += Characters[text[i]].Width;
            return w;
        }

        private void FontSet_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
            Bitmap image;
            int x = 0;
            for (int i = 0; i < num_chars; ++i)
            {
                if (Characters[i] == null) continue;
                image = Characters[i].Image;
                int w = Characters[i].Width * _zoom;
                int h = Characters[i].Height * _zoom;
                if (image.Width > 0) w = image.Width * _zoom;
                if (image.Height > 0) h = image.Height * _zoom;
                e.Graphics.DrawString(new string((char)i, 1), draw_font, Brushes.Black, x, 0);
                e.Graphics.DrawImage(image, x, 16, w, h);
                e.Graphics.DrawRectangle(Pens.Black, x+2, 16, w, h);
                e.Graphics.DrawString(i.ToString(), draw_font, Brushes.Black, x, 16+h);
                if (i == selection)
                    e.Graphics.DrawRectangle(Pens.Magenta, x - 1, 15, 2 + w, 2 + h);
                x += w + 4;
            }
        }
        
        public void GenerateFont(Font font, bool gradient, Color c1, Color c2, bool stroke, Color c3)
        {
            Brush semi_black = new SolidBrush(Color.FromArgb(255, c3));
            Brush gradient_brush = new SolidBrush(c1);
            Graphics g;
            Character c;
            for (int i = 0; i < num_chars; ++i)
            {
                string str = new string((char)i, 1);
                
                c = Characters[i];
                g = CreateGraphics();
                int w = (int)(g.MeasureString(str, font)).Width;
                if (stroke) w += 2;
                int h = stroke ? font.Height + 2 : font.Height;

                if (str == " ") w += 4; // to give it some breathing room.

                Bitmap img = new Bitmap(Math.Max(1, w - 3), font.Height);
                g = Graphics.FromImage(img);
                g.SmoothingMode = SmoothingMode.None;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;

                if (gradient)
                {
                    Point pt = new Point(0, img.Height);
                    gradient_brush = new LinearGradientBrush(Point.Empty, pt, c1, c2);
                }

                try
                {
                    if (stroke)
                    {
                        g.DrawString(str, font, semi_black, -1, -2);
                        g.DrawString(str, font, semi_black, 0, -1);
                        g.DrawString(str, font, semi_black, -1, 0);
                        g.DrawString(str, font, semi_black, -2, -1);
                        g.DrawString(str, font, gradient_brush, -1, -1);
                    }
                    else
                    {
                        g.DrawString(str, font, gradient_brush, -2, -2);
                    }
                }
                catch { }
                
                g.Dispose();
                c.Image.Dispose();
                c.Image = img;
            }
            UpdateWidth();
            Refresh();
        }

        private void FontSet_MouseClick(object sender, MouseEventArgs e)
        {
            int x = 0;
            for (int i = 0; i < num_chars; ++i)
            {
                int w = Characters[i].Width * _zoom;
                int h = Characters[i].Height * _zoom;
                if (e.X > x && e.X < x + w && e.Y > 16 && e.Y < 16 + h) Selection = (short)i;
                x += w * _zoom + 4;
            }
        }

        private void FontSet_KeyUp(object sender, KeyEventArgs e)
        {
            char c = (char)e.KeyValue;
            if (char.IsLetterOrDigit(c) || char.IsPunctuation(c))
            {
                if (e.Shift) Selection = (short)e.KeyValue;
                else if (char.IsLetter(c)) Selection = (short)(e.KeyValue + 32);
                else Selection = (short)e.KeyValue;
            }
        }

        private void UpdateWidth()
        {
            int w = 0;
            foreach (Character c in Characters)
                w += c.Width * _zoom + 4;
            Width = w;
        }

        private void ZoomInItem_Click(object sender, EventArgs e)
        {
            ZoomIn();
        }

        public void ZoomIn()
        {
            if (_zoom < 8)
            {
                ZoomOutItem.Enabled = true;
                _zoom *= 2;
                UpdateWidth();
                if (_zoom == 8) ZoomInItem.Enabled = false;
                if (LayoutZoomed != null) LayoutZoomed(this, new EventArgs());
                Invalidate();
            }
        }

        private void ZoomOutItem_Click(object sender, EventArgs e)
        {
            ZoomOut();
        }

        public void ZoomOut()
        {
            if (_zoom > 1)
            {
                ZoomInItem.Enabled = true;
                _zoom /= 2;
                UpdateWidth();
                if (_zoom == 1) ZoomOutItem.Enabled = false;
                if (LayoutZoomed != null) LayoutZoomed(this, new EventArgs());
                Invalidate();
            }
        }

        public int Zoom
        {
            get { return _zoom; }
        }
    }

    public class Character
    {
        short _width = 8;
        short _height = 12;
        Bitmap _image = null;

        public Character()
        {
            _image = new Bitmap(_width, _height, PixelFormat.Format32bppArgb);
        }

        public Character(BinaryReader stream, short version)
        {
            _width = stream.ReadInt16();
            _height = stream.ReadInt16();
            stream.ReadBytes(28);

            int size = _width * _height * 4;
            BitmapLoader loader = new BitmapLoader(_width, _height);
            if (version >= 1)
            {
                _image = loader.LoadFromStream(stream, size);
            }
            loader.Close();
        }

        public void Save(BinaryWriter writer, short version)
        {
            writer.Write(_width);
            writer.Write(_height);
            writer.Write(new byte[28]);
            BitmapSaver saver = new BitmapSaver(_width, _height);
            if (version >= 1) saver.SaveToStream(_image, writer);
        }

        public Bitmap Image
        {
            get { return _image; }
            set { _image = value; _width = (short)_image.Width; _height = (short)_image.Height; }
        }

        public short Width
        {
            get { return _width; }
        }

        public short Height
        {
            get { return _height; }
        }
    }
}
