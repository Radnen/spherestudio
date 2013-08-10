namespace FontEditPlugin
{
    partial class FontSet
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
            this.FontContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ZoomInItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ZoomOutItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FontContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // FontContextMenu
            // 
            this.FontContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ZoomInItem,
            this.ZoomOutItem});
            this.FontContextMenu.Name = "FontContextMenu";
            this.FontContextMenu.Size = new System.Drawing.Size(153, 70);
            // 
            // ZoomInItem
            // 
            this.ZoomInItem.Image = global::FontEditPlugin.Properties.Resources.magnifier_zoom_in;
            this.ZoomInItem.Name = "ZoomInItem";
            this.ZoomInItem.Size = new System.Drawing.Size(152, 22);
            this.ZoomInItem.Text = "Zoom &In";
            this.ZoomInItem.Click += new System.EventHandler(this.ZoomInItem_Click);
            // 
            // ZoomOutItem
            // 
            this.ZoomOutItem.Image = global::FontEditPlugin.Properties.Resources.magnifier_zoom_out;
            this.ZoomOutItem.Name = "ZoomOutItem";
            this.ZoomOutItem.Size = new System.Drawing.Size(152, 22);
            this.ZoomOutItem.Text = "Zoom &Out";
            this.ZoomOutItem.Click += new System.EventHandler(this.ZoomOutItem_Click);
            // 
            // FontSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::FontEditPlugin.Properties.Resources.editbg;
            this.ContextMenuStrip = this.FontContextMenu;
            this.DoubleBuffered = true;
            this.Name = "FontSet";
            this.Size = new System.Drawing.Size(333, 49);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FontSet_Paint);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FontSet_KeyUp);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FontSet_MouseClick);
            this.FontContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip FontContextMenu;
        private System.Windows.Forms.ToolStripMenuItem ZoomInItem;
        private System.Windows.Forms.ToolStripMenuItem ZoomOutItem;
    }
}
