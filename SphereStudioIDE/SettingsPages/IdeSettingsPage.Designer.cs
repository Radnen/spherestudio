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
            this.useStartPageButton = new System.Windows.Forms.CheckBox();
            this.rememberProjectButton = new System.Windows.Forms.CheckBox();
            this.styleDropDown = new System.Windows.Forms.ComboBox();
            this.removeDirButton = new System.Windows.Forms.Button();
            this.addDirButton = new System.Windows.Forms.Button();
            this.moveDirDownButton = new System.Windows.Forms.Button();
            this.moveDirUpButton = new System.Windows.Forms.Button();
            this.dirsListBox = new System.Windows.Forms.ListBox();
            this.stylePanel = new System.Windows.Forms.Panel();
            this.styleHeading = new System.Windows.Forms.Label();
            this.miscPanel = new System.Windows.Forms.Panel();
            this.miscHeading = new System.Windows.Forms.Label();
            this.dirsPanel = new System.Windows.Forms.Panel();
            this.dirsHeading = new System.Windows.Forms.Label();
            this.stylePanel.SuspendLayout();
            this.miscPanel.SuspendLayout();
            this.dirsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // useStartPageButton
            // 
            this.useStartPageButton.AutoSize = true;
            this.useStartPageButton.BackColor = System.Drawing.SystemColors.Control;
            this.useStartPageButton.Location = new System.Drawing.Point(10, 32);
            this.useStartPageButton.Name = "useStartPageButton";
            this.useStartPageButton.Size = new System.Drawing.Size(303, 17);
            this.useStartPageButton.TabIndex = 0;
            this.useStartPageButton.Text = "Show the &Start Page at startup when not opening a project";
            this.useStartPageButton.UseVisualStyleBackColor = false;
            // 
            // rememberProjectButton
            // 
            this.rememberProjectButton.AutoSize = true;
            this.rememberProjectButton.BackColor = System.Drawing.SystemColors.Control;
            this.rememberProjectButton.Location = new System.Drawing.Point(10, 55);
            this.rememberProjectButton.Name = "rememberProjectButton";
            this.rememberProjectButton.Size = new System.Drawing.Size(328, 17);
            this.rememberProjectButton.TabIndex = 2;
            this.rememberProjectButton.Text = "Remember the &last worked-on project and open it at next startup";
            this.rememberProjectButton.UseVisualStyleBackColor = false;
            // 
            // styleDropDown
            // 
            this.styleDropDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.styleDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.styleDropDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.styleDropDown.FormattingEnabled = true;
            this.styleDropDown.Location = new System.Drawing.Point(10, 32);
            this.styleDropDown.Margin = new System.Windows.Forms.Padding(5);
            this.styleDropDown.MaxDropDownItems = 10;
            this.styleDropDown.Name = "styleDropDown";
            this.styleDropDown.Size = new System.Drawing.Size(342, 21);
            this.styleDropDown.TabIndex = 0;
            // 
            // removeDirButton
            // 
            this.removeDirButton.Enabled = false;
            this.removeDirButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeDirButton.Location = new System.Drawing.Point(96, 136);
            this.removeDirButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.removeDirButton.Name = "removeDirButton";
            this.removeDirButton.Size = new System.Drawing.Size(80, 25);
            this.removeDirButton.TabIndex = 5;
            this.removeDirButton.Text = "Remove";
            this.removeDirButton.UseVisualStyleBackColor = true;
            this.removeDirButton.Click += new System.EventHandler(this.RemovePathButton_Click);
            // 
            // addDirButton
            // 
            this.addDirButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addDirButton.Location = new System.Drawing.Point(10, 136);
            this.addDirButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.addDirButton.Name = "addDirButton";
            this.addDirButton.Size = new System.Drawing.Size(80, 25);
            this.addDirButton.TabIndex = 4;
            this.addDirButton.Text = "Add...";
            this.addDirButton.UseVisualStyleBackColor = true;
            this.addDirButton.Click += new System.EventHandler(this.AddPathButton_Click);
            // 
            // moveDirDownButton
            // 
            this.moveDirDownButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.moveDirDownButton.Enabled = false;
            this.moveDirDownButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.moveDirDownButton.Image = global::SphereStudio.Ide.Properties.Resources.resultset_down;
            this.moveDirDownButton.Location = new System.Drawing.Point(327, 134);
            this.moveDirDownButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.moveDirDownButton.Name = "moveDirDownButton";
            this.moveDirDownButton.Size = new System.Drawing.Size(25, 25);
            this.moveDirDownButton.TabIndex = 3;
            this.moveDirDownButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.moveDirDownButton.UseVisualStyleBackColor = true;
            this.moveDirDownButton.Click += new System.EventHandler(this.DownButton_Click);
            // 
            // moveDirUpButton
            // 
            this.moveDirUpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.moveDirUpButton.Enabled = false;
            this.moveDirUpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.moveDirUpButton.Image = global::SphereStudio.Ide.Properties.Resources.resultset_up;
            this.moveDirUpButton.Location = new System.Drawing.Point(296, 134);
            this.moveDirUpButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.moveDirUpButton.Name = "moveDirUpButton";
            this.moveDirUpButton.Size = new System.Drawing.Size(25, 25);
            this.moveDirUpButton.TabIndex = 2;
            this.moveDirUpButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.moveDirUpButton.UseVisualStyleBackColor = true;
            this.moveDirUpButton.Click += new System.EventHandler(this.UpButton_Click);
            // 
            // dirsListBox
            // 
            this.dirsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dirsListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dirsListBox.FormattingEnabled = true;
            this.dirsListBox.IntegralHeight = false;
            this.dirsListBox.Location = new System.Drawing.Point(10, 32);
            this.dirsListBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dirsListBox.Name = "dirsListBox";
            this.dirsListBox.Size = new System.Drawing.Size(342, 94);
            this.dirsListBox.TabIndex = 1;
            this.dirsListBox.SelectedIndexChanged += new System.EventHandler(this.PathList_SelectedIndexChanged);
            // 
            // stylePanel
            // 
            this.stylePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.stylePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.stylePanel.Controls.Add(this.styleHeading);
            this.stylePanel.Controls.Add(this.styleDropDown);
            this.stylePanel.Location = new System.Drawing.Point(9, 12);
            this.stylePanel.Name = "stylePanel";
            this.stylePanel.Size = new System.Drawing.Size(363, 66);
            this.stylePanel.TabIndex = 6;
            // 
            // styleHeading
            // 
            this.styleHeading.Dock = System.Windows.Forms.DockStyle.Top;
            this.styleHeading.Location = new System.Drawing.Point(0, 0);
            this.styleHeading.Name = "styleHeading";
            this.styleHeading.Size = new System.Drawing.Size(361, 23);
            this.styleHeading.TabIndex = 0;
            this.styleHeading.Text = "default color scheme";
            this.styleHeading.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // miscPanel
            // 
            this.miscPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.miscPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.miscPanel.Controls.Add(this.miscHeading);
            this.miscPanel.Controls.Add(this.useStartPageButton);
            this.miscPanel.Controls.Add(this.rememberProjectButton);
            this.miscPanel.Location = new System.Drawing.Point(9, 84);
            this.miscPanel.Name = "miscPanel";
            this.miscPanel.Size = new System.Drawing.Size(363, 84);
            this.miscPanel.TabIndex = 7;
            // 
            // miscHeading
            // 
            this.miscHeading.Dock = System.Windows.Forms.DockStyle.Top;
            this.miscHeading.Location = new System.Drawing.Point(0, 0);
            this.miscHeading.Name = "miscHeading";
            this.miscHeading.Size = new System.Drawing.Size(361, 23);
            this.miscHeading.TabIndex = 0;
            this.miscHeading.Text = "behavior";
            this.miscHeading.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dirsPanel
            // 
            this.dirsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dirsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dirsPanel.Controls.Add(this.dirsHeading);
            this.dirsPanel.Controls.Add(this.dirsListBox);
            this.dirsPanel.Controls.Add(this.moveDirDownButton);
            this.dirsPanel.Controls.Add(this.moveDirUpButton);
            this.dirsPanel.Controls.Add(this.removeDirButton);
            this.dirsPanel.Controls.Add(this.addDirButton);
            this.dirsPanel.Location = new System.Drawing.Point(9, 174);
            this.dirsPanel.Name = "dirsPanel";
            this.dirsPanel.Size = new System.Drawing.Size(363, 170);
            this.dirsPanel.TabIndex = 8;
            // 
            // dirsHeading
            // 
            this.dirsHeading.Dock = System.Windows.Forms.DockStyle.Top;
            this.dirsHeading.Location = new System.Drawing.Point(0, 0);
            this.dirsHeading.Name = "dirsHeading";
            this.dirsHeading.Size = new System.Drawing.Size(361, 23);
            this.dirsHeading.TabIndex = 0;
            this.dirsHeading.Text = "project directories";
            this.dirsHeading.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // IdeSettingsPage
            // 
            this.Controls.Add(this.dirsPanel);
            this.Controls.Add(this.miscPanel);
            this.Controls.Add(this.stylePanel);
            this.Name = "IdeSettingsPage";
            this.Size = new System.Drawing.Size(382, 370);
            this.stylePanel.ResumeLayout(false);
            this.miscPanel.ResumeLayout(false);
            this.miscPanel.PerformLayout();
            this.dirsPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.CheckBox useStartPageButton;
        private System.Windows.Forms.CheckBox rememberProjectButton;
        private System.Windows.Forms.ComboBox styleDropDown;
        private System.Windows.Forms.Button removeDirButton;
        private System.Windows.Forms.Button addDirButton;
        private System.Windows.Forms.Button moveDirDownButton;
        private System.Windows.Forms.Button moveDirUpButton;
        private System.Windows.Forms.ListBox dirsListBox;
        private System.Windows.Forms.Panel stylePanel;
        private System.Windows.Forms.Label styleHeading;
        private System.Windows.Forms.Panel miscPanel;
        private System.Windows.Forms.Label miscHeading;
        private System.Windows.Forms.Panel dirsPanel;
        private System.Windows.Forms.Label dirsHeading;
    }
}
