using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

using SphereStudio.Base;
using SphereStudio.UI;

namespace SphereStudio.Ide.Forms
{
    partial class AboutDialog : Form, IStyleAware
    {
        public AboutDialog()
        {
            InitializeComponent();

            this.Text = $"About {Versioning.Name}";
            this.labelProductName.Text = $"{Versioning.Name} {Versioning.Version}";
            this.labelCopyright.Text = $"\xA9 {Versioning.Copyright}";
            this.labelCompanyName.Text = Versioning.Author;

            // get the installed Windows version
            var os = Environment.OSVersion;
            var windowsVersion = os.Version.Major == 5 && os.Version.Minor == 1 ? "XP"
                : os.Version.Major == 6 && os.Version.Minor == 0 ? "Vista"
                : os.Version.Major == 6 && os.Version.Minor == 1 ? "7"
                : os.Version.Major == 6 && os.Version.Minor == 2 ? "8"
                : os.Version.Major == 6 && os.Version.Minor == 3 ? "8.1"
                : os.Version.Major == 10 && os.Version.Minor == 0 ? "10"
                : $"{os.Version.Major}.{os.Version.Minor}";
            string updateName = os.ServicePack;
            if (os.Version.Major == 10 && os.Version.Minor == 0)
            {
                // for Windows 10, there are multiple releases.  figure out which one is in use
                // based on the build number.
                updateName = os.Version.Build == 10240 ? "RTM"
                    : os.Version.Build == 10586 ? "November Update"
                    : os.Version.Build == 14393 ? "Anniversary Update"
                    : os.Version.Build == 15063 ? "Creators Update"
                    : os.Version.Build == 16299 ? "Fall Creators Update"
                    : os.Version.Build == 17134 ? "Apr. 2018 Update"
                    : os.Version.Build == 17763 ? "Oct. 2018 Update"
                    : os.Version.Build == 18362 ? "May 2019 Update"
                    : os.Version.Build == 18363 ? "Nov. 2019 Update"
                    : os.Version.Build == 19041 ? "May 2020 Update"
                    : $"Build {os.Version.Build}";
            }
            var platform = Environment.Is64BitOperatingSystem ? "x64" : "x86";
            this.labelPlatform.Text = $"Windows\x2122 {windowsVersion} - {platform}\n{updateName}";
            this.textBoxDescription.Text = Versioning.Credits;

            StyleManager.AutoStyle(this);
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
