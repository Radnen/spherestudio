namespace SphereStudio.Forms
{
    partial class GameSettings
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
            this.PathLabel = new System.Windows.Forms.Label();
            this.GameTitleLabel = new System.Windows.Forms.Label();
            this.AuthorLabel = new System.Windows.Forms.Label();
            this.PathTextBox = new System.Windows.Forms.TextBox();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.authorBox = new System.Windows.Forms.TextBox();
            this.DescLabel = new System.Windows.Forms.Label();
            this.descriptionBox = new System.Windows.Forms.TextBox();
            this.ScriptLabel = new System.Windows.Forms.Label();
            this.ScreenSizeLabel = new System.Windows.Forms.Label();
            this.mainScriptBox = new System.Windows.Forms.ComboBox();
            this.XLabel = new System.Windows.Forms.Label();
            this.widthBox = new System.Windows.Forms.TextBox();
            this.heightBox = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.NewProjectPic = new System.Windows.Forms.PictureBox();
            this.ButtonPanel = new System.Windows.Forms.Panel();
            this.buildDirBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NewProjectPic)).BeginInit();
            this.ButtonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // PathLabel
            // 
            this.PathLabel.AutoSize = true;
            this.PathLabel.Location = new System.Drawing.Point(13, 50);
            this.PathLabel.Name = "PathLabel";
            this.PathLabel.Size = new System.Drawing.Size(33, 16);
            this.PathLabel.TabIndex = 0;
            this.PathLabel.Text = "Path";
            // 
            // GameTitleLabel
            // 
            this.GameTitleLabel.AutoSize = true;
            this.GameTitleLabel.Location = new System.Drawing.Point(13, 81);
            this.GameTitleLabel.Name = "GameTitleLabel";
            this.GameTitleLabel.Size = new System.Drawing.Size(70, 16);
            this.GameTitleLabel.TabIndex = 2;
            this.GameTitleLabel.Text = "Game Title";
            // 
            // AuthorLabel
            // 
            this.AuthorLabel.AutoSize = true;
            this.AuthorLabel.Location = new System.Drawing.Point(14, 112);
            this.AuthorLabel.Name = "AuthorLabel";
            this.AuthorLabel.Size = new System.Drawing.Size(46, 16);
            this.AuthorLabel.TabIndex = 4;
            this.AuthorLabel.Text = "Author";
            // 
            // PathTextBox
            // 
            this.PathTextBox.Enabled = false;
            this.PathTextBox.Location = new System.Drawing.Point(112, 47);
            this.PathTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PathTextBox.Name = "PathTextBox";
            this.PathTextBox.Size = new System.Drawing.Size(236, 23);
            this.PathTextBox.TabIndex = 1;
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(112, 78);
            this.nameBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(236, 23);
            this.nameBox.TabIndex = 3;
            // 
            // authorBox
            // 
            this.authorBox.Location = new System.Drawing.Point(112, 109);
            this.authorBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.authorBox.Name = "authorBox";
            this.authorBox.Size = new System.Drawing.Size(236, 23);
            this.authorBox.TabIndex = 5;
            // 
            // DescLabel
            // 
            this.DescLabel.AutoSize = true;
            this.DescLabel.Location = new System.Drawing.Point(12, 143);
            this.DescLabel.Name = "DescLabel";
            this.DescLabel.Size = new System.Drawing.Size(71, 16);
            this.DescLabel.TabIndex = 6;
            this.DescLabel.Text = "Description";
            // 
            // descriptionBox
            // 
            this.descriptionBox.Location = new System.Drawing.Point(12, 163);
            this.descriptionBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.descriptionBox.Multiline = true;
            this.descriptionBox.Name = "descriptionBox";
            this.descriptionBox.Size = new System.Drawing.Size(336, 176);
            this.descriptionBox.TabIndex = 7;
            // 
            // ScriptLabel
            // 
            this.ScriptLabel.AutoSize = true;
            this.ScriptLabel.Location = new System.Drawing.Point(12, 350);
            this.ScriptLabel.Name = "ScriptLabel";
            this.ScriptLabel.Size = new System.Drawing.Size(73, 16);
            this.ScriptLabel.TabIndex = 8;
            this.ScriptLabel.Text = "Start Script";
            // 
            // ScreenSizeLabel
            // 
            this.ScreenSizeLabel.AutoSize = true;
            this.ScreenSizeLabel.Location = new System.Drawing.Point(12, 382);
            this.ScreenSizeLabel.Name = "ScreenSizeLabel";
            this.ScreenSizeLabel.Size = new System.Drawing.Size(76, 16);
            this.ScreenSizeLabel.TabIndex = 10;
            this.ScreenSizeLabel.Text = "Screen Size";
            // 
            // mainScriptBox
            // 
            this.mainScriptBox.FormattingEnabled = true;
            this.mainScriptBox.Location = new System.Drawing.Point(112, 347);
            this.mainScriptBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.mainScriptBox.Name = "mainScriptBox";
            this.mainScriptBox.Size = new System.Drawing.Size(236, 24);
            this.mainScriptBox.TabIndex = 9;
            // 
            // XLabel
            // 
            this.XLabel.AutoSize = true;
            this.XLabel.Location = new System.Drawing.Point(224, 382);
            this.XLabel.Name = "XLabel";
            this.XLabel.Size = new System.Drawing.Size(14, 16);
            this.XLabel.TabIndex = 12;
            this.XLabel.Text = "x";
            // 
            // widthBox
            // 
            this.widthBox.Location = new System.Drawing.Point(112, 379);
            this.widthBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.widthBox.MaxLength = 4;
            this.widthBox.Name = "widthBox";
            this.widthBox.Size = new System.Drawing.Size(103, 23);
            this.widthBox.TabIndex = 11;
            this.widthBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.resolutionBox_KeyPress);
            // 
            // heightBox
            // 
            this.heightBox.Location = new System.Drawing.Point(244, 379);
            this.heightBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.heightBox.MaxLength = 4;
            this.heightBox.Name = "heightBox";
            this.heightBox.Size = new System.Drawing.Size(104, 23);
            this.heightBox.TabIndex = 13;
            this.heightBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.resolutionBox_KeyPress);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(94, 5);
            this.buttonOK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(87, 28);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "Save";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(187, 5);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(87, 28);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // NewProjectPic
            // 
            this.NewProjectPic.Dock = System.Windows.Forms.DockStyle.Top;
            this.NewProjectPic.Image = global::SphereStudio.Properties.Resources.SetGame;
            this.NewProjectPic.InitialImage = global::SphereStudio.Properties.Resources.NewGame;
            this.NewProjectPic.Location = new System.Drawing.Point(0, 0);
            this.NewProjectPic.Name = "NewProjectPic";
            this.NewProjectPic.Size = new System.Drawing.Size(360, 40);
            this.NewProjectPic.TabIndex = 16;
            this.NewProjectPic.TabStop = false;
            // 
            // ButtonPanel
            // 
            this.ButtonPanel.Controls.Add(this.buttonOK);
            this.ButtonPanel.Controls.Add(this.buttonCancel);
            this.ButtonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonPanel.Location = new System.Drawing.Point(0, 463);
            this.ButtonPanel.Name = "ButtonPanel";
            this.ButtonPanel.Size = new System.Drawing.Size(360, 37);
            this.ButtonPanel.TabIndex = 14;
            // 
            // buildDirBox
            // 
            this.buildDirBox.Location = new System.Drawing.Point(112, 413);
            this.buildDirBox.Name = "buildDirBox";
            this.buildDirBox.Size = new System.Drawing.Size(236, 23);
            this.buildDirBox.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 416);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 16);
            this.label1.TabIndex = 18;
            this.label1.Text = "Build Directory";
            // 
            // GameSettings
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(360, 500);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buildDirBox);
            this.Controls.Add(this.ButtonPanel);
            this.Controls.Add(this.NewProjectPic);
            this.Controls.Add(this.heightBox);
            this.Controls.Add(this.widthBox);
            this.Controls.Add(this.XLabel);
            this.Controls.Add(this.mainScriptBox);
            this.Controls.Add(this.ScreenSizeLabel);
            this.Controls.Add(this.ScriptLabel);
            this.Controls.Add(this.descriptionBox);
            this.Controls.Add(this.DescLabel);
            this.Controls.Add(this.authorBox);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.PathTextBox);
            this.Controls.Add(this.AuthorLabel);
            this.Controls.Add(this.GameTitleLabel);
            this.Controls.Add(this.PathLabel);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Game Settings";
            this.Load += new System.EventHandler(this.GameSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NewProjectPic)).EndInit();
            this.ButtonPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label PathLabel;
        private System.Windows.Forms.Label GameTitleLabel;
        private System.Windows.Forms.Label AuthorLabel;
        private System.Windows.Forms.TextBox PathTextBox;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.TextBox authorBox;
        private System.Windows.Forms.Label DescLabel;
        private System.Windows.Forms.TextBox descriptionBox;
        private System.Windows.Forms.Label ScriptLabel;
        private System.Windows.Forms.Label ScreenSizeLabel;
        private System.Windows.Forms.ComboBox mainScriptBox;
        private System.Windows.Forms.Label XLabel;
        private System.Windows.Forms.TextBox widthBox;
        private System.Windows.Forms.TextBox heightBox;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.PictureBox NewProjectPic;
        private System.Windows.Forms.Panel ButtonPanel;
        private System.Windows.Forms.TextBox buildDirBox;
        private System.Windows.Forms.Label label1;
    }
}