namespace SphereStudio.UI
{
    partial class StringInputForm
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
            this.m_textBox = new System.Windows.Forms.TextBox();
            this.m_okButton = new System.Windows.Forms.Button();
            this.m_cancelButton = new System.Windows.Forms.Button();
            this.m_heading = new SphereStudio.UI.DialogHeader();
            this.SuspendLayout();
            // 
            // m_textBox
            // 
            this.m_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_textBox.Location = new System.Drawing.Point(12, 37);
            this.m_textBox.Name = "m_textBox";
            this.m_textBox.Size = new System.Drawing.Size(313, 20);
            this.m_textBox.TabIndex = 1;
            this.m_textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.StringTextBox_KeyPress);
            // 
            // m_okButton
            // 
            this.m_okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.m_okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_okButton.Location = new System.Drawing.Point(169, 68);
            this.m_okButton.Name = "m_okButton";
            this.m_okButton.Size = new System.Drawing.Size(75, 23);
            this.m_okButton.TabIndex = 2;
            this.m_okButton.Text = "OK";
            this.m_okButton.UseVisualStyleBackColor = true;
            // 
            // m_cancelButton
            // 
            this.m_cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cancelButton.Location = new System.Drawing.Point(250, 68);
            this.m_cancelButton.Name = "m_cancelButton";
            this.m_cancelButton.Size = new System.Drawing.Size(75, 23);
            this.m_cancelButton.TabIndex = 3;
            this.m_cancelButton.Text = "Cancel";
            this.m_cancelButton.UseVisualStyleBackColor = true;
            // 
            // m_heading
            // 
            this.m_heading.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_heading.Location = new System.Drawing.Point(0, 0);
            this.m_heading.Name = "m_heading";
            this.m_heading.Size = new System.Drawing.Size(337, 23);
            this.m_heading.TabIndex = 4;
            this.m_heading.Text = "Please enter the new value";
            this.m_heading.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StringInputForm
            // 
            this.AcceptButton = this.m_okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.m_cancelButton;
            this.ClientSize = new System.Drawing.Size(337, 103);
            this.Controls.Add(this.m_heading);
            this.Controls.Add(this.m_cancelButton);
            this.Controls.Add(this.m_okButton);
            this.Controls.Add(this.m_textBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StringInputForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Set Value";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox m_textBox;
        private System.Windows.Forms.Button m_okButton;
        private System.Windows.Forms.Button m_cancelButton;
        private DialogHeader m_heading;
    }
}