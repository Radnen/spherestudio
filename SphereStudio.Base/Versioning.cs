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
        public const string Version = "WiP";

        /// <summary>
        /// Whether the Sphere Studio version being built against is a WiP version.
        /// </summary>
        public const bool IsWiP = true;

        /// <summary>
        /// A string indicating the copyright holder and year(s) of copyright.
        /// </summary>
        public const string Copyright = "2021 Sphere Engine Group";

        /// <summary>
        /// A short description of the software along with a list of contributors.
        /// </summary>
        public const string Credits =
            "DEVELOPERS\r\n" +
            "    Bruce Pascoe ('Fat Cerberus')\r\n" +
            "    Andrew Helenius ('Radnen')\r\n" +
            "\r\nTESTERS\r\n" +
            "    DaVince\r\n" +
            "    Eggbertx\r\n" +
            "    Flying Jester\r\n";
    }
}
