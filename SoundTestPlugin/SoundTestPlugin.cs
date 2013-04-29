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
        public string Description { get { return "Listen to BGM and sounds from your game while you work!"; } }
        public string Version { get { return "1.0"; } }
        public Icon Icon { get; set; }

        public IPluginHost Host { get; set; }

        private DockContent content;
        private SoundPicker soundPicker;
        private ToolStripMenuItem playPauseMenuItem;
        private ToolStripMenuItem stopMenuItem;

        private void host_projectOpen(object sender, EventArgs e)
        {
            this.soundPicker.RePopulate(Host.CurrentGame.RootPath);
        }

        private void host_projectClose(object sender, EventArgs e)
        {
            this.soundPicker.Clear();
        }

        private void soundTestMenu_PlayPause_Click(object sender, EventArgs args)
        {
        }

        private void soundTestMenu_Stop_Click(object sender, EventArgs args)
        {
        }

        public SoundTestPlugin()
        {
            playPauseMenuItem = new ToolStripMenuItem("&Play/Pause");
            stopMenuItem = new ToolStripMenuItem("&Stop");
            playPauseMenuItem.Click += new EventHandler(soundTestMenu_PlayPause_Click);
            stopMenuItem.Click += new EventHandler(soundTestMenu_Stop_Click);
        }

        public void Initialize()
        {
            this.soundPicker = new SoundPicker();
            this.soundPicker.Dock = DockStyle.Fill;
            this.content = new DockContent();
            this.content.Controls.Add(this.soundPicker);
            this.content.Text = "Sound Test";
            this.content.DockAreas = DockAreas.DockBottom | DockAreas.DockLeft | DockAreas.DockRight | DockAreas.DockTop | DockAreas.Document;
            this.content.DockHandler.HideOnClose = true;
            this.content.Icon = this.Icon;
            Host.DockControl(this.content, DockState.DockLeft);
            Host.AddMenuItem("Sound Test", playPauseMenuItem);
            Host.AddMenuItem("Sound Test", stopMenuItem);
            Host.OnOpenProject += host_projectOpen;
            Host.OnCloseProject += host_projectClose;
        }

        public void Destroy()
        {
            Host.RemoveMenuItem("Sound Test");
        }
    }
}
