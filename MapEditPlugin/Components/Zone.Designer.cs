namespace Sphere_Editor.EditorComponents
{
    partial class ZoneControl
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
            this.ZoneMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.EditZoneItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DestroyZoneItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ZoneMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ZoneMenuStrip
            // 
            this.ZoneMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EditZoneItem,
            this.DestroyZoneItem});
            this.ZoneMenuStrip.Name = "ZoneMenuStrip";
            this.ZoneMenuStrip.ShowImageMargin = false;
            this.ZoneMenuStrip.Size = new System.Drawing.Size(123, 48);
            // 
            // EditZoneItem
            // 
            this.EditZoneItem.Name = "EditZoneItem";
            this.EditZoneItem.Size = new System.Drawing.Size(152, 22);
            this.EditZoneItem.Text = "Edit Zone";
            this.EditZoneItem.Click += new System.EventHandler(this.EditZoneItem_Click);
            // 
            // DestroyZoneItem
            // 
            this.DestroyZoneItem.Name = "DestroyZoneItem";
            this.DestroyZoneItem.Size = new System.Drawing.Size(152, 22);
            this.DestroyZoneItem.Text = "Destroy Zone";
            this.DestroyZoneItem.Click += new System.EventHandler(this.DestroyZoneItem_Click);
            // 
            // Zone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.DoubleBuffered = true;
            this.Name = "Zone";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Zone_Paint);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Zone_MouseMove);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Zone_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Zone_MouseUp);
            this.ZoneMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip ZoneMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem EditZoneItem;
        private System.Windows.Forms.ToolStripMenuItem DestroyZoneItem;

    }
}
