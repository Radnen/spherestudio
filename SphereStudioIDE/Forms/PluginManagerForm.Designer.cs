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
            this.PresetsList = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.PluginsList = new System.Windows.Forms.ListView();
            this.NameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AuthorColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.VersionColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DescriptionColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pluginHeader = new SphereStudio.UI.DialogHeader();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.ImagePluginList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ScriptPluginList = new System.Windows.Forms.ComboBox();
            this.EnginePluginList = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CompilerPluginList = new System.Windows.Forms.ComboBox();
            this.FilePluginList = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.editorLabel2 = new SphereStudio.UI.DialogHeader();
            this.okButton = new System.Windows.Forms.Button();
            this.deletePresetButton = new System.Windows.Forms.Button();
            this.savePresetButton = new System.Windows.Forms.Button();
            this.header = new System.Windows.Forms.Label();
            this.footer = new System.Windows.Forms.Panel();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.footer.SuspendLayout();
            this.SuspendLayout();
            // 
            // PresetsList
            // 
            this.PresetsList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PresetsList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PresetsList.FormattingEnabled = true;
            this.PresetsList.Location = new System.Drawing.Point(12, 36);
            this.PresetsList.Name = "PresetsList";
            this.PresetsList.Size = new System.Drawing.Size(254, 21);
            this.PresetsList.TabIndex = 1;
            this.PresetsList.SelectedIndexChanged += new System.EventHandler(this.PresetsList_SelectedIndexChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 67);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(644, 421);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.PluginsList);
            this.tabPage2.Controls.Add(this.pluginHeader);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.editorLabel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(636, 395);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Plugins";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // PluginsList
            // 
            this.PluginsList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PluginsList.CheckBoxes = true;
            this.PluginsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameColumn,
            this.AuthorColumn,
            this.VersionColumn,
            this.DescriptionColumn});
            this.PluginsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PluginsList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.PluginsList.HideSelection = false;
            this.PluginsList.Location = new System.Drawing.Point(3, 152);
            this.PluginsList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PluginsList.Name = "PluginsList";
            this.PluginsList.ShowItemToolTips = true;
            this.PluginsList.Size = new System.Drawing.Size(630, 240);
            this.PluginsList.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.PluginsList.TabIndex = 3;
            this.PluginsList.UseCompatibleStateImageBehavior = false;
            this.PluginsList.View = System.Windows.Forms.View.Details;
            this.PluginsList.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.PluginsList_ItemChecked);
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
            // pluginHeader
            // 
            this.pluginHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pluginHeader.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.pluginHeader.Location = new System.Drawing.Point(3, 129);
            this.pluginHeader.Name = "pluginHeader";
            this.pluginHeader.Size = new System.Drawing.Size(630, 23);
            this.pluginHeader.TabIndex = 2;
            this.pluginHeader.Text = "Which plugins do you want to use?";
            this.pluginHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.ImagePluginList);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.ScriptPluginList);
            this.panel2.Controls.Add(this.EnginePluginList);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.CompilerPluginList);
            this.panel2.Controls.Add(this.FilePluginList);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 26);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(630, 103);
            this.panel2.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(332, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Image Editor";
            // 
            // ImagePluginList
            // 
            this.ImagePluginList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ImagePluginList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ImagePluginList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ImagePluginList.FormattingEnabled = true;
            this.ImagePluginList.Location = new System.Drawing.Point(410, 68);
            this.ImagePluginList.Name = "ImagePluginList";
            this.ImagePluginList.Size = new System.Drawing.Size(205, 21);
            this.ImagePluginList.TabIndex = 9;
            this.ImagePluginList.SelectedIndexChanged += new System.EventHandler(this.ImagePluginList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(334, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Script Editor";
            // 
            // ScriptPluginList
            // 
            this.ScriptPluginList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ScriptPluginList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ScriptPluginList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ScriptPluginList.FormattingEnabled = true;
            this.ScriptPluginList.Location = new System.Drawing.Point(410, 41);
            this.ScriptPluginList.Name = "ScriptPluginList";
            this.ScriptPluginList.Size = new System.Drawing.Size(205, 21);
            this.ScriptPluginList.TabIndex = 7;
            this.ScriptPluginList.SelectedIndexChanged += new System.EventHandler(this.ScriptPluginList_SelectedIndexChanged);
            // 
            // EnginePluginList
            // 
            this.EnginePluginList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EnginePluginList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EnginePluginList.FormattingEnabled = true;
            this.EnginePluginList.Location = new System.Drawing.Point(71, 14);
            this.EnginePluginList.Name = "EnginePluginList";
            this.EnginePluginList.Size = new System.Drawing.Size(205, 21);
            this.EnginePluginList.TabIndex = 6;
            this.EnginePluginList.SelectedIndexChanged += new System.EventHandler(this.EnginePluginList_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Engine";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(295, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Unknown File Types";
            // 
            // CompilerPluginList
            // 
            this.CompilerPluginList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CompilerPluginList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CompilerPluginList.FormattingEnabled = true;
            this.CompilerPluginList.Location = new System.Drawing.Point(71, 41);
            this.CompilerPluginList.Name = "CompilerPluginList";
            this.CompilerPluginList.Size = new System.Drawing.Size(205, 21);
            this.CompilerPluginList.TabIndex = 4;
            this.CompilerPluginList.SelectedIndexChanged += new System.EventHandler(this.CompilerPluginList_SelectedIndexChanged);
            // 
            // FilePluginList
            // 
            this.FilePluginList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FilePluginList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FilePluginList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FilePluginList.FormattingEnabled = true;
            this.FilePluginList.Location = new System.Drawing.Point(410, 14);
            this.FilePluginList.Name = "FilePluginList";
            this.FilePluginList.Size = new System.Drawing.Size(205, 21);
            this.FilePluginList.TabIndex = 1;
            this.FilePluginList.SelectedIndexChanged += new System.EventHandler(this.FilePluginList_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Compiler";
            // 
            // editorLabel2
            // 
            this.editorLabel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.editorLabel2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.editorLabel2.Location = new System.Drawing.Point(3, 3);
            this.editorLabel2.Name = "editorLabel2";
            this.editorLabel2.Size = new System.Drawing.Size(630, 23);
            this.editorLabel2.TabIndex = 6;
            this.editorLabel2.Text = "Select the default engine, compiler, and editors for this configuration.";
            this.editorLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point(576, 13);
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
            this.header.Size = new System.Drawing.Size(668, 23);
            this.header.TabIndex = 6;
            this.header.Text = "manage your Sphere Studio plugins";
            this.header.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // footer
            // 
            this.footer.Controls.Add(this.okButton);
            this.footer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footer.Location = new System.Drawing.Point(0, 499);
            this.footer.Name = "footer";
            this.footer.Size = new System.Drawing.Size(668, 50);
            this.footer.TabIndex = 7;
            // 
            // PluginManagerForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.okButton;
            this.ClientSize = new System.Drawing.Size(668, 549);
            this.Controls.Add(this.footer);
            this.Controls.Add(this.header);
            this.Controls.Add(this.deletePresetButton);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.PresetsList);
            this.Controls.Add(this.savePresetButton);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PluginManagerForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Plugin Manager";
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.footer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox PresetsList;
        private System.Windows.Forms.Button savePresetButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListView PluginsList;
        private System.Windows.Forms.ColumnHeader NameColumn;
        private System.Windows.Forms.ColumnHeader AuthorColumn;
        private System.Windows.Forms.ColumnHeader VersionColumn;
        private System.Windows.Forms.ColumnHeader DescriptionColumn;
        private SphereStudio.UI.DialogHeader pluginHeader;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button deletePresetButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CompilerPluginList;
        private System.Windows.Forms.ComboBox FilePluginList;
        private System.Windows.Forms.Label label4;
        private SphereStudio.UI.DialogHeader editorLabel2;
        private System.Windows.Forms.ComboBox EnginePluginList;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ImagePluginList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ScriptPluginList;
        private System.Windows.Forms.Label header;
        private System.Windows.Forms.Panel footer;
    }
}