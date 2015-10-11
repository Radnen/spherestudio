using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

using Sphere.Core.Editor;
using System.Drawing;
using System.Media;

namespace SphereStudio.Forms
{
    partial class ProjectPropsForm : Form, IStyleable
    {
        private Project _project;
        
        public ProjectPropsForm(Project someProject)
        {
            InitializeComponent();
            UpdateStyle();

            _project = someProject;
        }

        public void UpdateStyle()
        {
            StyleSettings.ApplyStyle(ButtonPanel);
            StyleSettings.ApplyStyle(buttonOK);
            StyleSettings.ApplyStyle(buttonCancel);
        }

        private void GameSettings_Load(object sender, EventArgs e)
        {
            PathTextBox.Text = _project.RootPath;
            nameBox.Text = _project.Name;
            authorBox.Text = _project.Author;
            descriptionBox.Text = _project.Description;
            widthBox.Text = _project.ScreenWidth.ToString();
            heightBox.Text = _project.ScreenHeight.ToString();
            buildDirBox.Text = _project.BuildPath;

            // I'll need to populate the script combo box.
            DirectoryInfo dir = new DirectoryInfo(PathTextBox.Text + "\\scripts");

            var scriptList = from FileInfo file in dir.EnumerateFiles("*")
                             where file.Extension == ".js" || file.Extension == ".coffee"
                             orderby file.Name ascending
                             select file.Name;
            foreach (string filename in scriptList)
            {
                mainScriptBox.Items.Add(filename);
            }
            mainScriptBox.Text = _project.MainScript;
        }

        private void resolutionBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\t');
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (nameBox.Text == "" ||
                widthBox.Text == "" || heightBox.Text == "")
            {
                MessageBox.Show("Some required fields are missing or incorrect.", Text);
                return;
            }

            DialogResult = DialogResult.OK;
            _project.Name = nameBox.Text;
            _project.Author = authorBox.Text;
            _project.Description = descriptionBox.Text;
            _project.ScreenWidth = int.Parse(widthBox.Text);
            _project.ScreenHeight = int.Parse(heightBox.Text);
            _project.MainScript = mainScriptBox.Text;
            _project.BuildPath = buildDirBox.Text;
            _project.Save();
        }
    }
}
