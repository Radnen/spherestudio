using System;

namespace SphereStudio
{
    // note: `const` is resolved at compile time in the referencing assembly.  this is
    //       desirable for built-in plugins to avoid them dynamically adopting the version number
    //       of the Sphere Studio installation they're running against.

    /// <summary>
    /// Provides versioning information for Sphere Studio.
    /// </summary>
    public static class Versioning
    {
        /// <summary>
        /// The name of the IDE used for branding.
        /// </summary>
        public const string Name = "Sphere Studio";

        /// <summary>
        /// The name of the author used for branding.
        /// </summary>
        public const string Author = "Spherical";

        /// <summary>
        /// The version number of the software.
        /// </summary>
        public const string Version = "1.3.0";

        /// <summary>
        /// A string indicating the copyright holder and year(s) of copyright.
        /// </summary>
        public const string Copyright = "2020 Sphere Engine Group";

        /// <summary>
        /// A short description of the software along with a list of contributors.
        /// </summary>
        public const string Credits =
            "A modern game development environment for Sphere, coded in C# and sporting many useful features like debugging, support for compilers, plugins, and more.\r\n\r\n" +
            "DEVELOPERS\r\n" +
            "  Andrew Helenius ('Radnen')\r\n" +
            "  Bruce Pascoe ('Fat Cerberus')\r\n\r\n" +
            "TESTERS\r\n" +
            "  DaVince\r\n" +
            "  Eggbertx\r\n" +
            "  Flying Jester";

    }
}
