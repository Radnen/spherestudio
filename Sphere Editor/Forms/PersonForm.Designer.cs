namespace Sphere_Editor.Forms
{
    partial class PersonForm
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
            this.components = new System.ComponentModel.Container();
            this.NameLabel = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.SpritesetLabel = new System.Windows.Forms.Label();
            this.SpritesetBox = new System.Windows.Forms.TextBox();
            this.ScriptTabControl = new System.Windows.Forms.TabControl();
            this.OnCreatePage = new System.Windows.Forms.TabPage();
            this.OnDestroyPage = new System.Windows.Forms.TabPage();
            this.OnTouchPage = new System.Windows.Forms.TabPage();
            this.OnTalkPage = new System.Windows.Forms.TabPage();
            this.CommandGeneratorPage = new System.Windows.Forms.TabPage();
            this.PersonEditorTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.SpritesetButton = new System.Windows.Forms.Button();
            this.LayerComboBox = new System.Windows.Forms.ComboBox();
            this.SpritePreview = new System.Windows.Forms.PictureBox();
            this.CancelFormButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.DirectionBox = new System.Windows.Forms.ComboBox();
            this.GenerateButton = new System.Windows.Forms.Button();
            this.LayerLabel = new System.Windows.Forms.Label();
            this.PositionLabel = new System.Windows.Forms.Label();
            this.CodePanel = new System.Windows.Forms.Panel();
            this.DirLabel = new System.Windows.Forms.Label();
            this.ScriptTabControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpritePreview)).BeginInit();
            this.SuspendLayout();
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameLabel.Location = new System.Drawing.Point(97, 13);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(53, 16);
            this.NameLabel.TabIndex = 0;
            this.NameLabel.Text = "Name:";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.NameTextBox.Location = new System.Drawing.Point(176, 12);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(162, 20);
            this.NameTextBox.TabIndex = 1;
            this.PersonEditorTooltip.SetToolTip(this.NameTextBox, "The unique identifier for this entity.");
            // 
            // SpritesetLabel
            // 
            this.SpritesetLabel.AutoSize = true;
            this.SpritesetLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SpritesetLabel.Location = new System.Drawing.Point(97, 44);
            this.SpritesetLabel.Name = "SpritesetLabel";
            this.SpritesetLabel.Size = new System.Drawing.Size(74, 16);
            this.SpritesetLabel.TabIndex = 2;
            this.SpritesetLabel.Text = "Spriteset:";
            // 
            // SpritesetBox
            // 
            this.SpritesetBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.SpritesetBox.Location = new System.Drawing.Point(176, 40);
            this.SpritesetBox.Name = "SpritesetBox";
            this.SpritesetBox.Size = new System.Drawing.Size(162, 20);
            this.SpritesetBox.TabIndex = 3;
            // 
            // ScriptTabControl
            // 
            this.ScriptTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ScriptTabControl.Controls.Add(this.OnCreatePage);
            this.ScriptTabControl.Controls.Add(this.OnDestroyPage);
            this.ScriptTabControl.Controls.Add(this.OnTouchPage);
            this.ScriptTabControl.Controls.Add(this.OnTalkPage);
            this.ScriptTabControl.Controls.Add(this.CommandGeneratorPage);
            this.ScriptTabControl.Location = new System.Drawing.Point(12, 124);
            this.ScriptTabControl.Name = "ScriptTabControl";
            this.ScriptTabControl.SelectedIndex = 0;
            this.ScriptTabControl.Size = new System.Drawing.Size(442, 21);
            this.ScriptTabControl.TabIndex = 4;
            this.ScriptTabControl.SelectedIndexChanged += new System.EventHandler(this.ScriptTabControl_SelectedIndexChanged);
            // 
            // OnCreatePage
            // 
            this.OnCreatePage.Location = new System.Drawing.Point(4, 22);
            this.OnCreatePage.Name = "OnCreatePage";
            this.OnCreatePage.Padding = new System.Windows.Forms.Padding(3);
            this.OnCreatePage.Size = new System.Drawing.Size(434, 0);
            this.OnCreatePage.TabIndex = 0;
            this.OnCreatePage.Text = "On Create";
            this.OnCreatePage.UseVisualStyleBackColor = true;
            // 
            // OnDestroyPage
            // 
            this.OnDestroyPage.Location = new System.Drawing.Point(4, 22);
            this.OnDestroyPage.Name = "OnDestroyPage";
            this.OnDestroyPage.Padding = new System.Windows.Forms.Padding(3);
            this.OnDestroyPage.Size = new System.Drawing.Size(434, 0);
            this.OnDestroyPage.TabIndex = 1;
            this.OnDestroyPage.Text = "On Destroy";
            this.OnDestroyPage.UseVisualStyleBackColor = true;
            // 
            // OnTouchPage
            // 
            this.OnTouchPage.Location = new System.Drawing.Point(4, 22);
            this.OnTouchPage.Name = "OnTouchPage";
            this.OnTouchPage.Padding = new System.Windows.Forms.Padding(3);
            this.OnTouchPage.Size = new System.Drawing.Size(434, 0);
            this.OnTouchPage.TabIndex = 2;
            this.OnTouchPage.Text = "On Touch";
            this.OnTouchPage.UseVisualStyleBackColor = true;
            // 
            // OnTalkPage
            // 
            this.OnTalkPage.Location = new System.Drawing.Point(4, 22);
            this.OnTalkPage.Name = "OnTalkPage";
            this.OnTalkPage.Padding = new System.Windows.Forms.Padding(3);
            this.OnTalkPage.Size = new System.Drawing.Size(434, 0);
            this.OnTalkPage.TabIndex = 3;
            this.OnTalkPage.Text = "On Talk";
            this.OnTalkPage.UseVisualStyleBackColor = true;
            // 
            // CommandGeneratorPage
            // 
            this.CommandGeneratorPage.Location = new System.Drawing.Point(4, 22);
            this.CommandGeneratorPage.Name = "CommandGeneratorPage";
            this.CommandGeneratorPage.Padding = new System.Windows.Forms.Padding(3);
            this.CommandGeneratorPage.Size = new System.Drawing.Size(434, 0);
            this.CommandGeneratorPage.TabIndex = 4;
            this.CommandGeneratorPage.Text = "Command Generator";
            this.CommandGeneratorPage.UseVisualStyleBackColor = true;
            // 
            // SpritesetButton
            // 
            this.SpritesetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SpritesetButton.Image = global::Sphere_Editor.Properties.Resources.palette;
            this.SpritesetButton.Location = new System.Drawing.Point(344, 38);
            this.SpritesetButton.Name = "SpritesetButton";
            this.SpritesetButton.Size = new System.Drawing.Size(24, 23);
            this.SpritesetButton.TabIndex = 6;
            this.PersonEditorTooltip.SetToolTip(this.SpritesetButton, "Find a local spriteset to use.");
            this.SpritesetButton.UseVisualStyleBackColor = true;
            this.SpritesetButton.Click += new System.EventHandler(this.SpritesetButton_Click);
            // 
            // LayerComboBox
            // 
            this.LayerComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.LayerComboBox.FormattingEnabled = true;
            this.LayerComboBox.Location = new System.Drawing.Point(176, 70);
            this.LayerComboBox.Name = "LayerComboBox";
            this.LayerComboBox.Size = new System.Drawing.Size(162, 21);
            this.LayerComboBox.TabIndex = 10;
            this.PersonEditorTooltip.SetToolTip(this.LayerComboBox, "The layer the sprite will appear on.");
            this.LayerComboBox.SelectedIndexChanged += new System.EventHandler(this.LayerComboBox_SelectedIndexChanged);
            // 
            // SpritePreview
            // 
            this.SpritePreview.BackgroundImage = global::Sphere_Editor.Properties.Resources.editbg;
            this.SpritePreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SpritePreview.Location = new System.Drawing.Point(16, 24);
            this.SpritePreview.Name = "SpritePreview";
            this.SpritePreview.Size = new System.Drawing.Size(75, 79);
            this.SpritePreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.SpritePreview.TabIndex = 11;
            this.SpritePreview.TabStop = false;
            this.PersonEditorTooltip.SetToolTip(this.SpritePreview, "The default sprite direction of this entity.");
            // 
            // CancelFormButton
            // 
            this.CancelFormButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelFormButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelFormButton.Location = new System.Drawing.Point(377, 41);
            this.CancelFormButton.Name = "CancelFormButton";
            this.CancelFormButton.Size = new System.Drawing.Size(75, 23);
            this.CancelFormButton.TabIndex = 7;
            this.CancelFormButton.Text = "Cancel";
            this.PersonEditorTooltip.SetToolTip(this.CancelFormButton, "Forget these changes");
            this.CancelFormButton.UseVisualStyleBackColor = true;
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.SaveButton.Location = new System.Drawing.Point(377, 12);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 8;
            this.SaveButton.Text = "Save";
            this.PersonEditorTooltip.SetToolTip(this.SaveButton, "Keep these changes");
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // DirectionBox
            // 
            this.DirectionBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.DirectionBox.FormattingEnabled = true;
            this.DirectionBox.Location = new System.Drawing.Point(177, 97);
            this.DirectionBox.Name = "DirectionBox";
            this.DirectionBox.Size = new System.Drawing.Size(162, 21);
            this.DirectionBox.TabIndex = 15;
            this.PersonEditorTooltip.SetToolTip(this.DirectionBox, "The Direction the sprite will appear on.");
            this.DirectionBox.SelectedIndexChanged += new System.EventHandler(this.DirectionBox_SelectedIndexChanged);
            // 
            // GenerateButton
            // 
            this.GenerateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GenerateButton.Image = global::Sphere_Editor.Properties.Resources.arrow_refresh;
            this.GenerateButton.Location = new System.Drawing.Point(344, 10);
            this.GenerateButton.Name = "GenerateButton";
            this.GenerateButton.Size = new System.Drawing.Size(24, 23);
            this.GenerateButton.TabIndex = 16;
            this.GenerateButton.Text = "...";
            this.PersonEditorTooltip.SetToolTip(this.GenerateButton, "Generate Name");
            this.GenerateButton.UseVisualStyleBackColor = true;
            this.GenerateButton.Click += new System.EventHandler(this.GenerateButton_Click);
            // 
            // LayerLabel
            // 
            this.LayerLabel.AutoSize = true;
            this.LayerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LayerLabel.Location = new System.Drawing.Point(97, 71);
            this.LayerLabel.Name = "LayerLabel";
            this.LayerLabel.Size = new System.Drawing.Size(51, 16);
            this.LayerLabel.TabIndex = 9;
            this.LayerLabel.Text = "Layer:";
            // 
            // PositionLabel
            // 
            this.PositionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PositionLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(225)))), ((int)(((byte)(243)))));
            this.PositionLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PositionLabel.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PositionLabel.Location = new System.Drawing.Point(344, 67);
            this.PositionLabel.Name = "PositionLabel";
            this.PositionLabel.Size = new System.Drawing.Size(108, 51);
            this.PositionLabel.TabIndex = 12;
            this.PositionLabel.Text = "(X: 128, Y: 128)";
            this.PositionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CodePanel
            // 
            this.CodePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.CodePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CodePanel.Location = new System.Drawing.Point(12, 144);
            this.CodePanel.Name = "CodePanel";
            this.CodePanel.Size = new System.Drawing.Size(440, 219);
            this.CodePanel.TabIndex = 13;
            // 
            // DirLabel
            // 
            this.DirLabel.AutoSize = true;
            this.DirLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DirLabel.Location = new System.Drawing.Point(97, 98);
            this.DirLabel.Name = "DirLabel";
            this.DirLabel.Size = new System.Drawing.Size(74, 16);
            this.DirLabel.TabIndex = 14;
            this.DirLabel.Text = "Direction:";
            // 
            // PersonForm
            // 
            this.AcceptButton = this.SaveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelFormButton;
            this.ClientSize = new System.Drawing.Size(464, 382);
            this.Controls.Add(this.GenerateButton);
            this.Controls.Add(this.DirectionBox);
            this.Controls.Add(this.DirLabel);
            this.Controls.Add(this.ScriptTabControl);
            this.Controls.Add(this.CodePanel);
            this.Controls.Add(this.PositionLabel);
            this.Controls.Add(this.SpritePreview);
            this.Controls.Add(this.LayerComboBox);
            this.Controls.Add(this.LayerLabel);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.CancelFormButton);
            this.Controls.Add(this.SpritesetButton);
            this.Controls.Add(this.SpritesetBox);
            this.Controls.Add(this.SpritesetLabel);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.NameLabel);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(380, 260);
            this.Name = "PersonForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sphere Person Editor";
            this.Load += new System.EventHandler(this.PersonForm_Load);
            this.ScriptTabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SpritePreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Label SpritesetLabel;
        private System.Windows.Forms.TextBox SpritesetBox;
        private System.Windows.Forms.TabControl ScriptTabControl;
        private System.Windows.Forms.Button SpritesetButton;
        private System.Windows.Forms.ToolTip PersonEditorTooltip;
        private System.Windows.Forms.Button CancelFormButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Label LayerLabel;
        private System.Windows.Forms.ComboBox LayerComboBox;
        private System.Windows.Forms.PictureBox SpritePreview;
        private System.Windows.Forms.Label PositionLabel;
        private System.Windows.Forms.TabPage OnCreatePage;
        private System.Windows.Forms.TabPage OnDestroyPage;
        private System.Windows.Forms.TabPage OnTouchPage;
        private System.Windows.Forms.TabPage OnTalkPage;
        private System.Windows.Forms.TabPage CommandGeneratorPage;
        private System.Windows.Forms.Panel CodePanel;
        private System.Windows.Forms.Label DirLabel;
        private System.Windows.Forms.ComboBox DirectionBox;
        private System.Windows.Forms.Button GenerateButton;
    }
}