namespace Sphere_Editor.SpritesetComponents
{
    partial class DirectionAnimator
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
            this.PlayButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.FrameTracker = new System.Windows.Forms.TrackBar();
            this.AnimTimer = new System.Windows.Forms.Timer(this.components);
            this.AnimContainer = new System.Windows.Forms.Panel();
            this.AnimStatus = new System.Windows.Forms.StatusStrip();
            this.AnimLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.DirLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.AnimPanel = new Sphere_Editor.EditorPanel();
            ((System.ComponentModel.ISupportInitialize)(this.FrameTracker)).BeginInit();
            this.AnimContainer.SuspendLayout();
            this.AnimStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // PlayButton
            // 
            this.PlayButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.PlayButton.Enabled = false;
            this.PlayButton.Image = global::Sphere_Editor.Properties.Resources.resultset_next;
            this.PlayButton.Location = new System.Drawing.Point(60, 143);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(56, 23);
            this.PlayButton.TabIndex = 1;
            this.PlayButton.Text = "Play";
            this.PlayButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.PlayButton.UseVisualStyleBackColor = true;
            this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.StopButton.Enabled = false;
            this.StopButton.Image = global::Sphere_Editor.Properties.Resources.cross;
            this.StopButton.Location = new System.Drawing.Point(132, 143);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(56, 23);
            this.StopButton.TabIndex = 2;
            this.StopButton.Text = "Stop";
            this.StopButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // FrameTracker
            // 
            this.FrameTracker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.FrameTracker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.FrameTracker.LargeChange = 1;
            this.FrameTracker.Location = new System.Drawing.Point(6, 6);
            this.FrameTracker.Maximum = 3;
            this.FrameTracker.Name = "FrameTracker";
            this.FrameTracker.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.FrameTracker.Size = new System.Drawing.Size(45, 160);
            this.FrameTracker.TabIndex = 3;
            this.FrameTracker.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.FrameTracker.Value = 3;
            this.FrameTracker.Scroll += new System.EventHandler(this.FrameTracker_Scroll);
            // 
            // AnimTimer
            // 
            this.AnimTimer.Interval = 800;
            this.AnimTimer.Tick += new System.EventHandler(this.AnimTimer_Tick);
            // 
            // AnimContainer
            // 
            this.AnimContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.AnimContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.AnimContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AnimContainer.Controls.Add(this.AnimPanel);
            this.AnimContainer.Location = new System.Drawing.Point(60, 6);
            this.AnimContainer.Margin = new System.Windows.Forms.Padding(6);
            this.AnimContainer.Name = "AnimContainer";
            this.AnimContainer.Size = new System.Drawing.Size(128, 128);
            this.AnimContainer.TabIndex = 4;
            // 
            // AnimStatus
            // 
            this.AnimStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.AnimStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AnimLabel,
            this.DirLabel});
            this.AnimStatus.Location = new System.Drawing.Point(0, 171);
            this.AnimStatus.Name = "AnimStatus";
            this.AnimStatus.Size = new System.Drawing.Size(196, 24);
            this.AnimStatus.SizingGrip = false;
            this.AnimStatus.TabIndex = 5;
            this.AnimStatus.Text = "Animation Status";
            // 
            // AnimLabel
            // 
            this.AnimLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.AnimLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Bump;
            this.AnimLabel.Name = "AnimLabel";
            this.AnimLabel.Size = new System.Drawing.Size(67, 19);
            this.AnimLabel.Text = "Frame: 1/4";
            // 
            // DirLabel
            // 
            this.DirLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.DirLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Bump;
            this.DirLabel.Name = "DirLabel";
            this.DirLabel.Size = new System.Drawing.Size(96, 19);
            this.DirLabel.Text = "Direction: North";
            // 
            // AnimPanel
            // 
            this.AnimPanel.BackgroundImage = global::Sphere_Editor.Properties.Resources.editbg2;
            this.AnimPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AnimPanel.Location = new System.Drawing.Point(16, 16);
            this.AnimPanel.Margin = new System.Windows.Forms.Padding(6);
            this.AnimPanel.Name = "AnimPanel";
            this.AnimPanel.Size = new System.Drawing.Size(96, 96);
            this.AnimPanel.TabIndex = 0;
            this.AnimPanel.XSnap = 0;
            this.AnimPanel.YSnap = 0;
            this.AnimPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.AnimPanel_Paint);
            // 
            // DirectionAnimator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(225)))), ((int)(((byte)(243)))));
            this.Controls.Add(this.AnimStatus);
            this.Controls.Add(this.AnimContainer);
            this.Controls.Add(this.FrameTracker);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.PlayButton);
            this.Name = "DirectionAnimator";
            this.Size = new System.Drawing.Size(196, 195);
            this.Resize += new System.EventHandler(this.DirectionAnimator_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.FrameTracker)).EndInit();
            this.AnimContainer.ResumeLayout(false);
            this.AnimStatus.ResumeLayout(false);
            this.AnimStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EditorPanel AnimPanel;
        private System.Windows.Forms.Button PlayButton;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.TrackBar FrameTracker;
        private System.Windows.Forms.Timer AnimTimer;
        private System.Windows.Forms.Panel AnimContainer;
        private System.Windows.Forms.StatusStrip AnimStatus;
        private System.Windows.Forms.ToolStripStatusLabel AnimLabel;
        private System.Windows.Forms.ToolStripStatusLabel DirLabel;

    }
}
