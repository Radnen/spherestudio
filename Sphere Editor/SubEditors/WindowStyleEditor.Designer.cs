namespace Sphere_Editor.SubEditors
{
    partial class WindowStyleEditor
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
                style.Dispose();
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
            this.StyleContextStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.GridItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ZoomInItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ZoomOutItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditBGItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WindowHolder = new System.Windows.Forms.Panel();
            this.WindowPanel = new System.Windows.Forms.Panel();
            this.StyleToolStrip = new System.Windows.Forms.ToolStrip();
            this.GridButton = new System.Windows.Forms.ToolStripButton();
            this.Separator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ZoomInButton = new System.Windows.Forms.ToolStripButton();
            this.ZoomOutButton = new System.Windows.Forms.ToolStripButton();
            this.Seperator2 = new System.Windows.Forms.ToolStripSeparator();
            this.LeftButton = new System.Windows.Forms.ToolStripButton();
            this.ImgLabel = new System.Windows.Forms.ToolStripLabel();
            this.RightButton = new System.Windows.Forms.ToolStripButton();
            this.Seperator3 = new System.Windows.Forms.ToolStripSeparator();
            this.StyleStatusStrip = new System.Windows.Forms.StatusStrip();
            this.ZoomLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.EditorPanel = new System.Windows.Forms.Panel();
            this.MainSplitter = new System.Windows.Forms.SplitContainer();
            this.StyleDrawer = new Sphere_Editor.SubEditors.Drawer2();
            this.StyleContextStrip.SuspendLayout();
            this.WindowHolder.SuspendLayout();
            this.StyleToolStrip.SuspendLayout();
            this.StyleStatusStrip.SuspendLayout();
            this.EditorPanel.SuspendLayout();
            this.MainSplitter.Panel1.SuspendLayout();
            this.MainSplitter.Panel2.SuspendLayout();
            this.MainSplitter.SuspendLayout();
            this.SuspendLayout();
            // 
            // StyleContextStrip
            // 
            this.StyleContextStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GridItem,
            this.ZoomInItem,
            this.ZoomOutItem,
            this.EditBGItem});
            this.StyleContextStrip.Name = "StyleContextStrip";
            this.StyleContextStrip.Size = new System.Drawing.Size(137, 92);
            // 
            // GridItem
            // 
            this.GridItem.Image = global::Sphere_Editor.Properties.Resources.grid;
            this.GridItem.Name = "GridItem";
            this.GridItem.Size = new System.Drawing.Size(136, 22);
            this.GridItem.Text = "Toggle &Grid";
            this.GridItem.Click += new System.EventHandler(this.GridItem_Click);
            this.GridItem.MouseEnter += new System.EventHandler(this.GridButton_MouseEnter);
            this.GridItem.MouseLeave += new System.EventHandler(this.ClearTip);
            // 
            // ZoomInItem
            // 
            this.ZoomInItem.Image = global::Sphere_Editor.Properties.Resources.magnifier_zoom_in;
            this.ZoomInItem.Name = "ZoomInItem";
            this.ZoomInItem.Size = new System.Drawing.Size(136, 22);
            this.ZoomInItem.Text = "Zoom &In";
            this.ZoomInItem.Click += new System.EventHandler(this.ZoomInItem_Click);
            // 
            // ZoomOutItem
            // 
            this.ZoomOutItem.Enabled = false;
            this.ZoomOutItem.Image = global::Sphere_Editor.Properties.Resources.magnifier_zoom_out;
            this.ZoomOutItem.Name = "ZoomOutItem";
            this.ZoomOutItem.Size = new System.Drawing.Size(136, 22);
            this.ZoomOutItem.Text = "Zoom &Out";
            this.ZoomOutItem.Click += new System.EventHandler(this.ZoomOutItem_Click);
            // 
            // EditBGItem
            // 
            this.EditBGItem.Image = global::Sphere_Editor.Properties.Resources.palette;
            this.EditBGItem.Name = "EditBGItem";
            this.EditBGItem.Size = new System.Drawing.Size(136, 22);
            this.EditBGItem.Text = "&Edit BG";
            this.EditBGItem.Click += new System.EventHandler(this.EditBGItem_Click);
            this.EditBGItem.MouseEnter += new System.EventHandler(this.EditBGItem_MouseEnter);
            this.EditBGItem.MouseLeave += new System.EventHandler(this.ClearTip);
            // 
            // WindowHolder
            // 
            this.WindowHolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.WindowHolder.Controls.Add(this.WindowPanel);
            this.WindowHolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WindowHolder.Location = new System.Drawing.Point(0, 25);
            this.WindowHolder.Name = "WindowHolder";
            this.WindowHolder.Size = new System.Drawing.Size(506, 161);
            this.WindowHolder.TabIndex = 5;
            this.WindowHolder.MouseEnter += new System.EventHandler(this.WindowHolder_MouseEnter);
            this.WindowHolder.MouseLeave += new System.EventHandler(this.ClearTip);
            this.WindowHolder.Resize += new System.EventHandler(this.WindowHolder_Resize);
            // 
            // WindowPanel
            // 
            this.WindowPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.WindowPanel.BackgroundImage = global::Sphere_Editor.Properties.Resources.editbg2;
            this.WindowPanel.ContextMenuStrip = this.StyleContextStrip;
            this.WindowPanel.Location = new System.Drawing.Point(141, 16);
            this.WindowPanel.Name = "WindowPanel";
            this.WindowPanel.Size = new System.Drawing.Size(224, 128);
            this.WindowPanel.TabIndex = 0;
            this.WindowPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.TestPanel_Paint);
            this.WindowPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TestPanel_MouseDown);
            this.WindowPanel.MouseEnter += new System.EventHandler(this.WindowPanel_MouseEnter);
            this.WindowPanel.MouseLeave += new System.EventHandler(this.WindowPanel_MouseLeave);
            this.WindowPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TestPanel_MouseMove);
            this.WindowPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TestPanel_MouseUp);
            // 
            // StyleToolStrip
            // 
            this.StyleToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.StyleToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GridButton,
            this.Separator1,
            this.ZoomInButton,
            this.ZoomOutButton,
            this.Seperator2,
            this.LeftButton,
            this.ImgLabel,
            this.RightButton,
            this.Seperator3});
            this.StyleToolStrip.Location = new System.Drawing.Point(0, 0);
            this.StyleToolStrip.Name = "StyleToolStrip";
            this.StyleToolStrip.Padding = new System.Windows.Forms.Padding(5, 0, 1, 0);
            this.StyleToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.StyleToolStrip.Size = new System.Drawing.Size(506, 25);
            this.StyleToolStrip.TabIndex = 6;
            this.StyleToolStrip.Text = "toolStrip1";
            // 
            // GridButton
            // 
            this.GridButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.GridButton.Image = global::Sphere_Editor.Properties.Resources.grid;
            this.GridButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.GridButton.Name = "GridButton";
            this.GridButton.Size = new System.Drawing.Size(23, 22);
            this.GridButton.Text = "Show Grid";
            this.GridButton.Click += new System.EventHandler(this.GridItem_Click);
            this.GridButton.MouseEnter += new System.EventHandler(this.GridButton_MouseEnter);
            this.GridButton.MouseLeave += new System.EventHandler(this.ClearTip);
            // 
            // Separator1
            // 
            this.Separator1.Name = "Separator1";
            this.Separator1.Size = new System.Drawing.Size(6, 25);
            // 
            // ZoomInButton
            // 
            this.ZoomInButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ZoomInButton.Image = global::Sphere_Editor.Properties.Resources.magnifier_zoom_in;
            this.ZoomInButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ZoomInButton.Name = "ZoomInButton";
            this.ZoomInButton.Size = new System.Drawing.Size(23, 22);
            this.ZoomInButton.Text = "Zoom In";
            this.ZoomInButton.Click += new System.EventHandler(this.ZoomInItem_Click);
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
            this.ZoomOutButton.Click += new System.EventHandler(this.ZoomOutItem_Click);
            // 
            // Seperator2
            // 
            this.Seperator2.Name = "Seperator2";
            this.Seperator2.Size = new System.Drawing.Size(6, 25);
            // 
            // LeftButton
            // 
            this.LeftButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.LeftButton.Enabled = false;
            this.LeftButton.Image = global::Sphere_Editor.Properties.Resources.resultset_previous;
            this.LeftButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LeftButton.Name = "LeftButton";
            this.LeftButton.Size = new System.Drawing.Size(23, 22);
            this.LeftButton.Text = "Set Left";
            this.LeftButton.Click += new System.EventHandler(this.LeftButton_Click);
            this.LeftButton.MouseEnter += new System.EventHandler(this.LeftButton_MouseEnter);
            this.LeftButton.MouseLeave += new System.EventHandler(this.ClearTip);
            // 
            // ImgLabel
            // 
            this.ImgLabel.Name = "ImgLabel";
            this.ImgLabel.Size = new System.Drawing.Size(52, 22);
            this.ImgLabel.Text = "Image: 0";
            // 
            // RightButton
            // 
            this.RightButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RightButton.Image = global::Sphere_Editor.Properties.Resources.resultset_next;
            this.RightButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RightButton.Name = "RightButton";
            this.RightButton.Size = new System.Drawing.Size(23, 22);
            this.RightButton.Text = "Set Right";
            this.RightButton.Click += new System.EventHandler(this.RightButton_Click);
            this.RightButton.MouseEnter += new System.EventHandler(this.RightButton_MouseEnter);
            this.RightButton.MouseLeave += new System.EventHandler(this.ClearTip);
            // 
            // Seperator3
            // 
            this.Seperator3.Name = "Seperator3";
            this.Seperator3.Size = new System.Drawing.Size(6, 25);
            // 
            // StyleStatusStrip
            // 
            this.StyleStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ZoomLabel});
            this.StyleStatusStrip.Location = new System.Drawing.Point(0, 186);
            this.StyleStatusStrip.Name = "StyleStatusStrip";
            this.StyleStatusStrip.Size = new System.Drawing.Size(506, 22);
            this.StyleStatusStrip.SizingGrip = false;
            this.StyleStatusStrip.TabIndex = 7;
            // 
            // ZoomLabel
            // 
            this.ZoomLabel.Name = "ZoomLabel";
            this.ZoomLabel.Size = new System.Drawing.Size(51, 17);
            this.ZoomLabel.Text = "Zoom: 1";
            // 
            // EditorPanel
            // 
            this.EditorPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.EditorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EditorPanel.Controls.Add(this.WindowHolder);
            this.EditorPanel.Controls.Add(this.StyleToolStrip);
            this.EditorPanel.Controls.Add(this.StyleStatusStrip);
            this.EditorPanel.Location = new System.Drawing.Point(6, 6);
            this.EditorPanel.Margin = new System.Windows.Forms.Padding(6);
            this.EditorPanel.Name = "EditorPanel";
            this.EditorPanel.Size = new System.Drawing.Size(508, 210);
            this.EditorPanel.TabIndex = 9;
            // 
            // MainSplitter
            // 
            this.MainSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainSplitter.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.MainSplitter.Location = new System.Drawing.Point(0, 0);
            this.MainSplitter.Name = "MainSplitter";
            this.MainSplitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // MainSplitter.Panel1
            // 
            this.MainSplitter.Panel1.Controls.Add(this.EditorPanel);
            // 
            // MainSplitter.Panel2
            // 
            this.MainSplitter.Panel2.Controls.Add(this.StyleDrawer);
            this.MainSplitter.Size = new System.Drawing.Size(520, 383);
            this.MainSplitter.SplitterDistance = 222;
            this.MainSplitter.TabIndex = 10;
            // 
            // StyleDrawer
            // 
            this.StyleDrawer.CanDirty = false;
            this.StyleDrawer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StyleDrawer.FixedSize = true;
            this.StyleDrawer.HelpLabel = null;
            this.StyleDrawer.Location = new System.Drawing.Point(0, 0);
            this.StyleDrawer.Name = "StyleDrawer";
            this.StyleDrawer.Size = new System.Drawing.Size(520, 157);
            this.StyleDrawer.TabIndex = 0;
            this.StyleDrawer.ImageEdited += new System.EventHandler(this.StyleDrawer_ImageEdited);
            // 
            // WindowStyleEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MainSplitter);
            this.DoubleBuffered = true;
            this.Name = "WindowStyleEditor";
            this.Size = new System.Drawing.Size(520, 383);
            this.Resize += new System.EventHandler(this.WindowStyleEditor_Resize);
            this.StyleContextStrip.ResumeLayout(false);
            this.WindowHolder.ResumeLayout(false);
            this.StyleToolStrip.ResumeLayout(false);
            this.StyleToolStrip.PerformLayout();
            this.StyleStatusStrip.ResumeLayout(false);
            this.StyleStatusStrip.PerformLayout();
            this.EditorPanel.ResumeLayout(false);
            this.EditorPanel.PerformLayout();
            this.MainSplitter.Panel1.ResumeLayout(false);
            this.MainSplitter.Panel2.ResumeLayout(false);
            this.MainSplitter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel WindowPanel;
        private System.Windows.Forms.ContextMenuStrip StyleContextStrip;
        private System.Windows.Forms.ToolStripMenuItem GridItem;
        private System.Windows.Forms.Panel WindowHolder;
        private System.Windows.Forms.ToolStripMenuItem ZoomInItem;
        private System.Windows.Forms.ToolStripMenuItem ZoomOutItem;
        private System.Windows.Forms.ToolStrip StyleToolStrip;
        private System.Windows.Forms.ToolStripButton GridButton;
        private System.Windows.Forms.ToolStripSeparator Separator1;
        private System.Windows.Forms.ToolStripButton ZoomInButton;
        private System.Windows.Forms.ToolStripButton ZoomOutButton;
        private System.Windows.Forms.ToolStripMenuItem EditBGItem;
        private System.Windows.Forms.StatusStrip StyleStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel ZoomLabel;
        private System.Windows.Forms.ToolStripSeparator Seperator2;
        private System.Windows.Forms.ToolStripButton LeftButton;
        private System.Windows.Forms.ToolStripLabel ImgLabel;
        private System.Windows.Forms.ToolStripButton RightButton;
        private System.Windows.Forms.ToolStripSeparator Seperator3;
        private System.Windows.Forms.Panel EditorPanel;
        private System.Windows.Forms.SplitContainer MainSplitter;
        private Drawer2 StyleDrawer;
    }
}
