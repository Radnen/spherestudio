using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

using SphereStudio.Settings;
using Sphere.Core.Editor;

namespace SphereStudio.Forms
{
    internal partial class GameSettings : Form, IStyleable
    {
        private ProjectSettings _project;
        
        public GameSettings(ProjectSettings someProject)
        {
            InitializeComponent();
            UpdateStyle();

            _project = someProject;
        }

        private void GameSettings_Load(object sender, EventArgs e)
        {
            PathTextBox.Text = _project.RootPath;
            NameTextBox.Text = _project.Name;
            AuthorTextBox.Text = _project.Author;
            DescTextBox.Text = _project.Description;
            WidthTextBox.Text = _project.ScreenWidth.ToString();
            HeightTextBox.Text = _project.ScreenHeight.ToString();
            
            // I'll need to populate the script combo box.
            DirectoryInfo dir = new DirectoryInfo(PathTextBox.Text + "\\scripts");

            var scriptList = from FileInfo file in dir.EnumerateFiles("*")
                             where file.Extension == ".js" || file.Extension == ".coffee"
                             orderby file.Name ascending
                             select file.Name;
            foreach (string filename in scriptList)
            {
                ScriptComboBox.Items.Add(filename);
            }
            ScriptComboBox.Text = _project.MainScript;
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8);
        }

        public void UpdateStyle()
        {
            StyleSettings.ApplyStyle(ButtonPanel);
            StyleSettings.ApplyStyle(buttonOK);
            StyleSettings.ApplyStyle(buttonCancel);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            _project.Name = NameTextBox.Text;
            _project.Author = AuthorTextBox.Text;
            _project.Description = DescTextBox.Text;
            _project.ScreenWidth = int.Parse(WidthTextBox.Text);
            _project.ScreenHeight = int.Parse(WidthTextBox.Text);
            _project.MainScript = ScriptComboBox.Text;
            _project.Save();
        }
    }
}
