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
            this.fileList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listImages = new System.Windows.Forms.ImageList(this.components);
            this.makePackageButton = new System.Windows.Forms.Button();
            this.packProgress = new System.Windows.Forms.ProgressBar();
            this.deflateLevel = new System.Windows.Forms.TrackBar();
            this.deflateLvLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            this.percentLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.deflateLevel)).BeginInit();
            this.SuspendLayout();
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
            this.fileList.Location = new System.Drawing.Point(12, 12);
            this.fileList.MultiSelect = false;
            this.fileList.Name = "fileList";
            this.fileList.Size = new System.Drawing.Size(444, 397);
            this.fileList.SmallImageList = this.listImages;
            this.fileList.TabIndex = 0;
            this.fileList.UseCompatibleStateImageBehavior = false;
            this.fileList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Path";
            this.columnHeader1.Width = 300;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "File Size";
            this.columnHeader2.Width = 100;
            // 
            // listImages
            // 
            this.listImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("listImages.ImageStream")));
            this.listImages.TransparentColor = System.Drawing.Color.Transparent;
            this.listImages.Images.SetKeyName(0, "new_item.png");
            // 
            // makePackageButton
            // 
            this.makePackageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.makePackageButton.Location = new System.Drawing.Point(462, 13);
            this.makePackageButton.Name = "makePackageButton";
            this.makePackageButton.Size = new System.Drawing.Size(106, 43);
            this.makePackageButton.TabIndex = 1;
            this.makePackageButton.Text = "Make &Package";
            this.makePackageButton.UseVisualStyleBackColor = true;
            this.makePackageButton.Click += new System.EventHandler(this.makePackageButton_Click);
            // 
            // packProgress
            // 
            this.packProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.packProgress.Location = new System.Drawing.Point(12, 441);
            this.packProgress.Name = "packProgress";
            this.packProgress.Size = new System.Drawing.Size(446, 13);
            this.packProgress.TabIndex = 7;
            // 
            // deflateLevel
            // 
            this.deflateLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deflateLevel.LargeChange = 3;
            this.deflateLevel.Location = new System.Drawing.Point(464, 122);
            this.deflateLevel.Maximum = 9;
            this.deflateLevel.Name = "deflateLevel";
            this.deflateLevel.Size = new System.Drawing.Size(104, 45);
            this.deflateLevel.TabIndex = 4;
            this.deflateLevel.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.deflateLevel.Value = 6;
            this.deflateLevel.Scroll += new System.EventHandler(this.deflateLevel_Scroll);
            // 
            // deflateLvLabel
            // 
            this.deflateLvLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deflateLvLabel.Location = new System.Drawing.Point(462, 98);
            this.deflateLvLabel.Name = "deflateLvLabel";
            this.deflateLvLabel.Size = new System.Drawing.Size(106, 21);
            this.deflateLvLabel.TabIndex = 3;
            this.deflateLvLabel.Text = "Compression Lv. 6";
            this.deflateLvLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(462, 62);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(106, 24);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // statusLabel
            // 
            this.statusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusLabel.Location = new System.Drawing.Point(9, 422);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(408, 16);
            this.statusLabel.TabIndex = 5;
            this.statusLabel.Text = "Select files and then click \'Make Package\'.";
            // 
            // percentLabel
            // 
            this.percentLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.percentLabel.Location = new System.Drawing.Point(423, 422);
            this.percentLabel.Name = "percentLabel";
            this.percentLabel.Size = new System.Drawing.Size(35, 16);
            this.percentLabel.TabIndex = 6;
            this.percentLabel.Text = "100%";
            this.percentLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // MakePackageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(578, 466);
            this.Controls.Add(this.percentLabel);
            this.Controls.Add(this.deflateLvLabel);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.deflateLevel);
            this.Controls.Add(this.packProgress);
            this.Controls.Add(this.makePackageButton);
            this.Controls.Add(this.fileList);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MakePackageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Package Game";
            this.Load += new System.EventHandler(this.MakePackageForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.deflateLevel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView fileList;
        private System.Windows.Forms.Button makePackageButton;
        private System.Windows.Forms.ProgressBar packProgress;
        private System.Windows.Forms.TrackBar deflateLevel;
        private System.Windows.Forms.Label deflateLvLabel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label percentLabel;
        private System.Windows.Forms.ImageList listImages;
    }
}