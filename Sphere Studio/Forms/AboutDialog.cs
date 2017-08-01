using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

using SphereStudio;
using SphereStudio.UI;

namespace SphereStudio.Ide.Forms
{
    partial class AboutDialog : Form, IStyleable
    {
        public AboutDialog()
        {
            InitializeComponent();

            this.Text = String.Format("About {0}", Versioning.Name);
            this.labelProductName.Text = string.Format("{0} {1}", Versioning.Name, Versioning.Version);
            this.labelCopyright.Text = string.Format("\xA9 {0}", Versioning.Copyright);
            this.labelCompanyName.Text = "By: " + Versioning.Author;

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
            this.textBoxDescription.Text = Versioning.Credits;

            Styler.AutoStyle(this);
        }

        public void ApplyStyle(UIStyle style)
        {
            style.AsUIElement(this);
            style.AsAccent(okButton);
            style.AsTextView(textBoxDescription);
        }

        private void websiteUrlLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(websiteUrlLink.Text.Substring(
                websiteUrlLink.LinkArea.Start,
                websiteUrlLink.LinkArea.Length));
        }
    }
}
