namespace Sphere_Editor.SubEditors
{
    partial class Mapper
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
            if (disposing && (components != null))
            {
                components.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mapper));
            this.MapToolStrip = new System.Windows.Forms.ToolStrip();
            this.TileSelectButton = new System.Windows.Forms.ToolStripButton();
            this.TileLineButton = new System.Windows.Forms.ToolStripButton();
            this.TileRectangleButton = new System.Windows.Forms.ToolStripButton();
            this.TileFillButton = new System.Windows.Forms.ToolStripButton();
            this.TileToolSeperator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ZoomInButton = new System.Windows.Forms.ToolStripButton();
            this.ZoomOutButton = new System.Windows.Forms.ToolStripButton();
            this.TileToolSeperator2 = new System.Windows.Forms.ToolStripSeparator();
            this.TileUndoButton = new System.Windows.Forms.ToolStripButton();
            this.TileRedoButton = new System.Windows.Forms.ToolStripButton();
            this.TileToolSeperator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ZoneToolButton = new System.Windows.Forms.ToolStripButton();
            this.MoveEntityButton = new System.Windows.Forms.ToolStripButton();
            this.MapPanel = new Sphere_Editor.EditorPanel();
            this.DrawerControl = new Sphere_Editor.SubEditors.Drawer();
            this.DefaultSplitter = new System.Windows.Forms.SplitContainer();
            this.MapSplitter = new System.Windows.Forms.SplitContainer();
            this.MapStatus = new System.Windows.Forms.StatusStrip();
            this.EntityStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.TileStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ZoomStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.DrawerPage = new System.Windows.Forms.TabPage();
            this.EditorPage = new System.Windows.Forms.TabPage();
            this.MainTileEditor = new Sphere_Editor.EditorComponents.TileEditor();
            this.AutosetPage = new System.Windows.Forms.TabPage();
            this.AutosetEditor1 = new Sphere_Editor.EditorComponents.AutosetEditor();
            this.TilesetBox = new System.Windows.Forms.Panel();
            this.TilesetLabel = new Sphere_Editor.EditorLabel();
            this.TilesetPanel = new Sphere_Editor.EditorPanel();
            this.LayersBox = new System.Windows.Forms.Panel();
            this.LayerLabel = new Sphere_Editor.EditorLabel();
            this.MapLayerPanel = new Sphere_Editor.EditorPanel();
            this.MapToolStrip.SuspendLayout();
            this.DefaultSplitter.Panel1.SuspendLayout();
            this.DefaultSplitter.Panel2.SuspendLayout();
            this.DefaultSplitter.SuspendLayout();
            this.MapSplitter.Panel1.SuspendLayout();
            this.MapSplitter.Panel2.SuspendLayout();
            this.MapSplitter.SuspendLayout();
            this.MapStatus.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.DrawerPage.SuspendLayout();
            this.EditorPage.SuspendLayout();
            this.AutosetPage.SuspendLayout();
            this.TilesetBox.SuspendLayout();
            this.LayersBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // MapToolStrip
            // 
            this.MapToolStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(225)))), ((int)(((byte)(243)))));
            this.MapToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.MapToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TileSelectButton,
            this.TileLineButton,
            this.TileRectangleButton,
            this.TileFillButton,
            this.TileToolSeperator1,
            this.ZoomInButton,
            this.ZoomOutButton,
            this.TileToolSeperator2,
            this.TileUndoButton,
            this.TileRedoButton,
            this.TileToolSeperator3,
            this.ZoneToolButton,
            this.MoveEntityButton});
            this.MapToolStrip.Location = new System.Drawing.Point(0, 0);
            this.MapToolStrip.Name = "MapToolStrip";
            this.MapToolStrip.Padding = new System.Windows.Forms.Padding(5, 0, 1, 0);
            this.MapToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.MapToolStrip.Size = new System.Drawing.Size(560, 25);
            this.MapToolStrip.TabIndex = 2;
            // 
            // TileSelectButton
            // 
            this.TileSelectButton.Checked = true;
            this.TileSelectButton.CheckOnClick = true;
            this.TileSelectButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TileSelectButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TileSelectButton.Image = global::Sphere_Editor.Properties.Resources.pencil;
            this.TileSelectButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TileSelectButton.Name = "TileSelectButton";
            this.TileSelectButton.Size = new System.Drawing.Size(23, 22);
            this.TileSelectButton.Text = "Draw Tile";
            this.TileSelectButton.Click += new System.EventHandler(this.TileSelectButton_Click);
            // 
            // TileLineButton
            // 
            this.TileLineButton.CheckOnClick = true;
            this.TileLineButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TileLineButton.Image = global::Sphere_Editor.Properties.Resources.line;
            this.TileLineButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TileLineButton.Name = "TileLineButton";
            this.TileLineButton.Size = new System.Drawing.Size(23, 22);
            this.TileLineButton.Text = "Draw Tile Line";
            this.TileLineButton.Click += new System.EventHandler(this.TileLineButton_Click);
            // 
            // TileRectangleButton
            // 
            this.TileRectangleButton.CheckOnClick = true;
            this.TileRectangleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TileRectangleButton.Image = global::Sphere_Editor.Properties.Resources.rectangle;
            this.TileRectangleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TileRectangleButton.Name = "TileRectangleButton";
            this.TileRectangleButton.Size = new System.Drawing.Size(23, 22);
            this.TileRectangleButton.Text = "Fill Tile Rectangle";
            this.TileRectangleButton.Click += new System.EventHandler(this.TileRectangleButton_Click);
            // 
            // TileFillButton
            // 
            this.TileFillButton.CheckOnClick = true;
            this.TileFillButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TileFillButton.Image = global::Sphere_Editor.Properties.Resources.paintcan;
            this.TileFillButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TileFillButton.Name = "TileFillButton";
            this.TileFillButton.Size = new System.Drawing.Size(23, 22);
            this.TileFillButton.Text = "Fill Tile";
            this.TileFillButton.Click += new System.EventHandler(this.TileFillButton_Click);
            // 
            // TileToolSeperator1
            // 
            this.TileToolSeperator1.Name = "TileToolSeperator1";
            this.TileToolSeperator1.Size = new System.Drawing.Size(6, 25);
            // 
            // ZoomInButton
            // 
            this.ZoomInButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ZoomInButton.Image = ((System.Drawing.Image)(resources.GetObject("ZoomInButton.Image")));
            this.ZoomInButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ZoomInButton.Name = "ZoomInButton";
            this.ZoomInButton.Size = new System.Drawing.Size(23, 22);
            this.ZoomInButton.Text = "Zoom In";
            this.ZoomInButton.Click += new System.EventHandler(this.ZoomInClick);
            // 
            // ZoomOutButton
            // 
            this.ZoomOutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ZoomOutButton.Enabled = false;
            this.ZoomOutButton.Image = global::Sphere_Editor.Properties.Resources.magnifier_zoom_out;
            this.ZoomOutButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ZoomOutButton.Name = "ZoomOutButton";
            this.ZoomOutButton.Size = new System.Drawing.Size(23, 22);
            this.ZoomOutButton.Text = "Zoom Out";
            this.ZoomOutButton.Click += new System.EventHandler(this.ZoomOutClick);
            // 
            // TileToolSeperator2
            // 
            this.TileToolSeperator2.Name = "TileToolSeperator2";
            this.TileToolSeperator2.Size = new System.Drawing.Size(6, 25);
            // 
            // TileUndoButton
            // 
            this.TileUndoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TileUndoButton.Enabled = false;
            this.TileUndoButton.Image = global::Sphere_Editor.Properties.Resources.arrow_undo;
            this.TileUndoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TileUndoButton.Name = "TileUndoButton";
            this.TileUndoButton.Size = new System.Drawing.Size(23, 22);
            this.TileUndoButton.Text = "Undo Action";
            this.TileUndoButton.Click += new System.EventHandler(this.TileUndoButton_Click);
            // 
            // TileRedoButton
            // 
            this.TileRedoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TileRedoButton.Enabled = false;
            this.TileRedoButton.Image = global::Sphere_Editor.Properties.Resources.arrow_redo;
            this.TileRedoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TileRedoButton.Name = "TileRedoButton";
            this.TileRedoButton.Size = new System.Drawing.Size(23, 22);
            this.TileRedoButton.Text = "Redo Action";
            this.TileRedoButton.Click += new System.EventHandler(this.TileRedoButton_Click);
            // 
            // TileToolSeperator3
            // 
            this.TileToolSeperator3.Name = "TileToolSeperator3";
            this.TileToolSeperator3.Size = new System.Drawing.Size(6, 25);
            // 
            // ZoneToolButton
            // 
            this.ZoneToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ZoneToolButton.Image = global::Sphere_Editor.Properties.Resources.zone;
            this.ZoneToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ZoneToolButton.Name = "ZoneToolButton";
            this.ZoneToolButton.Size = new System.Drawing.Size(23, 22);
            this.ZoneToolButton.Text = "Edit Zones";
            this.ZoneToolButton.Click += new System.EventHandler(this.ZoneToolButton_Click);
            // 
            // MoveEntityButton
            // 
            this.MoveEntityButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MoveEntityButton.Image = global::Sphere_Editor.Properties.Resources.arrow_inout;
            this.MoveEntityButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MoveEntityButton.Name = "MoveEntityButton";
            this.MoveEntityButton.Size = new System.Drawing.Size(23, 22);
            this.MoveEntityButton.Text = "Move Entity";
            this.MoveEntityButton.Click += new System.EventHandler(this.MoveEntityButton_Click);
            // 
            // MapPanel
            // 
            this.MapPanel.AutoSize = true;
            this.MapPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.MapPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MapPanel.Location = new System.Drawing.Point(0, 0);
            this.MapPanel.Name = "MapPanel";
            this.MapPanel.Size = new System.Drawing.Size(398, 144);
            this.MapPanel.TabIndex = 3;
            this.MapPanel.XSnap = 0;
            this.MapPanel.YSnap = 0;
            // 
            // DrawerControl
            // 
            this.DrawerControl.CanDirty = true;
            this.DrawerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DrawerControl.HelpLabel = null;
            this.DrawerControl.Location = new System.Drawing.Point(3, 3);
            this.DrawerControl.Name = "DrawerControl";
            this.DrawerControl.Size = new System.Drawing.Size(384, 170);
            this.DrawerControl.TabIndex = 5;
            // 
            // DefaultSplitter
            // 
            this.DefaultSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DefaultSplitter.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.DefaultSplitter.Location = new System.Drawing.Point(0, 25);
            this.DefaultSplitter.Name = "DefaultSplitter";
            // 
            // DefaultSplitter.Panel1
            // 
            this.DefaultSplitter.Panel1.Controls.Add(this.MapSplitter);
            // 
            // DefaultSplitter.Panel2
            // 
            this.DefaultSplitter.Panel2.Controls.Add(this.TilesetBox);
            this.DefaultSplitter.Panel2.Controls.Add(this.LayersBox);
            this.DefaultSplitter.Size = new System.Drawing.Size(560, 374);
            this.DefaultSplitter.SplitterDistance = 398;
            this.DefaultSplitter.TabIndex = 6;
            // 
            // MapSplitter
            // 
            this.MapSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MapSplitter.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.MapSplitter.Location = new System.Drawing.Point(0, 0);
            this.MapSplitter.Name = "MapSplitter";
            this.MapSplitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // MapSplitter.Panel1
            // 
            this.MapSplitter.Panel1.Controls.Add(this.MapPanel);
            this.MapSplitter.Panel1.Controls.Add(this.MapStatus);
            // 
            // MapSplitter.Panel2
            // 
            this.MapSplitter.Panel2.Controls.Add(this.tabControl1);
            this.MapSplitter.Size = new System.Drawing.Size(398, 374);
            this.MapSplitter.SplitterDistance = 168;
            this.MapSplitter.TabIndex = 6;
            // 
            // MapStatus
            // 
            this.MapStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EntityStatusLabel,
            this.TileStatusLabel,
            this.ZoomStatusLabel});
            this.MapStatus.Location = new System.Drawing.Point(0, 144);
            this.MapStatus.Name = "MapStatus";
            this.MapStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.MapStatus.Size = new System.Drawing.Size(398, 24);
            this.MapStatus.SizingGrip = false;
            this.MapStatus.TabIndex = 4;
            this.MapStatus.Text = "statusStrip1";
            // 
            // EntityStatusLabel
            // 
            this.EntityStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.EntityStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.EntityStatusLabel.Name = "EntityStatusLabel";
            this.EntityStatusLabel.Size = new System.Drawing.Size(261, 19);
            this.EntityStatusLabel.Spring = true;
            this.EntityStatusLabel.Text = "Entity: \"name\" x, y";
            this.EntityStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.EntityStatusLabel.Visible = false;
            // 
            // TileStatusLabel
            // 
            this.TileStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.TileStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.TileStatusLabel.Name = "TileStatusLabel";
            this.TileStatusLabel.Size = new System.Drawing.Size(62, 19);
            this.TileStatusLabel.Text = "Tile: (0, 0)";
            // 
            // ZoomStatusLabel
            // 
            this.ZoomStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.ZoomStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.ZoomStatusLabel.Name = "ZoomStatusLabel";
            this.ZoomStatusLabel.Size = new System.Drawing.Size(60, 19);
            this.ZoomStatusLabel.Text = "Zoom: x1";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.DrawerPage);
            this.tabControl1.Controls.Add(this.EditorPage);
            this.tabControl1.Controls.Add(this.AutosetPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(398, 202);
            this.tabControl1.TabIndex = 0;
            // 
            // DrawerPage
            // 
            this.DrawerPage.Controls.Add(this.DrawerControl);
            this.DrawerPage.Location = new System.Drawing.Point(4, 22);
            this.DrawerPage.Name = "DrawerPage";
            this.DrawerPage.Padding = new System.Windows.Forms.Padding(3);
            this.DrawerPage.Size = new System.Drawing.Size(390, 176);
            this.DrawerPage.TabIndex = 0;
            this.DrawerPage.Text = "Tile Drawer";
            this.DrawerPage.UseVisualStyleBackColor = true;
            // 
            // EditorPage
            // 
            this.EditorPage.Controls.Add(this.MainTileEditor);
            this.EditorPage.Location = new System.Drawing.Point(4, 22);
            this.EditorPage.Name = "EditorPage";
            this.EditorPage.Padding = new System.Windows.Forms.Padding(3);
            this.EditorPage.Size = new System.Drawing.Size(390, 176);
            this.EditorPage.TabIndex = 1;
            this.EditorPage.Text = "Tile Editor";
            this.EditorPage.UseVisualStyleBackColor = true;
            // 
            // MainTileEditor
            // 
            this.MainTileEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(225)))), ((int)(((byte)(243)))));
            this.MainTileEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTileEditor.Location = new System.Drawing.Point(3, 3);
            this.MainTileEditor.MinimumSize = new System.Drawing.Size(350, 280);
            this.MainTileEditor.Name = "MainTileEditor";
            this.MainTileEditor.Size = new System.Drawing.Size(384, 280);
            this.MainTileEditor.TabIndex = 0;
            this.MainTileEditor.Tile = null;
            this.MainTileEditor.Zoom = 4;
            this.MainTileEditor.Modified += new System.EventHandler(this.MainTileEditor_Modified);
            // 
            // AutosetPage
            // 
            this.AutosetPage.Controls.Add(this.AutosetEditor1);
            this.AutosetPage.Location = new System.Drawing.Point(4, 22);
            this.AutosetPage.Name = "AutosetPage";
            this.AutosetPage.Size = new System.Drawing.Size(390, 176);
            this.AutosetPage.TabIndex = 2;
            this.AutosetPage.Text = "Autosets";
            this.AutosetPage.UseVisualStyleBackColor = true;
            // 
            // AutosetEditor1
            // 
            this.AutosetEditor1.AutoScroll = true;
            this.AutosetEditor1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(225)))), ((int)(((byte)(243)))));
            this.AutosetEditor1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AutosetEditor1.CenterTile = ((short)(-1));
            this.AutosetEditor1.CenterTiles = ((System.Collections.Generic.List<short>)(resources.GetObject("AutosetEditor1.CenterTiles")));
            this.AutosetEditor1.CornerTiles = ((System.Collections.Generic.List<short>)(resources.GetObject("AutosetEditor1.CornerTiles")));
            this.AutosetEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AutosetEditor1.Location = new System.Drawing.Point(0, 0);
            this.AutosetEditor1.Name = "AutosetEditor1";
            this.AutosetEditor1.Size = new System.Drawing.Size(192, 74);
            this.AutosetEditor1.TabIndex = 0;
            this.AutosetEditor1.Tileset = null;
            this.AutosetEditor1.OnUse += new Sphere_Editor.EditorComponents.AutosetEditor.EventHandler(this.autosetEditor1_OnUse);
            // 
            // TilesetBox
            // 
            this.TilesetBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TilesetBox.Controls.Add(this.TilesetLabel);
            this.TilesetBox.Controls.Add(this.TilesetPanel);
            this.TilesetBox.Location = new System.Drawing.Point(6, 196);
            this.TilesetBox.Margin = new System.Windows.Forms.Padding(6);
            this.TilesetBox.Name = "TilesetBox";
            this.TilesetBox.Size = new System.Drawing.Size(146, 161);
            this.TilesetBox.TabIndex = 8;
            // 
            // TilesetLabel
            // 
            this.TilesetLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TilesetLabel.Font = new System.Drawing.Font("Verdana", 10.5F);
            this.TilesetLabel.ForeColor = System.Drawing.Color.MidnightBlue;
            this.TilesetLabel.Location = new System.Drawing.Point(0, 0);
            this.TilesetLabel.Name = "TilesetLabel";
            this.TilesetLabel.Size = new System.Drawing.Size(144, 23);
            this.TilesetLabel.TabIndex = 0;
            this.TilesetLabel.Text = "Tileset";
            this.TilesetLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TilesetPanel
            // 
            this.TilesetPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TilesetPanel.Location = new System.Drawing.Point(3, 26);
            this.TilesetPanel.Name = "TilesetPanel";
            this.TilesetPanel.Padding = new System.Windows.Forms.Padding(2);
            this.TilesetPanel.Size = new System.Drawing.Size(138, 130);
            this.TilesetPanel.TabIndex = 4;
            this.TilesetPanel.XSnap = 0;
            this.TilesetPanel.YSnap = 0;
            // 
            // LayersBox
            // 
            this.LayersBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LayersBox.Controls.Add(this.LayerLabel);
            this.LayersBox.Controls.Add(this.MapLayerPanel);
            this.LayersBox.Location = new System.Drawing.Point(6, 6);
            this.LayersBox.Margin = new System.Windows.Forms.Padding(6);
            this.LayersBox.Name = "LayersBox";
            this.LayersBox.Size = new System.Drawing.Size(146, 180);
            this.LayersBox.TabIndex = 7;
            // 
            // LayerLabel
            // 
            this.LayerLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.LayerLabel.Font = new System.Drawing.Font("Verdana", 10.5F);
            this.LayerLabel.ForeColor = System.Drawing.Color.MidnightBlue;
            this.LayerLabel.Location = new System.Drawing.Point(0, 0);
            this.LayerLabel.Name = "LayerLabel";
            this.LayerLabel.Size = new System.Drawing.Size(144, 23);
            this.LayerLabel.TabIndex = 1;
            this.LayerLabel.Text = "Layers";
            this.LayerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MapLayerPanel
            // 
            this.MapLayerPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.MapLayerPanel.Location = new System.Drawing.Point(3, 26);
            this.MapLayerPanel.Name = "MapLayerPanel";
            this.MapLayerPanel.Padding = new System.Windows.Forms.Padding(2);
            this.MapLayerPanel.Size = new System.Drawing.Size(138, 149);
            this.MapLayerPanel.TabIndex = 5;
            this.MapLayerPanel.XSnap = 0;
            this.MapLayerPanel.YSnap = 0;
            // 
            // Mapper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DefaultSplitter);
            this.Controls.Add(this.MapToolStrip);
            this.Name = "Mapper";
            this.Size = new System.Drawing.Size(560, 399);
            this.MapToolStrip.ResumeLayout(false);
            this.MapToolStrip.PerformLayout();
            this.DefaultSplitter.Panel1.ResumeLayout(false);
            this.DefaultSplitter.Panel2.ResumeLayout(false);
            this.DefaultSplitter.ResumeLayout(false);
            this.MapSplitter.Panel1.ResumeLayout(false);
            this.MapSplitter.Panel1.PerformLayout();
            this.MapSplitter.Panel2.ResumeLayout(false);
            this.MapSplitter.ResumeLayout(false);
            this.MapStatus.ResumeLayout(false);
            this.MapStatus.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.DrawerPage.ResumeLayout(false);
            this.EditorPage.ResumeLayout(false);
            this.AutosetPage.ResumeLayout(false);
            this.TilesetBox.ResumeLayout(false);
            this.LayersBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip MapToolStrip;
        private System.Windows.Forms.ToolStripButton TileSelectButton;
        private System.Windows.Forms.ToolStripButton TileLineButton;
        private System.Windows.Forms.ToolStripButton TileRectangleButton;
        private System.Windows.Forms.ToolStripButton TileFillButton;
        private System.Windows.Forms.ToolStripSeparator TileToolSeperator1;
        private System.Windows.Forms.ToolStripButton ZoomInButton;
        private System.Windows.Forms.ToolStripButton ZoomOutButton;
        private System.Windows.Forms.ToolStripSeparator TileToolSeperator2;
        private System.Windows.Forms.ToolStripButton TileUndoButton;
        private System.Windows.Forms.ToolStripButton TileRedoButton;
        private System.Windows.Forms.ToolStripSeparator TileToolSeperator3;
        private System.Windows.Forms.ToolStripButton ZoneToolButton;
        private EditorPanel MapPanel;
        private Drawer DrawerControl;
        private System.Windows.Forms.SplitContainer DefaultSplitter;
        private EditorPanel MapLayerPanel;
        private System.Windows.Forms.SplitContainer MapSplitter;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage DrawerPage;
        private System.Windows.Forms.TabPage EditorPage;
        private EditorComponents.TileEditor MainTileEditor;
        private System.Windows.Forms.Panel LayersBox;
        private EditorLabel LayerLabel;
        private System.Windows.Forms.Panel TilesetBox;
        private EditorLabel TilesetLabel;
        private EditorPanel TilesetPanel;
        private EditorComponents.AutosetEditor AutosetEditor1;
        private System.Windows.Forms.TabPage AutosetPage;
        private System.Windows.Forms.ToolStripButton MoveEntityButton;
        private System.Windows.Forms.StatusStrip MapStatus;
        private System.Windows.Forms.ToolStripStatusLabel TileStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel EntityStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel ZoomStatusLabel;
    }
}
