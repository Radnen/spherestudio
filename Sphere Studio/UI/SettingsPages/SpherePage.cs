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

namespace SphereStudio.UI.SettingsPages
{
    public partial class SpherePage : UserControl, ISettingsPage
    {
        public SpherePage()
        {
            InitializeComponent();
            Control = this;
        }

        public Control Control { get; private set; }

        public bool Apply()
        {
            Global.Settings.SpherePath = SpherePath.Text;
            return true;
        }

        protected override void OnLoad(EventArgs e)
        {
            SpherePath.Text = Global.Settings.SpherePath;

            base.OnLoad(e);
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            fb.Description = "Select the folder where Sphere 1.x is installed.";
            fb.ShowNewFolderButton = false;
            if (fb.ShowDialog(this) == DialogResult.OK)
            {
                SpherePath.Text = fb.SelectedPath;
            }
        }

        private void ConfigButton_Click(object sender, EventArgs e)
        {
            Directory.SetCurrentDirectory(SpherePath.Text);
            Process.Start(Path.Combine(SpherePath.Text, "config.exe"));
            Directory.SetCurrentDirectory(Application.StartupPath);
        }

        private void SpherePath_TextChanged(object sender, EventArgs e)
        {
            ConfigButton.Enabled = File.Exists(Path.Combine(SpherePath.Text, "config.exe"));
        }
    }
}
