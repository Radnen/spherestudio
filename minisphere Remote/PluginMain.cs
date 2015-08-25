using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

using Sphere.Plugins;
using Sphere.Plugins.Interfaces;
using minisphere.Remote.Panes;

namespace minisphere.Remote
{
    public class minisphereDebugPlugin : IDebugPlugin
    {
        public string Name { get { return "minisphere Remote"; } }
        public string Author { get { return "Fat Cerberus"; } }
        public string Description { get { return "Provides debug support for minisphere."; } }
        public string Version { get { return "1.7.6"; } }

        public Icon Icon { get; private set; }

        public void Initialize(ISettings conf)
        {
            Views.Initialize();
        }

        public void ShutDown()
        {
            Views.ShutDown();
        }

        public IDebugger Debug(IProject project)
        {
            // start minisphere in debugging mode
            string enginePath = PluginManager.IDE.EnginePath;
            string args = string.Format(@"--debug --game ""{0}""", project.Build());
            Process engine = Process.Start(enginePath, args);

            return new DebugSession(project, enginePath, engine);
        }
    }

    static class Views
    {
        public static ConsolePane Console { get; private set; }
        public static ErrorPane Errors { get; private set; }
        public static InspectorPane Inspector { get; private set; }
        public static StackPane Stack { get; private set; }

        public static void Initialize()
        {
            Inspector = new InspectorPane();
            Stack = new StackPane();
            Console = new ConsolePane();
            Errors = new ErrorPane();
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
