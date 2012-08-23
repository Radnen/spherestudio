namespace Sphere_Editor.Settings
{
    partial class EditorSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditorSettings));
            this.cancelButton = new System.Windows.Forms.Button();
            this.OkButton = new System.Windows.Forms.Button();
            this.SpherePathLabel = new System.Windows.Forms.Label();
            this.SpherePathBox = new System.Windows.Forms.TextBox();
            this.FolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.SpherePathButton = new System.Windows.Forms.Button();
            this.ConfigPathLabel = new System.Windows.Forms.Label();
            this.GamePathLabel = new System.Windows.Forms.Label();
            this.ConfigPathBox = new System.Windows.Forms.TextBox();
            this.GamePathBox = new System.Windows.Forms.TextBox();
            this.OptionsBox = new System.Windows.Forms.GroupBox();
            this.WineCheckBox = new System.Windows.Forms.CheckBox();
            this.ScriptUpdateCheckBox = new System.Windows.Forms.CheckBox();
            this.FontComboBox = new System.Windows.Forms.ComboBox();
            this.FontLabel = new System.Windows.Forms.Label();
            this.AutoStartCheckBox = new System.Windows.Forms.CheckBox();
            this.PathsBox = new System.Windows.Forms.GroupBox();
            this.GamesPathButton = new System.Windows.Forms.Button();
            this.SettingsTip = new Sphere_Editor.TipLabel();
            this.OptionsBox.SuspendLayout();
            this.PathsBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(106, 288);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(87, 23);
            this.cancelButton.TabIndex = 0;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // OkButton
            // 
            this.OkButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkButton.Location = new System.Drawing.Point(209, 288);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(87, 23);
            this.OkButton.TabIndex = 1;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            // 
            // SpherePathLabel
            // 
            this.SpherePathLabel.AutoSize = true;
            this.SpherePathLabel.Location = new System.Drawing.Point(11, 16);
            this.SpherePathLabel.Name = "SpherePathLabel";
            this.SpherePathLabel.Size = new System.Drawing.Size(128, 13);
            this.SpherePathLabel.TabIndex = 2;
            this.SpherePathLabel.Text = "Sphere Engine Path: ";
            // 
            // SpherePathBox
            // 
            this.SpherePathBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.SpherePathBox.Location = new System.Drawing.Point(14, 32);
            this.SpherePathBox.Name = "SpherePathBox";
            this.SpherePathBox.Size = new System.Drawing.Size(316, 20);
            this.SpherePathBox.TabIndex = 5;
            // 
            // SpherePathButton
            // 
            this.SpherePathButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SpherePathButton.Image = global::Sphere_Editor.Properties.Resources.folder;
            this.SpherePathButton.Location = new System.Drawing.Point(336, 30);
            this.SpherePathButton.Name = "SpherePathButton";
            this.SpherePathButton.Size = new System.Drawing.Size(36, 23);
            this.SpherePathButton.TabIndex = 8;
            this.SpherePathButton.UseVisualStyleBackColor = true;
            this.SpherePathButton.Click += new System.EventHandler(this.SpherePathButton_Click);
            this.SpherePathButton.MouseEnter += new System.EventHandler(this.SpherePathButton_MouseEnter);
            this.SpherePathButton.MouseLeave += new System.EventHandler(this.ClearTip);
            // 
            // ConfigPathLabel
            // 
            this.ConfigPathLabel.AutoSize = true;
            this.ConfigPathLabel.Location = new System.Drawing.Point(11, 55);
            this.ConfigPathLabel.Name = "ConfigPathLabel";
            this.ConfigPathLabel.Size = new System.Drawing.Size(77, 13);
            this.ConfigPathLabel.TabIndex = 3;
            this.ConfigPathLabel.Text = "Config Path:";
            // 
            // GamePathLabel
            // 
            this.GamePathLabel.AutoSize = true;
            this.GamePathLabel.Location = new System.Drawing.Point(11, 94);
            this.GamePathLabel.Name = "GamePathLabel";
            this.GamePathLabel.Size = new System.Drawing.Size(73, 13);
            this.GamePathLabel.TabIndex = 4;
            this.GamePathLabel.Text = "Game Path:";
            // 
            // ConfigPathBox
            // 
            this.ConfigPathBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ConfigPathBox.Location = new System.Drawing.Point(14, 71);
            this.ConfigPathBox.Name = "ConfigPathBox";
            this.ConfigPathBox.Size = new System.Drawing.Size(358, 20);
            this.ConfigPathBox.TabIndex = 6;
            // 
            // GamePathBox
            // 
            this.GamePathBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.GamePathBox.Location = new System.Drawing.Point(14, 110);
            this.GamePathBox.Name = "GamePathBox";
            this.GamePathBox.Size = new System.Drawing.Size(316, 20);
            this.GamePathBox.TabIndex = 7;
            // 
            // OptionsBox
            // 
            this.OptionsBox.Controls.Add(this.WineCheckBox);
            this.OptionsBox.Controls.Add(this.ScriptUpdateCheckBox);
            this.OptionsBox.Controls.Add(this.FontComboBox);
            this.OptionsBox.Controls.Add(this.FontLabel);
            this.OptionsBox.Controls.Add(this.AutoStartCheckBox);
            this.OptionsBox.Location = new System.Drawing.Point(12, 188);
            this.OptionsBox.Name = "OptionsBox";
            this.OptionsBox.Size = new System.Drawing.Size(378, 94);
            this.OptionsBox.TabIndex = 11;
            this.OptionsBox.TabStop = false;
            this.OptionsBox.Text = "Editor Options:";
            // 
            // WineCheckBox
            // 
            this.WineCheckBox.AutoSize = true;
            this.WineCheckBox.Checked = true;
            this.WineCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.WineCheckBox.Location = new System.Drawing.Point(6, 19);
            this.WineCheckBox.Name = "WineCheckBox";
            this.WineCheckBox.Size = new System.Drawing.Size(103, 17);
            this.WineCheckBox.TabIndex = 17;
            this.WineCheckBox.Text = "Use Wine Mode";
            this.WineCheckBox.UseVisualStyleBackColor = false;
            // 
            // ScriptUpdateCheckBox
            // 
            this.ScriptUpdateCheckBox.AutoSize = true;
            this.ScriptUpdateCheckBox.Checked = true;
            this.ScriptUpdateCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ScriptUpdateCheckBox.Location = new System.Drawing.Point(197, 19);
            this.ScriptUpdateCheckBox.Name = "ScriptUpdateCheckBox";
            this.ScriptUpdateCheckBox.Size = new System.Drawing.Size(134, 17);
            this.ScriptUpdateCheckBox.TabIndex = 16;
            this.ScriptUpdateCheckBox.Text = "Update Script Headers";
            this.ScriptUpdateCheckBox.UseVisualStyleBackColor = false;
            this.ScriptUpdateCheckBox.MouseEnter += new System.EventHandler(this.ScriptUpdateCheckBox_MouseEnter);
            this.ScriptUpdateCheckBox.MouseLeave += new System.EventHandler(this.ClearTip);
            // 
            // FontComboBox
            // 
            this.FontComboBox.FormattingEnabled = true;
            this.FontComboBox.Items.AddRange(new object[] {
            "Verdana",
            "Tahoma",
            "Arial",
            "Comic Sans MS",
            "Courier"});
            this.FontComboBox.Location = new System.Drawing.Point(197, 63);
            this.FontComboBox.Name = "FontComboBox";
            this.FontComboBox.Size = new System.Drawing.Size(175, 21);
            this.FontComboBox.TabIndex = 15;
            this.FontComboBox.Text = "Verdana";
            this.FontComboBox.MouseEnter += new System.EventHandler(this.FontComboBox_MouseEnter);
            this.FontComboBox.MouseLeave += new System.EventHandler(this.ClearTip);
            // 
            // FontLabel
            // 
            this.FontLabel.AutoSize = true;
            this.FontLabel.Location = new System.Drawing.Point(194, 43);
            this.FontLabel.Name = "FontLabel";
            this.FontLabel.Size = new System.Drawing.Size(108, 13);
            this.FontLabel.TabIndex = 14;
            this.FontLabel.Text = "Editor Label Font:";
            // 
            // AutoStartCheckBox
            // 
            this.AutoStartCheckBox.AutoSize = true;
            this.AutoStartCheckBox.Checked = true;
            this.AutoStartCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AutoStartCheckBox.Location = new System.Drawing.Point(6, 42);
            this.AutoStartCheckBox.Name = "AutoStartCheckBox";
            this.AutoStartCheckBox.Size = new System.Drawing.Size(111, 17);
            this.AutoStartCheckBox.TabIndex = 11;
            this.AutoStartCheckBox.Text = "Open Last Project";
            this.AutoStartCheckBox.UseVisualStyleBackColor = false;
            this.AutoStartCheckBox.MouseEnter += new System.EventHandler(this.AutoStartCheckBox_MouseEnter);
            this.AutoStartCheckBox.MouseLeave += new System.EventHandler(this.ClearTip);
            // 
            // PathsBox
            // 
            this.PathsBox.Controls.Add(this.GamesPathButton);
            this.PathsBox.Controls.Add(this.SpherePathLabel);
            this.PathsBox.Controls.Add(this.ConfigPathLabel);
            this.PathsBox.Controls.Add(this.SpherePathButton);
            this.PathsBox.Controls.Add(this.GamePathLabel);
            this.PathsBox.Controls.Add(this.GamePathBox);
            this.PathsBox.Controls.Add(this.SpherePathBox);
            this.PathsBox.Controls.Add(this.ConfigPathBox);
            this.PathsBox.Location = new System.Drawing.Point(12, 31);
            this.PathsBox.Name = "PathsBox";
            this.PathsBox.Size = new System.Drawing.Size(378, 151);
            this.PathsBox.TabIndex = 12;
            this.PathsBox.TabStop = false;
            this.PathsBox.Text = "Editor Paths:";
            // 
            // GamesPathButton
            // 
            this.GamesPathButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GamesPathButton.Image = global::Sphere_Editor.Properties.Resources.folder;
            this.GamesPathButton.Location = new System.Drawing.Point(336, 108);
            this.GamesPathButton.Name = "GamesPathButton";
            this.GamesPathButton.Size = new System.Drawing.Size(36, 23);
            this.GamesPathButton.TabIndex = 9;
            this.GamesPathButton.UseVisualStyleBackColor = true;
            this.GamesPathButton.Click += new System.EventHandler(this.GamesPathButton_Click);
            this.GamesPathButton.MouseEnter += new System.EventHandler(this.GamesPathButton_MouseEnter);
            this.GamesPathButton.MouseLeave += new System.EventHandler(this.ClearTip);
            // 
            // SettingsTip
            // 
            this.SettingsTip.AlwaysShow = true;
            this.SettingsTip.BackColor = System.Drawing.Color.Lavender;
            this.SettingsTip.Dock = System.Windows.Forms.DockStyle.Top;
            this.SettingsTip.Font = new System.Drawing.Font("Verdana", 7.75F);
            this.SettingsTip.Image = ((System.Drawing.Image)(resources.GetObject("SettingsTip.Image")));
            this.SettingsTip.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SettingsTip.Location = new System.Drawing.Point(0, 0);
            this.SettingsTip.Name = "SettingsTip";
            this.SettingsTip.Size = new System.Drawing.Size(402, 21);
            this.SettingsTip.TabIndex = 13;
            this.SettingsTip.Text = "Rollover an item to view help.";
            this.SettingsTip.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EditorSettings
            // 
            this.AcceptButton = this.OkButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 323);
            this.Controls.Add(this.SettingsTip);
            this.Controls.Add(this.PathsBox);
            this.Controls.Add(this.OptionsBox);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.cancelButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(640, 480);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(380, 223);
            this.Name = "EditorSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editor Settings";
            this.OptionsBox.ResumeLayout(false);
            this.OptionsBox.PerformLayout();
            this.PathsBox.ResumeLayout(false);
            this.PathsBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Label SpherePathLabel;
        private System.Windows.Forms.TextBox SpherePathBox;
        private System.Windows.Forms.Button SpherePathButton;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowser;
        private System.Windows.Forms.Label ConfigPathLabel;
        private System.Windows.Forms.Label GamePathLabel;
        private System.Windows.Forms.TextBox ConfigPathBox;
        private System.Windows.Forms.TextBox GamePathBox;
        private System.Windows.Forms.GroupBox OptionsBox;
        private System.Windows.Forms.CheckBox AutoStartCheckBox;
        private System.Windows.Forms.GroupBox PathsBox;
        private System.Windows.Forms.Button GamesPathButton;
        private TipLabel SettingsTip;
        private System.Windows.Forms.Label FontLabel;
        private System.Windows.Forms.ComboBox FontComboBox;
        private System.Windows.Forms.CheckBox ScriptUpdateCheckBox;
        private System.Windows.Forms.CheckBox WineCheckBox;
    }
}