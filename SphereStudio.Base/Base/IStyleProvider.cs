using SphereStudio.UI;

namespace SphereStudio.Base
{
    /// <summary>
    /// Specifies the interface for a plugin providing UI themes.
    /// </summary>
    public interface IStyleProvider : IPlugin
    {
        /// <summary>
        /// Gets an array of all the themes provided by the plugin.
        /// </summary>
        /// <returns></returns>
        UIStyle[] Styles { get; }
    }
}
