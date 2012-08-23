namespace Sphere_Editor.EditorComponents
{
    partial class ImageEditControl2
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
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selectColorItem = new System.Windows.Forms.ToolStripMenuItem();
            this.replaceColorItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sep1 = new System.Windows.Forms.ToolStripSeparator();
            this.blendModeItem = new System.Windows.Forms.ToolStripMenuItem();
            this.replaceItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blendItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flipItem = new System.Windows.Forms.ToolStripMenuItem();
            this.horizontalItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verticalItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotateLeftItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotateRightItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sep2 = new System.Windows.Forms.ToolStripSeparator();
            this.copyImageItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteImageItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteNewItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteIntoItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectColorItem,
            this.replaceColorItem,
            this.sep1,
            this.blendModeItem,
            this.flipItem,
            this.sep2,
            this.copyImageItem,
            this.pasteImageItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(153, 170);
            this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
            // 
            // selectColorItem
            // 
            this.selectColorItem.Image = global::Sphere_Editor.Properties.Resources.pencil;
            this.selectColorItem.Name = "selectColorItem";
            this.selectColorItem.Size = new System.Drawing.Size(152, 22);
            this.selectColorItem.Text = "&Select Color";
            this.selectColorItem.Click += new System.EventHandler(this.selectColorItem_Click);
            // 
            // replaceColorItem
            // 
            this.replaceColorItem.Image = global::Sphere_Editor.Properties.Resources.paintcan;
            this.replaceColorItem.Name = "replaceColorItem";
            this.replaceColorItem.Size = new System.Drawing.Size(152, 22);
            this.replaceColorItem.Text = "&Replace Color";
            this.replaceColorItem.Click += new System.EventHandler(this.replaceColorItem_Click);
            // 
            // sep1
            // 
            this.sep1.Name = "sep1";
            this.sep1.Size = new System.Drawing.Size(149, 6);
            // 
            // blendModeItem
            // 
            this.blendModeItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.replaceItem,
            this.blendItem});
            this.blendModeItem.Name = "blendModeItem";
            this.blendModeItem.Size = new System.Drawing.Size(152, 22);
            this.blendModeItem.Text = "&Blend Mode";
            // 
            // replaceItem
            // 
            this.replaceItem.Checked = true;
            this.replaceItem.CheckOnClick = true;
            this.replaceItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.replaceItem.Name = "replaceItem";
            this.replaceItem.Size = new System.Drawing.Size(115, 22);
            this.replaceItem.Text = "Replace";
            this.replaceItem.Click += new System.EventHandler(this.replaceItem_Click);
            // 
            // blendItem
            // 
            this.blendItem.CheckOnClick = true;
            this.blendItem.Name = "blendItem";
            this.blendItem.Size = new System.Drawing.Size(115, 22);
            this.blendItem.Text = "Blend";
            this.blendItem.Click += new System.EventHandler(this.blendItem_Click);
            // 
            // flipItem
            // 
            this.flipItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.horizontalItem,
            this.verticalItem,
            this.rotateLeftItem,
            this.rotateRightItem});
            this.flipItem.Name = "flipItem";
            this.flipItem.Size = new System.Drawing.Size(152, 22);
            this.flipItem.Text = "&Edit";
            // 
            // horizontalItem
            // 
            this.horizontalItem.Name = "horizontalItem";
            this.horizontalItem.Size = new System.Drawing.Size(152, 22);
            this.horizontalItem.Text = "Flip Horizontal";
            this.horizontalItem.Click += new System.EventHandler(this.horizontalItem_Click);
            // 
            // verticalItem
            // 
            this.verticalItem.Name = "verticalItem";
            this.verticalItem.Size = new System.Drawing.Size(152, 22);
            this.verticalItem.Text = "Flip Vertical";
            this.verticalItem.Click += new System.EventHandler(this.verticalItem_Click);
            // 
            // rotateLeftItem
            // 
            this.rotateLeftItem.Name = "rotateLeftItem";
            this.rotateLeftItem.Size = new System.Drawing.Size(152, 22);
            this.rotateLeftItem.Text = "Rotate Left";
            this.rotateLeftItem.Click += new System.EventHandler(this.rotateLeftItem_Click);
            // 
            // rotateRightItem
            // 
            this.rotateRightItem.Name = "rotateRightItem";
            this.rotateRightItem.Size = new System.Drawing.Size(152, 22);
            this.rotateRightItem.Text = "Rotate Right";
            this.rotateRightItem.Click += new System.EventHandler(this.rotateRightItem_Click);
            // 
            // sep2
            // 
            this.sep2.Name = "sep2";
            this.sep2.Size = new System.Drawing.Size(149, 6);
            // 
            // copyImageItem
            // 
            this.copyImageItem.Image = global::Sphere_Editor.Properties.Resources.page_copy;
            this.copyImageItem.Name = "copyImageItem";
            this.copyImageItem.Size = new System.Drawing.Size(152, 22);
            this.copyImageItem.Text = "&Copy Image";
            this.copyImageItem.Click += new System.EventHandler(this.copyImageItem_Click);
            // 
            // pasteImageItem
            // 
            this.pasteImageItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pasteNewItem,
            this.pasteIntoItem});
            this.pasteImageItem.Image = global::Sphere_Editor.Properties.Resources.paste_plain;
            this.pasteImageItem.Name = "pasteImageItem";
            this.pasteImageItem.Size = new System.Drawing.Size(152, 22);
            this.pasteImageItem.Text = "&Paste Image";
            // 
            // pasteNewItem
            // 
            this.pasteNewItem.Name = "pasteNewItem";
            this.pasteNewItem.Size = new System.Drawing.Size(129, 22);
            this.pasteNewItem.Text = "Paste New";
            this.pasteNewItem.Click += new System.EventHandler(this.pasteNewItem_Click);
            // 
            // pasteIntoItem
            // 
            this.pasteIntoItem.Name = "pasteIntoItem";
            this.pasteIntoItem.Size = new System.Drawing.Size(129, 22);
            this.pasteIntoItem.Text = "Paste Into";
            this.pasteIntoItem.Click += new System.EventHandler(this.pasteIntoItem_Click);
            // 
            // ImageEditControl2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ContextMenuStrip = this.contextMenuStrip;
            this.DoubleBuffered = true;
            this.Name = "ImageEditControl2";
            this.Size = new System.Drawing.Size(148, 148);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ImageEditControl2_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ImageEditControl2_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ImageEditControl2_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ImageEditControl2_MouseUp);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem selectColorItem;
        private System.Windows.Forms.ToolStripMenuItem replaceColorItem;
        private System.Windows.Forms.ToolStripSeparator sep2;
        private System.Windows.Forms.ToolStripMenuItem copyImageItem;
        private System.Windows.Forms.ToolStripMenuItem pasteImageItem;
        private System.Windows.Forms.ToolStripSeparator sep1;
        private System.Windows.Forms.ToolStripMenuItem blendModeItem;
        private System.Windows.Forms.ToolStripMenuItem replaceItem;
        private System.Windows.Forms.ToolStripMenuItem blendItem;
        private System.Windows.Forms.ToolStripMenuItem flipItem;
        private System.Windows.Forms.ToolStripMenuItem horizontalItem;
        private System.Windows.Forms.ToolStripMenuItem verticalItem;
        private System.Windows.Forms.ToolStripMenuItem pasteNewItem;
        private System.Windows.Forms.ToolStripMenuItem pasteIntoItem;
        private System.Windows.Forms.ToolStripMenuItem rotateLeftItem;
        private System.Windows.Forms.ToolStripMenuItem rotateRightItem;
    }
}
