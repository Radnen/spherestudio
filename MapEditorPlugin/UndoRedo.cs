using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sphere.Core;
using Sphere.Core.Editor;
using MapEditPlugin.Components;


namespace MapEditPlugin.UndoRedo
{
    internal struct HistoryTile
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

    internal class LayerPage : HistoryPage
    {
        private List<Layer> _before, _after;
        private byte _start_before, _start_after;
        private MapControl _parent;

        public LayerPage(MapControl parent, List<Layer> before, List<Layer> after, byte start_before, byte start_after)
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

    internal class TileRemovePage : HistoryPage
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

    internal class TileAddPage : HistoryPage
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
            if (_parent.TilesetControl.Selected[0] >= _parent.Map.Tileset.Tiles.Count)
                _parent.TilesetControl.Select((short)(_parent.Map.Tileset.Tiles.Count - 1));
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

    internal class LayerTilesPage : HistoryPage
    {
        short _layer;
        short[,] _tiles_old;
        short[,] _tiles_new;
        MapControl _parent;

        public LayerTilesPage(MapControl parent, short[,] tiles_old, short[,] tiles_new, short layer)
        {
            _layer = layer;
            _parent = parent;
            _tiles_old = tiles_old;
            _tiles_new = tiles_new;
        }

        public override void Undo()
        {
            _parent.BaseMap.Layers[_layer].SetTiles(_tiles_old);
            _parent.RefreshLayers();
        }

        public override void Redo()
        {
            _parent.BaseMap.Layers[_layer].SetTiles(_tiles_new);
            _parent.RefreshLayers();
        }
    }

    internal class TileListPage : HistoryPage
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
}
