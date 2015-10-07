using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Sphere.Core;

namespace SphereStudio.Plugins.Forms
{
    partial class LayerForm : Form
    {
        private Layer layer;
        
        public LayerForm(Layer layer)
        {
            InitializeComponent();
            this.layer = layer;
            plxXSlide.SetRange(-160, 160);
            plxYSlide.SetRange(-160, 160);
            scrollXSlide.SetRange(-160, 160);
            scrollYSlide.SetRange(-160, 160);
            parallaxCheck.Checked = layer.Parallax;
        }

        private void updateLabels()
        {
            plxXLabel.Text = String.Format("X: {0}", (plxXSlide.Value / 10.0).ToString("F1"));
            plxYLabel.Text = String.Format("Y: {0}", (plxYSlide.Value / 10.0).ToString("F1"));
            scrollXLabel.Text = String.Format("X: {0}", (scrollXSlide.Value / 10.0).ToString("F1"));
            scrollYLabel.Text = String.Format("Y: {0}", (scrollYSlide.Value / 10.0).ToString("F1"));
        }

        private void LayerForm_Load(object sender, EventArgs e)
        {
            nameBox.Text = layer.Name;
            xSizeBox.Value = layer.Width; ySizeBox.Value = layer.Height;
            try
            {
                plxXSlide.Value = (int)Math.Round(layer.ParallaxX * 10.0f);
                plxYSlide.Value = (int)Math.Round(layer.ParallaxY * 10.0f);
            }
            catch (Exception)
            {
                plxXSlide.Value = 0;
                plxYSlide.Value = 0;
            }
            scrollXSlide.Value = (int)Math.Round(layer.ScrollX * 10.0f);
            scrollYSlide.Value = (int)Math.Round(layer.ScrollY * 10.0f);
            visibleCheck.Checked = layer.Visible;
            reflectCheck.Checked = layer.Reflective;
            parallaxCheck.Checked = parallaxGroup.Enabled = layer.Parallax;
            updateLabels();
        }

        private void plxXSlide_Scroll(object sender, EventArgs e)
        {
            updateLabels();
        }

        private void plxYSlide_Scroll(object sender, EventArgs e)
        {
            updateLabels();
        }

        private void scrollXSlide_Scroll(object sender, EventArgs e)
        {
            updateLabels();
        }

        private void scrollYSlide_Scroll(object sender, EventArgs e)
        {
            updateLabels();
        }

        private void parallaxCheck_CheckedChanged(object sender, EventArgs e)
        {
            parallaxGroup.Enabled = parallaxCheck.Checked;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            layer.Name = nameBox.Text;
            layer.Resize((short)xSizeBox.Value, (short)ySizeBox.Value);
            layer.Visible = visibleCheck.Checked;
            layer.Reflective = reflectCheck.Checked;
            layer.Parallax = parallaxCheck.Checked;
            layer.ParallaxX = plxXSlide.Value / 10.0f;
            layer.ParallaxY = plxYSlide.Value / 10.0f;
            layer.ScrollX = scrollXSlide.Value / 10.0f;
            layer.ScrollY = scrollYSlide.Value / 10.0f;
        }
    }
}
