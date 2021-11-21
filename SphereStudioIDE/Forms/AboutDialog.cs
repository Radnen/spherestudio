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

            this.labelProductName.Text = $"{Versioning.Name} {Versioning.Version}";
            this.labelCopyright.Text = $"\xA9 {Versioning.Copyright}";
            this.labelCompanyName.Text = Versioning.Author;

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
