namespace MapEditorPlugin.Components
{
    partial class LayerControl
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
                if (Items != null)
                    foreach (LayerItem item in Items) item.Dispose();
                Items = null;
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
            this.SuspendLayout();
            // 
            // LayerControl
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "LayerControl";
            this.Size = new System.Drawing.Size(156, 222);
            this.Load += new System.EventHandler(this.LayerControl_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.LayerControl_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.LayerControl_DragEnter);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.LayerControl_DragOver);
            this.DragLeave += new System.EventHandler(this.LayerControl_DragLeave);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.LayerControl_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LayerControl_MouseDown);
            this.MouseLeave += new System.EventHandler(this.LayerControl_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LayerControl_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LayerControl_MouseUp);
            this.Resize += new System.EventHandler(this.LayerControl_Resize);
            this.ResumeLayout(false);

        }

        #endregion





    }
}
