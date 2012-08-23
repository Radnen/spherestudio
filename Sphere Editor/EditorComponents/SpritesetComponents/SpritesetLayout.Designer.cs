namespace Sphere_Editor.SpritesetComponents
{
    partial class DirectionLayout
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
            this.InfoPanel = new System.Windows.Forms.Panel();
            this.NamePanel = new System.Windows.Forms.Panel();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.NameLabel = new Sphere_Editor.EditorLabel();
            this.ImagesPanel = new System.Windows.Forms.Panel();
            this.AddPanel = new System.Windows.Forms.Panel();
            this.AddFrameButton = new System.Windows.Forms.Button();
            this.RemoveFrameButton = new System.Windows.Forms.Button();
            this.DirectionStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Seperator1 = new System.Windows.Forms.ToolStripSeparator();
            this.AddDirectionItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveDirectionItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Separator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ZoomInItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ZoomOutItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Separator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ToggleItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SetDelayItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Seperator4 = new System.Windows.Forms.ToolStripSeparator();
            this.InfoPanel.SuspendLayout();
            this.NamePanel.SuspendLayout();
            this.AddPanel.SuspendLayout();
            this.DirectionStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // InfoPanel
            // 
            this.InfoPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(225)))), ((int)(((byte)(243)))));
            this.InfoPanel.Controls.Add(this.NamePanel);
            this.InfoPanel.Controls.Add(this.NameLabel);
            this.InfoPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.InfoPanel.Location = new System.Drawing.Point(0, 0);
            this.InfoPanel.Name = "InfoPanel";
            this.InfoPanel.Size = new System.Drawing.Size(140, 81);
            this.InfoPanel.TabIndex = 0;
            // 
            // NamePanel
            // 
            this.NamePanel.Controls.Add(this.NameTextBox);
            this.NamePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NamePanel.Location = new System.Drawing.Point(0, 23);
            this.NamePanel.Name = "NamePanel";
            this.NamePanel.Size = new System.Drawing.Size(140, 58);
            this.NamePanel.TabIndex = 2;
            // 
            // NameTextBox
            // 
            this.NameTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NameTextBox.Location = new System.Drawing.Point(5, 19);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(131, 20);
            this.NameTextBox.TabIndex = 1;
            this.NameTextBox.Text = "Direction";
            this.NameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NameTextBox.TextChanged += new System.EventHandler(this.NameTextBox_TextChanged);
            // 
            // NameLabel
            // 
            this.NameLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.NameLabel.Font = new System.Drawing.Font("Verdana", 10.5F);
            this.NameLabel.ForeColor = System.Drawing.Color.MidnightBlue;
            this.NameLabel.Location = new System.Drawing.Point(0, 0);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(140, 23);
            this.NameLabel.TabIndex = 3;
            this.NameLabel.Text = "Name";
            this.NameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.NameLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NameLabel_MouseDown);
            this.NameLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NameLabel_MouseMove);
            // 
            // ImagesPanel
            // 
            this.ImagesPanel.AutoSize = true;
            this.ImagesPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImagesPanel.Location = new System.Drawing.Point(140, 0);
            this.ImagesPanel.Name = "ImagesPanel";
            this.ImagesPanel.Size = new System.Drawing.Size(0, 81);
            this.ImagesPanel.TabIndex = 1;
            // 
            // AddPanel
            // 
            this.AddPanel.AllowDrop = true;
            this.AddPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(225)))), ((int)(((byte)(243)))));
            this.AddPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AddPanel.Controls.Add(this.AddFrameButton);
            this.AddPanel.Controls.Add(this.RemoveFrameButton);
            this.AddPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.AddPanel.Location = new System.Drawing.Point(140, 0);
            this.AddPanel.MinimumSize = new System.Drawing.Size(90, 2);
            this.AddPanel.Name = "AddPanel";
            this.AddPanel.Size = new System.Drawing.Size(90, 81);
            this.AddPanel.TabIndex = 0;
            // 
            // AddFrameButton
            // 
            this.AddFrameButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AddFrameButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.AddFrameButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddFrameButton.Image = global::Sphere_Editor.Properties.Resources.resultset_next;
            this.AddFrameButton.Location = new System.Drawing.Point(47, 23);
            this.AddFrameButton.Name = "AddFrameButton";
            this.AddFrameButton.Size = new System.Drawing.Size(32, 32);
            this.AddFrameButton.TabIndex = 0;
            this.AddFrameButton.UseVisualStyleBackColor = true;
            this.AddFrameButton.Click += new System.EventHandler(this.AddFrameButton_Click);
            // 
            // RemoveFrameButton
            // 
            this.RemoveFrameButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RemoveFrameButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.RemoveFrameButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.RemoveFrameButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RemoveFrameButton.Image = global::Sphere_Editor.Properties.Resources.resultset_previous;
            this.RemoveFrameButton.Location = new System.Drawing.Point(9, 23);
            this.RemoveFrameButton.Name = "RemoveFrameButton";
            this.RemoveFrameButton.Size = new System.Drawing.Size(32, 32);
            this.RemoveFrameButton.TabIndex = 1;
            this.RemoveFrameButton.UseVisualStyleBackColor = true;
            this.RemoveFrameButton.Click += new System.EventHandler(this.RemoveFrameButton_Click);
            // 
            // DirectionStrip
            // 
            this.DirectionStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddItem,
            this.RemoveItem,
            this.Seperator1,
            this.AddDirectionItem,
            this.RemoveDirectionItem,
            this.Separator2,
            this.SetDelayItem,
            this.Separator3,
            this.ZoomInItem,
            this.ZoomOutItem,
            this.Seperator4,
            this.ToggleItem});
            this.DirectionStrip.Name = "DirectionStrip";
            this.DirectionStrip.Size = new System.Drawing.Size(176, 204);
            this.DirectionStrip.Opening += new System.ComponentModel.CancelEventHandler(this.DirectionStrip_Opening);
            // 
            // AddItem
            // 
            this.AddItem.Image = global::Sphere_Editor.Properties.Resources.add;
            this.AddItem.Name = "AddItem";
            this.AddItem.Size = new System.Drawing.Size(175, 22);
            this.AddItem.Text = "&Add Frame";
            this.AddItem.Click += new System.EventHandler(this.AddItem_Click);
            // 
            // RemoveItem
            // 
            this.RemoveItem.Image = global::Sphere_Editor.Properties.Resources.delete;
            this.RemoveItem.Name = "RemoveItem";
            this.RemoveItem.Size = new System.Drawing.Size(175, 22);
            this.RemoveItem.Text = "&Remove Frame";
            this.RemoveItem.Click += new System.EventHandler(this.RemoveItem_Click);
            // 
            // Seperator1
            // 
            this.Seperator1.Name = "Seperator1";
            this.Seperator1.Size = new System.Drawing.Size(172, 6);
            // 
            // AddDirectionItem
            // 
            this.AddDirectionItem.Image = global::Sphere_Editor.Properties.Resources.add;
            this.AddDirectionItem.Name = "AddDirectionItem";
            this.AddDirectionItem.Size = new System.Drawing.Size(175, 22);
            this.AddDirectionItem.Text = "Add &Direction";
            this.AddDirectionItem.Click += new System.EventHandler(this.AddDirectionItem_Click);
            // 
            // RemoveDirectionItem
            // 
            this.RemoveDirectionItem.Image = global::Sphere_Editor.Properties.Resources.delete;
            this.RemoveDirectionItem.Name = "RemoveDirectionItem";
            this.RemoveDirectionItem.Size = new System.Drawing.Size(175, 22);
            this.RemoveDirectionItem.Text = "R&emove Direction";
            this.RemoveDirectionItem.Click += new System.EventHandler(this.RemoveDirectionItem_Click);
            // 
            // Separator2
            // 
            this.Separator2.Name = "Separator2";
            this.Separator2.Size = new System.Drawing.Size(172, 6);
            // 
            // ZoomInItem
            // 
            this.ZoomInItem.Image = global::Sphere_Editor.Properties.Resources.magnifier_zoom_in;
            this.ZoomInItem.Name = "ZoomInItem";
            this.ZoomInItem.Size = new System.Drawing.Size(175, 22);
            this.ZoomInItem.Text = "Zoom &In";
            this.ZoomInItem.Click += new System.EventHandler(this.ZoomInItem_Click);
            // 
            // ZoomOutItem
            // 
            this.ZoomOutItem.Image = global::Sphere_Editor.Properties.Resources.magnifier_zoom_out;
            this.ZoomOutItem.Name = "ZoomOutItem";
            this.ZoomOutItem.Size = new System.Drawing.Size(175, 22);
            this.ZoomOutItem.Text = "Zoom &Out";
            this.ZoomOutItem.Click += new System.EventHandler(this.ZoomOutItem_Click);
            // 
            // Separator3
            // 
            this.Separator3.Name = "Separator3";
            this.Separator3.Size = new System.Drawing.Size(172, 6);
            // 
            // ToggleItem
            // 
            this.ToggleItem.Name = "ToggleItem";
            this.ToggleItem.Size = new System.Drawing.Size(175, 22);
            this.ToggleItem.Text = "&Toggle Show Delay";
            this.ToggleItem.Click += new System.EventHandler(this.ToggleItem_Click);
            // 
            // SetDelayItem
            // 
            this.SetDelayItem.Image = global::Sphere_Editor.Properties.Resources.page_white_edit;
            this.SetDelayItem.Name = "SetDelayItem";
            this.SetDelayItem.Size = new System.Drawing.Size(175, 22);
            this.SetDelayItem.Text = "&Set Delay...";
            this.SetDelayItem.Click += new System.EventHandler(this.SetDelayItem_Click);
            // 
            // Seperator4
            // 
            this.Seperator4.Name = "Seperator4";
            this.Seperator4.Size = new System.Drawing.Size(172, 6);
            // 
            // DirectionLayout
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ContextMenuStrip = this.DirectionStrip;
            this.Controls.Add(this.ImagesPanel);
            this.Controls.Add(this.InfoPanel);
            this.Controls.Add(this.AddPanel);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(230, 83);
            this.Name = "DirectionLayout";
            this.Size = new System.Drawing.Size(230, 81);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.DirectionLayout_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.DirectionLayout_DragEnter);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.DirectionLayout_DragOver);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.DirectionLayout_Paint);
            this.InfoPanel.ResumeLayout(false);
            this.NamePanel.ResumeLayout(false);
            this.NamePanel.PerformLayout();
            this.AddPanel.ResumeLayout(false);
            this.DirectionStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel InfoPanel;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Panel NamePanel;
        private System.Windows.Forms.Panel ImagesPanel;
        private System.Windows.Forms.Panel AddPanel;
        private System.Windows.Forms.Button RemoveFrameButton;
        private System.Windows.Forms.Button AddFrameButton;
        private System.Windows.Forms.ContextMenuStrip DirectionStrip;
        private System.Windows.Forms.ToolStripMenuItem AddItem;
        private System.Windows.Forms.ToolStripMenuItem RemoveItem;
        private System.Windows.Forms.ToolStripSeparator Seperator1;
        private System.Windows.Forms.ToolStripMenuItem ToggleItem;
        private EditorLabel NameLabel;
        private System.Windows.Forms.ToolStripMenuItem ZoomInItem;
        private System.Windows.Forms.ToolStripMenuItem ZoomOutItem;
        private System.Windows.Forms.ToolStripSeparator Separator3;
        private System.Windows.Forms.ToolStripMenuItem AddDirectionItem;
        private System.Windows.Forms.ToolStripSeparator Separator2;
        private System.Windows.Forms.ToolStripMenuItem RemoveDirectionItem;
        private System.Windows.Forms.ToolStripMenuItem SetDelayItem;
        private System.Windows.Forms.ToolStripSeparator Seperator4;

    }
}
