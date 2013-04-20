using System.IO;
using System.Drawing;

namespace Sphere.Core
{
    /// <summary>
    /// An obstruction segment.
    /// </summary>
    public class Segment
    {
        private int x1, y1, x2, y2;

        /// <summary>
        /// Creates an empty segment.
        /// </summary>
        public Segment() { }

        /// <summary>
        /// Creates a segment with supplied values.
        /// </summary>
        /// <param name="x1">The upper left x.</param>
        /// <param name="y1">The upper left y.</param>
        /// <param name="x2">The lower right x.</param>
        /// <param name="y2">The lower right y.</param>
        public Segment(int x1, int y1, int x2, int y2)
        {
            this.x1 = x1;
            this.x2 = x2;
            this.y1 = y1;
            this.y2 = y2;
        }

        /// <summary>
        /// Creates and loads a segment from a filestream.
        /// </summary>
        /// <param name="stream">The System.IO.BinaryReader to use.</param>
        public Segment(BinaryReader stream)
        {
            this.x1 = stream.ReadInt32();
            this.y1 = stream.ReadInt32();
            this.x2 = stream.ReadInt32();
            this.y2 = stream.ReadInt32();
        }

        /// <summary>
        /// Draws this obstruction segement to the System.Drawings.Graphics.
        /// </summary>
        /// <param name="g">The System.Drawing.Graphics to use.</param>
        /// <param name="off_x">The offset x position.</param>
        /// <param name="off_y">The offset y position.</param>
        /// <param name="zoom">The zoom factor to use.</param>
        public void DrawMe(Graphics g, int off_x, int off_y, int zoom)
        {
            g.DrawLine(Pens.Magenta, x1 * zoom - off_x, y1 * zoom - off_y, x2 * zoom - off_x, y2 * zoom - off_y);
        }

        /// <summary>
        /// Draws this obstruction segement to the System.Drawings.Graphics.
        /// </summary>
        /// <param name="g">The System.Drawing.Graphics to use.</param>
        /// <param name="offset">The x/y offset to use.</param>
        /// <param name="zoom">The zoom factor to use.</param>
        public void Draw(Graphics g, ref Point offset, int zoom)
        {
            int x = x1 * zoom + offset.X;
            int y = y1 * zoom + offset.Y;
            int xx = x2 * zoom + offset.X;
            int yy = y2 * zoom + offset.Y;
            g.DrawLine(Pens.Magenta, x, y, xx, yy);
        }

        /// <summary>
        /// Stores this segment into a filestream.
        /// </summary>
        /// <param name="binwrite">The System.IO.BinaryWriter to use.</param>
        internal void Save(BinaryWriter binwrite)
        {
            binwrite.Write(this.x1);
            binwrite.Write(this.y1);
            binwrite.Write(this.x2);
            binwrite.Write(this.y2);
        }
    }
}
