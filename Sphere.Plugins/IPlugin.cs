using System.Drawing;

namespace Sphere.Plugins
{
    /// <summary>
    /// Used to implement a general plugin.
    /// </summary>
    public interface IPlugin
    {
        string Name { get; }
        string Author { get; }
        string Description { get; }
        string Version { get; }

        Icon Icon { get; }

        void Initialize();
        void Destroy();
    }
}
