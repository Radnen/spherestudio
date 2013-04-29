namespace SoundTestPlugin
{
    partial class SoundPicker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SoundPicker));
            this.toolbar = new System.Windows.Forms.ToolStrip();
            this.playPauseTool = new System.Windows.Forms.ToolStripButton();
            this.stopTool = new System.Windows.Forms.ToolStripButton();
            this.trackList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolbar
            // 
            this.toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playPauseTool,
            this.stopTool});
            this.toolbar.Location = new System.Drawing.Point(0, 0);
            this.toolbar.Name = "toolbar";
            this.toolbar.Size = new System.Drawing.Size(350, 25);
            this.toolbar.TabIndex = 0;
            this.toolbar.Text = "toolStrip1";
            // 
            // playPauseTool
            // 
            this.playPauseTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.playPauseTool.Image = ((System.Drawing.Image)(resources.GetObject("playPauseTool.Image")));
            this.playPauseTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.playPauseTool.Name = "playPauseTool";
            this.playPauseTool.Size = new System.Drawing.Size(23, 22);
            this.playPauseTool.Text = "toolStripButton1";
            // 
            // stopTool
            // 
            this.stopTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stopTool.Image = ((System.Drawing.Image)(resources.GetObject("stopTool.Image")));
            this.stopTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stopTool.Name = "stopTool";
            this.stopTool.Size = new System.Drawing.Size(23, 22);
            this.stopTool.Text = "toolStripButton2";
            // 
            // trackList
            // 
            this.trackList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.trackList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackList.FullRowSelect = true;
            this.trackList.GridLines = true;
            this.trackList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.trackList.Location = new System.Drawing.Point(0, 25);
            this.trackList.MultiSelect = false;
            this.trackList.Name = "trackList";
            this.trackList.ShowItemToolTips = true;
            this.trackList.Size = new System.Drawing.Size(350, 347);
            this.trackList.TabIndex = 1;
            this.trackList.UseCompatibleStateImageBehavior = false;
            this.trackList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "File";
            this.columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Path";
            this.columnHeader2.Width = 150;
            // 
            // SoundPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.trackList);
            this.Controls.Add(this.toolbar);
            this.Name = "SoundPicker";
            this.Size = new System.Drawing.Size(350, 372);
            this.toolbar.ResumeLayout(false);
            this.toolbar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolbar;
        private System.Windows.Forms.ToolStripButton playPauseTool;
        private System.Windows.Forms.ToolStripButton stopTool;
        private System.Windows.Forms.ListView trackList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}
