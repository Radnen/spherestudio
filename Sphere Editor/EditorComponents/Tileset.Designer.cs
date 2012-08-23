namespace Sphere_Editor.EditorComponents
{
    partial class TilesetControl
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
            this.TilesetContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AppendTileItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InsertTileItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DuplicateTile = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteTileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Separator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ZoomMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ZoomInItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ZoomOutItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RestoreItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Separator2 = new System.Windows.Forms.ToolStripSeparator();
            this.TilesetContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // TilesetContextMenu
            // 
            this.TilesetContextMenu.BackColor = System.Drawing.Color.Lavender;
            this.TilesetContextMenu.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.TilesetContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AppendTileItem,
            this.InsertTileItem,
            this.DuplicateTile,
            this.DeleteTileMenuItem,
            this.Separator2,
            this.Separator1,
            this.ZoomMenuItem});
            this.TilesetContextMenu.Name = "contextMenuStrip1";
            this.TilesetContextMenu.Size = new System.Drawing.Size(154, 126);
            this.TilesetContextMenu.Opened += new System.EventHandler(this.TilesetContextMenu_Opened);
            // 
            // AppendTileItem
            // 
            this.AppendTileItem.Image = global::Sphere_Editor.Properties.Resources.add;
            this.AppendTileItem.Name = "AppendTileItem";
            this.AppendTileItem.Size = new System.Drawing.Size(153, 22);
            this.AppendTileItem.Text = "&Append Tile";
            this.AppendTileItem.Click += new System.EventHandler(this.AppendTileItem_Click);
            // 
            // InsertTileItem
            // 
            this.InsertTileItem.Image = global::Sphere_Editor.Properties.Resources.add;
            this.InsertTileItem.Name = "InsertTileItem";
            this.InsertTileItem.Size = new System.Drawing.Size(153, 22);
            this.InsertTileItem.Text = "&Insert Tile";
            this.InsertTileItem.Click += new System.EventHandler(this.InsertTileItem_Click);
            // 
            // DuplicateTile
            // 
            this.DuplicateTile.Image = global::Sphere_Editor.Properties.Resources.page_copy;
            this.DuplicateTile.Name = "DuplicateTile";
            this.DuplicateTile.Size = new System.Drawing.Size(153, 22);
            this.DuplicateTile.Text = "D&uplicate Tile";
            this.DuplicateTile.Click += new System.EventHandler(this.DuplicateTile_Click);
            // 
            // DeleteTileMenuItem
            // 
            this.DeleteTileMenuItem.Image = global::Sphere_Editor.Properties.Resources.delete;
            this.DeleteTileMenuItem.Name = "DeleteTileMenuItem";
            this.DeleteTileMenuItem.Size = new System.Drawing.Size(153, 22);
            this.DeleteTileMenuItem.Text = "Delete Tile";
            this.DeleteTileMenuItem.Click += new System.EventHandler(this.DeleteTileMenuItem_Click);
            // 
            // Separator1
            // 
            this.Separator1.Name = "Separator1";
            this.Separator1.Size = new System.Drawing.Size(150, 6);
            // 
            // ZoomMenuItem
            // 
            this.ZoomMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ZoomInItem,
            this.ZoomOutItem,
            this.RestoreItem});
            this.ZoomMenuItem.Name = "ZoomMenuItem";
            this.ZoomMenuItem.Size = new System.Drawing.Size(153, 22);
            this.ZoomMenuItem.Text = "&Zoom";
            // 
            // ZoomInItem
            // 
            this.ZoomInItem.Image = global::Sphere_Editor.Properties.Resources.magnifier_zoom_in;
            this.ZoomInItem.Name = "ZoomInItem";
            this.ZoomInItem.ShortcutKeyDisplayString = "Ctrl ++";
            this.ZoomInItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Oemplus)));
            this.ZoomInItem.Size = new System.Drawing.Size(177, 22);
            this.ZoomInItem.Text = "Zoom &In";
            this.ZoomInItem.Click += new System.EventHandler(this.ZoomInItem_Click);
            // 
            // ZoomOutItem
            // 
            this.ZoomOutItem.Enabled = false;
            this.ZoomOutItem.Image = global::Sphere_Editor.Properties.Resources.magnifier_zoom_out;
            this.ZoomOutItem.Name = "ZoomOutItem";
            this.ZoomOutItem.ShortcutKeyDisplayString = "Ctrl +-";
            this.ZoomOutItem.Size = new System.Drawing.Size(177, 22);
            this.ZoomOutItem.Text = "Zoom &Out";
            this.ZoomOutItem.Click += new System.EventHandler(this.ZoomOutItem_Click);
            // 
            // RestoreItem
            // 
            this.RestoreItem.Name = "RestoreItem";
            this.RestoreItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D0)));
            this.RestoreItem.Size = new System.Drawing.Size(177, 22);
            this.RestoreItem.Text = "Restore";
            this.RestoreItem.Click += new System.EventHandler(this.RestoreZoomItem_Click);
            // 
            // Separator2
            // 
            this.Separator2.Name = "Separator2";
            this.Separator2.Size = new System.Drawing.Size(150, 6);
            // 
            // TilesetControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackgroundImage = global::Sphere_Editor.Properties.Resources.editbg;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DoubleBuffered = true;
            this.Name = "TilesetControl";
            this.Size = new System.Drawing.Size(125, 229);
            this.Load += new System.EventHandler(this.TilesetControl_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Tileset_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TilesetControl_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TilesetControl_KeyUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TilesetControl_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TilesetControl_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TilesetControl_MouseUp);
            this.Resize += new System.EventHandler(this.TilesetControl_Resize);
            this.TilesetContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip TilesetContextMenu;
        private System.Windows.Forms.ToolStripMenuItem InsertTileItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteTileMenuItem;
        private System.Windows.Forms.ToolStripSeparator Separator1;
        private System.Windows.Forms.ToolStripMenuItem DuplicateTile;
        private System.Windows.Forms.ToolStripMenuItem ZoomMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ZoomInItem;
        private System.Windows.Forms.ToolStripMenuItem ZoomOutItem;
        private System.Windows.Forms.ToolStripMenuItem RestoreItem;
        private System.Windows.Forms.ToolStripSeparator Separator2;
        private System.Windows.Forms.ToolStripMenuItem AppendTileItem;
    }
}
