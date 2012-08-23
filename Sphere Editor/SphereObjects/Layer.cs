using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.IO;
using Sphere_Editor.EditorComponents;

namespace Sphere_Editor.SphereObjects
{
    public class Layer
    {
        #region private data
        public static Pen seg_pen = new Pen(Color.Pink);
        public short[] Tiles;
        public bool[] Dirty;
        private short _width, _height;
        private float parallax_x, parallax_y;
        private float scrolling_x, scrolling_y;
        private short tile_width = 16, tile_height = 16;
        private bool _reflective, _visible = true, _parallax;
        private short flags;
        private int seg_amount, off_x, off_y;
        public List<Segment> Segments = new List<Segment>();
        private Bitmap layer_img;
        private int _zoom = 1, twz = 16, thz = 16;
        private string _name;
        #endregion

        public Layer() { }

        public Layer(string name, short width, short height, short tile_width, short tile_height)
        {
            _name = name;
            _width = width;
            _height = height;
            this.tile_width = tile_width;
            this.tile_height = tile_height;

            int arr_size = _width * _height;
            Tiles = new short[arr_size];
            Dirty = new bool[arr_size];

            for (int i = 0; i < arr_size; ++i) Dirty[i] = true;
            layer_img = new Bitmap(tile_width, tile_height, PixelFormat.Format32bppArgb);
        }

        public Layer(BinaryReader stream)
        {
            _width = stream.ReadInt16();
            _height = stream.ReadInt16();
            flags = stream.ReadInt16();
            _visible = (~flags & 1) == 1;
            _parallax = (flags & 2) == 2;
            parallax_x = stream.ReadSingle();
            parallax_y = stream.ReadSingle();
            scrolling_x = stream.ReadSingle();
            scrolling_y = stream.ReadSingle();
            seg_amount = stream.ReadInt32();
            _reflective = stream.ReadBoolean();
            stream.ReadBytes(3); // reserved

            Int16 length = stream.ReadInt16();
            _name = new string(stream.ReadChars(length));

            // Load the Tiles
            int size = _width * _height;
            Tiles = new short[size];
            Dirty = new bool[size];
            int i = -1;
            while (++i < size)
            {
                Tiles[i] = stream.ReadInt16();
                Dirty[i] = true;
            }
            layer_img = new Bitmap(tile_width, tile_height, PixelFormat.Format32bppArgb);

            // Load the segments
            i = seg_amount;
            while (i-- > 0) Segments.Add(new Segment(stream));
        }

        internal void Save(BinaryWriter binwrite)
        {
            // Save Header:
            binwrite.Write((short)_width);
            binwrite.Write((short)_height);
            binwrite.Write(flags);
            binwrite.Write(parallax_x);
            binwrite.Write(parallax_y);
            binwrite.Write(scrolling_x);
            binwrite.Write(scrolling_y);
            binwrite.Write(seg_amount);
            binwrite.Write(_reflective);
            binwrite.Write(new byte[3]);
            binwrite.Write((short)_name.Length);
            binwrite.Write(_name.ToCharArray());

            // Save Tiles:
            for (int i = 0; i < Tiles.Length; ++i) binwrite.Write((short)Tiles[i]);

            // Save Segments:
            foreach (Segment s in Segments) s.Save(binwrite);
        }

        public void AddSegment(Segment line)
        {
            Segments.Add(line);
        }

        public void UpdateDrawingWindow(int w, int h)
        {
            if (w != 0 || h != 0)
            {
                this.layer_img.Dispose();
                this.layer_img = new Bitmap(w, h);
            }
        }

        public void UpdateTileOffset(int x, int y)
        {
            this.off_x = x;
            this.off_y = y;
        }

        // creates a "snapshot", a section starting at the start (x, y),
        // with the size of the width and height.
        public void UpdateLayer(TilesetControl tileset, bool forced)
        {
            // create drawing surface:
            Graphics g = Graphics.FromImage(layer_img);
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            g.CompositingMode = CompositingMode.SourceCopy;
            g.PixelOffsetMode = PixelOffsetMode.Half;

            int index, iy;
            int h = layer_img.Height / thz;
            int w = layer_img.Width / twz;
            int wz = _width * twz;
            for (int y = 0; y < h; y++)
            {
                iy = (y + this.off_y) * _width;
                for (int x = 0; x < w; x++)
                {
                    index = (this.off_x + x) + iy;
                    if (index >= Tiles.Length || (x + off_x) * twz == wz)
                    {
                        g.FillRectangle(Brushes.Black, x * twz, y * thz, twz, thz);
                        continue;
                    }
                    if (index < Tiles.Length && (Dirty[index] || forced))
                    {
                        g.DrawImage(tileset.GetTile(Tiles[index]).Graphic, x * twz, y * thz, twz, thz);
                        Dirty[index] = false;
                    }
                }
            }
            g.Dispose();
        }

        // this will iterate through and adjust tile index offset
        // starting from start index clear through to the end.
        public void DoAdjustment(int startIndex, short times)
        {
            int i = Tiles.Length;
            while(i-- > 0) if (Tiles[i] >= startIndex) Tiles[i] += times;
        }

        // UpdateLayer() must be called after a layer rezise has happened.
        public void ResizeLayer(short width, short height)
        {
            short[,] tiles = new short[width, height];
            Dirty = new bool[width * height];

            int index = 0;
            for (int y = 0; y < this._height; ++y)
            {
                for (int x = 0; x < this._width; ++x)
                {
                    if (x < width && y < height) tiles[x, y] = Tiles[index];
                    index++;
                }
            }

            // Set the old width and height to these new values:
            this._width = width;
            this._height = height;
            Tiles = new short[width * height];

            index = 0;
            for (int y = 0; y < this._height; ++y)
            {
                for (int x = 0; x < this._width; ++x)
                {
                    Tiles[index] = tiles[x, y];
                    index++;
                }
            }
        }

        // If the layer is visible, draw the single layer image.
        public void DrawLayer(Graphics g)
        {
            if (!_visible) return;
            g.DrawImageUnscaled(layer_img, 0, 0);
            foreach (Segment seg in Segments) seg.DrawMe(g, off_x * twz, off_y * thz, _zoom);
        }

        public short Width
        {
            get { return _width; }
            set { _width = value; }
        }

        public short Height
        {
            get { return _height; }
            set { _height = value; }
        }

        // sets the zoom level as well as compute the new zoomed layer size.
        public int Zoom
        {
            get { return _zoom; }
            set { _zoom = value; twz = tile_width * value; thz = tile_height * value; }
        }

        public bool Visible
        {
            get { return _visible; }
            set { _visible = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public short TileWidth
        {
            get { return tile_width; }
            set { tile_width = value; twz = value * _zoom; }
        }

        public short TileHeight
        {
            get { return tile_height; }
            set { tile_height = value; thz = value * _zoom; }
        }

        public void SetTile(int old_index, short new_index)
        {
            if (old_index < Tiles.Length && Tiles[old_index] != new_index)
            {
                Tiles[old_index] = new_index;
                Dirty[old_index] = true;
            }
        }

        // focus here!
        public void SetTile(int x, int y, short index)
        {
            int tile = x + y * _width;
            if (tile < Tiles.Length && tile >= 0 && x < _width && Tiles[tile] != index)
            {
                Tiles[tile] = index;
                Dirty[tile] = true;
            }
        }

        // sets new tile size and calculates new zoomed layer size
        public void SetTileSize(short width, short height)
        {
            tile_width = width;
            tile_height = height;
        }

        public short GetTileAt(int x, int y)
        {
            return Tiles[x + y * _width];
        }

        public Layer Clone()
        {
            Layer new_layer = new Layer();
            new_layer.Tiles = (short[])this.Tiles.Clone();
            return new_layer;
        }
    }
}
