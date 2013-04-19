namespace Sphere_Editor.Forms
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
            this.components = new System.ComponentModel.Container();
            this.cancelButton = new System.Windows.Forms.Button();
            this.OkButton = new System.Windows.Forms.Button();
            this.SpherePathLabel = new System.Windows.Forms.Label();
            this.SpherePathBox = new System.Windows.Forms.TextBox();
            this.FolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.SpherePathButton = new System.Windows.Forms.Button();
            this.ConfigPathLabel = new System.Windows.Forms.Label();
            this.GamePathLabel = new System.Windows.Forms.Label();
            this.ConfigPathBox = new System.Windows.Forms.TextBox();
            this.FontComboBox = new System.Windows.Forms.ComboBox();
            this.FontLabel = new System.Windows.Forms.Label();
            this.SettingsTabs = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.PropLabel = new System.Windows.Forms.Label();
            this.ItemCheckBox = new System.Windows.Forms.CheckedListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.PathListBox = new System.Windows.Forms.ListBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.PluginList = new System.Windows.Forms.ListView();
            this.NameCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AuthorCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.VersionCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DescriptionCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.PresetListBox = new System.Windows.Forms.ListBox();
            this.UsePresetButton = new System.Windows.Forms.Button();
            this.RemovePresetButton = new System.Windows.Forms.Button();
            this.SavePresetButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Tip = new System.Windows.Forms.ToolTip(this.components);
            this.SettingsTabs.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(115, 12);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 0;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // OkButton
            // 
            this.OkButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkButton.Location = new System.Drawing.Point(204, 12);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 1;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            // 
            // SpherePathLabel
            // 
            this.SpherePathLabel.AutoSize = true;
            this.SpherePathLabel.Location = new System.Drawing.Point(3, 3);
            this.SpherePathLabel.Name = "SpherePathLabel";
            this.SpherePathLabel.Size = new System.Drawing.Size(102, 13);
            this.SpherePathLabel.TabIndex = 2;
            this.SpherePathLabel.Text = "Sphere Engine Path";
            // 
            // SpherePathBox
            // 
            this.SpherePathBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.SpherePathBox.Location = new System.Drawing.Point(5, 19);
            this.SpherePathBox.Name = "SpherePathBox";
            this.SpherePathBox.Size = new System.Drawing.Size(339, 20);
            this.SpherePathBox.TabIndex = 5;
            // 
            // SpherePathButton
            // 
            this.SpherePathButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SpherePathButton.Image = global::Sphere_Editor.Properties.Resources.folder;
            this.SpherePathButton.Location = new System.Drawing.Point(349, 17);
            this.SpherePathButton.Name = "SpherePathButton";
            this.SpherePathButton.Size = new System.Drawing.Size(31, 23);
            this.SpherePathButton.TabIndex = 8;
            this.Tip.SetToolTip(this.SpherePathButton, "Choose Sphere Folder");
            this.SpherePathButton.UseVisualStyleBackColor = true;
            this.SpherePathButton.Click += new System.EventHandler(this.SpherePathButton_Click);
            // 
            // ConfigPathLabel
            // 
            this.ConfigPathLabel.AutoSize = true;
            this.ConfigPathLabel.Location = new System.Drawing.Point(3, 42);
            this.ConfigPathLabel.Name = "ConfigPathLabel";
            this.ConfigPathLabel.Size = new System.Drawing.Size(62, 13);
            this.ConfigPathLabel.TabIndex = 3;
            this.ConfigPathLabel.Text = "Config Path";
            // 
            // GamePathLabel
            // 
            this.GamePathLabel.AutoSize = true;
            this.GamePathLabel.Location = new System.Drawing.Point(3, 81);
            this.GamePathLabel.Name = "GamePathLabel";
            this.GamePathLabel.Size = new System.Drawing.Size(65, 13);
            this.GamePathLabel.TabIndex = 4;
            this.GamePathLabel.Text = "Game Paths";
            // 
            // ConfigPathBox
            // 
            this.ConfigPathBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ConfigPathBox.Location = new System.Drawing.Point(7, 58);
            this.ConfigPathBox.Name = "ConfigPathBox";
            this.ConfigPathBox.Size = new System.Drawing.Size(338, 20);
            this.ConfigPathBox.TabIndex = 6;
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
            this.FontComboBox.Location = new System.Drawing.Point(9, 132);
            this.FontComboBox.Name = "FontComboBox";
            this.FontComboBox.Size = new System.Drawing.Size(151, 21);
            this.FontComboBox.TabIndex = 15;
            this.FontComboBox.Text = "Verdana";
            // 
            // FontLabel
            // 
            this.FontLabel.AutoSize = true;
            this.FontLabel.Location = new System.Drawing.Point(7, 116);
            this.FontLabel.Name = "FontLabel";
            this.FontLabel.Size = new System.Drawing.Size(90, 13);
            this.FontLabel.TabIndex = 14;
            this.FontLabel.Text = "Editor Label Font:";
            // 
            // SettingsTabs
            // 
            this.SettingsTabs.Controls.Add(this.tabPage1);
            this.SettingsTabs.Controls.Add(this.tabPage2);
            this.SettingsTabs.Controls.Add(this.tabPage3);
            this.SettingsTabs.Controls.Add(this.tabPage4);
            this.SettingsTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SettingsTabs.Location = new System.Drawing.Point(0, 0);
            this.SettingsTabs.Name = "SettingsTabs";
            this.SettingsTabs.SelectedIndex = 0;
            this.SettingsTabs.Size = new System.Drawing.Size(394, 251);
            this.SettingsTabs.TabIndex = 14;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.PropLabel);
            this.tabPage1.Controls.Add(this.ItemCheckBox);
            this.tabPage1.Controls.Add(this.FontComboBox);
            this.tabPage1.Controls.Add(this.FontLabel);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(386, 225);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Options";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // PropLabel
            // 
            this.PropLabel.AutoSize = true;
            this.PropLabel.Location = new System.Drawing.Point(5, 3);
            this.PropLabel.Name = "PropLabel";
            this.PropLabel.Size = new System.Drawing.Size(54, 13);
            this.PropLabel.TabIndex = 19;
            this.PropLabel.Text = "Properties";
            // 
            // ItemCheckBox
            // 
            this.ItemCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ItemCheckBox.FormattingEnabled = true;
            this.ItemCheckBox.Items.AddRange(new object[] {
            "Update Script Headers",
            "Open Last Project"});
            this.ItemCheckBox.Location = new System.Drawing.Point(5, 19);
            this.ItemCheckBox.Name = "ItemCheckBox";
            this.ItemCheckBox.Size = new System.Drawing.Size(373, 94);
            this.ItemCheckBox.TabIndex = 18;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.RemoveButton);
            this.tabPage2.Controls.Add(this.AddButton);
            this.tabPage2.Controls.Add(this.PathListBox);
            this.tabPage2.Controls.Add(this.SpherePathLabel);
            this.tabPage2.Controls.Add(this.ConfigPathLabel);
            this.tabPage2.Controls.Add(this.ConfigPathBox);
            this.tabPage2.Controls.Add(this.SpherePathButton);
            this.tabPage2.Controls.Add(this.SpherePathBox);
            this.tabPage2.Controls.Add(this.GamePathLabel);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(386, 225);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Paths";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // RemoveButton
            // 
            this.RemoveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RemoveButton.Enabled = false;
            this.RemoveButton.Location = new System.Drawing.Point(76, 198);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(64, 23);
            this.RemoveButton.TabIndex = 11;
            this.RemoveButton.Text = "Remove";
            this.Tip.SetToolTip(this.RemoveButton, "Remove Selected Gamepath");
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AddButton.Location = new System.Drawing.Point(7, 198);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(64, 23);
            this.AddButton.TabIndex = 10;
            this.AddButton.Text = "Add...";
            this.Tip.SetToolTip(this.AddButton, "Add a Games Path");
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // PathListBox
            // 
            this.PathListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.PathListBox.FormattingEnabled = true;
            this.PathListBox.Location = new System.Drawing.Point(5, 97);
            this.PathListBox.Name = "PathListBox";
            this.PathListBox.Size = new System.Drawing.Size(340, 95);
            this.PathListBox.TabIndex = 9;
            this.PathListBox.SelectedIndexChanged += new System.EventHandler(this.PathListBox_SelectedIndexChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.PluginList);
            this.tabPage3.Controls.Add(this.panel2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(386, 225);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Plugins";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // PluginList
            // 
            this.PluginList.CheckBoxes = true;
            this.PluginList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameCol,
            this.AuthorCol,
            this.VersionCol,
            this.DescriptionCol});
            this.PluginList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PluginList.GridLines = true;
            this.PluginList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.PluginList.Location = new System.Drawing.Point(3, 36);
            this.PluginList.Name = "PluginList";
            this.PluginList.Size = new System.Drawing.Size(380, 186);
            this.PluginList.TabIndex = 0;
            this.PluginList.UseCompatibleStateImageBehavior = false;
            this.PluginList.View = System.Windows.Forms.View.Details;
            this.PluginList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.PluginList_ItemCheck);
            // 
            // NameCol
            // 
            this.NameCol.Text = "Name";
            this.NameCol.Width = 70;
            // 
            // AuthorCol
            // 
            this.AuthorCol.Text = "Author";
            // 
            // VersionCol
            // 
            this.VersionCol.Text = "Version";
            this.VersionCol.Width = 50;
            // 
            // DescriptionCol
            // 
            this.DescriptionCol.Text = "Description";
            this.DescriptionCol.Width = 195;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(380, 33);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(380, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "This is a list of plugins that are present in the /plugins directory.\r\nHit the ch" +
                "eck boxes to add or remove features from the editor.";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.PresetListBox);
            this.tabPage4.Controls.Add(this.UsePresetButton);
            this.tabPage4.Controls.Add(this.RemovePresetButton);
            this.tabPage4.Controls.Add(this.SavePresetButton);
            this.tabPage4.Controls.Add(this.label2);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(386, 225);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Presets";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // PresetListBox
            // 
            this.PresetListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.PresetListBox.FormattingEnabled = true;
            this.PresetListBox.Location = new System.Drawing.Point(6, 36);
            this.PresetListBox.Name = "PresetListBox";
            this.PresetListBox.Size = new System.Drawing.Size(372, 147);
            this.PresetListBox.TabIndex = 15;
            this.PresetListBox.SelectedIndexChanged += new System.EventHandler(this.PresetListBox_SelectedIndexChanged);
            // 
            // UsePresetButton
            // 
            this.UsePresetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.UsePresetButton.Enabled = false;
            this.UsePresetButton.Location = new System.Drawing.Point(6, 196);
            this.UsePresetButton.Name = "UsePresetButton";
            this.UsePresetButton.Size = new System.Drawing.Size(64, 23);
            this.UsePresetButton.TabIndex = 14;
            this.UsePresetButton.Text = "Use";
            this.Tip.SetToolTip(this.UsePresetButton, "Use Preset Settings File");
            this.UsePresetButton.UseVisualStyleBackColor = true;
            this.UsePresetButton.Click += new System.EventHandler(this.UsePresetButton_Click);
            // 
            // RemovePresetButton
            // 
            this.RemovePresetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RemovePresetButton.Enabled = false;
            this.RemovePresetButton.Location = new System.Drawing.Point(145, 196);
            this.RemovePresetButton.Name = "RemovePresetButton";
            this.RemovePresetButton.Size = new System.Drawing.Size(64, 23);
            this.RemovePresetButton.TabIndex = 13;
            this.RemovePresetButton.Text = "Remove";
            this.Tip.SetToolTip(this.RemovePresetButton, "Remove the preset settings file.");
            this.RemovePresetButton.UseVisualStyleBackColor = true;
            this.RemovePresetButton.Click += new System.EventHandler(this.RemovePresetButton_Click);
            // 
            // SavePresetButton
            // 
            this.SavePresetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SavePresetButton.Location = new System.Drawing.Point(76, 196);
            this.SavePresetButton.Name = "SavePresetButton";
            this.SavePresetButton.Size = new System.Drawing.Size(64, 23);
            this.SavePresetButton.TabIndex = 12;
            this.SavePresetButton.Text = "Add...";
            this.Tip.SetToolTip(this.SavePresetButton, "Save these settings.");
            this.SavePresetButton.UseVisualStyleBackColor = true;
            this.SavePresetButton.Click += new System.EventHandler(this.SavePresetButton_Click);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(380, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "Editor presets allow you to target different sphere versions,\r\ngame paths and plu" +
                "gin lists to suit your development needs.";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cancelButton);
            this.panel1.Controls.Add(this.OkButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 251);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(394, 46);
            this.panel1.TabIndex = 15;
            // 
            // EditorSettings
            // 
            this.AcceptButton = this.OkButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 297);
            this.Controls.Add(this.SettingsTabs);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(549, 480);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 325);
            this.Name = "EditorSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editor Settings";
            this.Load += new System.EventHandler(this.EditorSettings_Load);
            this.SettingsTabs.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
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
        private System.Windows.Forms.Label FontLabel;
        private System.Windows.Forms.ComboBox FontComboBox;
        private System.Windows.Forms.TabControl SettingsTabs;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckedListBox ItemCheckBox;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListBox PathListBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label PropLabel;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.ToolTip Tip;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListView PluginList;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader NameCol;
        private System.Windows.Forms.ColumnHeader AuthorCol;
        private System.Windows.Forms.ColumnHeader VersionCol;
        private System.Windows.Forms.ColumnHeader DescriptionCol;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button UsePresetButton;
        private System.Windows.Forms.Button RemovePresetButton;
        private System.Windows.Forms.Button SavePresetButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox PresetListBox;
    }
}