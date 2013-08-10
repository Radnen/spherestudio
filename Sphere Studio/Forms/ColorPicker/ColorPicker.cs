﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace SphereStudio.Forms.ColorPicker
{
    internal partial class ColorPicker : Form
    {
        private Color color = Color.White;

        public ColorPicker()
        {
            InitializeComponent();
        }

        private void ColorRect_ColorSelected(object sender, EventArgs e)
        {
            SelectedColorBox.SelectedColor = ColorRect.SelectedColor;
            SelectedColorBox.Refresh();
        }

        private void ColorRect_MouseUp(object sender, MouseEventArgs e)
        {
            PreviousColorBox.SelectedColor = SelectedColorBox.SelectedColor;
            PreviousColorBox.Refresh();
        }

        private void ColorSlider_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(SphereStudio.Properties.Resources.Gradient, ColorSlider.DisplayRectangle);
        }

        private void ColorSlider_MouseClick(object sender, MouseEventArgs e)
        {
            Color c = SphereStudio.Properties.Resources.Gradient.GetPixel(e.X, e.Y);
            ColorRect.FillColor = c;
        }
    }
}
