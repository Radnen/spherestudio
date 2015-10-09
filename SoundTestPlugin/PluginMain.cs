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
    public class PluginMain : IPluginMain, IFileOpener, IDockPane
    {
        public string Name { get { return "Sound Test"; } }
        public string Author { get { return "Spherical"; } }
        public string Description { get { return "Listen to sounds from your game while you work!"; } }
        public string Version { get { return "1.2.0"; } }

        public bool ShowInViewMenu { get; private set; }
        public Control Control { get; private set; }
        public DockHint DockHint { get; private set; }
        public Bitmap DockIcon { get; private set; }

        public string FileTypeName { get; private set; }
        public Bitmap FileIcon { get; private set; }
        public string[] FileExtensions { get; private set; }

        private SoundPicker _soundPicker;

        public void Initialize(ISettings conf)
        {
            _soundPicker = new SoundPicker(this);
            _soundPicker.WatchProject(PluginManager.IDE.Project);
            _soundPicker.Refresh();

            FileTypeName = "Audio File";
            FileIcon = Properties.Resources.Icon;
            FileExtensions = new[]
            {
                "mp3", "ogg", "flac",  // compressed audio formats
                "mod", "it", "s3d",    // tracker formats
                "wav"                  // uncompressed/PCM formats
            };

            Control = _soundPicker;
            DockHint = DockHint.Left;
            DockIcon = Properties.Resources.Icon;
            ShowInViewMenu = true;

            PluginManager.Register(this, this, "Sound Test");

            PluginManager.IDE.LoadProject += IDE_LoadProject;
            PluginManager.IDE.UnloadProject += IDE_UnloadProject;
            PluginManager.IDE.TestGame += IDE_TestGame;
            PluginManager.IDE.Docking.Show(this);
        }

        public void ShutDown()
        {
            PluginManager.UnregisterAll(this);
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
            _soundPicker.WatchProject(PluginManager.IDE.Project);
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
