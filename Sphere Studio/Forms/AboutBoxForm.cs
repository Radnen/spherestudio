using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace SphereStudio.Forms
{
    internal partial class AboutBoxForm : Form
    {
        public AboutBoxForm()
        {
            InitializeComponent();
            this.Text = String.Format("About {0}", AssemblyTitle);
            this.labelProductName.Text = string.Format("{0} {1}", AssemblyProduct, AssemblyVersion);
            this.labelCopyright.Text = AssemblyCopyright;
            this.labelCompanyName.Text = "By: " + AssemblyCompany;
            Version os = Environment.OSVersion.Version;
            string windowsVersion = os.Major == 5 && os.Minor == 1 ? "XP"
                : os.Major == 6 && os.Minor == 0 ? "Vista"
                : os.Major == 6 && os.Minor == 1 ? "7"
                : os.Major == 6 && os.Minor == 2 ? "8"
                : os.Major == 6 && os.Minor == 3 ? "8.1"
                : os.Major == 10 && os.Minor == 0 ? "10"
                : string.Format("{0}.{1}", os.Major, os.Minor);
            this.labelPlatform.Text = string.Format("Windows {0}\n{1}",
                windowsVersion, Environment.Is64BitProcess ? "x64" : "x86");
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
