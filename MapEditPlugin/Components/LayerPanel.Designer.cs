namespace SphereStudio.Plugins.Components
{
    partial class LayerPanel
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
            this.MoveDownButton = new System.Windows.Forms.Button();
            this.MoveUpButton = new System.Windows.Forms.Button();
            this.RemoveLayerButton = new System.Windows.Forms.Button();
            this.AddLayerButton = new System.Windows.Forms.Button();
            this.LayerContextStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddLayerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveLayerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MoveUpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MoveDownMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RenameLayerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LayersPanel = new Sphere.Core.Editor.EditorPanel();
            this.LayerContextStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MoveDownButton
            // 
            this.MoveDownButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.MoveDownButton.Location = new System.Drawing.Point(76, 279);
            this.MoveDownButton.Name = "MoveDownButton";
            this.MoveDownButton.Size = new System.Drawing.Size(74, 28);
            this.MoveDownButton.TabIndex = 8;
            this.MoveDownButton.Text = "Move Down";
            this.MoveDownButton.UseVisualStyleBackColor = true;
            // 
            // MoveUpButton
            // 
            this.MoveUpButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.MoveUpButton.Location = new System.Drawing.Point(2, 279);
            this.MoveUpButton.Name = "MoveUpButton";
            this.MoveUpButton.Size = new System.Drawing.Size(74, 28);
            this.MoveUpButton.TabIndex = 7;
            this.MoveUpButton.Text = "Move Up";
            this.MoveUpButton.UseVisualStyleBackColor = true;
            // 
            // RemoveLayerButton
            // 
            this.RemoveLayerButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.RemoveLayerButton.Location = new System.Drawing.Point(3, 250);
            this.RemoveLayerButton.Name = "RemoveLayerButton";
            this.RemoveLayerButton.Size = new System.Drawing.Size(146, 23);
            this.RemoveLayerButton.TabIndex = 10;
            this.RemoveLayerButton.Text = "Remove Layer";
            this.RemoveLayerButton.UseVisualStyleBackColor = true;
            this.RemoveLayerButton.Click += new System.EventHandler(this.RemoveLayerButton_Click);
            // 
            // AddLayerButton
            // 
            this.AddLayerButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.AddLayerButton.Location = new System.Drawing.Point(3, 3);
            this.AddLayerButton.Name = "AddLayerButton";
            this.AddLayerButton.Size = new System.Drawing.Size(146, 23);
            this.AddLayerButton.TabIndex = 9;
            this.AddLayerButton.Text = "Add Layer";
            this.AddLayerButton.UseVisualStyleBackColor = true;
            this.AddLayerButton.Click += new System.EventHandler(this.AddLayerButton_Click);
            // 
            // LayerContextStrip
            // 
            this.LayerContextStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddLayerMenuItem,
            this.RemoveLayerMenuItem,
            this.MoveUpMenuItem,
            this.MoveDownMenuItem,
            this.RenameLayerMenuItem});
            this.LayerContextStrip.Name = "LayerContextStrip";
            this.LayerContextStrip.Size = new System.Drawing.Size(158, 114);
            this.LayerContextStrip.Opening += new System.ComponentModel.CancelEventHandler(this.LayerContextStrip_Opening);
            // 
            // AddLayerMenuItem
            // 
            this.AddLayerMenuItem.Image = global::SphereStudio.Plugins.Properties.Resources.add;
            this.AddLayerMenuItem.Name = "AddLayerMenuItem";
            this.AddLayerMenuItem.Size = new System.Drawing.Size(157, 22);
            this.AddLayerMenuItem.Text = "&Add Layer";
            this.AddLayerMenuItem.Click += new System.EventHandler(this.AddLayerButton_Click);
            // 
            // RemoveLayerMenuItem
            // 
            this.RemoveLayerMenuItem.Image = global::SphereStudio.Plugins.Properties.Resources.delete;
            this.RemoveLayerMenuItem.Name = "RemoveLayerMenuItem";
            this.RemoveLayerMenuItem.Size = new System.Drawing.Size(157, 22);
            this.RemoveLayerMenuItem.Text = "&Remove Layer";
            this.RemoveLayerMenuItem.Click += new System.EventHandler(this.RemoveLayerButton_Click);
            // 
            // MoveUpMenuItem
            // 
            this.MoveUpMenuItem.Name = "MoveUpMenuItem";
            this.MoveUpMenuItem.Size = new System.Drawing.Size(157, 22);
            this.MoveUpMenuItem.Text = "Move &Up";
            // 
            // MoveDownMenuItem
            // 
            this.MoveDownMenuItem.Name = "MoveDownMenuItem";
            this.MoveDownMenuItem.Size = new System.Drawing.Size(157, 22);
            this.MoveDownMenuItem.Text = "Move &Down";
            // 
            // RenameLayerMenuItem
            // 
            this.RenameLayerMenuItem.Image = global::SphereStudio.Plugins.Properties.Resources.application_view_list;
            this.RenameLayerMenuItem.Name = "RenameLayerMenuItem";
            this.RenameLayerMenuItem.Size = new System.Drawing.Size(157, 22);
            this.RenameLayerMenuItem.Text = "Re&name Layer...";
            this.RenameLayerMenuItem.Click += new System.EventHandler(this.RenameLayerMenuItem_Click);
            // 
            // LayersPanel
            // 
            this.LayersPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.LayersPanel.AutoScroll = true;
            this.LayersPanel.BackColor = System.Drawing.SystemColors.Control;
            this.LayersPanel.Location = new System.Drawing.Point(3, 32);
            this.LayersPanel.Name = "LayersPanel";
            this.LayersPanel.Size = new System.Drawing.Size(146, 212);
            this.LayersPanel.TabIndex = 11;
            this.LayersPanel.XSnap = 0;
            this.LayersPanel.YSnap = 0;
            // 
            // LayerPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(225)))), ((int)(((byte)(243)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.MoveDownButton);
            this.Controls.Add(this.LayersPanel);
            this.Controls.Add(this.MoveUpButton);
            this.Controls.Add(this.RemoveLayerButton);
            this.Controls.Add(this.AddLayerButton);
            this.Name = "LayerPanel";
            this.Size = new System.Drawing.Size(153, 310);
            this.Resize += new System.EventHandler(this.LayerPanel_Resize);
            this.LayerContextStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button MoveDownButton;
        private System.Windows.Forms.Button MoveUpButton;
        private System.Windows.Forms.Button RemoveLayerButton;
        private System.Windows.Forms.Button AddLayerButton;
        private System.Windows.Forms.ContextMenuStrip LayerContextStrip;
        private System.Windows.Forms.ToolStripMenuItem AddLayerMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RemoveLayerMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MoveUpMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MoveDownMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RenameLayerMenuItem;
        private Sphere.Core.Editor.EditorPanel LayersPanel;
    }
}
