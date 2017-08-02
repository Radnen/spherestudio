using System.IO;
using System.Drawing;

namespace SphereStudio.Vanilla
{
    /// <summary>
    /// An obstruction segment.
    /// </summary>
    public class Segment
    {
        private readonly int _x1;
        private readonly int _y1;
        private readonly int _x2;
        private readonly int _y2;

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
            _x1 = x1;
            _x2 = x2;
            _y1 = y1;
            _y2 = y2;
        }

        /// <summary>
        /// Creates and loads a segment from a filestream.
        /// </summary>
        /// <param name="stream">The System.IO.BinaryReader to use.</param>
        public Segment(BinaryReader stream)
        {
            _x1 = stream.ReadInt32();
            _y1 = stream.ReadInt32();
            _x2 = stream.ReadInt32();
            _y2 = stream.ReadInt32();
        }

        /// <summary>
        /// Draws this obstruction segement to the System.Drawings.Graphics.
        /// </summary>
        /// <param name="g">The System.Drawing.Graphics to use.</param>
        /// <param name="offX">The offset x position.</param>
        /// <param name="offY">The offset y position.</param>
        /// <param name="zoom">The zoom factor to use.</param>
        public void DrawMe(Graphics g, int offX, int offY, int zoom)
        {
            g.DrawLine(Pens.Magenta, _x1 * zoom - offX, _y1 * zoom - offY, _x2 * zoom - offX, _y2 * zoom - offY);
        }

        /// <summary>
        /// Draws this obstruction segement to the System.Drawings.Graphics.
        /// </summary>
        /// <param name="g">The System.Drawing.Graphics to use.</param>
        /// <param name="offset">The x/y offset to use.</param>
        /// <param name="zoom">The zoom factor to use.</param>
        public void Draw(Graphics g, ref Point offset, int zoom)
        {
            int x = _x1 * zoom + offset.X;
            int y = _y1 * zoom + offset.Y;
            int xx = _x2 * zoom + offset.X;
            int yy = _y2 * zoom + offset.Y;
            g.DrawLine(Pens.Magenta, x, y, xx, yy);
        }

        /// <summary>
        /// Stores this segment into a filestream.
        /// </summary>
        /// <param name="binwrite">The System.IO.BinaryWriter to use.</param>
        public void Save(BinaryWriter binwrite)
        {
            binwrite.Write(_x1);
            binwrite.Write(_y1);
            binwrite.Write(_x2);
            binwrite.Write(_y2);
        }
    }
}
