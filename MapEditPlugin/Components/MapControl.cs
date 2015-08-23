using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Sphere.Core;
using Sphere.Core.Editor;
using Sphere.Core.Utility;
using Sphere.Plugins;
using SphereStudio.Plugins.Forms;
using SphereStudio.Plugins.UndoRedo;

namespace SphereStudio.Plugins.Components
{
    partial class MapControl : UserControl
    {
        #region Attributes
        private int _vw, _vh;
        private Point _mouse;
        private Point _last_mouse;
        private int _tile_w_zoom;
        private int _tile_h_zoom;
        private bool _ctrl_key, _can_copy = true;
        short[,] _old_cache;

        private bool _paint = false, _move = false;
        private Point _anchor, _offset;
        private static Brush _rect_brush = new SolidBrush(Color.FromArgb(125, Color.Blue));
        public List<GraphicalLayer> GraphicLayers { get; private set; }
        private Zone _temp_zone = new Zone();

        public Point MapPixel { get; set; }
        public short Zoom { get; private set; }
        public List<short> Tiles { get; set; }
        public int SelWidth { get; set; }
        public short CurrentTile { get; set; }
        public short CurrentLayer { get; set; }
        public bool ShowCameraBounds { get; set; }
        public bool ShowTileNums { get; set; }

        /// <summary>
        /// Gets the location of the mouse in tiles.
        /// </summary>
        public Point MouseTile
        {
            get
            {
                Point t = new Point();
                t.X = _mouse.X / _tile_w_zoom;
                t.Y = _mouse.Y / _tile_h_zoom;
                return t;
            }
        }

        public event EventHandler PropChanged;
        public event EventHandler Edited;
        public bool CanZoomIn { get { return Zoom != 4; } }
        public bool CanZoomOut { get { return Zoom != 1; } }

        private Entity _cur_ent = null;
        private Zone _cur_zone = null;

        private Map _base_map;
        public Map BaseMap
        {
            get { return _base_map; }
            set
            {
                _base_map = value;
                if (_base_map != null)
                {
                    Zoom = 1;
                    SelWidth = 1;
                    _tile_h_zoom = value.Tileset.TileWidth;
                    _tile_w_zoom = value.Tileset.TileHeight;
                    _vw = value.Width * _tile_w_zoom;
                    _vh = value.Height * _tile_h_zoom;
                    UpdateScrollBars();

                    if (GraphicLayers != null)
                        foreach (GraphicalLayer layer in GraphicLayers) layer.Dispose();
                    GraphicLayers = new List<GraphicalLayer>(value.Layers.Count);

                    for (int i = 0; i < value.Layers.Count; ++i)
                        GraphicLayers.Add(new GraphicalLayer(value.Layers[i], value.Tileset.TileWidth, value.Tileset.TileHeight));
                }
            }
        }

        public short TileWidth { get { return _base_map.Tileset.TileWidth; } }
        public short TileHeight { get { return _base_map.Tileset.TileHeight; } }
        #endregion

        #region History
        private HistoryManager _h_manager = new HistoryManager();
        private List<HistoryTile> _h_tiles = new List<HistoryTile>();

        public bool CanUndo { get { return _h_manager.CanUndo; } }
        public bool CanRedo { get { return _h_manager.CanRedo; } }
        #endregion

        #region Tools
        public enum MapTool
        {
            Pen,
            Line,
            Rectangle,
            FloodFill,
            Zone,
            Entity,
        }

        public MapTool Tool { get; set; }
        #endregion

        public MapControl()
        {
            Zoom = 1;
            SelWidth = 1;
            MapPixel = new Point(0, 0);
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            MouseWheel += new MouseEventHandler(MapControl_MouseWheel);
            hScrollBar.LargeChange = vScrollBar.LargeChange = 1;
        }

        #region Public Functions
        /// <summary>
        /// Sets the base maps layers to new layers, keeping track of changes.
        /// </summary>
        /// <param name="new_layers">List of new layers to set.</param>
        /// <param name="new_start">The new start layer.</param>
        public void SetLayers(List<Layer> new_layers, byte new_start)
        {
            PushLayerPage(new_layers, new_start);
            _base_map.Layers = new_layers;
            _base_map.StartLayer = new_start;
            RefreshLayers();
        }


        /// <summary>
        /// Redraws the current viewport. Do this when there's a change.
        /// </summary>
        public void RefreshLayers()
        {
            if (_base_map == null || IsDisposed) return;
            for (int i = 0; i < GraphicLayers.Count; ++i)
                GraphicLayers[i].Refresh(_base_map.Layers[i], _base_map.Tileset);
            Invalidate();
        }

        /// <summary>
        /// Resizes the layers to the new width and height.
        /// </summary>
        /// <param name="tw">The new witdh in tiles.</param>
        /// <param name="th">The new Height in tiles.</param>
        public void ResizeLayers(int tw, int th)
        {
            _tile_w_zoom = tw * Zoom;
            _tile_h_zoom = th * Zoom;
            _vw = _tile_w_zoom * BaseMap.Width;
            _vh = _tile_h_zoom * BaseMap.Height;
            
            _offset.X = _offset.X / _tile_w_zoom * _tile_w_zoom;
            _offset.Y = _offset.Y / _tile_h_zoom * _tile_h_zoom;

            for (int i = 0; i < GraphicLayers.Count; ++i)
            {
                GraphicLayers[i].Resize(tw, th);
                GraphicLayers[i].Update(ref _offset, Size, _base_map.Tileset);
            }

            Invalidate();
        }

        /// <summary>
        /// In case you ever get lost you can quickly recenter it.
        /// </summary>
        public void CenterMap()
        {
            _offset.X = Width / 2 - _vw / 2;
            _offset.Y = Height / 2 - _vh / 2;
            UpdateScrollBars();
            UpdateLayers();
        }

        /// <summary>
        /// Used to update and draw a bew region of the map.
        /// Do this only if the view was moved by some other means.
        /// </summary>
        public void UpdateView()
        {
            UpdateScrollBars();
            UpdateLayers();
        }

        /// <summary>
        /// false, means it stopped zooming.
        /// </summary>
        public bool ZoomIn()
        {
            if (Zoom < 4)
            {
                Zoom *= 2;
                _tile_w_zoom = _base_map.Tileset.TileWidth * Zoom;
                _tile_h_zoom = _base_map.Tileset.TileHeight * Zoom;
                _vw = BaseMap.Width * _tile_w_zoom;
                _vh = BaseMap.Height * _tile_h_zoom;
                UpdateScrollBars();
                foreach (GraphicalLayer gl in GraphicLayers) gl.SetZoom(Zoom);
                UpdateLayers();
                UpdateScrollBars();
                Invalidate();
            }
            return CanZoomIn;
        }

        /// <summary>
        /// false means it stopped zooming.
        /// </summary>
        public bool ZoomOut()
        {
            if (Zoom > 1)
            {
                Zoom /= 2;
                _tile_w_zoom = _base_map.Tileset.TileWidth * Zoom;
                _tile_h_zoom = _base_map.Tileset.TileHeight * Zoom;
                _vw = BaseMap.Width * _tile_w_zoom;
                _vh = BaseMap.Height * _tile_h_zoom;
                foreach (GraphicalLayer gl in GraphicLayers) gl.SetZoom(Zoom);
                UpdateLayers();
                UpdateScrollBars();
                Invalidate();
            }
            return CanZoomOut;
        }

        /// <summary>
        /// Adds a new fresh layer to the control.
        /// </summary>
        /// <returns>A sphere layer object.</returns>
        public Layer AddLayer()
        {
            Layer layer = new Layer();
            layer.CreateNew((short)_base_map.Width, (short)_base_map.Height);
            _base_map.Layers.Add(layer);
            GraphicalLayer g_layer = new GraphicalLayer(layer, _base_map.Tileset.TileWidth, _base_map.Tileset.TileHeight);
            g_layer.SetZoom(Zoom);
            GraphicLayers.Add(g_layer);
            UpdateLayers();
            return layer;
        }
        #endregion

        private void UpdateLayers()
        {
            for (int i = 0; i < GraphicLayers.Count; ++i)
                GraphicLayers[i].Update(ref _offset, Size, _base_map.Tileset);
            Invalidate();
        }

        private void CalcMouse(Point mouse)
        {
            _mouse.X = ((mouse.X - _offset.X) / _tile_w_zoom) * _tile_w_zoom;
            _mouse.Y = ((mouse.Y - _offset.Y) / _tile_h_zoom) * _tile_h_zoom;
            MapPixel = new Point((mouse.X - _offset.X) / Zoom, (mouse.Y - _offset.Y) / Zoom);
        }

        #region Draw Logic
        private void MapControl_Paint(object sender, PaintEventArgs e)
        {
            if (BaseMap == null) return;
            e.Graphics.CompositingQuality = CompositingQuality.HighSpeed;
            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;

            DrawGraphicLayers(e.Graphics);

            if (ShowTileNums) DrawTileNums(e.Graphics);

            DrawZones(e.Graphics);
            
            if (_paint && Tool == MapTool.Zone)
                DrawTool(e.Graphics);

            if (Tool == MapTool.Pen)
                DrawSelector(e.Graphics);
            else if (Tool != MapTool.Zone)
                DrawSelector(e.Graphics, true);

            e.Graphics.DrawRectangle(Pens.Black, _offset.X, _offset.Y, _vw, _vh);

            DrawEntities(e.Graphics);

            int sx = _base_map.StartX / TileWidth * TileWidth * Zoom + _offset.X;
            int sy = _base_map.StartY / TileHeight * TileHeight * Zoom + _offset.Y;

            e.Graphics.DrawImage(Properties.Resources.startpos, sx, sy, _tile_w_zoom, _tile_h_zoom);

            if (ShowCameraBounds) DrawCameraBounds(e.Graphics);
        }

        private static Font _numFont = new Font("Courier", 8.0f);

        public void DrawTileNums(Graphics graphics)
        {
            int h = _base_map.Height * _tile_h_zoom;
            int w = _base_map.Width * _tile_w_zoom;
            for (int y = 0; y < h; y += _tile_h_zoom)
            {
                for (int x = 0; x < w; x += _tile_h_zoom)
                {
                    var tile = _base_map.Layers[CurrentLayer].GetTile(x / _tile_w_zoom, y / _tile_h_zoom);
                    if (tile < 0) continue;

                    if (x < -_offset.X || y < -_offset.Y) continue;
                    if (x > -_offset.X + Width || y > -_offset.Y + Height) continue;

                    int tx = _offset.X + x;
                    int ty = _offset.Y + y;

                    string s = tile.ToString();
                    graphics.DrawString(s, _numFont, Brushes.Black, tx + 1, ty + 1);
                    graphics.DrawString(s, _numFont, Brushes.White, tx, ty);
                }
            }
        }

        private void DrawGraphicLayers(Graphics g)
        {
            for (int i = 0; i < GraphicLayers.Count; ++i)
            {
                GraphicLayers[i].Draw(g, ref _offset);
                if (i == CurrentLayer && _paint && (Tool == MapTool.Line || Tool == MapTool.Rectangle)) DrawTool(g);
            }
        }

        private void DrawZones(Graphics g)
        {
            int state = Tool == MapTool.Zone ? 0 : -1;
            foreach (Zone zone in _base_map.Zones)
                zone.Draw(g, _offset, state, Zoom);
        }

        private void DrawEntities(Graphics g)
        {
            foreach (Entity ent in _base_map.Entities)
                ent.Draw(g, _base_map.Tileset.TileWidth, _base_map.Tileset.TileHeight, ref _offset, Zoom);
        }

        private void DrawSelector(Graphics g, bool single = false)
        {
            bool mouse_in = (_mouse.X >= 0 && _mouse.Y >= 0 && _mouse.X < _vw && _mouse.Y < _vh);
            
            if (!mouse_in) return;
            if (Tiles == null || SelWidth == 0) return;

            Brush yellow = new SolidBrush(Color.FromArgb(125, Color.Yellow));
            int ox = _offset.X + _mouse.X; // origin x/y
            int oy = _offset.Y + _mouse.Y;

            if (single)
            {
                if (Tool == MapTool.Entity && _cur_ent != null && _cur_ent.Layer == CurrentLayer)
                {
                    g.FillRectangle(yellow, ox, oy, _tile_w_zoom, _tile_h_zoom);
                    g.DrawRectangle(Pens.White, ox, oy, _tile_w_zoom, _tile_h_zoom);
                }
                else
                    g.DrawRectangle(Pens.Yellow, ox, oy, _tile_w_zoom, _tile_h_zoom);
                return;
            }

            int w = SelWidth * _tile_w_zoom; // box x/y
            int h = (Tiles.Count / SelWidth) * _tile_h_zoom;

            for (int y = 0; y < h; y += _tile_h_zoom)
                for (int x = 0; x < w; x += _tile_w_zoom)
                    g.DrawRectangle(Pens.Yellow, ox + x, oy + y, _tile_w_zoom, _tile_h_zoom);
        }

        private void DrawCameraBounds(Graphics g)
        {
            int sw = PluginManager.IDE.CurrentGame.ScreenWidth;
            int sh = PluginManager.IDE.CurrentGame.ScreenHeight;
            int x = (sw / 2) * Zoom;
            int y = (sh / 2) * Zoom;
            int w = _vw - sw * Zoom;
            int h = _vh - sh * Zoom;
            g.DrawRectangle(Pens.Magenta, _offset.X + x, _offset.Y + y, w, h);
        }
        #endregion

        private void UpdateScrollBars()
        {
            int maxh = (_vw < Width) ? 0 : (_vw - Width) / _tile_w_zoom + 3;
            int maxv = (_vh < Height) ? 0 : (_vh - Height) / _tile_w_zoom + 3;
            hScrollBar.Maximum = maxh;
            hScrollBar.Minimum = (_vw < Width) ? 0 : -2;
            vScrollBar.Maximum = maxv;
            vScrollBar.Minimum = (_vh < Height) ? 0 : -2;
            hScrollBar.Value = Math.Min(Math.Max(0, -(_offset.X / _tile_w_zoom)), maxh);
            vScrollBar.Value = Math.Min(Math.Max(0, -(_offset.Y / _tile_h_zoom)), maxv);
        }

        private bool GetEntityAtMouse()
        {
            int x, y;
            foreach (Entity ent in _base_map.Entities)
            {
                x = ent.X / _base_map.Tileset.TileWidth * _tile_w_zoom;
                y = ent.Y / _base_map.Tileset.TileHeight * _tile_h_zoom;
                if (_mouse.X == x && _mouse.Y == y)
                {
                    _cur_ent = ent;
                    return true;
                }
            }
            _cur_ent = null;
            return false;
        }

        private bool GetZoneAtMouse()
        {
            foreach (Zone zone in _base_map.Zones)
            {
                if (zone.IsMouseWithin(MapPixel))
                {
                    _cur_zone = zone;
                    return true;
                }
            }
            return false;
        }

        private void InvalidateCursor()
        {
            Invalidate(new Rectangle(0, 0, Width, Height));
        }

        private void StampTiles(int ox, int oy)
        {
            if (Tiles == null || SelWidth == 0) return;
            int w = SelWidth, h = Tiles.Count / w, i = 0;
            for (int y = 0; y < h; ++y)
                for (int x = 0; x < w; ++x, ++i)
                    SetTile(Tiles[i], ox + x, oy + y, false);
        }

        /// <summary>
        /// Sets a tile at the x/y location on the map to the specified tile.
        /// </summary>
        /// <param name="tile">Index number of tile in tileset to set.</param>
        /// <param name="x">The x location in tiles.</param>
        /// <param name="y">The y location in tiles.</param>
        private void SetTile(short tile, int x, int y, bool hist = true)
        {
            short older = _base_map.Layers[CurrentLayer].GetTile(x, y);
            if (tile == -1 || older == -1 || older == tile) return;

            if (hist) { _h_tiles.Add(new HistoryTile(x, y, older, tile)); }

            _base_map.Layers[CurrentLayer].SetTile(x, y, tile);
            GraphicLayers[CurrentLayer].SetTile(x, y, _base_map.Tileset.Tiles[tile].Graphic);
        }

        /// <summary>
        /// Sets the 'current tile' to the x/y location.
        /// </summary>
        private void SetTile(int x, int y)
        {
            SetTile(CurrentTile, x, y);
        }

        #region Mouse
        private void MapControl_MouseWheel(object sender, MouseEventArgs e)
        {
            CalcMouse(e.Location); // update position before.
            if (e.Delta > 0 && CanZoomIn)
            {
                _offset.X -= _mouse.X;
                _offset.Y -= _mouse.Y;
                ZoomIn();
            }
            else if (e.Delta < 0 && CanZoomOut)
            {
                _offset.X += _mouse.X / 2;
                _offset.Y += _mouse.Y / 2;
                ZoomOut();
            }
            CalcMouse(e.Location); // update position after.
            Invalidate();
        }

        private void MapControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (_move)
            {
                _offset.X = e.X - _anchor.X;
                _offset.Y = e.Y - _anchor.Y;
                UpdateLayers();
                Invalidate();
            }
            else CalcMouse(e.Location);

            if (_mouse == _last_mouse) return;

            if (_paint)
            {
                if (Tool == MapTool.Pen)
                {
                    int x = _mouse.X / _tile_w_zoom;
                    int y = _mouse.Y / _tile_h_zoom;
                    StampTiles(x, y);
                }
                else if (Tool == MapTool.Entity && _cur_ent != null &&
                    _cur_ent.Layer == CurrentLayer)
                {
                    if (_ctrl_key && _can_copy) // copy - move:
                        CopyEntity();

                    _cur_ent.X = (short)(_mouse.X / Zoom + TileWidth / 2 - 1);
                    _cur_ent.Y = (short)(_mouse.Y / Zoom + TileHeight / 2 - 1);
                }
            }
            else if (Tool == MapTool.Entity)
                GetEntityAtMouse();

            InvalidateCursor();
            _last_mouse = _mouse;
        }

        private void CopyEntity()
        {
            Entity ent = _cur_ent.Copy();
            if (ent.Type == Entity.EntityType.Person) ent.FigureOutName(_base_map.Entities);
            _base_map.Entities.Add(ent);
            _can_copy = false;
            _cur_ent = ent;
        }

        private void MapControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                CalcMouse(e.Location);

                if (Tool == MapTool.Pen)
                {
                    _old_cache = _base_map.Layers[CurrentLayer].CloneTiles();
                    StampTiles(_mouse.X / _tile_w_zoom, _mouse.Y / _tile_h_zoom);
                }
                else
                    _anchor = _mouse;

                InvalidateCursor();
                _paint = true;
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Middle)
            {
                CalcMouse(e.Location);
                _anchor = e.Location;
                _anchor.X -= _offset.X;
                _anchor.Y -= _offset.Y;
                Cursor.Current = Cursors.SizeAll;
                _move = true;
            }
        }

        private void MapControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                _paint = false;

                if (Tool != MapTool.Pen) DoTool();
                if (Tool == MapTool.Entity)
                {
                    _cur_ent = null;
                    _can_copy = true;
                }
                else if (Tool == MapTool.Pen)
                {
                    short[,] new_cache = _base_map.Layers[CurrentLayer].CloneTiles();
                    LayerTilesPage page = new LayerTilesPage(this, _old_cache, new_cache, CurrentLayer);
                    _h_manager.PushPage(page);
                }
                else PushTilePage();

                if (Edited != null) Edited(this, EventArgs.Empty);
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Middle)
            {
                UpdateLayers();
                Cursor = Cursors.Default;

                hScrollBar.Value = Math.Min(Math.Max(0, -(_offset.X / _tile_w_zoom)), hScrollBar.Maximum);
                vScrollBar.Value = Math.Min(Math.Max(0, -(_offset.Y / _tile_h_zoom)), vScrollBar.Maximum);

                _move = false;
            }
            Invalidate();
        }
        #endregion

        #region History
        public void DrawTile(int x, int y, int layer, short index)
        {
            _base_map.Layers[layer].SetTile(x, y, index);
            GraphicLayers[layer].SetTile(x, y, _base_map.Tileset.Tiles[index].Graphic);
        }

        private void PushTilePage()
        {
            if (_h_tiles.Count == 0) return;
            TileListPage page = new TileListPage(this, _h_tiles, CurrentLayer);
            _h_manager.PushPage(page);
            _h_tiles = new List<HistoryTile>();
        }

        private void PushLayerPage(List<Layer> new_layers, byte new_start)
        {
            LayerPage page = new LayerPage(this, _base_map.Layers, new_layers, _base_map.StartLayer, new_start);
            _h_manager.PushPage(page);
        }

        public void PushTileLayerPage(TileRemovePage page)
        {
            _h_manager.PushPage(page);
        }

        public void PushTileLayerPage(TileAddPage page)
        {
            _h_manager.PushPage(page);
        }

        public bool Undo()
        {
            if (!_h_manager.Undo()) return false;
            Invalidate();
            return CanUndo;
        }

        public bool Redo()
        {
            if (!_h_manager.Redo()) return false;
            Invalidate();
            return CanRedo;
        }
        #endregion

        #region Tools
        private void DrawTool(Graphics g)
        {
            if (!_base_map.Layers[CurrentLayer].Visible) return;
            Line l = new Line(_anchor, _mouse);
            Rectangle r = Line.ToRectangle(l);
            r.Width += _tile_w_zoom;
            r.Height += _tile_h_zoom;

            if (Tool == MapTool.Rectangle)
            {
                r.X += _offset.X;
                r.Y += _offset.Y;
                g.FillRectangle(_rect_brush, r);
                g.DrawRectangle(Pens.Black, r);
            }
            else if (Tool == MapTool.Line)
            {
                l.X1 += (short)(_offset.X + _tile_w_zoom / 2); l.X2 += (short)(_offset.X + _tile_w_zoom / 2);
                l.Y1 += (short)(_offset.Y + _tile_h_zoom / 2); l.Y2 += (short)(_offset.Y + _tile_h_zoom / 2);
                l.DrawLine(g, Pens.Blue);
            }
            else if (Tool == MapTool.Zone)
            {
                _temp_zone.X = r.X / Zoom;
                _temp_zone.Y = r.Y / Zoom;
                _temp_zone.Width = r.Width / Zoom;
                _temp_zone.Height = r.Height / Zoom;
                _temp_zone.Layer = CurrentLayer;
                _temp_zone.Visible = true;
                _temp_zone.Draw(g, _offset, 0, Zoom);
            }
        }

        private void DoTool()
        {
            if (!_base_map.Layers[CurrentLayer].Visible) return;
            Line l = new Line(_anchor, _mouse);
            Rectangle r = Line.ToRectangle(l);
            r.Width += _tile_w_zoom;
            r.Height += _tile_h_zoom;
            int x = r.X / _tile_w_zoom;
            int y = r.Y / _tile_h_zoom;
            int w = r.Width / _tile_w_zoom;
            int h = r.Height / _tile_h_zoom;

            switch (Tool)
            {
                case MapTool.Rectangle:
                    Rectangle(x, y, w, h);
                    break;
                case MapTool.Line:
                    LineTiles(l.X1 / _tile_w_zoom, l.Y1 / _tile_h_zoom, l.X2 / _tile_w_zoom, l.Y2 / _tile_h_zoom);
                    break;
                case MapTool.FloodFill:
                    FloodFill(l.X1 / _tile_w_zoom, l.Y1 / _tile_h_zoom);
                    break;
                case MapTool.Zone:
                    _base_map.Zones.Add(_temp_zone);
                    _temp_zone = new Zone();
                    break;
            }
        }

        #region algorithms
        private void Rectangle(int x, int y, int w, int h)
        {
            w += x;
            h += y;
            for (int i = x; i < w; ++i)
                for (int j = y; j < h; ++j)
                    SetTile(i, j);
        }

        /// <summary>
        /// GRWRID: Bresenham's Algorithm.
        /// </summary>
        private void LineTiles(int x1, int y1, int x2, int y2)
        {
            int dx = Math.Abs(x2 - x1);
            int dy = Math.Abs(y2 - y1);
            int sx = (x1 < x2) ? 1 : -1;
            int sy = (y1 < y2) ? 1 : -1;
            int err = dx - dy, e2;

            while (true)
            {
                SetTile(x1, y1);
                if (x1 == x2 && y1 == y2) break;
                e2 = 2 * err;
                if (e2 > -dy)
                {
                    err -= dy;
                    x1 += sx;
                }
                if (e2 < dx)
                {
                    err += dx;
                    y1 += sy;
                }
                SetTile(x1, y1);
            }
        }

        private void FloodFill(int x, int y)
        {
            int old_tile = _base_map.Layers[CurrentLayer].GetTile(x, y);
            if (old_tile == CurrentTile) return;

            int w = _base_map.Width - 1, h = _base_map.Height - 1;
            Stack<Point> points = new Stack<Point>();
            points.Push(new Point(x, y));
            SetTile(x, y);

            while (points.Count > 0)
            {
                Point pt = points.Pop();
                if (pt.X > 0) CheckFloodPoint(points, pt.X - 1, pt.Y, old_tile);
                if (pt.Y > 0) CheckFloodPoint(points, pt.X, pt.Y - 1, old_tile);
                if (pt.X < w) CheckFloodPoint(points, pt.X + 1, pt.Y, old_tile);
                if (pt.Y < h) CheckFloodPoint(points, pt.X, pt.Y + 1, old_tile);
            }
        }

        private void CheckFloodPoint(Stack<Point> points, int x, int y, int old_t)
        {
            if (_base_map.Layers[CurrentLayer].GetTile(x, y) == old_t)
            {
                points.Push(new Point(x, y));
                SetTile(x, y);
            }
        }
        #endregion
        #endregion

        #region menu items
        private void SelectItem_Click(object sender, EventArgs e)
        {
            int x = _mouse.X / _tile_w_zoom;
            int y = _mouse.Y / _tile_h_zoom;
            CurrentTile = _base_map.Layers[CurrentLayer].GetTile(x, y);
            if (PropChanged != null) PropChanged(this, EventArgs.Empty);
        }

        private void SetStartItem_Click(object sender, EventArgs e)
        {
            _base_map.StartLayer = (byte)CurrentLayer;
            _base_map.StartX = (short)(_mouse.X / Zoom + TileWidth / 2 - 1);
            _base_map.StartY = (short)(_mouse.Y / Zoom + TileHeight / 2 - 1);
            Invalidate();
            if (PropChanged != null) PropChanged(this, EventArgs.Empty);
        }

        private void PersonItem_Click(object sender, EventArgs e)
        {
            using (PersonForm form = new PersonForm(_base_map.Entities))
            {
                form.AddLayers(_base_map.Layers);
                form.SelectedIndex = CurrentLayer;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    form.Person.X = (short)(_mouse.X / Zoom + TileWidth / 2 - 1);
                    form.Person.Y = (short)(_mouse.Y / Zoom + TileHeight / 2 - 1);
                    _base_map.Entities.Add(form.Person);
                    form.Person.Visible = _base_map.Layers[CurrentLayer].Visible;
                    Invalidate();
                    if (Edited != null) Edited(this, EventArgs.Empty);
                }
            }
        }

        private void TriggerItem_Click(object sender, EventArgs e)
        {
            using (TriggerForm form = new TriggerForm())
            {
                form.AddLayers(_base_map.Layers);
                form.SelectedIndex = CurrentLayer;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    form.Trigger.X = (short)(_mouse.X / Zoom + TileWidth / 2 - 1);
                    form.Trigger.Y = (short)(_mouse.Y / Zoom + TileHeight / 2 - 1);
                    _base_map.Entities.Add(form.Trigger);
                    form.Trigger.Visible = _base_map.Layers[CurrentLayer].Visible;
                    Invalidate();
                    if (Edited != null) Edited(this, EventArgs.Empty);
                }
            }
        }

        private void EditEntityItem_Click(object sender, EventArgs e)
        {
            if (_cur_ent == null) return;
            if (_cur_ent.Type == Entity.EntityType.Person)
                EditPerson();
            else
                EditTrigger();
        }

        private void EditPerson()
        {
            using (PersonForm form = new PersonForm(_cur_ent.Copy(), _base_map.Entities))
            {
                form.AddLayers(_base_map.Layers);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    _base_map.Entities[_base_map.Entities.IndexOf(_cur_ent)] = form.Person;
                    if (Edited != null) Edited(this, EventArgs.Empty);
                }
            }
        }

        private void EditTrigger()
        {
            using (TriggerForm form = new TriggerForm(_cur_ent.Copy()))
            {
                form.AddLayers(_base_map.Layers);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    _base_map.Entities[_base_map.Entities.IndexOf(_cur_ent)] = form.Trigger;
                    if (Edited != null) Edited(this, EventArgs.Empty);
                }
            }
        }

        private void DeleteEntityItem_Click(object sender, EventArgs e)
        {
            if (_cur_ent == null) return;
            if (MessageBox.Show("Are you sure you want to delete this entity?", "Entity Deletion",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                _base_map.Entities.Remove(_cur_ent);
                Invalidate();
                if (Edited != null) Edited(this, EventArgs.Empty);
            }
        }

        private void MapContextMenu_Opening(object sender, CancelEventArgs e)
        {
            bool found = GetEntityAtMouse();
            bool zone = GetZoneAtMouse();
            DeleteEntityItem.Visible = found;
            EditEntityItem.Visible = found;
            CopyEntityItem.Enabled = found;
            PasteEntityItem.Enabled = (!found && PluginData.CopiedEnt != null);
            EditZoneItem.Visible = zone;
            DeleteZoneItem.Visible = zone;
        }

        private void CopyEntityItem_Click(object sender, EventArgs e)
        {
            PluginData.CopiedEnt = _cur_ent;
        }

        private void PasteEntityItem_Click(object sender, EventArgs e)
        {
            if (PluginData.CopiedEnt == null) return;
            Entity ent = PluginData.CopiedEnt.Copy();
            ent.X = (short)(_mouse.X / Zoom + (_base_map.Tileset.TileWidth - 1) / 2);
            ent.Y = (short)(_mouse.Y / Zoom + (_base_map.Tileset.TileHeight - 1) / 2);
            _base_map.Entities.Add(ent);
            if (Edited != null) Edited(this, EventArgs.Empty);
        }

        private void DeleteZoneItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sre you want to delete this zone?", "Delete Zone",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                _base_map.Zones.Remove(_cur_zone);
                _cur_zone = null;
                Invalidate();
                if (Edited != null) Edited(this, EventArgs.Empty);
            }
        }

        private void EditZoneItem_Click(object sender, EventArgs e)
        {
            using (ZoneForm form = new ZoneForm(_cur_zone))
            {
                foreach (Layer l in _base_map.Layers) form.AddString(l.Name);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    _base_map.Zones[_base_map.Zones.IndexOf(_cur_zone)] = form.Zone.Clone();
                    if (Edited != null) Edited(this, EventArgs.Empty);
                }
            }
        }
        #endregion

        private void MapControl_KeyDown(object sender, KeyEventArgs e)
        {
            _ctrl_key = e.Control;
        }

        private void MapControl_KeyUp(object sender, KeyEventArgs e)
        {
            _ctrl_key = e.Control;
        }

        private void hScrollBar_ValueChanged(object sender, EventArgs e)
        {
            if (_move) return;
            _offset.X = -hScrollBar.Value * _tile_w_zoom;
            UpdateLayers();
            Invalidate(false);
        }

        private void vScrollBar_ValueChanged(object sender, EventArgs e)
        {
            if (_move) return;
            _offset.Y = -vScrollBar.Value * _tile_h_zoom;
            UpdateLayers();
            Invalidate(false);
        }

        // In order to redraw regions that come into existance via form resize.
        private void MapControl_Resize(object sender, EventArgs e)
        {
            if (_base_map == null || IsDisposed) return;
            UpdateScrollBars();
            UpdateLayers();
        }
    }
}
