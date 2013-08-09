namespace MapEditPlugin.Forms
{
    partial class MapPropertiesForm
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
            this.FilenameTextBox = new System.Windows.Forms.TextBox();
            this.BgMusicTextbox = new System.Windows.Forms.TextBox();
            this.TilesetTextbox = new System.Windows.Forms.TextBox();
            this.RepeatMapCheckBox = new System.Windows.Forms.CheckBox();
            this.FilenameLabel = new System.Windows.Forms.Label();
            this.TilesetLabel = new System.Windows.Forms.Label();
            this.BgMusicLabel = new System.Windows.Forms.Label();
            this.OkayButton = new System.Windows.Forms.Button();
            this.TheCancelButton = new System.Windows.Forms.Button();
            this.ScriptTabControl = new System.Windows.Forms.TabControl();
            this.EnterTab = new System.Windows.Forms.TabPage();
            this.LeaveTab = new System.Windows.Forms.TabPage();
            this.LeaveNorth = new System.Windows.Forms.TabPage();
            this.LeaveEast = new System.Windows.Forms.TabPage();
            this.LeaveSouth = new System.Windows.Forms.TabPage();
            this.LeaveWest = new System.Windows.Forms.TabPage();
            this.ScriptPanel = new System.Windows.Forms.Panel();
            this.BgMusicButton = new System.Windows.Forms.Button();
            this.TilesetButton = new System.Windows.Forms.Button();
            this.ScriptLabel = new System.Windows.Forms.Label();
            this.TilePropPanel = new System.Windows.Forms.Panel();
            this.RescaleCheckBox = new System.Windows.Forms.CheckBox();
            this.TileHeightBox = new System.Windows.Forms.TextBox();
            this.TileSizeComboBox = new System.Windows.Forms.ComboBox();
            this.XLabel = new System.Windows.Forms.Label();
            this.TileWidthBox = new System.Windows.Forms.TextBox();
            this.TileSizeLabel = new System.Windows.Forms.Label();
            this.TilePropLabel = new Sphere.Core.Editor.EditorLabel();
            this.LayerHeightBox = new System.Windows.Forms.TextBox();
            this.XLabel2 = new System.Windows.Forms.Label();
            this.LayerWidthBox = new System.Windows.Forms.TextBox();
            this.LayerSizeLabel = new System.Windows.Forms.Label();
            this.LayerPropPanel = new System.Windows.Forms.Panel();
            this.LayerPropLabel = new Sphere.Core.Editor.EditorLabel();
            this.LayerNumLabel = new System.Windows.Forms.Label();
            this.EntityNumLabel = new System.Windows.Forms.Label();
            this.ZoneNumLabel = new System.Windows.Forms.Label();
            this.ScriptTabControl.SuspendLayout();
            this.TilePropPanel.SuspendLayout();
            this.LayerPropPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // FilenameTextBox
            // 
            this.FilenameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.FilenameTextBox.Location = new System.Drawing.Point(131, 12);
            this.FilenameTextBox.Name = "FilenameTextBox";
            this.FilenameTextBox.ReadOnly = true;
            this.FilenameTextBox.Size = new System.Drawing.Size(256, 20);
            this.FilenameTextBox.TabIndex = 0;
            // 
            // BgMusicTextbox
            // 
            this.BgMusicTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.BgMusicTextbox.Location = new System.Drawing.Point(131, 38);
            this.BgMusicTextbox.Name = "BgMusicTextbox";
            this.BgMusicTextbox.Size = new System.Drawing.Size(224, 20);
            this.BgMusicTextbox.TabIndex = 1;
            this.BgMusicTextbox.Text = "<phasing feature out>";
            // 
            // TilesetTextbox
            // 
            this.TilesetTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TilesetTextbox.Location = new System.Drawing.Point(131, 64);
            this.TilesetTextbox.Name = "TilesetTextbox";
            this.TilesetTextbox.ReadOnly = true;
            this.TilesetTextbox.Size = new System.Drawing.Size(224, 20);
            this.TilesetTextbox.TabIndex = 3;
            // 
            // RepeatMapCheckBox
            // 
            this.RepeatMapCheckBox.AutoSize = true;
            this.RepeatMapCheckBox.Location = new System.Drawing.Point(11, 90);
            this.RepeatMapCheckBox.Name = "RepeatMapCheckBox";
            this.RepeatMapCheckBox.Size = new System.Drawing.Size(85, 17);
            this.RepeatMapCheckBox.TabIndex = 5;
            this.RepeatMapCheckBox.Text = "Repeat Map";
            this.RepeatMapCheckBox.UseVisualStyleBackColor = true;
            // 
            // FilenameLabel
            // 
            this.FilenameLabel.AutoSize = true;
            this.FilenameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilenameLabel.Location = new System.Drawing.Point(9, 15);
            this.FilenameLabel.Name = "FilenameLabel";
            this.FilenameLabel.Size = new System.Drawing.Size(61, 13);
            this.FilenameLabel.TabIndex = 4;
            this.FilenameLabel.Text = "Filename:";
            // 
            // TilesetLabel
            // 
            this.TilesetLabel.AutoSize = true;
            this.TilesetLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TilesetLabel.Location = new System.Drawing.Point(9, 67);
            this.TilesetLabel.Name = "TilesetLabel";
            this.TilesetLabel.Size = new System.Drawing.Size(49, 13);
            this.TilesetLabel.TabIndex = 5;
            this.TilesetLabel.Text = "Tileset:";
            // 
            // BgMusicLabel
            // 
            this.BgMusicLabel.AutoSize = true;
            this.BgMusicLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BgMusicLabel.Location = new System.Drawing.Point(9, 41);
            this.BgMusicLabel.Name = "BgMusicLabel";
            this.BgMusicLabel.Size = new System.Drawing.Size(116, 13);
            this.BgMusicLabel.TabIndex = 6;
            this.BgMusicLabel.Text = "Background Music:";
            // 
            // OkayButton
            // 
            this.OkayButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OkayButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkayButton.Location = new System.Drawing.Point(393, 12);
            this.OkayButton.Name = "OkayButton";
            this.OkayButton.Size = new System.Drawing.Size(75, 23);
            this.OkayButton.TabIndex = 11;
            this.OkayButton.Text = "Okay";
            this.OkayButton.UseVisualStyleBackColor = true;
            this.OkayButton.Click += new System.EventHandler(this.OkayButton_Click);
            // 
            // TheCancelButton
            // 
            this.TheCancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TheCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.TheCancelButton.Location = new System.Drawing.Point(393, 41);
            this.TheCancelButton.Name = "TheCancelButton";
            this.TheCancelButton.Size = new System.Drawing.Size(75, 23);
            this.TheCancelButton.TabIndex = 12;
            this.TheCancelButton.Text = "Cancel";
            this.TheCancelButton.UseVisualStyleBackColor = true;
            // 
            // ScriptTabControl
            // 
            this.ScriptTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ScriptTabControl.Controls.Add(this.EnterTab);
            this.ScriptTabControl.Controls.Add(this.LeaveTab);
            this.ScriptTabControl.Controls.Add(this.LeaveNorth);
            this.ScriptTabControl.Controls.Add(this.LeaveEast);
            this.ScriptTabControl.Controls.Add(this.LeaveSouth);
            this.ScriptTabControl.Controls.Add(this.LeaveWest);
            this.ScriptTabControl.Location = new System.Drawing.Point(12, 126);
            this.ScriptTabControl.Name = "ScriptTabControl";
            this.ScriptTabControl.SelectedIndex = 0;
            this.ScriptTabControl.Size = new System.Drawing.Size(458, 21);
            this.ScriptTabControl.TabIndex = 9;
            this.ScriptTabControl.SelectedIndexChanged += new System.EventHandler(this.ScriptTabControl_SelectedIndexChanged);
            // 
            // EnterTab
            // 
            this.EnterTab.Location = new System.Drawing.Point(4, 22);
            this.EnterTab.Name = "EnterTab";
            this.EnterTab.Padding = new System.Windows.Forms.Padding(3);
            this.EnterTab.Size = new System.Drawing.Size(450, 0);
            this.EnterTab.TabIndex = 0;
            this.EnterTab.Text = "On Enter Map";
            this.EnterTab.UseVisualStyleBackColor = true;
            // 
            // LeaveTab
            // 
            this.LeaveTab.Location = new System.Drawing.Point(4, 22);
            this.LeaveTab.Name = "LeaveTab";
            this.LeaveTab.Padding = new System.Windows.Forms.Padding(3);
            this.LeaveTab.Size = new System.Drawing.Size(450, 0);
            this.LeaveTab.TabIndex = 1;
            this.LeaveTab.Text = "On Leave Map";
            this.LeaveTab.UseVisualStyleBackColor = true;
            // 
            // LeaveNorth
            // 
            this.LeaveNorth.Location = new System.Drawing.Point(4, 22);
            this.LeaveNorth.Name = "LeaveNorth";
            this.LeaveNorth.Size = new System.Drawing.Size(450, 0);
            this.LeaveNorth.TabIndex = 2;
            this.LeaveNorth.Text = "Leave North";
            this.LeaveNorth.UseVisualStyleBackColor = true;
            // 
            // LeaveEast
            // 
            this.LeaveEast.Location = new System.Drawing.Point(4, 22);
            this.LeaveEast.Name = "LeaveEast";
            this.LeaveEast.Size = new System.Drawing.Size(450, 0);
            this.LeaveEast.TabIndex = 3;
            this.LeaveEast.Text = "Leave East";
            this.LeaveEast.UseVisualStyleBackColor = true;
            // 
            // LeaveSouth
            // 
            this.LeaveSouth.Location = new System.Drawing.Point(4, 22);
            this.LeaveSouth.Name = "LeaveSouth";
            this.LeaveSouth.Size = new System.Drawing.Size(450, 0);
            this.LeaveSouth.TabIndex = 4;
            this.LeaveSouth.Text = "Leave South";
            this.LeaveSouth.UseVisualStyleBackColor = true;
            // 
            // LeaveWest
            // 
            this.LeaveWest.Location = new System.Drawing.Point(4, 22);
            this.LeaveWest.Name = "LeaveWest";
            this.LeaveWest.Size = new System.Drawing.Size(450, 0);
            this.LeaveWest.TabIndex = 5;
            this.LeaveWest.Text = "Leave West";
            this.LeaveWest.UseVisualStyleBackColor = true;
            // 
            // ScriptPanel
            // 
            this.ScriptPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ScriptPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ScriptPanel.Location = new System.Drawing.Point(12, 146);
            this.ScriptPanel.Name = "ScriptPanel";
            this.ScriptPanel.Size = new System.Drawing.Size(456, 188);
            this.ScriptPanel.TabIndex = 10;
            // 
            // BgMusicButton
            // 
            this.BgMusicButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BgMusicButton.Enabled = false;
            this.BgMusicButton.Location = new System.Drawing.Point(361, 36);
            this.BgMusicButton.Name = "BgMusicButton";
            this.BgMusicButton.Size = new System.Drawing.Size(26, 23);
            this.BgMusicButton.TabIndex = 2;
            this.BgMusicButton.Text = "...";
            this.BgMusicButton.UseVisualStyleBackColor = true;
            // 
            // TilesetButton
            // 
            this.TilesetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TilesetButton.Enabled = false;
            this.TilesetButton.Location = new System.Drawing.Point(361, 62);
            this.TilesetButton.Name = "TilesetButton";
            this.TilesetButton.Size = new System.Drawing.Size(26, 23);
            this.TilesetButton.TabIndex = 4;
            this.TilesetButton.Text = "...";
            this.TilesetButton.UseVisualStyleBackColor = true;
            // 
            // ScriptLabel
            // 
            this.ScriptLabel.AutoSize = true;
            this.ScriptLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScriptLabel.Location = new System.Drawing.Point(9, 110);
            this.ScriptLabel.Name = "ScriptLabel";
            this.ScriptLabel.Size = new System.Drawing.Size(123, 13);
            this.ScriptLabel.TabIndex = 13;
            this.ScriptLabel.Text = "Default Map Scripts:\r\n";
            // 
            // TilePropPanel
            // 
            this.TilePropPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TilePropPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.TilePropPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.TilePropPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TilePropPanel.Controls.Add(this.RescaleCheckBox);
            this.TilePropPanel.Controls.Add(this.TileHeightBox);
            this.TilePropPanel.Controls.Add(this.TileSizeComboBox);
            this.TilePropPanel.Controls.Add(this.XLabel);
            this.TilePropPanel.Controls.Add(this.TileWidthBox);
            this.TilePropPanel.Controls.Add(this.TileSizeLabel);
            this.TilePropPanel.Controls.Add(this.TilePropLabel);
            this.TilePropPanel.Location = new System.Drawing.Point(11, 340);
            this.TilePropPanel.Name = "TilePropPanel";
            this.TilePropPanel.Size = new System.Drawing.Size(220, 90);
            this.TilePropPanel.TabIndex = 14;
            // 
            // RescaleCheckBox
            // 
            this.RescaleCheckBox.AutoSize = true;
            this.RescaleCheckBox.Location = new System.Drawing.Point(144, 68);
            this.RescaleCheckBox.Name = "RescaleCheckBox";
            this.RescaleCheckBox.Size = new System.Drawing.Size(71, 17);
            this.RescaleCheckBox.TabIndex = 9;
            this.RescaleCheckBox.Text = "Rescale?";
            this.RescaleCheckBox.UseVisualStyleBackColor = true;
            // 
            // TileHeightBox
            // 
            this.TileHeightBox.Location = new System.Drawing.Point(81, 65);
            this.TileHeightBox.Name = "TileHeightBox";
            this.TileHeightBox.Size = new System.Drawing.Size(46, 20);
            this.TileHeightBox.TabIndex = 8;
            this.TileHeightBox.Text = "16";
            this.TileHeightBox.TextChanged += new System.EventHandler(this.TileWidthBox_TextChanged);
            this.TileHeightBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // TileSizeComboBox
            // 
            this.TileSizeComboBox.FormattingEnabled = true;
            this.TileSizeComboBox.Items.AddRange(new object[] {
            "8 x 8",
            "16 x 16",
            "24 x 24",
            "32 x 32"});
            this.TileSizeComboBox.Location = new System.Drawing.Point(66, 29);
            this.TileSizeComboBox.Name = "TileSizeComboBox";
            this.TileSizeComboBox.Size = new System.Drawing.Size(149, 21);
            this.TileSizeComboBox.TabIndex = 6;
            this.TileSizeComboBox.Text = "16 x 16";
            this.TileSizeComboBox.SelectedIndexChanged += new System.EventHandler(this.TileSizeComboBox_SelectedIndexChanged);
            // 
            // XLabel
            // 
            this.XLabel.AutoSize = true;
            this.XLabel.BackColor = System.Drawing.Color.Transparent;
            this.XLabel.Location = new System.Drawing.Point(58, 68);
            this.XLabel.Margin = new System.Windows.Forms.Padding(6);
            this.XLabel.Name = "XLabel";
            this.XLabel.Size = new System.Drawing.Size(14, 13);
            this.XLabel.TabIndex = 4;
            this.XLabel.Text = "X";
            // 
            // TileWidthBox
            // 
            this.TileWidthBox.Location = new System.Drawing.Point(3, 65);
            this.TileWidthBox.Name = "TileWidthBox";
            this.TileWidthBox.Size = new System.Drawing.Size(46, 20);
            this.TileWidthBox.TabIndex = 7;
            this.TileWidthBox.Text = "16";
            this.TileWidthBox.TextChanged += new System.EventHandler(this.TileWidthBox_TextChanged);
            this.TileWidthBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // TileSizeLabel
            // 
            this.TileSizeLabel.BackColor = System.Drawing.Color.Transparent;
            this.TileSizeLabel.Location = new System.Drawing.Point(6, 29);
            this.TileSizeLabel.Margin = new System.Windows.Forms.Padding(6);
            this.TileSizeLabel.Name = "TileSizeLabel";
            this.TileSizeLabel.Size = new System.Drawing.Size(51, 21);
            this.TileSizeLabel.TabIndex = 1;
            this.TileSizeLabel.Text = "Tile Size:";
            this.TileSizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TilePropLabel
            // 
            this.TilePropLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TilePropLabel.Font = new System.Drawing.Font("Verdana", 10.5F);
            this.TilePropLabel.ForeColor = System.Drawing.Color.MidnightBlue;
            this.TilePropLabel.Location = new System.Drawing.Point(0, 0);
            this.TilePropLabel.Name = "TilePropLabel";
            this.TilePropLabel.Size = new System.Drawing.Size(218, 23);
            this.TilePropLabel.TabIndex = 0;
            this.TilePropLabel.Text = "Tile Size";
            this.TilePropLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LayerHeightBox
            // 
            this.LayerHeightBox.Location = new System.Drawing.Point(164, 45);
            this.LayerHeightBox.Margin = new System.Windows.Forms.Padding(3, 3, 6, 3);
            this.LayerHeightBox.Name = "LayerHeightBox";
            this.LayerHeightBox.Size = new System.Drawing.Size(48, 20);
            this.LayerHeightBox.TabIndex = 10;
            this.LayerHeightBox.Text = "15";
            this.LayerHeightBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // XLabel2
            // 
            this.XLabel2.AutoSize = true;
            this.XLabel2.BackColor = System.Drawing.Color.Transparent;
            this.XLabel2.Location = new System.Drawing.Point(141, 48);
            this.XLabel2.Margin = new System.Windows.Forms.Padding(6);
            this.XLabel2.Name = "XLabel2";
            this.XLabel2.Size = new System.Drawing.Size(14, 13);
            this.XLabel2.TabIndex = 8;
            this.XLabel2.Text = "X";
            // 
            // LayerWidthBox
            // 
            this.LayerWidthBox.Location = new System.Drawing.Point(84, 45);
            this.LayerWidthBox.Name = "LayerWidthBox";
            this.LayerWidthBox.Size = new System.Drawing.Size(48, 20);
            this.LayerWidthBox.TabIndex = 9;
            this.LayerWidthBox.Text = "20";
            this.LayerWidthBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // LayerSizeLabel
            // 
            this.LayerSizeLabel.BackColor = System.Drawing.Color.Transparent;
            this.LayerSizeLabel.Location = new System.Drawing.Point(6, 29);
            this.LayerSizeLabel.Margin = new System.Windows.Forms.Padding(6);
            this.LayerSizeLabel.Name = "LayerSizeLabel";
            this.LayerSizeLabel.Size = new System.Drawing.Size(65, 51);
            this.LayerSizeLabel.TabIndex = 6;
            this.LayerSizeLabel.Text = "Layer Size: (in tiles)";
            this.LayerSizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LayerPropPanel
            // 
            this.LayerPropPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LayerPropPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.LayerPropPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LayerPropPanel.Controls.Add(this.LayerWidthBox);
            this.LayerPropPanel.Controls.Add(this.XLabel2);
            this.LayerPropPanel.Controls.Add(this.LayerPropLabel);
            this.LayerPropPanel.Controls.Add(this.LayerHeightBox);
            this.LayerPropPanel.Controls.Add(this.LayerSizeLabel);
            this.LayerPropPanel.Location = new System.Drawing.Point(249, 341);
            this.LayerPropPanel.Margin = new System.Windows.Forms.Padding(6);
            this.LayerPropPanel.Name = "LayerPropPanel";
            this.LayerPropPanel.Size = new System.Drawing.Size(220, 90);
            this.LayerPropPanel.TabIndex = 15;
            // 
            // LayerPropLabel
            // 
            this.LayerPropLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.LayerPropLabel.Font = new System.Drawing.Font("Verdana", 10.5F);
            this.LayerPropLabel.ForeColor = System.Drawing.Color.MidnightBlue;
            this.LayerPropLabel.Location = new System.Drawing.Point(0, 0);
            this.LayerPropLabel.Name = "LayerPropLabel";
            this.LayerPropLabel.Size = new System.Drawing.Size(218, 23);
            this.LayerPropLabel.TabIndex = 0;
            this.LayerPropLabel.Text = "Map Size";
            this.LayerPropLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LayerNumLabel
            // 
            this.LayerNumLabel.AutoSize = true;
            this.LayerNumLabel.Location = new System.Drawing.Point(219, 110);
            this.LayerNumLabel.Name = "LayerNumLabel";
            this.LayerNumLabel.Size = new System.Drawing.Size(78, 13);
            this.LayerNumLabel.TabIndex = 11;
            this.LayerNumLabel.Text = "# of Layers: (0)";
            // 
            // EntityNumLabel
            // 
            this.EntityNumLabel.AutoSize = true;
            this.EntityNumLabel.Location = new System.Drawing.Point(303, 110);
            this.EntityNumLabel.Name = "EntityNumLabel";
            this.EntityNumLabel.Size = new System.Drawing.Size(81, 13);
            this.EntityNumLabel.TabIndex = 16;
            this.EntityNumLabel.Text = "# of Entities: (0)";
            // 
            // ZoneNumLabel
            // 
            this.ZoneNumLabel.AutoSize = true;
            this.ZoneNumLabel.Location = new System.Drawing.Point(390, 110);
            this.ZoneNumLabel.Name = "ZoneNumLabel";
            this.ZoneNumLabel.Size = new System.Drawing.Size(77, 13);
            this.ZoneNumLabel.TabIndex = 17;
            this.ZoneNumLabel.Text = "# of Zones: (0)";
            // 
            // MapPropertiesForm
            // 
            this.AcceptButton = this.OkayButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 442);
            this.Controls.Add(this.ZoneNumLabel);
            this.Controls.Add(this.EntityNumLabel);
            this.Controls.Add(this.LayerNumLabel);
            this.Controls.Add(this.LayerPropPanel);
            this.Controls.Add(this.TilePropPanel);
            this.Controls.Add(this.RepeatMapCheckBox);
            this.Controls.Add(this.ScriptTabControl);
            this.Controls.Add(this.ScriptLabel);
            this.Controls.Add(this.TilesetButton);
            this.Controls.Add(this.BgMusicButton);
            this.Controls.Add(this.ScriptPanel);
            this.Controls.Add(this.TheCancelButton);
            this.Controls.Add(this.OkayButton);
            this.Controls.Add(this.BgMusicLabel);
            this.Controls.Add(this.TilesetLabel);
            this.Controls.Add(this.FilenameLabel);
            this.Controls.Add(this.TilesetTextbox);
            this.Controls.Add(this.BgMusicTextbox);
            this.Controls.Add(this.FilenameTextBox);
            this.DoubleBuffered = true;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(496, 480);
            this.Name = "MapPropertiesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Map Properties";
            this.ScriptTabControl.ResumeLayout(false);
            this.TilePropPanel.ResumeLayout(false);
            this.TilePropPanel.PerformLayout();
            this.LayerPropPanel.ResumeLayout(false);
            this.LayerPropPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FilenameTextBox;
        private System.Windows.Forms.TextBox BgMusicTextbox;
        private System.Windows.Forms.TextBox TilesetTextbox;
        private System.Windows.Forms.CheckBox RepeatMapCheckBox;
        private System.Windows.Forms.Label FilenameLabel;
        private System.Windows.Forms.Label TilesetLabel;
        private System.Windows.Forms.Label BgMusicLabel;
        private System.Windows.Forms.Button OkayButton;
        private System.Windows.Forms.Button TheCancelButton;
        private System.Windows.Forms.TabControl ScriptTabControl;
        private System.Windows.Forms.TabPage EnterTab;
        private System.Windows.Forms.TabPage LeaveTab;
        private System.Windows.Forms.TabPage LeaveNorth;
        private System.Windows.Forms.TabPage LeaveEast;
        private System.Windows.Forms.TabPage LeaveSouth;
        private System.Windows.Forms.TabPage LeaveWest;
        private System.Windows.Forms.Panel ScriptPanel;
        private System.Windows.Forms.Button BgMusicButton;
        private System.Windows.Forms.Button TilesetButton;
        private System.Windows.Forms.Label ScriptLabel;
        private System.Windows.Forms.Panel TilePropPanel;
        private Sphere.Core.Editor.EditorLabel TilePropLabel;
        private System.Windows.Forms.ComboBox TileSizeComboBox;
        private System.Windows.Forms.Label XLabel;
        private System.Windows.Forms.TextBox TileHeightBox;
        private System.Windows.Forms.TextBox TileWidthBox;
        private System.Windows.Forms.Label TileSizeLabel;
        private System.Windows.Forms.TextBox LayerHeightBox;
        private System.Windows.Forms.Label XLabel2;
        private System.Windows.Forms.TextBox LayerWidthBox;
        private System.Windows.Forms.Label LayerSizeLabel;
        private System.Windows.Forms.Panel LayerPropPanel;
        private Sphere.Core.Editor.EditorLabel LayerPropLabel;
        private System.Windows.Forms.CheckBox RescaleCheckBox;
        private System.Windows.Forms.Label LayerNumLabel;
        private System.Windows.Forms.Label EntityNumLabel;
        private System.Windows.Forms.Label ZoneNumLabel;
    }
}