using System.IO;
using System.Drawing;

namespace Sphere_Editor.SphereObjects
{
    public class Segment
    {
        private int x1, y1, x2, y2;

        public Segment() { }

        public Segment(int x1, int y1, int x2, int y2)
        {
            this.x1 = x1;
            this.x2 = x2;
            this.y1 = y1;
            this.y2 = y2;
        }

        public Segment(BinaryReader stream)
        {
            this.x1 = stream.ReadInt32();
            this.y1 = stream.ReadInt32();
            this.x2 = stream.ReadInt32();
            this.y2 = stream.ReadInt32();
        }

        // I can try and do something cool with these segments!
        public void DrawMe(Graphics g, int off_x, int off_y, int zoom)
        {
            g.DrawLine(Pens.Magenta, x1 * zoom - off_x, y1 * zoom - off_y, x2 * zoom - off_x, y2 * zoom - off_y);
        }

        public void Draw(Graphics g, ref Point offset, int zoom)
        {
            int x = x1 * zoom + offset.X;
            int y = y1 * zoom + offset.Y;
            int xx = x2 * zoom + offset.X;
            int yy = y2 * zoom + offset.Y;
            g.DrawLine(Pens.Magenta, x, y, xx, yy);
        }

        internal void Save(BinaryWriter binwrite)
        {
            binwrite.Write(this.x1);
            binwrite.Write(this.y1);
            binwrite.Write(this.x2);
            binwrite.Write(this.y2);
        }
    }
}
