using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

using Sphere.Plugins;
using Sphere.Plugins.Interfaces;

namespace minisphere.Remote
{
    public class minisphereDebugPlugin : IDebugPlugin
    {
        public string Name { get { return "minisphere Remote"; } }
        public string Author { get { return "Fat Cerberus"; } }
        public string Description { get { return "Provides debug support for minisphere."; } }
        public string Version { get { return "1.7.0"; } }

        public Icon Icon { get; private set; }

        public void Initialize(ISettings conf)
        {
        }

        public void ShutDown()
        {

        }

        public async Task<IDebugger> Debug(IProject project)
        {
            // start minisphere in debugging mode
            string enginePath = PluginManager.IDE.EnginePath;
            string args = string.Format(@"--debug --game ""{0}""\game.sgm", project.RootPath);
            Process engine = Process.Start(enginePath, args);

            // fire up the debugger
            DebugSession client = new DebugSession(project, enginePath, engine);
            try
            {
                await client.Connect("localhost", 812);
                return client;
            }
            catch (TimeoutException)
            {
                return null;
            }
        }
    }
}
