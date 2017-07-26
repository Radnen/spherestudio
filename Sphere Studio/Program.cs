using System;
using System.IO;
using System.Windows.Forms;

using SphereStudio.Forms;

namespace SphereStudio
{
    static class Program
    {
        public const string Name = "Sphere Studio";
        public const string Author = "Spherical Community";
        public const string Version = "X.X.X";
        public const string Copyright = "2013-2017 S.E.G.";
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var form = new MainWindow();

            // check for and open files dragged onto the app.
            foreach (string s in args)
            {
                if (!File.Exists(s))
                    continue;
                form.OpenFile(s);
            }

            if (args.Length > 0 && File.Exists(args[args.Length - 1]))
                form.SetDefaultActive(args[args.Length - 1]);

            Application.Run(form);
        }
    }
}
