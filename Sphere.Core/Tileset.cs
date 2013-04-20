using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using Sphere.Core.Utility;

namespace Sphere.Core
{
    /// <summary>
    /// A sphree Tileset object.
    /// </summary>
    public class Tileset : IDisposable
    {
        /// <summary>
        /// Gets a list of Tile objects this Tileset uses.
        /// </summary>
        public List<Tile> Tiles { get; private set; }

        /// <summary>
        /// Gets or sets the width of a tile in pixels.
        /// </summary>
        public short TileWidth { get; set; }

        /// <summary>
        /// Gets or sets the height of a tile in pixels.
        /// </summary>
        public short TileHeight { get; set; }

        private short _version = 1;
        private byte _has_obstruct, _compression;

        /// <summary>
        /// Gets if this has disposed or not.
        /// </summary>
        public bool IsDisposed { get { return _disposed; } }

        /// <summary>
        /// Creates a fresh, empty tileset.
        /// </summary>
        public Tileset()
        {
            Tiles = new List<Tile>();
        }

        /// <summary>
        /// Adds a blank tile to the list of tiles.
        /// </summary>
        /// <param name="tile_width">The tile width in pixels.</param>
        /// <param name="tile_height">The tile height in pixels.</param>
        public void CreateNew(short tile_width, short tile_height)
        {
            TileWidth = tile_width;
            TileHeight = tile_height;
            Tiles.Add(new Tile(TileWidth, TileHeight));
        }

        /// <summary>
        /// Loads a tileset independantly from a file.
        /// </summary>
        /// <param name="filename">The filename to load from.</param>
        /// <returns>A tileset object from the file or null if it doesn't exist.</returns>
        public static Tileset FromFile(string filename)
        {
            if (!File.Exists(filename)) return null;
            using (BinaryReader reader = new BinaryReader(File.OpenRead(filename)))
            {
                return FromBinary(reader);
            }
        }

        /// <summary>
        /// Takes the images of a spriteset and creates a ileset representation of it.
        /// </summary>
        /// <param name="set">The spriteset to use.</param>
        /// <returns>A tileset of the spritesets images.</returns>
        public static Tileset FromSpriteset(Spriteset set)
        {
            Tileset tileset = new Tileset();
            foreach (Bitmap image in set.Images)
                tileset.Tiles.Add(new Tile(image));

            tileset.TileWidth = set.SpriteWidth;
            tileset.TileHeight = set.SpriteHeight;

            return tileset;
        }

        /// <summary>
        /// Loads a tileset from a filestream.
        /// </summary>
        /// <param name="reader">The System.IO.BinrayReader to use.</param>
        /// <returns>A tileset object.</returns>
        public static Tileset FromBinary(BinaryReader reader)
        {
            Tileset ts = new Tileset();
            reader.ReadChars(4); // sign
            ts._version = reader.ReadInt16();  // version
            short num_tiles = reader.ReadInt16();
            ts.TileWidth = reader.ReadInt16();
            ts.TileHeight = reader.ReadInt16();
            reader.ReadInt16(); // tile_bpp
            ts._compression = reader.ReadByte();
            ts._has_obstruct = reader.ReadByte();
            reader.ReadBytes(240);

            using (BitmapLoader loader = new BitmapLoader(ts.TileWidth, ts.TileHeight))
            {
                int bit_size = ts.TileWidth * ts.TileHeight * 4;
                Tile new_tile;

                while (num_tiles-- > 0)
                {
                    new_tile = new Tile(ts.TileWidth, ts.TileHeight);
                    new_tile.Graphic = loader.LoadFromStream(reader, bit_size);
                    ts.Tiles.Add(new_tile);
                }
            }

            foreach (Tile t in ts.Tiles)
            {
                reader.ReadByte();
                t.Animated = reader.ReadBoolean();
                t.NextAnim = reader.ReadInt16();
                t.Delay = reader.ReadInt16();
                reader.ReadByte();
                t.Blocked = reader.ReadByte();
                int segs = reader.ReadInt16();
                int amt = reader.ReadInt16();
                reader.ReadBytes(20);
                t.Name = new string(reader.ReadChars(amt));
                while (segs-- > 0)
                {
                    Line l = new Line(reader.ReadInt16(), reader.ReadInt16(), reader.ReadInt16(), reader.ReadInt16());
                    t.Obstructions.Add(l);
                }
            }

            return ts;
        }

        /// <summary>
        /// Savbes the tileset to a separate file.
        /// </summary>
        /// <param name="filename">The filename to save to.</param>
        public void Save(string filename)
        {
            using (BinaryWriter writer = new BinaryWriter(File.OpenWrite(filename)))
            {
                // save header data:
                writer.Write(".rts".ToCharArray());
                writer.Write(_version);
                writer.Write((short)Tiles.Count);
                writer.Write(TileWidth);
                writer.Write(TileHeight);
                writer.Write((short)32);
                writer.Write(_compression);

                foreach (Tile t in Tiles)
                    if (t.Obstructions.Count > 0) _has_obstruct = 1;

                writer.Write(_has_obstruct);
                writer.Write(new byte[240]);

                // save tile pixels:
                BitmapSaver saver = new BitmapSaver(TileWidth, TileHeight);
                for (int i = 0; i < Tiles.Count; ++i)
                    saver.SaveToStream(Tiles[i].Graphic, writer);

                // save tile info:
                foreach (Tile t in Tiles)
                {
                    writer.Write(new byte());
                    writer.Write(t.Animated);
                    writer.Write(t.NextAnim);
                    writer.Write(t.Delay);
                    writer.Write(new byte());
                    writer.Write((byte)2);
                    writer.Write((short)t.Obstructions.Count);
                    writer.Write((short)t.Name.Length);
                    writer.Write(new byte[20]);
                    writer.Write(t.Name.ToCharArray());
                    foreach (Line l in t.Obstructions)
                    {
                        writer.Write(l.X1); writer.Write(l.Y1);
                        writer.Write(l.X2); writer.Write(l.Y2);
                    }
                }

                writer.Flush();
            }
        }

        /// <summary>
        /// Disposes and clears this Tileset.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool _disposed = false;
        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    for (int i = 0; i < Tiles.Count; ++i)
                    {
                        Tiles[i].Graphic.Dispose();
                        Tiles[i].Graphic = null;
                    }
                }
                Tiles = null;
            }
            _disposed = true;
        }

        /// <summary>
        /// Resizes the tiles in the tileset.
        /// </summary>
        /// <param name="tw">New tile width.</param>
        /// <param name="th">New tile height.</param>
        /// <param name="rescale">If true rescale, else resize.</param>
        public void ResizeTiles(short tw, short th, bool rescale)
        {
            TileWidth = tw;
            TileHeight = th;

            foreach (Tile t in Tiles)
            {
                Bitmap bmap = new Bitmap(tw, th, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
                using (Graphics g = Graphics.FromImage(bmap))
                {
                    g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

                    if (rescale)
                        g.DrawImage(t.Graphic, 0, 0, tw, th);
                    else
                        g.DrawImageUnscaled(t.Graphic, Point.Empty);
                }
                t.Graphic.Dispose();
                t.Graphic = bmap;
            }
        }

        /// <summary>
        /// Updates graphics From a tileset image file.
        /// </summary>
        /// <param name="filename"></param>
        public void UpdateFromImage(string filename)
        {
            Bitmap img = (Bitmap)Bitmap.FromFile(filename);
            Rectangle rect = new Rectangle(0, 0, TileWidth, TileHeight);

            int index = 0;
            for (int y = 0; y < img.Height; y += TileHeight)
            {
                rect.Y = y;
                for (int x = 0; x < img.Width; x += TileWidth, index++)
                {
                    rect.X = x;
                    if (index < Tiles.Count)
                    {
                        Tiles[index].Graphic.Dispose();
                        Tiles[index].Graphic = img.Clone(rect, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
                    }
                    else
                    {
                        Tile t = new Tile(img.Clone(rect, System.Drawing.Imaging.PixelFormat.Format32bppPArgb));
                        Tiles.Add(t);
                    }
                }
            }

            img.Dispose();
        }

        /// <summary>
        /// Saves the tileset as an image.
        /// </summary>
        /// <param name="filename">The filename to save to.</param>
        /// <param name="across">The amount of tiles to put across (width-wise).</param>
        public void SaveImage(string filename, int across = 6)
        {
            int w = across * TileWidth;
            int h = (int)Math.Ceiling((float)Tiles.Count / across) * TileHeight;

            using (Bitmap img = new Bitmap(w, h))
            {
                using (Graphics g = Graphics.FromImage(img))
                {
                    g.Clear(Color.Transparent);
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

                    for (int i = 0, y = 0; y < h; y += TileHeight)
                    {
                        for (int x = 0; x < w; x += TileWidth, i++)
                        {
                            g.DrawImage(Tiles[i].Graphic, x, y);
                        }
                    }
                }

                img.Save(filename, System.Drawing.Imaging.ImageFormat.Png);
            }
        }
    }
}
