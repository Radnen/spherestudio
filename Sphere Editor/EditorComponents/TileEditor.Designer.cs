namespace Sphere_Editor.EditorComponents
{
    partial class TileEditor
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
                if (_tileset != null) _tileset.Dispose();
                if (_obstruction_layer != null) _obstruction_layer.Dispose();
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
            this.EditorLabel = new System.Windows.Forms.Label();
            this.ImageHolder = new System.Windows.Forms.Panel();
            this.TileImage = new Sphere_Editor.EditorPanel();
            this.ZoomStatusStrip = new System.Windows.Forms.StatusStrip();
            this.ZoomLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.TileToolStrip = new System.Windows.Forms.ToolStrip();
            this.LineButton = new System.Windows.Forms.ToolStripButton();
            this.RectangleButton = new System.Windows.Forms.ToolStripButton();
            this.ClearObstButton = new System.Windows.Forms.ToolStripButton();
            this.Separator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ZoomInButton = new System.Windows.Forms.ToolStripButton();
            this.ZoomOutButton = new System.Windows.Forms.ToolStripButton();
            this.Separator2 = new System.Windows.Forms.ToolStripSeparator();
            this.PresetButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.NoneItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FullItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BottomHalfItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TopHalfItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LeftHalfItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RightHalfItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UpperLeftItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UpperRightItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LowerRightItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LowerLeftItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Seperator3 = new System.Windows.Forms.ToolStripSeparator();
            this.PlayAnimButton = new System.Windows.Forms.ToolStripButton();
            this.StopAnimButton = new System.Windows.Forms.ToolStripButton();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.AnimateCheckBox = new System.Windows.Forms.CheckBox();
            this.NextTileTextBox = new System.Windows.Forms.TextBox();
            this.DelayTextBox = new System.Windows.Forms.TextBox();
            this.NextTileLabel = new System.Windows.Forms.Label();
            this.DelayLabel = new System.Windows.Forms.Label();
            this.MainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.TileEditorPanel = new System.Windows.Forms.Panel();
            this.ButtonPanel = new System.Windows.Forms.Panel();
            this.BackButton = new System.Windows.Forms.Button();
            this.NextButton = new System.Windows.Forms.Button();
            this.NamePanel = new System.Windows.Forms.Panel();
            this.NameLabel = new Sphere_Editor.EditorLabel();
            this.AnimationPanel = new System.Windows.Forms.Panel();
            this.PropPanel = new System.Windows.Forms.Panel();
            this.AnimLabel = new System.Windows.Forms.Label();
            this.ObstLabel = new Sphere_Editor.EditorLabel();
            this.ImageContextStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ZoomInItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ZoomOutItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ClearItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImageHolder.SuspendLayout();
            this.ZoomStatusStrip.SuspendLayout();
            this.TileToolStrip.SuspendLayout();
            this.MainSplitContainer.Panel1.SuspendLayout();
            this.MainSplitContainer.Panel2.SuspendLayout();
            this.MainSplitContainer.SuspendLayout();
            this.TileEditorPanel.SuspendLayout();
            this.ButtonPanel.SuspendLayout();
            this.NamePanel.SuspendLayout();
            this.AnimationPanel.SuspendLayout();
            this.PropPanel.SuspendLayout();
            this.ImageContextStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // EditorLabel
            // 
            this.EditorLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.EditorLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.EditorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditorLabel.Image = global::Sphere_Editor.Properties.Resources.BarImage;
            this.EditorLabel.Location = new System.Drawing.Point(0, 0);
            this.EditorLabel.Name = "EditorLabel";
            this.EditorLabel.Size = new System.Drawing.Size(277, 23);
            this.EditorLabel.TabIndex = 0;
            this.EditorLabel.Text = "Tile Editor #(000)";
            this.EditorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ImageHolder
            // 
            this.ImageHolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.ImageHolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ImageHolder.Controls.Add(this.TileImage);
            this.ImageHolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImageHolder.Location = new System.Drawing.Point(30, 23);
            this.ImageHolder.Name = "ImageHolder";
            this.ImageHolder.Size = new System.Drawing.Size(367, 292);
            this.ImageHolder.TabIndex = 1;
            this.ImageHolder.Resize += new System.EventHandler(this.ImageHolder_Resize);
            // 
            // TileImage
            // 
            this.TileImage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TileImage.BackgroundImage = global::Sphere_Editor.Properties.Resources.editbg2;
            this.TileImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TileImage.Location = new System.Drawing.Point(150, 103);
            this.TileImage.Name = "TileImage";
            this.TileImage.Size = new System.Drawing.Size(64, 64);
            this.TileImage.TabIndex = 0;
            this.TileImage.XSnap = 0;
            this.TileImage.YSnap = 0;
            this.TileImage.Paint += new System.Windows.Forms.PaintEventHandler(this.TileImage_Paint);
            this.TileImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TileImage_MouseDown);
            this.TileImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TileImage_MouseMove);
            this.TileImage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TileImage_MouseUp);
            // 
            // ZoomStatusStrip
            // 
            this.ZoomStatusStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ZoomStatusStrip.BackgroundImage = global::Sphere_Editor.Properties.Resources.BarImage;
            this.ZoomStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ZoomLabel});
            this.ZoomStatusStrip.Location = new System.Drawing.Point(0, 315);
            this.ZoomStatusStrip.Name = "ZoomStatusStrip";
            this.ZoomStatusStrip.Size = new System.Drawing.Size(397, 22);
            this.ZoomStatusStrip.SizingGrip = false;
            this.ZoomStatusStrip.TabIndex = 2;
            this.ZoomStatusStrip.Text = "statusStrip1";
            // 
            // ZoomLabel
            // 
            this.ZoomLabel.BackColor = System.Drawing.Color.Transparent;
            this.ZoomLabel.Name = "ZoomLabel";
            this.ZoomLabel.Size = new System.Drawing.Size(56, 17);
            this.ZoomLabel.Text = "Zoom: 4x";
            // 
            // TileToolStrip
            // 
            this.TileToolStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.TileToolStrip.Dock = System.Windows.Forms.DockStyle.Left;
            this.TileToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.TileToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LineButton,
            this.RectangleButton,
            this.ClearObstButton,
            this.Separator1,
            this.ZoomInButton,
            this.ZoomOutButton,
            this.Separator2,
            this.PresetButton,
            this.Seperator3,
            this.PlayAnimButton,
            this.StopAnimButton});
            this.TileToolStrip.Location = new System.Drawing.Point(0, 23);
            this.TileToolStrip.Name = "TileToolStrip";
            this.TileToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.TileToolStrip.Size = new System.Drawing.Size(30, 292);
            this.TileToolStrip.TabIndex = 2;
            this.TileToolStrip.Text = "TileToolStrip";
            // 
            // LineButton
            // 
            this.LineButton.Checked = true;
            this.LineButton.CheckOnClick = true;
            this.LineButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.LineButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.LineButton.Image = global::Sphere_Editor.Properties.Resources.line;
            this.LineButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LineButton.Name = "LineButton";
            this.LineButton.Size = new System.Drawing.Size(29, 20);
            this.LineButton.Text = "Line Obstruction";
            this.LineButton.Click += new System.EventHandler(this.LineButton_Click);
            // 
            // RectangleButton
            // 
            this.RectangleButton.CheckOnClick = true;
            this.RectangleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RectangleButton.Image = global::Sphere_Editor.Properties.Resources.rectangle;
            this.RectangleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RectangleButton.Name = "RectangleButton";
            this.RectangleButton.Size = new System.Drawing.Size(29, 20);
            this.RectangleButton.Text = "Rectangle Obstruction";
            this.RectangleButton.Click += new System.EventHandler(this.RectangleButton_Click);
            // 
            // ClearObstButton
            // 
            this.ClearObstButton.CheckOnClick = true;
            this.ClearObstButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ClearObstButton.Image = global::Sphere_Editor.Properties.Resources.delete;
            this.ClearObstButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ClearObstButton.Name = "ClearObstButton";
            this.ClearObstButton.Size = new System.Drawing.Size(29, 20);
            this.ClearObstButton.Text = "Clear Obstructions";
            this.ClearObstButton.Click += new System.EventHandler(this.ClearObstButton_Click);
            // 
            // Separator1
            // 
            this.Separator1.Name = "Separator1";
            this.Separator1.Size = new System.Drawing.Size(29, 6);
            // 
            // ZoomInButton
            // 
            this.ZoomInButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ZoomInButton.Image = global::Sphere_Editor.Properties.Resources.magnifier_zoom_in;
            this.ZoomInButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ZoomInButton.Name = "ZoomInButton";
            this.ZoomInButton.Size = new System.Drawing.Size(29, 20);
            this.ZoomInButton.Text = "Zoom In";
            this.ZoomInButton.Click += new System.EventHandler(this.ZoomInButton_Click);
            // 
            // ZoomOutButton
            // 
            this.ZoomOutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ZoomOutButton.Image = global::Sphere_Editor.Properties.Resources.magnifier_zoom_out;
            this.ZoomOutButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ZoomOutButton.Name = "ZoomOutButton";
            this.ZoomOutButton.Size = new System.Drawing.Size(29, 20);
            this.ZoomOutButton.Text = "Zoom Out";
            this.ZoomOutButton.Click += new System.EventHandler(this.ZoomOutButton_Click);
            // 
            // Separator2
            // 
            this.Separator2.Name = "Separator2";
            this.Separator2.Size = new System.Drawing.Size(29, 6);
            // 
            // PresetButton
            // 
            this.PresetButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.PresetButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NoneItem,
            this.FullItem,
            this.BottomHalfItem,
            this.TopHalfItem,
            this.LeftHalfItem,
            this.RightHalfItem,
            this.UpperLeftItem,
            this.UpperRightItem,
            this.LowerRightItem,
            this.LowerLeftItem});
            this.PresetButton.Image = global::Sphere_Editor.Properties.Resources.add;
            this.PresetButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PresetButton.Name = "PresetButton";
            this.PresetButton.Size = new System.Drawing.Size(27, 20);
            this.PresetButton.Text = "Presets";
            // 
            // NoneItem
            // 
            this.NoneItem.Image = global::Sphere_Editor.Properties.Resources.cross;
            this.NoneItem.Name = "NoneItem";
            this.NoneItem.Size = new System.Drawing.Size(152, 22);
            this.NoneItem.Text = "None";
            this.NoneItem.Click += new System.EventHandler(this.ClearItem_Click);
            // 
            // FullItem
            // 
            this.FullItem.Image = global::Sphere_Editor.Properties.Resources.rectangle;
            this.FullItem.Name = "FullItem";
            this.FullItem.Size = new System.Drawing.Size(152, 22);
            this.FullItem.Text = "Full";
            this.FullItem.Click += new System.EventHandler(this.FullItem_Click);
            // 
            // BottomHalfItem
            // 
            this.BottomHalfItem.Name = "BottomHalfItem";
            this.BottomHalfItem.Size = new System.Drawing.Size(152, 22);
            this.BottomHalfItem.Text = "Bottom Half";
            this.BottomHalfItem.Visible = false;
            // 
            // TopHalfItem
            // 
            this.TopHalfItem.Name = "TopHalfItem";
            this.TopHalfItem.Size = new System.Drawing.Size(152, 22);
            this.TopHalfItem.Text = "Top Half";
            this.TopHalfItem.Visible = false;
            // 
            // LeftHalfItem
            // 
            this.LeftHalfItem.Name = "LeftHalfItem";
            this.LeftHalfItem.Size = new System.Drawing.Size(152, 22);
            this.LeftHalfItem.Text = "Left Half";
            this.LeftHalfItem.Visible = false;
            // 
            // RightHalfItem
            // 
            this.RightHalfItem.Name = "RightHalfItem";
            this.RightHalfItem.Size = new System.Drawing.Size(152, 22);
            this.RightHalfItem.Text = "Right Half";
            this.RightHalfItem.Visible = false;
            // 
            // UpperLeftItem
            // 
            this.UpperLeftItem.Name = "UpperLeftItem";
            this.UpperLeftItem.Size = new System.Drawing.Size(152, 22);
            this.UpperLeftItem.Text = "Upper Left";
            this.UpperLeftItem.Visible = false;
            // 
            // UpperRightItem
            // 
            this.UpperRightItem.Name = "UpperRightItem";
            this.UpperRightItem.Size = new System.Drawing.Size(152, 22);
            this.UpperRightItem.Text = "Upper Right";
            this.UpperRightItem.Visible = false;
            // 
            // LowerRightItem
            // 
            this.LowerRightItem.Name = "LowerRightItem";
            this.LowerRightItem.Size = new System.Drawing.Size(152, 22);
            this.LowerRightItem.Text = "Lower Right";
            this.LowerRightItem.Visible = false;
            // 
            // LowerLeftItem
            // 
            this.LowerLeftItem.Name = "LowerLeftItem";
            this.LowerLeftItem.Size = new System.Drawing.Size(152, 22);
            this.LowerLeftItem.Text = "Lower Left";
            this.LowerLeftItem.Visible = false;
            // 
            // Seperator3
            // 
            this.Seperator3.Name = "Seperator3";
            this.Seperator3.Size = new System.Drawing.Size(29, 6);
            // 
            // PlayAnimButton
            // 
            this.PlayAnimButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.PlayAnimButton.Enabled = false;
            this.PlayAnimButton.Image = global::Sphere_Editor.Properties.Resources.resultset_next;
            this.PlayAnimButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PlayAnimButton.Name = "PlayAnimButton";
            this.PlayAnimButton.Size = new System.Drawing.Size(29, 20);
            this.PlayAnimButton.Text = "toolStripButton1";
            // 
            // StopAnimButton
            // 
            this.StopAnimButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.StopAnimButton.Enabled = false;
            this.StopAnimButton.Image = global::Sphere_Editor.Properties.Resources.cross;
            this.StopAnimButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StopAnimButton.Name = "StopAnimButton";
            this.StopAnimButton.Size = new System.Drawing.Size(29, 20);
            this.StopAnimButton.Text = "toolStripButton2";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.NameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NameTextBox.Location = new System.Drawing.Point(4, 30);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(256, 20);
            this.NameTextBox.TabIndex = 4;
            // 
            // AnimateCheckBox
            // 
            this.AnimateCheckBox.AutoSize = true;
            this.AnimateCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.AnimateCheckBox.Location = new System.Drawing.Point(7, 6);
            this.AnimateCheckBox.Margin = new System.Windows.Forms.Padding(6);
            this.AnimateCheckBox.Name = "AnimateCheckBox";
            this.AnimateCheckBox.Size = new System.Drawing.Size(70, 17);
            this.AnimateCheckBox.TabIndex = 5;
            this.AnimateCheckBox.Text = "Animated";
            this.AnimateCheckBox.UseVisualStyleBackColor = false;
            this.AnimateCheckBox.CheckedChanged += new System.EventHandler(this.AnimateCheckBox_CheckedChanged);
            // 
            // NextTileTextBox
            // 
            this.NextTileTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NextTileTextBox.Enabled = false;
            this.NextTileTextBox.Location = new System.Drawing.Point(7, 51);
            this.NextTileTextBox.Margin = new System.Windows.Forms.Padding(3, 3, 6, 3);
            this.NextTileTextBox.Name = "NextTileTextBox";
            this.NextTileTextBox.Size = new System.Drawing.Size(117, 20);
            this.NextTileTextBox.TabIndex = 6;
            // 
            // DelayTextBox
            // 
            this.DelayTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.DelayTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DelayTextBox.Enabled = false;
            this.DelayTextBox.Location = new System.Drawing.Point(130, 51);
            this.DelayTextBox.Margin = new System.Windows.Forms.Padding(3, 3, 6, 3);
            this.DelayTextBox.Name = "DelayTextBox";
            this.DelayTextBox.Size = new System.Drawing.Size(119, 20);
            this.DelayTextBox.TabIndex = 7;
            // 
            // NextTileLabel
            // 
            this.NextTileLabel.AutoSize = true;
            this.NextTileLabel.BackColor = System.Drawing.Color.Transparent;
            this.NextTileLabel.Location = new System.Drawing.Point(7, 32);
            this.NextTileLabel.Margin = new System.Windows.Forms.Padding(3);
            this.NextTileLabel.Name = "NextTileLabel";
            this.NextTileLabel.Size = new System.Drawing.Size(52, 13);
            this.NextTileLabel.TabIndex = 8;
            this.NextTileLabel.Text = "Next Tile:";
            // 
            // DelayLabel
            // 
            this.DelayLabel.AutoSize = true;
            this.DelayLabel.BackColor = System.Drawing.Color.Transparent;
            this.DelayLabel.Location = new System.Drawing.Point(127, 32);
            this.DelayLabel.Margin = new System.Windows.Forms.Padding(3);
            this.DelayLabel.Name = "DelayLabel";
            this.DelayLabel.Size = new System.Drawing.Size(69, 13);
            this.DelayLabel.TabIndex = 9;
            this.DelayLabel.Text = "Frame Delay:";
            // 
            // MainSplitContainer
            // 
            this.MainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.MainSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.MainSplitContainer.Name = "MainSplitContainer";
            // 
            // MainSplitContainer.Panel1
            // 
            this.MainSplitContainer.Panel1.Controls.Add(this.TileEditorPanel);
            // 
            // MainSplitContainer.Panel2
            // 
            this.MainSplitContainer.Panel2.Controls.Add(this.ImageHolder);
            this.MainSplitContainer.Panel2.Controls.Add(this.TileToolStrip);
            this.MainSplitContainer.Panel2.Controls.Add(this.ZoomStatusStrip);
            this.MainSplitContainer.Panel2.Controls.Add(this.ObstLabel);
            this.MainSplitContainer.Size = new System.Drawing.Size(678, 337);
            this.MainSplitContainer.SplitterDistance = 277;
            this.MainSplitContainer.TabIndex = 11;
            // 
            // TileEditorPanel
            // 
            this.TileEditorPanel.Controls.Add(this.EditorLabel);
            this.TileEditorPanel.Controls.Add(this.ButtonPanel);
            this.TileEditorPanel.Controls.Add(this.NamePanel);
            this.TileEditorPanel.Controls.Add(this.AnimationPanel);
            this.TileEditorPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TileEditorPanel.Location = new System.Drawing.Point(0, 0);
            this.TileEditorPanel.Margin = new System.Windows.Forms.Padding(6);
            this.TileEditorPanel.Name = "TileEditorPanel";
            this.TileEditorPanel.Size = new System.Drawing.Size(277, 337);
            this.TileEditorPanel.TabIndex = 18;
            // 
            // ButtonPanel
            // 
            this.ButtonPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(225)))), ((int)(((byte)(243)))));
            this.ButtonPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ButtonPanel.Controls.Add(this.BackButton);
            this.ButtonPanel.Controls.Add(this.NextButton);
            this.ButtonPanel.Location = new System.Drawing.Point(6, 220);
            this.ButtonPanel.Margin = new System.Windows.Forms.Padding(6);
            this.ButtonPanel.Name = "ButtonPanel";
            this.ButtonPanel.Size = new System.Drawing.Size(265, 111);
            this.ButtonPanel.TabIndex = 16;
            // 
            // BackButton
            // 
            this.BackButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BackButton.Image = global::Sphere_Editor.Properties.Resources.resultset_previous;
            this.BackButton.Location = new System.Drawing.Point(53, 41);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(75, 27);
            this.BackButton.TabIndex = 13;
            this.BackButton.Text = "Back";
            this.BackButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // NextButton
            // 
            this.NextButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NextButton.Image = global::Sphere_Editor.Properties.Resources.resultset_next;
            this.NextButton.Location = new System.Drawing.Point(134, 41);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(75, 27);
            this.NextButton.TabIndex = 14;
            this.NextButton.Text = "Next";
            this.NextButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // NamePanel
            // 
            this.NamePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.NamePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.NamePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NamePanel.Controls.Add(this.NameLabel);
            this.NamePanel.Controls.Add(this.NameTextBox);
            this.NamePanel.Location = new System.Drawing.Point(6, 29);
            this.NamePanel.Margin = new System.Windows.Forms.Padding(6);
            this.NamePanel.Name = "NamePanel";
            this.NamePanel.Size = new System.Drawing.Size(265, 55);
            this.NamePanel.TabIndex = 17;
            // 
            // NameLabel
            // 
            this.NameLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.NameLabel.Font = new System.Drawing.Font("Verdana", 10.5F);
            this.NameLabel.ForeColor = System.Drawing.Color.MidnightBlue;
            this.NameLabel.Location = new System.Drawing.Point(0, 0);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(263, 23);
            this.NameLabel.TabIndex = 5;
            this.NameLabel.Text = "Tile Name";
            this.NameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AnimationPanel
            // 
            this.AnimationPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.AnimationPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.AnimationPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AnimationPanel.Controls.Add(this.PropPanel);
            this.AnimationPanel.Controls.Add(this.AnimLabel);
            this.AnimationPanel.Location = new System.Drawing.Point(6, 96);
            this.AnimationPanel.Margin = new System.Windows.Forms.Padding(6);
            this.AnimationPanel.Name = "AnimationPanel";
            this.AnimationPanel.Size = new System.Drawing.Size(265, 112);
            this.AnimationPanel.TabIndex = 15;
            // 
            // PropPanel
            // 
            this.PropPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.PropPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(225)))), ((int)(((byte)(243)))));
            this.PropPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PropPanel.Controls.Add(this.AnimateCheckBox);
            this.PropPanel.Controls.Add(this.NextTileTextBox);
            this.PropPanel.Controls.Add(this.NextTileLabel);
            this.PropPanel.Controls.Add(this.DelayTextBox);
            this.PropPanel.Controls.Add(this.DelayLabel);
            this.PropPanel.Location = new System.Drawing.Point(3, 29);
            this.PropPanel.Name = "PropPanel";
            this.PropPanel.Size = new System.Drawing.Size(257, 78);
            this.PropPanel.TabIndex = 11;
            // 
            // AnimLabel
            // 
            this.AnimLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.AnimLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.AnimLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AnimLabel.Image = global::Sphere_Editor.Properties.Resources.BarImage;
            this.AnimLabel.Location = new System.Drawing.Point(0, 0);
            this.AnimLabel.Name = "AnimLabel";
            this.AnimLabel.Size = new System.Drawing.Size(263, 23);
            this.AnimLabel.TabIndex = 10;
            this.AnimLabel.Text = "Animation Properties";
            this.AnimLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ObstLabel
            // 
            this.ObstLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ObstLabel.Font = new System.Drawing.Font("Verdana", 10.5F);
            this.ObstLabel.ForeColor = System.Drawing.Color.MidnightBlue;
            this.ObstLabel.Location = new System.Drawing.Point(0, 0);
            this.ObstLabel.Name = "ObstLabel";
            this.ObstLabel.Size = new System.Drawing.Size(397, 23);
            this.ObstLabel.TabIndex = 3;
            this.ObstLabel.Text = "Tile Obstruction Editor / Animator";
            this.ObstLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ImageContextStrip
            // 
            this.ImageContextStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ZoomInItem,
            this.ZoomOutItem,
            this.StripSeparator1,
            this.ClearItem});
            this.ImageContextStrip.Name = "ImageContextStrip";
            this.ImageContextStrip.Size = new System.Drawing.Size(190, 76);
            // 
            // ZoomInItem
            // 
            this.ZoomInItem.Image = global::Sphere_Editor.Properties.Resources.magnifier_zoom_in;
            this.ZoomInItem.Name = "ZoomInItem";
            this.ZoomInItem.Size = new System.Drawing.Size(189, 22);
            this.ZoomInItem.Text = "Zoom &In";
            this.ZoomInItem.Click += new System.EventHandler(this.ZoomInButton_Click);
            // 
            // ZoomOutItem
            // 
            this.ZoomOutItem.Image = global::Sphere_Editor.Properties.Resources.magnifier_zoom_out;
            this.ZoomOutItem.Name = "ZoomOutItem";
            this.ZoomOutItem.Size = new System.Drawing.Size(189, 22);
            this.ZoomOutItem.Text = "Zoom &Out";
            this.ZoomOutItem.Click += new System.EventHandler(this.ZoomOutButton_Click);
            // 
            // StripSeparator1
            // 
            this.StripSeparator1.Name = "StripSeparator1";
            this.StripSeparator1.Size = new System.Drawing.Size(186, 6);
            // 
            // ClearItem
            // 
            this.ClearItem.Image = global::Sphere_Editor.Properties.Resources.delete;
            this.ClearItem.Name = "ClearItem";
            this.ClearItem.Size = new System.Drawing.Size(189, 22);
            this.ClearItem.Text = "Clear &All Obstructions";
            this.ClearItem.Click += new System.EventHandler(this.ClearItem_Click);
            // 
            // TileEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MainSplitContainer);
            this.MinimumSize = new System.Drawing.Size(414, 332);
            this.Name = "TileEditor";
            this.Size = new System.Drawing.Size(678, 337);
            this.ImageHolder.ResumeLayout(false);
            this.ZoomStatusStrip.ResumeLayout(false);
            this.ZoomStatusStrip.PerformLayout();
            this.TileToolStrip.ResumeLayout(false);
            this.TileToolStrip.PerformLayout();
            this.MainSplitContainer.Panel1.ResumeLayout(false);
            this.MainSplitContainer.Panel2.ResumeLayout(false);
            this.MainSplitContainer.Panel2.PerformLayout();
            this.MainSplitContainer.ResumeLayout(false);
            this.TileEditorPanel.ResumeLayout(false);
            this.ButtonPanel.ResumeLayout(false);
            this.NamePanel.ResumeLayout(false);
            this.NamePanel.PerformLayout();
            this.AnimationPanel.ResumeLayout(false);
            this.PropPanel.ResumeLayout(false);
            this.PropPanel.PerformLayout();
            this.ImageContextStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label EditorLabel;
        private System.Windows.Forms.Panel ImageHolder;
        private EditorPanel TileImage;
        private System.Windows.Forms.ToolStrip TileToolStrip;
        private System.Windows.Forms.ToolStripButton LineButton;
        private System.Windows.Forms.ToolStripButton RectangleButton;
        private System.Windows.Forms.ToolStripSeparator Separator1;
        private System.Windows.Forms.ToolStripButton ZoomInButton;
        private System.Windows.Forms.ToolStripButton ZoomOutButton;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.CheckBox AnimateCheckBox;
        private System.Windows.Forms.TextBox NextTileTextBox;
        private System.Windows.Forms.TextBox DelayTextBox;
        private System.Windows.Forms.Label NextTileLabel;
        private System.Windows.Forms.Label DelayLabel;
        private System.Windows.Forms.StatusStrip ZoomStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel ZoomLabel;
        private System.Windows.Forms.ToolStripDropDownButton PresetButton;
        private System.Windows.Forms.ToolStripSeparator Separator2;
        private System.Windows.Forms.ToolStripMenuItem NoneItem;
        private System.Windows.Forms.ToolStripMenuItem FullItem;
        private System.Windows.Forms.ToolStripMenuItem BottomHalfItem;
        private System.Windows.Forms.ToolStripMenuItem TopHalfItem;
        private System.Windows.Forms.ToolStripMenuItem LeftHalfItem;
        private System.Windows.Forms.ToolStripMenuItem RightHalfItem;
        private System.Windows.Forms.ToolStripMenuItem UpperLeftItem;
        private System.Windows.Forms.ToolStripMenuItem UpperRightItem;
        private System.Windows.Forms.ToolStripMenuItem LowerRightItem;
        private System.Windows.Forms.ToolStripMenuItem LowerLeftItem;
        private System.Windows.Forms.SplitContainer MainSplitContainer;
        private System.Windows.Forms.ToolStripSeparator Seperator3;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.ToolStripButton PlayAnimButton;
        private System.Windows.Forms.ToolStripButton StopAnimButton;
        private System.Windows.Forms.Panel AnimationPanel;
        private System.Windows.Forms.Label AnimLabel;
        private System.Windows.Forms.Panel ButtonPanel;
        private System.Windows.Forms.Panel PropPanel;
        private System.Windows.Forms.Panel NamePanel;
        private EditorLabel NameLabel;
        private System.Windows.Forms.Panel TileEditorPanel;
        private System.Windows.Forms.ToolStripButton ClearObstButton;
        private System.Windows.Forms.ContextMenuStrip ImageContextStrip;
        private System.Windows.Forms.ToolStripMenuItem ZoomInItem;
        private System.Windows.Forms.ToolStripMenuItem ZoomOutItem;
        private System.Windows.Forms.ToolStripSeparator StripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ClearItem;
        private EditorLabel ObstLabel;
    }
}
