using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

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

    public class Line
    {
        private short x1, y1, x2, y2;
        public Line(short x1, short y1, short x2, short y2)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
        }

        public Line(Point start, Point end)
        {
            this.x1 = (short)start.X;
            this.x2 = (short)end.X;
            this.y1 = (short)start.Y;
            this.y2 = (short)end.Y;
        }

        public Line(Line copy)
        {
            this.x1 = copy.x1;
            this.x2 = copy.x2;
            this.y1 = copy.y1;
            this.y2 = copy.y2;
        }

        public short X1
        {
            get { return x1; }
            set { x1 = value; }
        }

        public short Y1
        {
            get { return y1; }
            set { y1 = value; }
        }

        public short X2
        {
            get { return x2; }
            set { x2 = value; }
        }

        public short Y2
        {
            get { return y2; }
            set { y2 = value; }
        }

        public void DrawLine(Graphics g, Pen p)
        {
            g.DrawLine(p, this.x1, this.y1, this.x2, this.y2);
        }

        public static Rectangle ToRectangle(Line l)
        {
            Line copy = new Line(l);

            if (l.x2 < l.x1) { copy.x1 = l.x2; copy.x2 = l.x1; }
            if (l.y2 < l.y1) { copy.y1 = l.y2; copy.y2 = l.y1; }

            int w = copy.x2 - copy.x1;
            int h = copy.y2 - copy.y1;
            return new Rectangle(copy.x1, copy.y1, w, h);
        }
    }
}
