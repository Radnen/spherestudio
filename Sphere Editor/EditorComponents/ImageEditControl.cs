using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using Sphere_Editor.Forms.ColorPicker;
using Sphere_Editor.Bitmaps;

namespace Sphere_Editor.EditorComponents
{
    public partial class ImageEditorControl : UserControl
    {
        public enum Tool
        {
            Pen,
            Line,
            Rect,
            Fill,
            Elipse,
            Pan
        }

        #region private fields
        private int _zoom = 1;
        private int _vw, _vh; // virtual width and height space
        private bool grid = false, _paint = false, _ctrl = false; // ctrl-click handler;
        private Pen LinePen = Pens.Pink, SelPen = new Pen(Color.White), TilePen = Pens.Yellow;
        private Bitmap image, edit_layer, grid_image, bg_image;
        private TileImage[] TileImages;
        private List<TileImage> TileArray = new List<TileImage>();

        private List<HistoryPage> UndoQueue = new List<HistoryPage>();
        private List<HistoryPage> RedoQueue = new List<HistoryPage>();
        private Rectangle edit_region = Rectangle.Empty;
        private Point Origin = Point.Empty;

        private int base_width, base_height;
        private Color color = Color.White;
        private int cur_img;
        private int cur_x, cur_y;   // current mouse position
        private int tool_x, tool_y; // tool start position
        private int last_x, last_y; // last mouse position
        private int x_off, y_off;   // image offsets from scrollbars

        private List<bool> visible_layers = new List<bool>();

        private Tool _tool;
        private Control dummy;
        #endregion

        public delegate void EventHandler(object sender, EventArgs e);
        public event EventHandler ImageEdited, ColorChanged;

        public ImageEditorControl()
        {
            InitializeComponent();
            base_width = Width;
            base_height = Height;
            
            image = new Bitmap(Width, Height, PixelFormat.Format32bppPArgb);
            visible_layers.Add(true);
            edit_layer = new Bitmap(image);

            // add base pages to undo/redo history:
            AddPage(UndoQueue, true);
            AddPage(RedoQueue, true);

            // a work-around for the autoscroll:
            dummy = new Control("test", 0, 0, 0, 0);
            dummy.Enabled = false;
            Controls.Add(dummy);
        }

        #region getters and setters
        public ToolStripStatusLabel LocationLabel { get; set; }

        public DynamicPalette DynaPalette { get; set; }

        public int Zoom
        {
            get { return _zoom; }
        }

        public int ToolNum
        {
            get { return (int)_tool; }
            set
            {
                _tool = (Tool)value;
                if (value == 5) this.Cursor = Cursors.SizeAll;
                else this.Cursor = Cursors.Default;
            }
        }

        public int ImageAmount
        {
            get { return TileArray.Count; }
        }

        public Color DrawColor
        {
            get { return color; }
            set { color = value; SelPen.Color = value; }
        }

        /// <summary>
        /// Grabs a copy of this bitmap.
        /// </summary>
        public Bitmap Image
        {
            get { return new Bitmap(image); }
        }

        public bool Undoable
        {
            get { return (cur_img > 0); }
        }

        public bool Redoable
        {
            get { return (cur_img < UndoQueue.Count - 1); }
        }

        public bool Outline { get; set; }
        #endregion

        // used to ignore dummy nodes movement:
        protected override Point ScrollToControl(Control activeControl)
        {
            return DisplayRectangle.Location;
        }

        protected override void OnScroll(ScrollEventArgs se)
        {
            if (se.ScrollOrientation == ScrollOrientation.HorizontalScroll)
                x_off = se.NewValue / _zoom;
            else
                y_off = se.NewValue / _zoom;

            Refresh();
            base.OnScroll(se);
        }

        // removes any disposable data, or otherwise it will just linger there.
        public void Destroy()
        {
            ClearHistory();
            image.Dispose();
            edit_layer.Dispose();
            SelPen.Dispose();
            if (grid_image != null) grid_image.Dispose();
            if (bg_image != null) bg_image.Dispose();
            if (TileImages != null) foreach (TileImage ti in TileImages) ti.Image.Dispose();
            dummy.Dispose();
        }

        private void ImageEditorControl_Load(object sender, EventArgs e)
        {
            Width = Math.Min(Parent.Width, base_width);
            Height = Math.Min(Parent.Height, base_height);
        }

        public List<bool> LayerVisibility
        {
            get { return visible_layers; }
            set { visible_layers = value; }
        }

        public void UpdateScrollbars()
        {
            int x = -2 + _zoom, y = -2 + _zoom;
            if (_vh > Parent.Height && Width < Parent.Width) { x = -19; y = _zoom / 2; }
            if (_vw > Parent.Width && Height < Parent.Height) { x = _zoom / 2; y = -19; }
            if (Width < Parent.Width && Height < Parent.Height) x = y = -2;

            AutoScrollPosition = new Point(0, 0);
            x_off = 0; y_off = 0;

            HorizontalScroll.SmallChange = _zoom;
            HorizontalScroll.LargeChange = _zoom * 4;
            VerticalScroll.SmallChange = _zoom;
            VerticalScroll.LargeChange = _zoom * 4;

            Point p = new Point(_vw + x, _vh + y);
            dummy.Location = p;
        }

        private void UpdateControlSize()
        {
            Width = Math.Min(Parent.Width, _vw);
            Height = Math.Min(Parent.Height, _vh);

            if (_vh > Parent.Height && Width < Parent.Width) Width += 19;
            else if (_vw > Parent.Width && Height < Parent.Height) Height += 19;
        }

        /// <summary>
        /// Positions the object in the middle of its container.
        /// Also toggles scrollbars where apropriate.
        /// </summary>
        public void UpdateControl()
        {
            UpdateControlSize();
            if (Width < Parent.Width && Height < Parent.Height)
                Location = new Point(Parent.Width / 2 - Width / 2, Parent.Height / 2 - Height / 2);
            else if (Width < Parent.Width)
                Location = new Point(Parent.Width / 2 - Width / 2, 0);
            else if (Height < Parent.Height)
                Location = new Point(0, Parent.Height / 2 - Height / 2);
            else Location = Point.Empty;
            UpdateScrollbars();
            Invalidate();
        }

        public void SetSize(int width, int height)
        {
            _vw = base_width = width;
            _vh = base_height = height;
            _vw = _vw * _zoom;
            _vh = _vh * _zoom;
            UpdateControl();
            Invalidate();
        }

        public void SetZoom(int zoom)
        {
            if (zoom != _zoom)
            {
                _zoom = zoom;
                UpdateGrid();
            }
            _vw = base_width * zoom;
            _vh = base_height * zoom;
            UpdateControl();
            Invalidate();
        }

        public void SetImage(Bitmap img)
        {
            ClearHistory();
            TileArray.Clear();
            TileImages = null;
            
            if (image != null) image.Dispose();
            image = new Bitmap(img);
            if (edit_layer != null) edit_layer.Dispose();
            edit_layer = new Bitmap(image);
            
            AddPage(UndoQueue, true);
            AddPage(RedoQueue, true);

            if (img.Width != base_width || img.Height != base_height) UpdateGrid();
            SetSize(img.Width, img.Height);
            SetZoom(_zoom);
        }

        // this will set the editor with a field that corresponds to tile indices.
        // the Bitmap img should be pre-compiled.
        public void SetTileImageMap(Bitmap img, short[] indices)
        {
            SetImage(img);
            for (int i = 0; i < indices.Length; ++i) TileArray.Add(new TileImage(indices[i]));
            TileImages = TileArray.ToArray();
        }

        // return a series of the original - yet modified TileImage objects.
        public TileImage[] GetEditorImageTiles(int tw, int th)
        {
            int width = base_width / tw;
            int height = (int)Math.Ceiling((float)TileArray.Count / (float)width);
            int index = 0;
            int yy = 0;
            Rectangle rect;
            for (int y = 0; y < height; ++y)
            {
                yy = y * th;
                for (int x = 0; x < width; ++x)
                {
                    if (index < TileArray.Count)
                    {
                        rect = new Rectangle(x * tw, yy, tw, th);
                        TileImages[index].Image = image.Clone(rect, image.PixelFormat);
                    }
                    ++index;
                }
            }
            return TileImages;
        }

        public void ToggleGrid()
        {
            grid = !grid;
            Invalidate();
        }

        /// <summary>
        /// Resizes the image to new bounds.
        /// </summary>
        /// <param name="width">New width parameter.</param>
        /// <param name="height">New height parameter.</param>
        /// <param name="scale">If true, it shall scale the image rather than increase canvas size.</param>
        /// <param name="mode">the resizing mode</param>
        public void ResizeImage(int width, int height, bool scale, InterpolationMode mode)
        {
            UpdateHistoryBefore();
            Image temp = this.image;
            image = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(this.image);
            g.InterpolationMode = mode;
            g.PixelOffsetMode = PixelOffsetMode.Half;

            // Perform any scaling:
            if (scale) g.DrawImage(temp, 0, 0, width, height);
            else g.DrawImageUnscaled(temp, 0, 0);
            
            // Duspose resources:
            g.Dispose();
            temp.Dispose();
            edit_layer.Dispose();

            edit_layer = new Bitmap(image);

            this.SetSize(width, height);
            this.SetZoom(_zoom);
            UpdateHistoryAfter();
        }

        private void ImageEditorControl_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            e.Graphics.CompositingQuality = CompositingQuality.HighSpeed;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;

            int wz = Width / _zoom + 1;
            int hz = Height / _zoom + 1;

            DrawBG(e.Graphics);
            if (visible_layers[0])
            {
                Rectangle rect = new Rectangle(0, 0, wz * _zoom, hz * _zoom);
                e.Graphics.DrawImage(edit_layer, rect, x_off, y_off, wz, hz, GraphicsUnit.Pixel);
            }

            if (_paint) DrawTool(e.Graphics);

            /*Size sz = new Size((edit_region.Width + 1) * _zoom, (edit_region.Height + 1) * _zoom);
            Point pt = new Point(edit_region.X * _zoom, edit_region.Y * _zoom);
            Rectangle draw_region = new Rectangle(pt, sz);
            e.Graphics.DrawRectangle(Pens.Red, draw_region);*/

            if (grid && _zoom > 1) DrawGrid(e.Graphics);
        }

        private void UpdateEditRegion(int x, int y)
        {
            switch (_tool)
            {
                case Tool.Pen:
                    if (x < edit_region.X) { edit_region.Width += edit_region.X - x; edit_region.X = x; }
                    else if (x > edit_region.Right) { edit_region.Width = x - edit_region.X; }

                    if (y < edit_region.Y) { edit_region.Height += edit_region.Y - y; edit_region.Y = y; }
                    else if (y > edit_region.Bottom) { edit_region.Height = y - edit_region.Y; }
                break;
                case Tool.Line:
                case Tool.Rect:
                    if (x < Origin.X) edit_region.X = x;
                    else edit_region.X = Origin.X;
                    if (y < Origin.Y) edit_region.Y = y;
                    else edit_region.Y = Origin.Y;
                    edit_region.Width = Math.Abs(Origin.X - x);
                    edit_region.Height = Math.Abs(Origin.Y - y);
                break;
            }
        }

        /// <summary>
        /// Draws the grid image X*Y times, depending on the size of the control.
        /// </summary>
        /// <param name="g">Graphics object in which to draw grid image.</param>
        private void DrawGrid(Graphics g)
        {
            int w = grid_image.Width * ((int)Math.Ceiling((float)Width / grid_image.Width));
            int h = grid_image.Height * ((int)Math.Ceiling((float)Height / grid_image.Height));

            for (int y = 0; y < h; y += grid_image.Height)
                for (int x = 0; x < w; x += grid_image.Width)
                    g.DrawImageUnscaled(grid_image, x, y);
        }

        private void DrawBG(Graphics g)
        {
            if (bg_image != null)
                g.DrawImage(bg_image, 0, 0, _vw, _vh);
        }

        /// <summary>
        /// Initializes the grid which is a generated 512x512 texture.
        /// </summary>
        private void UpdateGrid()
        {
            int w = 256, h = 256;
            if (grid_image != null) grid_image.Dispose();

            grid_image = new Bitmap(w, h, PixelFormat.Format32bppPArgb);

            // draw grid:
            using (Graphics g = Graphics.FromImage(grid_image))
            {
                for (int x = 0; x < w; x += _zoom) g.DrawLine(LinePen, x, 0, x, w);
                for (int y = 0; y < h; y += _zoom) g.DrawLine(LinePen, 0, y, h, y);
            }

            // draw dotted bg image:
            if (bg_image == null)
            {
                w = image.Width; h = image.Height;
                bg_image = new Bitmap(w, h, PixelFormat.Format32bppPArgb);
                using (Graphics g = Graphics.FromImage(bg_image))
                {
                    g.FillRectangle(Brushes.White, 0, 0, w, h);
                    Rectangle rect = new Rectangle(0, 0, 1, 1);
                    for (int x = 0; x < w; x++)
                    {
                        rect.X = x;
                        for (int y = 0; y < h; y++)
                        {
                            if (y % 2 == ((x % 2 == 0) ? 0 : 1))
                            {
                                rect.Y = y;
                                g.FillRectangle(Brushes.LightGray, rect);
                            }
                        }
                    }
                }
            }
        }

        #region history functions
        public void UndoAction()
        {
            //UndoQueue[cur_img].Draw(ref image);
            //UndoQueue[cur_img].Draw(ref edit_layer);

            UpdateUndoRedoItems();
            if (image.Width != base_width || image.Height != base_height)
            {
                this.SetSize(image.Width, image.Height);
                this.SetZoom(this.Zoom);
            }
            else Refresh();
            if (cur_img > 0) cur_img--;
            if (ImageEdited != null) ImageEdited(this, new EventArgs());
        }

        public void RedoAction()
        {
            if (cur_img < RedoQueue.Count - 1) cur_img++;
            //RedoQueue[cur_img].Draw(ref image);
            //RedoQueue[cur_img].Draw(ref edit_layer);

            UpdateUndoRedoItems();
            if (image.Width != base_width || image.Height != base_height)
            {
                this.SetSize(image.Width, image.Height);
                this.SetZoom(this.Zoom);
            }
            else Refresh();
            if (ImageEdited != null) ImageEdited(this, new EventArgs());
        }

        // used after an image has been edited, updates only the editing portion:
        private void UpdateHistory()
        {
            UpdateHistoryBefore(false);
            UpdateHistoryAfter(false);
        }

        // happens before a large image change:
        private void UpdateHistoryBefore() { UpdateHistoryBefore(true); }
        private void UpdateHistoryBefore(bool all)
        {
            if (!all)
            {
                // update region to new offsets:
                edit_region.X += x_off;
                edit_region.Y += y_off;

                // update region to have non-0 sizes:
                if (edit_region.Width == 0) edit_region.Width = 1;
                if (edit_region.Height == 0) edit_region.Height = 1;

                // add padding (to compensate the pixel offset mode of 'half'):
                edit_region.Width++;
                edit_region.Height++;

                // remove padding if out of bounds:
                while (edit_region.Right > image.Width) edit_region.Width--;
                while (edit_region.Bottom > image.Height) edit_region.Height--;
            }

            AddPage(UndoQueue, all);
        }

        private void UpdateHistoryAfter() { UpdateHistoryAfter(true); }
        private void UpdateHistoryAfter(bool all)
        {
            if (!all) Flatten();
            AddPage(RedoQueue, all);
            cur_img++;
            UpdateUndoRedoItems();
            Refresh();
            if (ImageEdited != null) ImageEdited(this, new EventArgs());
        }

        private void AddPage(List<HistoryPage> pages, bool all)
        {
            if (pages.Count > 0)
            {
                //for (int i = cur_img + 1; i < pages.Count - 1 - cur_img; ++i) pages[i].Section.Dispose();
                pages.RemoveRange(cur_img + 1, pages.Count - 1 - cur_img);
            }

            //HistoryPage page;
            //if (all) { page = new HistoryPage(new Bitmap(this.image)); page.IsFullImage = true; }
            //else page = new HistoryPage(image.Clone(edit_region, PixelFormat.Format32bppArgb), edit_region.Location);
            //pages.Add(page);
        }

        private void ClearHistory()
        {
            //foreach (HistoryPage p in UndoQueue) p.Section.Dispose();
            //foreach (HistoryPage p in RedoQueue) p.Section.Dispose();
            UndoQueue.Clear();
            RedoQueue.Clear();
            cur_img = 0;
            UpdateUndoRedoItems();
        }

        public void UpdateUndoRedoItems()
        {
            UndoMenuItem.Enabled = Undoable;
            RedoMenuItem.Enabled = Redoable;
        }

        private void Flatten()
        {
            using (Graphics g = Graphics.FromImage(image))
            {
                g.PixelOffsetMode = PixelOffsetMode.Half;
                g.InterpolationMode = InterpolationMode.NearestNeighbor;
                g.CompositingMode = CompositingMode.SourceCopy;
                using (Bitmap img = edit_layer.Clone(edit_region, PixelFormat.Format32bppPArgb))
                {
                    g.DrawImageUnscaled(img, edit_region.Location);
                }
            }
        }
        #endregion

        #region mouse input
        private void ImageEditorControl_MouseDown(object sender, MouseEventArgs e)
        {            
            if (e.Button == MouseButtons.Left && !_ctrl)
            {
                if (cur_x + x_off >= image.Width || cur_y + y_off >= image.Height) return;

                tool_x = e.X / _zoom * _zoom;
                tool_y = e.Y / _zoom * _zoom;
                
                Origin = new Point(e.X / _zoom, e.Y / _zoom);
                edit_region.Location = Origin;
                edit_region.Size = new Size(1, 1);

                if (_tool == Tool.Pen || _tool == Tool.Rect) edit_layer.SetPixel(x_off + cur_x, y_off + cur_y, color);
                if (_tool == Tool.Pan) UpdateHistoryBefore();
                _paint = true;
                Refresh();
            }
        }

        private void ImageEditorControl_MouseMove(object sender, MouseEventArgs e)
        {
            last_x = cur_x; last_y = cur_y;
            cur_x = e.X / _zoom;
            cur_y = e.Y / _zoom;

            if (LocationLabel != null && (cur_x != last_x || cur_y != last_y))
            {
                LocationLabel.Text = "Location: (" + (cur_x + x_off) + "," + (cur_y + y_off) + ")";
                if (_paint) Invalidate();
            }

            if (_paint)
            {
                if (_tool != Tool.Pan) UpdateEditRegion(Math.Min(Math.Max(0, e.X), Width) / _zoom, Math.Min(Math.Max(0, e.Y), Height) / _zoom);
                if (_tool == Tool.Pen) DoTool(Graphics.FromImage(edit_layer));
                else if (_tool == Tool.Pan)
                {
                    Slide(cur_x - last_x, cur_y - last_y);
                }
            }
        }

        private void ImageEditorControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (_ctrl) GetPixelItem_Click(null, null);
                else if (_paint)
                {
                    if (cur_x + x_off <= image.Width && cur_y + y_off <= image.Height)
                    {
                        if (_tool != Tool.Pen || _tool != Tool.Pan) DoTool(Graphics.FromImage(edit_layer));
                    }
                    
                    if (_tool == Tool.Pan) UpdateHistoryAfter();
                    else UpdateHistory();
                    _paint = false;
                }
            }
        }

        private void DrawTool(Graphics g)
        {
            g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;
            switch (_tool)
            {
                case Tool.Line:
                    int z2 = _zoom/2;
                    int cx = cur_x * _zoom, cy = cur_y * _zoom;
                    g.DrawRectangle(SelPen, tool_x, tool_y, _zoom, _zoom);
                    g.DrawLine(SelPen, tool_x+z2, tool_y+z2, cx+z2, cy+z2);
                break;
                case Tool.Rect:
                    Color draw = Color.FromArgb(255, color);
                    Size sz = new Size((edit_region.Width + 1) * _zoom, (edit_region.Height + 1) * _zoom);
                    Point pt = new Point(edit_region.X * _zoom, edit_region.Y * _zoom);
                    Rectangle draw_region = new Rectangle(pt, sz);

                    if (!Outline) g.FillRectangle(new SolidBrush(draw), draw_region);
                    else g.DrawRectangle(new Pen(draw), draw_region);
                 break;
            }
        }

        private void DoTool(Graphics g)
        {
            g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
            int cx = x_off + cur_x, cy = y_off + cur_y;
            edit_region.Width++; edit_region.Height++;
            edit_region.X += x_off; edit_region.Y += y_off;
            g.SetClip(edit_region);
            switch (_tool)
            {
                case Tool.Pen:
                    g.DrawLine(SelPen, x_off + last_x, y_off + last_y, cx, cy);
                break;
                case Tool.Line:
                    g.DrawLine(SelPen, x_off + Origin.X, y_off + Origin.Y, cx, cy);
                break;
                case Tool.Rect:
                if (!Outline)
                {
                    using (SolidBrush brush = new SolidBrush(color))
                    {
                        g.FillRectangle(brush, edit_region);
                    }
                }
                else
                {
                    edit_region.Width--; edit_region.Height--;

                    if (edit_region.Width == 0 || edit_region.Height == 0)
                        g.DrawLine(SelPen, edit_region.X, edit_region.Y, edit_region.Right, edit_region.Bottom);
                    else
                        g.DrawRectangle(SelPen, edit_region);

                    edit_region.Width++; edit_region.Height++;
                }
                    break;
                case Tool.Fill:
                    FastBitmap bmap = new FastBitmap(edit_layer);
                    bmap.LockImage();
                    edit_region = bmap.FloodFill(cx, cy, color);
                    edit_region.Width++; edit_region.Height++;
                    bmap.UnlockImage();
                break;
                // case 4: ellipse
            }
            edit_region.Width--; edit_region.Height--;
            edit_region.X -= x_off; edit_region.Y -= y_off;
            g.ResetClip();
            g.Dispose();
        }
        #endregion

        /// <summary>
        /// Draws the image slid to the new position.
        /// </summary>
        /// <param name="ox">horizontal increments.</param>
        /// <param name="oy">vertical increments.</param>
        public void Slide(int ox, int oy)
        {
            Graphics g = Graphics.FromImage(edit_layer);
            g.CompositingMode = CompositingMode.SourceCopy;

            // this optimization technique creates the illusion of moving left or up.
            if (ox < 0) ox += image.Width;
            if (oy < 0) oy += image.Height;

            int w = image.Width - ox, h = image.Height - oy;
            g.DrawImageUnscaled(image, ox, oy);
            if (ox > 0)
            {
                Rectangle right = new Rectangle(w, 0, ox, h);
                g.DrawImageUnscaled(image.Clone(right, PixelFormat.Format32bppPArgb), 0, oy);
            }
            if (oy > 0)
            {
                Rectangle bottom = new Rectangle(0, h, w, oy);
                g.DrawImageUnscaled(image.Clone(bottom, PixelFormat.Format32bppPArgb), ox, 0);
            }
            if (ox > 0 && oy > 0)
            {
                Rectangle lr = new Rectangle(w, h, ox, oy);
                g.DrawImageUnscaled(image.Clone(lr, PixelFormat.Format32bppPArgb), 0, 0);
            }
            g.Dispose();
            image.Dispose();
            image = new Bitmap(edit_layer);
        }

        public void ReplacePixels(Color oldCol, Color newCol)
        {
            UpdateHistoryBefore();
            FastBitmap bmap = new FastBitmap(image);
            bmap.LockImage();
            bmap.ReplaceColor(oldCol, newCol);
            bmap.UnlockImage();
            edit_layer.Dispose();
            edit_layer = new Bitmap(image);
            UpdateHistoryAfter();
        }

        public void Copy()
        {
            IDataObject ImageData = new DataObject();
            ImageData.SetData(DataFormats.Dib, true, image);
            ImageData.SetData(DataFormats.Bitmap, true, image);
            Clipboard.SetDataObject(ImageData, true);
        }

        public void Paste()
        {
            IDataObject data = Clipboard.GetDataObject();
            string[] formats = data.GetFormats();
            if (formats.Length == 0) return;

            this.UpdateHistoryBefore(true);
            this.image.Dispose();

            if (data.GetDataPresent(DataFormats.Dib))
            {
                MemoryStream dat = (MemoryStream)data.GetData(DataFormats.Dib);
                this.image = BitmapLoader.BitmapFromDIB(dat);
            }
            else if (data.GetDataPresent(DataFormats.Bitmap))
            {
                this.image = (Bitmap)data.GetData(DataFormats.Bitmap);
            }

            this.edit_layer.Dispose();
            this.edit_layer = new Bitmap(this.image);
            this.UpdateHistoryAfter(true);
            this.SetSize(image.Width, image.Height);
            this.SetZoom(this.Zoom);
        }

        #region context items
        private void GetPixelItem_Click(object sender, EventArgs e)
        {
            DrawColor = image.GetPixel(x_off + cur_x, y_off + cur_y);
            if (ColorChanged != null) ColorChanged(this, new EventArgs());
        }

        private void ToggleGridItem_Click(object sender, EventArgs e)
        {
            this.ToggleGrid();
        }

        private void CopyImageItem_Click(object sender, EventArgs e)
        {
            this.Copy();
        }

        private void PasteImageItem_Click(object sender, EventArgs e)
        {
            this.Paste();
        }

        private void UndoMenuItem_Click(object sender, EventArgs e)
        {
            if (Undoable) UndoAction();
            UpdateUndoRedoItems();
        }

        private void RedoMenuItem_Click(object sender, EventArgs e)
        {
            if (Redoable) RedoAction();
            UpdateUndoRedoItems();
        }

        private void ImageEditorControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey) _ctrl = true;
        }

        private void ImageEditorControl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey) _ctrl = false;
        }

        private void ReplacePixelsItem_Click(object sender, EventArgs e)
        {
            Color cur_col = image.GetPixel(x_off + cur_x, y_off + cur_y);
            ReplacePixels(cur_col, color);
        }
        #endregion

        #region filter algorithms
        // Let's make a gaussian blur filter!
        private Single Gauss(Single x, Single middle, Single width)
        {
            if (width == 0) return 1F;

            Double t = -(1.00 / Width) * ((middle - x) * (middle - x));
            return (Single)Math.Pow(1.5, t);
        }

        public void Blur(int h, int v)
        {
            FastBitmap fastBmp = new FastBitmap(image);
            fastBmp.LockImage();

            int h2 = (h << 1) + 1;
            int v2 = (v << 1) + 1;

            float weight;
            float[] weights = new float[h2];
            for (int i = 0; i < h2; ++i) weights[i] = Gauss(-h + i, 0, h);

            double weighted;
            double a, r, g, b;
            byte ba, br, bg, bb;
            Color c;

            // first we do a horizontal pass:
            for (int row = 0; row < image.Height; ++row)
            {
                for (int col = 0; col < image.Width; ++col)
                {
                    a = r = g = b = 0;
                    weight = 0;
                    for (int i = 0; i < h2; ++i)
                    {
                        int x = col - h + i;
                        if (x < 0)
                        {
                            i += -x;
                            x = 0;
                        }
                        if (x > image.Width - 1) break;
                        c = fastBmp.GetPixel(x, row);
                        weighted = weights[i] / 255 * c.A;
                        r += c.R * weighted;
                        g += c.G * weighted;
                        b += c.B * weighted;
                        a += c.A * weights[i];
                        weight += weights[i];
                    }
                    br = (byte)Math.Min(Math.Round(r/weight), 255);
                    bg = (byte)Math.Min(Math.Round(g/weight), 255);
                    bb = (byte)Math.Min(Math.Round(b/weight), 255);
                    ba = (byte)Math.Min(Math.Round(a/weight), 255);
                    fastBmp.SetPixel(col, row, Color.FromArgb(ba, br, bg, bb));
                }
            }

            if (v2 != h2) weights = new float[v2];
            for (int i = 0; i < v2; ++i) weights[i] = Gauss(-v + 1, 0, v);

            // then we do a vertical pass:
            for (int col = 0; col < image.Width; ++col)
            {
                for (int row = 0; row < image.Height; ++row)
                {
                    a = r = g = b = 0;
                    weight = 0;
                    for (int i = 0; i < v2; ++i)
                    {
                        int y = row - v + i;
                        if (y < 0)
                        {
                            i += -y;
                            y = 0;
                        }
                        if (y > image.Height - 1) break;
                        c = fastBmp.GetPixel(col, y);
                        weighted = weights[i] / 255 * c.A;
                        r += c.R * weighted;
                        g += c.G * weighted;
                        b += c.B * weighted;
                        a += c.A * weights[i];
                        weight += weights[i];
                    }
                    br = (byte)Math.Min(Math.Round(r/weight), 255);
                    bg = (byte)Math.Min(Math.Round(g/weight), 255);
                    bb = (byte)Math.Min(Math.Round(b/weight), 255);
                    ba = (byte)Math.Min(Math.Round(a/weight), 255);
                    fastBmp.SetPixel(col, row, Color.FromArgb(ba, br, bg, bb));
                }
            }

            fastBmp.UnlockImage();
        }

        public void ColorNoise()
        {
            FastBitmap bmap = new FastBitmap(image);
            bmap.LockImage();
            Random rand = new Random();
            Color col;
            int a, r, g, b;
            a = r = g = b = 0;
            for (int y = 0; y < image.Height; ++y)
            {
                for (int x = 0; x < image.Width; ++x)
                {
                    col = bmap.GetPixel(x, y);
                    a = rand.Next(col.A, Math.Min(col.A + 26, 255));
                    r = rand.Next(Math.Max(0, col.R - 25), Math.Min(col.R + 26, 255));
                    g = rand.Next(Math.Max(0, col.G - 25), Math.Min(col.G + 26, 255));
                    b = rand.Next(Math.Max(0, col.B - 25), Math.Min(col.B + 26, 255));
                    bmap.SetPixel(x, y, Color.FromArgb(a, r, g, b));
                }
            }
            bmap.UnlockImage();
        }

        public void MonoNoise()
        {
            FastBitmap bmap = new FastBitmap(image);
            bmap.LockImage();
            Random rand = new Random();
            Color c;
            int num, r, g, b;
            num = r = g = b = 0;
            for (int y = 0; y < image.Height; ++y)
            {
                for (int x = 0; x < image.Width; ++x)
                {
                    c = bmap.GetPixel(x, y);
                    num = rand.Next(0, 51);
                    r = Math.Min(c.R + num, 255);
                    g = Math.Min(c.G + num, 255);
                    b = Math.Min(c.B + num, 255);
                    bmap.SetPixel(x, y, Color.FromArgb(c.A, r, g, b));
                }
            }
            bmap.UnlockImage();
        }

        public void InvertColors()
        {
            FastBitmap bmap = new FastBitmap(image);
            Color c;
            bmap.LockImage();
            for (int y = 0; y < image.Height; ++y)
            {
                for (int x = 0; x < image.Width; ++x)
                {
                    c = bmap.GetPixel(x, y);
                    bmap.SetPixel(x, y, Color.FromArgb(c.A, 255 - c.R, 255 - c.G, 255 - c.B));
                }
            }
            bmap.UnlockImage();
        }

        public void ToGrayscale()
        {
            FastBitmap bmap = new FastBitmap(image);
            bmap.LockImage();
            bmap.Grayscale();
            bmap.UnlockImage();
        }
        #endregion

        #region filter items
        private void BlurItem_Click(object sender, EventArgs e)
        {
            UpdateHistoryBefore();
            Blur(1, 1);
            edit_layer.Dispose();
            edit_layer = new Bitmap(image);
            UpdateHistoryAfter();
        }

        private void NoiseItem_Click(object sender, EventArgs e)
        {
            UpdateHistoryBefore();
            ColorNoise();
            edit_layer.Dispose();
            edit_layer = new Bitmap(image);
            UpdateHistoryAfter();
        }

        private void MonoNoiseItem_Click(object sender, EventArgs e)
        {
            UpdateHistoryBefore();
            MonoNoise();
            edit_layer.Dispose();
            edit_layer = new Bitmap(image);
            UpdateHistoryAfter();
        }

        private void InvertColorItem_Click(object sender, EventArgs e)
        {
            UpdateHistoryBefore();
            InvertColors();
            edit_layer.Dispose();
            edit_layer = new Bitmap(image);
            UpdateHistoryAfter();
        }

        private void GrayscaleItem_Click(object sender, EventArgs e)
        {
            UpdateHistoryBefore();
            ToGrayscale();
            edit_layer.Dispose();
            edit_layer = new Bitmap(image);
            UpdateHistoryAfter();
        }
        #endregion

        #region edit items
        private void FlipHorizontalItem_Click(object sender, EventArgs e)
        {
            UpdateHistoryBefore();
            image.RotateFlip(RotateFlipType.RotateNoneFlipX);
            edit_layer.RotateFlip(RotateFlipType.RotateNoneFlipX);
            UpdateHistoryAfter();
        }

        private void FlipVerticalItem_Click(object sender, EventArgs e)
        {
            UpdateHistoryBefore();
            image.RotateFlip(RotateFlipType.RotateNoneFlipY);
            edit_layer.RotateFlip(RotateFlipType.RotateNoneFlipY);
            UpdateHistoryAfter();
        }

        private void RotateCWItem_Click(object sender, EventArgs e)
        {
            UpdateHistoryBefore();
            image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            edit_layer.RotateFlip(RotateFlipType.Rotate90FlipNone);
            UpdateHistoryAfter();
        }

        private void RotateCCWItem_Click(object sender, EventArgs e)
        {
            UpdateHistoryBefore();
            image.RotateFlip(RotateFlipType.Rotate270FlipNone);
            edit_layer.RotateFlip(RotateFlipType.Rotate270FlipNone);
            UpdateHistoryAfter();
        }

        private void UpItem_Click(object sender, EventArgs e)
        {
            UpdateHistoryBefore();
            Slide(0, -1);
            edit_layer.Dispose();
            edit_layer = new Bitmap(image);
            UpdateHistoryAfter();
        }

        private void DownItem_Click(object sender, EventArgs e)
        {
            UpdateHistoryBefore();
            Slide(0, 1);
            edit_layer.Dispose();
            edit_layer = new Bitmap(image);
            UpdateHistoryAfter();
        }

        private void LeftItem_Click(object sender, EventArgs e)
        {
            UpdateHistoryBefore();
            Slide(-1, 0);
            edit_layer.Dispose();
            edit_layer = new Bitmap(image);
            UpdateHistoryAfter();
        }

        private void RightItem_Click(object sender, EventArgs e)
        {
            UpdateHistoryBefore();
            Slide(1, 0);
            edit_layer.Dispose();
            edit_layer = new Bitmap(image);
            UpdateHistoryAfter();
        }
        #endregion
    }

    #region addendum
    // Used for this control within the tile/map editor.
    public class TileImage
    {
        Bitmap image;
        int index;

        public TileImage(int index_num)
        {
            image = new Bitmap(10, 10);
            index = index_num;
        }

        public Bitmap Image { get { return image; } set { image = value; } }
        public int Index { get { return index; } }
    }

    // Used for the undo queue within this editor.
    /*public class HistoryPage
    {
        Bitmap section;
        Point location;

        public HistoryPage(Bitmap img)
        {
            section = img;
            location = Point.Empty;
        }

        public HistoryPage(Bitmap img, Point p)
        {
            section = img;
            location = p;
        }

        public void Draw(ref Bitmap base_image)
        {
            if (IsFullImage)
            {
                base_image.Dispose();
                base_image = new Bitmap(section);
            }
            else
            {
                Graphics g = Graphics.FromImage(base_image);
                g.CompositingMode = CompositingMode.SourceCopy;
                g.DrawImageUnscaled(section, location);
                g.Dispose();
            }
        }

        public Bitmap Section
        {
            get { return section; }
            set { section = value; }
        }

        // setting this to true means the esction is a full image. This makes resize possible:
        public bool IsFullImage { get; set; }
    }*/
    #endregion
}