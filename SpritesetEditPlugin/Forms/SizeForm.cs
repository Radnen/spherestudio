using System;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Windows.Forms;

namespace SphereStudio.Plugins.Forms
{
    internal partial class SizeForm : Form
    {
        private int _width;
        private int _height;

        public SizeForm()
        {
            InitializeComponent();
            RescaleComboBox.SelectedIndex = 2;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            _width = int.Parse(WidthTextBox.Text);
            _height = int.Parse(HeightTextBox.Text);
        }

        public int WidthSize
        {
            get { return _width; }
            set { _width = value; WidthTextBox.Text = value.ToString(CultureInfo.InvariantCulture); }
        }

        public int HeightSize
        {
            get { return _height; }
            set { _height = value; HeightTextBox.Text = value.ToString(CultureInfo.InvariantCulture); }
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

        public InterpolationMode Mode
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
