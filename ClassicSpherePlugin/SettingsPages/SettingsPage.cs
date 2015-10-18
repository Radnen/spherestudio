using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Sphere.Plugins.Interfaces;

namespace SphereStudio.Vanilla.SettingsPages
{
    partial class SettingsPage : UserControl, ISettingsPage
    {
        private ISettings _conf;

        public SettingsPage(ISettings conf)
        {
            InitializeComponent();
            Control = this;

            _conf = conf;
        }

        public Control Control { get; private set; }

        public bool Apply()
        {
            _conf.SetValue("spherePath", SpherePathEdit.Text);
            return true;
        }

        protected override void OnLoad(EventArgs e)
        {
            SpherePathEdit.Text = _conf.GetString("spherePath", "");
            base.OnLoad(e);
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            fb.Description = "Where do you have classic Sphere installed?";
            fb.ShowNewFolderButton = false;
            if (fb.ShowDialog(this) == DialogResult.OK)
            {
                SpherePathEdit.Text = fb.SelectedPath;
            }
        }

        private void ConfigButton_Click(object sender, EventArgs e)
        {
            var configAppPath = Path.Combine(SpherePathEdit.Text, "config.exe");
            if (File.Exists(configAppPath))
            {
                Directory.SetCurrentDirectory(SpherePathEdit.Text);
                Process.Start(configAppPath);
                Directory.SetCurrentDirectory(Application.StartupPath);
            }
        }

        private void SpherePath_TextChanged(object sender, EventArgs e)
        {
            ConfigButton.Enabled = File.Exists(Path.Combine(SpherePathEdit.Text, "config.exe"));
        }
    }
}
