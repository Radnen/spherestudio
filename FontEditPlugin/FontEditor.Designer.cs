namespace FontEditPlugin
{
    partial class FontEditor
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
            this.FontSplitter = new System.Windows.Forms.SplitContainer();
            this.FontSettingPanel = new System.Windows.Forms.Panel();
            this.InfoPanel = new System.Windows.Forms.Panel();
            this.FontSizeLabel = new System.Windows.Forms.Label();
            this.CharacterLabel = new System.Windows.Forms.Label();
            this.NumLabel = new System.Windows.Forms.Label();
            this.FontPreviewer = new System.Windows.Forms.Panel();
            this.PreviewImageBox = new System.Windows.Forms.PictureBox();
            this.PreviewTextBox = new System.Windows.Forms.TextBox();
            this.FontPreviewLabel = new Sphere.Core.Editor.EditorLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.FontGenPanel = new System.Windows.Forms.Panel();
            this.StrokeColorLabel = new System.Windows.Forms.Label();
            this.StrokeColor = new Sphere.Core.Editor.ColorBox();
            this.GradientCheckBox = new System.Windows.Forms.CheckBox();
            this.GenerateButton = new System.Windows.Forms.Button();
            this.FontGenLabel = new Sphere.Core.Editor.EditorLabel();
            this.GradientTop = new Sphere.Core.Editor.ColorBox();
            this.StrokeCheck = new System.Windows.Forms.CheckBox();
            this.GradientBottom = new Sphere.Core.Editor.ColorBox();
            this.BottomLabel = new System.Windows.Forms.Label();
            this.TopLabel = new System.Windows.Forms.Label();
            this.FontPanel = new Sphere.Core.Editor.EditorPanel();
            this.FontSplitter.Panel1.SuspendLayout();
            this.FontSplitter.Panel2.SuspendLayout();
            this.FontSplitter.SuspendLayout();
            this.FontSettingPanel.SuspendLayout();
            this.InfoPanel.SuspendLayout();
            this.FontPreviewer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PreviewImageBox)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.FontGenPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // FontSplitter
            // 
            this.FontSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FontSplitter.Location = new System.Drawing.Point(0, 0);
            this.FontSplitter.Name = "FontSplitter";
            this.FontSplitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // FontSplitter.Panel1
            // 
            this.FontSplitter.Panel1.Controls.Add(this.FontSettingPanel);
            // 
            // FontSplitter.Panel2
            // 
            this.FontSplitter.Panel2.AutoScroll = true;
            this.FontSplitter.Panel2.Controls.Add(this.splitContainer1);
            this.FontSplitter.Size = new System.Drawing.Size(549, 434);
            this.FontSplitter.SplitterDistance = 152;
            this.FontSplitter.TabIndex = 1;
            // 
            // FontSettingPanel
            // 
            this.FontSettingPanel.Controls.Add(this.InfoPanel);
            this.FontSettingPanel.Controls.Add(this.FontPreviewer);
            this.FontSettingPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FontSettingPanel.Location = new System.Drawing.Point(0, 0);
            this.FontSettingPanel.Name = "FontSettingPanel";
            this.FontSettingPanel.Size = new System.Drawing.Size(549, 152);
            this.FontSettingPanel.TabIndex = 1;
            // 
            // InfoPanel
            // 
            this.InfoPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.InfoPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.InfoPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InfoPanel.Controls.Add(this.FontSizeLabel);
            this.InfoPanel.Controls.Add(this.CharacterLabel);
            this.InfoPanel.Controls.Add(this.NumLabel);
            this.InfoPanel.Location = new System.Drawing.Point(6, 6);
            this.InfoPanel.Margin = new System.Windows.Forms.Padding(6);
            this.InfoPanel.Name = "InfoPanel";
            this.InfoPanel.Size = new System.Drawing.Size(122, 140);
            this.InfoPanel.TabIndex = 4;
            // 
            // FontSizeLabel
            // 
            this.FontSizeLabel.AutoSize = true;
            this.FontSizeLabel.BackColor = System.Drawing.Color.Transparent;
            this.FontSizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FontSizeLabel.Location = new System.Drawing.Point(3, 4);
            this.FontSizeLabel.Name = "FontSizeLabel";
            this.FontSizeLabel.Size = new System.Drawing.Size(80, 16);
            this.FontSizeLabel.TabIndex = 0;
            this.FontSizeLabel.Text = "Size: 16 x 16";
            // 
            // CharacterLabel
            // 
            this.CharacterLabel.AutoSize = true;
            this.CharacterLabel.BackColor = System.Drawing.Color.Transparent;
            this.CharacterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CharacterLabel.Location = new System.Drawing.Point(3, 57);
            this.CharacterLabel.Name = "CharacterLabel";
            this.CharacterLabel.Size = new System.Drawing.Size(51, 16);
            this.CharacterLabel.TabIndex = 3;
            this.CharacterLabel.Text = "Char: A";
            // 
            // NumLabel
            // 
            this.NumLabel.AutoSize = true;
            this.NumLabel.BackColor = System.Drawing.Color.Transparent;
            this.NumLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumLabel.Location = new System.Drawing.Point(3, 30);
            this.NumLabel.Name = "NumLabel";
            this.NumLabel.Size = new System.Drawing.Size(56, 16);
            this.NumLabel.TabIndex = 2;
            this.NumLabel.Text = "Num: 65";
            // 
            // FontPreviewer
            // 
            this.FontPreviewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.FontPreviewer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.FontPreviewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FontPreviewer.Controls.Add(this.PreviewImageBox);
            this.FontPreviewer.Controls.Add(this.PreviewTextBox);
            this.FontPreviewer.Controls.Add(this.FontPreviewLabel);
            this.FontPreviewer.Location = new System.Drawing.Point(136, 6);
            this.FontPreviewer.Margin = new System.Windows.Forms.Padding(6);
            this.FontPreviewer.Name = "FontPreviewer";
            this.FontPreviewer.Size = new System.Drawing.Size(407, 140);
            this.FontPreviewer.TabIndex = 1;
            // 
            // PreviewImageBox
            // 
            this.PreviewImageBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.PreviewImageBox.BackColor = System.Drawing.Color.DimGray;
            this.PreviewImageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PreviewImageBox.Location = new System.Drawing.Point(3, 50);
            this.PreviewImageBox.Name = "PreviewImageBox";
            this.PreviewImageBox.Size = new System.Drawing.Size(399, 85);
            this.PreviewImageBox.TabIndex = 2;
            this.PreviewImageBox.TabStop = false;
            this.PreviewImageBox.Resize += new System.EventHandler(this.PreviewImageBox_Resize);
            // 
            // PreviewTextBox
            // 
            this.PreviewTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.PreviewTextBox.Location = new System.Drawing.Point(3, 24);
            this.PreviewTextBox.Name = "PreviewTextBox";
            this.PreviewTextBox.Size = new System.Drawing.Size(399, 20);
            this.PreviewTextBox.TabIndex = 1;
            this.PreviewTextBox.Text = "Preview";
            this.PreviewTextBox.TextChanged += new System.EventHandler(this.PreviewTextBox_TextChanged);
            // 
            // FontPreviewLabel
            // 
            this.FontPreviewLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(225)))), ((int)(((byte)(243)))));
            this.FontPreviewLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.FontPreviewLabel.Font = new System.Drawing.Font("Verdana", 10.5F);
            this.FontPreviewLabel.ForeColor = System.Drawing.Color.MidnightBlue;
            this.FontPreviewLabel.Location = new System.Drawing.Point(0, 0);
            this.FontPreviewLabel.Name = "FontPreviewLabel";
            this.FontPreviewLabel.Size = new System.Drawing.Size(405, 23);
            this.FontPreviewLabel.TabIndex = 3;
            this.FontPreviewLabel.Text = "Font Preview";
            this.FontPreviewLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.FontGenPanel);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.FontPanel);
            this.splitContainer1.Size = new System.Drawing.Size(549, 278);
            this.splitContainer1.SplitterDistance = 149;
            this.splitContainer1.TabIndex = 2;
            // 
            // FontGenPanel
            // 
            this.FontGenPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.FontGenPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.FontGenPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FontGenPanel.Controls.Add(this.StrokeColorLabel);
            this.FontGenPanel.Controls.Add(this.StrokeColor);
            this.FontGenPanel.Controls.Add(this.GradientCheckBox);
            this.FontGenPanel.Controls.Add(this.GenerateButton);
            this.FontGenPanel.Controls.Add(this.FontGenLabel);
            this.FontGenPanel.Controls.Add(this.GradientTop);
            this.FontGenPanel.Controls.Add(this.StrokeCheck);
            this.FontGenPanel.Controls.Add(this.GradientBottom);
            this.FontGenPanel.Controls.Add(this.BottomLabel);
            this.FontGenPanel.Controls.Add(this.TopLabel);
            this.FontGenPanel.Location = new System.Drawing.Point(4, 4);
            this.FontGenPanel.Margin = new System.Windows.Forms.Padding(6);
            this.FontGenPanel.Name = "FontGenPanel";
            this.FontGenPanel.Size = new System.Drawing.Size(537, 135);
            this.FontGenPanel.TabIndex = 11;
            // 
            // StrokeColorLabel
            // 
            this.StrokeColorLabel.AutoSize = true;
            this.StrokeColorLabel.Location = new System.Drawing.Point(206, 37);
            this.StrokeColorLabel.Name = "StrokeColorLabel";
            this.StrokeColorLabel.Size = new System.Drawing.Size(65, 13);
            this.StrokeColorLabel.TabIndex = 13;
            this.StrokeColorLabel.Text = "Stroke Color";
            // 
            // StrokeColor
            // 
            this.StrokeColor.Location = new System.Drawing.Point(153, 26);
            this.StrokeColor.Name = "StrokeColor";
            this.StrokeColor.Selected = false;
            this.StrokeColor.SelectedColor = System.Drawing.Color.White;
            this.StrokeColor.Size = new System.Drawing.Size(47, 35);
            this.StrokeColor.TabIndex = 12;
            this.StrokeColor.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GradientTop_MouseClick);
            // 
            // GradientCheckBox
            // 
            this.GradientCheckBox.AutoSize = true;
            this.GradientCheckBox.Location = new System.Drawing.Point(153, 76);
            this.GradientCheckBox.Name = "GradientCheckBox";
            this.GradientCheckBox.Size = new System.Drawing.Size(88, 17);
            this.GradientCheckBox.TabIndex = 11;
            this.GradientCheckBox.Text = "Use Gradient";
            this.GradientCheckBox.UseVisualStyleBackColor = true;
            // 
            // GenerateButton
            // 
            this.GenerateButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.GenerateButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.GenerateButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.GenerateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GenerateButton.Location = new System.Drawing.Point(281, 66);
            this.GenerateButton.Name = "GenerateButton";
            this.GenerateButton.Size = new System.Drawing.Size(111, 34);
            this.GenerateButton.TabIndex = 4;
            this.GenerateButton.Text = "Generate Font";
            this.GenerateButton.UseVisualStyleBackColor = true;
            this.GenerateButton.Click += new System.EventHandler(this.GenerateButton_Click);
            // 
            // FontGenLabel
            // 
            this.FontGenLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(225)))), ((int)(((byte)(243)))));
            this.FontGenLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.FontGenLabel.Font = new System.Drawing.Font("Verdana", 10.5F);
            this.FontGenLabel.ForeColor = System.Drawing.Color.MidnightBlue;
            this.FontGenLabel.Location = new System.Drawing.Point(0, 0);
            this.FontGenLabel.Name = "FontGenLabel";
            this.FontGenLabel.Size = new System.Drawing.Size(535, 23);
            this.FontGenLabel.TabIndex = 3;
            this.FontGenLabel.Text = "Font Generator";
            this.FontGenLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GradientTop
            // 
            this.GradientTop.Location = new System.Drawing.Point(3, 26);
            this.GradientTop.Name = "GradientTop";
            this.GradientTop.Selected = false;
            this.GradientTop.SelectedColor = System.Drawing.Color.White;
            this.GradientTop.Size = new System.Drawing.Size(47, 35);
            this.GradientTop.TabIndex = 5;
            this.GradientTop.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GradientTop_MouseClick);
            // 
            // StrokeCheck
            // 
            this.StrokeCheck.AutoSize = true;
            this.StrokeCheck.Location = new System.Drawing.Point(281, 36);
            this.StrokeCheck.Name = "StrokeCheck";
            this.StrokeCheck.Size = new System.Drawing.Size(79, 17);
            this.StrokeCheck.TabIndex = 9;
            this.StrokeCheck.Text = "Use Stroke";
            this.StrokeCheck.UseVisualStyleBackColor = true;
            // 
            // GradientBottom
            // 
            this.GradientBottom.Location = new System.Drawing.Point(2, 67);
            this.GradientBottom.Name = "GradientBottom";
            this.GradientBottom.Selected = false;
            this.GradientBottom.SelectedColor = System.Drawing.Color.White;
            this.GradientBottom.Size = new System.Drawing.Size(47, 35);
            this.GradientBottom.TabIndex = 6;
            this.GradientBottom.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GradientTop_MouseClick);
            // 
            // BottomLabel
            // 
            this.BottomLabel.AutoSize = true;
            this.BottomLabel.Location = new System.Drawing.Point(55, 77);
            this.BottomLabel.Name = "BottomLabel";
            this.BottomLabel.Size = new System.Drawing.Size(83, 13);
            this.BottomLabel.TabIndex = 8;
            this.BottomLabel.Text = "Gradient Bottom";
            // 
            // TopLabel
            // 
            this.TopLabel.AutoSize = true;
            this.TopLabel.Location = new System.Drawing.Point(56, 37);
            this.TopLabel.Name = "TopLabel";
            this.TopLabel.Size = new System.Drawing.Size(69, 13);
            this.TopLabel.TabIndex = 7;
            this.TopLabel.Text = "Gradient Top";
            // 
            // FontPanel
            // 
            this.FontPanel.AutoScroll = true;
            this.FontPanel.BackColor = System.Drawing.SystemColors.Control;
            this.FontPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FontPanel.Location = new System.Drawing.Point(0, 0);
            this.FontPanel.Name = "FontPanel";
            this.FontPanel.Size = new System.Drawing.Size(545, 121);
            this.FontPanel.TabIndex = 0;
            this.FontPanel.XSnap = 0;
            this.FontPanel.YSnap = 0;
            this.FontPanel.Scroll += new System.Windows.Forms.ScrollEventHandler(this.FontPanel_Scroll);
            // 
            // FontEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.FontSplitter);
            this.Name = "FontEditor";
            this.Size = new System.Drawing.Size(549, 434);
            this.FontSplitter.Panel1.ResumeLayout(false);
            this.FontSplitter.Panel2.ResumeLayout(false);
            this.FontSplitter.ResumeLayout(false);
            this.FontSettingPanel.ResumeLayout(false);
            this.InfoPanel.ResumeLayout(false);
            this.InfoPanel.PerformLayout();
            this.FontPreviewer.ResumeLayout(false);
            this.FontPreviewer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PreviewImageBox)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.FontGenPanel.ResumeLayout(false);
            this.FontGenPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer FontSplitter;
        private Sphere.Core.Editor.EditorPanel FontPanel;
        private System.Windows.Forms.Panel FontSettingPanel;
        private System.Windows.Forms.Label FontSizeLabel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel FontPreviewer;
        private System.Windows.Forms.PictureBox PreviewImageBox;
        private System.Windows.Forms.TextBox PreviewTextBox;
        private System.Windows.Forms.Label CharacterLabel;
        private System.Windows.Forms.Label NumLabel;
        private Sphere.Core.Editor.EditorLabel FontPreviewLabel;
        private System.Windows.Forms.Panel InfoPanel;
        private System.Windows.Forms.Button GenerateButton;
        private Sphere.Core.Editor.ColorBox GradientBottom;
        private Sphere.Core.Editor.ColorBox GradientTop;
        private System.Windows.Forms.Panel FontGenPanel;
        private Sphere.Core.Editor.EditorLabel FontGenLabel;
        private System.Windows.Forms.CheckBox StrokeCheck;
        private System.Windows.Forms.Label BottomLabel;
        private System.Windows.Forms.Label TopLabel;
        private System.Windows.Forms.CheckBox GradientCheckBox;
        private System.Windows.Forms.Label StrokeColorLabel;
        private Sphere.Core.Editor.ColorBox StrokeColor;
    }
}
