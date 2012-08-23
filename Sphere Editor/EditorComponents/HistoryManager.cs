using System;
using System.Collections.Generic;
using System.Text;
using Sphere_Editor.SphereObjects;
using Sphere_Editor.SubEditors;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Sphere_Editor.EditorComponents
{
    public class HistoryManager : IDisposable
    {
        int _history_pos = 0;
        List<HistoryPage> _pages;

        public bool CanUndo { get { return _history_pos != _pages.Count; } }
        public bool CanRedo { get { return _history_pos != 0; } }

        public HistoryManager()
        {
            _pages = new List<HistoryPage>();
        }

        public void PushPage(HistoryPage page)
        {
            for (int i = 0; i < _history_pos; ++i) _pages[i].Dispose();
            _pages.RemoveRange(0, _history_pos);

            _pages.Insert(0, page);
            _history_pos = 0;
        }

        /// <summary>
        /// Returns true if an undo has been successfully carried out.
        /// </summary>
        public bool Undo()
        {
            if (!CanUndo) return false;
            _pages[_history_pos].Undo();
            _history_pos++;
            return true;
        }

        /// <summary>
        /// Returns true if a redo has been successfully carried out.
        /// </summary>
        public bool Redo()
        {
            if (!CanRedo) return false;
            _history_pos--;
            _pages[_history_pos].Redo();
            return true;
        }

        public void Dispose()
        {
            for (int i = 0; i < _pages.Count; ++i)
                _pages[i].Dispose();
        }

        public void Clear()
        {
            Dispose();
            _pages.Clear();
            _history_pos = 0;
        }
    }

    public struct HistoryTile
    {
        public int x;
        public int y;
        public short older;
        public short newer;

        public HistoryTile(int x, int y, short older, short newer)
        {
            this.x = x;
            this.y = y;
            this.older = older;
            this.newer = newer;
        }
    }

    public abstract class HistoryPage : IDisposable
    {
        public abstract void Undo();
        public abstract void Redo();

        public virtual void Dispose() { } // not all pages dispose
    }

    public class LayerPage : HistoryPage
    {
        private List<Layer2> _before, _after;
        private byte _start_before, _start_after;
        private MapControl _parent;

        public LayerPage(MapControl parent, List<Layer2> before, List<Layer2> after, byte start_before, byte start_after)
        {
            _before = before;
            _after = after;
            _start_before = start_before;
            _start_after = start_after;
            _parent = parent;
        }

        public override void Undo()
        {
            _parent.BaseMap.Layers = _before;
            _parent.BaseMap.StartLayer = _start_before;
            _parent.RefreshLayers();
        }

        public override void Redo()
        {
            _parent.BaseMap.Layers = _after;
            _parent.BaseMap.StartLayer = _start_after;
            _parent.RefreshLayers();
        }
    }

    public class TileRemovePage : HistoryPage
    {
        short _startindex;
        List<Tile> _tiles;
        List<short[,]> _layertiles;
        MapEditor _parent;

        public TileRemovePage(MapEditor parent, List<Tile> tiles, short startindex, List<short[,]> layertiles)
        {
            _tiles = tiles;
            _parent = parent;
            _startindex = startindex;
            _layertiles = layertiles;
        }

        public override void Undo()
        {
            _parent.Map.Tileset.Tiles.InsertRange(_startindex, _tiles);

            for (int i = 0; i < _layertiles.Count; ++i)
                _parent.Map.Layers[i].SetTiles(_layertiles[i]);

            _parent.MapControl.RefreshLayers();
            _parent.Invalidate(true);
        }

        public override void Redo()
        {
            _parent.Map.Tileset.Tiles.RemoveRange(_startindex, _tiles.Count);

            for (int i = 0; i < _layertiles.Count; ++i)
                _parent.Map.Layers[i].AdjustTiles(_startindex, (short)-_tiles.Count);

            _parent.MapControl.RefreshLayers();
            _parent.Invalidate(true);
        }
    }

    public class TileAddPage : HistoryPage
    {
        MapEditor _parent;
        List<Tile> _added;
        List<short[,]> _layertiles;
        short _startindex;

        public TileAddPage(MapEditor parent, List<Tile> added, short startindex, List<short[,]> layertiles)
        {
            _parent = parent;
            _added = added;
            _startindex = startindex;
            _layertiles = layertiles;
        }

        public override void Undo()
        {
            _parent.Map.Tileset.Tiles.RemoveRange(_startindex, _added.Count);

            for (int i = 0; i < _layertiles.Count; ++i)
                _parent.Map.Layers[i].AdjustTiles(_startindex, (short)-_added.Count);

            _parent.MapControl.RefreshLayers();
            if (_parent.TilesetControl.Selected >= _parent.Map.Tileset.Tiles.Count)
                _parent.TilesetControl.Selected = (short)(_parent.Map.Tileset.Tiles.Count - 1);
            _parent.Invalidate(true);
        }

        public override void Redo()
        {
            _parent.Map.Tileset.Tiles.InsertRange(_startindex, _added);

            for (int i = 0; i < _layertiles.Count; ++i)
            {
                _parent.Map.Layers[i].SetTiles(_layertiles[i]);
                _parent.Map.Layers[i].AdjustTiles((short)(_startindex - 1), (short)_added.Count);
            }

            _parent.MapControl.RefreshLayers();
            _parent.Invalidate(true);
        }
    }

    public class TileListPage : HistoryPage
    {
        List<HistoryTile> _tiles;
        MapControl _parent;
        short _layer;

        public TileListPage(MapControl parent, List<HistoryTile> tiles, short layer)
        {
            _tiles = tiles;
            _parent = parent;
            _layer = layer;
        }

        public override void Undo()
        {
            foreach (HistoryTile ht in _tiles)
                _parent.DrawTile(ht.x, ht.y, _layer, ht.older);
            _parent.CurrentLayer = _layer;
        }

        public override void Redo()
        {
            foreach (HistoryTile ht in _tiles)
                _parent.DrawTile(ht.x, ht.y, _layer, ht.newer);
            _parent.CurrentLayer = _layer;
        }
    }

    public class ImageResizePage : HistoryPage
    {
        Bitmap _before, _after;
        ImageEditControl2 _parent;

        public ImageResizePage(ImageEditControl2 parent, Image before, Image after)
        {
            _parent = parent;
            _before = new Bitmap(before);
            _after = new Bitmap(after);
        }

        public override void Undo()
        {
            _parent.SetImage(_before);
        }

        public override void Redo()
        {
            _parent.SetImage(_after);
        }

        public override void Dispose()
        {
            _before.Dispose();
            _after.Dispose();
        }
    }

    public class ImagePage : HistoryPage
    {
        Point _pos;
        Image _before, _after;
        ImageEditControl2 _parent;

        public ImagePage(ImageEditControl2 parent, Point pos, Image before, Image after)
        {
            _pos = pos;
            _before = before;
            _after = after;
            _parent = parent;
        }

        public override void Undo()
        {
            using (Graphics g = Graphics.FromImage(_parent.EditImage))
            {
                g.PixelOffsetMode = PixelOffsetMode.Half;
                g.InterpolationMode = InterpolationMode.NearestNeighbor;
                g.CompositingQuality = CompositingQuality.HighSpeed;
                g.CompositingMode = CompositingMode.SourceCopy;
                g.DrawImage(_before, _pos);
            }
        }

        public override void Redo()
        {
            using (Graphics g = Graphics.FromImage(_parent.EditImage))
            {
                g.PixelOffsetMode = PixelOffsetMode.Half;
                g.InterpolationMode = InterpolationMode.NearestNeighbor;
                g.CompositingQuality = CompositingQuality.HighSpeed;
                g.CompositingMode = CompositingMode.SourceCopy;
                g.DrawImage(_after, _pos);
            }
        }

        public override void  Dispose()
        {
            _after.Dispose();
            _before.Dispose();
        }
    }
}