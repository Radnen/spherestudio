using System;
using System.IO;
using System.Windows.Forms;

using SphereStudio.Ide.BuiltIns;
using SphereStudio.Ide.Forms;

namespace SphereStudio.Ide
{
    /// <summary>
    /// Represents the global state of the Sphere Studio instance.
    /// </summary>
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            PluginManager.Register(null, new DefaultStyleProvider(), "Sphere Studio");
            PluginManager.Register(null, new IdeSettingsPage(), "Sphere Studio IDE");

            Form = new IdeWindow();

            // check for and open files dragged onto the app.
            foreach (var fileName in args)
            {
                if (File.Exists(fileName))
                {
                    Form.OpenFile(fileName);
                }
            }

            if (args.Length > 0 && File.Exists(args[args.Length - 1]))
            {
                Form.SetDefaultActive(args[args.Length - 1]);
            }

            Application.Run(Form);
        }

        /// <summary>
        /// Gets the form representing the IDE main window.
        /// </summary>
        public static IdeWindow Form { get; private set; }
    }
}
