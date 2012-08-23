using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.IO;

namespace Sphere_Editor.SphereObjects
{
    public class Layer2
    {
        #region attributes
        private short[,] _tiles;
        public short Width { get; private set; }
        public short Height { get; private set; }

        public float ParallaxX { get; set; }
        public float ParallaxY { get; set; }
        public float ScrollX { get; set; }
        public float ScrollY { get; set; }
        public bool Reflective { get; set; }
        public bool Visible { get; set; }
        public bool Parallax { get; set; }
        public short Flags { get; set; }

        public string Name { get; set; }
        public List<Segment> Segments { get; private set; }
        #endregion

        public Layer2()
        {
            Segments = new List<Segment>();
            Visible = true;
        }

        public void Save(BinaryWriter writer)
        {
            // save header:
            writer.Write(Width);
            writer.Write(Height);
            writer.Write(Flags);
            writer.Write(ParallaxX);
            writer.Write(ParallaxY);
            writer.Write(ScrollX);
            writer.Write(ScrollY);
            writer.Write(Segments.Count);
            writer.Write(Reflective);
            writer.Write(new byte[3]);
            writer.Write((short)Name.Length);
            writer.Write(Name.ToCharArray());

            // save tiles:
            for (int y = 0; y < Height; ++y)
                for (int x = 0; x < Width; ++x)
                    writer.Write(_tiles[x, y]);

            // save segments:
            for (int i = 0; i < Segments.Count; ++i) Segments[i].Save(writer);
        }

        public static Layer2 FromBinary(BinaryReader reader)
        {
            Layer2 layer = new Layer2();
            layer.Width = reader.ReadInt16();
            layer.Height = reader.ReadInt16();
            layer.Flags = reader.ReadInt16();
            layer.Visible = (~layer.Flags & 1) == 1;
            layer.Parallax = (layer.Flags & 2) == 2;
            layer.ParallaxX = reader.ReadSingle();
            layer.ParallaxY = reader.ReadSingle();
            layer.ScrollX = reader.ReadSingle();
            layer.ScrollY = reader.ReadSingle();
            int segs = reader.ReadInt32();
            layer.Reflective = reader.ReadBoolean();
            reader.ReadBytes(3); // reserved

            short length = reader.ReadInt16();
            layer.Name = new string(reader.ReadChars(length));

            layer._tiles = new short[layer.Width, layer.Height];
            for (int y = 0; y < layer.Height; ++y)
                for (int x = 0; x < layer.Width; ++x)
                    layer._tiles[x, y] = reader.ReadInt16();

            while (segs-- > 0) layer.Segments.Add(new Segment(reader));
            return layer;
        }

        public void CreateNew(short width, short height)
        {
            Width = width;
            Height = height;
            Name = "Untitled";

            _tiles = new short[width, height];
        }

        public bool SetTile(int x, int y, short index)
        {
            if (index < 0) return false;
            if (x < 0 || x >= Width) return false;
            if (y < 0 || y >= Height) return false;

            _tiles[x, y] = index;
            return true;
        }

        public bool Validate(int max)
        {
            bool retVal = true;
            for (int y = 0; y < Height; ++y)
            {
                for (int x = 0; x < Width; ++x)
                {
                    short index = _tiles[x, y];
                    if (index >= max)
                    {
                        index = _tiles[x, y] = 0;
                        retVal = false;
                    }
                }
            }
            return retVal;
        }

        public void SetTiles(short[,] tiles)
        {
            int w = _tiles.GetLength(0);
            int h = _tiles.GetLength(1);

            _tiles = new short[w, h];
            for (int x = 0; x < w; ++x)
                for (int y = 0; y < h; ++y)
                    _tiles[x, y] = tiles[x, y];
        }

        public short[,] CloneTiles()
        {
            int w = _tiles.GetLength(0);
            int h = _tiles.GetLength(1);
            short[,] copies = new short[w, h];
            for (int x = 0; x < w; ++x)
                for (int y = 0; y < h; ++y)
                    copies[x, y] = _tiles[x, y];
            return copies;
        }

        public void AdjustTiles(short startindex, short delta)
        {
            for (int y = 0; y < Height; ++y)
                for (int x = 0; x < Width; ++x)
                    if (_tiles[x, y] > startindex)
                    {
                        _tiles[x, y] += delta;
                        if (_tiles[x, y] < 0) _tiles[x, y] = 0;
                    }
        }

        public short GetTile(int x, int y)
        {
            if (x < 0 || y < 0 || x >= Width || y >= Height) return -1;
            else return _tiles[x, y];
        }

        public void Resize(short width, short height)
        {
            short[,] new_tiles = new short[width, height];

            int w = Math.Min(width, Width);
            int h = Math.Min(height, Height);

            for (int x = 0; x <  w; ++x)
                for (int y = 0; y < h; ++y)
                    new_tiles[x, y] = _tiles[x, y];

            Width = width;
            Height = height;
            _tiles = new_tiles;
        }
    }
}
