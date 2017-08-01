namespace SphereStudio.Plugins.Components
{
    partial class EntityControl
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
            this.EntityListView = new System.Windows.Forms.ListView();
            this.NameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LayerHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TypeHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EntityListLabel = new SphereStudio.UI.DialogHeader();
            this.SuspendLayout();
            // 
            // EntityListView
            // 
            this.EntityListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameHeader,
            this.LayerHeader,
            this.TypeHeader});
            this.EntityListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EntityListView.FullRowSelect = true;
            this.EntityListView.Location = new System.Drawing.Point(0, 23);
            this.EntityListView.MultiSelect = false;
            this.EntityListView.Name = "EntityListView";
            this.EntityListView.Size = new System.Drawing.Size(280, 291);
            this.EntityListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.EntityListView.TabIndex = 0;
            this.EntityListView.UseCompatibleStateImageBehavior = false;
            this.EntityListView.View = System.Windows.Forms.View.Details;
            this.EntityListView.ItemActivate += new System.EventHandler(this.EntityListView_ItemActivate);
            // 
            // NameHeader
            // 
            this.NameHeader.Text = "Name";
            this.NameHeader.Width = 123;
            // 
            // LayerHeader
            // 
            this.LayerHeader.Text = "Layer";
            this.LayerHeader.Width = 48;
            // 
            // TypeHeader
            // 
            this.TypeHeader.Text = "Type";
            this.TypeHeader.Width = 99;
            // 
            // EntityListLabel
            // 
            this.EntityListLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.EntityListLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.EntityListLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.EntityListLabel.ForeColor = System.Drawing.Color.White;
            this.EntityListLabel.Location = new System.Drawing.Point(0, 0);
            this.EntityListLabel.Name = "EntityListLabel";
            this.EntityListLabel.Size = new System.Drawing.Size(280, 23);
            this.EntityListLabel.TabIndex = 1;
            this.EntityListLabel.Text = "Entity List";
            this.EntityListLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EntityControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.EntityListView);
            this.Controls.Add(this.EntityListLabel);
            this.Name = "EntityControl";
            this.Size = new System.Drawing.Size(280, 314);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView EntityListView;
        private SphereStudio.UI.DialogHeader EntityListLabel;
        private System.Windows.Forms.ColumnHeader NameHeader;
        private System.Windows.Forms.ColumnHeader LayerHeader;
        private System.Windows.Forms.ColumnHeader TypeHeader;
    }
}
