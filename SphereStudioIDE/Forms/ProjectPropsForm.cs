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
        private Project project;

        public ProjectPropsForm(Project projectToEdit)
        {
            InitializeComponent();
            StyleManager.AutoStyle(this);

            project = projectToEdit;
        }

        public void ApplyStyle(UIStyle style)
        {
            style.AsUIElement(this);
            style.AsHeading(header);
            style.AsHeading(footer);
            style.AsAccent(okButton);
            style.AsAccent(cancelButton);
            style.AsAccent(upgradeButton);

            style.AsHeading(projectHeading);
            style.AsAccent(projectPanel);
            style.AsTextView(pathTextBox);
            style.AsTextView(typeDropDown);
            style.AsTextView(buildDirTextBox);

            style.AsHeading(gameHeader);
            style.AsAccent(gamePanel);
            style.AsTextView(titleTextBox);
            style.AsTextView(authorTextBox);
            style.AsTextView(summaryTextBox);
            style.AsTextView(resoDropDown);
            style.AsTextView(widthTextBox);
            style.AsTextView(heightTextBox);
        }

        protected override void OnLoad(EventArgs e)
        {
            typeDropDown.Items.AddRange(PluginManager.GetNames<ICompiler>());
            if (!typeDropDown.Items.Contains(project.Compiler))
                typeDropDown.Items.Insert(0, project.Compiler);

            var resoString = $"{project.ScreenWidth}x{project.ScreenHeight}";
            pathTextBox.Text = Path.GetDirectoryName(project.FileName);
            titleTextBox.Text = project.Name;
            authorTextBox.Text = project.Author;
            summaryTextBox.Text = project.Summary;
            buildDirTextBox.Text = project.BuildPath;
            typeDropDown.Text = project.Compiler;
            if (resoDropDown.FindStringExact(resoString) >= 0)
            {
                resoDropDown.Text = resoString;
            }
            else
            {
                resoDropDown.SelectedIndex = 0;
                widthTextBox.Text = project.ScreenWidth.ToString();
                heightTextBox.Text = project.ScreenHeight.ToString();
            }

            buildDirTextBox.Enabled = !project.BackCompatible;
            typeDropDown.Enabled = !project.BackCompatible;
            upgradeButton.Visible = project.BackCompatible;

            ActiveControl = titleTextBox;

            base.OnLoad(e);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (typeDropDown.Text != project.Compiler)
            {
                var answer = MessageBox.Show(
                    "You've changed the compiler for this project.  This may prevent Sphere Studio from building the project.  Are you sure you want to continue?",
                    "Changing Compiler", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (answer == DialogResult.No)
                {
                    DialogResult = DialogResult.None;
                    typeDropDown.Text = project.Compiler;
                    return;
                }
            }

            project.Name = titleTextBox.Text;
            project.Author = authorTextBox.Text;
            project.Summary = summaryTextBox.Text;
            project.Compiler = typeDropDown.Text;
            project.BuildPath = buildDirTextBox.Text;
            project.ScreenWidth = int.Parse(widthTextBox.Text);
            project.ScreenHeight = int.Parse(heightTextBox.Text);
            project.Save();
        }

        private void upgradeButton_Click(object sender, EventArgs e)
        {
            var answer = MessageBox.Show(
                "This is a Sphere 1.x-compatible project (game.sgm).  To enable all Sphere Studio features, you can upgrade it a full Sphere Studio project.  Do you want to upgrade now?",
                "Upgrade Project", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (answer == DialogResult.Yes)
            {
                project.Upgrade();
                pathTextBox.Text = project.FileName;
                buildDirTextBox.Enabled = true;
                typeDropDown.Enabled = true;
                buildDirTextBox.Text = project.BuildPath;
                typeDropDown.Text = project.Compiler;
                upgradeButton.Visible = false;
            }
        }

        private void typeDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResoLabel.Visible = resoDropDown.Visible = widthTextBox.Visible = heightTextBox.Visible =
                typeDropDown.Text == "Sphere 1.x Compatible";
        }

        private void resoDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (resoDropDown.SelectedIndex > 0)
            {
                var match = new Regex(@"(\d+)x(\d+)").Match(resoDropDown.Text);
                widthTextBox.Text = match.Groups[1].Value;
                heightTextBox.Text = match.Groups[2].Value;
                widthTextBox.Enabled = false;
                heightTextBox.Enabled = false;
            }
            else
            {
                widthTextBox.Enabled = true;
                heightTextBox.Enabled = true;
                widthTextBox.Focus();
                widthTextBox.SelectAll();
            }
        }

        private void resoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != '\t' && e.KeyChar != '\b';
        }
    }
}
