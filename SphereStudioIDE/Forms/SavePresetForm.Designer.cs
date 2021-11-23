namespace SphereStudio.Ide.Forms
{
    partial class SavePresetForm
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
            this.presetDropDown = new System.Windows.Forms.ComboBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.header = new System.Windows.Forms.Label();
            this.footer = new System.Windows.Forms.Panel();
            this.namePanel = new System.Windows.Forms.Panel();
            this.nameHeading = new System.Windows.Forms.Label();
            this.footer.SuspendLayout();
            this.namePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // presetDropDown
            // 
            this.presetDropDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.presetDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.presetDropDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.presetDropDown.FormattingEnabled = true;
            this.presetDropDown.Location = new System.Drawing.Point(57, 32);
            this.presetDropDown.Name = "presetDropDown";
            this.presetDropDown.Size = new System.Drawing.Size(385, 21);
            this.presetDropDown.TabIndex = 3;
            this.presetDropDown.SelectedIndexChanged += new System.EventHandler(this.presetBox_SelectedIndexChanged);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(7, 35);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(44, 13);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "Save as";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameTextBox.Location = new System.Drawing.Point(57, 59);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(385, 22);
            this.nameTextBox.TabIndex = 2;
            this.nameTextBox.TextChanged += new System.EventHandler(this.customNameBox_TextChanged);
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point(310, 13);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 25);
            this.okButton.TabIndex = 4;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point(391, 13);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 25);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // header
            // 
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.Location = new System.Drawing.Point(0, 0);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(478, 23);
            this.header.TabIndex = 6;
            this.header.Text = "save your plugin configuration as a preset";
            this.header.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // footer
            // 
            this.footer.Controls.Add(this.okButton);
            this.footer.Controls.Add(this.cancelButton);
            this.footer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footer.Location = new System.Drawing.Point(0, 142);
            this.footer.Name = "footer";
            this.footer.Size = new System.Drawing.Size(478, 50);
            this.footer.TabIndex = 7;
            // 
            // namePanel
            // 
            this.namePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.namePanel.Controls.Add(this.nameHeading);
            this.namePanel.Controls.Add(this.nameLabel);
            this.namePanel.Controls.Add(this.presetDropDown);
            this.namePanel.Controls.Add(this.nameTextBox);
            this.namePanel.Location = new System.Drawing.Point(12, 35);
            this.namePanel.Name = "namePanel";
            this.namePanel.Size = new System.Drawing.Size(454, 95);
            this.namePanel.TabIndex = 8;
            // 
            // nameHeading
            // 
            this.nameHeading.Dock = System.Windows.Forms.DockStyle.Top;
            this.nameHeading.Location = new System.Drawing.Point(0, 0);
            this.nameHeading.Name = "nameHeading";
            this.nameHeading.Size = new System.Drawing.Size(452, 23);
            this.nameHeading.TabIndex = 7;
            this.nameHeading.Text = "Preset Name";
            this.nameHeading.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SavePresetForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(478, 192);
            this.Controls.Add(this.namePanel);
            this.Controls.Add(this.footer);
            this.Controls.Add(this.header);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SavePresetForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Save Preset";
            this.footer.ResumeLayout(false);
            this.namePanel.ResumeLayout(false);
            this.namePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox presetDropDown;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label header;
        private System.Windows.Forms.Panel footer;
        private System.Windows.Forms.Panel namePanel;
        private System.Windows.Forms.Label nameHeading;
    }
}