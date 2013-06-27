using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using Sphere.Core;

namespace Sphere_Editor.EditorComponents
{
    public class GraphicalLayer : IDisposable
    {
        #region internal layercell class
        private class LayerCell
        {
            private int _tile_w, _tile_h;
            private int _tile_w_z, _tile_h_z;
            private int _zoom = 1;
            private int _vw, _vh;
            
            public Point Offset { get; private set; }
            public Bitmap Image { get; private set; }
            private Graphics _canvas;

            public bool Visible { get { return _canvas != null; } }

            public LayerCell(Point offset, int tile_width, int tile_height)
            {
                Offset = offset;
                _tile_w = _tile_w_z = tile_width;
                _tile_h = _tile_h_z = tile_height;
                _vw = _mul * tile_width;
                _vh = _mul * tile_height;
            }

            public void Allocate(Layer layer, Tileset tileset)
            {
                if (_canvas != null) return;

                Image = new Bitmap(_mul * _tile_w, _mul * _tile_h, PixelFormat.Format32bppPArgb);
                _canvas = Graphics.FromImage(Image);
                _canvas.CompositingMode = CompositingMode.SourceCopy;
                _canvas.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixel;
                _canvas.SmoothingMode = SmoothingMode.None;
                _canvas.CompositingQuality = CompositingQuality.HighSpeed;
                _canvas.InterpolationMode = InterpolationMode.NearestNeighbor;

                Redraw(layer, tileset);
            }

            public void Redraw(Layer layer, Tileset tileset)
            {
                if (_canvas == null) return;

                int tile, tx, ty;
                for (int x = 0; x < _mul; ++x)
                {
                    tx = x * _tile_w;
                    for (int y = 0; y < _mul; ++y)
                    {
                        tile = layer.GetTile(x + Offset.X, y + Offset.Y);
                        if (tile < 0) continue;

                        ty = y * _tile_h;
                        _canvas.DrawImageUnscaled(tileset.Tiles[tile].Graphic, tx, ty);
                    }
                }
            }

            public void Deallocate()
            {
                if (_canvas == null) return;
                Image.Dispose();
                _canvas.Dispose();
                Image = null;
                _canvas = null;
            }

            public void DrawTile(int x, int y, Bitmap img)
            {
                if (_canvas == null) return;
                x -= Offset.X;
                y -= Offset.Y;
                
                if (x < 0 || x >= _mul || y < 0 || y >= _mul) return;

                x = x * _tile_w;
                y = y * _tile_h;

                _canvas.DrawImageUnscaled(img, x, y);
            }

            public void Draw(Graphics map, ref Point offset)
            {
                if (_canvas == null) return;

                int x = Offset.X * _tile_w_z + offset.X;
                int y = Offset.Y * _tile_h_z + offset.Y;
                
                map.DrawImage(Image, x, y, _vw, _vh);
            }

            public void SetZoom(int zoom)
            {
                _zoom = zoom;
                _tile_w_z = _tile_w * _zoom;
                _tile_h_z = _tile_h * _zoom;
                _vw = _mul * _tile_w_z;
                _vh = _mul * _tile_h_z;
            }
        }
        #endregion

        public Layer TargetLayer { get; private set; }
        private int _tile_w, _tile_h, _width;
        private static int _mul = 10;
        private LayerCell[] _cells;
        private int _zoom = 1;

        public GraphicalLayer(Layer target, int tile_width, int tile_height)
        {
            TargetLayer = target;
            Resize(tile_width, tile_height);
        }

        public void Resize(int tile_width, int tile_height)
        {
            int w = (TargetLayer.Width / _mul) + 1;
            int h = (TargetLayer.Height / _mul) + 1;

            Dispose();

            _cells = new LayerCell[w * h];
            _width = w;

            int index = 0;
            Point offset = new Point();
            for (int y = 0; y < h; y++)
            {
                offset.Y = y * _mul;
                for (int x = 0; x < w; x++)
                {
                    offset.X = x * _mul;
                    _cells[index] = new LayerCell(offset, tile_width, tile_height);
                    index++;
                }
            }

            _tile_w = tile_width;
            _tile_h = tile_height;
        }

        public void Refresh(Tileset tileset)
        {
            if (tileset.IsDisposed) return;
            for (int i = 0; i < _cells.Length; ++i) _cells[i].Redraw(TargetLayer, tileset);
        }

        public void Refresh(Layer target, Tileset tileset, bool shownums = false)
        {
            if (tileset.IsDisposed) return;

            TargetLayer = target;
            for (int i = 0; i < _cells.Length; ++i) _cells[i].Redraw(target, tileset);
        }

        // determines which cells to load up:
        public void Update(ref Point offset, Size bounds, Tileset tileset)
        {
            if (tileset.IsDisposed) return;

            int cell_x = _tile_w * _zoom, cell_y = _tile_h * _zoom;
            int size = _mul * _tile_w * _zoom;
            foreach (LayerCell cell in _cells)
            {
                int x = cell.Offset.X * cell_x + offset.X;
                int y = cell.Offset.Y * cell_y + offset.Y;

                if (x < -size || y < -size || x > bounds.Width || y > bounds.Height)
                    cell.Deallocate();
                else
                    cell.Allocate(TargetLayer, tileset);
            }
        }

        public void Draw(Graphics map, ref Point offset)
        {
            if (!TargetLayer.Visible) return;
            
            for (int i = 0; i < _cells.Length; ++i) { _cells[i].Draw(map, ref offset); }

            for (int j = 0; j < TargetLayer.Segments.Count; ++j)
                TargetLayer.Segments[j].Draw(map, ref offset, _zoom);
        }

        public void SetZoom(int zoom)
        {
            _zoom = zoom;
            for (int i = 0; i < _cells.Length; ++i) { _cells[i].SetZoom(_zoom); }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool _disposed;
        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_cells != null)
                    {
                        for (int i = 0; i < _cells.Length; ++i)
                            _cells[i].Deallocate();
                    }
                }

                _cells = null;
            }
            _disposed = true;
        }

        public void SetTile(int x, int y, Bitmap bitmap)
        {
            int cx = x / _mul;
            int cy = y / _mul;
            int index = cx + cy * _width;
            if (cx < 0 || cy < 0 || index > _cells.Length) return;
            _cells[index].DrawTile(x, y, bitmap);
        }
    }
}
