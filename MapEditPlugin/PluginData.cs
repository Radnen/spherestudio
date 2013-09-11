using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sphere.Core;
using Sphere.Plugins;

namespace SphereStudio.Plugins
{
    internal static class PluginData
    {
        public static Entity CopiedEnt;
        public static List<string> Functions = new List<string>();

        static PluginData()
        {
            LoadFunctions();
        }
        
        public static void LoadFunctions()
        {
            FileInfo file = new FileInfo(Application.StartupPath + "/docs/functions.txt");
            if (!file.Exists) return;

            using (StreamReader reader = file.OpenText())
            {
                while (!reader.EndOfStream)
                    Functions.Add(reader.ReadLine());
            }
        }
    }
}
