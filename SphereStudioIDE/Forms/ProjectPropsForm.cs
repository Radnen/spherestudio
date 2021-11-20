using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using SphereStudio.Ide;
using SphereStudio.Base;
using SphereStudio.UI;

namespace SphereStudio.Ide.Forms
{
    partial class ProjectPropsForm : Form, IStyleAware
    {
        private Project _project;
        private bool _resoChanging = false;
        
        public ProjectPropsForm(Project someProject, bool editBuild = false)
        {
            InitializeComponent();
            _project = someProject;

            ActiveControl = NameTextBox;
            if (editBuild)
            {
                tabControl1.SelectedTab = BuildPage;
                ActiveControl = BuildDirTextBox;
            }
        }

        public void ApplyStyle(UIStyle theme)
        {
            theme.AsUIElement(ButtonPanel);
            theme.AsUIElement(OKButton);
            theme.AsUIElement(CloseButton);
        }

        private void ProjectPropsForm_Load(object sender, EventArgs e)
        {
            CompilerComboBox.Items.AddRange(PluginManager.GetNames<ICompiler>());
            if (!CompilerComboBox.Items.Contains(_project.Compiler))
                CompilerComboBox.Items.Insert(0, _project.Compiler);

            PathTextBox.Text = _project.FileName;
            NameTextBox.Text = _project.Name;
            AuthorTextBox.Text = _project.Author;
            SummaryTextBox.Text = _project.Summary;
            BuildDirTextBox.Text = _project.BuildPath;
            CompilerComboBox.Text = _project.Compiler;
            string resoString = string.Format("{0}x{1}", _project.ScreenWidth, _project.ScreenHeight);
            if (ResoComboBox.FindStringExact(resoString) >= 0)
                ResoComboBox.Text = resoString;
            else
            {
                WidthBox.Text = _project.ScreenWidth.ToString();
                HeightBox.Text = _project.ScreenHeight.ToString();
                ResoComboBox.SelectedIndex = 0;
            }

            BuildDirTextBox.Enabled = !_project.BackCompatible;
            CompilerComboBox.Enabled = !_project.BackCompatible;
            UpgradeButton.Visible = _project.BackCompatible;
            CompatModeLabel.Visible = _project.BackCompatible;
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

            _project.Name = NameTextBox.Text;
            _project.Author = AuthorTextBox.Text;
            _project.Summary = SummaryTextBox.Text;
            _project.Compiler = CompilerComboBox.Text;
            _project.BuildPath = BuildDirTextBox.Text;
            _project.ScreenWidth = int.Parse(WidthBox.Text);
            _project.ScreenHeight = int.Parse(HeightBox.Text);
            _project.Save();
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

        private void ResoText_Changed(object sender, EventArgs e)
        {
            if (!_resoChanging)
            {
                ResoComboBox.SelectedIndex = 0;
            }
        }

        private void EngineList_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            Refresh();
        }

        private void EngineComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Refresh();
        }

        private void CompilerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResoLabel.Visible = ResoComboBox.Visible = WidthBox.Visible = HeightBox.Visible =
                CompilerComboBox.Text == "Classic";
        }

        private void UpgradeButton_Click(object sender, EventArgs e)
        {
            _project.Upgrade();
            PathTextBox.Text = _project.FileName;
            BuildDirTextBox.Enabled = true;
            CompilerComboBox.Enabled = true;
            BuildDirTextBox.Text = _project.BuildPath;
            CompilerComboBox.Text = _project.Compiler;
            UpgradeButton.Visible = false;
            CompatModeLabel.Visible = false;
        }
    }
}
