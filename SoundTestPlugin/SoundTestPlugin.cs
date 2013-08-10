﻿using System;
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

        private const string OpenFileFilter = "*.mp3;*.ogg;*.flac;*.mod;*.it;*.s3d;*.wav";

        private readonly string[] _fileTypes = new[] {
            ".mp3", ".ogg", ".flac",  // compressed audio
            ".mod", ".it", ".s3d",    // tracker formats
            ".wav"                    // uncompressed/PCM
        };

        private DockContent _content;
        private SoundPicker _soundPicker;

        private void host_LoadProject(object sender, EventArgs e)
        {
            _soundPicker.WatchProject(PluginManager.IDE.CurrentGame);
        }

        private void host_UnloadProject(object sender, EventArgs e)
        {
            _soundPicker.WatchProject(null);
        }

        private void host_TryEditFile(object sender, EditFileEventArgs e)
        {
            if (e.Handled) return;
            foreach (string type in _fileTypes)
            {
                if (e.Extension == type)
                {
                    _soundPicker.PlayFile(e.Path);
                    e.Handled = true;
                }
            }
        }

        private void host_TestGame(object sender, EventArgs e)
        {
            _soundPicker.ForcePause();
        }

        public SoundTestPlugin()
        {
            Icon = Icon.FromHandle(Properties.Resources.Icon.GetHicon());
        }

        public void Initialize()
        {
            _soundPicker = new SoundPicker() {Dock = DockStyle.Fill};
            _soundPicker.Refresh();
            _content = new DockContent();
            _content.Controls.Add(_soundPicker);
            _content.Text = @"Sound Test";
            _content.DockAreas = DockAreas.DockBottom | DockAreas.DockLeft | DockAreas.DockRight | DockAreas.DockTop | DockAreas.Document;
            _content.DockHandler.HideOnClose = true;
            _content.Icon = Icon;
            PluginManager.IDE.DockControl(_content, DockState.DockLeft);
            PluginManager.IDE.RegisterOpenFileType("Audio", OpenFileFilter);
            PluginManager.IDE.LoadProject += host_LoadProject;
            PluginManager.IDE.UnloadProject += host_UnloadProject;
            PluginManager.IDE.TestGame += host_TestGame;
            PluginManager.IDE.TryEditFile += host_TryEditFile;
            _soundPicker.WatchProject(PluginManager.IDE.CurrentGame);
        }

        public void Destroy()
        {
            PluginManager.IDE.UnregisterOpenFileType(OpenFileFilter);
            _soundPicker.WatchProject(null);
            _soundPicker.StopMusic();
            PluginManager.IDE.RemoveControl("Sound Test");
            PluginManager.IDE.TryEditFile -= host_TryEditFile;
            PluginManager.IDE.TestGame -= host_TestGame;
            PluginManager.IDE.LoadProject -= host_LoadProject;
            PluginManager.IDE.UnloadProject -= host_UnloadProject;
        }
    }
}
