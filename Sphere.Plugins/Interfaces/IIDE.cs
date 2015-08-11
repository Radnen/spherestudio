using System;
using System.ComponentModel;
using System.Windows.Forms;

using Sphere.Plugins.Views;

namespace Sphere.Plugins.Interfaces
{
    /// <summary>
    /// Provides the interface to the Sphere Studio core.
    /// </summary>
    public interface IIDE : ISynchronizeInvoke
    {
        ISettings OpenSettings(string settingsID);
        
        /// <summary>
        /// Provides access to the Sphere Studio global configuration.
        /// </summary>
        ISettings Settings { get; }
        
        /// <summary>
        /// Provides access to the project settings.
        /// </summary>
        IProject CurrentGame { get; }

        /// <summary>
        /// Gets the EditorObject representing the active document.
        /// </summary>
        DocumentView CurrentDocument { get; }

        IDebugger Debugger { get; }
        
        /// <summary>
        /// Gets the path of the current Sphere engine used for game testing.
        /// </summary>
        string EnginePath { get; }
        
        /// <summary>
        /// Add event handlers to do things when a project opens.
        /// </summary>
        event EventHandler LoadProject;

        /// <summary>
        /// Add event handlers to do things when the Test Game command is clicked.
        /// </summary>
        event EventHandler TestGame;

        /// <summary>
        /// Add event handlers to do things when a project closes.
        /// </summary>
        event EventHandler UnloadProject;

        /// <summary>
        /// Adds a control to the main dock panel, at the associated state.
        /// </summary>
        /// <param name="description">Data used to tell the editor how to dock this plugin's editor.</param>
        void DockControl(DockDescription description);

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
        /// Registers an editor plugin as a File:New handler. This adds an
        /// entry to the File:New menu in the IDE.
        /// </summary>
        /// <param name="plugin">The editor plugin to register.</param>
        /// <param name="name">The friendly name of the document being created, e.g. "Script" or "Image".</param>
        void RegisterNewHandler(IEditorPlugin plugin, string name);
        
        /// <summary>
        /// Unregisters a previously registered File:New handler.
        /// </summary>
        /// <param name="plugin">The editor plugin to unregister.</param>
        void UnregisterNewHandler(IEditorPlugin plugin);
        
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
        /// Gets a list of the loaded document's filepaths in the Sphere Studio's main dock panel.
        /// </summary>
        string[] Documents { get; }

        /// <summary>
        /// Used to send an invalidate to all editors if styling has changed,
        /// usually due to changing a style option through a plugin.
        /// </summary>
        void RestyleEditors();
    }
}
