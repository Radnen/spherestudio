using System.Drawing;

namespace Sphere.Core.Utility
{
    /// <summary>
    /// A convenient Line object.
    /// </summary>
    public class Line
    {
        private short x1, y1, x2, y2;

        /// <summary>
        /// Creates a new, empty Line.
        /// </summary>
        public Line() { }

        /// <summary>
        /// Creates a line with some values.
        /// </summary>
        /// <param name="x1">The start x.</param>
        /// <param name="y1">The start y.</param>
        /// <param name="x2">The end x.</param>
        /// <param name="y2">The end y.</param>
        public Line(short x1, short y1, short x2, short y2)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
        }

        /// <summary>
        /// Creates a line with some values.
        /// </summary>
        /// <param name="start">The start Point.</param>
        /// <param name="end">The end Point.</param>
        public Line(Point start, Point end)
            : this((short)start.X, (short)start.Y, (short)end.X, (short)end.Y) { }

        /// <summary>
        /// Creates a line from another line.
        /// </summary>
        /// <param name="copy">The other line to copy from.</param>
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

        /// <summary>
        /// Draws this line to the System.Drawing.Graphics.
        /// </summary>
        /// <param name="g">The System.Drawing.graphics to use.</param>
        /// <param name="pen">The pen style to use.</param>
        public void DrawLine(Graphics g, Pen pen)
        {
            g.DrawLine(pen, this.x1, this.y1, this.x2, this.y2);
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
