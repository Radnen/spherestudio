using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.IO;
using Sphere.Core.Utility;

namespace Sphere.Core.SphereObjects
{
    /// <summary>
    /// A Sphere windowstyle object.
    /// </summary>
    public class Windowstyle : IDisposable
    {
        // Different Directions:
        private Bitmap[] _images = new Bitmap[9];
        private Rectangle[] _rectangles = new Rectangle[9];
        private Pen _grid_pen = new Pen(Brushes.LimeGreen);
        private Pen _sel_pen = new Pen(Brushes.Red);
        private Image _preview = null;
        private int _zoom = 1, _sel = 0;
        private int _p_width = 0;
        private int _p_height = 0;

        /// <summary>
        /// nested class for working with colors
        /// </summary>
        private class RGBA
        {
            byte red = 0;
            byte blue = 0;
            byte green = 0;
            byte alpha = 0;

            public void ReadData(BinaryReader binread)
            {
                red = binread.ReadByte();
                green = binread.ReadByte();
                blue = binread.ReadByte();
                alpha = binread.ReadByte();
            }

            public void SaveData(BinaryWriter binwrite)
            {
                binwrite.Write(this.red);
                binwrite.Write(this.blue);
                binwrite.Write(this.green);
                binwrite.Write(this.alpha);
            }
        }

        // Header data:
        string _sig = ".rws";
        short _version = 1;
        byte _edge_width = 0;
        byte _background_mode = 0;
        RGBA[] _edge_colors = new RGBA[4];
        byte[] _edge_offset = new byte[4];

        /// <summary>
        /// Instantitates a blank window for your use.
        /// </summary>
        public Windowstyle()
        {
            _version = 2;
            for (int i = 0; i < _edge_colors.Length; ++i) _edge_colors[i] = new RGBA();
            for (int i = 0; i < _images.Length; ++i) _images[i] = new Bitmap(16, 16, PixelFormat.Format32bppPArgb);
        }

        /// <summary>
        /// Creates a new windowstyle by loading a filename.
        /// </summary>
        /// <param name="filename">The file where the windowstyle is saved.</param>
        public Windowstyle(string filename)
        {
            using (BinaryReader reader = new BinaryReader(File.OpenRead(filename)))
            {
                Open(reader);
            }
        }

        /// <summary>
        /// Instantiates a new WindowStyle object.
        /// </summary>
        /// <param name="binread">The stream where the data lies</param>
        public Windowstyle(BinaryReader binread)
        {
            Open(binread);
        }

        /// <summary>
        /// Disposes any resources used by this control.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool _disposed;
        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    foreach (Bitmap b in _images) b.Dispose();
                    if (_preview != null) _preview.Dispose();
                    _grid_pen.Dispose();
                    _sel_pen.Dispose();
                }

                _preview = null;
                _grid_pen = null;
                _sel_pen = null;
                _images = null;
            }
            _disposed = true;
        }

        /// <summary>
        /// Saves the windowstyle to the Sphere .rws format.
        /// </summary>
        /// <param name="filename">The path in which to save to.</param>
        public void Save(string filename)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(filename, FileMode.Create)))
            {
                writer.Write(_sig.ToCharArray());
                writer.Write(_version);
                writer.Write(_edge_width);
                writer.Write(_background_mode);
                for (int i = 0; i < _edge_colors.Length; ++i) _edge_colors[i].SaveData(writer);
                for (int i = 0; i < _edge_offset.Length; ++i) writer.Write(_edge_offset[i]);
                writer.Write(new byte[36]);

                switch (_version)
                {
                    case 2:
                        BitmapSaver saver;
                        foreach (Bitmap b in _images)
                        {
                            writer.Write((short)b.Width);
                            writer.Write((short)b.Height);
                            saver = new BitmapSaver(b.Width, b.Height);
                            saver.SaveToStream(b, writer);
                        }
                        break;
                }

                writer.Flush();
            }
        }

        /// <summary>
        /// Reads the windowstyle from a filestream.
        /// </summary>
        /// <param name="binread">The System.IO.BinaryReader to use.</param>
        public void Open(BinaryReader binread)
        {
            _sig = new string(binread.ReadChars(4));
            _version = binread.ReadInt16();
            _edge_width = binread.ReadByte();
            _background_mode = binread.ReadByte();
            for (int i = 0; i < _edge_colors.Length; ++i)
            {
                _edge_colors[i] = new RGBA();
                _edge_colors[i].ReadData(binread);
            }
            for (int i = 0; i < _edge_offset.Length; ++i) _edge_offset[1] = binread.ReadByte();
            binread.ReadBytes(36); // reserved

            switch (_version)
            {
                case 2:
                    BitmapLoader loader;
                    for (int i = 0; i < _images.Length; ++i)
                    {
                        short width = binread.ReadInt16();
                        short height = binread.ReadInt16();
                        loader = new BitmapLoader(width, height);
                        _images[i] = loader.LoadFromStream(binread, width * height * 4);
                        loader.Close();
                    }
                    break;
            }
        }

        /// <summary>
        /// Gets a list of images that represent the windowstyle edges and center.
        /// </summary>
        public Bitmap[] Images { get { return _images; } }

        /// <summary>
        /// Gets or sets if whether or not to show a grid.
        /// </summary>
        public bool Grid { get; set; }

        /// <summary>
        /// Gets/sets the zoom level.
        /// </summary>
        public int Zoom
        {
            get { return _zoom; }
            set
            {
                _zoom = value;
                _p_width = _preview.Width * value;
                _p_height = _preview.Height * value;
            }
        }

        /// <summary>
        /// Gets/sets the image map selected. -1 = none, 0-8 = sides.
        /// </summary>
        public int Selected
        {
            get { return _sel; }
            set { _sel = value; }
        }

        /// <summary>
        /// Generates a preview, so as to cache the resultant image.
        /// </summary>
        /// <param name="w">width of zone to fill</param>
        /// <param name="h">height of zone to fill</param>
        public void GeneratePreview(int w, int h)
        {
            if (_preview != null) _preview.Dispose();
            _preview = new Bitmap(w, h, PixelFormat.Format32bppPArgb);
            _p_width = w * _zoom;
            _p_height = h * _zoom;

            Graphics g = Graphics.FromImage(_preview);
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            g.PixelOffsetMode = PixelOffsetMode.Half;

            // corners:
            _rectangles[0] = new Rectangle(0, 0, _images[0].Width, _images[0].Height);
            _rectangles[2] = new Rectangle(w - _images[2].Width, 0, _images[2].Width, _images[2].Height);
            _rectangles[4] = new Rectangle(w - _images[4].Width, h - _images[4].Height, _images[4].Width, _images[4].Height);
            _rectangles[6] = new Rectangle(0, h - _images[6].Height, _images[6].Width, _images[6].Height);
            for (int i = 0; i < 8; i += 2) g.DrawImage(_images[i], _rectangles[i]);

            // sides:
            _rectangles[1] = new Rectangle(_images[0].Width, 0, w - (_images[0].Width + _images[2].Width), _images[1].Height);
            _rectangles[3] = new Rectangle(w - _images[2].Width, _images[2].Height, _images[3].Width, h - (_images[1].Height + _images[5].Height));
            _rectangles[5] = new Rectangle(_images[0].Width, h - _images[5].Height, w - (_images[6].Width + _images[4].Width), _images[5].Height);
            _rectangles[7] = new Rectangle(0, _images[0].Height, _images[7].Width, h - (_images[1].Height + _images[5].Height));

            FillWidth(g, _images[1], _rectangles[1]);
            FillHeight(g, _images[3], _rectangles[3]);
            FillWidth(g, _images[5], _rectangles[5]);
            FillHeight(g, _images[7], _rectangles[7]);

            // center:
            _rectangles[8] = new Rectangle(_images[0].Width, _images[0].Height, w - (_images[7].Width + _images[3].Width), h - (_images[1].Height + _images[5].Height));
            FillWithin(g, _images[8], _rectangles[8]);
        }

        /// <summary>
        /// Draws the window preview to the graphics object.
        /// </summary>
        /// <param name="g">Standard Graphics Object.</param>
        public void DrawWindow(Graphics g)
        {
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            g.PixelOffsetMode = PixelOffsetMode.Half;
            g.CompositingQuality = CompositingQuality.HighSpeed;
            g.DrawImage(_preview, 0, 0, _p_width, _p_height);

            int w = _preview.Width*_zoom;
            int h = _preview.Height*_zoom;
            if (Grid)
            {
                g.DrawRectangle(_grid_pen, 1, 1, w - 1, h - 1);
                g.DrawLine(_grid_pen, 0, _images[0].Height*_zoom, w, _images[2].Height*_zoom);
                g.DrawLine(_grid_pen, _images[0].Width*_zoom, 0, _images[6].Width*_zoom, h);
                g.DrawLine(_grid_pen, 0, h - _images[6].Height*_zoom, w, h - _images[4].Height*_zoom);
                g.DrawLine(_grid_pen, w - _images[2].Width*_zoom, 0, w - _images[4].Width*_zoom, h);

                if (_sel >= 0)
                {
                    g.PixelOffsetMode = PixelOffsetMode.None;
                    g.DrawRectangle(_sel_pen, _rectangles[_sel].X * _zoom, _rectangles[_sel].Y * _zoom,
                        _rectangles[_sel].Width * _zoom - 1, _rectangles[_sel].Height * _zoom - 1);
                }
            }
            else
            {
                g.DrawRectangle(Pens.Black, 1, 1, w - 1, h - 1);
            }
        }

        /// <summary>
        /// Returns true if a point is in a retcangular section, one of the 8.
        /// </summary>
        /// <param name="p">The point to compare by.</param>
        /// <param name="s">The section index.</param>
        /// <returns>True if within the subsection.</returns>
        public bool IsPointWithinSection(Point p, int s)
        {
            int x = _rectangles[s].X * _zoom;
            int y = _rectangles[s].Y * _zoom;
            int w = x + (_rectangles[s].Width * _zoom);
            int h = y + (_rectangles[s].Height * _zoom);
            return (p.X > x && p.Y > y && p.X < w && p.Y < h);
        }

        private void FillWidth(Graphics g, Bitmap img, Rectangle rect)
        {
            int x = rect.X, y = rect.Y;
            int d = (int)Math.Ceiling((double)rect.Width / img.Width) * img.Width;
            g.SetClip(rect);
            for (int i = 0; i < d; i += img.Width) g.DrawImageUnscaled(img, x + i, y);
            g.ResetClip();
        }

        private void FillHeight(Graphics g, Bitmap img, Rectangle rect)
        {
            int x = rect.X, y = rect.Y;
            int d = (int)Math.Ceiling((double)rect.Height / img.Height) * img.Height;
            g.SetClip(rect);
            for (int i = 0; i < d; i += img.Height) g.DrawImageUnscaled(img, x, y + i);
            g.ResetClip();
        }

        private void FillWithin(Graphics g, Bitmap img, Rectangle rect)
        {
            int dx = (int)Math.Ceiling((double)rect.Width / img.Width) * img.Width;
            int dy = (int)Math.Ceiling((double)rect.Height / img.Height) * img.Height;
            g.SetClip(rect);
            for (int xx = 0; xx < dx; xx += img.Width)
                for (int yy = 0; yy < dy; yy += img.Height)
                    g.DrawImageUnscaled(img, rect.X + xx, rect.Y + yy);
            g.ResetClip();
        }
    }
}
