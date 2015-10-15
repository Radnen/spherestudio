using System;
using System.Windows.Forms;

using Sphere.Plugins;
using Sphere.Plugins.Interfaces;
using Sphere.Core.Editor;

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
            StyleSettings.ApplyStyle(OKButton);
            StyleSettings.ApplyStyle(CloseButton);
        }

        private void ProjectPropsForm_Load(object sender, EventArgs e)
        {
            EngineComboBox.Items.AddRange(PluginManager.GetNames<IStarter>());
            CompilerComboBox.Items.AddRange(PluginManager.GetNames<ICompiler>());

            PathTextBox.Text = _project.FileName;
            NameTextBox.Text = _project.Name;
            AuthorTextBox.Text = _project.Author;
            SummaryTextBox.Text = _project.Description;
            BuildDirTextBox.Text = _project.BuildPath;
            EngineComboBox.Text = _project.Engine;
            CompilerComboBox.Text = _project.Compiler;

            ActiveControl = NameTextBox;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            _project.Name = NameTextBox.Text;
            _project.Author = AuthorTextBox.Text;
            _project.Description = SummaryTextBox.Text;
            _project.Engine = EngineComboBox.Text;
            _project.Compiler = CompilerComboBox.Text;
            _project.BuildPath = BuildDirTextBox.Text;
            _project.Save();
        }
    }
}
