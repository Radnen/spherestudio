namespace SphereStudio.Plugins.Components
{
    partial class QuickFind
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
            this.findTextBox = new System.Windows.Forms.TextBox();
            this.findButton = new System.Windows.Forms.Button();
            this.matchCaseButton = new System.Windows.Forms.CheckBox();
            this.wholeWordButton = new System.Windows.Forms.CheckBox();
            this.regexButton = new System.Windows.Forms.CheckBox();
            this.replaceButton = new System.Windows.Forms.Button();
            this.replaceTextBox = new System.Windows.Forms.TextBox();
            this.replaceAllButton = new System.Windows.Forms.Button();
            this.optionsPanel = new System.Windows.Forms.Panel();
            this.optionsHeading = new System.Windows.Forms.Label();
            this.optionsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // findTextBox
            // 
            this.findTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.findTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.findTextBox.Location = new System.Drawing.Point(6, 6);
            this.findTextBox.Name = "findTextBox";
            this.findTextBox.Size = new System.Drawing.Size(248, 23);
            this.findTextBox.TabIndex = 0;
            this.findTextBox.TextChanged += new System.EventHandler(this.FindTextBox_TextChanged);
            this.findTextBox.Enter += new System.EventHandler(this.FindTextBox_Enter);
            this.findTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FindTextBox_KeyPress);
            // 
            // findButton
            // 
            this.findButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.findButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.findButton.Location = new System.Drawing.Point(254, 5);
            this.findButton.Name = "findButton";
            this.findButton.Size = new System.Drawing.Size(50, 25);
            this.findButton.TabIndex = 4;
            this.findButton.TabStop = false;
            this.findButton.Text = "&Find";
            this.findButton.UseVisualStyleBackColor = true;
            this.findButton.Click += new System.EventHandler(this.FindButton_Click);
            // 
            // matchCaseButton
            // 
            this.matchCaseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.matchCaseButton.AutoSize = true;
            this.matchCaseButton.Location = new System.Drawing.Point(135, 4);
            this.matchCaseButton.Name = "matchCaseButton";
            this.matchCaseButton.Size = new System.Drawing.Size(51, 19);
            this.matchCaseButton.TabIndex = 1;
            this.matchCaseButton.TabStop = false;
            this.matchCaseButton.Text = "&Case";
            this.matchCaseButton.UseVisualStyleBackColor = true;
            this.matchCaseButton.CheckedChanged += new System.EventHandler(this.MatchCaseCheckBox_CheckedChanged);
            // 
            // wholeWordButton
            // 
            this.wholeWordButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.wholeWordButton.AutoSize = true;
            this.wholeWordButton.Location = new System.Drawing.Point(189, 4);
            this.wholeWordButton.Name = "wholeWordButton";
            this.wholeWordButton.Size = new System.Drawing.Size(55, 19);
            this.wholeWordButton.TabIndex = 2;
            this.wholeWordButton.TabStop = false;
            this.wholeWordButton.Text = "&Word";
            this.wholeWordButton.UseVisualStyleBackColor = true;
            this.wholeWordButton.CheckedChanged += new System.EventHandler(this.WholeWordCheckBox_CheckedChanged);
            // 
            // regexButton
            // 
            this.regexButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.regexButton.AutoSize = true;
            this.regexButton.Location = new System.Drawing.Point(246, 4);
            this.regexButton.Name = "regexButton";
            this.regexButton.Size = new System.Drawing.Size(58, 19);
            this.regexButton.TabIndex = 3;
            this.regexButton.TabStop = false;
            this.regexButton.Text = "Reg&Ex";
            this.regexButton.UseVisualStyleBackColor = true;
            this.regexButton.CheckedChanged += new System.EventHandler(this.RegexCheckBox_CheckedChanged);
            // 
            // replaceButton
            // 
            this.replaceButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.replaceButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.replaceButton.Location = new System.Drawing.Point(214, 29);
            this.replaceButton.Name = "replaceButton";
            this.replaceButton.Size = new System.Drawing.Size(48, 25);
            this.replaceButton.TabIndex = 6;
            this.replaceButton.TabStop = false;
            this.replaceButton.Text = "&Repl";
            this.replaceButton.UseVisualStyleBackColor = true;
            this.replaceButton.Click += new System.EventHandler(this.ReplaceButton_Click);
            // 
            // replaceTextBox
            // 
            this.replaceTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.replaceTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.replaceTextBox.Location = new System.Drawing.Point(6, 30);
            this.replaceTextBox.Name = "replaceTextBox";
            this.replaceTextBox.Size = new System.Drawing.Size(208, 23);
            this.replaceTextBox.TabIndex = 5;
            this.replaceTextBox.Enter += new System.EventHandler(this.ReplaceTextBox_Enter);
            this.replaceTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ReplaceTextBox_KeyPress);
            // 
            // replaceAllButton
            // 
            this.replaceAllButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.replaceAllButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.replaceAllButton.Location = new System.Drawing.Point(261, 29);
            this.replaceAllButton.Name = "replaceAllButton";
            this.replaceAllButton.Size = new System.Drawing.Size(43, 25);
            this.replaceAllButton.TabIndex = 7;
            this.replaceAllButton.TabStop = false;
            this.replaceAllButton.Text = "&All";
            this.replaceAllButton.UseVisualStyleBackColor = true;
            this.replaceAllButton.Click += new System.EventHandler(this.ReplaceAllButton_Click);
            // 
            // optionsPanel
            // 
            this.optionsPanel.Controls.Add(this.optionsHeading);
            this.optionsPanel.Controls.Add(this.matchCaseButton);
            this.optionsPanel.Controls.Add(this.wholeWordButton);
            this.optionsPanel.Controls.Add(this.regexButton);
            this.optionsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.optionsPanel.Location = new System.Drawing.Point(0, 61);
            this.optionsPanel.Name = "optionsPanel";
            this.optionsPanel.Size = new System.Drawing.Size(310, 27);
            this.optionsPanel.TabIndex = 8;
            // 
            // optionsHeading
            // 
            this.optionsHeading.AutoSize = true;
            this.optionsHeading.ForeColor = System.Drawing.SystemColors.GrayText;
            this.optionsHeading.Location = new System.Drawing.Point(6, 6);
            this.optionsHeading.Name = "optionsHeading";
            this.optionsHeading.Size = new System.Drawing.Size(64, 15);
            this.optionsHeading.TabIndex = 4;
            this.optionsHeading.Text = "Quick Find";
            // 
            // QuickFind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.optionsPanel);
            this.Controls.Add(this.replaceAllButton);
            this.Controls.Add(this.replaceButton);
            this.Controls.Add(this.replaceTextBox);
            this.Controls.Add(this.findButton);
            this.Controls.Add(this.findTextBox);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "QuickFind";
            this.Size = new System.Drawing.Size(310, 88);
            this.optionsPanel.ResumeLayout(false);
            this.optionsPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox findTextBox;
        private System.Windows.Forms.Button findButton;
        private System.Windows.Forms.CheckBox matchCaseButton;
        private System.Windows.Forms.CheckBox wholeWordButton;
        private System.Windows.Forms.CheckBox regexButton;
        private System.Windows.Forms.Button replaceButton;
        private System.Windows.Forms.TextBox replaceTextBox;
        private System.Windows.Forms.Button replaceAllButton;
        private System.Windows.Forms.Panel optionsPanel;
        private System.Windows.Forms.Label optionsHeading;
    }
}
