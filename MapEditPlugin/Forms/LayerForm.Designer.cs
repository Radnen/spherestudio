namespace SphereStudio.Plugins.Forms
{
    partial class LayerForm
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
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.parallaxGroup = new System.Windows.Forms.GroupBox();
            this.scrollYLabel = new System.Windows.Forms.Label();
            this.plxYLabel = new System.Windows.Forms.Label();
            this.scrollXLabel = new System.Windows.Forms.Label();
            this.plxXLabel = new System.Windows.Forms.Label();
            this.scrollYSlide = new System.Windows.Forms.TrackBar();
            this.scrollXSlide = new System.Windows.Forms.TrackBar();
            this.plxYSlide = new System.Windows.Forms.TrackBar();
            this.plxXSlide = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.parallaxCheck = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.reflectCheck = new System.Windows.Forms.CheckBox();
            this.visibleCheck = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.xSizeBox = new System.Windows.Forms.NumericUpDown();
            this.ySizeBox = new System.Windows.Forms.NumericUpDown();
            this.parallaxGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scrollYSlide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scrollXSlide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.plxYSlide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.plxXSlide)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xSizeBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ySizeBox)).BeginInit();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.okButton.Location = new System.Drawing.Point(403, 12);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "&Save";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(403, 41);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // nameBox
            // 
            this.nameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameBox.Location = new System.Drawing.Point(50, 12);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(347, 20);
            this.nameBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name";
            // 
            // parallaxGroup
            // 
            this.parallaxGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.parallaxGroup.Controls.Add(this.scrollYLabel);
            this.parallaxGroup.Controls.Add(this.plxYLabel);
            this.parallaxGroup.Controls.Add(this.scrollXLabel);
            this.parallaxGroup.Controls.Add(this.plxXLabel);
            this.parallaxGroup.Controls.Add(this.scrollYSlide);
            this.parallaxGroup.Controls.Add(this.scrollXSlide);
            this.parallaxGroup.Controls.Add(this.plxYSlide);
            this.parallaxGroup.Controls.Add(this.plxXSlide);
            this.parallaxGroup.Controls.Add(this.label3);
            this.parallaxGroup.Controls.Add(this.label2);
            this.parallaxGroup.Location = new System.Drawing.Point(12, 154);
            this.parallaxGroup.Name = "parallaxGroup";
            this.parallaxGroup.Size = new System.Drawing.Size(367, 146);
            this.parallaxGroup.TabIndex = 4;
            this.parallaxGroup.TabStop = false;
            // 
            // scrollYLabel
            // 
            this.scrollYLabel.AutoSize = true;
            this.scrollYLabel.Location = new System.Drawing.Point(318, 108);
            this.scrollYLabel.Name = "scrollYLabel";
            this.scrollYLabel.Size = new System.Drawing.Size(35, 13);
            this.scrollYLabel.TabIndex = 9;
            this.scrollYLabel.Text = "label4";
            // 
            // plxYLabel
            // 
            this.plxYLabel.AutoSize = true;
            this.plxYLabel.Location = new System.Drawing.Point(318, 46);
            this.plxYLabel.Name = "plxYLabel";
            this.plxYLabel.Size = new System.Drawing.Size(35, 13);
            this.plxYLabel.TabIndex = 9;
            this.plxYLabel.Text = "label4";
            // 
            // scrollXLabel
            // 
            this.scrollXLabel.AutoSize = true;
            this.scrollXLabel.Location = new System.Drawing.Point(143, 108);
            this.scrollXLabel.Name = "scrollXLabel";
            this.scrollXLabel.Size = new System.Drawing.Size(35, 13);
            this.scrollXLabel.TabIndex = 9;
            this.scrollXLabel.Text = "label4";
            // 
            // plxXLabel
            // 
            this.plxXLabel.AutoSize = true;
            this.plxXLabel.Location = new System.Drawing.Point(143, 46);
            this.plxXLabel.Name = "plxXLabel";
            this.plxXLabel.Size = new System.Drawing.Size(35, 13);
            this.plxXLabel.TabIndex = 9;
            this.plxXLabel.Text = "label4";
            // 
            // scrollYSlide
            // 
            this.scrollYSlide.AutoSize = false;
            this.scrollYSlide.Location = new System.Drawing.Point(184, 108);
            this.scrollYSlide.Name = "scrollYSlide";
            this.scrollYSlide.Size = new System.Drawing.Size(128, 22);
            this.scrollYSlide.TabIndex = 8;
            this.scrollYSlide.TickStyle = System.Windows.Forms.TickStyle.None;
            this.scrollYSlide.Scroll += new System.EventHandler(this.scrollYSlide_Scroll);
            // 
            // scrollXSlide
            // 
            this.scrollXSlide.AutoSize = false;
            this.scrollXSlide.Location = new System.Drawing.Point(9, 108);
            this.scrollXSlide.Name = "scrollXSlide";
            this.scrollXSlide.Size = new System.Drawing.Size(128, 22);
            this.scrollXSlide.TabIndex = 7;
            this.scrollXSlide.TickStyle = System.Windows.Forms.TickStyle.None;
            this.scrollXSlide.Scroll += new System.EventHandler(this.scrollXSlide_Scroll);
            // 
            // plxYSlide
            // 
            this.plxYSlide.AutoSize = false;
            this.plxYSlide.Location = new System.Drawing.Point(184, 46);
            this.plxYSlide.Name = "plxYSlide";
            this.plxYSlide.Size = new System.Drawing.Size(128, 22);
            this.plxYSlide.TabIndex = 8;
            this.plxYSlide.TickStyle = System.Windows.Forms.TickStyle.None;
            this.plxYSlide.Scroll += new System.EventHandler(this.plxYSlide_Scroll);
            // 
            // plxXSlide
            // 
            this.plxXSlide.AutoSize = false;
            this.plxXSlide.Location = new System.Drawing.Point(9, 46);
            this.plxXSlide.Name = "plxXSlide";
            this.plxXSlide.Size = new System.Drawing.Size(128, 22);
            this.plxXSlide.TabIndex = 7;
            this.plxXSlide.TickStyle = System.Windows.Forms.TickStyle.None;
            this.plxXSlide.Scroll += new System.EventHandler(this.plxXSlide_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Scroll Speed";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Parallax Multiplier";
            // 
            // parallaxCheck
            // 
            this.parallaxCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.parallaxCheck.AutoSize = true;
            this.parallaxCheck.Location = new System.Drawing.Point(21, 154);
            this.parallaxCheck.Name = "parallaxCheck";
            this.parallaxCheck.Size = new System.Drawing.Size(115, 17);
            this.parallaxCheck.TabIndex = 0;
            this.parallaxCheck.Text = "Parallax && Scrolling";
            this.parallaxCheck.UseVisualStyleBackColor = true;
            this.parallaxCheck.CheckedChanged += new System.EventHandler(this.parallaxCheck_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.reflectCheck);
            this.groupBox2.Controls.Add(this.visibleCheck);
            this.groupBox2.Location = new System.Drawing.Point(12, 83);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(367, 49);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Flags";
            // 
            // reflectCheck
            // 
            this.reflectCheck.AutoSize = true;
            this.reflectCheck.Location = new System.Drawing.Point(184, 19);
            this.reflectCheck.Name = "reflectCheck";
            this.reflectCheck.Size = new System.Drawing.Size(74, 17);
            this.reflectCheck.TabIndex = 1;
            this.reflectCheck.Text = "Reflective";
            this.reflectCheck.UseVisualStyleBackColor = true;
            // 
            // visibleCheck
            // 
            this.visibleCheck.AutoSize = true;
            this.visibleCheck.Location = new System.Drawing.Point(83, 19);
            this.visibleCheck.Name = "visibleCheck";
            this.visibleCheck.Size = new System.Drawing.Size(95, 17);
            this.visibleCheck.TabIndex = 0;
            this.visibleCheck.Text = "Layer is Visible";
            this.visibleCheck.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Size";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(97, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "x";
            // 
            // xSizeBox
            // 
            this.xSizeBox.Location = new System.Drawing.Point(50, 38);
            this.xSizeBox.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.xSizeBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.xSizeBox.Name = "xSizeBox";
            this.xSizeBox.Size = new System.Drawing.Size(41, 20);
            this.xSizeBox.TabIndex = 9;
            this.xSizeBox.ThousandsSeparator = true;
            this.xSizeBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ySizeBox
            // 
            this.ySizeBox.Location = new System.Drawing.Point(115, 38);
            this.ySizeBox.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.ySizeBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ySizeBox.Name = "ySizeBox";
            this.ySizeBox.Size = new System.Drawing.Size(41, 20);
            this.ySizeBox.TabIndex = 9;
            this.ySizeBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // LayerForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(490, 312);
            this.Controls.Add(this.ySizeBox);
            this.Controls.Add(this.xSizeBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.parallaxCheck);
            this.Controls.Add(this.parallaxGroup);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LayerForm";
            this.Text = "Layer Properties";
            this.Load += new System.EventHandler(this.LayerForm_Load);
            this.parallaxGroup.ResumeLayout(false);
            this.parallaxGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scrollYSlide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scrollXSlide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.plxYSlide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.plxXSlide)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xSizeBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ySizeBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox parallaxGroup;
        private System.Windows.Forms.CheckBox parallaxCheck;
        private System.Windows.Forms.Label plxYLabel;
        private System.Windows.Forms.Label plxXLabel;
        private System.Windows.Forms.TrackBar plxYSlide;
        private System.Windows.Forms.TrackBar plxXSlide;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label scrollYLabel;
        private System.Windows.Forms.Label scrollXLabel;
        private System.Windows.Forms.TrackBar scrollYSlide;
        private System.Windows.Forms.TrackBar scrollXSlide;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox reflectCheck;
        private System.Windows.Forms.CheckBox visibleCheck;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown xSizeBox;
        private System.Windows.Forms.NumericUpDown ySizeBox;
    }
}