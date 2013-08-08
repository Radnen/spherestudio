using System;
using System.Windows.Forms;
using Sphere.Core.Editor;
using Sphere.Core.Settings;
using WeifenLuo.WinFormsUI.Docking;

namespace Sphere.Plugins
{
    /// <summary>
    /// Specifies the interface for the Sphere Studio IDE.
    /// </summary>
    public interface IIDE
    {
        /// <summary>
        /// Gets the .ini settings of the editor.
        /// </summary>
        SphereSettings EditorSettings { get; }

        /// <summary>
        /// Gets the .sgm settings of the currently loaded game, or null.
        /// </summary>
        ProjectSettings CurrentGame { get; }

        /// <summary>
        /// Gets the EditorObject representing the active document.
        /// </summary>
        EditorObject CurrentDocument { get; }
        
        /// <summary>
        /// Add event handlers to do things when a project opens.
        /// </summary>
        event EventHandler LoadProject;

        /// <summary>
        /// Add event handlers to do things when the Test Game command is clicked.
        /// </summary>
        event EventHandler TestGame;

        /// <summary>
        /// Add event handlers to attempt to open files double-clicked in the project tree.
        /// </summary>
        event EditFileEventHandler TryEditFile;

        /// <summary>
        /// Add event handlers to do things when a project closes.
        /// </summary>
        event EventHandler UnloadProject;

        /// <summary>
        /// Adds a control to the main dock panel, at the associated state.
        /// </summary>
        /// <param name="content">The DockContent to add.</param>
        /// <param name="state">The state to put it in.</param>
        void DockControl(DockContent content, DockState state);

        /// <summary>
        /// Removes the control with name 'name' from the main dock panel.
        /// </summary>
        /// <param name="name"></param>
        void RemoveControl(string name);

        /// <summary>
        /// Add a new root level item to the Sphere Studio menu bar.
        /// </summary>
        /// <param name="item">The ToolStripMenuItem to add.</param>
        /// <param name="before">The name of the item you want to appear before, or none</param>
        void AddMenuItem(ToolStripMenuItem item, string before = "");

        /// <summary>
        /// Add a new item to a sub-menu of the Sphere Studio menu bar.
        /// </summary>
        /// <param name="location">Ex: 'View' or 'View.extra1.extra2'</param>
        /// <param name="newItem">The ToolStripMenuItem to add.</param>
        void AddMenuItem(string location, ToolStripItem newItem);

        /// <summary>
        /// Registers a file type to be shown in the "Open File" dialog of the IDE.
        /// </summary>
        /// <param name="typeName">The pluralized name of the type, e.g. "Images".</param>
        /// <param name="filters">
        /// A semicolon-delimited list of filename filters to associate with the type.
        /// e.g. "*.bmp;*.gif;*.jpg;*.png"
        /// </param>
        void RegisterOpenFileType(string typeName, string filters);

        /// <summary>
        /// Reverses a previous call to RegisterOpenFileType.
        /// </summary>
        /// <param name="filters">The list of filters associated with the type. Must be exactly as passed to RegisterOpenFileType.</param>
        void UnregisterOpenFileType(string filters);
        
        /// <summary>
        /// Removes the menu item from it's containing drop down menu.
        /// </summary>
        /// <param name="item">The ToolStripMenuItem to remove.</param>
        void RemoveMenuItem(ToolStripItem item);

        /// <summary>
        /// Removes a root level menu item with the associated name.
        /// </summary>
        /// <param name="name">The name of the item to remove; Ex: 'View'.</param>
        void RemoveMenuItem(string name);

        /// <summary>
        /// Gets a list of the documents in the Sphere Studio's main dock panel.
        /// </summary>
        /// <returns>A collection of DockContent objects.</returns>
        DockContentCollection GetDocuments();
    }
}
