namespace Sphere_Editor.Forms
{
    partial class TriggerForm
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
            this.SaveButton = new System.Windows.Forms.Button();
            this.CancelFormButton = new System.Windows.Forms.Button();
            this.FunctionPanel = new System.Windows.Forms.Panel();
            this.LayerLabel = new System.Windows.Forms.Label();
            this.LayerComboBox = new System.Windows.Forms.ComboBox();
            this.FunctionLabel = new System.Windows.Forms.Label();
            this.FunctionPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.SaveButton.Location = new System.Drawing.Point(305, 12);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 0;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CancelFormButton
            // 
            this.CancelFormButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelFormButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelFormButton.Location = new System.Drawing.Point(305, 41);
            this.CancelFormButton.Name = "CancelFormButton";
            this.CancelFormButton.Size = new System.Drawing.Size(75, 23);
            this.CancelFormButton.TabIndex = 1;
            this.CancelFormButton.Text = "Cancel";
            this.CancelFormButton.UseVisualStyleBackColor = true;
            // 
            // FunctionPanel
            // 
            this.FunctionPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.FunctionPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FunctionPanel.Location = new System.Drawing.Point(12, 70);
            this.FunctionPanel.Name = "FunctionPanel";
            this.FunctionPanel.Size = new System.Drawing.Size(368, 186);
            this.FunctionPanel.TabIndex = 3;
            // 
            // LayerLabel
            // 
            this.LayerLabel.AutoSize = true;
            this.LayerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LayerLabel.Location = new System.Drawing.Point(9, 15);
            this.LayerLabel.Name = "LayerLabel";
            this.LayerLabel.Size = new System.Drawing.Size(42, 13);
            this.LayerLabel.TabIndex = 4;
            this.LayerLabel.Text = "Layer:";
            // 
            // LayerComboBox
            // 
            this.LayerComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.LayerComboBox.FormattingEnabled = true;
            this.LayerComboBox.Location = new System.Drawing.Point(57, 12);
            this.LayerComboBox.Name = "LayerComboBox";
            this.LayerComboBox.Size = new System.Drawing.Size(242, 21);
            this.LayerComboBox.TabIndex = 5;
            this.LayerComboBox.SelectedIndexChanged += new System.EventHandler(this.LayerComboBox_SelectedIndexChanged);
            // 
            // FunctionLabel
            // 
            this.FunctionLabel.AutoSize = true;
            this.FunctionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FunctionLabel.Location = new System.Drawing.Point(10, 46);
            this.FunctionLabel.Name = "FunctionLabel";
            this.FunctionLabel.Size = new System.Drawing.Size(60, 13);
            this.FunctionLabel.TabIndex = 6;
            this.FunctionLabel.Text = "Function:";
            // 
            // TriggerForm
            // 
            this.AcceptButton = this.SaveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelFormButton;
            this.ClientSize = new System.Drawing.Size(392, 268);
            this.Controls.Add(this.FunctionLabel);
            this.Controls.Add(this.LayerComboBox);
            this.Controls.Add(this.LayerLabel);
            this.Controls.Add(this.FunctionPanel);
            this.Controls.Add(this.CancelFormButton);
            this.Controls.Add(this.SaveButton);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(250, 200);
            this.Name = "TriggerForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Trigger Editor";
            this.Load += new System.EventHandler(this.TriggerForm_Load);
            this.FunctionPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button CancelFormButton;
        private System.Windows.Forms.Panel FunctionPanel;
        private System.Windows.Forms.Label LayerLabel;
        private System.Windows.Forms.ComboBox LayerComboBox;
        private System.Windows.Forms.Label FunctionLabel;
    }
}