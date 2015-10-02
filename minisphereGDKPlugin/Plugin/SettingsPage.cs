using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Sphere.Plugins.Interfaces;

namespace minisphere.GDK.Plugin
{
    public partial class SettingsPage : UserControl, ISettingsPage
    {
        private ISettings config;

        public SettingsPage(ISettings conf)
        {
            InitializeComponent();
            config = conf;
        }

        public Control Control { get { return this; } }

        public bool Apply()
        {
            config.SetValue("gdkPath", GDKPath.Text);
            config.SetValue("debuggablePackages", MakeDebugPackage.Checked);
            config.SetValue("keepConsoleOutput", KeepConsoleOpen.Checked);
            config.SetValue("testWithConsole", TestWithConsole.Checked);
            return true;
        }

        protected override void OnLoad(EventArgs e)
        {
            GDKPath.Text = config.GetString("gdkPath", "");
            MakeDebugPackage.Checked = config.GetBoolean("debuggablePackages", false);
            KeepConsoleOpen.Checked = config.GetBoolean("keepConsoleOutput", false);
            TestWithConsole.Checked = config.GetBoolean("testWithConsole", false);

            base.OnLoad(e);
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            fb.Description = "Select the folder where the minisphere GDK is installed. (minisphere 2.0+ required)";
            fb.ShowNewFolderButton = false;
            if (fb.ShowDialog(this) == DialogResult.OK)
            {
                GDKPath.Text = fb.SelectedPath;
            }
        }
    }
}
