using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Sphere.Core.Settings;
using Sphere.Plugins;

namespace Sphere.Plugins
{
    public class SPKPackerPlugin : IPlugin
    {
        public string Name { get { return "SPK Packager"; } }
        public string Author { get { return "Lord English"; } }
        public string Description { get { return "Sphere Studio default game packager"; } }
        public string Version { get { return "1.2.0"; } }

        public Icon Icon { get; set; }

        private ToolStripMenuItem rootMenu;
        private ToolStripMenuItem packageMenuItem;

        private void packageGame_Click(object sender, EventArgs e)
        {
            ProjectSettings project;

            if ((project = PluginManager.IDE.CurrentGame) == null)
                MessageBox.Show("No game loaded!", "SPK Packager", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                new MakePackageForm(project.RootPath).ShowDialog();
            }
        }

        public SPKPackerPlugin()
        {
            packageMenuItem = new ToolStripMenuItem("&Package Game...", Properties.Resources.Checkmark, packageGame_Click);
            
            // build menu structure
            rootMenu = new ToolStripMenuItem("&Package");
            rootMenu.DropDownItems.Add(packageMenuItem);
            PluginManager.IDE.AddMenuItem(rootMenu, "View");
        }

        public void Initialize()
        {
        }

        public void Destroy()
        {

        }
    }
}
