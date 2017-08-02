namespace SphereStudio.Base
{
    /// <summary>
    /// Specifies the interface for an embedded editor.
    /// </summary>
    public interface IEditor<T> : IPlugin
        where T : DocumentView
    {
        /// <summary>
        /// Creates a new embeddable DocumentView for this editor.
        /// </summary>
        /// <returns></returns>
        T CreateEditView();
    }
}
