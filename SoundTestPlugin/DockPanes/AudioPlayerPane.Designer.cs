﻿namespace SphereStudio.Plugins.UI
{
    partial class AudioPlayerPane
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AudioPlayerPane));
            this.toolbar = new System.Windows.Forms.ToolStrip();
            this.stopTool = new System.Windows.Forms.ToolStripButton();
            this.pauseTool = new System.Windows.Forms.ToolStripButton();
            this.playTool = new System.Windows.Forms.ToolStripButton();
            this.trackList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.trackNameLabel = new System.Windows.Forms.Label();
            this.playTimer = new System.Windows.Forms.Timer(this.components);
            this.toolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolbar
            // 
            this.toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stopTool,
            this.pauseTool,
            this.playTool});
            this.toolbar.Location = new System.Drawing.Point(0, 0);
            this.toolbar.Name = "toolbar";
            this.toolbar.ShowItemToolTips = false;
            this.toolbar.Size = new System.Drawing.Size(351, 25);
            this.toolbar.TabIndex = 0;
            this.toolbar.Text = "toolStrip1";
            // 
            // stopTool
            // 
            this.stopTool.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.stopTool.Enabled = false;
            this.stopTool.Image = ((System.Drawing.Image)(resources.GetObject("stopTool.Image")));
            this.stopTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stopTool.Name = "stopTool";
            this.stopTool.Size = new System.Drawing.Size(51, 22);
            this.stopTool.Text = "&Stop";
            this.stopTool.Click += new System.EventHandler(this.stopTool_Click);
            // 
            // pauseTool
            // 
            this.pauseTool.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.pauseTool.Enabled = false;
            this.pauseTool.Image = ((System.Drawing.Image)(resources.GetObject("pauseTool.Image")));
            this.pauseTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pauseTool.Name = "pauseTool";
            this.pauseTool.Size = new System.Drawing.Size(58, 22);
            this.pauseTool.Text = "P&ause";
            this.pauseTool.Click += new System.EventHandler(this.pauseTool_Click);
            // 
            // playTool
            // 
            this.playTool.Enabled = false;
            this.playTool.Image = ((System.Drawing.Image)(resources.GetObject("playTool.Image")));
            this.playTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.playTool.Name = "playTool";
            this.playTool.Size = new System.Drawing.Size(109, 22);
            this.playTool.Text = "Playback Status";
            // 
            // trackList
            // 
            this.trackList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.trackList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.trackList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackList.FullRowSelect = true;
            this.trackList.GridLines = true;
            this.trackList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.trackList.Location = new System.Drawing.Point(0, 47);
            this.trackList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.trackList.MultiSelect = false;
            this.trackList.Name = "trackList";
            this.trackList.ShowItemToolTips = true;
            this.trackList.Size = new System.Drawing.Size(351, 430);
            this.trackList.TabIndex = 1;
            this.trackList.UseCompatibleStateImageBehavior = false;
            this.trackList.View = System.Windows.Forms.View.Details;
            this.trackList.Click += new System.EventHandler(this.trackList_Click);
            this.trackList.DoubleClick += new System.EventHandler(this.trackList_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Track";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Path (Relative)";
            this.columnHeader2.Width = 200;
            // 
            // trackNameLabel
            // 
            this.trackNameLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(32)))), ((int)(((byte)(48)))));
            this.trackNameLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.trackNameLabel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trackNameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.trackNameLabel.Location = new System.Drawing.Point(0, 25);
            this.trackNameLabel.Name = "trackNameLabel";
            this.trackNameLabel.Size = new System.Drawing.Size(351, 22);
            this.trackNameLabel.TabIndex = 2;
            this.trackNameLabel.Text = "Now Playing";
            this.trackNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.trackNameLabel.Paint += new System.Windows.Forms.PaintEventHandler(this.trackNameLabel_Paint);
            this.trackNameLabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.trackNameLabel_MouseClick);
            // 
            // playTimer
            // 
            this.playTimer.Enabled = true;
            this.playTimer.Tick += new System.EventHandler(this.playTimer_Tick);
            // 
            // SoundPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.trackList);
            this.Controls.Add(this.trackNameLabel);
            this.Controls.Add(this.toolbar);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PlayerDockPane";
            this.Size = new System.Drawing.Size(351, 477);
            this.toolbar.ResumeLayout(false);
            this.toolbar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolbar;
        private System.Windows.Forms.ToolStripButton stopTool;
        private System.Windows.Forms.ListView trackList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ToolStripButton pauseTool;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label trackNameLabel;
        private System.Windows.Forms.ToolStripButton playTool;
        private System.Windows.Forms.Timer playTimer;
    }
}
