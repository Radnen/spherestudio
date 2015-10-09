using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Sphere.Plugins.Views;

namespace Sphere.Plugins.Interfaces
{
    /// <summary>
    /// Specifies the interface for the Sphere Studio IDE.
    /// </summary>
    public interface IIDE : ISynchronizeInvoke
    {
        /// <summary>
        /// Provides access to the Sphere Studio global configuration.
        /// </summary>
        ISettings Settings { get; }
        
        /// <summary>
        /// Provides access to the project settings.
        /// </summary>
        IProject Project { get; }

        /// <summary>
        /// Gets the EditorObject representing the active document.
        /// </summary>
        DocumentView CurrentDocument { get; }

        /// <summary>
        /// Gets the interface to the IDE dock manager.
        /// </summary>
        IDock Docking { get; }

        /// <summary>
        /// Fires when a project is loaded into the IDE.
        /// </summary>
        event EventHandler LoadProject;

        /// <summary>
        /// Fires when an open project is closed.
        /// </summary>
        event EventHandler UnloadProject;

        /// <summary>
        /// Fires when the Test Game or Debug commands are chosen.
        /// </summary>
        event EventHandler TestGame;

        /// <summary>
        /// Creates a ScriptView for an embedded script editor.
        /// </summary>
        /// <returns></returns>
        ScriptView CreateScriptView();

        /// <summary>
        /// Creates an ImageView for an embedded image editor.
        /// </summary>
        /// <returns></returns>
        ImageView CreateImageView();
        
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
        /// Opens a file as a document in the IDE.
        /// </summary>
        /// <param name="fileName">The full path of the file to open.</param>
        /// <returns>The DocumentView for the opened file.</returns>
        DocumentView OpenFile(string fileName);

        /// <summary>
        /// Used to send an invalidate to all editors if styling has changed,
        /// usually due to changing a style option through a plugin.
        /// </summary>
        void RestyleEditors();
    }

    /// <summary>
    /// Specifies the interface for the dock panel manager.
    /// </summary>
    public interface IDock
    {
        /// <summary>
        /// Updates the IDE dock container with new and removed panes.
        /// </summary>
        void Refresh();

        /// <summary>
        /// Hides a registered dock pane. If it is already hidden, does nothing.
        /// </summary>
        /// <param name="pane"></param>
        void Hide(IDockPane pane);

        /// <summary>
        /// Shows a registered dock pane. If it is already visible, does nothing.
        /// </summary>
        /// <param name="pane"></param>
        void Show(IDockPane pane);
    }
}
