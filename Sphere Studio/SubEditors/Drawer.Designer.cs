namespace Sphere_Editor.SubEditors
{
    partial class Drawer
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Drawer));
            this.EditorToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.ColorBox1 = new Sphere_Editor.Forms.ColorPicker.ColorBox();
            this.ColorBox2 = new Sphere_Editor.Forms.ColorPicker.ColorBox();
            this.DrawerPanel = new System.Windows.Forms.Panel();
            this.ImagePanel = new Sphere_Editor.EditorPanel();
            this.ImageEditor = new Sphere_Editor.EditorComponents.ImageEditorControl();
            this.DrawToolStrip = new System.Windows.Forms.ToolStrip();
            this.PencilButton = new System.Windows.Forms.ToolStripButton();
            this.LineButton = new System.Windows.Forms.ToolStripButton();
            this.RectangleButton = new System.Windows.Forms.ToolStripButton();
            this.FillButton = new System.Windows.Forms.ToolStripButton();
            this.PanButton = new System.Windows.Forms.ToolStripButton();
            this.OutlineButton = new System.Windows.Forms.ToolStripButton();
            this.DrawSeperator = new System.Windows.Forms.ToolStripSeparator();
            this.UndoButton = new System.Windows.Forms.ToolStripButton();
            this.RedoButton = new System.Windows.Forms.ToolStripButton();
            this.DrawSeperator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ZoomInButton = new System.Windows.Forms.ToolStripButton();
            this.ZoomOutButton = new System.Windows.Forms.ToolStripButton();
            this.DrawSeperator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ShowGridButton = new System.Windows.Forms.ToolStripButton();
            this.EditorStatus = new System.Windows.Forms.StatusStrip();
            this.ZoomLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.LocationLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.FilterProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.EditorPanel = new System.Windows.Forms.Panel();
            this.PalettePanel = new System.Windows.Forms.Panel();
            this.DynaPalette = new Sphere_Editor.Forms.ColorPicker.DynamicPalette();
            this.PaletteLabel = new Sphere_Editor.EditorLabel();
            this.PaletteStatus = new System.Windows.Forms.StatusStrip();
            this.AlphaLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ColorSelectionPanel = new System.Windows.Forms.Panel();
            this.ColorFlow = new System.Windows.Forms.FlowLayoutPanel();
            this.ColorLabel = new Sphere_Editor.EditorLabel();
            this.AlphaTracker = new System.Windows.Forms.TrackBar();
            this.ImageLayerHolder = new System.Windows.Forms.Panel();
            this.ImageLayersPanel = new System.Windows.Forms.Panel();
            this.LayersPanel = new Sphere_Editor.EditorPanel();
            this.LayerLabel = new Sphere_Editor.EditorLabel();
            this.DrawerPanel.SuspendLayout();
            this.ImagePanel.SuspendLayout();
            this.DrawToolStrip.SuspendLayout();
            this.EditorStatus.SuspendLayout();
            this.EditorPanel.SuspendLayout();
            this.PalettePanel.SuspendLayout();
            this.PaletteStatus.SuspendLayout();
            this.ColorSelectionPanel.SuspendLayout();
            this.ColorFlow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AlphaTracker)).BeginInit();
            this.ImageLayerHolder.SuspendLayout();
            this.ImageLayersPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // EditorToolTip
            // 
            this.EditorToolTip.AutoPopDelay = 5000;
            this.EditorToolTip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(216)))), ((int)(((byte)(249)))));
            this.EditorToolTip.InitialDelay = 750;
            this.EditorToolTip.ReshowDelay = 100;
            this.EditorToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.EditorToolTip.ToolTipTitle = "Editor Help";
            // 
            // ColorBox1
            // 
            this.ColorBox1.Location = new System.Drawing.Point(3, 3);
            this.ColorBox1.Name = "ColorBox1";
            this.ColorBox1.Selected = false;
            this.ColorBox1.SelectedColor = System.Drawing.Color.White;
            this.ColorBox1.Size = new System.Drawing.Size(64, 48);
            this.ColorBox1.TabIndex = 6;
            this.EditorToolTip.SetToolTip(this.ColorBox1, "Double click to set Primary Color.");
            this.ColorBox1.ColorChanged += new System.EventHandler(this.ColorUpdated);
            this.ColorBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Color1_MouseClick);
            // 
            // ColorBox2
            // 
            this.ColorBox2.Location = new System.Drawing.Point(73, 3);
            this.ColorBox2.Name = "ColorBox2";
            this.ColorBox2.Selected = false;
            this.ColorBox2.SelectedColor = System.Drawing.Color.White;
            this.ColorBox2.Size = new System.Drawing.Size(64, 48);
            this.ColorBox2.TabIndex = 7;
            this.EditorToolTip.SetToolTip(this.ColorBox2, "Double click to set Secondary Color.");
            this.ColorBox2.ColorChanged += new System.EventHandler(this.ColorUpdated);
            this.ColorBox2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Color2_MouseClick);
            // 
            // DrawerPanel
            // 
            this.DrawerPanel.Controls.Add(this.ImagePanel);
            this.DrawerPanel.Controls.Add(this.DrawToolStrip);
            this.DrawerPanel.Controls.Add(this.EditorStatus);
            this.DrawerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DrawerPanel.Location = new System.Drawing.Point(134, 0);
            this.DrawerPanel.Name = "DrawerPanel";
            this.DrawerPanel.Size = new System.Drawing.Size(312, 385);
            this.DrawerPanel.TabIndex = 3;
            // 
            // ImagePanel
            // 
            this.ImagePanel.AutoScroll = true;
            this.ImagePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.ImagePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ImagePanel.Controls.Add(this.ImageEditor);
            this.ImagePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImagePanel.Location = new System.Drawing.Point(0, 25);
            this.ImagePanel.Name = "ImagePanel";
            this.ImagePanel.Size = new System.Drawing.Size(312, 336);
            this.ImagePanel.TabIndex = 2;
            this.ImagePanel.XSnap = 0;
            this.ImagePanel.YSnap = 0;
            this.ImagePanel.Resize += new System.EventHandler(this.ImagePanel_Resize);
            // 
            // ImageEditor
            // 
            this.ImageEditor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ImageEditor.AutoScroll = true;
            this.ImageEditor.BackColor = System.Drawing.Color.Transparent;
            this.ImageEditor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ImageEditor.Cursor = System.Windows.Forms.Cursors.Default;
            this.ImageEditor.DrawColor = System.Drawing.Color.Empty;
            this.ImageEditor.DynaPalette = null;
            this.ImageEditor.LayerVisibility = ((System.Collections.Generic.List<bool>)(resources.GetObject("ImageEditor.LayerVisibility")));
            this.ImageEditor.Location = new System.Drawing.Point(116, 128);
            this.ImageEditor.LocationLabel = null;
            this.ImageEditor.Name = "ImageEditor";
            this.ImageEditor.Outline = false;
            this.ImageEditor.Size = new System.Drawing.Size(80, 80);
            this.ImageEditor.TabIndex = 0;
            this.ImageEditor.ToolNum = 0;
            this.ImageEditor.ImageEdited += new Sphere_Editor.EditorComponents.ImageEditorControl.EventHandler(this.ImageEditor_ImageEdited);
            this.ImageEditor.ColorChanged += new Sphere_Editor.EditorComponents.ImageEditorControl.EventHandler(this.ImageEditor_ColorChanged);
            // 
            // DrawToolStrip
            // 
            this.DrawToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.DrawToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PencilButton,
            this.LineButton,
            this.RectangleButton,
            this.FillButton,
            this.PanButton,
            this.OutlineButton,
            this.DrawSeperator,
            this.UndoButton,
            this.RedoButton,
            this.DrawSeperator2,
            this.ZoomInButton,
            this.ZoomOutButton,
            this.DrawSeperator3,
            this.ShowGridButton});
            this.DrawToolStrip.Location = new System.Drawing.Point(0, 0);
            this.DrawToolStrip.Name = "DrawToolStrip";
            this.DrawToolStrip.Padding = new System.Windows.Forms.Padding(5, 0, 1, 0);
            this.DrawToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.DrawToolStrip.Size = new System.Drawing.Size(312, 25);
            this.DrawToolStrip.TabIndex = 2;
            // 
            // PencilButton
            // 
            this.PencilButton.Checked = true;
            this.PencilButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.PencilButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.PencilButton.Image = global::Sphere_Editor.Properties.Resources.pencil;
            this.PencilButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PencilButton.Name = "PencilButton";
            this.PencilButton.Size = new System.Drawing.Size(23, 22);
            this.PencilButton.Text = "Pencil Tool";
            this.PencilButton.Click += new System.EventHandler(this.PencilButton_Click);
            // 
            // LineButton
            // 
            this.LineButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.LineButton.Image = global::Sphere_Editor.Properties.Resources.line;
            this.LineButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LineButton.Name = "LineButton";
            this.LineButton.Size = new System.Drawing.Size(23, 22);
            this.LineButton.Text = "Line Tool";
            this.LineButton.Click += new System.EventHandler(this.LineButton_Click);
            // 
            // RectangleButton
            // 
            this.RectangleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RectangleButton.Image = global::Sphere_Editor.Properties.Resources.rectangle;
            this.RectangleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RectangleButton.Name = "RectangleButton";
            this.RectangleButton.Size = new System.Drawing.Size(23, 22);
            this.RectangleButton.Text = "Rectangle Tool";
            this.RectangleButton.Click += new System.EventHandler(this.RectangleButton_Click);
            // 
            // FillButton
            // 
            this.FillButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.FillButton.Image = global::Sphere_Editor.Properties.Resources.paintcan;
            this.FillButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FillButton.Name = "FillButton";
            this.FillButton.Size = new System.Drawing.Size(23, 22);
            this.FillButton.Text = "Fill Tool";
            this.FillButton.Click += new System.EventHandler(this.FillButton_Click);
            // 
            // PanButton
            // 
            this.PanButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.PanButton.Image = global::Sphere_Editor.Properties.Resources.arrow_inout;
            this.PanButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PanButton.Name = "PanButton";
            this.PanButton.Size = new System.Drawing.Size(23, 22);
            this.PanButton.Text = "Pan Image";
            this.PanButton.Click += new System.EventHandler(this.PanButton_Click);
            // 
            // OutlineButton
            // 
            this.OutlineButton.CheckOnClick = true;
            this.OutlineButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.OutlineButton.Image = global::Sphere_Editor.Properties.Resources.outline;
            this.OutlineButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OutlineButton.Name = "OutlineButton";
            this.OutlineButton.Size = new System.Drawing.Size(23, 22);
            this.OutlineButton.Text = "Use Outline";
            this.OutlineButton.Click += new System.EventHandler(this.OutlineButton_Click);
            // 
            // DrawSeperator
            // 
            this.DrawSeperator.Name = "DrawSeperator";
            this.DrawSeperator.Size = new System.Drawing.Size(6, 25);
            // 
            // UndoButton
            // 
            this.UndoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.UndoButton.Enabled = false;
            this.UndoButton.Image = global::Sphere_Editor.Properties.Resources.arrow_undo;
            this.UndoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.UndoButton.Name = "UndoButton";
            this.UndoButton.Size = new System.Drawing.Size(23, 22);
            this.UndoButton.Text = "Undo Action";
            this.UndoButton.Click += new System.EventHandler(this.UndoButton_Click);
            // 
            // RedoButton
            // 
            this.RedoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RedoButton.Enabled = false;
            this.RedoButton.Image = global::Sphere_Editor.Properties.Resources.arrow_redo;
            this.RedoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RedoButton.Name = "RedoButton";
            this.RedoButton.Size = new System.Drawing.Size(23, 22);
            this.RedoButton.Text = "Redo Action";
            this.RedoButton.Click += new System.EventHandler(this.RedoButton_Click);
            // 
            // DrawSeperator2
            // 
            this.DrawSeperator2.Name = "DrawSeperator2";
            this.DrawSeperator2.Size = new System.Drawing.Size(6, 25);
            // 
            // ZoomInButton
            // 
            this.ZoomInButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ZoomInButton.Image = global::Sphere_Editor.Properties.Resources.magnifier_zoom_in;
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
            // DrawSeperator3
            // 
            this.DrawSeperator3.Name = "DrawSeperator3";
            this.DrawSeperator3.Size = new System.Drawing.Size(6, 25);
            // 
            // ShowGridButton
            // 
            this.ShowGridButton.CheckOnClick = true;
            this.ShowGridButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ShowGridButton.Image = global::Sphere_Editor.Properties.Resources.grid;
            this.ShowGridButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ShowGridButton.Name = "ShowGridButton";
            this.ShowGridButton.Size = new System.Drawing.Size(23, 22);
            this.ShowGridButton.Text = "Display Grid";
            this.ShowGridButton.Click += new System.EventHandler(this.ShowGridButton_Click);
            // 
            // EditorStatus
            // 
            this.EditorStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ZoomLabel,
            this.LocationLabel,
            this.FilterProgress});
            this.EditorStatus.Location = new System.Drawing.Point(0, 361);
            this.EditorStatus.Name = "EditorStatus";
            this.EditorStatus.Size = new System.Drawing.Size(312, 24);
            this.EditorStatus.SizingGrip = false;
            this.EditorStatus.TabIndex = 1;
            this.EditorStatus.Text = "Image Status";
            // 
            // ZoomLabel
            // 
            this.ZoomLabel.BackColor = System.Drawing.SystemColors.Control;
            this.ZoomLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.ZoomLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.ZoomLabel.Name = "ZoomLabel";
            this.ZoomLabel.Size = new System.Drawing.Size(63, 19);
            this.ZoomLabel.Text = "Zoom:  1x";
            // 
            // LocationLabel
            // 
            this.LocationLabel.BackColor = System.Drawing.SystemColors.Control;
            this.LocationLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.LocationLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.LocationLabel.Name = "LocationLabel";
            this.LocationLabel.Size = new System.Drawing.Size(81, 19);
            this.LocationLabel.Text = "Location: 0, 0";
            // 
            // FilterProgress
            // 
            this.FilterProgress.Name = "FilterProgress";
            this.FilterProgress.Size = new System.Drawing.Size(100, 18);
            this.FilterProgress.Visible = false;
            // 
            // EditorPanel
            // 
            this.EditorPanel.AutoScroll = true;
            this.EditorPanel.Controls.Add(this.PalettePanel);
            this.EditorPanel.Controls.Add(this.PaletteStatus);
            this.EditorPanel.Controls.Add(this.ColorSelectionPanel);
            this.EditorPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.EditorPanel.Location = new System.Drawing.Point(446, 0);
            this.EditorPanel.Name = "EditorPanel";
            this.EditorPanel.Size = new System.Drawing.Size(223, 385);
            this.EditorPanel.TabIndex = 0;
            // 
            // PalettePanel
            // 
            this.PalettePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.PalettePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.PalettePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PalettePanel.Controls.Add(this.DynaPalette);
            this.PalettePanel.Controls.Add(this.PaletteLabel);
            this.PalettePanel.Location = new System.Drawing.Point(9, 155);
            this.PalettePanel.Margin = new System.Windows.Forms.Padding(6);
            this.PalettePanel.Name = "PalettePanel";
            this.PalettePanel.Size = new System.Drawing.Size(208, 202);
            this.PalettePanel.TabIndex = 8;
            // 
            // DynaPalette
            // 
            this.DynaPalette.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.DynaPalette.BackColor = System.Drawing.SystemColors.Control;
            this.DynaPalette.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DynaPalette.Location = new System.Drawing.Point(9, 29);
            this.DynaPalette.Margin = new System.Windows.Forms.Padding(6);
            this.DynaPalette.Name = "DynaPalette";
            this.DynaPalette.Size = new System.Drawing.Size(191, 165);
            this.DynaPalette.TabIndex = 0;
            this.DynaPalette.Resize += new System.EventHandler(this.DynaPalette_Resize);
            // 
            // PaletteLabel
            // 
            this.PaletteLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(225)))), ((int)(((byte)(243)))));
            this.PaletteLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.PaletteLabel.Font = new System.Drawing.Font("Verdana", 10.5F);
            this.PaletteLabel.ForeColor = System.Drawing.Color.MidnightBlue;
            this.PaletteLabel.Location = new System.Drawing.Point(0, 0);
            this.PaletteLabel.Name = "PaletteLabel";
            this.PaletteLabel.Size = new System.Drawing.Size(206, 23);
            this.PaletteLabel.TabIndex = 12;
            this.PaletteLabel.Text = "Drawing Palette";
            this.PaletteLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PaletteStatus
            // 
            this.PaletteStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AlphaLabel});
            this.PaletteStatus.Location = new System.Drawing.Point(0, 363);
            this.PaletteStatus.Name = "PaletteStatus";
            this.PaletteStatus.Size = new System.Drawing.Size(223, 22);
            this.PaletteStatus.SizingGrip = false;
            this.PaletteStatus.TabIndex = 1;
            this.PaletteStatus.Text = "Palette Status";
            // 
            // AlphaLabel
            // 
            this.AlphaLabel.Name = "AlphaLabel";
            this.AlphaLabel.Size = new System.Drawing.Size(62, 17);
            this.AlphaLabel.Text = "Alpha: 255";
            // 
            // ColorSelectionPanel
            // 
            this.ColorSelectionPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ColorSelectionPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ColorSelectionPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ColorSelectionPanel.Controls.Add(this.ColorFlow);
            this.ColorSelectionPanel.Controls.Add(this.ColorLabel);
            this.ColorSelectionPanel.Controls.Add(this.AlphaTracker);
            this.ColorSelectionPanel.Location = new System.Drawing.Point(9, 6);
            this.ColorSelectionPanel.Margin = new System.Windows.Forms.Padding(6);
            this.ColorSelectionPanel.Name = "ColorSelectionPanel";
            this.ColorSelectionPanel.Size = new System.Drawing.Size(208, 144);
            this.ColorSelectionPanel.TabIndex = 10;
            // 
            // ColorFlow
            // 
            this.ColorFlow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ColorFlow.BackColor = System.Drawing.SystemColors.Control;
            this.ColorFlow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ColorFlow.Controls.Add(this.ColorBox1);
            this.ColorFlow.Controls.Add(this.ColorBox2);
            this.ColorFlow.Location = new System.Drawing.Point(56, 28);
            this.ColorFlow.Name = "ColorFlow";
            this.ColorFlow.Size = new System.Drawing.Size(144, 108);
            this.ColorFlow.TabIndex = 8;
            // 
            // ColorLabel
            // 
            this.ColorLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(225)))), ((int)(((byte)(243)))));
            this.ColorLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ColorLabel.Font = new System.Drawing.Font("Verdana", 10.5F);
            this.ColorLabel.ForeColor = System.Drawing.Color.MidnightBlue;
            this.ColorLabel.Location = new System.Drawing.Point(0, 0);
            this.ColorLabel.Name = "ColorLabel";
            this.ColorLabel.Size = new System.Drawing.Size(206, 23);
            this.ColorLabel.TabIndex = 13;
            this.ColorLabel.Text = "Drawing Colors";
            this.ColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AlphaTracker
            // 
            this.AlphaTracker.BackColor = System.Drawing.SystemColors.Control;
            this.AlphaTracker.Location = new System.Drawing.Point(5, 28);
            this.AlphaTracker.Maximum = 255;
            this.AlphaTracker.Name = "AlphaTracker";
            this.AlphaTracker.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.AlphaTracker.Size = new System.Drawing.Size(45, 108);
            this.AlphaTracker.TabIndex = 2;
            this.AlphaTracker.TickFrequency = 5;
            this.AlphaTracker.Value = 255;
            this.AlphaTracker.Scroll += new System.EventHandler(this.AlphaTracker_Scroll);
            // 
            // ImageLayerHolder
            // 
            this.ImageLayerHolder.Controls.Add(this.ImageLayersPanel);
            this.ImageLayerHolder.Dock = System.Windows.Forms.DockStyle.Left;
            this.ImageLayerHolder.Location = new System.Drawing.Point(0, 0);
            this.ImageLayerHolder.Name = "ImageLayerHolder";
            this.ImageLayerHolder.Size = new System.Drawing.Size(134, 385);
            this.ImageLayerHolder.TabIndex = 4;
            // 
            // ImageLayersPanel
            // 
            this.ImageLayersPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ImageLayersPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ImageLayersPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ImageLayersPanel.Controls.Add(this.LayersPanel);
            this.ImageLayersPanel.Controls.Add(this.LayerLabel);
            this.ImageLayersPanel.Location = new System.Drawing.Point(6, 7);
            this.ImageLayersPanel.Margin = new System.Windows.Forms.Padding(6);
            this.ImageLayersPanel.Name = "ImageLayersPanel";
            this.ImageLayersPanel.Size = new System.Drawing.Size(119, 372);
            this.ImageLayersPanel.TabIndex = 3;
            // 
            // LayersPanel
            // 
            this.LayersPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.LayersPanel.AutoScroll = true;
            this.LayersPanel.BackColor = System.Drawing.SystemColors.Control;
            this.LayersPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LayersPanel.Location = new System.Drawing.Point(6, 29);
            this.LayersPanel.Margin = new System.Windows.Forms.Padding(6);
            this.LayersPanel.Name = "LayersPanel";
            this.LayersPanel.Size = new System.Drawing.Size(105, 335);
            this.LayersPanel.TabIndex = 2;
            this.LayersPanel.XSnap = 0;
            this.LayersPanel.YSnap = 0;
            // 
            // LayerLabel
            // 
            this.LayerLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(225)))), ((int)(((byte)(243)))));
            this.LayerLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.LayerLabel.Font = new System.Drawing.Font("Verdana", 10.5F);
            this.LayerLabel.ForeColor = System.Drawing.Color.MidnightBlue;
            this.LayerLabel.Location = new System.Drawing.Point(0, 0);
            this.LayerLabel.Name = "LayerLabel";
            this.LayerLabel.Size = new System.Drawing.Size(117, 23);
            this.LayerLabel.TabIndex = 1;
            this.LayerLabel.Text = "Image Layers";
            this.LayerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Drawer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DrawerPanel);
            this.Controls.Add(this.EditorPanel);
            this.Controls.Add(this.ImageLayerHolder);
            this.Name = "Drawer";
            this.Size = new System.Drawing.Size(669, 385);
            this.DrawerPanel.ResumeLayout(false);
            this.DrawerPanel.PerformLayout();
            this.ImagePanel.ResumeLayout(false);
            this.DrawToolStrip.ResumeLayout(false);
            this.DrawToolStrip.PerformLayout();
            this.EditorStatus.ResumeLayout(false);
            this.EditorStatus.PerformLayout();
            this.EditorPanel.ResumeLayout(false);
            this.EditorPanel.PerformLayout();
            this.PalettePanel.ResumeLayout(false);
            this.PaletteStatus.ResumeLayout(false);
            this.PaletteStatus.PerformLayout();
            this.ColorSelectionPanel.ResumeLayout(false);
            this.ColorSelectionPanel.PerformLayout();
            this.ColorFlow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AlphaTracker)).EndInit();
            this.ImageLayerHolder.ResumeLayout(false);
            this.ImageLayersPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sphere_Editor.EditorComponents.ImageEditorControl ImageEditor;
        private System.Windows.Forms.ToolStrip DrawToolStrip;
        private System.Windows.Forms.ToolStripButton PencilButton;
        private System.Windows.Forms.ToolStripButton LineButton;
        private System.Windows.Forms.ToolStripButton RectangleButton;
        private System.Windows.Forms.ToolStripButton FillButton;
        private System.Windows.Forms.ToolStripSeparator DrawSeperator;
        private System.Windows.Forms.ToolStripButton ZoomInButton;
        private System.Windows.Forms.ToolStripButton ZoomOutButton;
        private System.Windows.Forms.ToolStripSeparator DrawSeperator3;
        private System.Windows.Forms.ToolStripButton ShowGridButton;
        private System.Windows.Forms.Panel EditorPanel;
        private System.Windows.Forms.TrackBar AlphaTracker;
        private System.Windows.Forms.ToolStripSeparator DrawSeperator2;
        private System.Windows.Forms.ToolStripButton UndoButton;
        private System.Windows.Forms.ToolStripButton RedoButton;
        private Forms.ColorPicker.ColorBox ColorBox2;
        private Forms.ColorPicker.ColorBox ColorBox1;
        private System.Windows.Forms.Panel PalettePanel;
        private System.Windows.Forms.Panel ColorSelectionPanel;
        private Forms.ColorPicker.DynamicPalette DynaPalette;
        private System.Windows.Forms.StatusStrip EditorStatus;
        private System.Windows.Forms.ToolStripStatusLabel ZoomLabel;
        private System.Windows.Forms.ToolStripStatusLabel LocationLabel;
        private System.Windows.Forms.ToolStripProgressBar FilterProgress;
        private EditorPanel ImagePanel;
        private System.Windows.Forms.ToolStripButton PanButton;
        private System.Windows.Forms.StatusStrip PaletteStatus;
        private System.Windows.Forms.ToolStripStatusLabel AlphaLabel;
        private System.Windows.Forms.ToolTip EditorToolTip;
        private System.Windows.Forms.Panel DrawerPanel;
        private System.Windows.Forms.ToolStripButton OutlineButton;
        private EditorLabel PaletteLabel;
        private System.Windows.Forms.FlowLayoutPanel ColorFlow;
        private EditorLabel ColorLabel;
        private System.Windows.Forms.Panel ImageLayerHolder;
        private EditorLabel LayerLabel;
        private EditorPanel LayersPanel;
        private System.Windows.Forms.Panel ImageLayersPanel;
    }
}
