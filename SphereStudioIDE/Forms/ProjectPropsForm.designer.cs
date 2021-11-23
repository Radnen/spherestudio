namespace SphereStudio.Ide.Forms
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
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.authorTextBox = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.resoDropDown = new System.Windows.Forms.ComboBox();
            this.heightTextBox = new System.Windows.Forms.TextBox();
            this.widthTextBox = new System.Windows.Forms.TextBox();
            this.ResoLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.summaryTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buildDirTextBox = new System.Windows.Forms.TextBox();
            this.typeDropDown = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.upgradeButton = new System.Windows.Forms.Button();
            this.footer = new System.Windows.Forms.Panel();
            this.projectPanel = new System.Windows.Forms.Panel();
            this.projectHeading = new System.Windows.Forms.Label();
            this.gamePanel = new System.Windows.Forms.Panel();
            this.gameHeader = new System.Windows.Forms.Label();
            this.header = new System.Windows.Forms.Label();
            this.footer.SuspendLayout();
            this.projectPanel.SuspendLayout();
            this.gamePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // PathLabel
            // 
            this.PathLabel.AutoSize = true;
            this.PathLabel.Location = new System.Drawing.Point(15, 35);
            this.PathLabel.Name = "PathLabel";
            this.PathLabel.Size = new System.Drawing.Size(55, 15);
            this.PathLabel.TabIndex = 1;
            this.PathLabel.Text = "Directory";
            // 
            // GameTitleLabel
            // 
            this.GameTitleLabel.AutoSize = true;
            this.GameTitleLabel.Location = new System.Drawing.Point(43, 35);
            this.GameTitleLabel.Name = "GameTitleLabel";
            this.GameTitleLabel.Size = new System.Drawing.Size(29, 15);
            this.GameTitleLabel.TabIndex = 1;
            this.GameTitleLabel.Text = "Title";
            // 
            // AuthorLabel
            // 
            this.AuthorLabel.AutoSize = true;
            this.AuthorLabel.Location = new System.Drawing.Point(28, 64);
            this.AuthorLabel.Name = "AuthorLabel";
            this.AuthorLabel.Size = new System.Drawing.Size(44, 15);
            this.AuthorLabel.TabIndex = 3;
            this.AuthorLabel.Text = "Author";
            // 
            // pathTextBox
            // 
            this.pathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pathTextBox.Location = new System.Drawing.Point(76, 32);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.ReadOnly = true;
            this.pathTextBox.Size = new System.Drawing.Size(303, 23);
            this.pathTextBox.TabIndex = 2;
            // 
            // titleTextBox
            // 
            this.titleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.titleTextBox.Location = new System.Drawing.Point(76, 32);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(303, 23);
            this.titleTextBox.TabIndex = 2;
            // 
            // authorTextBox
            // 
            this.authorTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.authorTextBox.Location = new System.Drawing.Point(76, 61);
            this.authorTextBox.Name = "authorTextBox";
            this.authorTextBox.Size = new System.Drawing.Size(303, 23);
            this.authorTextBox.TabIndex = 4;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point(235, 13);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(80, 25);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point(321, 13);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(80, 25);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // resoDropDown
            // 
            this.resoDropDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resoDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.resoDropDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resoDropDown.FormattingEnabled = true;
            this.resoDropDown.Items.AddRange(new object[] {
            "Custom Resolution",
            "320x240",
            "640x480",
            "800x600",
            "1024x768",
            "1280x720",
            "1920x1080"});
            this.resoDropDown.Location = new System.Drawing.Point(79, 184);
            this.resoDropDown.Name = "resoDropDown";
            this.resoDropDown.Size = new System.Drawing.Size(212, 23);
            this.resoDropDown.TabIndex = 8;
            this.resoDropDown.SelectedIndexChanged += new System.EventHandler(this.resoDropDown_SelectedIndexChanged);
            // 
            // heightTextBox
            // 
            this.heightTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.heightTextBox.Location = new System.Drawing.Point(341, 184);
            this.heightTextBox.Name = "heightTextBox";
            this.heightTextBox.Size = new System.Drawing.Size(38, 23);
            this.heightTextBox.TabIndex = 10;
            this.heightTextBox.Text = "240";
            this.heightTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.resoTextBox_KeyPress);
            // 
            // widthTextBox
            // 
            this.widthTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.widthTextBox.Location = new System.Drawing.Point(297, 184);
            this.widthTextBox.Name = "widthTextBox";
            this.widthTextBox.Size = new System.Drawing.Size(38, 23);
            this.widthTextBox.TabIndex = 9;
            this.widthTextBox.Text = "320";
            this.widthTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.resoTextBox_KeyPress);
            // 
            // ResoLabel
            // 
            this.ResoLabel.AutoSize = true;
            this.ResoLabel.Location = new System.Drawing.Point(7, 187);
            this.ResoLabel.Name = "ResoLabel";
            this.ResoLabel.Size = new System.Drawing.Size(63, 15);
            this.ResoLabel.TabIndex = 7;
            this.ResoLabel.Text = "Resolution";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Summary";
            // 
            // summaryTextBox
            // 
            this.summaryTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.summaryTextBox.Location = new System.Drawing.Point(76, 90);
            this.summaryTextBox.Multiline = true;
            this.summaryTextBox.Name = "summaryTextBox";
            this.summaryTextBox.Size = new System.Drawing.Size(303, 88);
            this.summaryTextBox.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Build In";
            // 
            // buildDirTextBox
            // 
            this.buildDirTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buildDirTextBox.Location = new System.Drawing.Point(76, 89);
            this.buildDirTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buildDirTextBox.Name = "buildDirTextBox";
            this.buildDirTextBox.Size = new System.Drawing.Size(303, 23);
            this.buildDirTextBox.TabIndex = 6;
            // 
            // typeDropDown
            // 
            this.typeDropDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.typeDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeDropDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.typeDropDown.FormattingEnabled = true;
            this.typeDropDown.Location = new System.Drawing.Point(76, 61);
            this.typeDropDown.Name = "typeDropDown";
            this.typeDropDown.Size = new System.Drawing.Size(303, 23);
            this.typeDropDown.TabIndex = 4;
            this.typeDropDown.SelectedIndexChanged += new System.EventHandler(this.typeDropDown_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Type";
            // 
            // upgradeButton
            // 
            this.upgradeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.upgradeButton.Location = new System.Drawing.Point(12, 13);
            this.upgradeButton.Name = "upgradeButton";
            this.upgradeButton.Size = new System.Drawing.Size(171, 25);
            this.upgradeButton.TabIndex = 2;
            this.upgradeButton.Text = "&Upgrade from Sphere 1.x...";
            this.upgradeButton.UseVisualStyleBackColor = true;
            this.upgradeButton.Visible = false;
            this.upgradeButton.Click += new System.EventHandler(this.upgradeButton_Click);
            // 
            // footer
            // 
            this.footer.Controls.Add(this.cancelButton);
            this.footer.Controls.Add(this.okButton);
            this.footer.Controls.Add(this.upgradeButton);
            this.footer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footer.Location = new System.Drawing.Point(0, 397);
            this.footer.Name = "footer";
            this.footer.Size = new System.Drawing.Size(413, 50);
            this.footer.TabIndex = 3;
            // 
            // projectPanel
            // 
            this.projectPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.projectPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.projectPanel.Controls.Add(this.projectHeading);
            this.projectPanel.Controls.Add(this.pathTextBox);
            this.projectPanel.Controls.Add(this.buildDirTextBox);
            this.projectPanel.Controls.Add(this.PathLabel);
            this.projectPanel.Controls.Add(this.label4);
            this.projectPanel.Controls.Add(this.label1);
            this.projectPanel.Controls.Add(this.typeDropDown);
            this.projectPanel.Location = new System.Drawing.Point(12, 38);
            this.projectPanel.Name = "projectPanel";
            this.projectPanel.Size = new System.Drawing.Size(389, 123);
            this.projectPanel.TabIndex = 1;
            // 
            // projectHeading
            // 
            this.projectHeading.Dock = System.Windows.Forms.DockStyle.Top;
            this.projectHeading.Location = new System.Drawing.Point(0, 0);
            this.projectHeading.Name = "projectHeading";
            this.projectHeading.Size = new System.Drawing.Size(387, 23);
            this.projectHeading.TabIndex = 0;
            this.projectHeading.Text = "Project Configuration";
            this.projectHeading.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gamePanel
            // 
            this.gamePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gamePanel.Controls.Add(this.gameHeader);
            this.gamePanel.Controls.Add(this.titleTextBox);
            this.gamePanel.Controls.Add(this.ResoLabel);
            this.gamePanel.Controls.Add(this.label3);
            this.gamePanel.Controls.Add(this.widthTextBox);
            this.gamePanel.Controls.Add(this.AuthorLabel);
            this.gamePanel.Controls.Add(this.summaryTextBox);
            this.gamePanel.Controls.Add(this.heightTextBox);
            this.gamePanel.Controls.Add(this.GameTitleLabel);
            this.gamePanel.Controls.Add(this.resoDropDown);
            this.gamePanel.Controls.Add(this.authorTextBox);
            this.gamePanel.Location = new System.Drawing.Point(12, 167);
            this.gamePanel.Name = "gamePanel";
            this.gamePanel.Size = new System.Drawing.Size(389, 218);
            this.gamePanel.TabIndex = 2;
            // 
            // gameHeader
            // 
            this.gameHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.gameHeader.Location = new System.Drawing.Point(0, 0);
            this.gameHeader.Name = "gameHeader";
            this.gameHeader.Size = new System.Drawing.Size(387, 23);
            this.gameHeader.TabIndex = 0;
            this.gameHeader.Text = "Game Information";
            this.gameHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // header
            // 
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.Location = new System.Drawing.Point(0, 0);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(413, 23);
            this.header.TabIndex = 0;
            this.header.Text = "configure your Sphere game project";
            this.header.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ProjectPropsForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(413, 447);
            this.Controls.Add(this.header);
            this.Controls.Add(this.gamePanel);
            this.Controls.Add(this.projectPanel);
            this.Controls.Add(this.footer);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProjectPropsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Project Properties";
            this.footer.ResumeLayout(false);
            this.projectPanel.ResumeLayout(false);
            this.projectPanel.PerformLayout();
            this.gamePanel.ResumeLayout(false);
            this.gamePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label PathLabel;
        private System.Windows.Forms.Label GameTitleLabel;
        private System.Windows.Forms.Label AuthorLabel;
        private System.Windows.Forms.TextBox pathTextBox;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.TextBox authorTextBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox summaryTextBox;
        private System.Windows.Forms.TextBox buildDirTextBox;
        private System.Windows.Forms.ComboBox typeDropDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox resoDropDown;
        private System.Windows.Forms.TextBox heightTextBox;
        private System.Windows.Forms.TextBox widthTextBox;
        private System.Windows.Forms.Label ResoLabel;
        private System.Windows.Forms.Button upgradeButton;
        private System.Windows.Forms.Panel footer;
        private System.Windows.Forms.Panel projectPanel;
        private System.Windows.Forms.Panel gamePanel;
        private System.Windows.Forms.Label gameHeader;
        private System.Windows.Forms.Label header;
        private System.Windows.Forms.Label projectHeading;
    }
}