namespace SphereStudio.Base
{
    /// <summary>
    /// Specifies the interface for a text console, as used for, e.g.
    /// the build system.
    /// </summary>
    public interface IConsole
    {
        /// <summary>
        /// Prints text to the console. Newlines must be printed manually.
        /// </summary>
        /// <param name="text">The text to be printed.</param>
        void Print(string text);
    }
}
