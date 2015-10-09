using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Sphere.Core;
using Sphere.Plugins;
using Sphere.Plugins.Interfaces;

namespace SphereStudio.Plugins.Components
{
    internal class FramePanel : Panel
    {
        private Spriteset _sprite;
        private Frame _frame = null;
        private bool _showDelay, _entered, _selected, _do_drag, _draw_drag;
        private int _zoom = 1;
        private Point _drag_start = Point.Empty;

        public FramePanel(Frame frame, Spriteset sprite, ISettings settings)
        {
            _sprite = sprite;
            _frame = frame;
            DoubleBuffered = true;
            BackgroundImage = Properties.Resources.EditAreaBG2;
            Dock = DockStyle.Left;
            _showDelay = settings.GetBoolean("spriteset-showdelay", false);
            Margin = new Padding(3);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) _sprite.Dispose();
            base.Dispose(disposing);
        }

        protected override void OnMouseEnter(System.EventArgs e)
        {
            _entered = true;
            Refresh();
        }

        protected override void OnMouseLeave(System.EventArgs e)
        {
            _entered = false;
            Refresh();
        }

        public int Zoom
        {
            get { return _zoom; }
            set
            {
                _zoom = value;
                Width = _sprite.SpriteWidth * value;
                Height = _sprite.SpriteHeight * value;
            }
        }

        public short Delay
        {
            get { return _frame.Delay; }
            set { _frame.Delay = value; }
        }

        public bool ShowDelay
        {
            get { return _showDelay; }
            set { _showDelay = value; Invalidate(true); }
        }

        public Frame Frame
        {
            get { return _frame; }
            set { _frame = value; }
        }

        public short Index
        {
            get { return _frame.Index; }
            set { _frame.Index = value; }
        }

        public bool Selected
        {
            get { return _selected; }
            set { _selected = value; Refresh(); }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
            e.Graphics.DrawImage(_sprite.Images[Frame.Index], 0, 0, Width, Height);

            if (_showDelay)
            {
                e.Graphics.FillRectangle(Brushes.White, Width - 16, Height - 18, 16, 18);
                e.Graphics.DrawRectangle(Pens.Black, Width - 16, Height - 18, 16, 18);
                e.Graphics.DrawString(Delay.ToString(), SystemFonts.MessageBoxFont, Brushes.Black, Width - 14, Height - 17);
            }

            if (_selected)
            {
                Pen pen;
                if (_entered) pen = new Pen(Color.FromArgb(200, Color.Green), 2F);
                else pen = new Pen(Color.FromArgb(200, Color.SlateBlue), 2F);
                e.Graphics.DrawRectangle(pen, 1, 1, Width - 2, Height - 2);
                pen.Dispose();
            }
            else if (_entered)
            {
                Pen pen = new Pen(Color.FromArgb(200, Color.Yellow), 2F);
                e.Graphics.DrawRectangle(pen, 1, 1, Width - 2, Height - 2);
                pen.Dispose();
            }
            else
            {
                e.Graphics.DrawRectangle(Pens.Navy, 0, 0, Width, Height);
            }

            if (_draw_drag) e.Graphics.DrawRectangle(Pens.Red, 1, 1, Width - 2, Height - 2);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            _do_drag = true;
            _drag_start = e.Location;
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            _do_drag = false;
            base.OnMouseUp(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (_do_drag)
            {
                int xx = _drag_start.X - e.X; // I check cursor location for valid
                int yy = _drag_start.Y - e.Y; // drag operation...

                if (Math.Sqrt(xx * xx + yy * yy) > 4)
                {
                    _draw_drag = true;
                    DoDragDrop(new DataObject("Frame", this), DragDropEffects.Move);
                    _do_drag = _draw_drag = false;
                }
            }

            base.OnMouseMove(e);
        }
    }
}
