using System;
using System.Drawing;
using System.Windows.Forms;
using Sphere_Editor.EditorComponents;
using Sphere_Editor.SphereObjects;
using WeifenLuo.WinFormsUI.Docking;

namespace Sphere_Editor.SubEditors
{
    public partial class Mapper : EditorObject
    {
        MapEditorControl Mappy = new MapEditorControl();
        LayerPanel MapLayers;

        // uninitialized docking objects:
        DockPanel MapperDock;
        DockContent MapContent;
        DockContent LayerContent;
        DockContent DrawerContent;
        DockContent TilesetContent;
        DockContent AutosetContent;
        DockContent TileEditorContent;

        private string filename = null;
        private bool tileset_float = false;
        private bool layer_float = false;

        public Mapper()
        {
            InitializeComponent();
            InitializeDocking();

            MapPanel.Controls.Add(Mappy);
            Mappy.Tileset.AddTile();
            Mappy.Layers.Add(new Layer("Base", 320, 240, Mappy.TileWidth, Mappy.TileHeight));
            Mappy.SetSize(20, 15);
            Mappy.SetZoomLevel(1);
            for (int i = 0; i < 9; ++i) Mappy.MapHeader.Scripts.Add(string.Empty);

            Init();
        }

        public Mapper(short width, short height, string tileset_path)
        {
            InitializeComponent();
            InitializeDocking();

            MapPanel.Controls.Add(Mappy);
            if (tileset_path != string.Empty)
            {
                Mappy.MapHeader.Scripts.Add(System.IO.Path.GetFileName(tileset_path));
                Mappy.Tileset.Dispose();
                Mappy.Tileset = new TilesetControl(tileset_path);
            }
            else Mappy.Tileset.AddTile();
            Mappy.Layers.Add(new Layer("Base", width, height, Mappy.TileWidth, Mappy.TileHeight));
            Mappy.SetSize(width, height);
            Mappy.SetZoomLevel(1);
            int i = 0;
            if (tileset_path != string.Empty) i = 1;
            for (; i < 9; ++i) Mappy.MapHeader.Scripts.Add(string.Empty);

            Init();
        }

        public Mapper(string filename)
        {
            this.filename = filename;
            InitializeComponent();
            Mappy.LoadMap(filename);
            InitializeDocking();
            MapPanel.Controls.Add(Mappy);
            Init();
        }

        private void Init()
        {
            MapLayers = new LayerPanel();
            MapLayers.Dock = DockStyle.Fill;
            MapLayerPanel.Controls.Add(MapLayers);
            TilesetPanel.Controls.Add(Mappy.Tileset);
            TilesetPanel.AutoScroll = true;
            if (Global.CurrentEditor.UseDockForm) Controls.Remove(DefaultSplitter);

            Mappy.LayerChanged += new EventHandler(Mappy_LayerChanged);
            Mappy.StartChanged += new EventHandler(Mappy_StartChanged);
            Mappy.MouseUp += new MouseEventHandler(Mappy_MouseUp);
            MapLayers.Layers.LayerSelected += new LayerControl.LayerEvent(Layers_LayerSelected);
            MapLayers.Layers.LayerVisibilityChanged += new LayerControl.LayerEvent(Layers_LayerVisibilityChanged);
            MapLayers.Layers.LayerChanged += new LayerControl.LayerEvent(Layers_LayerChanged);
            MapPanel.Resize += new EventHandler(MapPanel_Resize);
            DrawerControl.ImageEdited += new Drawer.EventHandler(DrawerControl_ImageEdited);

            Mappy.TileStatusLabel = this.TileStatusLabel;
            Mappy.Tileset.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
            Mappy.Tileset.TileSelected += new TilesetControl.EventHandler(Tileset_TileSelected);
            Mappy.Tileset.Selection = 0;
            Mappy.Tileset.Zoom = 2;
            DrawerControl.SetZoom(2);
            DrawerControl.CanDirty = false;
            Mappy.UpdateAllLayers();
            UpdateScrollSnap();

            foreach (Layer lay in Mappy.Layers)
                MapLayers.Layers.AddItem(lay.Name, lay.Visible);

            MapLayers.Layers.SelectItem(0);
            MapLayers.Layers.StartLayer = Mappy.StartLayer;
            //MainTileEditor.Tileset = Mappy.Tileset;
            AutosetEditor1.Tileset = Mappy.Tileset;
            Mappy.Tileset.UpdateHeight();
            Mappy.UpdateControl();
        }

        private void MapPanel_Resize(object sender, EventArgs e)
        {
            Mappy.UpdateControl();
            Mappy.Refresh();
        }

        private void Layers_LayerChanged(object sender, LayerItem li)
        {
            LayerControl ctrl = (LayerControl)sender;
            Layer layer = Mappy.Layers[ctrl.HomeIndex];
            Mappy.Layers.Remove(layer);
            Mappy.Layers.Insert(ctrl.MovedIndex, layer);

            Mappy.StartLayer = ctrl.StartLayer;
            
            if (!Parent.Text.Contains("*")) Parent.Text += "*";
            Mappy.UpdateAllLayers();
        }

        private void InitializeDocking()
        {
            if (!Global.CurrentEditor.UseDockForm) return;
            Controls.Remove(DefaultSplitter);

            MapperDock = new DockPanel();
            MapperDock.Dock = DockStyle.Fill;
            MapperDock.DocumentStyle = DocumentStyle.DockingWindow;
            Controls.Add(MapperDock);

            #region Content Planes
            MapContent = new DockContent();
            MapContent.DockHandler.CloseButtonVisible = false;
            MapContent.Controls.Add(MapPanel);
            MapContent.Controls.Add(MapToolStrip);
            MapContent.Controls.Add(MapStatus);
            MapContent.Text = "Map Editor";
            MapContent.AllowEndUserDocking = false;
            MapContent.Show(MapperDock, DockState.Document);

            LayerContent = new DockContent();
            LayerContent.Controls.Add(LayersBox);
            LayersBox.Size = new System.Drawing.Size(LayersBox.Parent.Width - 30, LayersBox.Parent.Height - 48);
            LayersBox.Location = new Point(6, 6);
            LayersBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            LayerContent.Text = "Layers";
            LayerContent.DockHandler.CloseButtonVisible = false;
            LayerContent.DockAreas = DockAreas.DockBottom | DockAreas.DockLeft | DockAreas.DockRight | DockAreas.Float;
            LayerContent.Show(MapperDock, DockState.DockRight);

            TilesetContent = new DockContent();
            TilesetContent.Controls.Add(TilesetBox);
            TilesetBox.Size = new System.Drawing.Size(TilesetBox.Parent.Width - 30, TilesetBox.Parent.Height - 48);
            TilesetBox.Location = new Point(6, 6);
            TilesetBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            TilesetContent.Text = "Tileset";
            TilesetContent.DockHandler.CloseButtonVisible = false;
            TilesetContent.DockAreas = DockAreas.DockBottom | DockAreas.DockLeft | DockAreas.DockRight | DockAreas.Float;
            TilesetContent.Show(LayerContent.Pane, DockAlignment.Bottom, 0.40);

            AutosetContent = new DockContent();
            AutosetContent.Controls.Add(AutosetEditor1);
            AutosetContent.Text = "Autoset";
            AutosetContent.DockHandler.CloseButtonVisible = false;
            AutosetContent.DockAreas = DockAreas.Document | DockAreas.DockBottom | DockAreas.DockLeft | DockAreas.DockRight | DockAreas.Float;
            AutosetContent.Show(MapContent.Pane, DockAlignment.Bottom, 0.40);

            TileEditorContent = new DockContent();
            TileEditorContent.Controls.Add(MainTileEditor);
            TileEditorContent.Text = "Tile Editor";
            TileEditorContent.DockHandler.CloseButtonVisible = false;
            TileEditorContent.DockAreas = DockAreas.Document;
            TileEditorContent.Show(AutosetContent.PanelPane, AutosetContent);

            DrawerControl.Dock = DockStyle.Fill;
            DrawerContent = new DockContent();
            DrawerContent.Controls.Add(DrawerControl);
            DrawerContent.Text = "Tile Image Editor";
            DrawerContent.DockHandler.CloseButtonVisible = false;
            DrawerContent.DockAreas = DockAreas.Document;
            DrawerContent.Show(TileEditorContent.PanelPane, TileEditorContent);
            #endregion
        }

        private void UpdateScrollSnap()
        {
            MapPanel.HorizontalScroll.SmallChange = Mappy.TileWidth * Mappy.ZoomLevel;
            MapPanel.VerticalScroll.SmallChange = Mappy.TileHeight * Mappy.ZoomLevel;
            MapPanel.HorizontalScroll.LargeChange = Mappy.TileWidth * Mappy.ZoomLevel * 5;
            MapPanel.VerticalScroll.LargeChange = Mappy.TileHeight * Mappy.ZoomLevel * 5;
            MapPanel.XSnap = Mappy.TileWidth;
            MapPanel.YSnap = Mappy.TileHeight;
        }

        void DrawerControl_ImageEdited(object sender, EventArgs e)
        {
            int cur = Mappy.Tileset.Selection;

            if (DrawerControl.GetTileAmount() > 0)
            {
                int tw = Mappy.TileWidth;
                int th = Mappy.TileHeight;
                TileImage[] images = DrawerControl.GetUncompiledTiles(tw, th);
                foreach (TileImage img in images)
                {
                    if (img.Index == -1) continue; // to check for those 'blank' index tiles.
                    Mappy.Tileset.SetTileImage(img.Index, img.Image);
                }
            }
            else
                Mappy.Tileset.SetTileImage(cur, DrawerControl.Image);

            if (!Parent.Text.Contains("*")) Parent.Text += "*";
            Mappy.Tileset.Refresh();
            Mappy.UpdateAllLayers();
        }

        void Mappy_MouseUp(object sender, MouseEventArgs e)
        {
            TileUndoButton.Enabled = Mappy.IsUndoable;
            TileRedoButton.Enabled = Mappy.IsRedoable;
            MapLayers.Layers.StartLayer = Mappy.StartLayer;
            if (e.Button == MouseButtons.Left) { if (!Parent.Text.Contains("*")) Parent.Text += "*"; }
            MapLayers.Layers.Refresh();
        }

        void Layers_LayerVisibilityChanged(object sender, LayerItem li)
        {
            if (!Parent.Text.Contains("*")) Parent.Text += "*";
            Mappy.Refresh();
        }

        void Layers_LayerSelected(object sender, LayerItem li)
        {
            Mappy.LayerNum = MapLayers.Layers.SelectedIndex;
            Mappy.Refresh();
        }

        void Mappy_LayerChanged(object sender, EventArgs e)
        {
            MapLayers.Layers.SelectItem(Mappy.LayerNum);
            if (!Parent.Text.Contains("*")) Parent.Text += "*";
            MapLayers.Layers.Refresh();
        }

        void Mappy_StartChanged(object sender, EventArgs e)
        {
            MapLayers.Layers.StartLayer = Mappy.StartLayer;
            if (!Parent.Text.Contains("*")) Parent.Text += "*";
            MapLayers.Refresh();
        }

        void Tileset_TileSelected(object sender, EventArgs e)
        {
            short[] indices = Mappy.Tileset.GetSelectedIndices();
            if (indices != null)
            {
                if (indices.Length == 0)
                {
                    MainTileEditor.Tile = Mappy.Tileset.GetCurrentTile();
                    DrawerControl.SetImage((Bitmap)Mappy.Tileset.GetCurrentTile().Graphic);
                    Mappy.SetStampMap(new short[0], 1, 1);
                }
                else
                {
                    Bitmap map = Mappy.Tileset.GetTileMap();
                    DrawerControl.SetTileImageMap(map, indices);
                    Mappy.SetStampMap(indices, map.Width / Mappy.TileWidth,
                        map.Height / Mappy.TileHeight);
                }
            }
        }

        private void MapperDock_Leave(object sender, EventArgs e)
        {
            if (TilesetContent.DockState == DockState.Float)
            {
                TilesetContent.DockState = DockState.DockRight;
                tileset_float = true;
            }
            if (LayerContent.DockState == DockState.Float)
            {
                LayerContent.DockState = DockState.DockRight;
                layer_float = true;
            }
        }

        private void MapperDock_Enter(object sender, EventArgs e)
        {
            if (tileset_float)
            {
                TilesetContent.DockState = DockState.Float;
                tileset_float = false;
            }
            if (layer_float)
            {
                LayerContent.DockState = DockState.Float;
                layer_float = false;
            }
        }

        #region tool button clicks
        private void ZoomInClick(object sender, EventArgs e)
        {
            int zoom = Mappy.ZoomLevel;
            if (zoom < 6)
            {
                Mappy.SetZoomLevel(zoom + 1);
                ZoomStatusLabel.Text = "Zoom: x" + (zoom+1);
                ZoomOutButton.Enabled = true;
            }
            if (Mappy.ZoomLevel == 6) ZoomInButton.Enabled = false;
            UpdateScrollSnap();
        }

        private void ZoomOutClick(object sender, EventArgs e)
        {
            int zoom = Mappy.ZoomLevel;
            if (zoom > 1)
            {
                Mappy.SetZoomLevel(zoom - 1);
                ZoomStatusLabel.Text = "Zoom: x" + (zoom + 1);
                ZoomInButton.Enabled = true;
            }
            if (Mappy.ZoomLevel == 1) ZoomOutButton.Enabled = false;
            UpdateScrollSnap();
        }

        private void UnselectButtons()
        {
            TileRectangleButton.Checked = false;
            TileLineButton.Checked = false;
            TileSelectButton.Checked = false;
            TileFillButton.Checked = false;
            ZoneToolButton.Checked = false;
            for (int i = 0; i < Mappy.Controls.Count; ++i)
            {
                Mappy.Controls[i].Enabled = false;
            }
        }

        private void TileFillButton_Click(object sender, EventArgs e)
        {
            UnselectButtons();
            TileFillButton.Checked = true;
            Mappy.ToolNum = 3;
        }

        private void TileRectangleButton_Click(object sender, EventArgs e)
        {
            UnselectButtons();
            TileRectangleButton.Checked = true;
            Mappy.ToolNum = 2;
        }

        private void TileLineButton_Click(object sender, EventArgs e)
        {
            UnselectButtons();
            TileLineButton.Checked = true;
            Mappy.ToolNum = 1;
        }

        private void TileSelectButton_Click(object sender, EventArgs e)
        {
            UnselectButtons();
            TileSelectButton.Checked = true;
            Mappy.ToolNum = 0;
        }

        private void TileUndoButton_Click(object sender, EventArgs e)
        {
            Mappy.UndoAction();
            TileUndoButton.Enabled = Mappy.IsUndoable;
            TileRedoButton.Enabled = Mappy.IsRedoable;
        }

        private void TileRedoButton_Click(object sender, EventArgs e)
        {
            Mappy.RedoAction();
            TileUndoButton.Enabled = Mappy.IsUndoable;
            TileRedoButton.Enabled = Mappy.IsRedoable;
        }

        private void ZoneToolButton_Click(object sender, EventArgs e)
        {
            UnselectButtons();
            ZoneToolButton.Checked = true;
            for (int i = 0; i < Mappy.Controls.Count; ++i)
            {
                Mappy.Controls[i].Enabled = true;
            }
            Mappy.ToolNum = 4;
        }

        private void MoveEntityButton_Click(object sender, EventArgs e)
        {
            UnselectButtons();
            Mappy.ToolNum = 7;
            MoveEntityButton.Checked = true;
        }
        #endregion

        public MapEditorControl Map
        {
            get { return Mappy; }
            set { Mappy = value; }
        }

        public override void Save()
        {
            if (this.filename == null) SaveAs();
            else
            {
                MainTileEditor.Tile = MainTileEditor.Tile; // this stint will force a save of the current tile
                if (Mappy.SaveMap(filename))
                    Parent.Text = System.IO.Path.GetFileName(this.filename);
            }
        }

        public override void SaveAs()
        {
            SaveFileDialog diag = new SaveFileDialog();
            diag.Filter = "Map Files (.rmp)|*.rmp";

            if (Global.CurrentProject.Path != null)
                diag.InitialDirectory = Global.CurrentProject.Path + "\\maps";

            if (diag.ShowDialog() == DialogResult.OK)
            {
                this.filename = diag.FileName;
                this.Save();
            }
        }

        public override void Copy() { DrawerControl.Copy(); }
        public override void Paste() { DrawerControl.Paste(); }
        public override void Undo() { DrawerControl.Undo(); }
        public override void Redo() { DrawerControl.Redo(); }
        public override void ZoomIn() { ZoomInClick(null, EventArgs.Empty); }
        public override void ZoomOut() { ZoomOutClick(null, EventArgs.Empty); }

        private void MainTileEditor_Modified(object sender, EventArgs e)
        {
            if (!Parent.Text.Contains("*")) Parent.Text += "*";
        }

        private void autosetEditor1_OnUse(object sender, EventArgs e)
        {
            short tile = ((AutosetEditor)sender).CenterTile;
            if (tile == -1) return;
            else
            {
                UnselectButtons();
                Mappy.Tileset.Selection = tile;
                Mappy.ToolNum = 6;
                Mappy.Autoset = ((AutosetEditor)sender);
            }
        }
    }
}
