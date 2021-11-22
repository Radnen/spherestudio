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

            ActiveControl = nameTextBox;
            if (editBuild)
                ActiveControl = buildDirTextBox;

            StyleManager.AutoStyle(this);
        }

        public void ApplyStyle(UIStyle style)
        {
            style.AsUIElement(this);

            style.AsHeading(header);
            style.AsHeading(footer);
            style.AsHeading(projectHeader);
            style.AsHeading(gameHeader);
            style.AsAccent(projectPanel);
            style.AsAccent(gamePanel);

            style.AsAccent(okButton);
            style.AsAccent(cancelButton);
            style.AsAccent(upgradeButton);
            style.AsTextView(pathTextBox);
            style.AsTextView(nameTextBox);
            style.AsTextView(authorTextBox);
            style.AsTextView(resolutionDropDown);
            style.AsTextView(widthTextBox);
            style.AsTextView(heightTextBox);
            style.AsTextView(summaryTextBox);
            style.AsTextView(typeDropDown);
            style.AsTextView(buildDirTextBox);
        }

        private void ProjectPropsForm_Load(object sender, EventArgs e)
        {
            typeDropDown.Items.AddRange(PluginManager.GetNames<ICompiler>());
            if (!typeDropDown.Items.Contains(_project.Compiler))
                typeDropDown.Items.Insert(0, _project.Compiler);

            var resoString = $"{_project.ScreenWidth}x{_project.ScreenHeight}";
            pathTextBox.Text = Path.GetDirectoryName(_project.FileName);
            nameTextBox.Text = _project.Name;
            authorTextBox.Text = _project.Author;
            summaryTextBox.Text = _project.Summary;
            buildDirTextBox.Text = _project.BuildPath;
            typeDropDown.Text = _project.Compiler;
            if (resolutionDropDown.FindStringExact(resoString) >= 0)
            {
                resolutionDropDown.Text = resoString;
            }
            else
            {
                widthTextBox.Text = _project.ScreenWidth.ToString();
                heightTextBox.Text = _project.ScreenHeight.ToString();
                resolutionDropDown.SelectedIndex = 0;
            }

            buildDirTextBox.Enabled = !_project.BackCompatible;
            typeDropDown.Enabled = !_project.BackCompatible;
            upgradeButton.Visible = _project.BackCompatible;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (typeDropDown.Text != _project.Compiler)
            {
                var answer = MessageBox.Show(
                    "You've changed the compiler for this project.  This may prevent Sphere Studio from building the project.  Are you sure you want to continue?",
                    "Changing Compiler", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (answer == DialogResult.No)
                {
                    DialogResult = DialogResult.None;
                    typeDropDown.Text = _project.Compiler;
                    return;
                }
            }

            _project.Name = nameTextBox.Text;
            _project.Author = authorTextBox.Text;
            _project.Summary = summaryTextBox.Text;
            _project.Compiler = typeDropDown.Text;
            _project.BuildPath = buildDirTextBox.Text;
            _project.ScreenWidth = int.Parse(widthTextBox.Text);
            _project.ScreenHeight = int.Parse(heightTextBox.Text);
            _project.Save();
        }

        private void ResoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (resolutionDropDown.SelectedIndex > 0)
            {
                _resoChanging = true;
                var match = new Regex(@"(\d+)x(\d+)").Match(resolutionDropDown.Text);
                widthTextBox.Text = match.Groups[1].Value;
                heightTextBox.Text = match.Groups[2].Value;
                _resoChanging = false;
            }
        }

        private void ResoText_Changed(object sender, EventArgs e)
        {
            if (!_resoChanging)
            {
                resolutionDropDown.SelectedIndex = 0;
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
            ResoLabel.Visible = resolutionDropDown.Visible = widthTextBox.Visible = heightTextBox.Visible =
                typeDropDown.Text == "Sphere 1.x compatible";
        }

        private void UpgradeButton_Click(object sender, EventArgs e)
        {
            var answer = MessageBox.Show(
                "This is a Sphere 1.x-compatible project (game.sgm).  To enable all Sphere Studio features, you can upgrade it a full Sphere Studio project.  Do you want to upgrade now?",
                "Upgrade Project", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (answer == DialogResult.Yes)
            {
                _project.Upgrade();
                pathTextBox.Text = _project.FileName;
                buildDirTextBox.Enabled = true;
                typeDropDown.Enabled = true;
                buildDirTextBox.Text = _project.BuildPath;
                typeDropDown.Text = _project.Compiler;
                upgradeButton.Visible = false;
            }
        }
    }
}
