namespace SphereStudio.Forms
{
    partial class SettingsCenter
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
            this.HeaderBar = new Sphere.Core.Editor.EditorLabel();
            this.SplitBox = new System.Windows.Forms.SplitContainer();
            this.PageTree = new System.Windows.Forms.TreeView();
            this.ButtonBar = new System.Windows.Forms.Panel();
            this.ApplyButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SplitBox)).BeginInit();
            this.SplitBox.Panel1.SuspendLayout();
            this.SplitBox.SuspendLayout();
            this.ButtonBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // HeaderBar
            // 
            this.HeaderBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.HeaderBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeaderBar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.HeaderBar.ForeColor = System.Drawing.Color.White;
            this.HeaderBar.Location = new System.Drawing.Point(0, 0);
            this.HeaderBar.Name = "HeaderBar";
            this.HeaderBar.Size = new System.Drawing.Size(682, 23);
            this.HeaderBar.TabIndex = 1;
            this.HeaderBar.Text = "Configure your Sphere Studio environment.";
            this.HeaderBar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SplitBox
            // 
            this.SplitBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitBox.Location = new System.Drawing.Point(0, 23);
            this.SplitBox.Name = "SplitBox";
            // 
            // SplitBox.Panel1
            // 
            this.SplitBox.Panel1.Controls.Add(this.PageTree);
            // 
            // SplitBox.Panel2
            // 
            this.SplitBox.Panel2.Padding = new System.Windows.Forms.Padding(5);
            this.SplitBox.Size = new System.Drawing.Size(682, 415);
            this.SplitBox.SplitterDistance = 183;
            this.SplitBox.TabIndex = 2;
            // 
            // PageTree
            // 
            this.PageTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PageTree.FullRowSelect = true;
            this.PageTree.HideSelection = false;
            this.PageTree.Location = new System.Drawing.Point(0, 0);
            this.PageTree.Name = "PageTree";
            this.PageTree.Size = new System.Drawing.Size(183, 415);
            this.PageTree.TabIndex = 1;
            this.PageTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.PageTree_AfterSelect);
            // 
            // ButtonBar
            // 
            this.ButtonBar.Controls.Add(this.ApplyButton);
            this.ButtonBar.Controls.Add(this.CloseButton);
            this.ButtonBar.Controls.Add(this.OKButton);
            this.ButtonBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonBar.Location = new System.Drawing.Point(0, 438);
            this.ButtonBar.Name = "ButtonBar";
            this.ButtonBar.Size = new System.Drawing.Size(682, 37);
            this.ButtonBar.TabIndex = 3;
            // 
            // ApplyButton
            // 
            this.ApplyButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ApplyButton.Location = new System.Drawing.Point(594, 6);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(80, 25);
            this.ApplyButton.TabIndex = 2;
            this.ApplyButton.Text = "&Apply";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseButton.Location = new System.Drawing.Point(508, 6);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(80, 25);
            this.CloseButton.TabIndex = 1;
            this.CloseButton.Text = "Cancel";
            this.CloseButton.UseVisualStyleBackColor = true;
            // 
            // OKButton
            // 
            this.OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKButton.Location = new System.Drawing.Point(422, 6);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(80, 25);
            this.OKButton.TabIndex = 0;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // SettingsCenter
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CloseButton;
            this.ClientSize = new System.Drawing.Size(682, 475);
            this.Controls.Add(this.SplitBox);
            this.Controls.Add(this.ButtonBar);
            this.Controls.Add(this.HeaderBar);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsCenter";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings Center";
            this.SplitBox.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitBox)).EndInit();
            this.SplitBox.ResumeLayout(false);
            this.ButtonBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Sphere.Core.Editor.EditorLabel HeaderBar;
        private System.Windows.Forms.SplitContainer SplitBox;
        private System.Windows.Forms.TreeView PageTree;
        private System.Windows.Forms.Panel ButtonBar;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button ApplyButton;
    }
}