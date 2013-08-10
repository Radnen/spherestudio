namespace MapEditPlugin.Components
{
    partial class MapControl
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
                if (_base_map != null)
                {
                    _base_map.Dispose();
                    _base_map = null;
                    for (int i = 0; i < GraphicLayers.Count; ++i) GraphicLayers[i].Dispose();
                    GraphicLayers = null;
                    MouseWheel -= MapControl_MouseWheel;
                    Resize -= MapControl_Resize;
                }
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
            this.MapContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SelectItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SetStartItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.CopyEntityItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PasteEntityItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddEntityItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PersonItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TriggerItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditEntityItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteEntityItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteZoneItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditZoneItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vScrollBar = new System.Windows.Forms.VScrollBar();
            this.hScrollBar = new System.Windows.Forms.HScrollBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.MapContextMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MapContextMenu
            // 
            this.MapContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SelectItem,
            this.SetStartItem,
            this.toolStripSeparator1,
            this.CopyEntityItem,
            this.PasteEntityItem,
            this.AddEntityItem,
            this.EditEntityItem,
            this.DeleteEntityItem,
            this.DeleteZoneItem,
            this.EditZoneItem});
            this.MapContextMenu.Name = "MapContextMenu";
            this.MapContextMenu.Size = new System.Drawing.Size(153, 230);
            this.MapContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.MapContextMenu_Opening);
            // 
            // SelectItem
            // 
            this.SelectItem.Image = global::MapEditPlugin.Properties.Resources.pencil;
            this.SelectItem.Name = "SelectItem";
            this.SelectItem.Size = new System.Drawing.Size(152, 22);
            this.SelectItem.Text = "Select &Tile";
            this.SelectItem.Click += new System.EventHandler(this.SelectItem_Click);
            // 
            // SetStartItem
            // 
            this.SetStartItem.Image = global::MapEditPlugin.Properties.Resources.startpos;
            this.SetStartItem.Name = "SetStartItem";
            this.SetStartItem.Size = new System.Drawing.Size(152, 22);
            this.SetStartItem.Text = "Set &Start";
            this.SetStartItem.Click += new System.EventHandler(this.SetStartItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // CopyEntityItem
            // 
            this.CopyEntityItem.Name = "CopyEntityItem";
            this.CopyEntityItem.Size = new System.Drawing.Size(152, 22);
            this.CopyEntityItem.Text = "Copy Entity";
            this.CopyEntityItem.Click += new System.EventHandler(this.CopyEntityItem_Click);
            // 
            // PasteEntityItem
            // 
            this.PasteEntityItem.Name = "PasteEntityItem";
            this.PasteEntityItem.Size = new System.Drawing.Size(152, 22);
            this.PasteEntityItem.Text = "Paste Entity";
            this.PasteEntityItem.Click += new System.EventHandler(this.PasteEntityItem_Click);
            // 
            // AddEntityItem
            // 
            this.AddEntityItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PersonItem,
            this.TriggerItem});
            this.AddEntityItem.Name = "AddEntityItem";
            this.AddEntityItem.Size = new System.Drawing.Size(152, 22);
            this.AddEntityItem.Text = "Add Entity";
            // 
            // PersonItem
            // 
            this.PersonItem.Image = global::MapEditPlugin.Properties.Resources.person;
            this.PersonItem.Name = "PersonItem";
            this.PersonItem.Size = new System.Drawing.Size(112, 22);
            this.PersonItem.Text = "Person";
            this.PersonItem.Click += new System.EventHandler(this.PersonItem_Click);
            // 
            // TriggerItem
            // 
            this.TriggerItem.Image = global::MapEditPlugin.Properties.Resources.trigger;
            this.TriggerItem.Name = "TriggerItem";
            this.TriggerItem.Size = new System.Drawing.Size(112, 22);
            this.TriggerItem.Text = "Trigger";
            this.TriggerItem.Click += new System.EventHandler(this.TriggerItem_Click);
            // 
            // EditEntityItem
            // 
            this.EditEntityItem.Name = "EditEntityItem";
            this.EditEntityItem.Size = new System.Drawing.Size(152, 22);
            this.EditEntityItem.Text = "&Edit Entity...";
            this.EditEntityItem.Click += new System.EventHandler(this.EditEntityItem_Click);
            // 
            // DeleteEntityItem
            // 
            this.DeleteEntityItem.Name = "DeleteEntityItem";
            this.DeleteEntityItem.Size = new System.Drawing.Size(152, 22);
            this.DeleteEntityItem.Text = "&Delete Entity";
            this.DeleteEntityItem.Click += new System.EventHandler(this.DeleteEntityItem_Click);
            // 
            // DeleteZoneItem
            // 
            this.DeleteZoneItem.Name = "DeleteZoneItem";
            this.DeleteZoneItem.Size = new System.Drawing.Size(152, 22);
            this.DeleteZoneItem.Text = "&Delete Zone";
            this.DeleteZoneItem.Click += new System.EventHandler(this.DeleteZoneItem_Click);
            // 
            // EditZoneItem
            // 
            this.EditZoneItem.Name = "EditZoneItem";
            this.EditZoneItem.Size = new System.Drawing.Size(152, 22);
            this.EditZoneItem.Text = "Edit &Zone...";
            this.EditZoneItem.Visible = false;
            this.EditZoneItem.Click += new System.EventHandler(this.EditZoneItem_Click);
            // 
            // vScrollBar
            // 
            this.vScrollBar.Dock = System.Windows.Forms.DockStyle.Right;
            this.vScrollBar.Location = new System.Drawing.Point(286, 0);
            this.vScrollBar.Name = "vScrollBar";
            this.vScrollBar.Size = new System.Drawing.Size(17, 252);
            this.vScrollBar.TabIndex = 1;
            this.vScrollBar.ValueChanged += new System.EventHandler(this.vScrollBar_ValueChanged);
            // 
            // hScrollBar
            // 
            this.hScrollBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.hScrollBar.Location = new System.Drawing.Point(-1, 0);
            this.hScrollBar.Name = "hScrollBar";
            this.hScrollBar.Size = new System.Drawing.Size(287, 17);
            this.hScrollBar.TabIndex = 2;
            this.hScrollBar.ValueChanged += new System.EventHandler(this.hScrollBar_ValueChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.hScrollBar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 252);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(303, 17);
            this.panel1.TabIndex = 3;
            // 
            // MapControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ContextMenuStrip = this.MapContextMenu;
            this.Controls.Add(this.vScrollBar);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Name = "MapControl";
            this.Size = new System.Drawing.Size(303, 269);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MapControl_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MapControl_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MapControl_KeyUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MapControl_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MapControl_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MapControl_MouseUp);
            this.Resize += new System.EventHandler(this.MapControl_Resize);
            this.MapContextMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip MapContextMenu;
        private System.Windows.Forms.ToolStripMenuItem SelectItem;
        private System.Windows.Forms.ToolStripMenuItem SetStartItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem AddEntityItem;
        private System.Windows.Forms.ToolStripMenuItem PersonItem;
        private System.Windows.Forms.ToolStripMenuItem TriggerItem;
        private System.Windows.Forms.ToolStripMenuItem EditEntityItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteEntityItem;
        private System.Windows.Forms.ToolStripMenuItem CopyEntityItem;
        private System.Windows.Forms.ToolStripMenuItem PasteEntityItem;
        private System.Windows.Forms.ToolStripMenuItem EditZoneItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteZoneItem;
        private System.Windows.Forms.VScrollBar vScrollBar;
        private System.Windows.Forms.HScrollBar hScrollBar;
        private System.Windows.Forms.Panel panel1;
    }
}
