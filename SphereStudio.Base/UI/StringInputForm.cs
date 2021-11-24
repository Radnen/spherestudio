using System;
using System.Windows.Forms;

using SphereStudio.Base;

namespace SphereStudio.UI
{
    /// <summary>
    /// Represents a form that allows the user to enter a line of text.
    /// </summary>
    public partial class StringInputForm : Form, IStyleAware
    {
        private bool acceptNumbersOnly;

        /// <summary>
        /// Initializes the string input form.
        /// </summary>
        public StringInputForm(string caption, string labelText = null)
        {
            InitializeComponent();

            if (caption != null)
                Text = caption;
            if (labelText != null)
                header.Text = labelText;
            NumbersOnly = false;

            StyleManager.AutoStyle(this);
        }

        public void ApplyStyle(UIStyle style)
        {
            style.AsUIElement(this);
            style.AsHeading(header);
            style.AsHeading(footer);
            style.AsAccent(okButton);
            style.AsAccent(cancelButton);

            style.AsHeading(textHeading);
            style.AsAccent(textPanel);
            style.AsTextView(textBox);
        }

        /// <summary>
        /// Set this to use numbers only or not.
        /// </summary>
        public bool NumbersOnly
        {
            get { return acceptNumbersOnly; }
            set { acceptNumbersOnly = value; }
        }

        /// <summary>
        /// The string inputted into the form.
        /// </summary>
        public string Input
        {
            get { return textBox.Text; }
            set { textBox.Text = value; textBox.Select(); }
        }

        /// <summary>
        /// Use this to limit the number of characters one can input.
        /// </summary>
        public int MaxLength
        {
            get { return textBox.MaxLength; }
            set { textBox.MaxLength = value; }
        }

        private void StringTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (acceptNumbersOnly && !Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8);
        }
    }
}
