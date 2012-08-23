using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Sphere_Editor.SphereObjects;
using Sphere_Editor.EditorComponents;
using WeifenLuo.WinFormsUI.Docking;

namespace Sphere_Editor.SubEditors
{
    public partial class MapEditor : EditorObject
    {
        #region attributes
        private string _filename;
        private DockContent _map_content;
        private DockContent _draw_content;
        private DockContent _tile_content;
        private DockContent _layer_content;
        private DockContent _tileset_content;
        private DockPanel _main_panel;
        public Map Map { get { return MapControl.BaseMap; } }
        #endregion

        public MapEditor()
        {
            InitializeComponent();
            InitializeDocking();
            TileEditor.Tileset = TilesetControl;
        }

        #region docking
        public void InitializeDocking()
        {
            if (!Global.CurrentEditor.UseDockForm) return;

            Controls.Remove(mapSplitter);
            Controls.Remove(SplitContainer);
            Controls.Remove(splitContainer1);
            Controls.Remove(EditorTabs);

            _map_content = new DockContent();
            _map_content.Controls.Add(MapToolContainer);
            _map_content.Text = "Map Editor";
            _map_content.DockAreas = DockAreas.DockBottom | DockAreas.Document | DockAreas.DockTop;
            _map_content.DockHandler.CloseButtonVisible = false;

            _draw_content = new DockContent();
            _draw_content.Controls.Add(TileDrawer);
            _draw_content.Text = "Tile Image Editor";
            _draw_content.DockAreas = DockAreas.DockBottom | DockAreas.DockTop | DockAreas.Document;
            _draw_content.DockHandler.CloseButtonVisible = false;

            _tileset_content = new DockContent();
            _tileset_content.Controls.Add(TilesetPanel);
            TilesetControl.Width = TilesetPanel.Width - 2;
            _tileset_content.Text = "Tileset";
            _tileset_content.DockAreas = DockAreas.DockRight | DockAreas.DockLeft;
            _tileset_content.DockHandler.CloseButtonVisible = false;
            _tileset_content.AutoScroll = true;

            _tile_content = new DockContent();
            _tile_content.Controls.Add(TileEditor);
            _tile_content.Text = "Tile Properties";
            _tile_content.DockAreas = DockAreas.DockBottom | DockAreas.DockTop | DockAreas.Document;
            _tile_content.DockHandler.CloseButtonVisible = false;

            _layer_content = new DockContent();
            _layer_content.Controls.Add(LayerEditor);
            LayerEditor.Layers.LayerChanged += new LayerControl.LayerEvent(Layers_LayerChanged);
            LayerEditor.Layers.LayerSelected += new LayerControl.LayerEvent(Layers_LayerSelected);
            LayerEditor.Layers.LayerVisibilityChanged += new LayerControl.LayerEvent(Layers_LayerVisibilityChanged);
            _layer_content.Text = "Map Layers";
            _layer_content.DockAreas = DockAreas.DockLeft | DockAreas.DockRight;
            _layer_content.DockHandler.CloseButtonVisible = false;

            _main_panel = new DockPanel();
            _main_panel.Dock = DockStyle.Fill;
            _main_panel.DocumentStyle = DocumentStyle.DockingWindow;
            if (System.IO.File.Exists("MapEditor.xml"))
            {
                DeserializeDockContent dc = new DeserializeDockContent(GetContent);
                _main_panel.LoadFromXml("MapEditor.xml", dc);
            }
            else
            {
                _map_content.Show(_main_panel, DockState.Document);
                _tile_content.Show(_map_content.Pane, DockAlignment.Bottom, 0.40);
                _draw_content.Show(_tile_content.PanelPane, _tile_content);
                _layer_content.Show(_main_panel, DockState.DockRight);
                _tileset_content.Show(_layer_content.Pane, DockAlignment.Bottom, 0.80);
            }

            Controls.Add(_main_panel);
        }

        private int _id = -1;
        public IDockContent GetContent(string persist)
        {
            if (persist == "WeifenLuo.WinFormsUI.Docking.DockContent")
            {
                _id++;
                switch (_id)
                {
                    case 0: return _map_content;
                    case 1: return _tile_content;
                    case 2: return _draw_content;
                    case 3: return _layer_content;
                    case 4: return _tileset_content;
                    default: return new DockContent();
                }
            }
            else return new DockContent();
        }
        #endregion

        public void CreateNew(short width = 20,
                              short height = 15, short tile_width = 16,
                              short tile_height = 16, string tileset_path = null)
        {
            Map map = new Map();
            map.CreateNew(width, height, tile_width, tile_height, tileset_path);
            MapControl.BaseMap = map;

            TilesetControl.Tileset = MapControl.BaseMap.Tileset;
            TilesetControl.Select(0);
            InitLayers();

            Invalidate(true);
        }

        public override void SaveLayout()
        {
            _main_panel.SaveAsXml("MapEditor.xml");
        }

        public override void Destroy()
        {
            LayerEditor.Layers.LayerChanged -= Layers_LayerChanged;
            LayerEditor.Layers.LayerSelected -= Layers_LayerSelected;
            LayerEditor.Layers.LayerVisibilityChanged -= Layers_LayerVisibilityChanged;
        }

        public override void LoadFile(string filename)
        {
            _filename = filename;

            Map map = new Map();
            map.Load(filename);

            MapControl.BaseMap = map;
            TilesetControl.Tileset = MapControl.BaseMap.Tileset;
            TilesetControl.Select(0);
            TilesetControl.ZoomIn();
            InitLayers();

            Invalidate(true);
        }

        public override void Save()
        {
            if (_filename == null) SaveAs();
            else
            {
                if (!Map.Save(_filename))
                {
                    if (MessageBox.Show("Tileset needs to be saved.", "Save the Tileset", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                    {
                        using (SaveFileDialog diag = new SaveFileDialog())
                        {
                            diag.Filter = "Tileset Files (.rts)|*.rts";
                            diag.InitialDirectory = Global.CurrentProject.Path + "\\maps";
                            if (diag.ShowDialog() == DialogResult.OK)
                            {
                                Map.Scripts[0] = System.IO.Path.GetFileName(diag.FileName);
                                Map.Save(_filename);
                                Parent.Text = System.IO.Path.GetFileName(_filename);
                            }
                        }
                    }
                }
                else Parent.Text = System.IO.Path.GetFileName(_filename);
            }
        }

        public override void SaveAs()
        {
            using (SaveFileDialog diag = new SaveFileDialog())
            {
                diag.Filter = "Map Files (.rmp)|*.rmp";
                diag.InitialDirectory = Global.CurrentProject.Path + "\\maps";
                if (diag.ShowDialog() == DialogResult.OK)
                {
                    _filename = diag.FileName;
                    Save();
                }
            }
        }

        private void InitLayers()
        {
            LayerEditor.Layers.ClearItems();
            foreach (Layer2 lay in MapControl.BaseMap.Layers)
            {
                LayerItem item = new LayerItem(lay.Name, lay.Visible);
                item.Tag = lay;
                LayerEditor.Layers.AddItem(item);
            }

            foreach (Entity ent in Map.Entities)
                ent.Visible = Map.Layers[ent.Layer].Visible;

            foreach (Zone2 zone in Map.Zones)
                zone.Visible = Map.Layers[zone.Layer].Visible;

            LayerEditor.Layers.StartLayer = MapControl.BaseMap.StartLayer;
            LayerEditor.Layers.SelectItem(MapControl.CurrentLayer);
        }

        public override void ZoomIn()
        {
            MapControl.ZoomIn();
        }

        public override void ZoomOut()
        {
            MapControl.ZoomOut();
        }

        public override void Undo()
        {
            undoButton.Enabled = MapControl.Undo();
            redoButton.Enabled = true;
            InitLayers();
        }

        public override void Redo()
        {
            redoButton.Enabled = MapControl.Redo();
            undoButton.Enabled = true;
            InitLayers();
        }

        public void SetTileSize(int tile_width, int tile_height)
        {
            MapControl.ResizeLayers(tile_width, tile_height);
            TilesetControl.Invalidate();
            TilesetControl.Select(TilesetControl.Selected);
        }

        public void UpdateTileset(string filename)
        {
            Map.Tileset.UpdateFromImage(filename);
            MapControl.RefreshLayers();
            TilesetControl.Select(TilesetControl.Selected);
            Invalidate(true);
        }

        private void Layers_LayerVisibilityChanged(LayerControl sender, EditorComponents.LayerItem layer)
        {
            Map.Layers[layer.Index].Visible = layer.Visible;
            foreach (Entity ent in Map.Entities)
                if (ent.Layer == layer.Index) ent.Visible = layer.Visible;
            foreach (Zone2 zone in Map.Zones)
                if (zone.Layer == layer.Index) zone.Visible = layer.Visible;
            MapControl.Invalidate();
        }

        private void Layers_LayerSelected(LayerControl sender, LayerItem layer)
        {
            MapControl.CurrentLayer = (short)layer.Index;
        }

        private void Layers_LayerChanged(LayerControl sender, LayerItem layer)
        {
            List<Layer2> layers = new List<Layer2>();
            foreach (LayerItem li in sender.Items)
            {
                if (li.Tag is Layer2) layers.Add(li.Tag as Layer2);
            }
            byte start = (byte)((layer.Start) ? layer.Index : sender.StartLayer);
            if (layer.State == ListViewItemStates.Selected) MapControl.CurrentLayer = (short)layer.Index;
            MapControl.SetLayers(layers, start);
            redoButton.Enabled = MapControl.CanRedo;
            undoButton.Enabled = MapControl.CanUndo;
            if (!Parent.Text.EndsWith("*")) Parent.Text += "*";
        }

        private void zoomInButton_Click(object sender, EventArgs e)
        {
            zoomInButton.Enabled = MapControl.ZoomIn();
            zoomOutButton.Enabled = true;
        }

        private void zoomOutButton_Click(object sender, EventArgs e)
        {
            zoomOutButton.Enabled = MapControl.ZoomOut();
            zoomInButton.Enabled = true;
        }

        private void PenButton_Click(object sender, EventArgs e)
        {
            UncheckButtons();
            PenButton.Checked = true;
            MapControl.Tool = MapControl.MapTool.Pen;
            MapControl.Invalidate();
        }

        private void rectangleButton_Click(object sender, EventArgs e)
        {
            UncheckButtons();
            RectangleButton.Checked = true;
            MapControl.Tool = MapControl.MapTool.Rectangle;
            MapControl.Invalidate();
        }

        private void FloodFillButton_Click(object sender, EventArgs e)
        {
            UncheckButtons();
            FloodFillButton.Checked = true;
            MapControl.Tool = EditorComponents.MapControl.MapTool.FloodFill;
            MapControl.Invalidate();
        }

        private void LineButton_Click(object sender, EventArgs e)
        {
            UncheckButtons();
            LineButton.Checked = true;
            MapControl.Tool = EditorComponents.MapControl.MapTool.Line;
            MapControl.Invalidate();
        }

        private void UncheckButtons()
        {
            PenButton.Checked = zoneButton.Checked = false;
            RectangleButton.Checked = EntityButton.Checked = false;
            LineButton.Checked = FloodFillButton.Checked = false;
        }

        private void undoButton_Click(object sender, EventArgs e)
        {
            Undo();
            TilesetControl.UpdateHeight();
            SelectTile(TilesetControl.Selected);
        }

        private void redoButton_Click(object sender, EventArgs e)
        {
            Redo();
            TilesetControl.UpdateHeight();
            SelectTile(TilesetControl.Selected);
        }

        private void SelectTile(short tile)
        {
            if (tile >= Map.Tileset.Tiles.Count) tile = (short)(Map.Tileset.Tiles.Count - 1);
            MapControl.CurrentTile = tile;
            TilesetControl.Selected = tile;
            TileDrawer.SetImage(Map.Tileset.Tiles[tile].Graphic, true);
            TileEditor.Tile = Map.Tileset.Tiles[tile];
        }

        private void showCameraButton_Click(object sender, EventArgs e)
        {
            MapControl.ShowCameraBounds = !MapControl.ShowCameraBounds;
            showCameraButton.Checked = !showCameraButton.Checked;
            MapControl.Invalidate();
        }

        private void MapControl_Edited(object sender, EventArgs e)
        {
            redoButton.Enabled = MapControl.CanRedo;
            undoButton.Enabled = MapControl.CanUndo;
            if (!Parent.Text.EndsWith("*")) Parent.Text += "*";
        }

        private void zoneButton_Click(object sender, EventArgs e)
        {
            PenButton.Checked = RectangleButton.Checked = false;
            zoneButton.Checked = true;
            MapControl.Tool = MapControl.MapTool.Zone;
            MapControl.Invalidate();
        }

        private void TileDrawer_ImageEdited(object sender, EventArgs e)
        {
            TilesetControl.Tileset.Tiles[TilesetControl.Selected].Graphic = TileDrawer.GetImage();
            TilesetControl.Invalidate();
            MapControl.RefreshLayers();
            if (!Parent.Text.EndsWith("*")) Parent.Text += "*";
        }

        private void MapControl_Paint(object sender, PaintEventArgs e)
        {
            map_pos_label.Text = MapControl.Tile.ToString();
            map_pos_label.Text += " Start: " + Map.StartLayer;
            zoomInButton.Enabled = MapControl.CanZoomIn;
            zoomOutButton.Enabled = MapControl.CanZoomOut;
        }

        private void MapControl_PropChanged(object sender, EventArgs e)
        {
            LayerEditor.Layers.StartLayer = Map.StartLayer;
            LayerEditor.Layers.Invalidate();
            TilesetControl.Select(MapControl.CurrentTile);
        }

        private void EntityButton_Click(object sender, EventArgs e)
        {
            UncheckButtons();
            EntityButton.Checked = true;
            MapControl.Tool = MapControl.MapTool.Entity;
        }

        private void Layers_LayerAdded(object sender, EventArgs e)
        {
            Layer2 lay = MapControl.AddLayer();
            LayerItem item = new LayerItem("Untitled", true);
            item.Tag = lay;
            LayerEditor.Layers.AddItem(item);
            MapControl.RefreshLayers();
        }

        private void Layers_LayerRemoved(object sender, EventArgs e)
        {
            Layer2 target = LayerEditor.Layers.Items[LayerEditor.Layers.SelectedIndex].Tag as Layer2;
            
            for (int i = 0; i < MapControl.GraphicLayers.Count; ++i)
            {
                if (MapControl.GraphicLayers[i].TargetLayer == target)
                {
                    MapControl.GraphicLayers.RemoveAt(i);
                    break;
                }
            }

            Map.Layers.Remove(target);
            LayerEditor.Layers.RemoveItem(LayerEditor.Layers.SelectedIndex);
            MapControl.RefreshLayers();
        }

        private void TilesetControl_TileSelected(short tile)
        {
            SelectTile(tile);
        }

        private void TilesetControl_TileRemoved(short tile, List<Tile> tiles)
        {
            TileRemovePage page = new TileRemovePage(this, tiles, tile, Map.CloneAllLayerTiles());
            MapControl.PushTileLayerPage(page);

            foreach (Layer2 lay in Map.Layers) lay.AdjustTiles(tile, (short)-tiles.Count);
            MapControl.RefreshLayers();
            
            redoButton.Enabled = MapControl.CanRedo;
            undoButton.Enabled = MapControl.CanUndo;
            SelectTile(tile);
            if (!Parent.Text.EndsWith("*")) Parent.Text += "*";
        }

        private void TilesetControl_TileAdded(short tile, List<Tile> tiles)
        {
            TileAddPage page = new TileAddPage(this, tiles, tile, Map.CloneAllLayerTiles());
            MapControl.PushTileLayerPage(page);

            foreach (Layer2 lay in Map.Layers) lay.AdjustTiles((short)(tile - 1), (short)tiles.Count);
            MapControl.RefreshLayers();

            redoButton.Enabled = MapControl.CanRedo;
            undoButton.Enabled = MapControl.CanUndo;
            SelectTile(tile);
            if (!Parent.Text.EndsWith("*")) Parent.Text += "*";
        }
    }
}
