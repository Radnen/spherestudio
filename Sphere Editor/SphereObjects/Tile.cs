using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using Sphere_Editor.Utility;

namespace Sphere_Editor.SphereObjects
{
    public class Tile
    {
        private int _width = 16, _height = 16;
        private short delay = 0, next_anim = 0;
        private bool animated = false;
        private byte blocked = 0;
        private String name = "";
        private Bitmap graphic;

        private List<Line> obstructions = new List<Line>();

        /// <summary>
        /// Creates a tile object, from an existing image.
        /// </summary>
        /// <param name="image"></param>
        public Tile(Bitmap image)
        {
            _width = image.Width;
            _height = image.Height;
            graphic = image;
        }

        /// <summary>
        /// Create's a new tile object.
        /// </summary>
        /// <param name="width">The width of the tile.</param>
        /// <param name="height">The height of the tile.</param>
        public Tile(int width, int height)
        {
            _width = width;
            _height = height;
            graphic = new Bitmap(width, height, PixelFormat.Format32bppPArgb);
            using (Graphics g = Graphics.FromImage(graphic))
            {
                g.FillRectangle(Brushes.Black, new Rectangle(0, 0, Width, Height));
            }
        }

        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }

        public short Delay
        {
            get { return delay; }
            set { delay = value; }
        }

        public bool Animated
        {
            get { return animated; }
            set { animated = value; }
        }

        public byte Blocked
        {
            get { return blocked; }
            set { blocked = value; }
        }

        public short NextAnim
        {
            get { return next_anim; }
            set { next_anim = value; }
        }

        public List<Line> Obstructions
        {
            get { return obstructions; }
            set { obstructions = value; }
        }

        public Bitmap Graphic
        {
            get { return graphic; }
            set { if (graphic != null) { graphic.Dispose(); } graphic = value; }
        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public Tile Clone()
        {
            Tile new_tile = new Tile((Bitmap)graphic.Clone());
            new_tile.Name = (String)Name.Clone();
            return new_tile;
        }
    }
}
