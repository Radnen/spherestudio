using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;

namespace Sphere.Core
{
    /// <summary>
    /// A Sphere Zone object.
    /// </summary>
    public class Zone
    {
        #region attributes
        private short _x1, _y1;
        private short _x2, _y2;

        /// <summary>
        /// Gets or sers the layer index of this Zone.
        /// </summary>
        public short Layer { get; set; }
        
        /// <summary>
        /// Gets or sets the number of steps for this Zone.
        /// </summary>
        public short NumSteps { get; set; }

        /// <summary>
        /// Gets or sets the Function used by this Zone.
        /// </summary>
        public string Function { get; set; }

        /// <summary>
        /// Gets or sets the visibility of this Zone.
        /// </summary>
        public bool Visible { get; set; }

        private static Brush _bg = new SolidBrush(Color.FromArgb(125, Color.Red));
        private static Brush _bg2 = new SolidBrush(Color.FromArgb(125, Color.Yellow));
        private static Pen _off_pen;
        #endregion

        /// <summary>
        /// Gets or sets the width of this Zone in pixels.
        /// </summary>
        public int Width { get { return _x2 - _x1; } set { _x2 = (short)(_x1 + value); } }

        /// <summary>
        /// Gets or sets the height of this Zone in pixels.
        /// </summary>
        public int Height { get { return _y2 - _y1; } set { _y2 = (short)(_y1 + value); } }
        
        /// <summary>
        /// Gets or sets the x location of this Zone in pixels.
        /// </summary>
        public int X { get { return _x1; } set { _x1 = (short)value; } }

        /// <summary>
        /// Gets or sets the y location of this zone in pixels.
        /// </summary>
        public int Y { get { return _y1; } set { _y1 = (short)value; } }

        /// <summary>
        /// Creates a new, blank zone.
        /// </summary>
        public Zone()
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

        /// <summary>
        /// Creates a zone from a filestream.
        /// </summary>
        /// <param name="reader">The System.IO.BinrayReader to use.</param>
        /// <returns>A zone object.</returns>
        public static Zone FromBinary(BinaryReader reader)
        {
            Zone zone = new Zone();

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

        /// <summary>
        /// Stores the zone into a filestream.
        /// </summary>
        /// <param name="writer">The System.IO.BinaryWriter to use.</param>
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

        /// <summary>
        /// Gets if whather or not the mouse is in a zone.
        /// </summary>
        /// <param name="mouse">The System.Drawing.Point of the mouses location.</param>
        /// <returns>True if mouse is inside.</returns>
        public bool IsMouseWithin(Point mouse)
        {
            return (mouse.X >= X && mouse.X < X + Width && mouse.Y >= Y && mouse.Y < Y + Height);
        }

        /// <summary>
        /// Draws the zone to a System.drawing.Graphics.
        /// </summary>
        /// <param name="map">The System.Drawing.Graphics to use.</param>
        /// <param name="offset">The x/y offset of the zone.</param>
        /// <param name="lighted">The state the zone is in.</param>
        /// <param name="zoom">The zoom factor.</param>
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

        /// <summary>
        /// Creates a perfect copy of this Zone.
        /// </summary>
        /// <returns>A Zone object.</returns>
        public Zone Clone()
        {
            Zone zone = new Zone();
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
