using System;
using System.Windows.Forms;

namespace SphereStudio.UI
{
    /// <summary>
    /// Represents a form that allows the user to enter a line of text.
    /// </summary>
    public partial class StringInputForm : Form, IStyleable
    {
        private bool _numOnly;

        /// <summary>
        /// Initializes the string input form.
        /// </summary>
        public StringInputForm(string caption, string labelText = null)
        {
            InitializeComponent();

            if (caption != null)
                Text = caption;
            if (labelText != null)
                m_heading.Text = labelText;
            NumOnly = false;

            Styler.AutoStyle(this);
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
            get { return m_textBox.Text; }
            set { m_textBox.Text = value; m_textBox.Select(); }
        }

        /// <summary>
        /// Use this to limit the number of characters one can input.
        /// </summary>
        public int MaxLength
        {
            get { return m_textBox.MaxLength; }
            set { m_textBox.MaxLength = value; }
        }

        public void ApplyStyle(UIStyle style)
        {
            style.AsUIElement(this);
            style.AsTextView(m_textBox);
            style.AsAccent(m_okButton);
            style.AsAccent(m_cancelButton);
        }

        private void StringTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (_numOnly && !Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8);
        }
    }
}
