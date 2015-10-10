using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

using Sphere.Plugins;
using Sphere.Plugins.Interfaces;
using minisphere.Gdk.DockPanes;
using minisphere.Gdk.Plugins;
using minisphere.Gdk.SettingsPages;

namespace minisphere.Gdk
{
    public class PluginMain : IPluginMain
    {
        public string Name { get { return "minisphere GDK"; } }
        public string Author { get { return "Fat Cerberus"; } }
        public string Description { get { return "Provides support for the minisphere GDK toolchain."; } }
        public string Version { get { return "2.0b1"; } }

        internal ISettings Settings { get; private set; }

        public void Initialize(ISettings conf)
        {
            Settings = conf;

            PluginManager.Register(this, new CellCompiler(conf), "Cell");
            PluginManager.Register(this, new minisphereStarter(conf), "minisphere");
            PluginManager.Register(this, new SettingsPage(conf), "minisphere GDK");

            Panes.Initialize(this);

            PluginManager.Core.UnloadProject += on_UnloadProject;
        }

        public void ShutDown()
        {
            PluginManager.Core.UnloadProject -= on_UnloadProject;
            PluginManager.UnregisterAll(this);
        }

        private void on_UnloadProject(object sender, EventArgs e)
        {
            Panes.Errors.Clear();
            Panes.Console.Clear();
        }
    }

    static class Panes
    {
        public static void Initialize(PluginMain main)
        {
            PluginManager.Register(main, Inspector = new InspectorPane(), "Variables");
            PluginManager.Register(main, Stack = new StackPane(), "Call Stack");
            PluginManager.Register(main, Console = new ConsolePane(), "Debug Output");
            PluginManager.Register(main, Errors = new ErrorPane(), "Error View");

            if (main.Settings.GetBoolean("keepConsoleOutput", true))
            {
                PluginManager.Core.Docking.Show(Console);
            }
        }

        public static ConsolePane Console { get; private set; }
        public static ErrorPane Errors { get; private set; }
        public static InspectorPane Inspector { get; private set; }
        public static StackPane Stack { get; private set; }
    }
}
