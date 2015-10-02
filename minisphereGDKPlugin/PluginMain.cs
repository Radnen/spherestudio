using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

using Sphere.Plugins;
using Sphere.Plugins.Interfaces;
using minisphere.GDK.Debugger.UI;
using minisphere.GDK.Plugin;

namespace minisphere.GDK
{
    public class PluginMain : IPluginMain
    {
        public string Name { get { return "minisphere GDK"; } }
        public string Author { get { return "Fat Cerberus"; } }
        public string Description { get { return "Provides support for the minisphere GDK toolchain."; } }
        public string Version { get { return "2.0b1"; } }

        public Icon Icon { get; private set; }

        public void Initialize(ISettings conf)
        {
            PluginManager.RegisterPlugin(this, new CellCompiler(conf), "Cell");
            PluginManager.RegisterPlugin(this, new minisphereStarter(conf), "minisphere");
            PluginManager.RegisterPlugin(this, new SettingsPage(conf), "minisphere GDK");
            PluginManager.IDE.UnloadProject += IDE_UnloadProject;
            Views.Initialize(conf);
        }

        public void ShutDown()
        {
            PluginManager.UnregisterPlugins(this);
            PluginManager.IDE.UnloadProject -= IDE_UnloadProject;
            Views.ShutDown();
        }

        public bool Configure()
        {
            return true;
        }

        private void IDE_UnloadProject(object sender, EventArgs e)
        {
            Views.Errors.Clear();
            Views.Console.Clear();
        }
    }

    static class Views
    {
        public static ConsolePane Console { get; private set; }
        public static ErrorPane Errors { get; private set; }
        public static InspectorPane Inspector { get; private set; }
        public static StackPane Stack { get; private set; }

        public static void Initialize(ISettings conf)
        {
            Inspector = new InspectorPane();
            Stack = new StackPane();
            Console = new ConsolePane();
            Errors = new ErrorPane();

            if (!conf.GetBoolean("keepConsoleOutput", false))
                Console.DockPane.Hide();
            Errors.DockPane.Hide();
            Inspector.DockPane.Hide();
            Stack.DockPane.Hide();
        }

        public static void ShutDown()
        {
            Console.Dispose();
            Errors.Dispose();
            Inspector.Dispose();
            Stack.Dispose();
        }
    }
}
