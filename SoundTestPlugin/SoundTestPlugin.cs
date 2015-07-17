using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Sphere.Plugins;

using Sphere.Core.Editor;

namespace SphereStudio.Plugins
{
    public class SoundTestPlugin : IEditorPlugin
    {
        public string Name { get { return "Sound Test"; } }
        public string Author { get { return "Lord English"; } }
        public string Description { get { return "Listen to sounds from your game while you work! :o)"; } }
        public string Version { get { return "1.2.0"; } }
        public Icon Icon { get; set; }

        private const string _openFileFilters = "*.mp3;*.ogg;*.flac;*.mod;*.it;*.s3d;*.wav";
        private readonly string[] _extensionList = new[] {
            "mp3", "ogg", "flac",  // compressed audio formats
            "mod", "it", "s3d",    // tracker formats
            "wav"                  // uncompressed/PCM formats
        };
        
        private SoundPicker _soundPicker;

        public SoundTestPlugin()
        {
            Icon = Icon.FromHandle(Properties.Resources.Icon.GetHicon());
        }

        public void Initialize(ISettings conf)
        {
            _soundPicker = new SoundPicker() { Dock = DockStyle.Fill };
            _soundPicker.Refresh();

            DockDescription description = new DockDescription();
            description.TabText = @"Sound Test";
            description.Icon = Icon;
            description.Control = _soundPicker;
            description.DockAreas = DockDescAreas.Document | DockDescAreas.Sides;
            description.HideOnClose = true;
            description.DockState = DockDescStyle.Side;

            PluginManager.RegisterExtensions(this, _extensionList);
            PluginManager.IDE.DockControl(description);
            PluginManager.IDE.RegisterOpenFileType("Audio", _openFileFilters);
            PluginManager.IDE.LoadProject += IDE_LoadProject;
            PluginManager.IDE.UnloadProject += IDE_UnloadProject;
            PluginManager.IDE.TestGame += IDE_TestGame;
            _soundPicker.WatchProject(PluginManager.IDE.CurrentGame);
        }

        public void Destroy()
        {
            PluginManager.UnregisterExtensions(_extensionList);
            PluginManager.IDE.UnregisterOpenFileType(_openFileFilters);
            _soundPicker.WatchProject(null);
            _soundPicker.StopMusic();
            PluginManager.IDE.RemoveControl("Sound Test");
            PluginManager.IDE.TestGame -= IDE_TestGame;
            PluginManager.IDE.LoadProject -= IDE_LoadProject;
            PluginManager.IDE.UnloadProject -= IDE_UnloadProject;
        }

        public DocumentView CreateEditView() { return null; }
        public DocumentView NewDocument() { return null; }
        
        public DocumentView OpenDocument(string filepath)
        {
            _soundPicker.PlayFile(filepath);
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
