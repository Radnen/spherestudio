namespace Sphere_Editor.EditorComponents
{
    partial class TilesetControl2
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
            this.TileContextStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertItem = new System.Windows.Forms.ToolStripMenuItem();
            this.appendTilesItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeTilesItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.zoomInItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomOutItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TileContextStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // TileContextStrip
            // 
            this.TileContextStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addItem,
            this.removeItem,
            this.insertItem,
            this.appendTilesItem,
            this.removeTilesItem,
            this.toolStripSeparator1,
            this.zoomInItem,
            this.zoomOutItem});
            this.TileContextStrip.Name = "TileContextStrip";
            this.TileContextStrip.Size = new System.Drawing.Size(154, 186);
            this.TileContextStrip.Opening += new System.ComponentModel.CancelEventHandler(this.TileContextStrip_Opening);
            // 
            // addItem
            // 
            this.addItem.Image = global::Sphere_Editor.Properties.Resources.add;
            this.addItem.Name = "addItem";
            this.addItem.Size = new System.Drawing.Size(153, 22);
            this.addItem.Text = "&Add";
            this.addItem.Click += new System.EventHandler(this.addItem_Click);
            // 
            // removeItem
            // 
            this.removeItem.Image = global::Sphere_Editor.Properties.Resources.cross;
            this.removeItem.Name = "removeItem";
            this.removeItem.Size = new System.Drawing.Size(153, 22);
            this.removeItem.Text = "&Remove";
            this.removeItem.Click += new System.EventHandler(this.removeItem_Click);
            // 
            // insertItem
            // 
            this.insertItem.Name = "insertItem";
            this.insertItem.Size = new System.Drawing.Size(153, 22);
            this.insertItem.Text = "&Insert";
            this.insertItem.Click += new System.EventHandler(this.insertItem_Click);
            // 
            // appendTilesItem
            // 
            this.appendTilesItem.Name = "appendTilesItem";
            this.appendTilesItem.Size = new System.Drawing.Size(153, 22);
            this.appendTilesItem.Text = "Append Tiles...";
            this.appendTilesItem.Click += new System.EventHandler(this.appendTilesItem_Click);
            // 
            // removeTilesItem
            // 
            this.removeTilesItem.Name = "removeTilesItem";
            this.removeTilesItem.Size = new System.Drawing.Size(153, 22);
            this.removeTilesItem.Text = "Remove Tiles...";
            this.removeTilesItem.Click += new System.EventHandler(this.removeTilesItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(150, 6);
            // 
            // zoomInItem
            // 
            this.zoomInItem.Image = global::Sphere_Editor.Properties.Resources.magnifier_zoom_in;
            this.zoomInItem.Name = "zoomInItem";
            this.zoomInItem.Size = new System.Drawing.Size(153, 22);
            this.zoomInItem.Text = "Zoom In";
            this.zoomInItem.Click += new System.EventHandler(this.zoomInItem_Click);
            // 
            // zoomOutItem
            // 
            this.zoomOutItem.Image = global::Sphere_Editor.Properties.Resources.magnifier_zoom_out;
            this.zoomOutItem.Name = "zoomOutItem";
            this.zoomOutItem.Size = new System.Drawing.Size(153, 22);
            this.zoomOutItem.Text = "Zoom Out";
            this.zoomOutItem.Click += new System.EventHandler(this.zoomOutItem_Click);
            // 
            // TilesetControl2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Sphere_Editor.Properties.Resources.editbg2;
            this.DoubleBuffered = true;
            this.Name = "TilesetControl2";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.TilesetControl2_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TilesetControl2_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TilesetControl2_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TilesetControl2_MouseUp);
            this.Resize += new System.EventHandler(this.TilesetControl2_Resize);
            this.TileContextStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip TileContextStrip;
        private System.Windows.Forms.ToolStripMenuItem addItem;
        private System.Windows.Forms.ToolStripMenuItem removeItem;
        private System.Windows.Forms.ToolStripMenuItem insertItem;
        private System.Windows.Forms.ToolStripMenuItem appendTilesItem;
        private System.Windows.Forms.ToolStripMenuItem removeTilesItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem zoomInItem;
        private System.Windows.Forms.ToolStripMenuItem zoomOutItem;
    }
}
