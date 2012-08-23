using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Sphere_Editor.Forms
{
    public partial class SizeForm : Form
    {
        private int width;
        private int height;

        public SizeForm()
        {
            InitializeComponent();
            RescaleComboBox.SelectedIndex = 2;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            this.width = int.Parse(WidthTextBox.Text);
            this.height = int.Parse(HeightTextBox.Text);
        }

        public int WidthSize
        {
            get { return width; }
            set { width = value; WidthTextBox.Text = value.ToString(); }
        }

        public int HeightSize
        {
            get { return height; }
            set { height = value; HeightTextBox.Text = value.ToString(); }
        }

        public bool UseScale
        {
            get { return RescaleComboBox.Enabled; }
            set { RescaleComboBox.Enabled = value; }
        }
        
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8);
        }

        public InterpolationMode mode
        {
            get
            {
                switch (RescaleComboBox.SelectedIndex)
                {
                    case 0: return InterpolationMode.Bicubic;
                    case 1: return InterpolationMode.Bilinear;
                    default: return InterpolationMode.NearestNeighbor;
                }
            }
        }
    }
}
