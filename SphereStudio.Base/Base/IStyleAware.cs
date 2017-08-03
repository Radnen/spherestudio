namespace SphereStudio.Base
{
    /// <summary>
    /// Specifies the interface for a style-aware component.
    /// </summary>
    public interface IStyleAware
    {
        /// <summary>
        /// Sphere Studio calls this to restyle the component.
        /// </summary>
        void ApplyStyle(UIStyle style);
    }
}
