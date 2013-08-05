namespace MapEditPlugin
{
    partial class MapEditor
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null) components.Dispose();
                LayerEditor.Layers.LayerChanged -= Layers_LayerChanged;
                LayerEditor.Layers.LayerSelected -= Layers_LayerSelected;
                LayerEditor.Layers.LayerVisibilityChanged -= Layers_LayerVisibilityChanged;
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapEditor));
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.miniToolStrip = new System.Windows.Forms.ToolStrip();
            this.SplitContainer = new System.Windows.Forms.SplitContainer();
            this.mapSplitter = new System.Windows.Forms.SplitContainer();
            this.MapToolContainer = new System.Windows.Forms.ToolStripContainer();
            this.MapControl = new MapEditPlugin.Components.MapControl();
            this.mapstatus = new System.Windows.Forms.StatusStrip();
            this.map_pos_label = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.PenButton = new System.Windows.Forms.ToolStripButton();
            this.LineButton = new System.Windows.Forms.ToolStripButton();
            this.RectangleButton = new System.Windows.Forms.ToolStripButton();
            this.FloodFillButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.zoomInButton = new System.Windows.Forms.ToolStripButton();
            this.zoomOutButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.undoButton = new System.Windows.Forms.ToolStripButton();
            this.redoButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.showCameraButton = new System.Windows.Forms.ToolStripButton();
            this.zoneButton = new System.Windows.Forms.ToolStripButton();
            this.EntityButton = new System.Windows.Forms.ToolStripButton();
            this.ShowNumButton = new System.Windows.Forms.ToolStripButton();
            this.EditorTabs = new System.Windows.Forms.TabControl();
            this.imageTab = new System.Windows.Forms.TabPage();
            this.TileDrawer = new Sphere.Plugins.Shims.ImageEditShim();
            this.tileTab = new System.Windows.Forms.TabPage();
            this.TileEditor = new MapEditPlugin.Components.TileEditor();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.LayerEditor = new MapEditPlugin.Components.LayerPanel();
            this.TilesetPanel = new Sphere.Core.Editor.EditorPanel();
            this.TilesetControl = new MapEditPlugin.Components.TilesetControl2();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer)).BeginInit();
            this.SplitContainer.Panel1.SuspendLayout();
            this.SplitContainer.Panel2.SuspendLayout();
            this.SplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapSplitter)).BeginInit();
            this.mapSplitter.Panel1.SuspendLayout();
            this.mapSplitter.Panel2.SuspendLayout();
            this.mapSplitter.SuspendLayout();
            this.MapToolContainer.ContentPanel.SuspendLayout();
            this.MapToolContainer.TopToolStripPanel.SuspendLayout();
            this.MapToolContainer.SuspendLayout();
            this.mapstatus.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.EditorTabs.SuspendLayout();
            this.imageTab.SuspendLayout();
            this.tileTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.TilesetPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // BottomToolStripPanel
            // 
            this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // TopToolStripPanel
            // 
            this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // RightToolStripPanel
            // 
            this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // LeftToolStripPanel
            // 
            this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // ContentPanel
            // 
            this.ContentPanel.AutoScroll = true;
            this.ContentPanel.Size = new System.Drawing.Size(681, 428);
            // 
            // miniToolStrip
            // 
            this.miniToolStrip.AutoSize = false;
            this.miniToolStrip.CanOverflow = false;
            this.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.miniToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.miniToolStrip.Location = new System.Drawing.Point(107, 3);
            this.miniToolStrip.Name = "miniToolStrip";
            this.miniToolStrip.Size = new System.Drawing.Size(110, 25);
            this.miniToolStrip.TabIndex = 0;
            // 
            // SplitContainer
            // 
            this.SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.SplitContainer.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer.Name = "SplitContainer";
            // 
            // SplitContainer.Panel1
            // 
            this.SplitContainer.Panel1.Controls.Add(this.mapSplitter);
            // 
            // SplitContainer.Panel2
            // 
            this.SplitContainer.Panel2.Controls.Add(this.splitContainer1);
            this.SplitContainer.Size = new System.Drawing.Size(681, 453);
            this.SplitContainer.SplitterDistance = 457;
            this.SplitContainer.TabIndex = 3;
            // 
            // mapSplitter
            // 
            this.mapSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapSplitter.Location = new System.Drawing.Point(0, 0);
            this.mapSplitter.Name = "mapSplitter";
            this.mapSplitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // mapSplitter.Panel1
            // 
            this.mapSplitter.Panel1.Controls.Add(this.MapToolContainer);
            // 
            // mapSplitter.Panel2
            // 
            this.mapSplitter.Panel2.Controls.Add(this.EditorTabs);
            this.mapSplitter.Size = new System.Drawing.Size(457, 453);
            this.mapSplitter.SplitterDistance = 207;
            this.mapSplitter.TabIndex = 3;
            // 
            // MapToolContainer
            // 
            this.MapToolContainer.BottomToolStripPanelVisible = false;
            // 
            // MapToolContainer.ContentPanel
            // 
            this.MapToolContainer.ContentPanel.Controls.Add(this.MapControl);
            this.MapToolContainer.ContentPanel.Controls.Add(this.mapstatus);
            this.MapToolContainer.ContentPanel.Size = new System.Drawing.Size(457, 182);
            this.MapToolContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MapToolContainer.Location = new System.Drawing.Point(0, 0);
            this.MapToolContainer.Name = "MapToolContainer";
            this.MapToolContainer.Size = new System.Drawing.Size(457, 207);
            this.MapToolContainer.TabIndex = 2;
            this.MapToolContainer.Text = "toolStripContainer1";
            // 
            // MapToolContainer.TopToolStripPanel
            // 
            this.MapToolContainer.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // MapControl
            // 
            this.MapControl.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.MapControl.BaseMap = null;
            this.MapControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MapControl.CurrentLayer = ((short)(0));
            this.MapControl.CurrentTile = ((short)(0));
            this.MapControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MapControl.Location = new System.Drawing.Point(0, 0);
            this.MapControl.MapPixel = new System.Drawing.Point(0, 0);
            this.MapControl.Name = "MapControl";
            this.MapControl.SelWidth = 1;
            this.MapControl.ShowCameraBounds = false;
            this.MapControl.ShowTileNums = false;
            this.MapControl.Size = new System.Drawing.Size(457, 158);
            this.MapControl.TabIndex = 1;
            this.MapControl.Tiles = null;
            this.MapControl.Tool = MapEditPlugin.Components.MapControl.MapTool.Pen;
            this.MapControl.PropChanged += new System.EventHandler(this.MapControl_PropChanged);
            this.MapControl.Edited += new System.EventHandler(this.MapControl_Edited);
            this.MapControl.Paint += new System.Windows.Forms.PaintEventHandler(this.MapControl_Paint);
            // 
            // mapstatus
            // 
            this.mapstatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.map_pos_label});
            this.mapstatus.Location = new System.Drawing.Point(0, 158);
            this.mapstatus.Name = "mapstatus";
            this.mapstatus.Size = new System.Drawing.Size(457, 24);
            this.mapstatus.SizingGrip = false;
            this.mapstatus.TabIndex = 2;
            // 
            // map_pos_label
            // 
            this.map_pos_label.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.map_pos_label.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.map_pos_label.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.map_pos_label.Name = "map_pos_label";
            this.map_pos_label.Size = new System.Drawing.Size(37, 19);
            this.map_pos_label.Text = "(0, 0)";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PenButton,
            this.LineButton,
            this.RectangleButton,
            this.FloodFillButton,
            this.toolStripSeparator1,
            this.zoomInButton,
            this.zoomOutButton,
            this.toolStripSeparator2,
            this.undoButton,
            this.redoButton,
            this.toolStripSeparator3,
            this.showCameraButton,
            this.zoneButton,
            this.EntityButton,
            this.ShowNumButton});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(306, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // PenButton
            // 
            this.PenButton.Checked = true;
            this.PenButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.PenButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.PenButton.Image = global::MapEditPlugin.Properties.Resources.pencil;
            this.PenButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PenButton.Name = "PenButton";
            this.PenButton.Size = new System.Drawing.Size(23, 22);
            this.PenButton.Text = "Pen";
            this.PenButton.Click += new System.EventHandler(this.PenButton_Click);
            // 
            // LineButton
            // 
            this.LineButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.LineButton.Image = global::MapEditPlugin.Properties.Resources.line;
            this.LineButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LineButton.Name = "LineButton";
            this.LineButton.Size = new System.Drawing.Size(23, 22);
            this.LineButton.Text = "Line Tool";
            this.LineButton.Click += new System.EventHandler(this.LineButton_Click);
            // 
            // RectangleButton
            // 
            this.RectangleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RectangleButton.Image = global::MapEditPlugin.Properties.Resources.rectangle;
            this.RectangleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RectangleButton.Name = "RectangleButton";
            this.RectangleButton.Size = new System.Drawing.Size(23, 22);
            this.RectangleButton.Text = "Rectangle";
            this.RectangleButton.Click += new System.EventHandler(this.rectangleButton_Click);
            // 
            // FloodFillButton
            // 
            this.FloodFillButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.FloodFillButton.Image = global::MapEditPlugin.Properties.Resources.paintcan;
            this.FloodFillButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FloodFillButton.Name = "FloodFillButton";
            this.FloodFillButton.Size = new System.Drawing.Size(23, 22);
            this.FloodFillButton.Text = "Flood Fill Tool";
            this.FloodFillButton.Click += new System.EventHandler(this.FloodFillButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // zoomInButton
            // 
            this.zoomInButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.zoomInButton.Image = global::MapEditPlugin.Properties.Resources.magnifier_zoom_in;
            this.zoomInButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoomInButton.Name = "zoomInButton";
            this.zoomInButton.Size = new System.Drawing.Size(23, 22);
            this.zoomInButton.Text = "Zoom In";
            this.zoomInButton.Click += new System.EventHandler(this.zoomInButton_Click);
            // 
            // zoomOutButton
            // 
            this.zoomOutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.zoomOutButton.Enabled = false;
            this.zoomOutButton.Image = global::MapEditPlugin.Properties.Resources.magnifier_zoom_out;
            this.zoomOutButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoomOutButton.Name = "zoomOutButton";
            this.zoomOutButton.Size = new System.Drawing.Size(23, 22);
            this.zoomOutButton.Text = "Zoom Out";
            this.zoomOutButton.Click += new System.EventHandler(this.zoomOutButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // undoButton
            // 
            this.undoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.undoButton.Enabled = false;
            this.undoButton.Image = global::MapEditPlugin.Properties.Resources.arrow_undo;
            this.undoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.undoButton.Name = "undoButton";
            this.undoButton.Size = new System.Drawing.Size(23, 22);
            this.undoButton.Text = "Undo";
            this.undoButton.Click += new System.EventHandler(this.undoButton_Click);
            // 
            // redoButton
            // 
            this.redoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.redoButton.Enabled = false;
            this.redoButton.Image = global::MapEditPlugin.Properties.Resources.arrow_redo;
            this.redoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.redoButton.Name = "redoButton";
            this.redoButton.Size = new System.Drawing.Size(23, 22);
            this.redoButton.Text = "Redo";
            this.redoButton.Click += new System.EventHandler(this.redoButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // showCameraButton
            // 
            this.showCameraButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.showCameraButton.Image = global::MapEditPlugin.Properties.Resources.eye;
            this.showCameraButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.showCameraButton.Name = "showCameraButton";
            this.showCameraButton.Size = new System.Drawing.Size(23, 22);
            this.showCameraButton.Text = "Show Camera Bounds";
            this.showCameraButton.Click += new System.EventHandler(this.showCameraButton_Click);
            // 
            // zoneButton
            // 
            this.zoneButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.zoneButton.Image = global::MapEditPlugin.Properties.Resources.zone;
            this.zoneButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoneButton.Name = "zoneButton";
            this.zoneButton.Size = new System.Drawing.Size(23, 22);
            this.zoneButton.Text = "Zone Mode";
            this.zoneButton.Click += new System.EventHandler(this.zoneButton_Click);
            // 
            // EntityButton
            // 
            this.EntityButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.EntityButton.Image = global::MapEditPlugin.Properties.Resources.arrow_inout;
            this.EntityButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EntityButton.Name = "EntityButton";
            this.EntityButton.Size = new System.Drawing.Size(23, 22);
            this.EntityButton.Text = "Entity Mover";
            this.EntityButton.Click += new System.EventHandler(this.EntityButton_Click);
            // 
            // ShowNumButton
            // 
            this.ShowNumButton.CheckOnClick = true;
            this.ShowNumButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ShowNumButton.Image = global::MapEditPlugin.Properties.Resources.style;
            this.ShowNumButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ShowNumButton.Name = "ShowNumButton";
            this.ShowNumButton.Size = new System.Drawing.Size(23, 22);
            this.ShowNumButton.Text = "Show Tile Nums";
            this.ShowNumButton.Click += new System.EventHandler(this.ShowNumButton_Click);
            // 
            // EditorTabs
            // 
            this.EditorTabs.Controls.Add(this.imageTab);
            this.EditorTabs.Controls.Add(this.tileTab);
            this.EditorTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EditorTabs.Location = new System.Drawing.Point(0, 0);
            this.EditorTabs.Name = "EditorTabs";
            this.EditorTabs.SelectedIndex = 0;
            this.EditorTabs.Size = new System.Drawing.Size(457, 242);
            this.EditorTabs.TabIndex = 0;
            // 
            // imageTab
            // 
            this.imageTab.Controls.Add(this.TileDrawer);
            this.imageTab.Location = new System.Drawing.Point(4, 22);
            this.imageTab.Name = "imageTab";
            this.imageTab.Padding = new System.Windows.Forms.Padding(3);
            this.imageTab.Size = new System.Drawing.Size(449, 216);
            this.imageTab.TabIndex = 0;
            this.imageTab.Text = "Image Editor";
            this.imageTab.UseVisualStyleBackColor = true;
            // 
            // TileDrawer
            // 
            this.TileDrawer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TileDrawer.Location = new System.Drawing.Point(3, 3);
            this.TileDrawer.Name = "TileDrawer";
            this.TileDrawer.Size = new System.Drawing.Size(443, 210);
            this.TileDrawer.TabIndex = 0;
            this.TileDrawer.ImageEdited += new System.EventHandler(this.TileDrawer_ImageEdited);
            // 
            // tileTab
            // 
            this.tileTab.Controls.Add(this.TileEditor);
            this.tileTab.Location = new System.Drawing.Point(4, 22);
            this.tileTab.Name = "tileTab";
            this.tileTab.Padding = new System.Windows.Forms.Padding(3);
            this.tileTab.Size = new System.Drawing.Size(449, 216);
            this.tileTab.TabIndex = 1;
            this.tileTab.Text = "Tile Editor";
            this.tileTab.UseVisualStyleBackColor = true;
            // 
            // TileEditor
            // 
            this.TileEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TileEditor.Location = new System.Drawing.Point(3, 3);
            this.TileEditor.MinimumSize = new System.Drawing.Size(414, 332);
            this.TileEditor.Name = "TileEditor";
            this.TileEditor.Size = new System.Drawing.Size(443, 332);
            this.TileEditor.TabIndex = 0;
            this.TileEditor.Tile = null;
            this.TileEditor.Zoom = 4;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.LayerEditor);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.TilesetPanel);
            this.splitContainer1.Size = new System.Drawing.Size(220, 453);
            this.splitContainer1.SplitterDistance = 158;
            this.splitContainer1.TabIndex = 1;
            // 
            // LayerEditor
            // 
            this.LayerEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(225)))), ((int)(((byte)(243)))));
            this.LayerEditor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LayerEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayerEditor.Location = new System.Drawing.Point(0, 0);
            this.LayerEditor.Name = "LayerEditor";
            this.LayerEditor.Size = new System.Drawing.Size(220, 158);
            this.LayerEditor.TabIndex = 0;
            this.LayerEditor.LayerAdded += new System.EventHandler(this.Layers_LayerAdded);
            this.LayerEditor.LayerRemoved += new System.EventHandler(this.Layers_LayerRemoved);
            // 
            // TilesetPanel
            // 
            this.TilesetPanel.AutoScroll = true;
            this.TilesetPanel.Controls.Add(this.TilesetControl);
            this.TilesetPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TilesetPanel.Location = new System.Drawing.Point(0, 0);
            this.TilesetPanel.Name = "TilesetPanel";
            this.TilesetPanel.Size = new System.Drawing.Size(220, 291);
            this.TilesetPanel.TabIndex = 1;
            this.TilesetPanel.XSnap = 0;
            this.TilesetPanel.YSnap = 0;
            // 
            // TilesetControl
            // 
            this.TilesetControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TilesetControl.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("TilesetControl.BackgroundImage")));
            this.TilesetControl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.TilesetControl.CanInsert = true;
            this.TilesetControl.Location = new System.Drawing.Point(3, 3);
            this.TilesetControl.MultiSelect = false;
            this.TilesetControl.Name = "TilesetControl";
            this.TilesetControl.Selected = ((System.Collections.Generic.List<short>)(resources.GetObject("TilesetControl.Selected")));
            this.TilesetControl.Size = new System.Drawing.Size(0, 298);
            this.TilesetControl.TabIndex = 0;
            this.TilesetControl.Tileset = null;
            this.TilesetControl.TileSelected += new MapEditPlugin.Components.TilesetControl2.SelectedHandler(this.TilesetControl_TileSelected);
            this.TilesetControl.TileRemoved += new MapEditPlugin.Components.TilesetControl2.TileHandler(this.TilesetControl_TileRemoved);
            this.TilesetControl.TileAdded += new MapEditPlugin.Components.TilesetControl2.TileHandler(this.TilesetControl_TileAdded);
            // 
            // MapEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SplitContainer);
            this.Name = "MapEditor";
            this.Size = new System.Drawing.Size(681, 453);
            this.SplitContainer.Panel1.ResumeLayout(false);
            this.SplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer)).EndInit();
            this.SplitContainer.ResumeLayout(false);
            this.mapSplitter.Panel1.ResumeLayout(false);
            this.mapSplitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mapSplitter)).EndInit();
            this.mapSplitter.ResumeLayout(false);
            this.MapToolContainer.ContentPanel.ResumeLayout(false);
            this.MapToolContainer.ContentPanel.PerformLayout();
            this.MapToolContainer.TopToolStripPanel.ResumeLayout(false);
            this.MapToolContainer.TopToolStripPanel.PerformLayout();
            this.MapToolContainer.ResumeLayout(false);
            this.MapToolContainer.PerformLayout();
            this.mapstatus.ResumeLayout(false);
            this.mapstatus.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.EditorTabs.ResumeLayout(false);
            this.imageTab.ResumeLayout(false);
            this.tileTab.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.TilesetPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip miniToolStrip;
        private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
        private System.Windows.Forms.ToolStripContentPanel ContentPanel;
        private System.Windows.Forms.SplitContainer SplitContainer;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton PenButton;
        private System.Windows.Forms.ToolStripButton RectangleButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton zoomInButton;
        private System.Windows.Forms.ToolStripButton zoomOutButton;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Sphere.Core.Editor.EditorPanel TilesetPanel;
        private System.Windows.Forms.ToolStripContainer MapToolContainer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton undoButton;
        private System.Windows.Forms.ToolStripButton redoButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton zoneButton;
        private System.Windows.Forms.SplitContainer mapSplitter;
        private System.Windows.Forms.StatusStrip mapstatus;
        private System.Windows.Forms.ToolStripStatusLabel map_pos_label;
        private Components.LayerPanel LayerEditor;
        private System.Windows.Forms.ToolStripButton EntityButton;
        private System.Windows.Forms.ToolStripButton LineButton;
        private System.Windows.Forms.ToolStripButton FloodFillButton;
        private System.Windows.Forms.ToolStripButton showCameraButton;
        private System.Windows.Forms.TabControl EditorTabs;
        private System.Windows.Forms.TabPage imageTab;
        private System.Windows.Forms.TabPage tileTab;
        private Components.TileEditor TileEditor;
        public Components.TilesetControl2 TilesetControl;
        public Components.MapControl MapControl;
        private System.Windows.Forms.ToolStripButton ShowNumButton;
        private Sphere.Plugins.Shims.ImageEditShim TileDrawer;

    }
}
