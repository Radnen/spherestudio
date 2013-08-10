using System;
using System.Windows.Forms;

namespace Sphere.Core.Editor
{
    /// <summary>
    /// Represents a form that allows the user to enter a line of text.
    /// </summary>
    public partial class StringInputForm : Form
    {
        private bool _numOnly;

        /// <summary>
        /// Initializes the string input form.
        /// </summary>
        public StringInputForm()
        {
            InitializeComponent();
            NumOnly = false;
        }

        /// <summary>
        /// Set this to use numbers only or not.
        /// </summary>
        public bool NumOnly
        {
            get { return _numOnly; }
            set { _numOnly = value; }
        }

        /// <summary>
        /// The string inputted into the form.
        /// </summary>
        public string Input
        {
            get { return StringTextBox.Text; }
            set { StringTextBox.Text = value; StringTextBox.Select(); }
        }

        /// <summary>
        /// Use this to limit the number of characters one can input.
        /// </summary>
        public int MaxLength
        {
            get { return StringTextBox.MaxLength; }
            set { StringTextBox.MaxLength = value; }
        }

        private void StringTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (_numOnly && !Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8);
        }
    }
}
