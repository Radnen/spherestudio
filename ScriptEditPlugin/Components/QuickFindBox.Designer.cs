namespace SphereStudio.ScriptEditor.Components
{
    partial class QuickFindBox
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
            this.FindTextBox = new System.Windows.Forms.TextBox();
            this.FindButton = new System.Windows.Forms.Button();
            this.MatchCaseCheckBox = new System.Windows.Forms.CheckBox();
            this.WholeWordCheckBox = new System.Windows.Forms.CheckBox();
            this.RegexCheckBox = new System.Windows.Forms.CheckBox();
            this.ReplaceButton = new System.Windows.Forms.Button();
            this.ReplaceTextBox = new System.Windows.Forms.TextBox();
            this.ReplaceAllButton = new System.Windows.Forms.Button();
            this.OptionsPanel = new System.Windows.Forms.Panel();
            this.OptionsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // FindTextBox
            // 
            this.FindTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FindTextBox.Location = new System.Drawing.Point(5, 5);
            this.FindTextBox.Name = "FindTextBox";
            this.FindTextBox.Size = new System.Drawing.Size(213, 20);
            this.FindTextBox.TabIndex = 0;
            this.FindTextBox.TextChanged += new System.EventHandler(this.FindTextBox_TextChanged);
            this.FindTextBox.Enter += new System.EventHandler(this.FindTextBox_Enter);
            this.FindTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FindTextBox_KeyPress);
            // 
            // FindButton
            // 
            this.FindButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FindButton.Location = new System.Drawing.Point(218, 4);
            this.FindButton.Name = "FindButton";
            this.FindButton.Size = new System.Drawing.Size(43, 22);
            this.FindButton.TabIndex = 4;
            this.FindButton.TabStop = false;
            this.FindButton.Text = "&Find";
            this.FindButton.UseVisualStyleBackColor = true;
            this.FindButton.Click += new System.EventHandler(this.FindButton_Click);
            // 
            // MatchCaseCheckBox
            // 
            this.MatchCaseCheckBox.AutoSize = true;
            this.MatchCaseCheckBox.Location = new System.Drawing.Point(5, 4);
            this.MatchCaseCheckBox.Name = "MatchCaseCheckBox";
            this.MatchCaseCheckBox.Size = new System.Drawing.Size(83, 17);
            this.MatchCaseCheckBox.TabIndex = 1;
            this.MatchCaseCheckBox.TabStop = false;
            this.MatchCaseCheckBox.Text = "Match &Case";
            this.MatchCaseCheckBox.UseVisualStyleBackColor = true;
            this.MatchCaseCheckBox.CheckedChanged += new System.EventHandler(this.MatchCaseCheckBox_CheckedChanged);
            // 
            // WholeWordCheckBox
            // 
            this.WholeWordCheckBox.AutoSize = true;
            this.WholeWordCheckBox.Location = new System.Drawing.Point(95, 4);
            this.WholeWordCheckBox.Name = "WholeWordCheckBox";
            this.WholeWordCheckBox.Size = new System.Drawing.Size(86, 17);
            this.WholeWordCheckBox.TabIndex = 2;
            this.WholeWordCheckBox.TabStop = false;
            this.WholeWordCheckBox.Text = "Whole &Word";
            this.WholeWordCheckBox.UseVisualStyleBackColor = true;
            this.WholeWordCheckBox.CheckedChanged += new System.EventHandler(this.WholeWordCheckBox_CheckedChanged);
            // 
            // RegexCheckBox
            // 
            this.RegexCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RegexCheckBox.AutoSize = true;
            this.RegexCheckBox.Location = new System.Drawing.Point(205, 4);
            this.RegexCheckBox.Name = "RegexCheckBox";
            this.RegexCheckBox.Size = new System.Drawing.Size(58, 17);
            this.RegexCheckBox.TabIndex = 3;
            this.RegexCheckBox.TabStop = false;
            this.RegexCheckBox.Text = "Reg&Ex";
            this.RegexCheckBox.UseVisualStyleBackColor = true;
            this.RegexCheckBox.CheckedChanged += new System.EventHandler(this.RegexCheckBox_CheckedChanged);
            // 
            // ReplaceButton
            // 
            this.ReplaceButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ReplaceButton.Location = new System.Drawing.Point(183, 25);
            this.ReplaceButton.Name = "ReplaceButton";
            this.ReplaceButton.Size = new System.Drawing.Size(42, 22);
            this.ReplaceButton.TabIndex = 6;
            this.ReplaceButton.TabStop = false;
            this.ReplaceButton.Text = "&Repl";
            this.ReplaceButton.UseVisualStyleBackColor = true;
            this.ReplaceButton.Click += new System.EventHandler(this.ReplaceButton_Click);
            // 
            // ReplaceTextBox
            // 
            this.ReplaceTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ReplaceTextBox.Location = new System.Drawing.Point(5, 26);
            this.ReplaceTextBox.Name = "ReplaceTextBox";
            this.ReplaceTextBox.Size = new System.Drawing.Size(178, 20);
            this.ReplaceTextBox.TabIndex = 5;
            this.ReplaceTextBox.Enter += new System.EventHandler(this.ReplaceTextBox_Enter);
            this.ReplaceTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ReplaceTextBox_KeyPress);
            // 
            // ReplaceAllButton
            // 
            this.ReplaceAllButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ReplaceAllButton.Location = new System.Drawing.Point(224, 25);
            this.ReplaceAllButton.Name = "ReplaceAllButton";
            this.ReplaceAllButton.Size = new System.Drawing.Size(37, 22);
            this.ReplaceAllButton.TabIndex = 7;
            this.ReplaceAllButton.TabStop = false;
            this.ReplaceAllButton.Text = "&All";
            this.ReplaceAllButton.UseVisualStyleBackColor = true;
            this.ReplaceAllButton.Click += new System.EventHandler(this.ReplaceAllButton_Click);
            // 
            // OptionsPanel
            // 
            this.OptionsPanel.Controls.Add(this.MatchCaseCheckBox);
            this.OptionsPanel.Controls.Add(this.WholeWordCheckBox);
            this.OptionsPanel.Controls.Add(this.RegexCheckBox);
            this.OptionsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.OptionsPanel.Location = new System.Drawing.Point(0, 53);
            this.OptionsPanel.Name = "OptionsPanel";
            this.OptionsPanel.Size = new System.Drawing.Size(266, 24);
            this.OptionsPanel.TabIndex = 8;
            // 
            // QuickFindBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.OptionsPanel);
            this.Controls.Add(this.ReplaceAllButton);
            this.Controls.Add(this.ReplaceButton);
            this.Controls.Add(this.ReplaceTextBox);
            this.Controls.Add(this.FindButton);
            this.Controls.Add(this.FindTextBox);
            this.Name = "QuickFindBox";
            this.Size = new System.Drawing.Size(266, 77);
            this.OptionsPanel.ResumeLayout(false);
            this.OptionsPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FindTextBox;
        private System.Windows.Forms.Button FindButton;
        private System.Windows.Forms.CheckBox MatchCaseCheckBox;
        private System.Windows.Forms.CheckBox WholeWordCheckBox;
        private System.Windows.Forms.CheckBox RegexCheckBox;
        private System.Windows.Forms.Button ReplaceButton;
        private System.Windows.Forms.TextBox ReplaceTextBox;
        private System.Windows.Forms.Button ReplaceAllButton;
        private System.Windows.Forms.Panel OptionsPanel;
    }
}
