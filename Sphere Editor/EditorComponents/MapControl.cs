using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Sphere_Editor.SphereObjects;
using Sphere_Editor.Forms;

namespace Sphere_Editor.EditorComponents
{
    public partial class MapControl : UserControl
    {
        #region Attributes
        public short Zoom { get; private set; }
        private int _vw, _vh;
        private Point _mouse;
        private Point _last_mouse;
        private int _tile_w_zoom;
        private int _tile_h_zoom;
        private bool _ctrl_key, _can_copy = true;
        public event EventHandler PropChanged;

        private bool _paint = false, _move = false;
        private Point _anchor, _offset;
        private static Brush _rect_brush = new SolidBrush(Color.FromArgb(125, Color.Blue));
        public List<GraphicalLayer> GraphicLayers { get; private set; }
        private Zone2 _temp_zone = new Zone2();

        public Point MapPixel { get; set; }
        public short CurrentTile { get; set; }
        public short CurrentLayer { get; set; }
        public bool ShowCameraBounds { get; set; }
        public Point Tile
        {
            get
            {
                Point t = new Point();
                t.X = _mouse.X / _tile_w_zoom;
                t.Y = _mouse.Y / _tile_h_zoom;
                return t;
            }
        }

        public event EventHandler Edited;
        public bool CanZoomIn { get { return Zoom != 4; } }
        public bool CanZoomOut { get { return Zoom != 1; } }

        private Entity _cur_ent = null;
        private Zone2 _cur_zone = null;

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
                    _tile_h_zoom = value.Tileset.TileWidth;
                    _tile_w_zoom = value.Tileset.TileHeight;
                    _vw = value.Width * _tile_w_zoom;
                    _vh = value.Height * _tile_h_zoom;
                    UpdateScrollBars();
                    GraphicLayers = new List<GraphicalLayer>(value.Layers.Count);

                    for (int i = 0; i < value.Layers.Count; ++i)
                        GraphicLayers.Add(new GraphicalLayer(value.Layers[i], value.Tileset.TileWidth, value.Tileset.TileHeight));
                }
            }
        }
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
            MapPixel = new Point(0, 0);
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            MouseWheel += new MouseEventHandler(MapControl_MouseWheel);
            hScrollBar.LargeChange = vScrollBar.LargeChange = 1;
        }

        public void SetLayers(List<Layer2> new_layers, byte new_start)
        {
            PushLayerPage(new_layers, new_start);
            _base_map.Layers = new_layers;
            _base_map.StartLayer = new_start;
            RefreshLayers();
        }

        private void UpdateLayers()
        {
            for (int i = 0; i < GraphicLayers.Count; ++i)
                GraphicLayers[i].Update(ref _offset, Size, _base_map.Tileset);
            Invalidate();
        }

        public void RefreshLayers()
        {
            if (_base_map == null) return;
            if (IsDisposed) return;
            for (int i = 0; i < GraphicLayers.Count; ++i)
                GraphicLayers[i].Refresh(_base_map.Layers[i], _base_map.Tileset);
            Invalidate();
        }

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

        // in case it ever gets lost you can quickly recenter it.
        public void CenterMap()
        {
            _offset.X = Width / 2 - _vw / 2;
            _offset.Y = Height / 2 - _vh / 2;
            UpdateScrollBars();
            UpdateLayers();
        }

        private void CalcMouse(Point mouse)
        {
            _mouse.X = ((mouse.X - _offset.X) / _tile_w_zoom) * _tile_w_zoom;
            _mouse.Y = ((mouse.Y - _offset.Y) / _tile_h_zoom) * _tile_h_zoom;
            MapPixel = new Point((mouse.X - _offset.X) / Zoom, (mouse.Y - _offset.Y) / Zoom);
        }

        private void MapControl_Paint(object sender, PaintEventArgs e)
        {
            if (BaseMap == null) return;
            e.Graphics.CompositingQuality = CompositingQuality.HighSpeed;
            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;

            for (int i = 0; i < GraphicLayers.Count; ++i)
            {
                GraphicLayers[i].Draw(e.Graphics, ref _offset);
                if (i == CurrentLayer && _paint && (Tool == MapTool.Line || Tool == MapTool.Rectangle))
                    DrawTool(e.Graphics);
            }

            foreach (Zone2 zone in _base_map.Zones)
            {
                zone.Draw(e.Graphics, _offset, Tool == MapTool.Zone ? 0 : -1, Zoom);
            }

            foreach (Entity ent in _base_map.Entities)
            {
                ent.Draw(e.Graphics, _base_map.Tileset.TileWidth, _base_map.Tileset.TileHeight, ref _offset, Zoom);
            }

            if (_paint && Tool == MapTool.Zone) DrawTool(e.Graphics);

            if (_mouse.X >= 0 && _mouse.Y >= 0 && _mouse.X < _vw && _mouse.Y < _vh)
            {
                int x = _offset.X + _mouse.X;
                int y = _offset.Y + _mouse.Y;
                e.Graphics.DrawRectangle(Pens.Yellow, x, y, _tile_w_zoom, _tile_h_zoom);
            }
            e.Graphics.DrawRectangle(Pens.Black, _offset.X, _offset.Y, _vw, _vh);

            if (ShowCameraBounds) DrawCameraBounds(e.Graphics);
        }

        private void DrawCameraBounds(Graphics g)
        {
            int sw = int.Parse(Global.CurrentProject.Width);
            int sh = int.Parse(Global.CurrentProject.Height);
            int x = (sw / 2) * Zoom;
            int y = (sh / 2) * Zoom;
            int w = _vw - sw * Zoom;
            int h = _vh - sh * Zoom;
            g.DrawRectangle(Pens.Magenta, _offset.X + x, _offset.Y + y, w, h);
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

        public Layer2 AddLayer()
        {
            Layer2 layer = new Layer2();
            layer.CreateNew((short)_base_map.Width, (short)_base_map.Height);
            _base_map.Layers.Add(layer);
            GraphicalLayer g_layer = new GraphicalLayer(layer, _base_map.Tileset.TileWidth, _base_map.Tileset.TileHeight);
            g_layer.SetZoom(Zoom);
            GraphicLayers.Add(g_layer);
            UpdateLayers();
            return layer;
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
            return false;
        }

        private bool GetZoneAtMouse()
        {
            foreach (Zone2 zone in _base_map.Zones)
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
            Invalidate(new Rectangle(_offset.X + _mouse.X - 1, _offset.Y + _mouse.Y - 1, _tile_w_zoom + 2, _tile_h_zoom + 2));
            Invalidate(new Rectangle(_offset.X + _last_mouse.X - 1, _offset.Y + _last_mouse.Y - 1, _tile_w_zoom + 2, _tile_h_zoom + 2));
        }

        // set tile will also update the internal history list
        private void SetTile(int x, int y)
        {
            short older = _base_map.Layers[CurrentLayer].GetTile(x, y);
            if (older == -1 || older == CurrentTile) return;

            HistoryTile tile = new HistoryTile(x, y, older, CurrentTile);
            _base_map.Layers[CurrentLayer].SetTile(x, y, CurrentTile);
            GraphicLayers[CurrentLayer].SetTile(x, y, _base_map.Tileset.Tiles[CurrentTile].Graphic);
            _h_tiles.Add(tile);
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

            if (_mouse != _last_mouse)
            {
                if (_paint)
                {
                    if (Tool == MapTool.Pen)
                    {
                        int x = _mouse.X / _tile_w_zoom;
                        int y = _mouse.Y / _tile_h_zoom;
                        SetTile(x, y);
                    }
                    else if (Tool == MapTool.Entity && _cur_ent != null &&
                        _cur_ent.Layer == CurrentLayer)
                    {
                        if (_ctrl_key && _can_copy) // copy - move:
                        {
                            Entity ent = _cur_ent.Copy();
                            if (ent.Type == 1) ent.FigureOutName(_base_map.Entities);
                            _base_map.Entities.Add(ent);
                            _can_copy = false;
                            _cur_ent = ent;
                        }
                        _cur_ent.X = (short)(_mouse.X / Zoom + (_base_map.Tileset.TileWidth - 1) / 2);
                        _cur_ent.Y = (short)(_mouse.Y / Zoom + (_base_map.Tileset.TileHeight - 1) / 2);
                    }
                    else if (Tool != MapTool.FloodFill) Invalidate();
                }

                InvalidateCursor();
                _last_mouse = _mouse;
            }
        }

        private void MapControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                CalcMouse(e.Location);

                if (Tool == MapTool.Pen)
                    SetTile(_mouse.X / _tile_w_zoom, _mouse.Y / _tile_h_zoom);
                else if (Tool == MapTool.Entity)
                    GetEntityAtMouse();
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
            if (_h_tiles.Count > 0)
            {
                TileListPage page = new TileListPage(this, _h_tiles, CurrentLayer);
                _h_manager.PushPage(page);
                _h_tiles = new List<HistoryTile>();
            }
        }

        private void PushLayerPage(List<Layer2> new_layers, byte new_start)
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
                    _temp_zone = new Zone2();
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
            _base_map.StartX = (short)_mouse.X;
            _base_map.StartY = (short)_mouse.Y;
            if (PropChanged != null) PropChanged(this, EventArgs.Empty);
        }

        private void PersonItem_Click(object sender, EventArgs e)
        {
            using (PersonForm form = new PersonForm(_base_map.Entities))
            {
                foreach (Layer2 lay in _base_map.Layers) form.AddString(lay.Name);
                form.SelectedIndex = CurrentLayer;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    form.Person.X = (short)(_mouse.X / Zoom + (_base_map.Tileset.TileWidth - 1) / 2);
                    form.Person.Y = (short)(_mouse.Y / Zoom + (_base_map.Tileset.TileHeight - 1) / 2);
                    _base_map.Entities.Add(form.Person);
                    form.Person.Visible = _base_map.Layers[CurrentLayer].Visible;
                    if (Edited != null) Edited(this, EventArgs.Empty);
                }
            }
        }

        private void TriggerItem_Click(object sender, EventArgs e)
        {
            using (TriggerForm form = new TriggerForm())
            {
                foreach (Layer2 lay in _base_map.Layers) form.AddString(lay.Name);
                form.SelectedIndex = CurrentLayer;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    form.Trigger.X = (short)(_mouse.X / Zoom + (_base_map.Tileset.TileWidth - 1) / 2 - 1);
                    form.Trigger.Y = (short)(_mouse.Y / Zoom + (_base_map.Tileset.TileHeight - 1) / 2 - 1);
                    _base_map.Entities.Add(form.Trigger);
                    form.Trigger.Visible = _base_map.Layers[CurrentLayer].Visible;
                    if (Edited != null) Edited(this, EventArgs.Empty);
                }
            }
        }

        private void EditEntityItem_Click(object sender, EventArgs e)
        {
            if (_cur_ent == null) return;
            if (_cur_ent.Type == 1)
            {
                using (PersonForm form = new PersonForm(_cur_ent.Copy(), _base_map.Entities))
                {
                    foreach (Layer2 lay in _base_map.Layers) form.AddString(lay.Name);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        _base_map.Entities[_base_map.Entities.IndexOf(_cur_ent)] = form.Person;
                        if (Edited != null) Edited(this, EventArgs.Empty);
                    }
                }
            }
            else
            {
                using (TriggerForm form = new TriggerForm(_cur_ent.Copy()))
                {
                    foreach (Layer2 lay in _base_map.Layers) form.AddString(lay.Name);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        _base_map.Entities[_base_map.Entities.IndexOf(_cur_ent)] = form.Trigger;
                        if (Edited != null) Edited(this, EventArgs.Empty);
                    }
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
            PasteEntityItem.Enabled = (!found && Global.CopiedEnt != null);
            EditZoneItem.Visible = zone;
            DeleteZoneItem.Visible = zone;
        }

        private void CopyEntityItem_Click(object sender, EventArgs e)
        {
            Global.CopiedEnt = _cur_ent;
        }

        private void PasteEntityItem_Click(object sender, EventArgs e)
        {
            if (Global.CopiedEnt == null) return;
            Entity ent = Global.CopiedEnt.Copy();
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
                foreach (Layer2 l in _base_map.Layers) form.AddString(l.Name);
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

        private void MapControl_Resize(object sender, EventArgs e)
        {
            if (_base_map == null) return;
            if (IsDisposed) return;
            UpdateScrollBars();
            UpdateLayers();
        }
    }
}
