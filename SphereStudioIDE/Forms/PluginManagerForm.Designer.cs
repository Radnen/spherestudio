namespace SphereStudio.Ide.Forms
{
    partial class PluginManagerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PluginManagerForm));
            this.presetDropDown = new System.Windows.Forms.ComboBox();
            this.pluginsListView = new System.Windows.Forms.ListView();
            this.NameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AuthorColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.VersionColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DescriptionColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.imageDropDown = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.scriptDropDown = new System.Windows.Forms.ComboBox();
            this.engineDropDown = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.typeDropDown = new System.Windows.Forms.ComboBox();
            this.fileDropDown = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.deletePresetButton = new System.Windows.Forms.Button();
            this.savePresetButton = new System.Windows.Forms.Button();
            this.header = new System.Windows.Forms.Label();
            this.footer = new System.Windows.Forms.Panel();
            this.defaultsPanel = new System.Windows.Forms.Panel();
            this.defaultsHeading = new System.Windows.Forms.Label();
            this.pluginsPanel = new System.Windows.Forms.Panel();
            this.pluginsHeading = new System.Windows.Forms.Label();
            this.footer.SuspendLayout();
            this.defaultsPanel.SuspendLayout();
            this.pluginsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // presetDropDown
            // 
            this.presetDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.presetDropDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.presetDropDown.FormattingEnabled = true;
            this.presetDropDown.Location = new System.Drawing.Point(12, 36);
            this.presetDropDown.Name = "presetDropDown";
            this.presetDropDown.Size = new System.Drawing.Size(254, 21);
            this.presetDropDown.TabIndex = 1;
            this.presetDropDown.SelectedIndexChanged += new System.EventHandler(this.PresetsList_SelectedIndexChanged);
            // 
            // pluginsListView
            // 
            this.pluginsListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pluginsListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pluginsListView.CheckBoxes = true;
            this.pluginsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameColumn,
            this.AuthorColumn,
            this.VersionColumn,
            this.DescriptionColumn});
            this.pluginsListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.pluginsListView.HideSelection = false;
            this.pluginsListView.Location = new System.Drawing.Point(12, 32);
            this.pluginsListView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pluginsListView.Name = "pluginsListView";
            this.pluginsListView.ShowItemToolTips = true;
            this.pluginsListView.Size = new System.Drawing.Size(605, 251);
            this.pluginsListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.pluginsListView.TabIndex = 3;
            this.pluginsListView.UseCompatibleStateImageBehavior = false;
            this.pluginsListView.View = System.Windows.Forms.View.Details;
            this.pluginsListView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.PluginsList_ItemChecked);
            // 
            // NameColumn
            // 
            this.NameColumn.Text = "Name";
            this.NameColumn.Width = 180;
            // 
            // AuthorColumn
            // 
            this.AuthorColumn.Text = "Publisher";
            this.AuthorColumn.Width = 136;
            // 
            // VersionColumn
            // 
            this.VersionColumn.Text = "Version";
            this.VersionColumn.Width = 62;
            // 
            // DescriptionColumn
            // 
            this.DescriptionColumn.Text = "Description";
            this.DescriptionColumn.Width = 291;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(334, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Image Editor";
            // 
            // imageDropDown
            // 
            this.imageDropDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imageDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.imageDropDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.imageDropDown.FormattingEnabled = true;
            this.imageDropDown.Location = new System.Drawing.Point(412, 86);
            this.imageDropDown.Name = "imageDropDown";
            this.imageDropDown.Size = new System.Drawing.Size(205, 21);
            this.imageDropDown.TabIndex = 9;
            this.imageDropDown.SelectedIndexChanged += new System.EventHandler(this.ImagePluginList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(336, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Script Editor";
            // 
            // scriptDropDown
            // 
            this.scriptDropDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.scriptDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.scriptDropDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.scriptDropDown.FormattingEnabled = true;
            this.scriptDropDown.Location = new System.Drawing.Point(412, 59);
            this.scriptDropDown.Name = "scriptDropDown";
            this.scriptDropDown.Size = new System.Drawing.Size(205, 21);
            this.scriptDropDown.TabIndex = 7;
            this.scriptDropDown.SelectedIndexChanged += new System.EventHandler(this.ScriptPluginList_SelectedIndexChanged);
            // 
            // engineDropDown
            // 
            this.engineDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.engineDropDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.engineDropDown.FormattingEnabled = true;
            this.engineDropDown.Location = new System.Drawing.Point(86, 32);
            this.engineDropDown.Name = "engineDropDown";
            this.engineDropDown.Size = new System.Drawing.Size(190, 21);
            this.engineDropDown.TabIndex = 6;
            this.engineDropDown.SelectedIndexChanged += new System.EventHandler(this.EnginePluginList_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Engine";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(297, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Unknown File Types";
            // 
            // typeDropDown
            // 
            this.typeDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeDropDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.typeDropDown.FormattingEnabled = true;
            this.typeDropDown.Location = new System.Drawing.Point(86, 59);
            this.typeDropDown.Name = "typeDropDown";
            this.typeDropDown.Size = new System.Drawing.Size(190, 21);
            this.typeDropDown.TabIndex = 4;
            this.typeDropDown.SelectedIndexChanged += new System.EventHandler(this.CompilerPluginList_SelectedIndexChanged);
            // 
            // fileDropDown
            // 
            this.fileDropDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fileDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fileDropDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fileDropDown.FormattingEnabled = true;
            this.fileDropDown.Location = new System.Drawing.Point(412, 32);
            this.fileDropDown.Name = "fileDropDown";
            this.fileDropDown.Size = new System.Drawing.Size(205, 21);
            this.fileDropDown.TabIndex = 1;
            this.fileDropDown.SelectedIndexChanged += new System.EventHandler(this.FilePluginList_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Project Type";
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point(562, 13);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(80, 25);
            this.okButton.TabIndex = 5;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // deletePresetButton
            // 
            this.deletePresetButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deletePresetButton.Image = global::SphereStudio.Ide.Properties.Resources.cross;
            this.deletePresetButton.Location = new System.Drawing.Point(272, 35);
            this.deletePresetButton.Name = "deletePresetButton";
            this.deletePresetButton.Size = new System.Drawing.Size(36, 26);
            this.deletePresetButton.TabIndex = 2;
            this.deletePresetButton.UseVisualStyleBackColor = true;
            this.deletePresetButton.Click += new System.EventHandler(this.DeletePresetButton_Click);
            // 
            // savePresetButton
            // 
            this.savePresetButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.savePresetButton.Image = global::SphereStudio.Ide.Properties.Resources.disk;
            this.savePresetButton.Location = new System.Drawing.Point(314, 35);
            this.savePresetButton.Name = "savePresetButton";
            this.savePresetButton.Size = new System.Drawing.Size(36, 26);
            this.savePresetButton.TabIndex = 3;
            this.savePresetButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.savePresetButton.UseVisualStyleBackColor = true;
            this.savePresetButton.Click += new System.EventHandler(this.SavePresetButton_Click);
            // 
            // header
            // 
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.Location = new System.Drawing.Point(0, 0);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(654, 23);
            this.header.TabIndex = 6;
            this.header.Text = "manage your Sphere Studio plugins";
            this.header.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // footer
            // 
            this.footer.Controls.Add(this.okButton);
            this.footer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footer.Location = new System.Drawing.Point(0, 503);
            this.footer.Name = "footer";
            this.footer.Size = new System.Drawing.Size(654, 50);
            this.footer.TabIndex = 7;
            // 
            // defaultsPanel
            // 
            this.defaultsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.defaultsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.defaultsPanel.Controls.Add(this.label2);
            this.defaultsPanel.Controls.Add(this.defaultsHeading);
            this.defaultsPanel.Controls.Add(this.imageDropDown);
            this.defaultsPanel.Controls.Add(this.fileDropDown);
            this.defaultsPanel.Controls.Add(this.label1);
            this.defaultsPanel.Controls.Add(this.label4);
            this.defaultsPanel.Controls.Add(this.scriptDropDown);
            this.defaultsPanel.Controls.Add(this.typeDropDown);
            this.defaultsPanel.Controls.Add(this.engineDropDown);
            this.defaultsPanel.Controls.Add(this.label3);
            this.defaultsPanel.Controls.Add(this.label5);
            this.defaultsPanel.Location = new System.Drawing.Point(12, 67);
            this.defaultsPanel.Name = "defaultsPanel";
            this.defaultsPanel.Size = new System.Drawing.Size(630, 121);
            this.defaultsPanel.TabIndex = 8;
            // 
            // defaultsHeading
            // 
            this.defaultsHeading.Dock = System.Windows.Forms.DockStyle.Top;
            this.defaultsHeading.Location = new System.Drawing.Point(0, 0);
            this.defaultsHeading.Name = "defaultsHeading";
            this.defaultsHeading.Size = new System.Drawing.Size(628, 23);
            this.defaultsHeading.TabIndex = 0;
            this.defaultsHeading.Text = "Default Handlers";
            this.defaultsHeading.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pluginsPanel
            // 
            this.pluginsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pluginsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pluginsPanel.Controls.Add(this.pluginsHeading);
            this.pluginsPanel.Controls.Add(this.pluginsListView);
            this.pluginsPanel.Location = new System.Drawing.Point(12, 194);
            this.pluginsPanel.Name = "pluginsPanel";
            this.pluginsPanel.Size = new System.Drawing.Size(630, 297);
            this.pluginsPanel.TabIndex = 9;
            // 
            // pluginsHeading
            // 
            this.pluginsHeading.Dock = System.Windows.Forms.DockStyle.Top;
            this.pluginsHeading.Location = new System.Drawing.Point(0, 0);
            this.pluginsHeading.Name = "pluginsHeading";
            this.pluginsHeading.Size = new System.Drawing.Size(628, 23);
            this.pluginsHeading.TabIndex = 0;
            this.pluginsHeading.Text = "Installed Plugins";
            this.pluginsHeading.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PluginManagerForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.okButton;
            this.ClientSize = new System.Drawing.Size(654, 553);
            this.Controls.Add(this.pluginsPanel);
            this.Controls.Add(this.defaultsPanel);
            this.Controls.Add(this.footer);
            this.Controls.Add(this.header);
            this.Controls.Add(this.deletePresetButton);
            this.Controls.Add(this.presetDropDown);
            this.Controls.Add(this.savePresetButton);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PluginManagerForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Plugin Manager";
            this.footer.ResumeLayout(false);
            this.defaultsPanel.ResumeLayout(false);
            this.defaultsPanel.PerformLayout();
            this.pluginsPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox presetDropDown;
        private System.Windows.Forms.Button savePresetButton;
        private System.Windows.Forms.ListView pluginsListView;
        private System.Windows.Forms.ColumnHeader NameColumn;
        private System.Windows.Forms.ColumnHeader AuthorColumn;
        private System.Windows.Forms.ColumnHeader VersionColumn;
        private System.Windows.Forms.ColumnHeader DescriptionColumn;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button deletePresetButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox typeDropDown;
        private System.Windows.Forms.ComboBox fileDropDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox engineDropDown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox imageDropDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox scriptDropDown;
        private System.Windows.Forms.Label header;
        private System.Windows.Forms.Panel footer;
        private System.Windows.Forms.Panel defaultsPanel;
        private System.Windows.Forms.Label defaultsHeading;
        private System.Windows.Forms.Panel pluginsPanel;
        private System.Windows.Forms.Label pluginsHeading;
    }
}