﻿using System;
using System.IO;
using System.Windows.Forms;

using SphereStudio.Base;
using SphereStudio.Ide.BuiltIns;
using SphereStudio.Ide.Forms;

namespace SphereStudio.Ide
{
    /// <summary>
    /// Represents the global state of the Sphere Studio instance.
    /// </summary>
    static class Program
    {
        public const string DefaultStyle = "Sphere Studio: Midnight";
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            PluginManager.Register(null, new DefaultStyleProvider(), "Sphere Studio");
            PluginManager.Register(null, new MainSettingsPage(), "Sphere Studio");

            Form = new MainWindowForm();

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
        public static MainWindowForm Form { get; private set; }
    }
}
