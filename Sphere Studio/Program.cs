﻿using System;
using System.IO;
using System.Windows.Forms;

using SphereStudio.Forms;

namespace SphereStudio
{
    /// <summary>
    /// Represents the global state of the Sphere Studio instance.
    /// </summary>
    static class Program
    {
        public const string Name = "Sphere Studio";
        public const string Author = "Spherical Community";
        public const string Version = "X.X.X";
        public const string Copyright = "2013-2017 S.E.G.";

        public const string Credits = "A modern game development environment for Sphere, coded in C# and sporting many useful features like debugging, support for compilers, plugins, and more.\r\n\r\n"
                                    + "DEVELOPERS\r\n"
                                    + "  Andrew Helenius ('Radnen')\r\n"
                                    + "  Bruce Pascoe ('Fat Cerberus')\r\n\r\n"
                                    + "TESTERS\r\n"
                                    + "  DaVince\r\n"
                                    + "  Eggbert\r\n"
                                    + "  Flying Jester";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form = new MainWindow();

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
        public static MainWindow Form { get; private set; }
    }
}
