namespace Sphere_Editor.Forms.ColorPicker
{
    partial class ColorPicker
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColorPicker));
            this.BitDepthBox = new System.Windows.Forms.ComboBox();
            this.BitDepthLabel = new System.Windows.Forms.Label();
            this.OkayButton = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.ColorGroup = new System.Windows.Forms.GroupBox();
            this.ColorSlider = new System.Windows.Forms.Panel();
            this.PaletteGroup = new System.Windows.Forms.GroupBox();
            this.PreviousLabel = new System.Windows.Forms.Label();
            this.SelectedLabel = new System.Windows.Forms.Label();
            this.PreviousColorBox = new Sphere.Core.Editor.ColorBox();
            this.SelectedColorBox = new Sphere.Core.Editor.ColorBox();
            this.ColorRect = new Sphere_Editor.Forms.ColorPicker.ColorRectangle();
            this.ColorGroup.SuspendLayout();
            this.PaletteGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // BitDepthBox
            // 
            this.BitDepthBox.FormattingEnabled = true;
            this.BitDepthBox.Items.AddRange(new object[] {
            "Bit Depth:",
            "32 bit",
            "24 bit",
            "16 bit",
            "8 bit",
            "Grayscale"});
            this.BitDepthBox.Location = new System.Drawing.Point(95, 12);
            this.BitDepthBox.Name = "BitDepthBox";
            this.BitDepthBox.Size = new System.Drawing.Size(252, 21);
            this.BitDepthBox.TabIndex = 0;
            // 
            // BitDepthLabel
            // 
            this.BitDepthLabel.AutoSize = true;
            this.BitDepthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BitDepthLabel.Location = new System.Drawing.Point(9, 15);
            this.BitDepthLabel.Name = "BitDepthLabel";
            this.BitDepthLabel.Size = new System.Drawing.Size(64, 13);
            this.BitDepthLabel.TabIndex = 1;
            this.BitDepthLabel.Text = "Bit Depth:";
            // 
            // OkayButton
            // 
            this.OkayButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OkayButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkayButton.Location = new System.Drawing.Point(545, 299);
            this.OkayButton.Name = "OkayButton";
            this.OkayButton.Size = new System.Drawing.Size(75, 23);
            this.OkayButton.TabIndex = 2;
            this.OkayButton.Text = "Okay";
            this.OkayButton.UseVisualStyleBackColor = true;
            // 
            // CancelBtn
            // 
            this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(464, 299);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 3;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            // 
            // ColorGroup
            // 
            this.ColorGroup.Controls.Add(this.ColorRect);
            this.ColorGroup.Controls.Add(this.ColorSlider);
            this.ColorGroup.Location = new System.Drawing.Point(12, 36);
            this.ColorGroup.Name = "ColorGroup";
            this.ColorGroup.Size = new System.Drawing.Size(335, 281);
            this.ColorGroup.TabIndex = 4;
            this.ColorGroup.TabStop = false;
            this.ColorGroup.Text = "Color Group";
            // 
            // ColorSlider
            // 
            this.ColorSlider.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ColorSlider.Location = new System.Drawing.Point(284, 19);
            this.ColorSlider.Name = "ColorSlider";
            this.ColorSlider.Size = new System.Drawing.Size(32, 255);
            this.ColorSlider.TabIndex = 1;
            this.ColorSlider.Paint += new System.Windows.Forms.PaintEventHandler(this.ColorSlider_Paint);
            this.ColorSlider.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ColorSlider_MouseClick);
            // 
            // PaletteGroup
            // 
            this.PaletteGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.PaletteGroup.Controls.Add(this.PreviousLabel);
            this.PaletteGroup.Controls.Add(this.SelectedLabel);
            this.PaletteGroup.Controls.Add(this.PreviousColorBox);
            this.PaletteGroup.Controls.Add(this.SelectedColorBox);
            this.PaletteGroup.Location = new System.Drawing.Point(353, 12);
            this.PaletteGroup.Name = "PaletteGroup";
            this.PaletteGroup.Size = new System.Drawing.Size(267, 281);
            this.PaletteGroup.TabIndex = 5;
            this.PaletteGroup.TabStop = false;
            this.PaletteGroup.Text = "Palette Group";
            // 
            // PreviousLabel
            // 
            this.PreviousLabel.AutoSize = true;
            this.PreviousLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PreviousLabel.Location = new System.Drawing.Point(138, 203);
            this.PreviousLabel.Name = "PreviousLabel";
            this.PreviousLabel.Size = new System.Drawing.Size(89, 13);
            this.PreviousLabel.TabIndex = 3;
            this.PreviousLabel.Text = "Previous Color";
            // 
            // SelectedLabel
            // 
            this.SelectedLabel.AutoSize = true;
            this.SelectedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedLabel.Location = new System.Drawing.Point(6, 203);
            this.SelectedLabel.Name = "SelectedLabel";
            this.SelectedLabel.Size = new System.Drawing.Size(90, 13);
            this.SelectedLabel.TabIndex = 2;
            this.SelectedLabel.Text = "Selected Color";
            // 
            // PreviousColorBox
            // 
            this.PreviousColorBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PreviousColorBox.Location = new System.Drawing.Point(141, 219);
            this.PreviousColorBox.Name = "PreviousColorBox";
            this.PreviousColorBox.Selected = false;
            this.PreviousColorBox.SelectedColor = System.Drawing.Color.White;
            this.PreviousColorBox.Size = new System.Drawing.Size(120, 56);
            this.PreviousColorBox.TabIndex = 1;
            // 
            // SelectedColorBox
            // 
            this.SelectedColorBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SelectedColorBox.Location = new System.Drawing.Point(9, 219);
            this.SelectedColorBox.Name = "SelectedColorBox";
            this.SelectedColorBox.Selected = false;
            this.SelectedColorBox.SelectedColor = System.Drawing.Color.White;
            this.SelectedColorBox.Size = new System.Drawing.Size(120, 56);
            this.SelectedColorBox.TabIndex = 0;
            // 
            // ColorRect
            // 
            this.ColorRect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ColorRect.FillColor = System.Drawing.Color.Blue;
            this.ColorRect.Location = new System.Drawing.Point(6, 19);
            this.ColorRect.Name = "ColorRect";
            this.ColorRect.Size = new System.Drawing.Size(255, 255);
            this.ColorRect.TabIndex = 2;
            this.ColorRect.ColorSelected += new Sphere_Editor.Forms.ColorPicker.ColorRectangle.EventHandler(this.ColorRect_ColorSelected);
            this.ColorRect.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ColorRect_MouseUp);
            // 
            // ColorPicker
            // 
            this.AcceptButton = this.OkayButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(632, 329);
            this.Controls.Add(this.PaletteGroup);
            this.Controls.Add(this.ColorGroup);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.OkayButton);
            this.Controls.Add(this.BitDepthLabel);
            this.Controls.Add(this.BitDepthBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ColorPicker";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "ColorPicker";
            this.ColorGroup.ResumeLayout(false);
            this.PaletteGroup.ResumeLayout(false);
            this.PaletteGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox BitDepthBox;
        private System.Windows.Forms.Label BitDepthLabel;
        private System.Windows.Forms.Button OkayButton;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.GroupBox ColorGroup;
        private System.Windows.Forms.Panel ColorSlider;
        private System.Windows.Forms.GroupBox PaletteGroup;
        private ColorRectangle ColorRect;
        private Sphere.Core.Editor.ColorBox SelectedColorBox;
        private Sphere.Core.Editor.ColorBox PreviousColorBox;
        private System.Windows.Forms.Label PreviousLabel;
        private System.Windows.Forms.Label SelectedLabel;
    }
}