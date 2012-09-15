namespace Sphere_Editor.SubEditors
{
    partial class AudioPlayer
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
            this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.AudioTracker = new System.Windows.Forms.TrackBar();
            this.RepeatCheckBox = new System.Windows.Forms.CheckBox();
            this.TimeLabel = new System.Windows.Forms.Label();
            this.SongPanel = new System.Windows.Forms.Panel();
            this.InfoLabel = new System.Windows.Forms.Label();
            this.VolumeTracker = new System.Windows.Forms.TrackBar();
            this.PitchTracker = new System.Windows.Forms.TrackBar();
            this.StopButton = new System.Windows.Forms.Button();
            this.PlayButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.NameLabel = new Sphere_Editor.EditorLabel();
            ((System.ComponentModel.ISupportInitialize)(this.AudioTracker)).BeginInit();
            this.SongPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeTracker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PitchTracker)).BeginInit();
            this.SuspendLayout();
            // 
            // UpdateTimer
            // 
            this.UpdateTimer.Tick += new System.EventHandler(this.UpdateTimer_Tick);
            // 
            // AudioTracker
            // 
            this.AudioTracker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.AudioTracker.Location = new System.Drawing.Point(3, 26);
            this.AudioTracker.Name = "AudioTracker";
            this.AudioTracker.Size = new System.Drawing.Size(489, 45);
            this.AudioTracker.TabIndex = 3;
            this.AudioTracker.TickFrequency = 1000;
            this.AudioTracker.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.AudioTracker.Scroll += new System.EventHandler(this.AudioTracker_Scroll);
            // 
            // RepeatCheckBox
            // 
            this.RepeatCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RepeatCheckBox.AutoSize = true;
            this.RepeatCheckBox.Location = new System.Drawing.Point(165, 83);
            this.RepeatCheckBox.Name = "RepeatCheckBox";
            this.RepeatCheckBox.Size = new System.Drawing.Size(61, 17);
            this.RepeatCheckBox.TabIndex = 4;
            this.RepeatCheckBox.Text = "Repeat";
            this.RepeatCheckBox.UseVisualStyleBackColor = false;
            this.RepeatCheckBox.CheckedChanged += new System.EventHandler(this.RepeatCheckBox_CheckedChanged);
            // 
            // TimeLabel
            // 
            this.TimeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TimeLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(225)))), ((int)(((byte)(243)))));
            this.TimeLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TimeLabel.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeLabel.Location = new System.Drawing.Point(347, 78);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(145, 26);
            this.TimeLabel.TabIndex = 6;
            this.TimeLabel.Text = "(00.00) / (00.00)";
            this.TimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SongPanel
            // 
            this.SongPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.SongPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SongPanel.Controls.Add(this.NameLabel);
            this.SongPanel.Controls.Add(this.removeButton);
            this.SongPanel.Controls.Add(this.InfoLabel);
            this.SongPanel.Controls.Add(this.VolumeTracker);
            this.SongPanel.Controls.Add(this.PitchTracker);
            this.SongPanel.Controls.Add(this.TimeLabel);
            this.SongPanel.Controls.Add(this.RepeatCheckBox);
            this.SongPanel.Controls.Add(this.AudioTracker);
            this.SongPanel.Controls.Add(this.StopButton);
            this.SongPanel.Controls.Add(this.PlayButton);
            this.SongPanel.Location = new System.Drawing.Point(6, 6);
            this.SongPanel.Margin = new System.Windows.Forms.Padding(6);
            this.SongPanel.Name = "SongPanel";
            this.SongPanel.Size = new System.Drawing.Size(599, 109);
            this.SongPanel.TabIndex = 6;
            // 
            // InfoLabel
            // 
            this.InfoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.InfoLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(225)))), ((int)(((byte)(243)))));
            this.InfoLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InfoLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InfoLabel.Location = new System.Drawing.Point(166, 78);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(175, 26);
            this.InfoLabel.TabIndex = 11;
            this.InfoLabel.Text = "Volume: 100%";
            this.InfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // VolumeTracker
            // 
            this.VolumeTracker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.VolumeTracker.Location = new System.Drawing.Point(498, 26);
            this.VolumeTracker.Maximum = 100;
            this.VolumeTracker.Name = "VolumeTracker";
            this.VolumeTracker.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.VolumeTracker.Size = new System.Drawing.Size(45, 80);
            this.VolumeTracker.TabIndex = 9;
            this.VolumeTracker.TickFrequency = 1000;
            this.VolumeTracker.Value = 100;
            this.VolumeTracker.ValueChanged += new System.EventHandler(this.VolumeTracker_ValueChanged);
            this.VolumeTracker.MouseEnter += new System.EventHandler(this.VolumeTracker_MouseEnter);
            // 
            // PitchTracker
            // 
            this.PitchTracker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.PitchTracker.Location = new System.Drawing.Point(549, 26);
            this.PitchTracker.Maximum = 200;
            this.PitchTracker.Minimum = 10;
            this.PitchTracker.Name = "PitchTracker";
            this.PitchTracker.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.PitchTracker.Size = new System.Drawing.Size(45, 80);
            this.PitchTracker.TabIndex = 8;
            this.PitchTracker.TickFrequency = 1000;
            this.PitchTracker.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.PitchTracker.Value = 100;
            this.PitchTracker.ValueChanged += new System.EventHandler(this.PitchTracker_ValueChanged);
            this.PitchTracker.MouseEnter += new System.EventHandler(this.PitchTracker_MouseEnter);
            // 
            // StopButton
            // 
            this.StopButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.StopButton.Image = global::Sphere_Editor.Properties.Resources.stop;
            this.StopButton.Location = new System.Drawing.Point(84, 79);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(75, 23);
            this.StopButton.TabIndex = 1;
            this.StopButton.Text = "Stop";
            this.StopButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.StopButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // PlayButton
            // 
            this.PlayButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PlayButton.Image = global::Sphere_Editor.Properties.Resources.play;
            this.PlayButton.Location = new System.Drawing.Point(3, 79);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(75, 23);
            this.PlayButton.TabIndex = 0;
            this.PlayButton.Text = "Play";
            this.PlayButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.PlayButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.PlayButton.UseVisualStyleBackColor = true;
            this.PlayButton.Click += new System.EventHandler(this.PlayPauseButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.removeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(255)))));
            this.removeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeButton.Image = global::Sphere_Editor.Properties.Resources.cross;
            this.removeButton.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.removeButton.Location = new System.Drawing.Point(574, -1);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(24, 24);
            this.removeButton.TabIndex = 12;
            this.removeButton.UseVisualStyleBackColor = false;
            this.removeButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // NameLabel
            // 
            this.NameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.NameLabel.Font = new System.Drawing.Font("Verdana", 10.5F);
            this.NameLabel.ForeColor = System.Drawing.Color.MidnightBlue;
            this.NameLabel.Location = new System.Drawing.Point(0, 0);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(574, 23);
            this.NameLabel.TabIndex = 5;
            this.NameLabel.Text = "[[Song Name]]";
            this.NameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.NameLabel.DoubleClick += new System.EventHandler(this.NameLabel_DoubleClick);
            // 
            // AudioPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SongPanel);
            this.Name = "AudioPlayer";
            this.Size = new System.Drawing.Size(611, 121);
            ((System.ComponentModel.ISupportInitialize)(this.AudioTracker)).EndInit();
            this.SongPanel.ResumeLayout(false);
            this.SongPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeTracker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PitchTracker)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer UpdateTimer;
        private System.Windows.Forms.Button PlayButton;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.TrackBar AudioTracker;
        private System.Windows.Forms.CheckBox RepeatCheckBox;
        private EditorLabel NameLabel;
        private System.Windows.Forms.Label TimeLabel;
        private System.Windows.Forms.Panel SongPanel;
        private System.Windows.Forms.TrackBar VolumeTracker;
        private System.Windows.Forms.TrackBar PitchTracker;
        private System.Windows.Forms.Label InfoLabel;
        private System.Windows.Forms.Button removeButton;
    }
}
