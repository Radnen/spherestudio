using System;
using System.Reflection;
using System.Windows.Forms;

namespace Sphere_Editor.Forms
{
    /* Just a basic splash screen class I can use when loading stuff. */
    public partial class SplashScreen : Form
    {
        ScintillaNET.Scintilla _codebox = new ScintillaNET.Scintilla();
        delegate void SplashDelegate();
        private bool fadein = true;
        private int _prog = 0;

        public SplashScreen()
        {
            InitializeComponent();            

            Opacity = 0.00;
            VersionLabel.Text = "Version: " + AssemblyVersion;
            AuthorLabel.Text = "By: " + AssemblyCompany;

            _codebox.Show();
            _codebox.Dispose();
        }

        public int Progress
        {
            get { return _prog; }
            set { _prog = value; StatusLabel.Text = "Loading: " + value + "%"; }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
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

        private void SplashScreen_Shown(object sender, EventArgs e)
        {
            fadein = true;
            OpacityTimer.Start();
        }

        private void OpacityTimer_Tick(object sender, EventArgs e)
        {
            if (fadein) Opacity += 0.05;
            else Opacity -= 0.05;

            if (Opacity >= 1.00) OpacityTimer.Stop();
            if (Opacity <= 0) Close();
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            _codebox.ConfigurationManager.CustomLocation = Application.StartupPath + "\\SphereLexer.xml";
            _codebox.ConfigurationManager.Language = "js";
            _codebox.AutoComplete.StopCharacters = "";
            _codebox.AutoComplete.ListString = Global.CurrentScriptSettings.FunctionList;
            _codebox.AutoComplete.ListSeparator = ';';
        }
    }
}
