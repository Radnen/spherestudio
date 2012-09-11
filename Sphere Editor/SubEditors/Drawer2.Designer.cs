namespace Sphere_Editor.SubEditors
{
    partial class Drawer2
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
                Destroy();
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
            this.EditorToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.DrawerPanel = new System.Windows.Forms.Panel();
            this.ImagePanel = new Sphere_Editor.EditorPanel();
            this.ImageEditor = new Sphere_Editor.EditorComponents.ImageEditControl2();
            this.LocationLabel = new System.Windows.Forms.ToolStripStatusLabel();
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
            this.DrawSeperator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ShowGridButton = new System.Windows.Forms.ToolStripButton();
            this.EditorStatus = new System.Windows.Forms.StatusStrip();
            this.ZoomLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.EditorPanel = new System.Windows.Forms.Panel();
            this.ColorSelectionPanel = new System.Windows.Forms.Panel();
            this.ColorFlow = new System.Windows.Forms.FlowLayoutPanel();
            this.AlphaTracker = new System.Windows.Forms.TrackBar();
            this.PaletteStatus = new System.Windows.Forms.StatusStrip();
            this.AlphaLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ColorLabel = new Sphere_Editor.EditorLabel();
            this.DrawerPanel.SuspendLayout();
            this.ImagePanel.SuspendLayout();
            this.DrawToolStrip.SuspendLayout();
            this.EditorStatus.SuspendLayout();
            this.EditorPanel.SuspendLayout();
            this.ColorSelectionPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AlphaTracker)).BeginInit();
            this.PaletteStatus.SuspendLayout();
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
            // DrawerPanel
            // 
            this.DrawerPanel.Controls.Add(this.ImagePanel);
            this.DrawerPanel.Controls.Add(this.DrawToolStrip);
            this.DrawerPanel.Controls.Add(this.EditorStatus);
            this.DrawerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DrawerPanel.Location = new System.Drawing.Point(0, 0);
            this.DrawerPanel.Name = "DrawerPanel";
            this.DrawerPanel.Size = new System.Drawing.Size(273, 337);
            this.DrawerPanel.TabIndex = 3;
            // 
            // ImagePanel
            // 
            this.ImagePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.ImagePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ImagePanel.Controls.Add(this.ImageEditor);
            this.ImagePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImagePanel.Location = new System.Drawing.Point(0, 25);
            this.ImagePanel.Name = "ImagePanel";
            this.ImagePanel.Size = new System.Drawing.Size(273, 288);
            this.ImagePanel.TabIndex = 2;
            this.ImagePanel.XSnap = 0;
            this.ImagePanel.YSnap = 0;
            this.ImagePanel.Resize += new System.EventHandler(this.ImagePanel_Resize);
            // 
            // ImageEditor
            // 
            this.ImageEditor.BackColor = System.Drawing.Color.White;
            this.ImageEditor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ImageEditor.DrawColor = System.Drawing.Color.White;
            this.ImageEditor.FixedSize = false;
            this.ImageEditor.Location = new System.Drawing.Point(62, 70);
            this.ImageEditor.LocationLabel = this.LocationLabel;
            this.ImageEditor.Name = "ImageEditor";
            this.ImageEditor.Outlined = false;
            this.ImageEditor.Size = new System.Drawing.Size(148, 148);
            this.ImageEditor.TabIndex = 0;
            this.ImageEditor.Tool = Sphere_Editor.EditorComponents.ImageEditControl2.ImageTool.Pen;
            this.ImageEditor.UseGrid = false;
            this.ImageEditor.ImageEdited += new System.EventHandler(this.ImageEditor_ImageEdited);
            this.ImageEditor.ColorChanged += new System.EventHandler(this.ImageEditor_ColorChanged);
            this.ImageEditor.Paint += new System.Windows.Forms.PaintEventHandler(this.ImageEditor_Paint);
            // 
            // LocationLabel
            // 
            this.LocationLabel.BackColor = System.Drawing.SystemColors.Control;
            this.LocationLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.LocationLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.LocationLabel.Name = "LocationLabel";
            this.LocationLabel.Size = new System.Drawing.Size(62, 19);
            this.LocationLabel.Text = "Loc: {0, 0}";
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
            this.DrawSeperator3,
            this.ShowGridButton});
            this.DrawToolStrip.Location = new System.Drawing.Point(0, 0);
            this.DrawToolStrip.Name = "DrawToolStrip";
            this.DrawToolStrip.Padding = new System.Windows.Forms.Padding(5, 0, 1, 0);
            this.DrawToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.DrawToolStrip.Size = new System.Drawing.Size(273, 25);
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
            this.LocationLabel});
            this.EditorStatus.Location = new System.Drawing.Point(0, 313);
            this.EditorStatus.Name = "EditorStatus";
            this.EditorStatus.Size = new System.Drawing.Size(273, 24);
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
            // EditorPanel
            // 
            this.EditorPanel.AutoScroll = true;
            this.EditorPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.EditorPanel.Controls.Add(this.ColorSelectionPanel);
            this.EditorPanel.Controls.Add(this.PaletteStatus);
            this.EditorPanel.Controls.Add(this.ColorLabel);
            this.EditorPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.EditorPanel.Location = new System.Drawing.Point(273, 0);
            this.EditorPanel.Name = "EditorPanel";
            this.EditorPanel.Size = new System.Drawing.Size(135, 337);
            this.EditorPanel.TabIndex = 0;
            // 
            // ColorSelectionPanel
            // 
            this.ColorSelectionPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ColorSelectionPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ColorSelectionPanel.Controls.Add(this.ColorFlow);
            this.ColorSelectionPanel.Controls.Add(this.AlphaTracker);
            this.ColorSelectionPanel.Location = new System.Drawing.Point(9, 29);
            this.ColorSelectionPanel.Margin = new System.Windows.Forms.Padding(6);
            this.ColorSelectionPanel.Name = "ColorSelectionPanel";
            this.ColorSelectionPanel.Size = new System.Drawing.Size(120, 280);
            this.ColorSelectionPanel.TabIndex = 10;
            // 
            // ColorFlow
            // 
            this.ColorFlow.BackColor = System.Drawing.SystemColors.Control;
            this.ColorFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ColorFlow.Location = new System.Drawing.Point(45, 0);
            this.ColorFlow.Name = "ColorFlow";
            this.ColorFlow.Size = new System.Drawing.Size(73, 278);
            this.ColorFlow.TabIndex = 8;
            // 
            // AlphaTracker
            // 
            this.AlphaTracker.BackColor = System.Drawing.SystemColors.Control;
            this.AlphaTracker.Dock = System.Windows.Forms.DockStyle.Left;
            this.AlphaTracker.Location = new System.Drawing.Point(0, 0);
            this.AlphaTracker.Maximum = 255;
            this.AlphaTracker.Name = "AlphaTracker";
            this.AlphaTracker.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.AlphaTracker.Size = new System.Drawing.Size(45, 278);
            this.AlphaTracker.TabIndex = 2;
            this.AlphaTracker.TickFrequency = 5;
            this.AlphaTracker.Value = 255;
            this.AlphaTracker.Scroll += new System.EventHandler(this.AlphaTracker_Scroll);
            // 
            // PaletteStatus
            // 
            this.PaletteStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AlphaLabel});
            this.PaletteStatus.Location = new System.Drawing.Point(0, 315);
            this.PaletteStatus.Name = "PaletteStatus";
            this.PaletteStatus.Size = new System.Drawing.Size(135, 22);
            this.PaletteStatus.SizingGrip = false;
            this.PaletteStatus.TabIndex = 1;
            this.PaletteStatus.Text = "Palette Status";
            // 
            // AlphaLabel
            // 
            this.AlphaLabel.BackColor = System.Drawing.SystemColors.Control;
            this.AlphaLabel.Name = "AlphaLabel";
            this.AlphaLabel.Size = new System.Drawing.Size(62, 17);
            this.AlphaLabel.Text = "Alpha: 255";
            // 
            // ColorLabel
            // 
            this.ColorLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(225)))), ((int)(((byte)(243)))));
            this.ColorLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ColorLabel.Font = new System.Drawing.Font("Verdana", 10.5F);
            this.ColorLabel.ForeColor = System.Drawing.Color.MidnightBlue;
            this.ColorLabel.Location = new System.Drawing.Point(0, 0);
            this.ColorLabel.Name = "ColorLabel";
            this.ColorLabel.Size = new System.Drawing.Size(135, 23);
            this.ColorLabel.TabIndex = 13;
            this.ColorLabel.Text = "Palette";
            this.ColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Drawer2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DrawerPanel);
            this.Controls.Add(this.EditorPanel);
            this.Name = "Drawer2";
            this.Size = new System.Drawing.Size(408, 337);
            this.DrawerPanel.ResumeLayout(false);
            this.DrawerPanel.PerformLayout();
            this.ImagePanel.ResumeLayout(false);
            this.DrawToolStrip.ResumeLayout(false);
            this.DrawToolStrip.PerformLayout();
            this.EditorStatus.ResumeLayout(false);
            this.EditorStatus.PerformLayout();
            this.EditorPanel.ResumeLayout(false);
            this.EditorPanel.PerformLayout();
            this.ColorSelectionPanel.ResumeLayout(false);
            this.ColorSelectionPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AlphaTracker)).EndInit();
            this.PaletteStatus.ResumeLayout(false);
            this.PaletteStatus.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip DrawToolStrip;
        private System.Windows.Forms.ToolStripButton PencilButton;
        private System.Windows.Forms.ToolStripButton LineButton;
        private System.Windows.Forms.ToolStripButton RectangleButton;
        private System.Windows.Forms.ToolStripButton FillButton;
        private System.Windows.Forms.ToolStripSeparator DrawSeperator;
        private System.Windows.Forms.ToolStripSeparator DrawSeperator3;
        private System.Windows.Forms.ToolStripButton ShowGridButton;
        private System.Windows.Forms.Panel EditorPanel;
        private System.Windows.Forms.TrackBar AlphaTracker;
        private System.Windows.Forms.ToolStripButton UndoButton;
        private System.Windows.Forms.ToolStripButton RedoButton;
        private System.Windows.Forms.Panel ColorSelectionPanel;
        private System.Windows.Forms.StatusStrip EditorStatus;
        private System.Windows.Forms.ToolStripStatusLabel ZoomLabel;
        private System.Windows.Forms.ToolStripStatusLabel LocationLabel;
        private EditorPanel ImagePanel;
        private System.Windows.Forms.ToolStripButton PanButton;
        private System.Windows.Forms.StatusStrip PaletteStatus;
        private System.Windows.Forms.ToolStripStatusLabel AlphaLabel;
        private System.Windows.Forms.ToolTip EditorToolTip;
        private System.Windows.Forms.Panel DrawerPanel;
        private System.Windows.Forms.ToolStripButton OutlineButton;
        private System.Windows.Forms.FlowLayoutPanel ColorFlow;
        private EditorLabel ColorLabel;
        private EditorComponents.ImageEditControl2 ImageEditor;
    }
}
