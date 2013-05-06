using System;
using System.Drawing;
using System.Windows.Forms;
using Sphere.Core;
using Sphere.Plugins;
using WeifenLuo.WinFormsUI.Docking;

namespace SoundTestPlugin
{
    class SoundTestPlugin : IPlugin
    {
        public string Name { get { return "Sound Test"; } }
        public string Author { get { return "Bruce Pascoe"; } }
        public string Description { get { return "Listen to sounds from your game while you work! :o)"; } }
        public string Version { get { return "1.0"; } }
        public Icon Icon { get; set; }

        public IPluginHost Host { get; set; }

        private string _openFileFilter = "*.mp3;*.ogg;*.flac;*.mod;*.it;*.s3d;*.wav";
        private string[] _fileTypes = new string[] {
            ".mp3", ".ogg", ".flac",  // compressed audio
            ".mod", ".it", ".s3d",    // tracker formats
            ".wav"                    // uncompressed/PCM
        };

        private DockContent _content;
        private SoundPicker _soundPicker;

        private void host_LoadProject(object sender, EventArgs e)
        {
            _soundPicker.WatchProject(Host.CurrentGame);
        }

        private void host_UnloadProject(object sender, EventArgs e)
        {
            _soundPicker.WatchProject(null);
        }

        private void host_TryEditFile(object sender, EditFileEventArgs e)
        {
            if (e.IsAlreadyMatched) return;
            foreach (string type in _fileTypes)
            {
                if (e.FileExtension == type)
                {
                    _soundPicker.PlayFile(e.FileFullPath);
                    e.IsAlreadyMatched = true;
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
            _soundPicker = new SoundPicker(this);
            _soundPicker.Dock = DockStyle.Fill;
            _soundPicker.Refresh();
            _content = new DockContent();
            _content.Controls.Add(_soundPicker);
            _content.Text = "Sound Test";
            _content.DockAreas = DockAreas.DockBottom | DockAreas.DockLeft | DockAreas.DockRight | DockAreas.DockTop | DockAreas.Document;
            _content.DockHandler.HideOnClose = true;
            _content.Icon = Icon;
            Host.DockControl(_content, DockState.DockLeft);
            Host.LoadProject += new EventHandler(host_LoadProject);
            Host.UnloadProject += new EventHandler(host_UnloadProject);
            Host.TestGame += new EventHandler(host_TestGame);
            Host.RegisterOpenFileType("Audio", _openFileFilter);
            Host.TryEditFile += new EditFileEventHandler(host_TryEditFile);
            _soundPicker.WatchProject(Host.CurrentGame);
        }

        public void Destroy()
        {
            Host.UnregisterOpenFileType(_openFileFilter);
            _soundPicker.WatchProject(null);
            Host.RemoveControl("Sound Test");
            Host.TryEditFile -= host_TryEditFile;
            Host.TestGame -= host_TestGame;
            Host.LoadProject -= host_LoadProject;
            Host.UnloadProject -= host_UnloadProject;
        }
    }
}
