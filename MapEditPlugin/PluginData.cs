using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Sphere.Core;

namespace MapEditPlugin
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
