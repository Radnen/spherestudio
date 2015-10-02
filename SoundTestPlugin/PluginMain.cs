using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Sphere.Core.Editor;
using Sphere.Plugins;
using Sphere.Plugins.Interfaces;
using Sphere.Plugins.Views;

namespace SphereStudio.Plugins
{
    public class PluginMain : IPluginMain, IFileOpener
    {
        public string Name { get { return "Sound Test"; } }
        public string Author { get { return "Spherical"; } }
        public string Description { get { return "Listen to sounds from your game while you work!"; } }
        public string Version { get { return "1.2.0"; } }
        public Icon Icon { get; set; }

        private const string _openFileFilters = "*.mp3;*.ogg;*.flac;*.mod;*.it;*.s3d;*.wav";
        private readonly string[] _extensionList = new[] {
            "mp3", "ogg", "flac",  // compressed audio formats
            "mod", "it", "s3d",    // tracker formats
            "wav"                  // uncompressed/PCM formats
        };

        private SoundPicker _soundPicker;

        public PluginMain()
        {
            Icon = Icon.FromHandle(Properties.Resources.Icon.GetHicon());
        }

        public void Initialize(ISettings conf)
        {
            _soundPicker = new SoundPicker(this);
            _soundPicker.Refresh();

            PluginManager.RegisterPlugin(this, this, "Sound Test");
            PluginManager.RegisterExtensions(this, _extensionList);
            PluginManager.IDE.RegisterOpenFileType("Audio", _openFileFilters);
            PluginManager.IDE.LoadProject += IDE_LoadProject;
            PluginManager.IDE.UnloadProject += IDE_UnloadProject;
            PluginManager.IDE.TestGame += IDE_TestGame;
            _soundPicker.WatchProject(PluginManager.IDE.CurrentGame);
        }

        public void ShutDown()
        {
            PluginManager.UnregisterExtensions(_extensionList);
            PluginManager.UnregisterPlugins(this);
            PluginManager.IDE.UnregisterOpenFileType(_openFileFilters);
            _soundPicker.WatchProject(null);
            _soundPicker.StopMusic();
            PluginManager.IDE.TestGame -= IDE_TestGame;
            PluginManager.IDE.LoadProject -= IDE_LoadProject;
            PluginManager.IDE.UnloadProject -= IDE_UnloadProject;
        }

        public DocumentView New()
        {
            throw new NotSupportedException();
        }

        public DocumentView Open(string fileName)
        {
            _soundPicker.PlayFile(fileName);
            return null;
        }

        private void IDE_LoadProject(object sender, EventArgs e)
        {
            _soundPicker.WatchProject(PluginManager.IDE.CurrentGame);
        }

        private void IDE_UnloadProject(object sender, EventArgs e)
        {
            _soundPicker.WatchProject(null);
        }

        private void IDE_TestGame(object sender, EventArgs e)
        {
            _soundPicker.ForcePause();
        }
    }
}
