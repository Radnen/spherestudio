using System;
using System.IO;
using System.Windows.Forms;

using SphereStudio.Forms;

namespace SphereStudio
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var form = new IDEForm();

            // check for and open files dragged onto it.
            foreach (string s in args)
            {
                if (!File.Exists(s)) continue;
                form.OpenFile(s);
            }

            if (args.Length > 0 && File.Exists(args[args.Length - 1]))
                form.SetDefaultActive(args[args.Length - 1]);

            Application.Run(form);
        }
    }
}
