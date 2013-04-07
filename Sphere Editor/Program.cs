using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Sphere.Plugins;

namespace Sphere_Editor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            EditorForm ef = new EditorForm();
            Global.EvalPlugins((IPluginHost)ef);
            Application.Run(ef);
        }
    }
}
