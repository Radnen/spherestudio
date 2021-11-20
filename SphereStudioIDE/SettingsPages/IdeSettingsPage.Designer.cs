namespace SphereStudio.Ide.BuiltIns
{
    partial class IdeSettingsPage
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.UseStartPage = new System.Windows.Forms.CheckBox();
            this.OpenLastProject = new System.Windows.Forms.CheckBox();
            this.PropLabel = new SphereStudio.UI.DialogHeader();
            this.panel2 = new System.Windows.Forms.Panel();
            this.StylePicker = new System.Windows.Forms.ComboBox();
            this.editorLabel2 = new SphereStudio.UI.DialogHeader();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.ScriptHeader = new System.Windows.Forms.RichTextBox();
            this.editorLabel1 = new SphereStudio.UI.DialogHeader();
            this.panel3 = new System.Windows.Forms.Panel();
            this.UseScriptHeader = new System.Windows.Forms.CheckBox();
            this.editorLabel3 = new SphereStudio.UI.DialogHeader();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.RemovePathButton = new System.Windows.Forms.Button();
            this.AddPathButton = new System.Windows.Forms.Button();
            this.DownButton = new System.Windows.Forms.Button();
            this.UpButton = new System.Windows.Forms.Button();
            this.PathList = new System.Windows.Forms.ListBox();
            this.editorLabel4 = new SphereStudio.UI.DialogHeader();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(438, 400);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.PropLabel);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.editorLabel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(430, 374);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Environment";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.UseStartPage);
            this.panel1.Controls.Add(this.OpenLastProject);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 97);
            this.panel1.Margin = new System.Windows.Forms.Padding(5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(424, 68);
            this.panel1.TabIndex = 3;
            // 
            // UseStartPage
            // 
            this.UseStartPage.AutoSize = true;
            this.UseStartPage.Location = new System.Drawing.Point(14, 13);
            this.UseStartPage.Name = "UseStartPage";
            this.UseStartPage.Size = new System.Drawing.Size(299, 17);
            this.UseStartPage.TabIndex = 0;
            this.UseStartPage.Text = "Show the Start Page on startup when not loading a project";
            this.UseStartPage.UseVisualStyleBackColor = true;
            // 
            // OpenLastProject
            // 
            this.OpenLastProject.AutoSize = true;
            this.OpenLastProject.Location = new System.Drawing.Point(14, 36);
            this.OpenLastProject.Name = "OpenLastProject";
            this.OpenLastProject.Size = new System.Drawing.Size(224, 17);
            this.OpenLastProject.TabIndex = 2;
            this.OpenLastProject.Text = "Open the last worked-on project on startup";
            this.OpenLastProject.UseVisualStyleBackColor = true;
            // 
            // PropLabel
            // 
            this.PropLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.PropLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.PropLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.PropLabel.ForeColor = System.Drawing.Color.White;
            this.PropLabel.Location = new System.Drawing.Point(3, 74);
            this.PropLabel.Name = "PropLabel";
            this.PropLabel.Size = new System.Drawing.Size(424, 23);
            this.PropLabel.TabIndex = 2;
            this.PropLabel.Text = "IDE settings";
            this.PropLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.StylePicker);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 26);
            this.panel2.Margin = new System.Windows.Forms.Padding(5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(424, 48);
            this.panel2.TabIndex = 1;
            // 
            // StylePicker
            // 
            this.StylePicker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StylePicker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StylePicker.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StylePicker.FormattingEnabled = true;
            this.StylePicker.Location = new System.Drawing.Point(14, 13);
            this.StylePicker.Margin = new System.Windows.Forms.Padding(5);
            this.StylePicker.MaxDropDownItems = 10;
            this.StylePicker.Name = "StylePicker";
            this.StylePicker.Size = new System.Drawing.Size(395, 21);
            this.StylePicker.TabIndex = 0;
            // 
            // editorLabel2
            // 
            this.editorLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.editorLabel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.editorLabel2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.editorLabel2.ForeColor = System.Drawing.Color.White;
            this.editorLabel2.Location = new System.Drawing.Point(3, 3);
            this.editorLabel2.Name = "editorLabel2";
            this.editorLabel2.Size = new System.Drawing.Size(424, 23);
            this.editorLabel2.TabIndex = 0;
            this.editorLabel2.Text = "Select your preferred UI style";
            this.editorLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.ScriptHeader);
            this.tabPage3.Controls.Add(this.editorLabel1);
            this.tabPage3.Controls.Add(this.panel3);
            this.tabPage3.Controls.Add(this.editorLabel3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(430, 374);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Script Header";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // ScriptHeader
            // 
            this.ScriptHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ScriptHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScriptHeader.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScriptHeader.Location = new System.Drawing.Point(3, 89);
            this.ScriptHeader.Name = "ScriptHeader";
            this.ScriptHeader.Size = new System.Drawing.Size(424, 282);
            this.ScriptHeader.TabIndex = 8;
            this.ScriptHeader.Text = "/**\n * File: [filename]\n * Author: [author]\n * Date: [MM/dd/yy]\n**/";
            // 
            // editorLabel1
            // 
            this.editorLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.editorLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.editorLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.editorLabel1.ForeColor = System.Drawing.Color.White;
            this.editorLabel1.Location = new System.Drawing.Point(3, 66);
            this.editorLabel1.Name = "editorLabel1";
            this.editorLabel1.Size = new System.Drawing.Size(424, 23);
            this.editorLabel1.TabIndex = 7;
            this.editorLabel1.Text = "Enter template for script header";
            this.editorLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.UseScriptHeader);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 26);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(424, 40);
            this.panel3.TabIndex = 10;
            // 
            // UseScriptHeader
            // 
            this.UseScriptHeader.AutoSize = true;
            this.UseScriptHeader.Location = new System.Drawing.Point(16, 13);
            this.UseScriptHeader.Name = "UseScriptHeader";
            this.UseScriptHeader.Size = new System.Drawing.Size(219, 17);
            this.UseScriptHeader.TabIndex = 0;
            this.UseScriptHeader.Text = "Use automatic script header management";
            this.UseScriptHeader.UseVisualStyleBackColor = true;
            // 
            // editorLabel3
            // 
            this.editorLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.editorLabel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.editorLabel3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.editorLabel3.ForeColor = System.Drawing.Color.White;
            this.editorLabel3.Location = new System.Drawing.Point(3, 3);
            this.editorLabel3.Name = "editorLabel3";
            this.editorLabel3.Size = new System.Drawing.Size(424, 23);
            this.editorLabel3.TabIndex = 9;
            this.editorLabel3.Text = "Options";
            this.editorLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel6);
            this.tabPage2.Controls.Add(this.editorLabel4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(430, 374);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Project Paths";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label1);
            this.panel6.Controls.Add(this.RemovePathButton);
            this.panel6.Controls.Add(this.AddPathButton);
            this.panel6.Controls.Add(this.DownButton);
            this.panel6.Controls.Add(this.UpButton);
            this.panel6.Controls.Add(this.PathList);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(3, 26);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(424, 345);
            this.panel6.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(410, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = @"`Documents/Sphere Projects` is always searched by default.  You can specify additional directories to search for Sphere projects here.";
            // 
            // RemovePathButton
            // 
            this.RemovePathButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RemovePathButton.Enabled = false;
            this.RemovePathButton.Location = new System.Drawing.Point(355, 316);
            this.RemovePathButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RemovePathButton.Name = "RemovePathButton";
            this.RemovePathButton.Size = new System.Drawing.Size(64, 22);
            this.RemovePathButton.TabIndex = 5;
            this.RemovePathButton.Text = "Remove";
            this.RemovePathButton.UseVisualStyleBackColor = true;
            this.RemovePathButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RemovePathButton.Click += new System.EventHandler(this.RemovePathButton_Click);
            // 
            // AddPathButton
            // 
            this.AddPathButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AddPathButton.Location = new System.Drawing.Point(285, 316);
            this.AddPathButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AddPathButton.Name = "AddPathButton";
            this.AddPathButton.Size = new System.Drawing.Size(64, 22);
            this.AddPathButton.TabIndex = 4;
            this.AddPathButton.Text = "Add...";
            this.AddPathButton.UseVisualStyleBackColor = true;
            this.AddPathButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddPathButton.Click += new System.EventHandler(this.AddPathButton_Click);
            // 
            // DownButton
            // 
            this.DownButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DownButton.Enabled = false;
            this.DownButton.Image = global::SphereStudio.Ide.Properties.Resources.resultset_down;
            this.DownButton.Location = new System.Drawing.Point(37, 316);
            this.DownButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DownButton.Name = "DownButton";
            this.DownButton.Size = new System.Drawing.Size(23, 22);
            this.DownButton.TabIndex = 3;
            this.DownButton.UseVisualStyleBackColor = true;
            this.DownButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DownButton.Click += new System.EventHandler(this.DownButton_Click);
            // 
            // UpButton
            // 
            this.UpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.UpButton.Enabled = false;
            this.UpButton.Image = global::SphereStudio.Ide.Properties.Resources.resultset_up;
            this.UpButton.Location = new System.Drawing.Point(9, 316);
            this.UpButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.UpButton.Name = "UpButton";
            this.UpButton.Size = new System.Drawing.Size(23, 22);
            this.UpButton.TabIndex = 2;
            this.UpButton.UseVisualStyleBackColor = true;
            this.UpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpButton.Click += new System.EventHandler(this.UpButton_Click);
            // 
            // PathList
            // 
            this.PathList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PathList.FormattingEnabled = true;
            this.PathList.IntegralHeight = false;
            this.PathList.Location = new System.Drawing.Point(9, 40);
            this.PathList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PathList.Name = "PathList";
            this.PathList.Size = new System.Drawing.Size(410, 268);
            this.PathList.TabIndex = 1;
            this.PathList.SelectedIndexChanged += new System.EventHandler(this.PathList_SelectedIndexChanged);
            // 
            // editorLabel4
            // 
            this.editorLabel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.editorLabel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.editorLabel4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.editorLabel4.ForeColor = System.Drawing.Color.White;
            this.editorLabel4.Location = new System.Drawing.Point(3, 3);
            this.editorLabel4.Name = "editorLabel4";
            this.editorLabel4.Size = new System.Drawing.Size(424, 23);
            this.editorLabel4.TabIndex = 0;
            this.editorLabel4.Text = "Choose directories to be searched for Sphere Studio projects";
            this.editorLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // IdeSettingsPage
            // 
            this.Controls.Add(this.tabControl1);
            this.Name = "IdeSettingsPage";
            this.Size = new System.Drawing.Size(438, 400);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox UseStartPage;
        private System.Windows.Forms.CheckBox OpenLastProject;
        private SphereStudio.UI.DialogHeader PropLabel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox StylePicker;
        private SphereStudio.UI.DialogHeader editorLabel2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button RemovePathButton;
        private System.Windows.Forms.Button AddPathButton;
        private System.Windows.Forms.Button DownButton;
        private System.Windows.Forms.Button UpButton;
        private System.Windows.Forms.ListBox PathList;
        private SphereStudio.UI.DialogHeader editorLabel4;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.RichTextBox ScriptHeader;
        private SphereStudio.UI.DialogHeader editorLabel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox UseScriptHeader;
        private SphereStudio.UI.DialogHeader editorLabel3;
    }
}
