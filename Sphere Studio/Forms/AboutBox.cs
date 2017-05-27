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
            this.Text = String.Format("About {0}", AssemblyTitle);
            this.labelProductName.Text = string.Format("{0} {1}", AssemblyProduct, AssemblyVersion);
            this.labelCopyright.Text = AssemblyCopyright;
            this.labelCompanyName.Text = "By: " + AssemblyCompany;
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
                updateName = os.Version.Build == 10240 ? "RTM"
                    : os.Version.Build == 10586 ? "November Update"
                    : os.Version.Build == 14393 ? "Anniversary Update"
                    : os.Version.Build == 15063 ? "Creators Update"
                    : string.Format("{0}.{1}.{2}", os.Version.Major, os.Version.Minor, os.Version.Build);
            }
            this.labelPlatform.Text = string.Format("Windows\x2122 {0}\n{1}",
                windowsVersion, updateName);
            this.textBoxDescription.Text = AssemblyDescription;
        }

        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Application.ProductVersion;
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion

        private void websiteUrlLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(websiteUrlLink.Text.Substring(
                websiteUrlLink.LinkArea.Start,
                websiteUrlLink.LinkArea.Length));
        }
    }
}
