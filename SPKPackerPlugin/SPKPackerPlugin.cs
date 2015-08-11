using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Sphere.Plugins;
using Sphere.Plugins.Interfaces;

namespace SphereStudio.Plugins
{
    public class SPKPackerPlugin : IPlugin
    {
        public string Name { get { return "SPK Packager"; } }
        public string Author { get { return "Lord English"; } }
        public string Description { get { return "Sphere Studio default game packager"; } }
        public string Version { get { return "1.2.0"; } }

        public Icon Icon { get; set; }

        private ISettings _conf;
        private ToolStripMenuItem  packageMenuItem;
        private ToolStripSeparator menuSeparator1;
        
        private void packageGame_Click(object sender, EventArgs e)
        {
            IProject project;

            if ((project = PluginManager.IDE.CurrentGame) == null)
                MessageBox.Show("You must load a project into the editor first.", "SPK Packager", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                PluginManager.IDE.CurrentGame.Build();
                new MakePackageForm(project.RootPath, _conf).ShowDialog();
            }
        }

        public SPKPackerPlugin()
        {
            packageMenuItem = new ToolStripMenuItem("&Package Game...", null, packageGame_Click);
            packageMenuItem.Enabled = false;
            menuSeparator1 = new ToolStripSeparator();
        }

        public void Initialize(ISettings conf)
        {
            _conf = conf;
            
            PluginManager.IDE.AddMenuItem("Project", menuSeparator1);
            PluginManager.IDE.AddMenuItem("Project", packageMenuItem);
            PluginManager.IDE.LoadProject += IDE_LoadProject;
            PluginManager.IDE.UnloadProject += IDE_UnloadProject;
        }

        public void ShutDown()
        {
            PluginManager.IDE.RemoveMenuItem(packageMenuItem);
            PluginManager.IDE.RemoveMenuItem(menuSeparator1);

            PluginManager.IDE.LoadProject -= IDE_LoadProject;
            PluginManager.IDE.UnloadProject -= IDE_UnloadProject;
        }

        private void IDE_LoadProject(object sender, EventArgs e)
        {
            packageMenuItem.Enabled = true;
        }

        private void IDE_UnloadProject(object sender, EventArgs e)
        {
            packageMenuItem.Enabled = false;
        }
    }
}
