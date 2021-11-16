﻿using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using SphereStudio.Ide;
using SphereStudio.Base;
using SphereStudio.UI;

namespace SphereStudio.Ide.Forms
{
    partial class NewProjectForm : Form, IStyleAware
    {
        private bool _resoChanging = false;

        public NewProjectForm()
        {
            InitializeComponent();
        }

        public string RootFolder
        {
            get { return FolderBox.Text; }
            set
            {
                FolderBox.Text = value;
                DirectoryBox.Text = value + Path.DirectorySeparatorChar;
            }
        }

        public Project NewProject { get; private set; }

        private void NewProjectForm_Load(object sender, EventArgs e)
        {
            ResoComboBox.SelectedIndex = 0;
            CompilerComboBox.Items.AddRange(PluginManager.GetNames<ICompiler>());
            CompilerComboBox.Text = Core.Settings.Compiler;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            NewProject = Project.Create(DirectoryBox.Text, NameBox.Text);
            NewProject.Author = AuthorBox.Text;
            NewProject.Summary = DescriptionBox.Text;
            NewProject.ScreenWidth = int.Parse(WidthBox.Text);
            NewProject.ScreenHeight = int.Parse(HeightBox.Text);
            NewProject.MainScript = "main.js";
            NewProject.Compiler = CompilerComboBox.Text;
        }

        private void FillDirectory(object sender, KeyEventArgs e)
        {
            DirectoryBox.Text = FolderBox.Text + Path.DirectorySeparatorChar + NameBox.Text;
            CheckForOk();
        }

        private void FolderBrowseButton_Click(object sender, EventArgs e)
        {
            if (FolderFinder.ShowDialog() == DialogResult.OK)
            {
                FolderBox.Text = FolderFinder.SelectedPath;
                DirectoryBox.Text = FolderBox.Text + Path.DirectorySeparatorChar + NameBox.Text;
                CheckForOk();
            }
        }
        
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar) && e.KeyChar != '\t' && e.KeyChar != '\b');
        }

        private void ResoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ResoComboBox.SelectedIndex > 0)
            {
                _resoChanging = true;
                var match = new Regex(@"(\d+)x(\d+)").Match(ResoComboBox.Text);
                WidthBox.Text = match.Groups[1].Value;
                HeightBox.Text = match.Groups[2].Value;
                _resoChanging = false;
            }
        }

        private void CheckForOk()
        {
            OKButton.Enabled = true;
            StatusLabel.Text = @"Ready.";
            String text = NameBox.Text;
            String path = DirectoryBox.Text;
            if (text.Length == 0)
            {
                OKButton.Enabled = false;
                StatusLabel.Text = FolderBox.Text.Length < 2 ? "You'll need a name and directory." : "You'll need a name.";
            }
            else if (FolderBox.Text.Length < 2)
            {
                OKButton.Enabled = false;
                StatusLabel.Text = @"The directory must be more than 2 letters.";
            }

            char[] invalidChars = Path.GetInvalidPathChars();
            bool isPathInvalid = false;
            foreach (char ch in invalidChars)
                isPathInvalid |= path.Contains(ch.ToString());
            if (isPathInvalid)
            {
                OKButton.Enabled = false;
                StatusLabel.Text = @"Path or name contains invalid characters.";
            }
            else
            {
                System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo(DirectoryBox.Text);
                if (directory.Exists && text.Length > 0)
                {
                    OKButton.Enabled = false;
                    StatusLabel.Text = @"Project name already exists!";
                }
            }
        }

        public void ApplyStyle(UIStyle theme)
        {
            theme.AsUIElement(ButtonPanel);
            theme.AsUIElement(OKButton);
            theme.AsUIElement(CloseButton);
        }

        private void ResoText_Changed(object sender, EventArgs e)
        {
            if (!_resoChanging)
            {
                ResoComboBox.SelectedIndex = 0;
            }
        }
    }
}
