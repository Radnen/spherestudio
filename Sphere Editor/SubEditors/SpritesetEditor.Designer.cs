namespace Sphere_Editor.SubEditors
{
    partial class SpritesetEditor
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
            if (disposing)
            {
                if (components != null) components.Dispose();
                Destroy();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpritesetEditor));
            this.DirectionHolder = new Sphere_Editor.EditorPanel();
            this.SpriteDrawer = new Sphere_Editor.SubEditors.Drawer2();
            this.DirectionSplitter = new System.Windows.Forms.SplitContainer();
            this.ImagePanel = new System.Windows.Forms.Panel();
            this.ImageHolder = new Sphere_Editor.EditorPanel();
            this.ImagesLabel = new Sphere_Editor.EditorLabel();
            this.BasePanel = new System.Windows.Forms.Panel();
            this.BaseEditorLabel = new Sphere_Editor.EditorLabel();
            this.FrameBaseEditor = new Sphere_Editor.SpritesetComponents.BaseEditor();
            this.AnimPanel = new System.Windows.Forms.Panel();
            this.AnimLabel = new Sphere_Editor.EditorLabel();
            this.DirectionAnim = new Sphere_Editor.SpritesetComponents.DirectionAnimator();
            this.DirectionHolder.SuspendLayout();
            this.DirectionSplitter.Panel1.SuspendLayout();
            this.DirectionSplitter.Panel2.SuspendLayout();
            this.DirectionSplitter.SuspendLayout();
            this.ImagePanel.SuspendLayout();
            this.BasePanel.SuspendLayout();
            this.AnimPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // DirectionHolder
            // 
            this.DirectionHolder.AutoScroll = true;
            this.DirectionHolder.AutoScrollMargin = new System.Drawing.Size(32, 0);
            this.DirectionHolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.DirectionHolder.Controls.Add(this.SpriteDrawer);
            this.DirectionHolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DirectionHolder.Location = new System.Drawing.Point(0, 0);
            this.DirectionHolder.Name = "DirectionHolder";
            this.DirectionHolder.Size = new System.Drawing.Size(528, 487);
            this.DirectionHolder.TabIndex = 3;
            this.DirectionHolder.XSnap = 0;
            this.DirectionHolder.YSnap = 0;
            // 
            // SpriteDrawer
            // 
            this.SpriteDrawer.CanDirty = false;
            this.SpriteDrawer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SpriteDrawer.FixedSize = true;
            this.SpriteDrawer.HelpLabel = null;
            this.SpriteDrawer.Location = new System.Drawing.Point(0, 313);
            this.SpriteDrawer.Name = "SpriteDrawer";
            this.SpriteDrawer.Size = new System.Drawing.Size(528, 174);
            this.SpriteDrawer.TabIndex = 0;
            this.SpriteDrawer.ImageEdited += new System.EventHandler(this.SpriteDrawer_ImageEdited);
            // 
            // DirectionSplitter
            // 
            this.DirectionSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DirectionSplitter.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.DirectionSplitter.Location = new System.Drawing.Point(0, 0);
            this.DirectionSplitter.Name = "DirectionSplitter";
            // 
            // DirectionSplitter.Panel1
            // 
            this.DirectionSplitter.Panel1.Controls.Add(this.DirectionHolder);
            // 
            // DirectionSplitter.Panel2
            // 
            this.DirectionSplitter.Panel2.Controls.Add(this.ImagePanel);
            this.DirectionSplitter.Panel2.Controls.Add(this.BasePanel);
            this.DirectionSplitter.Panel2.Controls.Add(this.AnimPanel);
            this.DirectionSplitter.Size = new System.Drawing.Size(808, 487);
            this.DirectionSplitter.SplitterDistance = 528;
            this.DirectionSplitter.TabIndex = 4;
            // 
            // ImagePanel
            // 
            this.ImagePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ImagePanel.Controls.Add(this.ImageHolder);
            this.ImagePanel.Controls.Add(this.ImagesLabel);
            this.ImagePanel.Location = new System.Drawing.Point(6, 6);
            this.ImagePanel.Margin = new System.Windows.Forms.Padding(6);
            this.ImagePanel.Name = "ImagePanel";
            this.ImagePanel.Size = new System.Drawing.Size(264, 148);
            this.ImagePanel.TabIndex = 7;
            // 
            // ImageHolder
            // 
            this.ImageHolder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ImageHolder.AutoScroll = true;
            this.ImageHolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(225)))), ((int)(((byte)(243)))));
            this.ImageHolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ImageHolder.Location = new System.Drawing.Point(5, 26);
            this.ImageHolder.Name = "ImageHolder";
            this.ImageHolder.Size = new System.Drawing.Size(254, 117);
            this.ImageHolder.TabIndex = 6;
            this.ImageHolder.XSnap = 0;
            this.ImageHolder.YSnap = 0;
            // 
            // ImagesLabel
            // 
            this.ImagesLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ImagesLabel.Font = new System.Drawing.Font("Verdana", 10.5F);
            this.ImagesLabel.ForeColor = System.Drawing.Color.MidnightBlue;
            this.ImagesLabel.Location = new System.Drawing.Point(0, 0);
            this.ImagesLabel.Name = "ImagesLabel";
            this.ImagesLabel.Size = new System.Drawing.Size(262, 23);
            this.ImagesLabel.TabIndex = 5;
            this.ImagesLabel.Text = "Spriteset Images";
            this.ImagesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BasePanel
            // 
            this.BasePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BasePanel.Controls.Add(this.BaseEditorLabel);
            this.BasePanel.Controls.Add(this.FrameBaseEditor);
            this.BasePanel.Location = new System.Drawing.Point(6, 159);
            this.BasePanel.Margin = new System.Windows.Forms.Padding(6);
            this.BasePanel.Name = "BasePanel";
            this.BasePanel.Size = new System.Drawing.Size(264, 149);
            this.BasePanel.TabIndex = 6;
            // 
            // BaseEditorLabel
            // 
            this.BaseEditorLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.BaseEditorLabel.Font = new System.Drawing.Font("Verdana", 10.5F);
            this.BaseEditorLabel.ForeColor = System.Drawing.Color.MidnightBlue;
            this.BaseEditorLabel.Location = new System.Drawing.Point(0, 0);
            this.BaseEditorLabel.Name = "BaseEditorLabel";
            this.BaseEditorLabel.Size = new System.Drawing.Size(262, 23);
            this.BaseEditorLabel.TabIndex = 5;
            this.BaseEditorLabel.Text = "Frame Base Editor";
            this.BaseEditorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrameBaseEditor
            // 
            this.FrameBaseEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.FrameBaseEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.FrameBaseEditor.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("FrameBaseEditor.BackgroundImage")));
            this.FrameBaseEditor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.FrameBaseEditor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FrameBaseEditor.Location = new System.Drawing.Point(3, 26);
            this.FrameBaseEditor.Name = "FrameBaseEditor";
            this.FrameBaseEditor.Size = new System.Drawing.Size(256, 118);
            this.FrameBaseEditor.TabIndex = 4;
            this.FrameBaseEditor.Modified += new System.EventHandler(this.Modified);
            // 
            // AnimPanel
            // 
            this.AnimPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AnimPanel.Controls.Add(this.AnimLabel);
            this.AnimPanel.Controls.Add(this.DirectionAnim);
            this.AnimPanel.Location = new System.Drawing.Point(6, 313);
            this.AnimPanel.Margin = new System.Windows.Forms.Padding(6);
            this.AnimPanel.Name = "AnimPanel";
            this.AnimPanel.Size = new System.Drawing.Size(264, 168);
            this.AnimPanel.TabIndex = 5;
            // 
            // AnimLabel
            // 
            this.AnimLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.AnimLabel.Font = new System.Drawing.Font("Verdana", 10.5F);
            this.AnimLabel.ForeColor = System.Drawing.Color.MidnightBlue;
            this.AnimLabel.Location = new System.Drawing.Point(0, 0);
            this.AnimLabel.Name = "AnimLabel";
            this.AnimLabel.Size = new System.Drawing.Size(262, 23);
            this.AnimLabel.TabIndex = 4;
            this.AnimLabel.Text = "Direction Animation";
            this.AnimLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DirectionAnim
            // 
            this.DirectionAnim.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.DirectionAnim.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.DirectionAnim.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(225)))), ((int)(((byte)(243)))));
            this.DirectionAnim.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DirectionAnim.Direction = null;
            this.DirectionAnim.Location = new System.Drawing.Point(5, 26);
            this.DirectionAnim.Name = "DirectionAnim";
            this.DirectionAnim.Size = new System.Drawing.Size(254, 137);
            this.DirectionAnim.Sprite = null;
            this.DirectionAnim.TabIndex = 3;
            // 
            // SpritesetEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DirectionSplitter);
            this.Name = "SpritesetEditor";
            this.Size = new System.Drawing.Size(808, 487);
            this.DirectionHolder.ResumeLayout(false);
            this.DirectionSplitter.Panel1.ResumeLayout(false);
            this.DirectionSplitter.Panel2.ResumeLayout(false);
            this.DirectionSplitter.ResumeLayout(false);
            this.ImagePanel.ResumeLayout(false);
            this.BasePanel.ResumeLayout(false);
            this.AnimPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private EditorPanel DirectionHolder;
        private System.Windows.Forms.SplitContainer DirectionSplitter;
        private SpritesetComponents.DirectionAnimator DirectionAnim;
        private SpritesetComponents.BaseEditor FrameBaseEditor;
        private System.Windows.Forms.Panel BasePanel;
        private EditorLabel BaseEditorLabel;
        private System.Windows.Forms.Panel AnimPanel;
        private EditorLabel AnimLabel;
        private System.Windows.Forms.Panel ImagePanel;
        private EditorLabel ImagesLabel;
        private EditorPanel ImageHolder;
        private Drawer2 SpriteDrawer;
    }
}
