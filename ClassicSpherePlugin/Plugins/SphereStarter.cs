using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            if (File.Exists(enginePath))
                Process.Start(enginePath, options);
            else
            {
                MessageBox.Show("Sphere 1.x or compatible engine was not found. Please check your Sphere installation path under Settings Center -> Sphere 1.x Setup.",
                    "Unable to Start Engine", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
