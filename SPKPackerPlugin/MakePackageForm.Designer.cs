namespace Sphere.Plugins
{
    partial class MakePackageForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MakePackageForm));
            this.listImages = new System.Windows.Forms.ImageList(this.components);
            this.headerLabel = new Sphere.Core.Editor.EditorLabel();
            this.fileList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.makePackageButton = new System.Windows.Forms.Button();
            this.packProgress = new System.Windows.Forms.ProgressBar();
            this.deflateLevel = new System.Windows.Forms.TrackBar();
            this.cancelButton = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            this.deflateLvLabel = new System.Windows.Forms.Label();
            this.percentLabel = new System.Windows.Forms.Label();
            this.testButton = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.deflateLevel)).BeginInit();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // listImages
            // 
            this.listImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("listImages.ImageStream")));
            this.listImages.TransparentColor = System.Drawing.Color.Transparent;
            this.listImages.Images.SetKeyName(0, "new_item.png");
            // 
            // headerLabel
            // 
            this.headerLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.headerLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.headerLabel.ForeColor = System.Drawing.Color.White;
            this.headerLabel.Location = new System.Drawing.Point(0, 0);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(621, 23);
            this.headerLabel.TabIndex = 9;
            this.headerLabel.Text = "Create Sphere Game Package (.spk)";
            this.headerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fileList
            // 
            this.fileList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileList.CheckBoxes = true;
            this.fileList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.fileList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.fileList.Location = new System.Drawing.Point(13, 14);
            this.fileList.MultiSelect = false;
            this.fileList.Name = "fileList";
            this.fileList.Size = new System.Drawing.Size(487, 478);
            this.fileList.SmallImageList = this.listImages;
            this.fileList.TabIndex = 9;
            this.fileList.UseCompatibleStateImageBehavior = false;
            this.fileList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Path";
            this.columnHeader1.Width = 350;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "File Size";
            this.columnHeader2.Width = 100;
            // 
            // makePackageButton
            // 
            this.makePackageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.makePackageButton.Location = new System.Drawing.Point(509, 14);
            this.makePackageButton.Name = "makePackageButton";
            this.makePackageButton.Size = new System.Drawing.Size(101, 43);
            this.makePackageButton.TabIndex = 12;
            this.makePackageButton.Text = "Make &Package";
            this.makePackageButton.UseVisualStyleBackColor = true;
            this.makePackageButton.Click += new System.EventHandler(this.makePackageButton_Click);
            // 
            // packProgress
            // 
            this.packProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.packProgress.Location = new System.Drawing.Point(13, 524);
            this.packProgress.Name = "packProgress";
            this.packProgress.Size = new System.Drawing.Size(489, 13);
            this.packProgress.TabIndex = 24;
            // 
            // deflateLevel
            // 
            this.deflateLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deflateLevel.LargeChange = 3;
            this.deflateLevel.Location = new System.Drawing.Point(511, 123);
            this.deflateLevel.Maximum = 9;
            this.deflateLevel.Name = "deflateLevel";
            this.deflateLevel.Size = new System.Drawing.Size(99, 45);
            this.deflateLevel.TabIndex = 17;
            this.deflateLevel.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.deflateLevel.Value = 6;
            this.deflateLevel.Scroll += new System.EventHandler(this.deflateLevel_Scroll);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(509, 63);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(101, 24);
            this.cancelButton.TabIndex = 13;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusLabel.Location = new System.Drawing.Point(10, 505);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(451, 16);
            this.statusLabel.TabIndex = 19;
            this.statusLabel.Text = "Select files and then click \'Make Package\'.";
            // 
            // deflateLvLabel
            // 
            this.deflateLvLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deflateLvLabel.Location = new System.Drawing.Point(509, 99);
            this.deflateLvLabel.Name = "deflateLvLabel";
            this.deflateLvLabel.Size = new System.Drawing.Size(101, 21);
            this.deflateLvLabel.TabIndex = 16;
            this.deflateLvLabel.Text = "Compression Lv. 6";
            this.deflateLvLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // percentLabel
            // 
            this.percentLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.percentLabel.Location = new System.Drawing.Point(467, 505);
            this.percentLabel.Name = "percentLabel";
            this.percentLabel.Size = new System.Drawing.Size(35, 16);
            this.percentLabel.TabIndex = 21;
            this.percentLabel.Text = "100%";
            this.percentLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // testButton
            // 
            this.testButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.testButton.Location = new System.Drawing.Point(509, 473);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(101, 64);
            this.testButton.TabIndex = 25;
            this.testButton.Text = "Test Package!";
            this.testButton.UseVisualStyleBackColor = true;
            this.testButton.Visible = false;
            this.testButton.Click += new System.EventHandler(this.testButton_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.testButton);
            this.mainPanel.Controls.Add(this.percentLabel);
            this.mainPanel.Controls.Add(this.deflateLvLabel);
            this.mainPanel.Controls.Add(this.statusLabel);
            this.mainPanel.Controls.Add(this.cancelButton);
            this.mainPanel.Controls.Add(this.deflateLevel);
            this.mainPanel.Controls.Add(this.packProgress);
            this.mainPanel.Controls.Add(this.makePackageButton);
            this.mainPanel.Controls.Add(this.fileList);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 23);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(621, 550);
            this.mainPanel.TabIndex = 10;
            // 
            // MakePackageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 573);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.headerLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MakePackageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Package Game";
            this.Load += new System.EventHandler(this.MakePackageForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.deflateLevel)).EndInit();
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList listImages;
        private Core.Editor.EditorLabel headerLabel;
        private System.Windows.Forms.ListView fileList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button makePackageButton;
        private System.Windows.Forms.ProgressBar packProgress;
        private System.Windows.Forms.TrackBar deflateLevel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label deflateLvLabel;
        private System.Windows.Forms.Label percentLabel;
        private System.Windows.Forms.Button testButton;
        private System.Windows.Forms.Panel mainPanel;
    }
}