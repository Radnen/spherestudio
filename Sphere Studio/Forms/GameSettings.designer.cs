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
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.AuthorTextBox = new System.Windows.Forms.TextBox();
            this.DescLabel = new System.Windows.Forms.Label();
            this.DescTextBox = new System.Windows.Forms.TextBox();
            this.ScriptLabel = new System.Windows.Forms.Label();
            this.ScreenSizeLabel = new System.Windows.Forms.Label();
            this.ScriptComboBox = new System.Windows.Forms.ComboBox();
            this.XLabel = new System.Windows.Forms.Label();
            this.WidthTextBox = new System.Windows.Forms.TextBox();
            this.HeightTextBox = new System.Windows.Forms.TextBox();
            this.okayButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.NewProjectPic = new System.Windows.Forms.PictureBox();
            this.ButtonPanel = new System.Windows.Forms.Panel();
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
            this.GameTitleLabel.TabIndex = 1;
            this.GameTitleLabel.Text = "Game Title";
            // 
            // AuthorLabel
            // 
            this.AuthorLabel.AutoSize = true;
            this.AuthorLabel.Location = new System.Drawing.Point(14, 112);
            this.AuthorLabel.Name = "AuthorLabel";
            this.AuthorLabel.Size = new System.Drawing.Size(46, 16);
            this.AuthorLabel.TabIndex = 2;
            this.AuthorLabel.Text = "Author";
            // 
            // PathTextBox
            // 
            this.PathTextBox.Enabled = false;
            this.PathTextBox.Location = new System.Drawing.Point(112, 47);
            this.PathTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PathTextBox.Name = "PathTextBox";
            this.PathTextBox.Size = new System.Drawing.Size(236, 23);
            this.PathTextBox.TabIndex = 3;
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(112, 78);
            this.NameTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(236, 23);
            this.NameTextBox.TabIndex = 4;
            // 
            // AuthorTextBox
            // 
            this.AuthorTextBox.Location = new System.Drawing.Point(112, 109);
            this.AuthorTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AuthorTextBox.Name = "AuthorTextBox";
            this.AuthorTextBox.Size = new System.Drawing.Size(236, 23);
            this.AuthorTextBox.TabIndex = 5;
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
            // DescTextBox
            // 
            this.DescTextBox.Location = new System.Drawing.Point(12, 163);
            this.DescTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DescTextBox.Multiline = true;
            this.DescTextBox.Name = "DescTextBox";
            this.DescTextBox.Size = new System.Drawing.Size(336, 176);
            this.DescTextBox.TabIndex = 7;
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
            this.ScreenSizeLabel.Location = new System.Drawing.Point(12, 386);
            this.ScreenSizeLabel.Name = "ScreenSizeLabel";
            this.ScreenSizeLabel.Size = new System.Drawing.Size(76, 16);
            this.ScreenSizeLabel.TabIndex = 9;
            this.ScreenSizeLabel.Text = "Screen Size";
            // 
            // ScriptComboBox
            // 
            this.ScriptComboBox.FormattingEnabled = true;
            this.ScriptComboBox.Location = new System.Drawing.Point(112, 347);
            this.ScriptComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ScriptComboBox.Name = "ScriptComboBox";
            this.ScriptComboBox.Size = new System.Drawing.Size(236, 24);
            this.ScriptComboBox.TabIndex = 10;
            // 
            // XLabel
            // 
            this.XLabel.AutoSize = true;
            this.XLabel.Location = new System.Drawing.Point(221, 386);
            this.XLabel.Name = "XLabel";
            this.XLabel.Size = new System.Drawing.Size(14, 16);
            this.XLabel.TabIndex = 11;
            this.XLabel.Text = "x";
            // 
            // WidthTextBox
            // 
            this.WidthTextBox.Location = new System.Drawing.Point(110, 382);
            this.WidthTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.WidthTextBox.Name = "WidthTextBox";
            this.WidthTextBox.Size = new System.Drawing.Size(103, 23);
            this.WidthTextBox.TabIndex = 12;
            this.WidthTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // HeightTextBox
            // 
            this.HeightTextBox.Location = new System.Drawing.Point(244, 379);
            this.HeightTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.HeightTextBox.Name = "HeightTextBox";
            this.HeightTextBox.Size = new System.Drawing.Size(104, 23);
            this.HeightTextBox.TabIndex = 13;
            this.HeightTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // okayButton
            // 
            this.okayButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okayButton.Location = new System.Drawing.Point(183, 4);
            this.okayButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.okayButton.Name = "okayButton";
            this.okayButton.Size = new System.Drawing.Size(87, 28);
            this.okayButton.TabIndex = 14;
            this.okayButton.Text = "OK";
            this.okayButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(90, 4);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(87, 28);
            this.cancelButton.TabIndex = 15;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
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
            this.ButtonPanel.Controls.Add(this.okayButton);
            this.ButtonPanel.Controls.Add(this.cancelButton);
            this.ButtonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonPanel.Location = new System.Drawing.Point(0, 427);
            this.ButtonPanel.Name = "ButtonPanel";
            this.ButtonPanel.Size = new System.Drawing.Size(360, 37);
            this.ButtonPanel.TabIndex = 17;
            // 
            // GameSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 464);
            this.Controls.Add(this.ButtonPanel);
            this.Controls.Add(this.NewProjectPic);
            this.Controls.Add(this.HeightTextBox);
            this.Controls.Add(this.WidthTextBox);
            this.Controls.Add(this.XLabel);
            this.Controls.Add(this.ScriptComboBox);
            this.Controls.Add(this.ScreenSizeLabel);
            this.Controls.Add(this.ScriptLabel);
            this.Controls.Add(this.DescTextBox);
            this.Controls.Add(this.DescLabel);
            this.Controls.Add(this.AuthorTextBox);
            this.Controls.Add(this.NameTextBox);
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
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.TextBox AuthorTextBox;
        private System.Windows.Forms.Label DescLabel;
        private System.Windows.Forms.TextBox DescTextBox;
        private System.Windows.Forms.Label ScriptLabel;
        private System.Windows.Forms.Label ScreenSizeLabel;
        private System.Windows.Forms.ComboBox ScriptComboBox;
        private System.Windows.Forms.Label XLabel;
        private System.Windows.Forms.TextBox WidthTextBox;
        private System.Windows.Forms.TextBox HeightTextBox;
        private System.Windows.Forms.Button okayButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.PictureBox NewProjectPic;
        private System.Windows.Forms.Panel ButtonPanel;

    }
}