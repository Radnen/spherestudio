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

        public void Initialize(ISettings conf)
        {
            PluginManager.Register(this, new CellCompiler(conf), "Cell");
            PluginManager.Register(this, new minisphereStarter(conf), "minisphere");
            PluginManager.Register(this, new SettingsPage(conf), "minisphere GDK");
            PluginManager.IDE.UnloadProject += on_UnloadProject;
            Views.Initialize(this, conf);
        }

        public void ShutDown()
        {
            PluginManager.UnregisterAll(this);
            PluginManager.IDE.UnloadProject -= on_UnloadProject;
            Views.ShutDown();
        }

        private void on_UnloadProject(object sender, EventArgs e)
        {
            Views.Errors.Clear();
            Views.Console.Clear();
        }
    }

    static class Views
    {
        public static void Initialize(IPluginMain main, ISettings conf)
        {
            PluginManager.Register(main, Inspector = new InspectorPane(), "Variables");
            PluginManager.Register(main, Stack = new StackPane(), "Call Stack");
            PluginManager.Register(main, Console = new ConsolePane(), "Debug Output");
            PluginManager.Register(main, Errors = new ErrorPane(), "Error View");

            if (conf.GetBoolean("keepConsoleOutput", false))
                PluginManager.IDE.Docking.Show(Console);
        }

        public static void ShutDown()
        {
            PluginManager.Unregister(Console);
            PluginManager.Unregister(Errors);
            PluginManager.Unregister(Inspector);
            PluginManager.Unregister(Stack);
        }

        public static ConsolePane Console { get; private set; }
        public static ErrorPane Errors { get; private set; }
        public static InspectorPane Inspector { get; private set; }
        public static StackPane Stack { get; private set; }
    }
}
