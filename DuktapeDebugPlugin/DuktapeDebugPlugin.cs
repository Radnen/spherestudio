using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;

namespace Sphere.Plugins
{
    public class DuktapeDebugPlugin : IPlugin
    {
        public string Name { get { return "minisphere Debugger"; } }
        public string Author { get { return "Lord English"; } }
        public string Description { get { return "A stepping debugger for minisphere"; } }
        public string Version { get { return "1.6.0"; } }

        public Icon Icon { get; private set; }

        public void Initialize(ISettings conf)
        {

        }

        public void Destroy()
        {

        }

        public IDebugger Start(IProject project)
        {
            string exePath = PluginManager.IDE.EnginePath;
            var args = string.Format(@"--debug --game ""{0}""\game.sgm", project.RootPath);
            return new DuktapeClient("localhost", 812);
        }
    }
}
