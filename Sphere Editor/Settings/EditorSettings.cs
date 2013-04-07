using System;
using System.IO;
using System.Windows.Forms;
using Sphere_Editor.Utility;

namespace Sphere_Editor.Settings
{
    public partial class EditorSettings : Form
    {
        #region getters and setters
        public string SpherePath
        {
            get { return SpherePathBox.Text; }
            set { SpherePathBox.Text = value; }
        }

        public string ConfigPath
        {
            get { return ConfigPathBox.Text; }
            set { ConfigPathBox.Text = value; }
        }

        public string[] GamePaths
        {
            get
            {
                string[] strings = new string[PathListBox.Items.Count];
                PathListBox.Items.CopyTo(strings, 0);
                return strings;
            }
            set { PathListBox.Items.AddRange(value); }
        }

        public string LabelFont
        {
            get { return FontComboBox.Text; }
            set { FontComboBox.Text = value; }
        }

        public bool UseDockForm
        {
            get { return !ItemCheckBox.GetItemChecked(0); }
            set { ItemCheckBox.SetItemChecked(0, !value); }
        }

        public bool AutoStart
        {
            get { return ItemCheckBox.GetItemChecked(2); }
            set { ItemCheckBox.SetItemChecked(2, value); }
        }

        public bool UseScriptUpdate
        {
            get { return ItemCheckBox.GetItemChecked(1); }
            set { ItemCheckBox.SetItemChecked(1, value); }
        }
        #endregion

        public EditorSettings(SphereSettings settings)
        {
            InitializeComponent();
            SpherePath = settings.SpherePath;
            ConfigPath = settings.ConfigPath;
            GamePaths = settings.GetGamePaths();
            UseDockForm = settings.UseDockForm;
            AutoStart = settings.AutoOpen;
            UseScriptUpdate = settings.UseScriptUpdate;
            LabelFont = settings.LabelFont;
        }

        private void SpherePathButton_Click(object sender, EventArgs e)
        {
            if (FolderBrowser.ShowDialog() == DialogResult.OK)
            {
                string path = FolderBrowser.SelectedPath;
                if (File.Exists(path + "\\engine.exe"))
                    SpherePathBox.Text = path + "\\engine.exe";
                if (File.Exists(path + "\\config.exe"))
                    ConfigPathBox.Text = path + "\\config.exe";
                if (Directory.Exists(path + "\\games"))
                    PathListBox.Items.Add(path + "\\games");
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (FolderBrowser.ShowDialog() == DialogResult.OK)
            {
                PathListBox.Items.Add(FolderBrowser.SelectedPath);
            }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            PathListBox.Items.RemoveAt(PathListBox.SelectedIndex);
            if (PathListBox.Items.Count == 0) RemoveButton.Enabled = false;
        }

        private void PathListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RemoveButton.Enabled = true;
        }

        private void EditorSettings_Load(object sender, EventArgs e)
        {
            foreach (PluginWrapper wrapper in Global.plugins)
            {
                ListViewItem item = new ListViewItem();
                item.Text = wrapper.Plugin.Name;
                item.SubItems.Add(wrapper.Plugin.Author);
                item.SubItems.Add(wrapper.Plugin.Version);
                item.SubItems.Add(wrapper.Plugin.Description);
                PluginList.Items.Add(item);
            }
        }

        private void PluginList_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            int index = PluginList.Items.IndexOf(e.Item);
            if (e.Item.Checked) Global.plugins[index].Activate();
            else Global.plugins[index].Deactivate();
        }
    }
}
