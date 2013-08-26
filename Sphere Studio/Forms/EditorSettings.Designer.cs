namespace SphereStudio.Forms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditorSettings));
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.SpherePathLabel = new System.Windows.Forms.Label();
            this.SpherePathBox = new System.Windows.Forms.TextBox();
            this.FolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.ConfigPathLabel = new System.Windows.Forms.Label();
            this.GamePathLabel = new System.Windows.Forms.Label();
            this.ConfigPathBox = new System.Windows.Forms.TextBox();
            this.SettingsTabs = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.StyleLabel = new System.Windows.Forms.Label();
            this.StyleComboBox = new System.Windows.Forms.ComboBox();
            this.PropLabel = new System.Windows.Forms.Label();
            this.ItemCheckBox = new System.Windows.Forms.CheckedListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.DownButton = new System.Windows.Forms.Button();
            this.UpButton = new System.Windows.Forms.Button();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.PathListBox = new System.Windows.Forms.ListBox();
            this.SpherePathButton = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.PluginList = new System.Windows.Forms.ListView();
            this.NameCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AuthorCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.VersionCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DescriptionCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.Tip = new System.Windows.Forms.ToolTip(this.components);
            this.UsePresetButton = new System.Windows.Forms.Button();
            this.RemovePresetButton = new System.Windows.Forms.Button();
            this.SavePresetButton = new System.Windows.Forms.Button();
            this.PresetListBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ButtonPanel = new System.Windows.Forms.Panel();
            this.ApplyButton = new System.Windows.Forms.Button();
            this.PresetsPanel = new System.Windows.Forms.Panel();
            this.PresetLabel = new Sphere.Core.Editor.EditorLabel();
            this.SettingsTabs.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.ButtonPanel.SuspendLayout();
            this.PresetsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(370, 4);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 22);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(291, 4);
            this.okButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 22);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "&Save";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // SpherePathLabel
            // 
            this.SpherePathLabel.AutoSize = true;
            this.SpherePathLabel.Location = new System.Drawing.Point(6, 4);
            this.SpherePathLabel.Name = "SpherePathLabel";
            this.SpherePathLabel.Size = new System.Drawing.Size(102, 13);
            this.SpherePathLabel.TabIndex = 0;
            this.SpherePathLabel.Text = "Sphere Engine Path";
            // 
            // SpherePathBox
            // 
            this.SpherePathBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SpherePathBox.Location = new System.Drawing.Point(9, 19);
            this.SpherePathBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SpherePathBox.Name = "SpherePathBox";
            this.SpherePathBox.Size = new System.Drawing.Size(251, 20);
            this.SpherePathBox.TabIndex = 1;
            // 
            // ConfigPathLabel
            // 
            this.ConfigPathLabel.AutoSize = true;
            this.ConfigPathLabel.Location = new System.Drawing.Point(6, 43);
            this.ConfigPathLabel.Name = "ConfigPathLabel";
            this.ConfigPathLabel.Size = new System.Drawing.Size(62, 13);
            this.ConfigPathLabel.TabIndex = 3;
            this.ConfigPathLabel.Text = "Config Path";
            // 
            // GamePathLabel
            // 
            this.GamePathLabel.AutoSize = true;
            this.GamePathLabel.Location = new System.Drawing.Point(6, 82);
            this.GamePathLabel.Name = "GamePathLabel";
            this.GamePathLabel.Size = new System.Drawing.Size(65, 13);
            this.GamePathLabel.TabIndex = 5;
            this.GamePathLabel.Text = "Game Paths";
            // 
            // ConfigPathBox
            // 
            this.ConfigPathBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConfigPathBox.Location = new System.Drawing.Point(9, 58);
            this.ConfigPathBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ConfigPathBox.Name = "ConfigPathBox";
            this.ConfigPathBox.Size = new System.Drawing.Size(287, 20);
            this.ConfigPathBox.TabIndex = 4;
            // 
            // SettingsTabs
            // 
            this.SettingsTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SettingsTabs.Controls.Add(this.tabPage1);
            this.SettingsTabs.Controls.Add(this.tabPage2);
            this.SettingsTabs.Controls.Add(this.tabPage3);
            this.SettingsTabs.Location = new System.Drawing.Point(10, 11);
            this.SettingsTabs.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SettingsTabs.Name = "SettingsTabs";
            this.SettingsTabs.SelectedIndex = 0;
            this.SettingsTabs.Size = new System.Drawing.Size(307, 312);
            this.SettingsTabs.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.StyleLabel);
            this.tabPage1.Controls.Add(this.StyleComboBox);
            this.tabPage1.Controls.Add(this.PropLabel);
            this.tabPage1.Controls.Add(this.ItemCheckBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Size = new System.Drawing.Size(299, 283);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Options";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // StyleLabel
            // 
            this.StyleLabel.AutoSize = true;
            this.StyleLabel.Location = new System.Drawing.Point(3, 4);
            this.StyleLabel.Name = "StyleLabel";
            this.StyleLabel.Size = new System.Drawing.Size(47, 13);
            this.StyleLabel.TabIndex = 0;
            this.StyleLabel.Text = "UI Style:";
            // 
            // StyleComboBox
            // 
            this.StyleComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StyleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StyleComboBox.FormattingEnabled = true;
            this.StyleComboBox.Location = new System.Drawing.Point(5, 23);
            this.StyleComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StyleComboBox.MaxDropDownItems = 10;
            this.StyleComboBox.Name = "StyleComboBox";
            this.StyleComboBox.Size = new System.Drawing.Size(290, 21);
            this.StyleComboBox.TabIndex = 1;
            // 
            // PropLabel
            // 
            this.PropLabel.AutoSize = true;
            this.PropLabel.Location = new System.Drawing.Point(3, 45);
            this.PropLabel.Name = "PropLabel";
            this.PropLabel.Size = new System.Drawing.Size(54, 13);
            this.PropLabel.TabIndex = 2;
            this.PropLabel.Text = "Properties";
            // 
            // ItemCheckBox
            // 
            this.ItemCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ItemCheckBox.FormattingEnabled = true;
            this.ItemCheckBox.Items.AddRange(new object[] {
            "Update Script Headers",
            "Automatically Open Last Project",
            "Automatically Open Start Page"});
            this.ItemCheckBox.Location = new System.Drawing.Point(5, 62);
            this.ItemCheckBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ItemCheckBox.Name = "ItemCheckBox";
            this.ItemCheckBox.Size = new System.Drawing.Size(290, 64);
            this.ItemCheckBox.TabIndex = 3;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.DownButton);
            this.tabPage2.Controls.Add(this.UpButton);
            this.tabPage2.Controls.Add(this.RemoveButton);
            this.tabPage2.Controls.Add(this.AddButton);
            this.tabPage2.Controls.Add(this.PathListBox);
            this.tabPage2.Controls.Add(this.SpherePathLabel);
            this.tabPage2.Controls.Add(this.ConfigPathLabel);
            this.tabPage2.Controls.Add(this.ConfigPathBox);
            this.tabPage2.Controls.Add(this.SpherePathButton);
            this.tabPage2.Controls.Add(this.SpherePathBox);
            this.tabPage2.Controls.Add(this.GamePathLabel);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Size = new System.Drawing.Size(299, 283);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Paths";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // DownButton
            // 
            this.DownButton.Image = global::SphereStudio.Properties.Resources.resultset_down;
            this.DownButton.Location = new System.Drawing.Point(33, 369);
            this.DownButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DownButton.Name = "DownButton";
            this.DownButton.Size = new System.Drawing.Size(23, 22);
            this.DownButton.TabIndex = 13;
            this.Tip.SetToolTip(this.DownButton, "Move path down.");
            this.DownButton.UseVisualStyleBackColor = true;
            this.DownButton.Click += new System.EventHandler(this.DownButton_Click);
            // 
            // UpButton
            // 
            this.UpButton.Image = global::SphereStudio.Properties.Resources.resultset_up;
            this.UpButton.Location = new System.Drawing.Point(5, 369);
            this.UpButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.UpButton.Name = "UpButton";
            this.UpButton.Size = new System.Drawing.Size(23, 22);
            this.UpButton.TabIndex = 12;
            this.Tip.SetToolTip(this.UpButton, "Move path up.");
            this.UpButton.UseVisualStyleBackColor = true;
            this.UpButton.Click += new System.EventHandler(this.UpButton_Click);
            // 
            // RemoveButton
            // 
            this.RemoveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RemoveButton.Enabled = false;
            this.RemoveButton.Location = new System.Drawing.Point(231, 262);
            this.RemoveButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(64, 22);
            this.RemoveButton.TabIndex = 8;
            this.RemoveButton.Text = "Remove";
            this.Tip.SetToolTip(this.RemoveButton, "Remove Selected Gamepath");
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AddButton.Location = new System.Drawing.Point(161, 262);
            this.AddButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(64, 22);
            this.AddButton.TabIndex = 7;
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
            this.PathListBox.IntegralHeight = false;
            this.PathListBox.Location = new System.Drawing.Point(9, 97);
            this.PathListBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PathListBox.Name = "PathListBox";
            this.PathListBox.Size = new System.Drawing.Size(287, 158);
            this.PathListBox.TabIndex = 6;
            this.PathListBox.SelectedIndexChanged += new System.EventHandler(this.PathListBox_SelectedIndexChanged);
            // 
            // SpherePathButton
            // 
            this.SpherePathButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SpherePathButton.Image = global::SphereStudio.Properties.Resources.folder;
            this.SpherePathButton.Location = new System.Drawing.Point(264, 19);
            this.SpherePathButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SpherePathButton.Name = "SpherePathButton";
            this.SpherePathButton.Size = new System.Drawing.Size(31, 22);
            this.SpherePathButton.TabIndex = 2;
            this.Tip.SetToolTip(this.SpherePathButton, "Choose Sphere Folder");
            this.SpherePathButton.UseVisualStyleBackColor = true;
            this.SpherePathButton.Click += new System.EventHandler(this.SpherePathButton_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.PluginList);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage3.Size = new System.Drawing.Size(299, 286);
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
            this.PluginList.Location = new System.Drawing.Point(3, 32);
            this.PluginList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PluginList.Name = "PluginList";
            this.PluginList.ShowItemToolTips = true;
            this.PluginList.Size = new System.Drawing.Size(293, 250);
            this.PluginList.TabIndex = 1;
            this.PluginList.UseCompatibleStateImageBehavior = false;
            this.PluginList.View = System.Windows.Forms.View.Details;
            this.PluginList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.PluginList_ItemCheck);
            // 
            // NameCol
            // 
            this.NameCol.Text = "Name";
            this.NameCol.Width = 150;
            // 
            // AuthorCol
            // 
            this.AuthorCol.Text = "Author";
            this.AuthorCol.Width = 91;
            // 
            // VersionCol
            // 
            this.VersionCol.Text = "Version";
            this.VersionCol.Width = 62;
            // 
            // DescriptionCol
            // 
            this.DescriptionCol.Text = "Description";
            this.DescriptionCol.Width = 300;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(293, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "This is a list of plugins that are present in the /plugins directory. Click on th" +
    "e check boxes to add or remove features from the editor.";
            // 
            // UsePresetButton
            // 
            this.UsePresetButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UsePresetButton.Enabled = false;
            this.UsePresetButton.Location = new System.Drawing.Point(3, 260);
            this.UsePresetButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.UsePresetButton.Name = "UsePresetButton";
            this.UsePresetButton.Size = new System.Drawing.Size(195, 22);
            this.UsePresetButton.TabIndex = 2;
            this.UsePresetButton.Text = "Use";
            this.Tip.SetToolTip(this.UsePresetButton, "Use Preset Settings File");
            this.UsePresetButton.UseVisualStyleBackColor = true;
            this.UsePresetButton.Click += new System.EventHandler(this.UsePresetButton_Click);
            // 
            // RemovePresetButton
            // 
            this.RemovePresetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RemovePresetButton.Enabled = false;
            this.RemovePresetButton.Location = new System.Drawing.Point(134, 284);
            this.RemovePresetButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RemovePresetButton.Name = "RemovePresetButton";
            this.RemovePresetButton.Size = new System.Drawing.Size(64, 22);
            this.RemovePresetButton.TabIndex = 4;
            this.RemovePresetButton.Text = "Remove";
            this.Tip.SetToolTip(this.RemovePresetButton, "Remove the preset settings file.");
            this.RemovePresetButton.UseVisualStyleBackColor = true;
            this.RemovePresetButton.Click += new System.EventHandler(this.RemovePresetButton_Click);
            // 
            // SavePresetButton
            // 
            this.SavePresetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SavePresetButton.Location = new System.Drawing.Point(64, 284);
            this.SavePresetButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SavePresetButton.Name = "SavePresetButton";
            this.SavePresetButton.Size = new System.Drawing.Size(64, 22);
            this.SavePresetButton.TabIndex = 3;
            this.SavePresetButton.Text = "Add...";
            this.Tip.SetToolTip(this.SavePresetButton, "Save current settings to disk.");
            this.SavePresetButton.UseVisualStyleBackColor = true;
            this.SavePresetButton.Click += new System.EventHandler(this.SavePresetButton_Click);
            // 
            // PresetListBox
            // 
            this.PresetListBox.FormattingEnabled = true;
            this.PresetListBox.IntegralHeight = false;
            this.PresetListBox.Location = new System.Drawing.Point(3, 81);
            this.PresetListBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PresetListBox.Name = "PresetListBox";
            this.PresetListBox.Size = new System.Drawing.Size(196, 171);
            this.PresetListBox.TabIndex = 1;
            this.PresetListBox.SelectedIndexChanged += new System.EventHandler(this.PresetListBox_SelectedIndexChanged);
            this.PresetListBox.DoubleClick += new System.EventHandler(this.PresetListBox_DoubleClick);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(201, 58);
            this.label2.TabIndex = 0;
            this.label2.Text = "Presets allow you to target different Sphere versions, game paths and plugin list" +
    "s to suit your development needs.";
            // 
            // ButtonPanel
            // 
            this.ButtonPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ButtonPanel.Controls.Add(this.ApplyButton);
            this.ButtonPanel.Controls.Add(this.cancelButton);
            this.ButtonPanel.Controls.Add(this.okButton);
            this.ButtonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonPanel.Location = new System.Drawing.Point(0, 329);
            this.ButtonPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ButtonPanel.Name = "ButtonPanel";
            this.ButtonPanel.Size = new System.Drawing.Size(535, 30);
            this.ButtonPanel.TabIndex = 2;
            // 
            // ApplyButton
            // 
            this.ApplyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ApplyButton.Location = new System.Drawing.Point(450, 4);
            this.ApplyButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(75, 22);
            this.ApplyButton.TabIndex = 2;
            this.ApplyButton.Text = "&Apply";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // PresetsPanel
            // 
            this.PresetsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PresetsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PresetsPanel.Controls.Add(this.RemovePresetButton);
            this.PresetsPanel.Controls.Add(this.SavePresetButton);
            this.PresetsPanel.Controls.Add(this.UsePresetButton);
            this.PresetsPanel.Controls.Add(this.PresetListBox);
            this.PresetsPanel.Controls.Add(this.label2);
            this.PresetsPanel.Controls.Add(this.PresetLabel);
            this.PresetsPanel.Location = new System.Drawing.Point(322, 11);
            this.PresetsPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PresetsPanel.Name = "PresetsPanel";
            this.PresetsPanel.Size = new System.Drawing.Size(203, 312);
            this.PresetsPanel.TabIndex = 3;
            // 
            // PresetLabel
            // 
            this.PresetLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.PresetLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.PresetLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PresetLabel.ForeColor = System.Drawing.Color.White;
            this.PresetLabel.Location = new System.Drawing.Point(0, 0);
            this.PresetLabel.Name = "PresetLabel";
            this.PresetLabel.Size = new System.Drawing.Size(201, 19);
            this.PresetLabel.TabIndex = 4;
            this.PresetLabel.Text = "Presets";
            this.PresetLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EditorSettings
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(535, 359);
            this.Controls.Add(this.PresetsPanel);
            this.Controls.Add(this.SettingsTabs);
            this.Controls.Add(this.ButtonPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
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
            this.ButtonPanel.ResumeLayout(false);
            this.PresetsPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label SpherePathLabel;
        private System.Windows.Forms.TextBox SpherePathBox;
        private System.Windows.Forms.Button SpherePathButton;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowser;
        private System.Windows.Forms.Label ConfigPathLabel;
        private System.Windows.Forms.Label GamePathLabel;
        private System.Windows.Forms.TextBox ConfigPathBox;
        private System.Windows.Forms.TabControl SettingsTabs;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckedListBox ItemCheckBox;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListBox PathListBox;
        private System.Windows.Forms.Label PropLabel;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.ToolTip Tip;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListView PluginList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader NameCol;
        private System.Windows.Forms.ColumnHeader AuthorCol;
        private System.Windows.Forms.ColumnHeader VersionCol;
        private System.Windows.Forms.ColumnHeader DescriptionCol;
        private System.Windows.Forms.ListBox PresetListBox;
        private System.Windows.Forms.Button UsePresetButton;
        private System.Windows.Forms.Button RemovePresetButton;
        private System.Windows.Forms.Button SavePresetButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button DownButton;
        private System.Windows.Forms.Button UpButton;
        private System.Windows.Forms.Panel ButtonPanel;
        private System.Windows.Forms.Label StyleLabel;
        private System.Windows.Forms.ComboBox StyleComboBox;
        private System.Windows.Forms.Panel PresetsPanel;
        private Sphere.Core.Editor.EditorLabel PresetLabel;
        private System.Windows.Forms.Button ApplyButton;
    }
}