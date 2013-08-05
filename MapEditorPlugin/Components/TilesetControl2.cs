using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Sphere.Core;
using Sphere.Core.Editor;
using Sphere.Core.Utility;

namespace MapEditPlugin.Components
{
    public partial class TilesetControl2 : UserControl
    {
        private Tileset _tileset;
        public Tileset Tileset
        {
            get { return _tileset; }
            set
            {
                _zoom = 1;
                _tileset = value;
                if (_tileset != null)
                {
                    _tile_w_zoom = _tileset.TileWidth;
                    _tile_h_zoom = _tileset.TileHeight;
                    UpdateHeight();
                }
            }
        }

        public delegate void TileHandler(short startindex, List<Tile> tiles);
        public delegate void SelectedHandler(List<short> tiles);
        public event SelectedHandler TileSelected;
        public event TileHandler TileRemoved;
        public event TileHandler TileAdded;
        public bool MultiSelect { get; set; }

        private bool _select_paint = false;
        private int _selected_index = 0;
        private int _tile_w_zoom;
        private int _tile_h_zoom;
        private int _zoom = 1;
        private Line _selection = new Line();

        public Rectangle Selection
        {
            get
            {
                Rectangle sel = Line.ToRectangle(_selection);
                sel.Width++; sel.Height++;
                return sel;
            }
        }
        public List<short> Selected { get; set; }
        public bool CanInsert { get; set; }

        public TilesetControl2()
        {
            Selected = new List<short>();
            InitializeComponent();
            CanInsert = true;
        }

        /// <summary>
        /// Resizes or rescales the tileset belonging to this control.
        /// </summary>
        /// <param name="tileWidth">Width of the new tiles.</param>
        /// <param name="tileHeight">Height of the new tiles.</param>
        /// <param name="rescale">Whether or not to rescale along with the resize.</param>
        public void ResizeTileset(short tileWidth, short tileHeight, bool rescale)
        {
            Tileset.ResizeTiles(tileWidth, tileHeight, rescale);
            UpdateTileSize();
        }

        /// <summary>
        /// Call this when the tile sizes change outside of this controls scope.
        /// </summary>
        public void UpdateTileSize()
        {
            _tile_w_zoom = Tileset.TileWidth * _zoom;
            _tile_h_zoom = Tileset.TileHeight * _zoom;
            Invalidate();
        }

        private void TilesetControl2_Paint(object sender, PaintEventArgs e)
        {
            if (Tileset == null) return;

            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            e.Graphics.CompositingQuality = CompositingQuality.HighSpeed;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;

            short index = 0;
            int w = Width - _tile_w_zoom;
            for (int y = 0; y < Height; y += _tile_h_zoom)
            {
                for (int x = 0; x < w; x += _tile_w_zoom)
                {
                    if (index < Tileset.Tiles.Count)
                        e.Graphics.DrawImage(Tileset.Tiles[index].Graphic, x, y, _tile_w_zoom, _tile_h_zoom);
                    if (Selected.Contains(index))
                        e.Graphics.DrawRectangle(Pens.Magenta, x, y, _tile_w_zoom, _tile_h_zoom);
                    index++;
                }
            }
        }

        public void Select(short tile)
        {
            if (tile < -1 || tile >= Tileset.Tiles.Count) return;
            if (tile == -1)
            {
                Selected.Clear();
                Selected.Add(-1);
                _selection.Start = _selection.End;
            }
            else
            {
                _selected_index = tile;
                int x = (tile % (Width / _tile_w_zoom));
                int y = (tile / (Height / _tile_h_zoom));
                _selection.Start = new Point(x, y);
                _selection.End = _selection.Start;
                Selected.Clear();
                Selected.Add(tile);
            }

            Invalidate();
        }

        /// <summary>
        /// If it returns true, stop zooming.
        /// </summary>
        public bool ZoomIn()
        {
            if (_zoom != 8)
            {
                _zoom *= 2;
                _tile_w_zoom = _tileset.TileWidth * _zoom;
                _tile_h_zoom = _tileset.TileHeight * _zoom;
                UpdateHeight();
            }
            return _zoom == 8;
        }

        /// <summary>
        /// If it returns true, stop zooming.
        /// </summary>
        public bool ZoomOut()
        {
            if (_zoom != 1)
            {
                _zoom /= 2;
                _tile_w_zoom = _tileset.TileWidth * _zoom;
                _tile_h_zoom = _tileset.TileHeight * _zoom;
                UpdateHeight();
            }
            return _zoom == 1;
        }

        private void TilesetControl2_MouseDown(object sender, MouseEventArgs e)
        {
            int x = e.X / _tile_w_zoom;
            int y = e.Y / _tile_h_zoom;
            int w = Width / _tile_w_zoom;
            short tile = (short)(x + y * w);

            if (tile < 0 || tile >= Tileset.Tiles.Count) return;

            if (e.Button == MouseButtons.Left) _select_paint = true;
            _selection.Start = new Point(x, y);
            _selection.End = _selection.Start;
            SelectTiles();
            Invalidate();
        }

        private void TilesetControl2_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_select_paint || !MultiSelect) return;
            int x = e.X / _tile_w_zoom;
            int y = e.Y / _tile_h_zoom;
            _selection.End = new Point(x, y);
            SelectTiles();
            Invalidate();
        }

        private void TilesetControl2_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                TileContextStrip.Show(this, e.Location);
            else if (e.Button == MouseButtons.Left)
            {
                _select_paint = false;
                SelectTiles();
                Invalidate();
                if (TileSelected != null) TileSelected(Selected);
            }
        }

        private void SelectTiles()
        {
            Rectangle r = Selection;
            int w = Width / _tile_w_zoom;
            Selected.Clear();
            for (int y = 0; y < r.Height; ++y)
            {
                for (int x = 0; x < r.Width; ++x)
                {
                    short tile = (short)((r.X + x) + (r.Y + y) * w);
                    if (tile < 0 || tile > Tileset.Tiles.Count - 1) tile = -1;
                    Selected.Add(tile);
                }
            }
        }

        private void zoomInItem_Click(object sender, EventArgs e)
        {
            if (ZoomIn()) zoomInItem.Enabled = false;
            else zoomOutItem.Enabled = true;
        }

        private void zoomOutItem_Click(object sender, EventArgs e)
        {
            if (ZoomOut()) zoomOutItem.Enabled = false;
            else zoomInItem.Enabled = true;
        }

        private void insertItem_Click(object sender, EventArgs e)
        {
            AddTiles(Selected[0], 1);
        }

        private void addItem_Click(object sender, EventArgs e)
        {
            AddTiles((short)_tileset.Tiles.Count, 1);
        }

        private void appendTilesItem_Click(object sender, EventArgs e)
        {
            using (StringInputForm form = new StringInputForm())
            {
                form.NumOnly = true;
                if (form.ShowDialog() == DialogResult.OK)
                    AddTiles((short)_tileset.Tiles.Count, short.Parse(form.Input));
            }
        }

        private void removeItem_Click(object sender, EventArgs e)
        {
            RemoveTiles(1);
        }

        private void removeTilesItem_Click(object sender, EventArgs e)
        {
            using (StringInputForm form = new StringInputForm())
            {
                form.NumOnly = true;
                if (form.ShowDialog() == DialogResult.OK)
                    RemoveTiles(int.Parse(form.Input));
            }
        }

        private void TileContextStrip_Opening(object sender, CancelEventArgs e)
        {
            bool onlytile = _tileset.Tiles.Count == 1;
            removeTilesItem.Enabled = removeItem.Enabled = !onlytile;

            insertItem.Visible = CanInsert;
        }

        public void UpdateHeight()
        {
            if (_tile_w_zoom == 0) return;
            int w = Width / _tile_w_zoom;
            if (w == 0) return;
            Height = ((_tileset.Tiles.Count / w) + 2) * _tile_h_zoom;
        }

        private void TilesetControl2_Resize(object sender, EventArgs e)
        {
            UpdateHeight();
        }

        private void RemoveTiles(int count)
        {
            if (Selected.Count == 0) return;
            int amount = Math.Min(count, _tileset.Tiles.Count - Selected[0]);
            List<Tile> removed = new List<Tile>(amount);
            for (int i = 0; i < amount; ++i) removed.Add(_tileset.Tiles[Selected[0] + i]);
            _tileset.Tiles.RemoveRange(Selected[0], amount);
            UpdateHeight();
            Invalidate();
            if (TileRemoved != null) TileRemoved(Selected[0], removed);
        }

        private void AddTiles(short start, short count)
        {
            List<Tile> added = new List<Tile>(count);
            Tile t;
            for (short i = 0; i < count; ++i)
            {
                t = new Tile(_tileset.TileWidth, _tileset.TileHeight);
                _tileset.Tiles.Insert(start + i, t);
                added.Add(t);
            }
            UpdateHeight();
            Invalidate();
            if (TileAdded != null) TileAdded(start, added);
        }

        /// <summary>
        /// Compiles the Selected list into a single image.
        /// </summary>
        /// <returns>A System.Drawing.Bitmap of the selected area.</returns>
        public Bitmap GetCompiledImage()
        {
            int w = Selection.Width * _tileset.TileWidth;
            int h = Selection.Height * _tileset.TileHeight;
            int i = 0;
            Bitmap image = new Bitmap(w, h, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            using (Graphics g = Graphics.FromImage(image))
            {
                g.InterpolationMode = InterpolationMode.NearestNeighbor;
                for (int y = 0; y < image.Height; y += _tileset.TileHeight)
                {
                    for (int x = 0; x < image.Width; x += _tileset.TileWidth)
                    {
                        if (Selected[i] < 0)
                        {
                            g.FillRectangle(Brushes.Gray, new Rectangle(x, y, _tileset.TileWidth, _tileset.TileHeight));
                        }
                        else
                        {
                            g.DrawImageUnscaled(_tileset.Tiles[Selected[i]].Graphic, x, y);
                        }
                        i++;
                    }
                }
            }
            return image;
        }

        /// <summary>
        /// Sets the images of the selected tiles;
        /// </summary>
        /// <param name="images"></param>
        public void SetImages(List<Bitmap> images)
        {
            for (int i = 0; i < images.Count; ++i)
            {
                if (i >= Selected.Count || Selected[i] < 0) continue;
                _tileset.Tiles[Selected[i]].Graphic = images[i];
            }
            Invalidate();
        }
    }
}