using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace SphereStudio.Forms
{
    partial class AboutBox : Form
    {
        public AboutBox()
        {
            InitializeComponent();

            this.Text = String.Format("About {0}", Program.Name);
            this.labelProductName.Text = string.Format("{0} {1}", Program.Name, Program.Version);
            this.labelCopyright.Text = string.Format("\xA9 {0}", Program.Copyright);
            this.labelCompanyName.Text = "By: " + Program.Author;

            // get the installed Windows version
            var os = Environment.OSVersion;
            var windowsVersion = os.Version.Major == 5 && os.Version.Minor == 1 ? "XP"
                : os.Version.Major == 6 && os.Version.Minor == 0 ? "Vista"
                : os.Version.Major == 6 && os.Version.Minor == 1 ? "7"
                : os.Version.Major == 6 && os.Version.Minor == 2 ? "8"
                : os.Version.Major == 6 && os.Version.Minor == 3 ? "8.1"
                : os.Version.Major == 10 && os.Version.Minor == 0 ? "10"
                : string.Format("{0}.{1}", os.Version.Major, os.Version.Minor);
            string updateName = os.ServicePack;
            if (os.Version.Major == 10 && os.Version.Minor == 0)
            {
                // for Windows 10, there are multiple releases.  figure out which one is in use
                // based on the build number.
                updateName = os.Version.Build == 10240 ? "RTM"
                    : os.Version.Build == 10586 ? "November Update"
                    : os.Version.Build == 14393 ? "Anniversary Update"
                    : os.Version.Build == 15063 ? "Creators Update"
                    : string.Format("v{0}.{1}.{2}", os.Version.Major, os.Version.Minor, os.Version.Build);
            }
            this.labelPlatform.Text = string.Format("Windows\x2122 {0}\n{1}", windowsVersion, updateName);
            this.textBoxDescription.Text = Program.Credits;
        }

        private void websiteUrlLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(websiteUrlLink.Text.Substring(
                websiteUrlLink.LinkArea.Start,
                websiteUrlLink.LinkArea.Length));
        }
    }
}
