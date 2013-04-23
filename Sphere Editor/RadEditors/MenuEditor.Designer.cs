namespace Sphere_Editor.RadEditors
{
    partial class StateEditor
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
            this.PreviewHolder = new Sphere.Core.Editor.EditorPanel();
            this.ScreenPanel = new System.Windows.Forms.Panel();
            this.base_panel = new System.Windows.Forms.Panel();
            this.ObjectPanel = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.DescLabel = new System.Windows.Forms.Label();
            this.ButtonFlowLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.PanelButton = new System.Windows.Forms.Button();
            this.LabelButton = new System.Windows.Forms.Button();
            this.ButtonButton = new System.Windows.Forms.Button();
            this.ImageButton = new System.Windows.Forms.Button();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.NameLabel = new System.Windows.Forms.Label();
            this.ObjectLabel = new Sphere.Core.Editor.EditorLabel();
            this.MainSplitter2 = new System.Windows.Forms.SplitContainer();
            this.PreviewPanel = new System.Windows.Forms.Panel();
            this.PreviewLabel = new Sphere.Core.Editor.EditorLabel();
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.ObjectPage = new System.Windows.Forms.TabPage();
            this.CodePage = new System.Windows.Forms.TabPage();
            this.MainSplitter = new System.Windows.Forms.SplitContainer();
            this.MainPropGrid = new System.Windows.Forms.PropertyGrid();
            this.PreviewHolder.SuspendLayout();
            this.ScreenPanel.SuspendLayout();
            this.ObjectPanel.SuspendLayout();
            this.ButtonFlowLayout.SuspendLayout();
            this.MainSplitter2.Panel1.SuspendLayout();
            this.MainSplitter2.Panel2.SuspendLayout();
            this.MainSplitter2.SuspendLayout();
            this.PreviewPanel.SuspendLayout();
            this.MainTabControl.SuspendLayout();
            this.ObjectPage.SuspendLayout();
            this.MainSplitter.Panel1.SuspendLayout();
            this.MainSplitter.Panel2.SuspendLayout();
            this.MainSplitter.SuspendLayout();
            this.SuspendLayout();
            // 
            // PreviewHolder
            // 
            this.PreviewHolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(54)))), ((int)(((byte)(73)))));
            this.PreviewHolder.Controls.Add(this.ScreenPanel);
            this.PreviewHolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PreviewHolder.Location = new System.Drawing.Point(0, 23);
            this.PreviewHolder.Name = "PreviewHolder";
            this.PreviewHolder.Size = new System.Drawing.Size(587, 170);
            this.PreviewHolder.TabIndex = 0;
            this.PreviewHolder.XSnap = 0;
            this.PreviewHolder.YSnap = 0;
            // 
            // ScreenPanel
            // 
            this.ScreenPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ScreenPanel.BackColor = System.Drawing.Color.Black;
            this.ScreenPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ScreenPanel.Controls.Add(this.base_panel);
            this.ScreenPanel.Location = new System.Drawing.Point(133, -35);
            this.ScreenPanel.Name = "ScreenPanel";
            this.ScreenPanel.Size = new System.Drawing.Size(320, 240);
            this.ScreenPanel.TabIndex = 1;
            // 
            // base_panel
            // 
            this.base_panel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.base_panel.BackColor = System.Drawing.Color.Transparent;
            this.base_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.base_panel.Location = new System.Drawing.Point(79, 59);
            this.base_panel.Name = "base_panel";
            this.base_panel.Size = new System.Drawing.Size(160, 120);
            this.base_panel.TabIndex = 0;
            this.base_panel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MainPanel_MouseClick);
            // 
            // ObjectPanel
            // 
            this.ObjectPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ObjectPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ObjectPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ObjectPanel.Controls.Add(this.textBox1);
            this.ObjectPanel.Controls.Add(this.DescLabel);
            this.ObjectPanel.Controls.Add(this.ButtonFlowLayout);
            this.ObjectPanel.Controls.Add(this.NameTextBox);
            this.ObjectPanel.Controls.Add(this.NameLabel);
            this.ObjectPanel.Controls.Add(this.ObjectLabel);
            this.ObjectPanel.Location = new System.Drawing.Point(9, 9);
            this.ObjectPanel.Margin = new System.Windows.Forms.Padding(6);
            this.ObjectPanel.Name = "ObjectPanel";
            this.ObjectPanel.Size = new System.Drawing.Size(563, 256);
            this.ObjectPanel.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(9, 70);
            this.textBox1.Margin = new System.Windows.Forms.Padding(6);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(157, 178);
            this.textBox1.TabIndex = 9;
            // 
            // DescLabel
            // 
            this.DescLabel.AutoSize = true;
            this.DescLabel.Location = new System.Drawing.Point(6, 52);
            this.DescLabel.Margin = new System.Windows.Forms.Padding(6);
            this.DescLabel.Name = "DescLabel";
            this.DescLabel.Size = new System.Drawing.Size(63, 13);
            this.DescLabel.TabIndex = 8;
            this.DescLabel.Text = "Description:";
            // 
            // ButtonFlowLayout
            // 
            this.ButtonFlowLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonFlowLayout.BackColor = System.Drawing.SystemColors.Control;
            this.ButtonFlowLayout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ButtonFlowLayout.Controls.Add(this.PanelButton);
            this.ButtonFlowLayout.Controls.Add(this.LabelButton);
            this.ButtonFlowLayout.Controls.Add(this.ButtonButton);
            this.ButtonFlowLayout.Controls.Add(this.ImageButton);
            this.ButtonFlowLayout.Location = new System.Drawing.Point(175, 55);
            this.ButtonFlowLayout.Margin = new System.Windows.Forms.Padding(6);
            this.ButtonFlowLayout.Name = "ButtonFlowLayout";
            this.ButtonFlowLayout.Size = new System.Drawing.Size(380, 193);
            this.ButtonFlowLayout.TabIndex = 7;
            // 
            // PanelButton
            // 
            this.PanelButton.Location = new System.Drawing.Point(3, 3);
            this.PanelButton.Name = "PanelButton";
            this.PanelButton.Size = new System.Drawing.Size(75, 23);
            this.PanelButton.TabIndex = 1;
            this.PanelButton.Text = "Add Panel";
            this.PanelButton.UseVisualStyleBackColor = true;
            this.PanelButton.Click += new System.EventHandler(this.PanelButton_Click);
            // 
            // LabelButton
            // 
            this.LabelButton.Location = new System.Drawing.Point(84, 3);
            this.LabelButton.Name = "LabelButton";
            this.LabelButton.Size = new System.Drawing.Size(75, 23);
            this.LabelButton.TabIndex = 3;
            this.LabelButton.Text = "AddLabel";
            this.LabelButton.UseVisualStyleBackColor = true;
            this.LabelButton.Click += new System.EventHandler(this.LabelButton_Click);
            // 
            // ButtonButton
            // 
            this.ButtonButton.Location = new System.Drawing.Point(165, 3);
            this.ButtonButton.Name = "ButtonButton";
            this.ButtonButton.Size = new System.Drawing.Size(75, 23);
            this.ButtonButton.TabIndex = 2;
            this.ButtonButton.Text = "Add Button";
            this.ButtonButton.UseVisualStyleBackColor = true;
            // 
            // ImageButton
            // 
            this.ImageButton.Location = new System.Drawing.Point(246, 3);
            this.ImageButton.Name = "ImageButton";
            this.ImageButton.Size = new System.Drawing.Size(75, 23);
            this.ImageButton.TabIndex = 4;
            this.ImageButton.Text = "Add Image";
            this.ImageButton.UseVisualStyleBackColor = true;
            this.ImageButton.Click += new System.EventHandler(this.ImageButton_Click);
            // 
            // NameTextBox
            // 
            this.NameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.NameTextBox.Location = new System.Drawing.Point(79, 26);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(479, 20);
            this.NameTextBox.TabIndex = 6;
            this.NameTextBox.Text = "UntitledForm";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(6, 29);
            this.NameLabel.Margin = new System.Windows.Forms.Padding(6);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(64, 13);
            this.NameLabel.TabIndex = 5;
            this.NameLabel.Text = "Form Name:";
            // 
            // ObjectLabel
            // 
            this.ObjectLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ObjectLabel.Font = new System.Drawing.Font("Verdana", 10.5F);
            this.ObjectLabel.ForeColor = System.Drawing.Color.MidnightBlue;
            this.ObjectLabel.Location = new System.Drawing.Point(0, 0);
            this.ObjectLabel.Name = "ObjectLabel";
            this.ObjectLabel.Size = new System.Drawing.Size(561, 23);
            this.ObjectLabel.TabIndex = 0;
            this.ObjectLabel.Text = "Menu Objects";
            this.ObjectLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MainSplitter2
            // 
            this.MainSplitter2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainSplitter2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.MainSplitter2.Location = new System.Drawing.Point(0, 0);
            this.MainSplitter2.Name = "MainSplitter2";
            this.MainSplitter2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // MainSplitter2.Panel1
            // 
            this.MainSplitter2.Panel1.Controls.Add(this.PreviewPanel);
            // 
            // MainSplitter2.Panel2
            // 
            this.MainSplitter2.Panel2.Controls.Add(this.MainTabControl);
            this.MainSplitter2.Size = new System.Drawing.Size(589, 499);
            this.MainSplitter2.SplitterDistance = 195;
            this.MainSplitter2.TabIndex = 2;
            // 
            // PreviewPanel
            // 
            this.PreviewPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PreviewPanel.Controls.Add(this.PreviewHolder);
            this.PreviewPanel.Controls.Add(this.PreviewLabel);
            this.PreviewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PreviewPanel.Location = new System.Drawing.Point(0, 0);
            this.PreviewPanel.Margin = new System.Windows.Forms.Padding(6);
            this.PreviewPanel.Name = "PreviewPanel";
            this.PreviewPanel.Size = new System.Drawing.Size(589, 195);
            this.PreviewPanel.TabIndex = 1;
            // 
            // PreviewLabel
            // 
            this.PreviewLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.PreviewLabel.Font = new System.Drawing.Font("Verdana", 10.5F);
            this.PreviewLabel.ForeColor = System.Drawing.Color.MidnightBlue;
            this.PreviewLabel.Location = new System.Drawing.Point(0, 0);
            this.PreviewLabel.Name = "PreviewLabel";
            this.PreviewLabel.Size = new System.Drawing.Size(587, 23);
            this.PreviewLabel.TabIndex = 1;
            this.PreviewLabel.Text = "Menu Preview";
            this.PreviewLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MainTabControl
            // 
            this.MainTabControl.Controls.Add(this.ObjectPage);
            this.MainTabControl.Controls.Add(this.CodePage);
            this.MainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTabControl.Location = new System.Drawing.Point(0, 0);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(589, 300);
            this.MainTabControl.TabIndex = 0;
            this.MainTabControl.SelectedIndexChanged += new System.EventHandler(this.MainTabControl_SelectedIndexChanged);
            // 
            // ObjectPage
            // 
            this.ObjectPage.Controls.Add(this.ObjectPanel);
            this.ObjectPage.Location = new System.Drawing.Point(4, 22);
            this.ObjectPage.Name = "ObjectPage";
            this.ObjectPage.Padding = new System.Windows.Forms.Padding(3);
            this.ObjectPage.Size = new System.Drawing.Size(581, 274);
            this.ObjectPage.TabIndex = 0;
            this.ObjectPage.Text = "Object Page";
            this.ObjectPage.UseVisualStyleBackColor = true;
            // 
            // CodePage
            // 
            this.CodePage.Location = new System.Drawing.Point(4, 22);
            this.CodePage.Name = "CodePage";
            this.CodePage.Padding = new System.Windows.Forms.Padding(3);
            this.CodePage.Size = new System.Drawing.Size(581, 274);
            this.CodePage.TabIndex = 1;
            this.CodePage.Text = "Code Page";
            this.CodePage.UseVisualStyleBackColor = true;
            // 
            // MainSplitter
            // 
            this.MainSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainSplitter.Location = new System.Drawing.Point(0, 0);
            this.MainSplitter.Name = "MainSplitter";
            // 
            // MainSplitter.Panel1
            // 
            this.MainSplitter.Panel1.Controls.Add(this.MainSplitter2);
            // 
            // MainSplitter.Panel2
            // 
            this.MainSplitter.Panel2.Controls.Add(this.MainPropGrid);
            this.MainSplitter.Size = new System.Drawing.Size(865, 499);
            this.MainSplitter.SplitterDistance = 589;
            this.MainSplitter.TabIndex = 3;
            // 
            // MainPropGrid
            // 
            this.MainPropGrid.CommandsBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.MainPropGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPropGrid.Location = new System.Drawing.Point(0, 0);
            this.MainPropGrid.Name = "MainPropGrid";
            this.MainPropGrid.Size = new System.Drawing.Size(272, 499);
            this.MainPropGrid.TabIndex = 0;
            // 
            // StateEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MainSplitter);
            this.Name = "StateEditor";
            this.Size = new System.Drawing.Size(865, 499);
            this.PreviewHolder.ResumeLayout(false);
            this.ScreenPanel.ResumeLayout(false);
            this.ObjectPanel.ResumeLayout(false);
            this.ObjectPanel.PerformLayout();
            this.ButtonFlowLayout.ResumeLayout(false);
            this.MainSplitter2.Panel1.ResumeLayout(false);
            this.MainSplitter2.Panel2.ResumeLayout(false);
            this.MainSplitter2.ResumeLayout(false);
            this.PreviewPanel.ResumeLayout(false);
            this.MainTabControl.ResumeLayout(false);
            this.ObjectPage.ResumeLayout(false);
            this.MainSplitter.Panel1.ResumeLayout(false);
            this.MainSplitter.Panel2.ResumeLayout(false);
            this.MainSplitter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sphere.Core.Editor.EditorPanel PreviewHolder;
        private System.Windows.Forms.Panel ObjectPanel;
        private Sphere.Core.Editor.EditorLabel ObjectLabel;
        private System.Windows.Forms.SplitContainer MainSplitter2;
        private System.Windows.Forms.Button ImageButton;
        private System.Windows.Forms.Button LabelButton;
        private System.Windows.Forms.Button ButtonButton;
        private System.Windows.Forms.Button PanelButton;
        private System.Windows.Forms.Panel PreviewPanel;
        private Sphere.Core.Editor.EditorLabel PreviewLabel;
        private System.Windows.Forms.TabControl MainTabControl;
        private System.Windows.Forms.TabPage ObjectPage;
        private System.Windows.Forms.TabPage CodePage;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Panel base_panel;
        private System.Windows.Forms.FlowLayoutPanel ButtonFlowLayout;
        private System.Windows.Forms.SplitContainer MainSplitter;
        private System.Windows.Forms.PropertyGrid MainPropGrid;
        private System.Windows.Forms.Panel ScreenPanel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label DescLabel;
    }
}
