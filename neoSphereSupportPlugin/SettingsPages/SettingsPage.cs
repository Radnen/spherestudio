using System;
using System.Windows.Forms;

using SphereStudio.Base;

namespace SphereStudio.Plugins.SettingsPages
{
    partial class SettingsPage : UserControl, ISettingsPage, IStyleAware
    {
        private PluginMain m_main;

        public SettingsPage(PluginMain main)
        {
            InitializeComponent();
            StyleManager.AutoStyle(this);
            m_main = main;
        }

        public Control Control { get { return this; } }

        public void ApplyStyle(UIStyle style)
        {
            style.AsUIElement(this);

            style.AsHeading(directoryHeading);
            style.AsAccent(directoryPanel);
            style.AsTextView(enginePathTextBox);
            style.AsAccent(browseDirButton);
            
            style.AsHeading(debugHeading);
            style.AsAccent(debugPanel);
            style.AsAccent(testWithConsoleButton);
            style.AsAccent(useSourceMapsButton);
            style.AsAccent(testInWindowButton);
            style.AsAccent(showTracesButton);
            style.AsTextView(logLevelDropDown);
            
            style.AsTextView(enginePathTextBox);
            style.AsTextView(logLevelDropDown);
            style.AsAccent(browseDirButton);
        }

        public bool Apply()
        {
            m_main.Conf.GdkPath = enginePathTextBox.Text;
            m_main.Conf.MakeDebugPackages = useSourceMapsButton.Checked;
            m_main.Conf.AlwaysUseConsole = testWithConsoleButton.Checked;
            m_main.Conf.ShowTraceInfo = showTracesButton.Checked;
            m_main.Conf.TestInWindow = testInWindowButton.Checked;
            m_main.Conf.Verbosity = logLevelDropDown.SelectedIndex;
            return true;
        }

        protected override void OnLoad(EventArgs e)
        {
            enginePathTextBox.Text = m_main.Conf.GdkPath;
            useSourceMapsButton.Checked = m_main.Conf.MakeDebugPackages;
            showTracesButton.Checked = m_main.Conf.ShowTraceInfo;
            testWithConsoleButton.Checked = m_main.Conf.AlwaysUseConsole;
            testInWindowButton.Checked = m_main.Conf.TestInWindow;
            logLevelDropDown.SelectedIndex = m_main.Conf.Verbosity;
            base.OnLoad(e);
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            fb.Description = "Select the folder where Sphere is installed.";
            fb.ShowNewFolderButton = false;
            if (fb.ShowDialog(this) == DialogResult.OK)
            {
                enginePathTextBox.Text = fb.SelectedPath;
            }
        }
    }
}
