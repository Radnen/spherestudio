using System;
using System.Drawing;
using System.Windows.Forms;
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

        private string[] fileTypes = new string[]
        {
            "*.mp3",
            "*.ogg",
            "*.wav"
        };

        private DockContent content;
        private SoundPicker soundPicker;

        private void host_LoadProject(object sender, EventArgs e)
        {
            this.soundPicker.Refresh();
        }

        private void host_UnloadProject(object sender, EventArgs e)
        {
            this.soundPicker.Reset();
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
            Host.TestGame += new EventHandler(host_TestGame);
        }

        public void Destroy()
        {
            Host.RemoveMenuItem("Sound Test");
        }
    }
}
