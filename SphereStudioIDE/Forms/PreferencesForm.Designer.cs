namespace SphereStudio.Ide.Forms
{
    partial class PreferencesForm
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
            this.splitterBox = new System.Windows.Forms.SplitContainer();
            this.pageList = new System.Windows.Forms.TreeView();
            this.footer = new System.Windows.Forms.Panel();
            this.applyButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.header = new SphereStudio.UI.DialogHeader();
            ((System.ComponentModel.ISupportInitialize)(this.splitterBox)).BeginInit();
            this.splitterBox.Panel1.SuspendLayout();
            this.splitterBox.SuspendLayout();
            this.footer.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitterBox
            // 
            this.splitterBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitterBox.Location = new System.Drawing.Point(0, 23);
            this.splitterBox.Name = "splitterBox";
            // 
            // splitterBox.Panel1
            // 
            this.splitterBox.Panel1.Controls.Add(this.pageList);
            this.splitterBox.Size = new System.Drawing.Size(604, 364);
            this.splitterBox.SplitterDistance = 162;
            this.splitterBox.TabIndex = 2;
            // 
            // pageList
            // 
            this.pageList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pageList.FullRowSelect = true;
            this.pageList.HideSelection = false;
            this.pageList.HotTracking = true;
            this.pageList.Location = new System.Drawing.Point(0, 0);
            this.pageList.Name = "pageList";
            this.pageList.Size = new System.Drawing.Size(162, 364);
            this.pageList.TabIndex = 1;
            this.pageList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.PageTree_AfterSelect);
            this.pageList.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PageTree_MouseMove);
            // 
            // footer
            // 
            this.footer.Controls.Add(this.applyButton);
            this.footer.Controls.Add(this.cancelButton);
            this.footer.Controls.Add(this.okButton);
            this.footer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footer.Location = new System.Drawing.Point(0, 387);
            this.footer.Name = "footer";
            this.footer.Size = new System.Drawing.Size(604, 50);
            this.footer.TabIndex = 3;
            // 
            // applyButton
            // 
            this.applyButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.applyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.applyButton.Location = new System.Drawing.Point(512, 13);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(80, 25);
            this.applyButton.TabIndex = 2;
            this.applyButton.Text = "&Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point(426, 13);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(80, 25);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point(340, 13);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(80, 25);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // header
            // 
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.header.Location = new System.Drawing.Point(0, 0);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(604, 23);
            this.header.TabIndex = 1;
            this.header.Text = "configure the Sphere Studio integrated development environment";
            this.header.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PreferencesForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(604, 437);
            this.Controls.Add(this.splitterBox);
            this.Controls.Add(this.footer);
            this.Controls.Add(this.header);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PreferencesForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Preferences";
            this.splitterBox.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitterBox)).EndInit();
            this.splitterBox.ResumeLayout(false);
            this.footer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitterBox;
        private System.Windows.Forms.TreeView pageList;
        private System.Windows.Forms.Panel footer;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button applyButton;
        private UI.DialogHeader header;
    }
}