namespace SphereStudio.Components
{
    partial class DebugPane
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DebugPane));
            this.listVariables = new System.Windows.Forms.ListView();
            this.columnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitter = new System.Windows.Forms.SplitContainer();
            this.textValue = new System.Windows.Forms.TextBox();
            this.imagesVarList = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitter)).BeginInit();
            this.splitter.Panel1.SuspendLayout();
            this.splitter.Panel2.SuspendLayout();
            this.splitter.SuspendLayout();
            this.SuspendLayout();
            // 
            // listVariables
            // 
            this.listVariables.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnName,
            this.columnValue});
            this.listVariables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listVariables.FullRowSelect = true;
            this.listVariables.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listVariables.Location = new System.Drawing.Point(0, 0);
            this.listVariables.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listVariables.Name = "listVariables";
            this.listVariables.Size = new System.Drawing.Size(387, 231);
            this.listVariables.SmallImageList = this.imagesVarList;
            this.listVariables.TabIndex = 0;
            this.listVariables.UseCompatibleStateImageBehavior = false;
            this.listVariables.View = System.Windows.Forms.View.Details;
            this.listVariables.SelectedIndexChanged += new System.EventHandler(this.listVariables_SelectedIndexChanged);
            // 
            // columnName
            // 
            this.columnName.Text = "Name";
            this.columnName.Width = 100;
            // 
            // columnValue
            // 
            this.columnValue.Text = "Value";
            this.columnValue.Width = 250;
            // 
            // splitter
            // 
            this.splitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitter.Location = new System.Drawing.Point(0, 0);
            this.splitter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitter.Name = "splitter";
            this.splitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitter.Panel1
            // 
            this.splitter.Panel1.Controls.Add(this.listVariables);
            // 
            // splitter.Panel2
            // 
            this.splitter.Panel2.Controls.Add(this.textValue);
            this.splitter.Size = new System.Drawing.Size(387, 654);
            this.splitter.SplitterDistance = 231;
            this.splitter.TabIndex = 1;
            // 
            // textValue
            // 
            this.textValue.BackColor = System.Drawing.Color.Black;
            this.textValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textValue.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textValue.Location = new System.Drawing.Point(0, 0);
            this.textValue.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textValue.Multiline = true;
            this.textValue.Name = "textValue";
            this.textValue.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textValue.Size = new System.Drawing.Size(387, 419);
            this.textValue.TabIndex = 0;
            this.textValue.WordWrap = false;
            // 
            // imagesVarList
            // 
            this.imagesVarList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imagesVarList.ImageStream")));
            this.imagesVarList.TransparentColor = System.Drawing.Color.Transparent;
            this.imagesVarList.Images.SetKeyName(0, "eye.png");
            // 
            // DebugPane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitter);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DebugPane";
            this.Size = new System.Drawing.Size(387, 654);
            this.splitter.Panel1.ResumeLayout(false);
            this.splitter.Panel2.ResumeLayout(false);
            this.splitter.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitter)).EndInit();
            this.splitter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listVariables;
        private System.Windows.Forms.ColumnHeader columnName;
        private System.Windows.Forms.ColumnHeader columnValue;
        private System.Windows.Forms.SplitContainer splitter;
        private System.Windows.Forms.TextBox textValue;
        private System.Windows.Forms.ImageList imagesVarList;
    }
}
