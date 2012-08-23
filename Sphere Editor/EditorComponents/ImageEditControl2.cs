using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using Sphere_Editor.SphereObjects;
using Sphere_Editor.Bitmaps;

namespace Sphere_Editor.EditorComponents
{
    public partial class ImageEditControl2 : UserControl
    {
        #region attributes
        private Bitmap _image;
        private Bitmap _edit_layer;
        private Graphics _edit_canvas;
        private Bitmap _grid_bg, _bg;
        public int Zoom { get; private set; }
        public int _last_zoom;
        private bool _paint;
        private Point _mouse, _last_mouse;
        private Pen _draw_pen;
        private HistoryManager _h_manager;
        private Point _start_anchor = new Point();
        private Point _end_anchor = new Point();
        public event EventHandler ImageEdited;
        public event EventHandler ColorChanged;
        public ToolStripLabel LocationLabel { get; set; }
        public bool Outlined { get; set; }
        public Point Pixel { get { return _mouse; } }
        public bool FixedSize { get; set; }


        public enum ImageTool
        {
            Pen,
            Line,
            Rectangle,
            Floodfill,
            Pan
        }

        public ImageTool Tool { get; set; }
        public bool UseGrid { get; set; }

        public bool CanUndo { get { return _h_manager.CanUndo; } }
        public bool CanRedo { get { return _h_manager.CanRedo; } }
        public Image EditImage { get { return _edit_layer; } }
        public Color DrawColor
        {
            get { return _draw_pen.Color; }
            set { _draw_pen.Color = value; }
        }
        #endregion

        public ImageEditControl2()
        {
            InitializeComponent();
            _draw_pen = new System.Drawing.Pen(Color.White);
            _h_manager = new HistoryManager();
        }

        public void MakeNew(int width, int height)
        {
            SetImage(new Bitmap(width, height, PixelFormat.Format32bppPArgb));
        }

        public void Destroy()
        {
            if (_image != null)
            {
                _image.Dispose();
                _edit_layer.Dispose();
                _edit_canvas.Dispose();
                _grid_bg.Dispose();
                _bg.Dispose();
                _draw_pen.Dispose();
                _h_manager.Dispose();
            }

            _image = null;
        }

        private void UpdateGrid()
        {
            if (_image == null) return;
            if (_grid_bg != null) _grid_bg.Dispose();

            _grid_bg = new Bitmap(Width, Height, PixelFormat.Format32bppPArgb);

            using (Graphics g = Graphics.FromImage(_grid_bg))
            {
                for (int x = 0; x < Width; x += Zoom) g.DrawLine(Pens.Magenta, x, 0, x, Width);
                for (int y = 0; y < Height; y += Zoom) g.DrawLine(Pens.Magenta, 0, y, Height, y);
            }
        }

        /// <summary>
        /// Sets the drawing image as a copy of the image.
        /// </summary>
        public void SetImage(Bitmap image)
        {
            if (image == null) return;
            if (_image != null)
            {
                _image.Dispose();
                _edit_layer.Dispose();
                _edit_canvas.Dispose();
            }

            _image = new Bitmap(image);
            _edit_layer = new Bitmap(_image);
            _edit_canvas = Graphics.FromImage(_edit_layer);
            _edit_canvas.InterpolationMode = InterpolationMode.NearestNeighbor;
            _edit_canvas.CompositingMode = CompositingMode.SourceCopy;

            // here I construct a new dotted bg image.
            if (_bg != null) _bg.Dispose();
            _bg = new Bitmap(_image.Width, _image.Height, PixelFormat.Format32bppPArgb);
            FastBitmap bmap = new FastBitmap(_bg);
            bmap.LockImage();
            for (int x = 0; x < _image.Width; x++)
                for (int y = 0; y < _image.Height; y++)
                    if (y % 2 == (x % 2 == 0 ? 0 : 1)) bmap.SetPixel(x, y, Color.LightGray);
            bmap.UnlockImage();

            ResizeToFit();
        }

        /// <summary>
        /// Gets a copy of the current drawing image.
        /// </summary>
        public Bitmap GetImage()
        {
            Bitmap copy = new Bitmap(_image);
            return copy;
        }

        private void ImageEditControl2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _start_anchor = _mouse;
                _end_anchor = _start_anchor;

                if (Tool == ImageTool.Pen)
                {
                    using (SolidBrush brush = new SolidBrush(DrawColor))
                    {
                        _edit_canvas.FillRectangle(brush, _start_anchor.X, _start_anchor.Y, 1, 1);
                    }
                }

                _paint = true;
                Invalidate();
            }
        }

        private void ImageEditControl2_MouseMove(object sender, MouseEventArgs e)
        {
            _mouse.X = Math.Max(0, Math.Min(e.X, Width - 1)) / Zoom;
            _mouse.Y = Math.Max(0, Math.Min(e.Y, Height - 1)) / Zoom;

            if (_mouse != _last_mouse)
            {
                if (_paint)
                {
                    if (Tool == ImageTool.Pen) DoTool();
                    else if (Tool == ImageTool.Pan)
                    {
                        Slide(_mouse.X - _last_mouse.X, _mouse.Y - _last_mouse.Y);
                    }
                }

                if (LocationLabel != null)
                    LocationLabel.Text = "Loc: " + _mouse;

                Invalidate(false);
                _last_mouse = _mouse;
            }
        }

        private void DrawTool(Graphics g)
        {
            short x1 = (short)(_start_anchor.X * Zoom);
            short y1 = (short)(_start_anchor.Y * Zoom);
            short x2 = (short)(_mouse.X * Zoom);
            short y2 = (short)(_mouse.Y * Zoom);

            switch (Tool)
            {
                case ImageTool.Line:
                    g.DrawLine(_draw_pen, x1 + Zoom / 2, y1 + Zoom / 2, x2 + Zoom / 2, y2 + Zoom / 2);
                    break;
                case ImageTool.Rectangle:
                    Rectangle rect = Line.ToRectangle(new Line(x1, y1, x2, y2));
                    rect.Width += Zoom;
                    rect.Height += Zoom;
                    if (!Outlined)
                        using (Brush b = new SolidBrush(DrawColor))
                        {
                            g.FillRectangle(b, rect);
                        }
                    else g.DrawRectangle(_draw_pen, rect);
                    break;
            }
        }

        private void DoTool()
        {
            Rectangle rect;
            switch (Tool)
            {
                case ImageTool.Pen:
                    _edit_canvas.DrawLine(_draw_pen, _mouse, _last_mouse);
                    if (_mouse.X < _start_anchor.X) _start_anchor.X = _mouse.X;
                    if (_mouse.Y < _start_anchor.Y) _start_anchor.Y = _mouse.Y;
                    if (_mouse.X > _end_anchor.X) _end_anchor.X = _mouse.X;
                    if (_mouse.Y > _end_anchor.Y) _end_anchor.Y = _mouse.Y;
                    break;
                case ImageTool.Line:
                    _edit_canvas.DrawLine(_draw_pen, _start_anchor, _mouse);
                    _end_anchor = _end_anchor = _mouse;
                    break;
                case ImageTool.Rectangle:
                    rect = Line.ToRectangle(new Line(_start_anchor, _mouse));
                    if (!Outlined)
                    {
                        rect.Width += 1;
                        rect.Height += 1;
                        using (Brush b = new SolidBrush(DrawColor))
                        {
                            _edit_canvas.FillRectangle(b, rect);
                        }
                    }
                    else _edit_canvas.DrawRectangle(_draw_pen, rect);
                    _end_anchor = _mouse;
                    break;
                case ImageTool.Floodfill:
                    FastBitmap bmap = new FastBitmap(_edit_layer);
                    bmap.LockImage();
                    rect = bmap.FloodFill(_mouse.X, _mouse.Y, DrawColor);
                    bmap.UnlockImage();
                    _start_anchor = rect.Location;
                    _end_anchor.X = rect.Right;
                    _end_anchor.Y = rect.Bottom;
                    break;
            }
        }

        private void ImageEditControl2_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _paint = false;
                DoTool();
                PushHistory();
                if (ImageEdited != null) ImageEdited(this, EventArgs.Empty);
                Invalidate();
            }
        }

        private void PushResizePage(Image image)
        {
            ImageResizePage page = new ImageResizePage(this, _image, image);
            _h_manager.PushPage(page);
        }

        private void PushHistory()
        {
            Line region = new Line(_start_anchor, _end_anchor);
            Rectangle rect = Line.ToRectangle(region);
            rect.Width += 1;
            rect.Height += 1;

            Image before = _image.Clone(rect, PixelFormat.Format32bppPArgb);
            Image after = _edit_layer.Clone(rect, PixelFormat.Format32bppPArgb);

            ImagePage page = new ImagePage(this, rect.Location, before, after);
            Flatten(ref rect);
            _h_manager.PushPage(page);
        }

        // flatten will compile a portion of the current editing copy to
        // the base image for undo/redo, saving, and copy/paste purposes.
        private void Flatten(ref Rectangle rect)
        {
            using (Graphics g = Graphics.FromImage(_image))
            {
                g.PixelOffsetMode = PixelOffsetMode.Half;
                g.InterpolationMode = InterpolationMode.NearestNeighbor;
                g.CompositingQuality = CompositingQuality.HighSpeed;
                g.CompositingMode = CompositingMode.SourceCopy;
                g.DrawImage(_edit_layer, rect, rect, GraphicsUnit.Pixel);
            }
        }

        private void ImageEditControl2_Paint(object sender, PaintEventArgs e)
        {
            if (_image == null) return;

            e.Graphics.CompositingQuality = CompositingQuality.HighSpeed;
            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;

            e.Graphics.DrawImage(_bg, 0, 0, Width, Height);
            e.Graphics.DrawImage(_edit_layer, 0, 0, Width, Height);

            if (UseGrid) e.Graphics.DrawImageUnscaled(_grid_bg, Point.Empty);
            if (_paint) DrawTool(e.Graphics);
        }

        public void ResizeToFit()
        {
            if (Parent == null || _image == null) return;
            Zoom = Math.Max(1, Math.Min(Parent.Height / _image.Height, Parent.Width / _image.Width));
            Width = _image.Width * Zoom;
            Height = _image.Height * Zoom;
            int x = Parent.Width / 2 - Width / 2;
            int y = Parent.Height / 2 - Height / 2;
            Location = new Point(x, y);
            if (Zoom != _last_zoom)
            {
                UpdateGrid();
                _last_zoom = Zoom;
                Invalidate(false);
            }
        }

        public void Undo()
        {
            if (_h_manager.Undo())
            {
                Rectangle area = new Rectangle(Point.Empty, _image.Size);
                Flatten(ref area);
                Invalidate(false);
            }
        }

        public void Redo()
        {
            if (_h_manager.Redo())
            {
                Rectangle area = new Rectangle(Point.Empty, _image.Size);
                Flatten(ref area);
                Invalidate(false);
            }
        }

        public void ClearHistory()
        {
            _h_manager.Clear();
        }

        public void ResizeImage(int width, int height)
        {
            Bitmap image = new Bitmap(width, height);
            Rectangle rect = new Rectangle(0, 0, width, height);
            using (Graphics g = Graphics.FromImage(image))
            {
                g.InterpolationMode = InterpolationMode.NearestNeighbor;
                g.DrawImageUnscaledAndClipped(_image, rect);
            }
            PushResizePage(image);
            SetImage(image);
            if (ImageEdited != null) ImageEdited(this, EventArgs.Empty);
        }

        public void RescaleImage(int width, int height, InterpolationMode mode)
        {
            Bitmap image = new Bitmap(width, height, PixelFormat.Format32bppPArgb);
            using (Graphics g = Graphics.FromImage(image))
            {
                g.InterpolationMode = mode;
                g.DrawImage(_image, 0, 0, width, height);
            }
            PushResizePage(image);
            SetImage(image);
            if (ImageEdited != null) ImageEdited(this, EventArgs.Empty);
        }

        public void Slide(int ox, int oy)
        {
            // this optimization technique creates the illusion of moving left or up.
            Bitmap image = new Bitmap(_edit_layer);
            if (ox < 0) ox += _image.Width;
            if (oy < 0) oy += _image.Height;

            int w = _image.Width - ox, h = _image.Height - oy;
            CompositingMode oldMode = _edit_canvas.CompositingMode;
            _edit_canvas.CompositingMode = CompositingMode.SourceCopy;
            _edit_canvas.DrawImageUnscaled(image, ox, oy);
            if (ox > 0)
            {
                Rectangle right = new Rectangle(w, 0, ox, h);
                _edit_canvas.DrawImageUnscaled(image.Clone(right, PixelFormat.Format32bppPArgb), 0, oy);
            }
            if (oy > 0)
            {
                Rectangle bottom = new Rectangle(0, h, w, oy);
                _edit_canvas.DrawImageUnscaled(image.Clone(bottom, PixelFormat.Format32bppPArgb), ox, 0);
            }
            if (ox > 0 && oy > 0)
            {
                Rectangle lr = new Rectangle(w, h, ox, oy);
                _edit_canvas.DrawImageUnscaled(image.Clone(lr, PixelFormat.Format32bppPArgb), 0, 0);
            }

            image.Dispose();
            _edit_canvas.CompositingMode = oldMode;
            _start_anchor = Point.Empty;
            _end_anchor.X = _image.Width - 1;
            _end_anchor.Y = _image.Height - 1;
        }

        private void replaceColorItem_Click(object sender, EventArgs e)
        {
            FastBitmap bmap = new FastBitmap(_edit_layer);
            bmap.LockImage();
            bmap.ReplaceColor(bmap.GetPixel(_mouse.X, _mouse.Y), DrawColor);
            bmap.UnlockImage();
            _start_anchor = Point.Empty;
            _end_anchor.X = _image.Width - 1;
            _end_anchor.Y = _image.Height - 1;
            PushHistory();
            if (ImageEdited != null) ImageEdited(this, EventArgs.Empty);
        }

        private void selectColorItem_Click(object sender, EventArgs e)
        {
            FastBitmap bmap = new FastBitmap(_edit_layer);
            bmap.LockImage();
            DrawColor = bmap.GetPixel(_mouse.X, _mouse.Y);
            bmap.UnlockImage();
            if (ColorChanged != null) ColorChanged(this, EventArgs.Empty);
        }

        public void Copy()
        {
            Clipboard.SetImage(_image);
        }

        public void Paste()
        {
            if (FixedSize) PasteInto();
            else
            {
                IDataObject obj = Clipboard.GetDataObject();
                if (obj.GetDataPresent(DataFormats.Bitmap))
                {
                    Bitmap image = (Bitmap)obj.GetData("System.Drawing.Bitmap");
                    PushResizePage(image);
                    SetImage(image);
                    if (ImageEdited != null) ImageEdited(this, EventArgs.Empty);
                }
            }
        }

        public void PasteInto()
        {
            IDataObject obj = Clipboard.GetDataObject();
            if (obj.GetDataPresent(DataFormats.Bitmap))
            {
                Bitmap img = (Bitmap)obj.GetData("System.Drawing.Bitmap");
                Rectangle rect = new Rectangle(Point.Empty, _image.Size);
                _edit_canvas.DrawImageUnscaledAndClipped(img, rect);
                _start_anchor = Point.Empty;
                _end_anchor.X = rect.Width - 1;
                _end_anchor.Y = rect.Height - 1;
                PushHistory();
                if (ImageEdited != null) ImageEdited(this, EventArgs.Empty);
            }
        }

        private void copyImageItem_Click(object sender, EventArgs e)
        {
            Copy();
        }

        private void pasteNewItem_Click(object sender, EventArgs e)
        {
            Paste();
        }

        private void pasteIntoItem_Click(object sender, EventArgs e)
        {
            PasteInto();
        }

        private void replaceItem_Click(object sender, EventArgs e)
        {
            blendItem.Checked = false;
            _edit_canvas.CompositingMode = CompositingMode.SourceCopy;
        }

        private void blendItem_Click(object sender, EventArgs e)
        {
            replaceItem.Checked = false;
            _edit_canvas.CompositingMode = CompositingMode.SourceOver;
        }

        private void RotateFlip(RotateFlipType type)
        {
            _edit_layer.RotateFlip(type);
            _start_anchor = Point.Empty;
            _end_anchor.X = _image.Width - 1;
            _end_anchor.Y = _image.Height - 1;
            PushHistory();
            if (ImageEdited != null) ImageEdited(this, EventArgs.Empty);
        }

        private void horizontalItem_Click(object sender, EventArgs e)
        {
            RotateFlip(RotateFlipType.RotateNoneFlipX);
        }

        private void verticalItem_Click(object sender, EventArgs e)
        {
            RotateFlip(RotateFlipType.RotateNoneFlipY);
        }

        private void rotateLeftItem_Click(object sender, EventArgs e)
        {
            RotateFlip(RotateFlipType.Rotate270FlipNone);            
        }

        private void rotateRightItem_Click(object sender, EventArgs e)
        {
            RotateFlip(RotateFlipType.Rotate90FlipNone);
        }

        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            if (EditImage.Width != EditImage.Height)
            {
                rotateLeftItem.Enabled = false;
                rotateRightItem.Enabled = false;
            }
        }
    }
}
