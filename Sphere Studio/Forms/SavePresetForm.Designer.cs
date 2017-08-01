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
            this.presetBox = new System.Windows.Forms.ComboBox();
            this.editorLabel1 = new SphereStudio.UI.DialogHeader();
            this.nameLabel = new System.Windows.Forms.Label();
            this.customNameBox = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // presetBox
            // 
            this.presetBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.presetBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.presetBox.FormattingEnabled = true;
            this.presetBox.Location = new System.Drawing.Point(62, 32);
            this.presetBox.Name = "presetBox";
            this.presetBox.Size = new System.Drawing.Size(311, 21);
            this.presetBox.TabIndex = 3;
            this.presetBox.SelectedIndexChanged += new System.EventHandler(this.presetBox_SelectedIndexChanged);
            // 
            // editorLabel1
            // 
            this.editorLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.editorLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.editorLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.editorLabel1.ForeColor = System.Drawing.Color.White;
            this.editorLabel1.Location = new System.Drawing.Point(0, 0);
            this.editorLabel1.Name = "editorLabel1";
            this.editorLabel1.Size = new System.Drawing.Size(385, 23);
            this.editorLabel1.TabIndex = 0;
            this.editorLabel1.Text = "Save your configuration preset";
            this.editorLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(12, 35);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(44, 13);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "Save as";
            // 
            // customNameBox
            // 
            this.customNameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customNameBox.Location = new System.Drawing.Point(62, 59);
            this.customNameBox.Name = "customNameBox";
            this.customNameBox.Size = new System.Drawing.Size(311, 22);
            this.customNameBox.TabIndex = 2;
            this.customNameBox.TextChanged += new System.EventHandler(this.customNameBox_TextChanged);
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(217, 108);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 4;
            this.okButton.Text = "&Save";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(298, 108);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // SavePresetForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(385, 143);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.customNameBox);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.editorLabel1);
            this.Controls.Add(this.presetBox);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SavePresetForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Save Preset";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox presetBox;
        private SphereStudio.UI.DialogHeader editorLabel1;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox customNameBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
    }
}