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
            this.FolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.Tip = new System.Windows.Forms.ToolTip(this.components);
            this.UpButton = new System.Windows.Forms.Button();
            this.DownButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.ButtonPanel = new System.Windows.Forms.Panel();
            this.ApplyButton = new System.Windows.Forms.Button();
            this.editorLabel5 = new Sphere.Core.Editor.EditorLabel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.PathListBox = new System.Windows.Forms.ListBox();
            this.editorLabel4 = new Sphere.Core.Editor.EditorLabel();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ScriptHeaderBox = new System.Windows.Forms.RichTextBox();
            this.editorLabel1 = new Sphere.Core.Editor.EditorLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ItemCheckBox = new System.Windows.Forms.CheckedListBox();
            this.PropLabel = new Sphere.Core.Editor.EditorLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.StyleComboBox = new System.Windows.Forms.ComboBox();
            this.editorLabel2 = new Sphere.Core.Editor.EditorLabel();
            this.SettingsTabs = new System.Windows.Forms.TabControl();
            this.ButtonPanel.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SettingsTabs.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(462, 4);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 22);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(383, 4);
            this.okButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 22);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "&Save";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // UpButton
            // 
            this.UpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.UpButton.Image = global::SphereStudio.Properties.Resources.resultset_up;
            this.UpButton.Location = new System.Drawing.Point(9, 384);
            this.UpButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.UpButton.Name = "UpButton";
            this.UpButton.Size = new System.Drawing.Size(23, 22);
            this.UpButton.TabIndex = 16;
            this.Tip.SetToolTip(this.UpButton, "Move path up.");
            this.UpButton.UseVisualStyleBackColor = true;
            this.UpButton.Click += new System.EventHandler(this.UpButton_Click);
            // 
            // DownButton
            // 
            this.DownButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DownButton.Image = global::SphereStudio.Properties.Resources.resultset_down;
            this.DownButton.Location = new System.Drawing.Point(37, 384);
            this.DownButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DownButton.Name = "DownButton";
            this.DownButton.Size = new System.Drawing.Size(23, 22);
            this.DownButton.TabIndex = 17;
            this.Tip.SetToolTip(this.DownButton, "Move path down.");
            this.DownButton.UseVisualStyleBackColor = true;
            this.DownButton.Click += new System.EventHandler(this.DownButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AddButton.Location = new System.Drawing.Point(474, 384);
            this.AddButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(64, 22);
            this.AddButton.TabIndex = 18;
            this.AddButton.Text = "Add...";
            this.Tip.SetToolTip(this.AddButton, "Add a Games Path");
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // RemoveButton
            // 
            this.RemoveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RemoveButton.Enabled = false;
            this.RemoveButton.Location = new System.Drawing.Point(544, 384);
            this.RemoveButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(64, 22);
            this.RemoveButton.TabIndex = 19;
            this.RemoveButton.Text = "Remove";
            this.Tip.SetToolTip(this.RemoveButton, "Remove Selected Gamepath");
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // ButtonPanel
            // 
            this.ButtonPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ButtonPanel.Controls.Add(this.ApplyButton);
            this.ButtonPanel.Controls.Add(this.cancelButton);
            this.ButtonPanel.Controls.Add(this.okButton);
            this.ButtonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonPanel.Location = new System.Drawing.Point(0, 493);
            this.ButtonPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ButtonPanel.Name = "ButtonPanel";
            this.ButtonPanel.Size = new System.Drawing.Size(627, 30);
            this.ButtonPanel.TabIndex = 2;
            // 
            // ApplyButton
            // 
            this.ApplyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ApplyButton.Location = new System.Drawing.Point(542, 4);
            this.ApplyButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(75, 22);
            this.ApplyButton.TabIndex = 2;
            this.ApplyButton.Text = "&Apply";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // editorLabel5
            // 
            this.editorLabel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.editorLabel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.editorLabel5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.editorLabel5.ForeColor = System.Drawing.Color.White;
            this.editorLabel5.Location = new System.Drawing.Point(0, 0);
            this.editorLabel5.Name = "editorLabel5";
            this.editorLabel5.Size = new System.Drawing.Size(627, 23);
            this.editorLabel5.TabIndex = 3;
            this.editorLabel5.Text = "Customize your Sphere Studio environment";
            this.editorLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel6);
            this.tabPage2.Controls.Add(this.editorLabel4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Size = new System.Drawing.Size(619, 444);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Project Paths";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label1);
            this.panel6.Controls.Add(this.RemoveButton);
            this.panel6.Controls.Add(this.AddButton);
            this.panel6.Controls.Add(this.DownButton);
            this.panel6.Controls.Add(this.UpButton);
            this.panel6.Controls.Add(this.PathListBox);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(3, 27);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(613, 413);
            this.panel6.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(599, 27);
            this.label1.TabIndex = 20;
            this.label1.Text = "\'My Documents\\Sphere Studio\\Projects\' is always searched by default.  You can spe" +
    "cify additional directories to search for Sphere projects here.";
            // 
            // PathListBox
            // 
            this.PathListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PathListBox.FormattingEnabled = true;
            this.PathListBox.IntegralHeight = false;
            this.PathListBox.Location = new System.Drawing.Point(9, 40);
            this.PathListBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PathListBox.Name = "PathListBox";
            this.PathListBox.Size = new System.Drawing.Size(599, 336);
            this.PathListBox.TabIndex = 15;
            this.PathListBox.SelectedIndexChanged += new System.EventHandler(this.PathListBox_SelectedIndexChanged);
            // 
            // editorLabel4
            // 
            this.editorLabel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.editorLabel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.editorLabel4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.editorLabel4.ForeColor = System.Drawing.Color.White;
            this.editorLabel4.Location = new System.Drawing.Point(3, 4);
            this.editorLabel4.Name = "editorLabel4";
            this.editorLabel4.Size = new System.Drawing.Size(613, 23);
            this.editorLabel4.TabIndex = 18;
            this.editorLabel4.Text = "Additional Project Directories";
            this.editorLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Controls.Add(this.editorLabel1);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.PropLabel);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.editorLabel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Size = new System.Drawing.Size(619, 444);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Options";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.ScriptHeaderBox);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 258);
            this.panel3.Margin = new System.Windows.Forms.Padding(5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(613, 182);
            this.panel3.TabIndex = 10;
            // 
            // ScriptHeaderBox
            // 
            this.ScriptHeaderBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ScriptHeaderBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ScriptHeaderBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScriptHeaderBox.Location = new System.Drawing.Point(5, 5);
            this.ScriptHeaderBox.Name = "ScriptHeaderBox";
            this.ScriptHeaderBox.Size = new System.Drawing.Size(603, 174);
            this.ScriptHeaderBox.TabIndex = 6;
            this.ScriptHeaderBox.Text = "/**\n * File: [filename]\n * Author: [author]\n * Date: [MM/dd/yy]\n**/";
            // 
            // editorLabel1
            // 
            this.editorLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.editorLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.editorLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.editorLabel1.ForeColor = System.Drawing.Color.White;
            this.editorLabel1.Location = new System.Drawing.Point(3, 235);
            this.editorLabel1.Name = "editorLabel1";
            this.editorLabel1.Size = new System.Drawing.Size(613, 23);
            this.editorLabel1.TabIndex = 2;
            this.editorLabel1.Text = "Script Header";
            this.editorLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ItemCheckBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 83);
            this.panel1.Margin = new System.Windows.Forms.Padding(5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(613, 152);
            this.panel1.TabIndex = 9;
            // 
            // ItemCheckBox
            // 
            this.ItemCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ItemCheckBox.FormattingEnabled = true;
            this.ItemCheckBox.Items.AddRange(new object[] {
            "Use Automatic Script Headers",
            "Automatically Open Last Project",
            "Automatically Open Start Page"});
            this.ItemCheckBox.Location = new System.Drawing.Point(5, 5);
            this.ItemCheckBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ItemCheckBox.Name = "ItemCheckBox";
            this.ItemCheckBox.Size = new System.Drawing.Size(603, 139);
            this.ItemCheckBox.TabIndex = 3;
            // 
            // PropLabel
            // 
            this.PropLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.PropLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.PropLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.PropLabel.ForeColor = System.Drawing.Color.White;
            this.PropLabel.Location = new System.Drawing.Point(3, 60);
            this.PropLabel.Name = "PropLabel";
            this.PropLabel.Size = new System.Drawing.Size(613, 23);
            this.PropLabel.TabIndex = 1;
            this.PropLabel.Text = "Properties";
            this.PropLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.StyleComboBox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 27);
            this.panel2.Margin = new System.Windows.Forms.Padding(5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(613, 33);
            this.panel2.TabIndex = 4;
            // 
            // StyleComboBox
            // 
            this.StyleComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StyleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StyleComboBox.FormattingEnabled = true;
            this.StyleComboBox.Location = new System.Drawing.Point(5, 5);
            this.StyleComboBox.Margin = new System.Windows.Forms.Padding(5);
            this.StyleComboBox.MaxDropDownItems = 10;
            this.StyleComboBox.Name = "StyleComboBox";
            this.StyleComboBox.Size = new System.Drawing.Size(603, 21);
            this.StyleComboBox.TabIndex = 0;
            // 
            // editorLabel2
            // 
            this.editorLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.editorLabel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.editorLabel2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.editorLabel2.ForeColor = System.Drawing.Color.White;
            this.editorLabel2.Location = new System.Drawing.Point(3, 4);
            this.editorLabel2.Name = "editorLabel2";
            this.editorLabel2.Size = new System.Drawing.Size(613, 23);
            this.editorLabel2.TabIndex = 0;
            this.editorLabel2.Text = "UI Style";
            this.editorLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SettingsTabs
            // 
            this.SettingsTabs.Controls.Add(this.tabPage1);
            this.SettingsTabs.Controls.Add(this.tabPage2);
            this.SettingsTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SettingsTabs.Location = new System.Drawing.Point(0, 23);
            this.SettingsTabs.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SettingsTabs.Name = "SettingsTabs";
            this.SettingsTabs.SelectedIndex = 0;
            this.SettingsTabs.Size = new System.Drawing.Size(627, 470);
            this.SettingsTabs.TabIndex = 0;
            // 
            // EditorSettings
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(627, 523);
            this.Controls.Add(this.SettingsTabs);
            this.Controls.Add(this.ButtonPanel);
            this.Controls.Add(this.editorLabel5);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 325);
            this.Name = "EditorSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editor Settings";
            this.ButtonPanel.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.SettingsTabs.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowser;
        private System.Windows.Forms.ToolTip Tip;
        private System.Windows.Forms.Panel ButtonPanel;
        private System.Windows.Forms.Button ApplyButton;
        private Sphere.Core.Editor.EditorLabel editorLabel5;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button DownButton;
        private System.Windows.Forms.Button UpButton;
        private System.Windows.Forms.ListBox PathListBox;
        private Sphere.Core.Editor.EditorLabel editorLabel4;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckedListBox ItemCheckBox;
        private Sphere.Core.Editor.EditorLabel editorLabel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RichTextBox ScriptHeaderBox;
        private Sphere.Core.Editor.EditorLabel PropLabel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox StyleComboBox;
        private Sphere.Core.Editor.EditorLabel editorLabel2;
        private System.Windows.Forms.TabControl SettingsTabs;
        private System.Windows.Forms.Label label1;
    }
}