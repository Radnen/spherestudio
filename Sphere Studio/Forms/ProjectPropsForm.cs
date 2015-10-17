using System;
using System.Linq;
using System.Windows.Forms;

using Sphere.Plugins;
using Sphere.Plugins.Interfaces;
using Sphere.Core.Editor;

namespace SphereStudio.Forms
{
    partial class ProjectPropsForm : Form, IStyleable
    {
        private bool _isRefreshing = false;
        private Project _project;
        
        public ProjectPropsForm(Project someProject, bool editBuild = false)
        {
            InitializeComponent();
            UpdateStyle();
            _project = someProject;

            ActiveControl = NameTextBox;
            if (editBuild)
            {
                tabControl1.SelectedTab = BuildPage;
                ActiveControl = BuildDirTextBox;
            }
        }

        public override void Refresh()
        {
            base.Refresh();

            if (_isRefreshing) return;
            _isRefreshing = true;

            var selectedEngines = from ListViewItem item in EngineList.Items
                                  where item.Checked
                                  select item.Text;
            OKButton.Enabled = selectedEngines.Count() > 0;

            _isRefreshing = false;
        }

        public void UpdateStyle()
        {
            StyleSettings.ApplyStyle(ButtonPanel);
            StyleSettings.ApplyStyle(OKButton);
            StyleSettings.ApplyStyle(CloseButton);
        }

        private void ProjectPropsForm_Load(object sender, EventArgs e)
        {
            CompilerComboBox.Items.AddRange(PluginManager.GetNames<ICompiler>());
            if (!CompilerComboBox.Items.Contains(_project.Compiler))
                CompilerComboBox.Items.Insert(0, _project.Compiler);

            var engines = _project.Engines;
            foreach (string name in PluginManager.GetNames<IStarter>())
            {
                var plugin = PluginManager.Get<IStarter>(name);
                var item = EngineList.Items.Add(name);
                item.SubItems.Add(plugin is IDebugStarter ? "Yes" : "No");
                item.Checked = engines.Contains(name);
            }

            PathTextBox.Text = _project.FileName;
            NameTextBox.Text = _project.Name;
            AuthorTextBox.Text = _project.Author;
            SummaryTextBox.Text = _project.Summary;
            BuildDirTextBox.Text = _project.BuildPath;
            CompilerComboBox.Text = _project.Compiler;

            Refresh();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (CompilerComboBox.Text != _project.Compiler)
            {
                var answer = MessageBox.Show(
                    "You've changed the compiler for this project.  This may prevent Sphere Studio from building the project.  Are you sure you want to continue?",
                    "Changing Compiler", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (answer == DialogResult.No)
                {
                    DialogResult = DialogResult.None;
                    CompilerComboBox.Text = _project.Compiler;
                    return;
                }
            }

            var selectedEngines = from ListViewItem item in EngineList.Items
                                  where item.Checked
                                  select item.Text;

            _project.Name = NameTextBox.Text;
            _project.Author = AuthorTextBox.Text;
            _project.Summary = SummaryTextBox.Text;
            _project.Engines = selectedEngines.ToArray();
            _project.Compiler = CompilerComboBox.Text;
            _project.BuildPath = BuildDirTextBox.Text;
            _project.Save();
        }

        private void EngineList_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            Refresh();
        }

        private void EngineComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Refresh();
        }
    }
}
