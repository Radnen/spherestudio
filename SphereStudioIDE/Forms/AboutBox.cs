using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using SphereStudio.Base;

namespace SphereStudio.Ide.Forms
{
    partial class AboutBox : Form, IStyleAware
    {
        public AboutBox()
        {
            InitializeComponent();

            this.labelProductName.Text = $"{Versioning.Name} {Versioning.Version}";
            this.labelCopyright.Text = $"\xA9 {Versioning.Copyright}";
            this.labelCompanyName.Text = Versioning.Author;
            this.creditsTextBox.Text = Versioning.Credits;

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
                // Windows 11 is still v10.0, have to detect via build number
                if (os.Version.Build >= 22000)
                    windowsVersion = "11";

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
                    : os.Version.Build == 19042 ? "Oct. 2020 Update"
                    : os.Version.Build == 19043 ? "May 2021 Update"
                    : os.Version.Build == 22000 ? "v. 21H2"
                    : $"build {os.Version.Build}";
            }
            var architecture = RuntimeInformation.OSArchitecture == Architecture.X64 ? "x64"
                : RuntimeInformation.OSArchitecture == Architecture.Arm64 ? "ARM64"
                : RuntimeInformation.OSArchitecture == Architecture.Arm ? "ARM"
                : "x86";
            this.labelPlatform.Text = $"Windows {windowsVersion} {architecture}\n{updateName}";

            StyleManager.AutoStyle(this);
        }

        public void ApplyStyle(UIStyle style)
        {
            style.AsUIElement(this);
            style.AsHeading(header);
            style.AsHeading(versionHeader);
            style.AsHeading(footerPanel);
            style.AsAccent(versionPanel);
            style.AsAccent(closeButton);
            style.AsTextView(creditsTextBox);
        }

        private void websiteUrlLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(websiteUrlLink.Text.Substring(
                websiteUrlLink.LinkArea.Start,
                websiteUrlLink.LinkArea.Length));
        }
    }
}
