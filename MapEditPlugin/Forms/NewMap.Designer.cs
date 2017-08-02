namespace SphereStudio.Plugins.Forms
{
    partial class NewMapDialogue
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
            this.OkayButton = new System.Windows.Forms.Button();
            this.CnclButton = new System.Windows.Forms.Button();
            this.SizePanel = new System.Windows.Forms.Panel();
            this.HeightTextBox = new System.Windows.Forms.TextBox();
            this.XLabel = new System.Windows.Forms.Label();
            this.WidthTextBox = new System.Windows.Forms.TextBox();
            this.SizeLabel = new SphereStudio.UI.DialogHeader();
            this.TilesetPanel = new System.Windows.Forms.Panel();
            this.TilesetButton = new System.Windows.Forms.Button();
            this.TilesetTextBox = new System.Windows.Forms.TextBox();
            this.UseExistingCheckBox = new System.Windows.Forms.CheckBox();
            this.TilesetLabel = new SphereStudio.UI.DialogHeader();
            this.ImageBox = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TileHeightTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TileWidthTextBox = new System.Windows.Forms.TextBox();
            this.TileLabel = new SphereStudio.UI.DialogHeader();
            this.SizePanel.SuspendLayout();
            this.TilesetPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // OkayButton
            // 
            this.OkayButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OkayButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkayButton.Location = new System.Drawing.Point(233, 203);
            this.OkayButton.Name = "OkayButton";
            this.OkayButton.Size = new System.Drawing.Size(75, 23);
            this.OkayButton.TabIndex = 0;
            this.OkayButton.Text = "Create";
            this.OkayButton.UseVisualStyleBackColor = true;
            // 
            // CnclButton
            // 
            this.CnclButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CnclButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CnclButton.Location = new System.Drawing.Point(152, 203);
            this.CnclButton.Name = "CnclButton";
            this.CnclButton.Size = new System.Drawing.Size(75, 23);
            this.CnclButton.TabIndex = 1;
            this.CnclButton.Text = "Cancel";
            this.CnclButton.UseVisualStyleBackColor = true;
            // 
            // SizePanel
            // 
            this.SizePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SizePanel.Controls.Add(this.HeightTextBox);
            this.SizePanel.Controls.Add(this.XLabel);
            this.SizePanel.Controls.Add(this.WidthTextBox);
            this.SizePanel.Controls.Add(this.SizeLabel);
            this.SizePanel.Location = new System.Drawing.Point(12, 46);
            this.SizePanel.Name = "SizePanel";
            this.SizePanel.Size = new System.Drawing.Size(151, 64);
            this.SizePanel.TabIndex = 2;
            // 
            // HeightTextBox
            // 
            this.HeightTextBox.Location = new System.Drawing.Point(87, 31);
            this.HeightTextBox.MaxLength = 3;
            this.HeightTextBox.Name = "HeightTextBox";
            this.HeightTextBox.Size = new System.Drawing.Size(40, 20);
            this.HeightTextBox.TabIndex = 3;
            this.HeightTextBox.Text = "15";
            this.HeightTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            this.HeightTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // XLabel
            // 
            this.XLabel.AutoSize = true;
            this.XLabel.Location = new System.Drawing.Point(67, 34);
            this.XLabel.Name = "XLabel";
            this.XLabel.Size = new System.Drawing.Size(14, 13);
            this.XLabel.TabIndex = 2;
            this.XLabel.Text = "X";
            // 
            // WidthTextBox
            // 
            this.WidthTextBox.Location = new System.Drawing.Point(21, 31);
            this.WidthTextBox.MaxLength = 3;
            this.WidthTextBox.Name = "WidthTextBox";
            this.WidthTextBox.Size = new System.Drawing.Size(40, 20);
            this.WidthTextBox.TabIndex = 1;
            this.WidthTextBox.Text = "20";
            this.WidthTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            this.WidthTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // SizeLabel
            // 
            this.SizeLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.SizeLabel.Font = new System.Drawing.Font("Verdana", 10.5F);
            this.SizeLabel.ForeColor = System.Drawing.Color.MidnightBlue;
            this.SizeLabel.Location = new System.Drawing.Point(0, 0);
            this.SizeLabel.Name = "SizeLabel";
            this.SizeLabel.Size = new System.Drawing.Size(149, 23);
            this.SizeLabel.TabIndex = 0;
            this.SizeLabel.Text = "Map Size (in tiles)";
            this.SizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TilesetPanel
            // 
            this.TilesetPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TilesetPanel.Controls.Add(this.TilesetButton);
            this.TilesetPanel.Controls.Add(this.TilesetTextBox);
            this.TilesetPanel.Controls.Add(this.UseExistingCheckBox);
            this.TilesetPanel.Controls.Add(this.TilesetLabel);
            this.TilesetPanel.Location = new System.Drawing.Point(11, 116);
            this.TilesetPanel.Name = "TilesetPanel";
            this.TilesetPanel.Size = new System.Drawing.Size(297, 78);
            this.TilesetPanel.TabIndex = 3;
            // 
            // TilesetButton
            // 
            this.TilesetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TilesetButton.Enabled = false;
            this.TilesetButton.Image = global::SphereStudio.Plugins.Properties.Resources.folder;
            this.TilesetButton.Location = new System.Drawing.Point(10, 49);
            this.TilesetButton.Name = "TilesetButton";
            this.TilesetButton.Size = new System.Drawing.Size(34, 23);
            this.TilesetButton.TabIndex = 3;
            this.TilesetButton.UseVisualStyleBackColor = true;
            this.TilesetButton.Click += new System.EventHandler(this.TilesetButton_Click);
            // 
            // TilesetTextBox
            // 
            this.TilesetTextBox.Location = new System.Drawing.Point(50, 51);
            this.TilesetTextBox.Name = "TilesetTextBox";
            this.TilesetTextBox.ReadOnly = true;
            this.TilesetTextBox.Size = new System.Drawing.Size(242, 20);
            this.TilesetTextBox.TabIndex = 2;
            // 
            // UseExistingCheckBox
            // 
            this.UseExistingCheckBox.AutoSize = true;
            this.UseExistingCheckBox.Location = new System.Drawing.Point(3, 26);
            this.UseExistingCheckBox.Name = "UseExistingCheckBox";
            this.UseExistingCheckBox.Size = new System.Drawing.Size(118, 17);
            this.UseExistingCheckBox.TabIndex = 1;
            this.UseExistingCheckBox.Text = "Use Existing Tileset";
            this.UseExistingCheckBox.UseVisualStyleBackColor = true;
            this.UseExistingCheckBox.CheckedChanged += new System.EventHandler(this.UseExistingCheckBox_CheckedChanged);
            // 
            // TilesetLabel
            // 
            this.TilesetLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TilesetLabel.Font = new System.Drawing.Font("Verdana", 10.5F);
            this.TilesetLabel.ForeColor = System.Drawing.Color.MidnightBlue;
            this.TilesetLabel.Location = new System.Drawing.Point(0, 0);
            this.TilesetLabel.Name = "TilesetLabel";
            this.TilesetLabel.Size = new System.Drawing.Size(295, 23);
            this.TilesetLabel.TabIndex = 0;
            this.TilesetLabel.Text = "Tileset";
            this.TilesetLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ImageBox
            // 
            this.ImageBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.ImageBox.Image = global::SphereStudio.Plugins.Properties.Resources.NewMap;
            this.ImageBox.InitialImage = null;
            this.ImageBox.Location = new System.Drawing.Point(0, 0);
            this.ImageBox.Name = "ImageBox";
            this.ImageBox.Size = new System.Drawing.Size(320, 40);
            this.ImageBox.TabIndex = 4;
            this.ImageBox.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.TileHeightTextBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.TileWidthTextBox);
            this.panel1.Controls.Add(this.TileLabel);
            this.panel1.Location = new System.Drawing.Point(168, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(140, 64);
            this.panel1.TabIndex = 4;
            // 
            // TileHeightTextBox
            // 
            this.TileHeightTextBox.Location = new System.Drawing.Point(82, 31);
            this.TileHeightTextBox.MaxLength = 3;
            this.TileHeightTextBox.Name = "TileHeightTextBox";
            this.TileHeightTextBox.Size = new System.Drawing.Size(40, 20);
            this.TileHeightTextBox.TabIndex = 3;
            this.TileHeightTextBox.Text = "16";
            this.TileHeightTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            this.TileHeightTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "X";
            // 
            // TileWidthTextBox
            // 
            this.TileWidthTextBox.Location = new System.Drawing.Point(16, 31);
            this.TileWidthTextBox.MaxLength = 3;
            this.TileWidthTextBox.Name = "TileWidthTextBox";
            this.TileWidthTextBox.Size = new System.Drawing.Size(40, 20);
            this.TileWidthTextBox.TabIndex = 1;
            this.TileWidthTextBox.Text = "16";
            this.TileWidthTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            this.TileWidthTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // TileLabel
            // 
            this.TileLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TileLabel.Font = new System.Drawing.Font("Verdana", 10.5F);
            this.TileLabel.ForeColor = System.Drawing.Color.MidnightBlue;
            this.TileLabel.Location = new System.Drawing.Point(0, 0);
            this.TileLabel.Name = "TileLabel";
            this.TileLabel.Size = new System.Drawing.Size(138, 23);
            this.TileLabel.TabIndex = 0;
            this.TileLabel.Text = "Tile Size (in px)";
            this.TileLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NewMapDialogue
            // 
            this.AcceptButton = this.OkayButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CnclButton;
            this.ClientSize = new System.Drawing.Size(320, 238);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ImageBox);
            this.Controls.Add(this.TilesetPanel);
            this.Controls.Add(this.SizePanel);
            this.Controls.Add(this.CnclButton);
            this.Controls.Add(this.OkayButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewMapDialogue";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NewMap";
            this.SizePanel.ResumeLayout(false);
            this.SizePanel.PerformLayout();
            this.TilesetPanel.ResumeLayout(false);
            this.TilesetPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button OkayButton;
        private System.Windows.Forms.Button CnclButton;
        private System.Windows.Forms.Panel SizePanel;
        private SphereStudio.UI.DialogHeader SizeLabel;
        private System.Windows.Forms.Panel TilesetPanel;
        private SphereStudio.UI.DialogHeader TilesetLabel;
        private System.Windows.Forms.Button TilesetButton;
        private System.Windows.Forms.TextBox TilesetTextBox;
        private System.Windows.Forms.CheckBox UseExistingCheckBox;
        private System.Windows.Forms.TextBox HeightTextBox;
        private System.Windows.Forms.Label XLabel;
        private System.Windows.Forms.TextBox WidthTextBox;
        private System.Windows.Forms.PictureBox ImageBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox TileHeightTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TileWidthTextBox;
        private SphereStudio.UI.DialogHeader TileLabel;
    }
}