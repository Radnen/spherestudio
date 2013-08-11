using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Sphere.Plugins;
using WeifenLuo.WinFormsUI.Docking;

namespace SoundTestPlugin
{
    public class SoundTestPlugin : IPlugin
    {
        public string Name { get { return "Sound Test"; } }
        public string Author { get { return "Lord English"; } }
        public string Description { get { return "Listen to sounds from your game while you work! :o)"; } }
        public string Version { get { return "1.1.6.0"; } }
        public Icon Icon { get; set; }

        private const string _openFileFilters = "*.mp3;*.ogg;*.flac;*.mod;*.it;*.s3d;*.wav";
        private readonly List<string> _extensionList = new List<string>(new[] {
            ".mp3", ".ogg", ".flac",  // compressed audio formats
            ".mod", ".it", ".s3d",    // tracker formats
            ".wav"                    // uncompressed/PCM formats
        });
        
        private SoundPicker _soundPicker;

        public SoundTestPlugin()
        {
            Icon = Icon.FromHandle(Properties.Resources.Icon.GetHicon());
        }

        public void Initialize()
        {
            _soundPicker = new SoundPicker() { Dock = DockStyle.Fill };
            _soundPicker.Refresh();
            DockContent content = new DockContent() { Text = @"Sound Test", Icon = Icon };
            content.Controls.Add(_soundPicker);
            content.DockAreas = DockAreas.DockBottom | DockAreas.DockLeft | DockAreas.DockRight | DockAreas.DockTop | DockAreas.Document;
            content.DockHandler.HideOnClose = true;
            PluginManager.IDE.DockControl(content, DockState.DockLeft);
            PluginManager.IDE.RegisterOpenFileType("Audio", _openFileFilters);
            PluginManager.IDE.LoadProject += IDE_LoadProject;
            PluginManager.IDE.UnloadProject += IDE_UnloadProject;
            PluginManager.IDE.TestGame += IDE_TestGame;
            PluginManager.IDE.TryEditFile += IDE_TryEditFile;
            _soundPicker.WatchProject(PluginManager.IDE.CurrentGame);
        }

        public void Destroy()
        {
            PluginManager.IDE.UnregisterOpenFileType(_openFileFilters);
            _soundPicker.WatchProject(null);
            _soundPicker.StopMusic();
            PluginManager.IDE.RemoveControl("Sound Test");
            PluginManager.IDE.TryEditFile -= IDE_TryEditFile;
            PluginManager.IDE.TestGame -= IDE_TestGame;
            PluginManager.IDE.LoadProject -= IDE_LoadProject;
            PluginManager.IDE.UnloadProject -= IDE_UnloadProject;
        }

        private void IDE_LoadProject(object sender, EventArgs e)
        {
            _soundPicker.WatchProject(PluginManager.IDE.CurrentGame);
        }

        private void IDE_UnloadProject(object sender, EventArgs e)
        {
            _soundPicker.WatchProject(null);
        }

        private void IDE_TryEditFile(object sender, EditFileEventArgs e)
        {
            if (e.Handled) return;
            if (_extensionList.Contains(e.Extension.ToLowerInvariant()))
            {
                _soundPicker.PlayFile(e.Path);
                e.Handled = true;
            }
        }

        private void IDE_TestGame(object sender, EventArgs e)
        {
            _soundPicker.ForcePause();
        }
    }
}
