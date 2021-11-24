using System;

using SphereStudio.Base;
using SphereStudio.Plugins.UI;

namespace SphereStudio.Plugins
{
    public class PluginMain : IPluginMain
    {
        public string Name { get; } = "Audio Player";
        public string Description { get; } = "Listen to sounds from your game while you work!";
        public string Version { get; } = Versioning.Version;
        public string Author { get; } = Versioning.Author;

        private AudioPlayerPane dockPane;

        public void Initialize(ISettings conf)
        {
            dockPane = new AudioPlayerPane(this);
            dockPane.WatchProject(PluginManager.Core.Project);
            dockPane.Refresh();

            PluginManager.Register(this, dockPane, "Audio Player");

            PluginManager.Core.LoadProject += IDE_LoadProject;
            PluginManager.Core.UnloadProject += IDE_UnloadProject;
            PluginManager.Core.TestGame += IDE_TestGame;
        }

        public void ShutDown()
        {
            PluginManager.UnregisterAll(this);
            dockPane.WatchProject(null);
            dockPane.stopPlayback();
            PluginManager.Core.TestGame -= IDE_TestGame;
            PluginManager.Core.LoadProject -= IDE_LoadProject;
            PluginManager.Core.UnloadProject -= IDE_UnloadProject;
        }

        private void IDE_LoadProject(object sender, EventArgs e) =>
            dockPane.WatchProject(PluginManager.Core.Project);

        private void IDE_UnloadProject(object sender, EventArgs e) =>
            dockPane.WatchProject(null);

        private void IDE_TestGame(object sender, EventArgs e) =>
            dockPane.ForcePause();
    }
}
