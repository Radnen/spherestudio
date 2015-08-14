using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using SphereStudio.Settings;
using Sphere.Core.Editor;
using Sphere.Plugins;

namespace SphereStudio.Forms
{
    internal partial class EditorSettings : Form, IStyleable
    {
        #region getters and setters
        public string[] GamePaths
        {
            get
            {
                string[] strings = new string[PathListBox.Items.Count];
                PathListBox.Items.CopyTo(strings, 0);
                return strings;
            }
            set { PathListBox.Items.Clear(); PathListBox.Items.AddRange(value); }
        }

        public string Style
        {
            get { return StyleComboBox.Text; }
            set { StyleComboBox.Text = value; }
        }

        public bool UseScriptUpdate
        {
            get { return ItemCheckBox.GetItemChecked(0); }
            set { ItemCheckBox.SetItemChecked(0, value); }
        }

        public bool AutoStart
        {
            get { return ItemCheckBox.GetItemChecked(1); }
            set { ItemCheckBox.SetItemChecked(1, value); }
        }

        public bool UseStartPage
        {
            get { return ItemCheckBox.GetItemChecked(2); }
            set { ItemCheckBox.SetItemChecked(2, value); }
        }

        #endregion

        public EditorSettings(CoreSettings settings)
        {
            InitializeComponent();

            foreach (var item in StyleSettings.Styles)
                StyleComboBox.Items.Add(item.Key);
            FillValues(settings);
        }

        private void FillValues(CoreSettings settings)
        {
            GamePaths = settings.ProjectPaths;
            AutoStart = settings.AutoOpenProject;
            UseScriptUpdate = settings.AutoScriptHeader;
            UseStartPage = settings.AutoStartPage;
            Style = settings.UIStyle;
            UpdateStyle();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            FolderBrowser.Description = "Choose a custom Sphere games location.\n" +
                                        "Usually Sphere/games/ but you can use your own.";
            if (FolderBrowser.ShowDialog() == DialogResult.OK)
            {
                PathListBox.Items.Add(FolderBrowser.SelectedPath);
            }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            PathListBox.Items.RemoveAt(PathListBox.SelectedIndex);
            RemoveButton.Enabled = PathListBox.Items.Count > 0 && PathListBox.SelectedIndex > 0;
        }

        private void PathListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RemoveButton.Enabled = true;
        }

        private void DownButton_Click(object sender, EventArgs e)
        {
            var index = PathListBox.SelectedIndex;

            if (index + 1 < PathListBox.Items.Count)
            {
                var item = PathListBox.Items[index];
                PathListBox.Items.RemoveAt(index);
                PathListBox.Items.Insert(index + 1, item);
                PathListBox.SelectedIndex = index + 1;
            }
        }

        private void UpButton_Click(object sender, EventArgs e)
        {
            var index = PathListBox.SelectedIndex;

            if (index > 0)
            {
                var item = PathListBox.Items[index];
                PathListBox.Items.RemoveAt(index);
                PathListBox.Items.Insert(index - 1, item);
                PathListBox.SelectedIndex = index - 1;
            }
        }

        public void UpdateStyle()
        {
            StyleSettings.ApplySecondaryStyle(this);
            StyleSettings.ApplyStyle(ButtonPanel);
            StyleSettings.ApplyStyle(okButton);
            StyleSettings.ApplyStyle(cancelButton);
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            StyleSettings.CurrentStyle = Style;
            UpdateStyle();
            Global.Settings.UIStyle = Style;
            Global.Settings.AutoOpenProject = AutoStart;
            Global.Settings.AutoStartPage = UseStartPage;
            Global.Settings.AutoScriptHeader = UseScriptUpdate;
            Global.Settings.ProjectPaths = GamePaths;
            Invalidate(true);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            ApplyButton.PerformClick();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
