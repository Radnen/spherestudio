namespace SphereStudio.Forms
{
    partial class ProjectPropsForm
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
            this.ButtonPanel = new System.Windows.Forms.Panel();
            this.buildDirBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.editorLabel1 = new Sphere.Core.Editor.EditorLabel();
            this.ButtonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // PathLabel
            // 
            this.PathLabel.AutoSize = true;
            this.PathLabel.Location = new System.Drawing.Point(41, 41);
            this.PathLabel.Name = "PathLabel";
            this.PathLabel.Size = new System.Drawing.Size(30, 13);
            this.PathLabel.TabIndex = 16;
            this.PathLabel.Text = "Path";
            // 
            // GameTitleLabel
            // 
            this.GameTitleLabel.AutoSize = true;
            this.GameTitleLabel.Location = new System.Drawing.Point(12, 66);
            this.GameTitleLabel.Name = "GameTitleLabel";
            this.GameTitleLabel.Size = new System.Drawing.Size(60, 13);
            this.GameTitleLabel.TabIndex = 1;
            this.GameTitleLabel.Text = "Game Title";
            // 
            // AuthorLabel
            // 
            this.AuthorLabel.AutoSize = true;
            this.AuthorLabel.Location = new System.Drawing.Point(29, 92);
            this.AuthorLabel.Name = "AuthorLabel";
            this.AuthorLabel.Size = new System.Drawing.Size(43, 13);
            this.AuthorLabel.TabIndex = 3;
            this.AuthorLabel.Text = "Author";
            // 
            // PathTextBox
            // 
            this.PathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PathTextBox.Location = new System.Drawing.Point(78, 38);
            this.PathTextBox.Name = "PathTextBox";
            this.PathTextBox.ReadOnly = true;
            this.PathTextBox.Size = new System.Drawing.Size(265, 22);
            this.PathTextBox.TabIndex = 17;
            // 
            // nameBox
            // 
            this.nameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameBox.Location = new System.Drawing.Point(78, 63);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(265, 22);
            this.nameBox.TabIndex = 2;
            // 
            // authorBox
            // 
            this.authorBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.authorBox.Location = new System.Drawing.Point(78, 89);
            this.authorBox.Name = "authorBox";
            this.authorBox.Size = new System.Drawing.Size(265, 22);
            this.authorBox.TabIndex = 4;
            // 
            // DescLabel
            // 
            this.DescLabel.AutoSize = true;
            this.DescLabel.Location = new System.Drawing.Point(9, 116);
            this.DescLabel.Name = "DescLabel";
            this.DescLabel.Size = new System.Drawing.Size(66, 13);
            this.DescLabel.TabIndex = 5;
            this.DescLabel.Text = "Description";
            // 
            // descriptionBox
            // 
            this.descriptionBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.descriptionBox.Location = new System.Drawing.Point(12, 132);
            this.descriptionBox.Multiline = true;
            this.descriptionBox.Name = "descriptionBox";
            this.descriptionBox.Size = new System.Drawing.Size(331, 144);
            this.descriptionBox.TabIndex = 6;
            // 
            // ScriptLabel
            // 
            this.ScriptLabel.AutoSize = true;
            this.ScriptLabel.Location = new System.Drawing.Point(18, 285);
            this.ScriptLabel.Name = "ScriptLabel";
            this.ScriptLabel.Size = new System.Drawing.Size(77, 13);
            this.ScriptLabel.TabIndex = 7;
            this.ScriptLabel.Text = "Startup Script";
            // 
            // ScreenSizeLabel
            // 
            this.ScreenSizeLabel.AutoSize = true;
            this.ScreenSizeLabel.Location = new System.Drawing.Point(31, 312);
            this.ScreenSizeLabel.Name = "ScreenSizeLabel";
            this.ScreenSizeLabel.Size = new System.Drawing.Size(64, 13);
            this.ScreenSizeLabel.TabIndex = 9;
            this.ScreenSizeLabel.Text = "Screen Size";
            // 
            // mainScriptBox
            // 
            this.mainScriptBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainScriptBox.FormattingEnabled = true;
            this.mainScriptBox.Location = new System.Drawing.Point(101, 282);
            this.mainScriptBox.Name = "mainScriptBox";
            this.mainScriptBox.Size = new System.Drawing.Size(242, 21);
            this.mainScriptBox.TabIndex = 8;
            // 
            // XLabel
            // 
            this.XLabel.AutoSize = true;
            this.XLabel.Location = new System.Drawing.Point(196, 312);
            this.XLabel.Name = "XLabel";
            this.XLabel.Size = new System.Drawing.Size(12, 13);
            this.XLabel.TabIndex = 11;
            this.XLabel.Text = "x";
            // 
            // widthBox
            // 
            this.widthBox.Location = new System.Drawing.Point(101, 309);
            this.widthBox.MaxLength = 4;
            this.widthBox.Name = "widthBox";
            this.widthBox.Size = new System.Drawing.Size(89, 22);
            this.widthBox.TabIndex = 10;
            this.widthBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.resolutionBox_KeyPress);
            // 
            // heightBox
            // 
            this.heightBox.Location = new System.Drawing.Point(214, 309);
            this.heightBox.MaxLength = 4;
            this.heightBox.Name = "heightBox";
            this.heightBox.Size = new System.Drawing.Size(90, 22);
            this.heightBox.TabIndex = 12;
            this.heightBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.resolutionBox_KeyPress);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(187, 3);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "Save";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(268, 3);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // ButtonPanel
            // 
            this.ButtonPanel.Controls.Add(this.buttonOK);
            this.ButtonPanel.Controls.Add(this.buttonCancel);
            this.ButtonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonPanel.Location = new System.Drawing.Point(0, 376);
            this.ButtonPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ButtonPanel.Name = "ButtonPanel";
            this.ButtonPanel.Size = new System.Drawing.Size(353, 30);
            this.ButtonPanel.TabIndex = 15;
            // 
            // buildDirBox
            // 
            this.buildDirBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buildDirBox.Location = new System.Drawing.Point(101, 336);
            this.buildDirBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buildDirBox.Name = "buildDirBox";
            this.buildDirBox.Size = new System.Drawing.Size(242, 22);
            this.buildDirBox.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 339);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Build Directory";
            // 
            // editorLabel1
            // 
            this.editorLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.editorLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.editorLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.editorLabel1.ForeColor = System.Drawing.Color.White;
            this.editorLabel1.Location = new System.Drawing.Point(0, 0);
            this.editorLabel1.Name = "editorLabel1";
            this.editorLabel1.Size = new System.Drawing.Size(353, 23);
            this.editorLabel1.TabIndex = 0;
            this.editorLabel1.Text = "Configure your Sphere Studio game project";
            this.editorLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ProjectPropForm
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(353, 406);
            this.Controls.Add(this.editorLabel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buildDirBox);
            this.Controls.Add(this.ButtonPanel);
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
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProjectPropForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Project Properties";
            this.Load += new System.EventHandler(this.GameSettings_Load);
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
        private System.Windows.Forms.Panel ButtonPanel;
        private System.Windows.Forms.TextBox buildDirBox;
        private System.Windows.Forms.Label label1;
        private Sphere.Core.Editor.EditorLabel editorLabel1;
    }
}