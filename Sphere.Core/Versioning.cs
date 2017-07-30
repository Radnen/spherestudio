namespace Sphere.Core
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
        /// The name of the IDE, "Sphere Studio".
        /// </summary>
        public const string Name = "Sphere Studio";

        /// <summary>
        /// The name of the IDE author or supporting company.
        /// </summary>
        public const string Author = "Spherical Community";

        /// <summary>
        /// The version number of the IDE.
        /// </summary>
        public const string Version = "X.X.X";

        /// <summary>
        /// A string indicating the copyright holder and date of copyright.
        /// </summary>
        public const string Copyright = "2013-2017 S.E.G.";

        /// <summary>
        /// A short description of the IDE along with a list of contributors.
        /// </summary>
        public const string Credits =
            "A modern game development environment for Sphere, coded in C# and sporting many useful features like debugging, support for compilers, plugins, and more.\r\n\r\n" +
            "DEVELOPERS\r\n" +
            "  Andrew Helenius ('Radnen')\r\n" +
            "  Bruce Pascoe ('Fat Cerberus')\r\n\r\n" +
            "TESTERS\r\n" +
            "  DaVince\r\n" +
            "  Eggbert\r\n" +
            "  Flying Jester";

    }
}
