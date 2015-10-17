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
            if (!EngineComboBox.Items.Contains(_project.Engine))
                EngineComboBox.Items.Insert(0, _project.Engine);

            CompilerComboBox.Items.AddRange(PluginManager.GetNames<ICompiler>());
            if (!CompilerComboBox.Items.Contains(_project.Compiler))
                CompilerComboBox.Items.Insert(0, _project.Compiler);

            PathTextBox.Text = _project.FileName;
            NameTextBox.Text = _project.Name;
            AuthorTextBox.Text = _project.Author;
            SummaryTextBox.Text = _project.Summary;
            BuildDirTextBox.Text = _project.BuildPath;
            EngineComboBox.Text = _project.Engine;
            CompilerComboBox.Text = _project.Compiler;

            ActiveControl = NameTextBox;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (EngineComboBox.Text != _project.Engine || CompilerComboBox.Text != _project.Compiler)
            {
                var answer = MessageBox.Show(
                    "You've changed the toolchain for this project.  This may prevent Sphere Studio from building and/or running the project.  Are you sure you want to continue?",
                    "Changing Toolchain", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (answer == DialogResult.No)
                {
                    DialogResult = DialogResult.None;
                    return;
                }
            }

            _project.Name = NameTextBox.Text;
            _project.Author = AuthorTextBox.Text;
            _project.Summary = SummaryTextBox.Text;
            _project.Engine = EngineComboBox.Text;
            _project.Compiler = CompilerComboBox.Text;
            _project.BuildPath = BuildDirTextBox.Text;
            _project.Save();
        }
    }
}
