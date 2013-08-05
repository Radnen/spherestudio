namespace Sphere_Editor.EditorComponents
{
    partial class AutosetEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutosetEditor));
            this.CenterButton = new System.Windows.Forms.Button();
            this.CornerButton = new System.Windows.Forms.Button();
            this.UseButton = new System.Windows.Forms.Button();
            this.ResetButton = new System.Windows.Forms.Button();
            this.AutosetTip = new System.Windows.Forms.ToolTip(this.components);
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.LayerLabel = new System.Windows.Forms.Label();
            this.AsStampButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.AutotileBox = new System.Windows.Forms.Panel();
            this.ExtraBox = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.ActionBox = new System.Windows.Forms.Panel();
            this.xlabel = new System.Windows.Forms.Label();
            this.SizeLabel = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.editorLabel2 = new Sphere_Editor.EditorLabel();
            this.CenterPieces = new Sphere_Editor.EditorPanel();
            this.CornerPieces = new Sphere_Editor.EditorPanel();
            this.ActionLabel = new Sphere_Editor.EditorLabel();
            this.ExtraLabel = new Sphere_Editor.EditorLabel();
            this.editorPanel1 = new Sphere_Editor.EditorPanel();
            this.editorPanel2 = new Sphere_Editor.EditorPanel();
            this.editorLabel1 = new Sphere_Editor.EditorLabel();
            this.AutotileBox.SuspendLayout();
            this.ExtraBox.SuspendLayout();
            this.ActionBox.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CenterButton
            // 
            this.CenterButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.CenterButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.CenterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CenterButton.Location = new System.Drawing.Point(3, 128);
            this.CenterButton.Name = "CenterButton";
            this.CenterButton.Size = new System.Drawing.Size(96, 23);
            this.CenterButton.TabIndex = 3;
            this.CenterButton.Text = "Add Center Tiles";
            this.CenterButton.UseVisualStyleBackColor = true;
            this.CenterButton.Click += new System.EventHandler(this.CenterButton_Click);
            // 
            // CornerButton
            // 
            this.CornerButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.CornerButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.CornerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CornerButton.Location = new System.Drawing.Point(106, 128);
            this.CornerButton.Name = "CornerButton";
            this.CornerButton.Size = new System.Drawing.Size(96, 23);
            this.CornerButton.TabIndex = 4;
            this.CornerButton.Text = "Add Corner Tiles";
            this.CornerButton.UseVisualStyleBackColor = true;
            this.CornerButton.Click += new System.EventHandler(this.CornerButton_Click);
            // 
            // UseButton
            // 
            this.UseButton.Enabled = false;
            this.UseButton.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.UseButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.UseButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.UseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UseButton.Location = new System.Drawing.Point(3, 26);
            this.UseButton.Name = "UseButton";
            this.UseButton.Size = new System.Drawing.Size(110, 23);
            this.UseButton.TabIndex = 5;
            this.UseButton.Text = "Use As Auto Tiles";
            this.UseButton.UseVisualStyleBackColor = true;
            this.UseButton.Click += new System.EventHandler(this.UseButton_Click);
            // 
            // ResetButton
            // 
            this.ResetButton.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.ResetButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ResetButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ResetButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ResetButton.Location = new System.Drawing.Point(3, 84);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(110, 23);
            this.ResetButton.TabIndex = 6;
            this.ResetButton.Text = "Reset All Tiles";
            this.ResetButton.UseVisualStyleBackColor = false;
            this.ResetButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(48, 28);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(156, 21);
            this.comboBox1.TabIndex = 8;
            // 
            // LayerLabel
            // 
            this.LayerLabel.AutoSize = true;
            this.LayerLabel.Location = new System.Drawing.Point(6, 31);
            this.LayerLabel.Name = "LayerLabel";
            this.LayerLabel.Size = new System.Drawing.Size(36, 13);
            this.LayerLabel.TabIndex = 9;
            this.LayerLabel.Text = "Layer:";
            // 
            // AsStampButton
            // 
            this.AsStampButton.Enabled = false;
            this.AsStampButton.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.AsStampButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.AsStampButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.AsStampButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AsStampButton.Location = new System.Drawing.Point(3, 55);
            this.AsStampButton.Name = "AsStampButton";
            this.AsStampButton.Size = new System.Drawing.Size(110, 23);
            this.AsStampButton.TabIndex = 10;
            this.AsStampButton.Text = "Use Tiles As Stamp";
            this.AsStampButton.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(111, 128);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Add Center Tiles";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // AutotileBox
            // 
            this.AutotileBox.AutoSize = true;
            this.AutotileBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AutotileBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AutotileBox.Controls.Add(this.editorLabel2);
            this.AutotileBox.Controls.Add(this.CenterPieces);
            this.AutotileBox.Controls.Add(this.CenterButton);
            this.AutotileBox.Controls.Add(this.CornerPieces);
            this.AutotileBox.Controls.Add(this.CornerButton);
            this.AutotileBox.Location = new System.Drawing.Point(6, 6);
            this.AutotileBox.Margin = new System.Windows.Forms.Padding(6);
            this.AutotileBox.Name = "AutotileBox";
            this.AutotileBox.Size = new System.Drawing.Size(207, 156);
            this.AutotileBox.TabIndex = 12;
            // 
            // ExtraBox
            // 
            this.ExtraBox.AutoSize = true;
            this.ExtraBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ExtraBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ExtraBox.Controls.Add(this.LayerLabel);
            this.ExtraBox.Controls.Add(this.comboBox1);
            this.ExtraBox.Controls.Add(this.button2);
            this.ExtraBox.Controls.Add(this.ExtraLabel);
            this.ExtraBox.Controls.Add(this.editorPanel1);
            this.ExtraBox.Controls.Add(this.editorPanel2);
            this.ExtraBox.Controls.Add(this.button1);
            this.ExtraBox.Location = new System.Drawing.Point(6, 174);
            this.ExtraBox.Margin = new System.Windows.Forms.Padding(6);
            this.ExtraBox.Name = "ExtraBox";
            this.ExtraBox.Size = new System.Drawing.Size(215, 156);
            this.ExtraBox.TabIndex = 13;
            this.ExtraBox.Visible = false;
            // 
            // button2
            // 
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(111, 99);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Add Corner";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // ActionBox
            // 
            this.ActionBox.AutoSize = true;
            this.ActionBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ActionBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ActionBox.Controls.Add(this.xlabel);
            this.ActionBox.Controls.Add(this.SizeLabel);
            this.ActionBox.Controls.Add(this.textBox2);
            this.ActionBox.Controls.Add(this.textBox1);
            this.ActionBox.Controls.Add(this.ActionLabel);
            this.ActionBox.Controls.Add(this.UseButton);
            this.ActionBox.Controls.Add(this.ResetButton);
            this.ActionBox.Controls.Add(this.AsStampButton);
            this.ActionBox.Location = new System.Drawing.Point(225, 6);
            this.ActionBox.Margin = new System.Windows.Forms.Padding(6);
            this.ActionBox.Name = "ActionBox";
            this.ActionBox.Size = new System.Drawing.Size(118, 155);
            this.ActionBox.TabIndex = 14;
            // 
            // xlabel
            // 
            this.xlabel.AutoSize = true;
            this.xlabel.Location = new System.Drawing.Point(53, 133);
            this.xlabel.Name = "xlabel";
            this.xlabel.Size = new System.Drawing.Size(12, 13);
            this.xlabel.TabIndex = 18;
            this.xlabel.Text = "x";
            this.xlabel.Visible = false;
            // 
            // SizeLabel
            // 
            this.SizeLabel.AutoSize = true;
            this.SizeLabel.Location = new System.Drawing.Point(3, 114);
            this.SizeLabel.Name = "SizeLabel";
            this.SizeLabel.Size = new System.Drawing.Size(63, 13);
            this.SizeLabel.TabIndex = 17;
            this.SizeLabel.Text = "Stamp Size:";
            this.SizeLabel.Visible = false;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(69, 130);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(44, 20);
            this.textBox2.TabIndex = 16;
            this.textBox2.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 130);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(44, 20);
            this.textBox1.TabIndex = 15;
            this.textBox1.Visible = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.AutotileBox);
            this.flowLayoutPanel1.Controls.Add(this.ActionBox);
            this.flowLayoutPanel1.Controls.Add(this.ExtraBox);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 23);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(363, 337);
            this.flowLayoutPanel1.TabIndex = 15;
            // 
            // editorLabel2
            // 
            this.editorLabel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.editorLabel2.Font = new System.Drawing.Font("Verdana", 10.5F);
            this.editorLabel2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.editorLabel2.Location = new System.Drawing.Point(0, 0);
            this.editorLabel2.Name = "editorLabel2";
            this.editorLabel2.Size = new System.Drawing.Size(205, 23);
            this.editorLabel2.TabIndex = 0;
            this.editorLabel2.Text = "Auto Tiles";
            this.editorLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CenterPieces
            // 
            this.CenterPieces.BackColor = System.Drawing.Color.White;
            this.CenterPieces.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CenterPieces.BackgroundImage")));
            this.CenterPieces.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CenterPieces.Location = new System.Drawing.Point(3, 26);
            this.CenterPieces.Name = "CenterPieces";
            this.CenterPieces.Size = new System.Drawing.Size(96, 96);
            this.CenterPieces.TabIndex = 0;
            this.AutosetTip.SetToolTip(this.CenterPieces, "Double click to clear tiles.");
            this.CenterPieces.XSnap = 0;
            this.CenterPieces.YSnap = 0;
            this.CenterPieces.Paint += new System.Windows.Forms.PaintEventHandler(this.CenterPieces_Paint);
            this.CenterPieces.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.CenterPieces_MouseDoubleClick);
            // 
            // CornerPieces
            // 
            this.CornerPieces.BackColor = System.Drawing.Color.White;
            this.CornerPieces.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CornerPieces.BackgroundImage")));
            this.CornerPieces.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CornerPieces.Location = new System.Drawing.Point(121, 47);
            this.CornerPieces.Name = "CornerPieces";
            this.CornerPieces.Size = new System.Drawing.Size(64, 64);
            this.CornerPieces.TabIndex = 1;
            this.AutosetTip.SetToolTip(this.CornerPieces, "Double click to clear tiles.");
            this.CornerPieces.XSnap = 0;
            this.CornerPieces.YSnap = 0;
            this.CornerPieces.Paint += new System.Windows.Forms.PaintEventHandler(this.CornerPieces_Paint);
            this.CornerPieces.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.CornerPieces_MouseDoubleClick);
            // 
            // ActionLabel
            // 
            this.ActionLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ActionLabel.Font = new System.Drawing.Font("Verdana", 10.5F);
            this.ActionLabel.ForeColor = System.Drawing.Color.MidnightBlue;
            this.ActionLabel.Location = new System.Drawing.Point(0, 0);
            this.ActionLabel.Name = "ActionLabel";
            this.ActionLabel.Size = new System.Drawing.Size(116, 23);
            this.ActionLabel.TabIndex = 2;
            this.ActionLabel.Text = "Actions";
            this.ActionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ExtraLabel
            // 
            this.ExtraLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ExtraLabel.Font = new System.Drawing.Font("Verdana", 10.5F);
            this.ExtraLabel.ForeColor = System.Drawing.Color.MidnightBlue;
            this.ExtraLabel.Location = new System.Drawing.Point(0, 0);
            this.ExtraLabel.Name = "ExtraLabel";
            this.ExtraLabel.Size = new System.Drawing.Size(213, 23);
            this.ExtraLabel.TabIndex = 1;
            this.ExtraLabel.Text = "Layered Tiles";
            this.ExtraLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // editorPanel1
            // 
            this.editorPanel1.BackColor = System.Drawing.Color.White;
            this.editorPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("editorPanel1.BackgroundImage")));
            this.editorPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editorPanel1.Location = new System.Drawing.Point(9, 55);
            this.editorPanel1.Name = "editorPanel1";
            this.editorPanel1.Size = new System.Drawing.Size(96, 96);
            this.editorPanel1.TabIndex = 1;
            this.AutosetTip.SetToolTip(this.editorPanel1, "Double click to clear tiles.");
            this.editorPanel1.XSnap = 0;
            this.editorPanel1.YSnap = 0;
            // 
            // editorPanel2
            // 
            this.editorPanel2.BackColor = System.Drawing.Color.White;
            this.editorPanel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("editorPanel2.BackgroundImage")));
            this.editorPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editorPanel2.Location = new System.Drawing.Point(142, 61);
            this.editorPanel2.Name = "editorPanel2";
            this.editorPanel2.Size = new System.Drawing.Size(32, 32);
            this.editorPanel2.TabIndex = 2;
            this.AutosetTip.SetToolTip(this.editorPanel2, "Double click to clear tiles.");
            this.editorPanel2.XSnap = 0;
            this.editorPanel2.YSnap = 0;
            // 
            // editorLabel1
            // 
            this.editorLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.editorLabel1.Font = new System.Drawing.Font("Verdana", 10.5F);
            this.editorLabel1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.editorLabel1.Location = new System.Drawing.Point(0, 0);
            this.editorLabel1.Name = "editorLabel1";
            this.editorLabel1.Size = new System.Drawing.Size(363, 23);
            this.editorLabel1.TabIndex = 1;
            this.editorLabel1.Text = "Autoset #1";
            this.editorLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AutosetEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(225)))), ((int)(((byte)(243)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.editorLabel1);
            this.Name = "AutosetEditor";
            this.Size = new System.Drawing.Size(363, 360);
            this.AutotileBox.ResumeLayout(false);
            this.ExtraBox.ResumeLayout(false);
            this.ExtraBox.PerformLayout();
            this.ActionBox.ResumeLayout(false);
            this.ActionBox.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private EditorPanel CenterPieces;
        private EditorLabel editorLabel1;
        private EditorPanel CornerPieces;
        private System.Windows.Forms.Button CenterButton;
        private System.Windows.Forms.Button CornerButton;
        private System.Windows.Forms.Button UseButton;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.ToolTip AutosetTip;
        private EditorPanel editorPanel1;
        private EditorPanel editorPanel2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label LayerLabel;
        private System.Windows.Forms.Button AsStampButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel AutotileBox;
        private EditorLabel editorLabel2;
        private System.Windows.Forms.Panel ExtraBox;
        private System.Windows.Forms.Button button2;
        private EditorLabel ExtraLabel;
        private System.Windows.Forms.Panel ActionBox;
        private EditorLabel ActionLabel;
        private System.Windows.Forms.Label xlabel;
        private System.Windows.Forms.Label SizeLabel;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
