using System.Drawing;

namespace Sphere_Editor.Utility
{
    public class Line
    {
        private short x1, y1, x2, y2;

        public Line() { }

        public Line(short x1, short y1, short x2, short y2)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
        }

        public Line(Point start, Point end)
            : this((short)start.X, (short)start.Y, (short)end.X, (short)end.Y) { }

        public Line(Line copy) :
            this(copy.x1, copy.y1, copy.x2, copy.y2) { }

        /// <summary>
        /// Gets or sets the starting x value.
        /// </summary>
        public short X1
        {
            get { return x1; }
            set { x1 = value; }
        }

        /// <summary>
        /// Gets or sets the starting y value.
        /// </summary>
        public short Y1
        {
            get { return y1; }
            set { y1 = value; }
        }

        /// <summary>
        /// Gets or sets the ending x value.
        /// </summary>
        public short X2
        {
            get { return x2; }
            set { x2 = value; }
        }

        /// <summary>
        /// Gets or sets the ending y value.
        /// </summary>
        public short Y2
        {
            get { return y2; }
            set { y2 = value; }
        }

        /// <summary>
        /// Gets or sets the start location of this Line.
        /// </summary>
        public Point Start
        {
            get { return new Point(x1, y1); }
            set { x1 = (short)value.X; y1 = (short)value.Y; }
        }

        /// <summary>
        /// Gets or sets the end location of this Line.
        /// </summary>
        public Point End
        {
            get { return new Point(x2, y2); }
            set { x2 = (short)value.X; y2 = (short)value.Y; }
        }

        public void DrawLine(Graphics g, Pen p)
        {
            g.DrawLine(p, this.x1, this.y1, this.x2, this.y2);
        }

        /// <summary>
        /// Grabs the area of a Line.
        /// </summary>
        /// <param name="l">The line to convert</param>
        /// <returns>A System.Drawing.Rectangle of the area of this Line.</returns>
        public static Rectangle ToRectangle(Line l)
        {
            Line copy = new Line(l);

            if (l.x2 < l.x1) { copy.x1 = l.x2; copy.x2 = l.x1; }
            if (l.y2 < l.y1) { copy.y1 = l.y2; copy.y2 = l.y1; }

            int w = copy.x2 - copy.x1;
            int h = copy.y2 - copy.y1;
            return new Rectangle(copy.x1, copy.y1, w, h);
        }

        /// <summary>
        /// Grabs the area of this Line.
        /// </summary>
        /// <returns>A System.Drawing.Rectangle of the area of this Line.</returns>
        public Rectangle ToRectangle()
        {
            return ToRectangle(this);
        }
    }
}
