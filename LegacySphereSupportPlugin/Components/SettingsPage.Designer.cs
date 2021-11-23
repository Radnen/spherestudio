namespace SphereStudio.Plugins.Components
{
    partial class SettingsPage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsPage));
            this.configEngineButton = new System.Windows.Forms.Button();
            this.browseDirButton = new System.Windows.Forms.Button();
            this.enginePathTextBox = new System.Windows.Forms.TextBox();
            this.PathLabel = new System.Windows.Forms.Label();
            this.directoryPanel = new System.Windows.Forms.Panel();
            this.directoryHeading = new System.Windows.Forms.Label();
            this.directoryPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // configEngineButton
            // 
            this.configEngineButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.configEngineButton.Enabled = false;
            this.configEngineButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.configEngineButton.Image = global::SphereStudio.Plugins.Properties.Resources.ConfigIcon;
            this.configEngineButton.Location = new System.Drawing.Point(403, 58);
            this.configEngineButton.Name = "configEngineButton";
            this.configEngineButton.Size = new System.Drawing.Size(25, 25);
            this.configEngineButton.TabIndex = 0;
            this.configEngineButton.UseVisualStyleBackColor = true;
            this.configEngineButton.Click += new System.EventHandler(this.ConfigButton_Click);
            // 
            // browseDirButton
            // 
            this.browseDirButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browseDirButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.browseDirButton.Image = ((System.Drawing.Image)(resources.GetObject("browseDirButton.Image")));
            this.browseDirButton.Location = new System.Drawing.Point(434, 58);
            this.browseDirButton.Name = "browseDirButton";
            this.browseDirButton.Size = new System.Drawing.Size(80, 25);
            this.browseDirButton.TabIndex = 4;
            this.browseDirButton.Text = "Browse...";
            this.browseDirButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.browseDirButton.UseVisualStyleBackColor = true;
            this.browseDirButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // enginePathTextBox
            // 
            this.enginePathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.enginePathTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.enginePathTextBox.Location = new System.Drawing.Point(65, 32);
            this.enginePathTextBox.Name = "enginePathTextBox";
            this.enginePathTextBox.Size = new System.Drawing.Size(449, 20);
            this.enginePathTextBox.TabIndex = 2;
            this.enginePathTextBox.TextChanged += new System.EventHandler(this.SpherePath_TextChanged);
            // 
            // PathLabel
            // 
            this.PathLabel.AutoSize = true;
            this.PathLabel.Location = new System.Drawing.Point(10, 34);
            this.PathLabel.Name = "PathLabel";
            this.PathLabel.Size = new System.Drawing.Size(49, 13);
            this.PathLabel.TabIndex = 0;
            this.PathLabel.Text = "Directory";
            // 
            // directoryPanel
            // 
            this.directoryPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.directoryPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.directoryPanel.Controls.Add(this.configEngineButton);
            this.directoryPanel.Controls.Add(this.directoryHeading);
            this.directoryPanel.Controls.Add(this.browseDirButton);
            this.directoryPanel.Controls.Add(this.enginePathTextBox);
            this.directoryPanel.Controls.Add(this.PathLabel);
            this.directoryPanel.Location = new System.Drawing.Point(9, 12);
            this.directoryPanel.Name = "directoryPanel";
            this.directoryPanel.Size = new System.Drawing.Size(526, 94);
            this.directoryPanel.TabIndex = 5;
            // 
            // directoryHeading
            // 
            this.directoryHeading.Dock = System.Windows.Forms.DockStyle.Top;
            this.directoryHeading.Location = new System.Drawing.Point(0, 0);
            this.directoryHeading.Name = "directoryHeading";
            this.directoryHeading.Size = new System.Drawing.Size(524, 23);
            this.directoryHeading.TabIndex = 0;
            this.directoryHeading.Text = "Engine Executables";
            this.directoryHeading.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SettingsPage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.Controls.Add(this.directoryPanel);
            this.Name = "SettingsPage";
            this.Size = new System.Drawing.Size(545, 280);
            this.directoryPanel.ResumeLayout(false);
            this.directoryPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button configEngineButton;
        private System.Windows.Forms.Button browseDirButton;
        private System.Windows.Forms.TextBox enginePathTextBox;
        private System.Windows.Forms.Label PathLabel;
        private System.Windows.Forms.Panel directoryPanel;
        private System.Windows.Forms.Label directoryHeading;
    }
}
