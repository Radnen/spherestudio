using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Sphere_Editor.SphereObjects;

namespace Sphere_Editor.EditorComponents
{
    public partial class TilesetControl2 : UserControl
    {
        private Tileset2 _tileset;
        public Tileset2 Tileset
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
        public delegate void SelectedHandler(short tile);
        public event SelectedHandler TileSelected;
        public event TileHandler TileRemoved;
        public event TileHandler TileAdded;

        private int _tile_w_zoom;
        private int _tile_h_zoom;
        private int _zoom = 1;

        public short Selected { get; set; }
        public bool CanInsert { get; set; }

        public TilesetControl2()
        {
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

            int index = 0, w = Width - _tile_w_zoom;
            for (int y = 0; y < Height; y += _tile_h_zoom)
            {
                for (int x = 0; x < w; x += _tile_w_zoom)
                {
                    if (index < Tileset.Tiles.Count)
                        e.Graphics.DrawImage(Tileset.Tiles[index].Graphic, x, y, _tile_w_zoom, _tile_h_zoom);
                    if (index == Selected)
                        e.Graphics.DrawRectangle(Pens.Magenta, x, y, _tile_w_zoom, _tile_h_zoom);
                    index++;
                }
            }
        }

        public void Select(short tile)
        {
            if (tile >= Tileset.Tiles.Count) return;
            Selected = tile;
            Invalidate();
            if (TileSelected != null) TileSelected(tile);
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

            if (tile >= Tileset.Tiles.Count) return;

            Selected = tile;
            Invalidate();
            if (TileSelected != null) TileSelected(Selected);
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
            AddTiles(Selected, 1);
        }

        private void addItem_Click(object sender, EventArgs e)
        {
            AddTiles((short)_tileset.Tiles.Count, 1);
        }

        private void appendTilesItem_Click(object sender, EventArgs e)
        {
            using (Sphere_Editor.Forms.StringInputForm form = new Forms.StringInputForm())
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
            using (Sphere_Editor.Forms.StringInputForm form = new Forms.StringInputForm())
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

        private void TilesetControl2_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
                TileContextStrip.Show(this, e.Location);
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
            int amount = Math.Min(count, _tileset.Tiles.Count - Selected);
            List<Tile> removed = new List<Tile>(amount);
            for (int i = 0; i < amount; ++i) removed.Add(_tileset.Tiles[Selected + i]);
            _tileset.Tiles.RemoveRange(Selected, amount);
            UpdateHeight();
            Invalidate();
            if (TileRemoved != null) TileRemoved(Selected, removed);
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
    }
}