using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sphere.Plugins;
using Sphere.Plugins.Interfaces;

namespace SphereStudio.Vanilla.Plugins
{
    class SphereStarter : IStarter
    {
        private ISettings _conf;

        public SphereStarter(ISettings conf)
        {
            _conf = conf;
        }

        public bool CanConfigure
        {
            get
            {
                string spherePath = _conf.GetString("spherePath", "");
                return File.Exists(Path.Combine(spherePath, "config.exe"));
            }
        }

        public void Start(string gamePath, bool isPackage)
        {
            string enginePath = Path.Combine(_conf.GetString("spherePath", ""), "engine.exe");
            string options = string.Format(@"-game ""{0}""", gamePath);
            Process.Start(enginePath, options);
        }

        public void Configure()
        {
            if (!CanConfigure)
                throw new NotSupportedException("Engine doesn't support configuration.");

            string spherePath = _conf.GetString("spherePath", "");
            ProcessStartInfo psi = new ProcessStartInfo()
            {
                FileName = Path.Combine(spherePath, "config.exe"),
                UseShellExecute = false,
                WorkingDirectory = spherePath,
            };
            Process.Start(psi);
        }
    }
}
