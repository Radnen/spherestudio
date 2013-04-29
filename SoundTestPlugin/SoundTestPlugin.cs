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
        public string Version { get { return "1.0b"; } }
        public Icon Icon { get; set; }

        public IPluginHost Host { get; set; }

        private DockContent content;
        private SoundPicker soundPicker;

        private void host_projectOpen(object sender, EventArgs e)
        {
            this.soundPicker.RePopulate(Host.CurrentGame.RootPath);
        }

        private void host_projectClose(object sender, EventArgs e)
        {
            this.soundPicker.Clear();
        }

        public SoundTestPlugin()
        {
        }

        public void Initialize()
        {
            this.soundPicker = new SoundPicker(this);
            this.soundPicker.Dock = DockStyle.Fill;
            this.content = new DockContent();
            this.content.Controls.Add(this.soundPicker);
            this.content.Text = "Sound Test";
            this.content.DockAreas = DockAreas.DockBottom | DockAreas.DockLeft | DockAreas.DockRight | DockAreas.DockTop | DockAreas.Document;
            this.content.DockHandler.HideOnClose = true;
            this.content.Icon = this.Icon;
            Host.DockControl(this.content, DockState.DockLeft);
            Host.OnOpenProject += new EventHandler(host_projectOpen);
            Host.OnCloseProject += new EventHandler(host_projectClose);
            if (Host.CurrentGame != null)
            {
                this.soundPicker.RePopulate(Host.CurrentGame.RootPath);
            }
        }

        public void Destroy()
        {
            Host.RemoveMenuItem("Sound Test");
        }
    }
}
