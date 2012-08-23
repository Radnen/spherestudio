using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;

namespace Sphere_Editor.SphereObjects
{
    public class Zone2
    {
        #region attributes
        private short _x1, _y1;
        private short _x2, _y2;
        public short Layer { get; set; }
        public short NumSteps { get; set; }
        public string Function { get; set; }
        public bool Visible { get; set; }
        private static Brush _bg = new SolidBrush(Color.FromArgb(125, Color.Red));
        private static Brush _bg2 = new SolidBrush(Color.FromArgb(125, Color.Yellow));
        private static Pen _off_pen;
        #endregion

        public int Width { get { return _x2 - _x1; } set { _x2 = (short)(_x1 + value); } }
        public int Height { get { return _y2 - _y1; } set { _y2 = (short)(_y1 + value); } }
        public int X { get { return _x1; } set { _x1 = (short)value; } }
        public int Y { get { return _y1; } set { _y1 = (short)value; } }

        public Zone2()
        {
            if (_off_pen == null)
            {
                _off_pen = new Pen(Color.Red);
                _off_pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            }

            Function = "";
            NumSteps = 8;
            Layer = 0;
            Visible = true;
        }

        public static Zone2 FromBinary(BinaryReader reader)
        {
            Zone2 zone = new Zone2();

            // read header:
            zone._x1 = reader.ReadInt16();
            zone._y1 = reader.ReadInt16();
            zone._x2 = reader.ReadInt16();
            zone._y2 = reader.ReadInt16();
            zone.Layer = reader.ReadInt16();
            zone.NumSteps = reader.ReadInt16();
            reader.ReadBytes(4);

            // read function:
            short length = reader.ReadInt16();
            zone.Function = new string(reader.ReadChars(length));

            return zone;
        }

        public void Save(BinaryWriter writer)
        {
            // save header:
            writer.Write(_x1);
            writer.Write(_y1);
            writer.Write(_x2);
            writer.Write(_y2);
            writer.Write(Layer);
            writer.Write(NumSteps);
            writer.Write(new byte[4]);

            // save function:
            writer.Write((short)Function.Length);
            writer.Write(Function.ToCharArray());
        }

        public bool IsMouseWithin(Point mouse)
        {
            return (mouse.X >= X && mouse.X < X + Width && mouse.Y >= Y && mouse.Y < Y + Height);
        }

        public void Draw(Graphics map, Point offset, int lighted, int zoom)
        {
            if (!Visible) return;
            int x = offset.X + X * zoom;
            int y = offset.Y + Y * zoom;
            int w = Width * zoom;
            int h = Height * zoom;
            if (lighted < 0) // disabled
            {
                map.DrawRectangle(_off_pen, x, y, w, h);
            }
            else if (lighted > 0) // hovered
            {
                map.FillRectangle(_bg2, x, y, w, h);
                map.DrawRectangle(Pens.Yellow, x, y, w, h);
            }
            else // enabled
            {
                map.FillRectangle(_bg, x, y, w, h);
                map.DrawRectangle(Pens.Red, x, y, w, h);
                Point p = new Point(x + 4, y + 4);
                map.DrawString("Layer: " + Layer, SystemFonts.DialogFont, Brushes.White, p);
            }
        }

        public Zone2 Clone()
        {
            Zone2 zone = new Zone2();
            zone.X = X;
            zone.Y = Y;
            zone.Width = Width;
            zone.Height = Height;
            zone.Layer = Layer;
            zone.NumSteps = NumSteps;
            zone.Function = Function;

            return zone;
        }
    }
}
