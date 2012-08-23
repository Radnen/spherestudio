namespace Sphere_Editor.Forms
{
    partial class ZoneForm
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
            this.OkayButton = new System.Windows.Forms.Button();
            this.CancelFormButton = new System.Windows.Forms.Button();
            this.LayerComboBox = new System.Windows.Forms.ComboBox();
            this.LayerLabel = new System.Windows.Forms.Label();
            this.StepLabel = new System.Windows.Forms.Label();
            this.StepTextBox = new System.Windows.Forms.TextBox();
            this.ScriptPanel = new System.Windows.Forms.Panel();
            this.FunctionLabel = new System.Windows.Forms.Label();
            this.PositionLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // OkayButton
            // 
            this.OkayButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OkayButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkayButton.Location = new System.Drawing.Point(305, 12);
            this.OkayButton.Name = "OkayButton";
            this.OkayButton.Size = new System.Drawing.Size(75, 23);
            this.OkayButton.TabIndex = 0;
            this.OkayButton.Text = "Okay";
            this.OkayButton.UseVisualStyleBackColor = true;
            this.OkayButton.Click += new System.EventHandler(this.OkayButton_Click);
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
            // LayerComboBox
            // 
            this.LayerComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.LayerComboBox.FormattingEnabled = true;
            this.LayerComboBox.Location = new System.Drawing.Point(60, 12);
            this.LayerComboBox.Name = "LayerComboBox";
            this.LayerComboBox.Size = new System.Drawing.Size(239, 21);
            this.LayerComboBox.TabIndex = 3;
            this.LayerComboBox.SelectedIndexChanged += new System.EventHandler(this.LayerComboBox_SelectedIndexChanged);
            // 
            // LayerLabel
            // 
            this.LayerLabel.AutoSize = true;
            this.LayerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LayerLabel.Location = new System.Drawing.Point(12, 15);
            this.LayerLabel.Name = "LayerLabel";
            this.LayerLabel.Size = new System.Drawing.Size(42, 13);
            this.LayerLabel.TabIndex = 4;
            this.LayerLabel.Text = "Layer:";
            // 
            // StepLabel
            // 
            this.StepLabel.AutoSize = true;
            this.StepLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StepLabel.Location = new System.Drawing.Point(12, 46);
            this.StepLabel.Name = "StepLabel";
            this.StepLabel.Size = new System.Drawing.Size(43, 13);
            this.StepLabel.TabIndex = 5;
            this.StepLabel.Text = "Steps:";
            // 
            // StepTextBox
            // 
            this.StepTextBox.Location = new System.Drawing.Point(61, 43);
            this.StepTextBox.Name = "StepTextBox";
            this.StepTextBox.Size = new System.Drawing.Size(42, 20);
            this.StepTextBox.TabIndex = 6;
            this.StepTextBox.WordWrap = false;
            this.StepTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // ScriptPanel
            // 
            this.ScriptPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ScriptPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ScriptPanel.Location = new System.Drawing.Point(12, 86);
            this.ScriptPanel.Name = "ScriptPanel";
            this.ScriptPanel.Size = new System.Drawing.Size(368, 170);
            this.ScriptPanel.TabIndex = 7;
            // 
            // FunctionLabel
            // 
            this.FunctionLabel.AutoSize = true;
            this.FunctionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FunctionLabel.Location = new System.Drawing.Point(12, 70);
            this.FunctionLabel.Name = "FunctionLabel";
            this.FunctionLabel.Size = new System.Drawing.Size(60, 13);
            this.FunctionLabel.TabIndex = 8;
            this.FunctionLabel.Text = "Function:";
            // 
            // PositionLabel
            // 
            this.PositionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.PositionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PositionLabel.Location = new System.Drawing.Point(109, 46);
            this.PositionLabel.Name = "PositionLabel";
            this.PositionLabel.Size = new System.Drawing.Size(190, 23);
            this.PositionLabel.TabIndex = 9;
            this.PositionLabel.Text = "(X: 0, Y: 0)";
            this.PositionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ZoneForm
            // 
            this.AcceptButton = this.OkayButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelFormButton;
            this.ClientSize = new System.Drawing.Size(392, 268);
            this.Controls.Add(this.PositionLabel);
            this.Controls.Add(this.FunctionLabel);
            this.Controls.Add(this.ScriptPanel);
            this.Controls.Add(this.StepTextBox);
            this.Controls.Add(this.StepLabel);
            this.Controls.Add(this.LayerLabel);
            this.Controls.Add(this.LayerComboBox);
            this.Controls.Add(this.CancelFormButton);
            this.Controls.Add(this.OkayButton);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(320, 240);
            this.Name = "ZoneForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Zone Editor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OkayButton;
        private System.Windows.Forms.Button CancelFormButton;
        private System.Windows.Forms.ComboBox LayerComboBox;
        private System.Windows.Forms.Label LayerLabel;
        private System.Windows.Forms.Label StepLabel;
        private System.Windows.Forms.TextBox StepTextBox;
        private System.Windows.Forms.Panel ScriptPanel;
        private System.Windows.Forms.Label FunctionLabel;
        private System.Windows.Forms.Label PositionLabel;
    }
}