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

        private DockContent content;
        private SoundPicker soundPicker;

        private void host_LoadProject(object sender, EventArgs e)
        {
            this.soundPicker.WatchProject(this.Host.CurrentGame);
        }

        private void host_UnloadProject(object sender, EventArgs e)
        {
            this.soundPicker.WatchProject(null);
        }

        private void host_TryEditFile(object sender, EditFileEventArgs e)
        {
            if (e.IsAlreadyMatched)
            {
                return;
            }
            string[] validExtensions = new string[] {
                ".mp3",
                ".ogg",
                ".mod",
                ".it",
                ".wav"
            };
            foreach (string extension in validExtensions)
            {
                if (e.FileExtension == extension)
                {
                    e.IsAlreadyMatched = true;
                    this.soundPicker.PlayFile(e.FileFullPath);
                }
            }
        }

        private void host_TestGame(object sender, EventArgs e)
        {
            this.soundPicker.ForcePause();
        }

        public SoundTestPlugin()
        {
            this.Icon = Icon.FromHandle(Properties.Resources.Icon.GetHicon());
        }

        public void Initialize()
        {
            this.soundPicker = new SoundPicker(this);
            this.soundPicker.Dock = DockStyle.Fill;
            this.soundPicker.Refresh();
            this.content = new DockContent();
            this.content.Controls.Add(this.soundPicker);
            this.content.Text = "Sound Test";
            this.content.DockAreas = DockAreas.DockBottom | DockAreas.DockLeft | DockAreas.DockRight | DockAreas.DockTop | DockAreas.Document;
            this.content.DockHandler.HideOnClose = true;
            this.content.Icon = this.Icon;
            Host.DockControl(this.content, DockState.DockLeft);
            Host.LoadProject += new EventHandler(host_LoadProject);
            Host.UnloadProject += new EventHandler(host_UnloadProject);
            Host.TryEditFile += new EditFileEventHandler(host_TryEditFile);
            Host.TestGame += new EventHandler(host_TestGame);
        }

        public void Destroy()
        {
            Host.RemoveMenuItem("Sound Test");
        }
    }
}
