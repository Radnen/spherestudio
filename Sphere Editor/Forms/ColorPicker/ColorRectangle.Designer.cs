namespace Sphere_Editor.Forms.ColorPicker
{
    partial class ColorRectangle
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
            this.SuspendLayout();
            // 
            // ColorRectangle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DoubleBuffered = true;
            this.Name = "ColorRectangle";
            this.Size = new System.Drawing.Size(180, 180);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ColorRectangle_Paint);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ColorRectangle_MouseMove);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ColorRectangle_MouseClick);
            this.Resize += new System.EventHandler(this.ColorRectangle_Resize);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
