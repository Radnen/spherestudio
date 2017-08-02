namespace SphereStudio.UI
{
    partial class ScriptEditor
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
            this.fallbackTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // fallbackTextBox
            // 
            this.fallbackTextBox.AcceptsReturn = true;
            this.fallbackTextBox.AcceptsTab = true;
            this.fallbackTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fallbackTextBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fallbackTextBox.Location = new System.Drawing.Point(0, 0);
            this.fallbackTextBox.Multiline = true;
            this.fallbackTextBox.Name = "fallbackTextBox";
            this.fallbackTextBox.Size = new System.Drawing.Size(458, 338);
            this.fallbackTextBox.TabIndex = 0;
            // 
            // ScriptEditShim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.fallbackTextBox);
            this.Name = "ScriptEditShim";
            this.Size = new System.Drawing.Size(458, 338);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox fallbackTextBox;
    }
}
