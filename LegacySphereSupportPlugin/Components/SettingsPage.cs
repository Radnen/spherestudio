using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

using SphereStudio.Base;

namespace SphereStudio.Plugins.Components
{
    partial class SettingsPage : UserControl, ISettingsPage, IStyleAware
    {
        private ISettings _conf;

        public SettingsPage(ISettings conf)
        {
            InitializeComponent();
            Control = this;

            _conf = conf;

            StyleManager.AutoStyle(this);
        }

        public Control Control { get; private set; }

        public bool Apply()
        {
            _conf.SetValue("enginePath", enginePathTextBox.Text);
            return true;
        }

        public void ApplyStyle(UIStyle style)
        {
            style.AsUIElement(this);

            style.AsHeading(directoryHeading);
            style.AsAccent(directoryPanel);
            style.AsTextView(enginePathTextBox);
            style.AsAccent(configEngineButton);
            style.AsAccent(browseDirButton);
        }

        protected override void OnLoad(EventArgs e)
        {
            enginePathTextBox.Text = _conf.GetString("enginePath", "");
            base.OnLoad(e);
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            fb.Description = "Where do you have classic Sphere installed?";
            fb.ShowNewFolderButton = false;
            if (fb.ShowDialog(this) == DialogResult.OK)
            {
                enginePathTextBox.Text = fb.SelectedPath;
            }
        }

        private void ConfigButton_Click(object sender, EventArgs e)
        {
            var configAppPath = Path.Combine(enginePathTextBox.Text, "config.exe");
            if (File.Exists(configAppPath))
            {
                Directory.SetCurrentDirectory(enginePathTextBox.Text);
                Process.Start(configAppPath);
                Directory.SetCurrentDirectory(Application.StartupPath);
            }
        }

        private void enginePathTextBox_TextChanged(object sender, EventArgs e)
        {
            configEngineButton.Enabled = File.Exists(Path.Combine(enginePathTextBox.Text, "config.exe"));
        }
    }
}
