namespace Sphere_Editor.SpritesetComponents
{
    partial class BaseEditor
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
            this.FrameImage = new Sphere_Editor.EditorPanel();
            this.BaseStatusStrip = new System.Windows.Forms.StatusStrip();
            this.XYLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.WHLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.DirectionLabel = new Sphere_Editor.EditorLabel();
            this.BasePanel = new System.Windows.Forms.Panel();
            this.BaseStatusStrip.SuspendLayout();
            this.BasePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // FrameImage
            // 
            this.FrameImage.BackgroundImage = global::Sphere_Editor.Properties.Resources.editbg2;
            this.FrameImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FrameImage.Location = new System.Drawing.Point(64, 30);
            this.FrameImage.Name = "FrameImage";
            this.FrameImage.Size = new System.Drawing.Size(96, 96);
            this.FrameImage.TabIndex = 0;
            this.FrameImage.XSnap = 0;
            this.FrameImage.YSnap = 0;
            this.FrameImage.Paint += new System.Windows.Forms.PaintEventHandler(this.FrameImage_Paint);
            this.FrameImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrameImage_MouseDown);
            this.FrameImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FrameImage_MouseMove);
            this.FrameImage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FrameImage_MouseUp);
            // 
            // BaseStatusStrip
            // 
            this.BaseStatusStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.BaseStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.XYLabel,
            this.WHLabel});
            this.BaseStatusStrip.Location = new System.Drawing.Point(0, 179);
            this.BaseStatusStrip.Name = "BaseStatusStrip";
            this.BaseStatusStrip.Size = new System.Drawing.Size(224, 24);
            this.BaseStatusStrip.SizingGrip = false;
            this.BaseStatusStrip.TabIndex = 2;
            this.BaseStatusStrip.Text = "Base Status";
            // 
            // XYLabel
            // 
            this.XYLabel.BackColor = System.Drawing.Color.Transparent;
            this.XYLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.XYLabel.Name = "XYLabel";
            this.XYLabel.Size = new System.Drawing.Size(71, 19);
            this.XYLabel.Text = "X, Y = (0, 0)";
            // 
            // WHLabel
            // 
            this.WHLabel.BackColor = System.Drawing.Color.Transparent;
            this.WHLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.WHLabel.Name = "WHLabel";
            this.WHLabel.Size = new System.Drawing.Size(77, 19);
            this.WHLabel.Text = "W, H = (0, 0)";
            // 
            // DirectionLabel
            // 
            this.DirectionLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.DirectionLabel.Font = new System.Drawing.Font("Verdana", 10.5F);
            this.DirectionLabel.ForeColor = System.Drawing.Color.MidnightBlue;
            this.DirectionLabel.Location = new System.Drawing.Point(0, 0);
            this.DirectionLabel.Name = "DirectionLabel";
            this.DirectionLabel.Size = new System.Drawing.Size(224, 23);
            this.DirectionLabel.TabIndex = 3;
            this.DirectionLabel.Text = "Direction: north";
            this.DirectionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BasePanel
            // 
            this.BasePanel.Controls.Add(this.FrameImage);
            this.BasePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BasePanel.Location = new System.Drawing.Point(0, 23);
            this.BasePanel.Name = "BasePanel";
            this.BasePanel.Size = new System.Drawing.Size(224, 156);
            this.BasePanel.TabIndex = 4;
            // 
            // BaseEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.BasePanel);
            this.Controls.Add(this.DirectionLabel);
            this.Controls.Add(this.BaseStatusStrip);
            this.DoubleBuffered = true;
            this.Name = "BaseEditor";
            this.Size = new System.Drawing.Size(224, 203);
            this.Resize += new System.EventHandler(this.BaseEditor_Resize);
            this.BaseStatusStrip.ResumeLayout(false);
            this.BaseStatusStrip.PerformLayout();
            this.BasePanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EditorPanel FrameImage;
        private System.Windows.Forms.StatusStrip BaseStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel XYLabel;
        private System.Windows.Forms.ToolStripStatusLabel WHLabel;
        private EditorLabel DirectionLabel;
        private System.Windows.Forms.Panel BasePanel;
    }
}
