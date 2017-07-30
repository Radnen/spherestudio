using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Sphere.Core.Editor;

using ScintillaNET;

namespace SphereStudio.ScriptEditor.Components
{
    /// <summary>
    /// Implements the Quick Find box (fast Search and Replace).
    /// </summary>
    [ToolboxItem(false)]
    public partial class QuickFind : UserControl, IStyleable
    {
        // some of the logic here may seem a bit hard to follow.  unfortunately most
        // of the spaghetti is necessary, to keep the UI usable.  notes:
        //
        //     * ideally, checkboxes should not accept focus.  trouble is, even with .TabStop
        //       set to false, using an accelerator key will activate the control.  so the best
        //       we can do is refocus a textbox whenever a checkbox is changed.
        //     * non-Form controls cannot have an AcceptButton.  thus we need to handle
        //       the KeyPress event and activate the correct button when a Return character
        //       is received.
        //     * switching between Find and Replace textboxes should perform a Select All
        //       on the textbox being activated.  however, this should only happen when
        //       switching textboxes -- receiving focus from, e.g., a checkbox should NOT
        //       trigger a Select All.  this allows the user to manipulate search options
        //       in the middle of typing a term without affecting the cursor.
        //     * pressing a Find hotkey (Ctrl+F or Ctrl+H) while the Search box is visible
        //       should NOT change the text in the Find box nor trigger a search, but SHOULD
        //       select the text.  this matches MSVC behavior.

        private Scintilla _codeBox = null;
        private int _fullHeight;
        private TextBox _lastTextBox;
        private Control _parent;

        /// <summary>
        /// Constructs a new Quick Find control.  Initially it's invisible.
        /// </summary>
        /// <param name="parent">The parent control.  Quick Find will show in the top-right corner.</param>
        /// <param name="codeBox">The Scintilla control whose contents will be searched.</param>
        public QuickFind(Control parent, Scintilla codeBox)
        {
            InitializeComponent();
            Visible = false;

            _fullHeight = Height;
            _codeBox = codeBox;
            _parent = parent;
            _parent.Controls.Add(this);
        }

        /// <summary>
        /// Opens the Quick Find box.  The word under the cursor is automatically
        /// filled into the Find field.
        /// </summary>
        /// <param name="replace">A boolean value specifying whether we want Replace functionality.</param>
        public void Open(bool replace = false)
        {
            bool wasVisibleBefore = Visible;

            SuspendLayout();
            TitleLabel.Text = replace ? "Quick Replace" : "Quick Find";

            BringToFront();
            Show();

            // populate the Find term from the current selection
            if (!wasVisibleBefore)
            {
                if (string.IsNullOrEmpty(_codeBox.SelectedText))
                {
                    // if no selection, use word under cursor
                    int wordStart = _codeBox.WordStartPosition(_codeBox.CurrentPosition, false);
                    int wordEnd = _codeBox.WordEndPosition(_codeBox.CurrentPosition, false);
                    if (!wasVisibleBefore)
                    {
                        _codeBox.TargetStart = wordStart;
                        FindTextBox.Text = _codeBox.GetWordFromPosition(_codeBox.CurrentPosition);
                    }
                }
                else if (!_codeBox.SelectedText.Contains('\r') && !_codeBox.SelectedText.Contains('\n'))
                {
                    // if there is a selection, use it as the search term unless it contains newlines
                    _codeBox.TargetStart = _codeBox.SelectionStart;
                    FindTextBox.Text = _codeBox.SelectedText;
                }
                else
                {
                    FindTextBox.Text = "";
                }
                if (!string.IsNullOrEmpty(FindTextBox.Text))
                    PerformFind();
            }

            FindTextBox.Focus();
            FindTextBox.SelectAll();
            ReplaceTextBox.Visible = replace;
            ReplaceButton.Visible = replace;
            ReplaceAllButton.Visible = replace;
            if (replace)
                Height = _fullHeight;
            else
                Height = _fullHeight - ReplaceTextBox.Height;

            ResumeLayout();
        }

        /// <summary>
        /// Closes the Quick Find box.
        /// </summary>
        public void Close()
        {
            Hide();
        }

        /// <summary>
        /// Searches for the next occurrence of the most recently used search term.
        /// The search begins from the current cursor position.
        /// </summary>
        public void FindNext()
        {
            _codeBox.TargetStart = _codeBox.CurrentPosition;
            _codeBox.TargetEnd = _codeBox.TextLength;
            if (!string.IsNullOrEmpty(FindTextBox.Text))
            {
                if (!PerformFind())
                {
                    string message = string.Format("No matches were found for the following {1}:\n\n{0}",
                        FindTextBox.Text, RegexCheckBox.Checked ? "regular expression" : "text");
                    MessageBox.Show(this, message, "Quick Find", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                Open();
        }

        public void ApplyStyle(UIStyle theme)
        {
            theme.AsUIElement(FindButton);
            theme.AsUIElement(ReplaceButton);
            theme.AsUIElement(ReplaceAllButton);
            theme.AsUIElement(FindTextBox);
            theme.AsUIElement(ReplaceTextBox);
            theme.AsUIElement(MatchCaseCheckBox);
            theme.AsUIElement(WholeWordCheckBox);
            theme.AsUIElement(RegexCheckBox);
            theme.AsUIElement(OptionsPanel);

            Left = _parent.ClientSize.Width - Width
                - SystemInformation.VerticalScrollBarWidth
                - SystemInformation.BorderSize.Width;
            Top = SystemInformation.BorderSize.Height;
        }

        private bool PerformFind()
        {
            _codeBox.SearchFlags = SearchFlags.None;
            if (MatchCaseCheckBox.Checked)
                _codeBox.SearchFlags |= SearchFlags.MatchCase;
            if (WholeWordCheckBox.Checked)
                _codeBox.SearchFlags |= SearchFlags.WholeWord;
            if (RegexCheckBox.Checked)
                _codeBox.SearchFlags |= SearchFlags.Regex | SearchFlags.Posix;

            _codeBox.TargetEnd = _codeBox.TextLength;
            int pos = _codeBox.SearchInTarget(FindTextBox.Text);
            if (pos == Scintilla.InvalidPosition)
            {
                _codeBox.TargetStart = 0;
                pos = _codeBox.SearchInTarget(FindTextBox.Text);
            }
            if (pos != Scintilla.InvalidPosition)
            {
                FindTextBox.BackColor = SystemColors.Window;
                ReplaceButton.Enabled = true;
                ReplaceAllButton.Enabled = true;
                int line = _codeBox.LineFromPosition(_codeBox.TargetStart);
                if (line < _codeBox.FirstVisibleLine || line >= _codeBox.FirstVisibleLine + _codeBox.LinesOnScreen)
                    _codeBox.FirstVisibleLine = line - _codeBox.LinesOnScreen / 2;
                _codeBox.SelectionStart = _codeBox.TargetStart;
                _codeBox.SelectionEnd = _codeBox.TargetEnd;
            }
            else
            {
                FindTextBox.BackColor = Color.MistyRose;
                ReplaceButton.Enabled = false;
                ReplaceAllButton.Enabled = false;
            }

            return pos != Scintilla.InvalidPosition;
        }

        private void PerformReplace()
        {
            if (RegexCheckBox.Checked)
                _codeBox.ReplaceTargetRe(ReplaceTextBox.Text);
            else
                _codeBox.ReplaceTarget(ReplaceTextBox.Text);
            _codeBox.TargetStart = _codeBox.TargetEnd;
            PerformFind();
        }

        private void PerformReplaceAll()
        {
            _codeBox.TargetStart = 0;
            _codeBox.TargetEnd = _codeBox.TextLength;
            _codeBox.BeginUndoAction();
            int numChanges = 0;
            while (PerformFind())
            {
                PerformReplace();
                ++numChanges;
            }
            _codeBox.EndUndoAction();
            MessageBox.Show(this,
                string.Format("{0} replacement(s) were made.", numChanges), "Quick Replace",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FindTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_codeBox == null)
                return;

            FindButton.Enabled = !string.IsNullOrEmpty(FindTextBox.Text);
            ReplaceButton.Enabled = FindButton.Enabled;
            ReplaceAllButton.Enabled = FindButton.Enabled;
            if (FindButton.Enabled)
            {
                PerformFind();
            }
            else
            {
                FindTextBox.BackColor = SystemColors.Window;
            }
        }

        private void FindTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if (e.KeyChar == '\r')
                FindButton.PerformClick();
            else
                e.Handled = false;
        }

        private void ReplaceTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if (e.KeyChar == '\r')
                ReplaceButton.PerformClick();
            else
                e.Handled = false;
        }

        private void MatchCaseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PerformFind();
            _lastTextBox.Focus();
        }

        private void RegexCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            WholeWordCheckBox.Enabled = !RegexCheckBox.Checked;
            if (RegexCheckBox.Checked)
                WholeWordCheckBox.Checked = false;
            PerformFind();
            _lastTextBox.Focus();
        }

        private void WholeWordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PerformFind();
            _lastTextBox.Focus();
        }

        private void FindButton_Click(object sender, EventArgs e)
        {
            FindNext();
            _lastTextBox.Focus();
        }

        private void ReplaceButton_Click(object sender, EventArgs e)
        {
            PerformReplace();
            _lastTextBox.Focus();
        }

        private void FindTextBox_Enter(object sender, EventArgs e)
        {
            // don't Select All unless we came from a different textbox
            if (_lastTextBox != FindTextBox)
                FindTextBox.SelectAll();
            _lastTextBox = FindTextBox;
        }

        private void ReplaceTextBox_Enter(object sender, EventArgs e)
        {
            // don't Select All unless we came from a different textbox
            if (_lastTextBox != ReplaceTextBox)
                ReplaceTextBox.SelectAll();
            _lastTextBox = ReplaceTextBox;
        }

        private void ReplaceAllButton_Click(object sender, EventArgs e)
        {
            PerformReplaceAll();
            _lastTextBox.Focus();
        }
    }
}
