using System;
using System.IO;
using System.Windows.Forms;

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

        public string GamePath
        {
            get { return GamePathBox.Text; }
            set { GamePathBox.Text = value; }
        }

        public string LabelFont
        {
            get { return FontComboBox.Text; }
            set { FontComboBox.Text = value; }
        }

        public bool UseDockForm
        {
            get { return !WineCheckBox.Checked; }
            set { WineCheckBox.Checked = !value; }
        }

        public bool AutoStart
        {
            get { return AutoStartCheckBox.Checked; }
            set { AutoStartCheckBox.Checked = value; }
        }

        public bool UseScriptUpdate
        {
            get { return ScriptUpdateCheckBox.Checked; }
            set { ScriptUpdateCheckBox.Checked = value; }
        }
        #endregion

        public EditorSettings(SphereSettings settings)
        {
            InitializeComponent();
            SpherePath = settings.SpherePath;
            ConfigPath = settings.ConfigPath;
            GamePath = settings.GamesPath;
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
                if (Directory.Exists(path + "\\games") && string.IsNullOrEmpty(GamePathBox.Text))
                    GamePathBox.Text = path + "\\games";
            }
        }

        private void GamesPathButton_Click(object sender, EventArgs e)
        {
            if (FolderBrowser.ShowDialog() == DialogResult.OK)
                GamePath = FolderBrowser.SelectedPath;
        }

        #region tip texts
        private void ClearTip(object sender, EventArgs e)
        {
            SettingsTip.Clear();
        }

        private void GamesPathButton_MouseEnter(object sender, EventArgs e)
        {
            SettingsTip.Text = "Click if you want to use a different games path.";
        }

        private void SpherePathButton_MouseEnter(object sender, EventArgs e)
        {
            SettingsTip.Text = "The sphere search shall automatically fill out paths.";
        }

        private void DockCheckBox_MouseEnter(object sender, EventArgs e)
        {
            SettingsTip.Text = "Wine users should uncheck this option.";
        }

        private void AutoStartCheckBox_MouseEnter(object sender, EventArgs e)
        {
            SettingsTip.Text = "Checking this will allow the editor to reopen the last project when loading.";
        }

        private void HideTipCheckBox_MouseEnter(object sender, EventArgs e)
        {
            SettingsTip.Text = "Checking this will hide all help tips. Not recommended to new users.";
        }

        private void FontComboBox_MouseEnter(object sender, EventArgs e)
        {
            SettingsTip.Text = "Choose here for the title and tip label font.";
        }

        private void ScriptUpdateCheckBox_MouseEnter(object sender, EventArgs e)
        {
            SettingsTip.Text = "Setting this to true gives you self-updating script headers.";
        }
        #endregion
    }
}
