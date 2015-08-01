using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

using Sphere.Plugins;
using Sphere.Plugins.Interfaces;

namespace SphereStudio.Plugins
{
    public class DuktapeDebugPlugin : IDebugPlugin
    {
        public string Name { get { return "Duktape Remote"; } }
        public string Author { get { return "Lord English"; } }
        public string Description { get { return "Remote debugger for Duktape-based engines"; } }
        public string Version { get { return "1.2.0"; } }

        public Icon Icon { get; private set; }

        public void Initialize(ISettings conf)
        {
        }

        public void ShutDown()
        {

        }

        public IDebugger Start(IProject project)
        {
            // start minisphere in debugging mode
            string enginePath = PluginManager.IDE.EnginePath;
            string args = string.Format(@"--debug --game ""{0}""\game.sgm", project.RootPath);
            Process.Start(enginePath, args);

            // fire up the debugger
            DuktapeClient client = new DuktapeClient(project);
            try
            {
                client.Connect("localhost", 812);
                return client;
            }
            catch (TimeoutException)
            {
                return null;
            }
        }
    }
}
