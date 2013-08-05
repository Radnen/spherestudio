namespace Sphere_Editor.EditorComponents
{
    partial class MapEditorControl
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
            this.MapContextStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SelectTileItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SelectLayerItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StartLocationItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemSeperator1 = new System.Windows.Forms.ToolStripSeparator();
            this.AddEntityItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PersonItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TriggerItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteEntityItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditEntityItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyEntityItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PasteEntityItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MapContextStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MapContextStrip
            // 
            this.MapContextStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SelectTileItem,
            this.SelectLayerItem,
            this.StartLocationItem,
            this.ItemSeperator1,
            this.AddEntityItem,
            this.DeleteEntityItem,
            this.EditEntityItem,
            this.CopyEntityItem,
            this.PasteEntityItem});
            this.MapContextStrip.Name = "MapContextStrip";
            this.MapContextStrip.Size = new System.Drawing.Size(167, 208);
            this.MapContextStrip.Opened += new System.EventHandler(this.MapContextStrip_Opened);
            // 
            // SelectTileItem
            // 
            this.SelectTileItem.Image = global::Sphere_Editor.Properties.Resources.pencil;
            this.SelectTileItem.Name = "SelectTileItem";
            this.SelectTileItem.Size = new System.Drawing.Size(166, 22);
            this.SelectTileItem.Text = "Select &Tile";
            this.SelectTileItem.Click += new System.EventHandler(this.SelectTileItem_Click);
            // 
            // SelectLayerItem
            // 
            this.SelectLayerItem.Name = "SelectLayerItem";
            this.SelectLayerItem.Size = new System.Drawing.Size(166, 22);
            this.SelectLayerItem.Text = "Select &Layer";
            // 
            // StartLocationItem
            // 
            this.StartLocationItem.Image = global::Sphere_Editor.Properties.Resources.startpos;
            this.StartLocationItem.Name = "StartLocationItem";
            this.StartLocationItem.Size = new System.Drawing.Size(166, 22);
            this.StartLocationItem.Text = "Set &Start Location";
            this.StartLocationItem.Click += new System.EventHandler(this.StartLocationItem_Click);
            // 
            // ItemSeperator1
            // 
            this.ItemSeperator1.Name = "ItemSeperator1";
            this.ItemSeperator1.Size = new System.Drawing.Size(163, 6);
            // 
            // AddEntityItem
            // 
            this.AddEntityItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PersonItem,
            this.TriggerItem});
            this.AddEntityItem.Name = "AddEntityItem";
            this.AddEntityItem.Size = new System.Drawing.Size(166, 22);
            this.AddEntityItem.Text = "&Add Entity";
            // 
            // PersonItem
            // 
            this.PersonItem.Image = global::Sphere_Editor.Properties.Resources.person;
            this.PersonItem.Name = "PersonItem";
            this.PersonItem.Size = new System.Drawing.Size(112, 22);
            this.PersonItem.Text = "Person";
            this.PersonItem.Click += new System.EventHandler(this.PersonItem_Click);
            // 
            // TriggerItem
            // 
            this.TriggerItem.Image = global::Sphere_Editor.Properties.Resources.trigger;
            this.TriggerItem.Name = "TriggerItem";
            this.TriggerItem.Size = new System.Drawing.Size(112, 22);
            this.TriggerItem.Text = "Trigger";
            this.TriggerItem.Click += new System.EventHandler(this.TriggerItem_Click);
            // 
            // DeleteEntityItem
            // 
            this.DeleteEntityItem.Name = "DeleteEntityItem";
            this.DeleteEntityItem.Size = new System.Drawing.Size(166, 22);
            this.DeleteEntityItem.Text = "&Delete Entity...";
            this.DeleteEntityItem.Click += new System.EventHandler(this.DeleteEntityItem_Click);
            // 
            // EditEntityItem
            // 
            this.EditEntityItem.Enabled = false;
            this.EditEntityItem.Name = "EditEntityItem";
            this.EditEntityItem.Size = new System.Drawing.Size(166, 22);
            this.EditEntityItem.Text = "&Edit Entity";
            this.EditEntityItem.Click += new System.EventHandler(this.EditEntityItem_Click);
            // 
            // CopyEntityItem
            // 
            this.CopyEntityItem.Enabled = false;
            this.CopyEntityItem.Name = "CopyEntityItem";
            this.CopyEntityItem.Size = new System.Drawing.Size(166, 22);
            this.CopyEntityItem.Text = "Copy Entity";
            this.CopyEntityItem.Click += new System.EventHandler(this.CopyEntityItem_Click);
            // 
            // PasteEntityItem
            // 
            this.PasteEntityItem.Enabled = false;
            this.PasteEntityItem.Name = "PasteEntityItem";
            this.PasteEntityItem.Size = new System.Drawing.Size(166, 22);
            this.PasteEntityItem.Text = "Paste Entity";
            this.PasteEntityItem.Click += new System.EventHandler(this.PasteEntityItem_Click);
            // 
            // MapEditorControl
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::Sphere_Editor.Properties.Resources.editbg;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ContextMenuStrip = this.MapContextStrip;
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.Name = "MapEditorControl";
            this.Size = new System.Drawing.Size(318, 238);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MapEditorControl_Paint);
            this.Enter += new System.EventHandler(this.MapEditorControl_Enter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MapEditorControl_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MapEditorControl_KeyUp);
            this.Leave += new System.EventHandler(this.MapEditorControl_Leave);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MapEditorControl_MouseDown);
            this.MouseLeave += new System.EventHandler(this.MapEditorControl_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MapEditorControl_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MapEditorControl_MouseUp);
            this.MapContextStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip MapContextStrip;
        private System.Windows.Forms.ToolStripMenuItem SelectTileItem;
        private System.Windows.Forms.ToolStripMenuItem StartLocationItem;
        private System.Windows.Forms.ToolStripMenuItem AddEntityItem;
        private System.Windows.Forms.ToolStripMenuItem PersonItem;
        private System.Windows.Forms.ToolStripMenuItem TriggerItem;
        private System.Windows.Forms.ToolStripSeparator ItemSeperator1;
        private System.Windows.Forms.ToolStripMenuItem EditEntityItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteEntityItem;
        private System.Windows.Forms.ToolStripMenuItem SelectLayerItem;
        private System.Windows.Forms.ToolStripMenuItem CopyEntityItem;
        private System.Windows.Forms.ToolStripMenuItem PasteEntityItem;

    }
}
