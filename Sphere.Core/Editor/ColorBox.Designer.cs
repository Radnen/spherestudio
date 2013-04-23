namespace Sphere.Core.Editor
{
    partial class ColorBox
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
                _outline.Dispose();
                _selection.Dispose();
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
            // ColorBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DoubleBuffered = true;
            this.Name = "ColorBox";
            this.Size = new System.Drawing.Size(48, 48);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ColorBox_Paint);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ColorBox_MouseDoubleClick);
            this.Resize += new System.EventHandler(this.ColorBox_Resize);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
