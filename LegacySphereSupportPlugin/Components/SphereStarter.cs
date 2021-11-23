using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SphereStudio.Base;

namespace SphereStudio.Plugins.Components
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
                var enginePath = _conf.GetString("enginePath", "");
                return File.Exists(Path.Combine(enginePath, "config.exe"));
            }
        }

        public void Start(string gamePath, bool isPackage)
        {
            var enginePath = Path.Combine(_conf.GetString("enginePath", ""), "engine.exe");
            var options = $@"-game ""{gamePath}""";
            if (File.Exists(enginePath))
                Process.Start(enginePath, options);
            else
            {
                MessageBox.Show(
                    "Sphere 1.x or compatible engine was not found.  Please check your Sphere installation path under Preferences -> Sphere 1.x.",
                    "Unable to Start Engine", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Configure()
        {
            if (!CanConfigure)
                throw new NotSupportedException("Engine doesn't support configuration.");

            var enginePath = _conf.GetString("enginePath", "");
            ProcessStartInfo psi = new ProcessStartInfo()
            {
                FileName = Path.Combine(enginePath, "config.exe"),
                UseShellExecute = false,
                WorkingDirectory = enginePath,
            };
            Process.Start(psi);
        }
    }
}
