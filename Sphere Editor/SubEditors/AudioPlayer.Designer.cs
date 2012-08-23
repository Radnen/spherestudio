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
            this.PlayButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.AudioTracker = new System.Windows.Forms.TrackBar();
            this.RepeatCheckBox = new System.Windows.Forms.CheckBox();
            this.TimeLabel = new System.Windows.Forms.Label();
            this.SongPanel = new System.Windows.Forms.Panel();
            this.InfoLabel = new System.Windows.Forms.Label();
            this.VolumeTracker = new System.Windows.Forms.TrackBar();
            this.PitchTracker = new System.Windows.Forms.TrackBar();
            this.RemoveButton = new System.Windows.Forms.Button();
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
            // PlayButton
            // 
            this.PlayButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PlayButton.Image = global::Sphere_Editor.Properties.Resources.sound;
            this.PlayButton.Location = new System.Drawing.Point(3, 77);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(75, 23);
            this.PlayButton.TabIndex = 0;
            this.PlayButton.Text = "Play";
            this.PlayButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.PlayButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.PlayButton.UseVisualStyleBackColor = true;
            this.PlayButton.Click += new System.EventHandler(this.PlayPauseButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.StopButton.Image = global::Sphere_Editor.Properties.Resources.cross;
            this.StopButton.Location = new System.Drawing.Point(84, 77);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(75, 23);
            this.StopButton.TabIndex = 1;
            this.StopButton.Text = "Stop";
            this.StopButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.StopButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // AudioTracker
            // 
            this.AudioTracker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.AudioTracker.Location = new System.Drawing.Point(3, 26);
            this.AudioTracker.Name = "AudioTracker";
            this.AudioTracker.Size = new System.Drawing.Size(564, 45);
            this.AudioTracker.TabIndex = 3;
            this.AudioTracker.TickFrequency = 1000;
            this.AudioTracker.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.AudioTracker.Scroll += new System.EventHandler(this.AudioTracker_Scroll);
            // 
            // RepeatCheckBox
            // 
            this.RepeatCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RepeatCheckBox.AutoSize = true;
            this.RepeatCheckBox.Location = new System.Drawing.Point(165, 81);
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
            this.TimeLabel.Location = new System.Drawing.Point(413, 76);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(154, 26);
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
            this.SongPanel.Controls.Add(this.InfoLabel);
            this.SongPanel.Controls.Add(this.VolumeTracker);
            this.SongPanel.Controls.Add(this.PitchTracker);
            this.SongPanel.Controls.Add(this.RemoveButton);
            this.SongPanel.Controls.Add(this.TimeLabel);
            this.SongPanel.Controls.Add(this.NameLabel);
            this.SongPanel.Controls.Add(this.RepeatCheckBox);
            this.SongPanel.Controls.Add(this.AudioTracker);
            this.SongPanel.Controls.Add(this.StopButton);
            this.SongPanel.Controls.Add(this.PlayButton);
            this.SongPanel.Location = new System.Drawing.Point(6, 6);
            this.SongPanel.Margin = new System.Windows.Forms.Padding(6);
            this.SongPanel.Name = "SongPanel";
            this.SongPanel.Size = new System.Drawing.Size(665, 107);
            this.SongPanel.TabIndex = 6;
            // 
            // InfoLabel
            // 
            this.InfoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.InfoLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(225)))), ((int)(((byte)(243)))));
            this.InfoLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InfoLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InfoLabel.Location = new System.Drawing.Point(232, 76);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(175, 26);
            this.InfoLabel.TabIndex = 11;
            this.InfoLabel.Text = "Volume: 100%";
            this.InfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // VolumeTracker
            // 
            this.VolumeTracker.Dock = System.Windows.Forms.DockStyle.Right;
            this.VolumeTracker.Location = new System.Drawing.Point(573, 23);
            this.VolumeTracker.Maximum = 100;
            this.VolumeTracker.Name = "VolumeTracker";
            this.VolumeTracker.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.VolumeTracker.Size = new System.Drawing.Size(45, 82);
            this.VolumeTracker.TabIndex = 9;
            this.VolumeTracker.TickFrequency = 1000;
            this.VolumeTracker.Value = 100;
            this.VolumeTracker.ValueChanged += new System.EventHandler(this.VolumeTracker_ValueChanged);
            this.VolumeTracker.MouseEnter += new System.EventHandler(this.VolumeTracker_MouseEnter);
            // 
            // PitchTracker
            // 
            this.PitchTracker.Dock = System.Windows.Forms.DockStyle.Right;
            this.PitchTracker.Location = new System.Drawing.Point(618, 23);
            this.PitchTracker.Maximum = 200;
            this.PitchTracker.Minimum = 10;
            this.PitchTracker.Name = "PitchTracker";
            this.PitchTracker.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.PitchTracker.Size = new System.Drawing.Size(45, 82);
            this.PitchTracker.TabIndex = 8;
            this.PitchTracker.TickFrequency = 1000;
            this.PitchTracker.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.PitchTracker.Value = 100;
            this.PitchTracker.ValueChanged += new System.EventHandler(this.PitchTracker_ValueChanged);
            this.PitchTracker.MouseEnter += new System.EventHandler(this.PitchTracker_MouseEnter);
            // 
            // RemoveButton
            // 
            this.RemoveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RemoveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.RemoveButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.RemoveButton.FlatAppearance.BorderSize = 0;
            this.RemoveButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.RemoveButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.RemoveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RemoveButton.Image = global::Sphere_Editor.Properties.Resources.cross;
            this.RemoveButton.Location = new System.Drawing.Point(634, 2);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(26, 20);
            this.RemoveButton.TabIndex = 7;
            this.RemoveButton.UseVisualStyleBackColor = false;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // NameLabel
            // 
            this.NameLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.NameLabel.Font = new System.Drawing.Font("Verdana", 10.5F);
            this.NameLabel.ForeColor = System.Drawing.Color.MidnightBlue;
            this.NameLabel.Location = new System.Drawing.Point(0, 0);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(663, 23);
            this.NameLabel.TabIndex = 5;
            this.NameLabel.Text = "[[Song Name]]";
            this.NameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AudioPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SongPanel);
            this.Name = "AudioPlayer";
            this.Size = new System.Drawing.Size(677, 119);
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
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.TrackBar VolumeTracker;
        private System.Windows.Forms.TrackBar PitchTracker;
        private System.Windows.Forms.Label InfoLabel;
    }
}
