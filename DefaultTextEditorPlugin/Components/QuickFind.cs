using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ScintillaNET;

using SphereStudio.Base;

namespace SphereStudio.Plugins.Components
{
    /// <summary>
    /// Implements the Quick Find box (fast Search and Replace).
    /// </summary>
    [ToolboxItem(false)]
    public partial class QuickFind : UserControl, IStyleAware
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

        private Scintilla codeBox = null;
        private int fullHeight;
        private TextBox lastTextBox;
        private Control parentControl;

        /// <summary>
        /// Constructs a new Quick Find control.  Initially it's invisible.
        /// </summary>
        /// <param name="parent">The parent control.  Quick Find will show in the top-right corner.</param>
        /// <param name="codeBox">The Scintilla control whose contents will be searched.</param>
        public QuickFind(Control parent, Scintilla codeBox)
        {
            InitializeComponent();
            Visible = false;

            fullHeight = Height;
            this.codeBox = codeBox;
            parentControl = parent;
            parentControl.Controls.Add(this);

            StyleManager.AutoStyle(this);
        }

        /// <summary>
        /// Opens the Quick Find box.  The word under the cursor is automatically
        /// filled into the Find field.
        /// </summary>
        /// <param name="replace">A boolean value specifying whether we want Replace functionality.</param>
        public void Open(bool replace = false)
        {
            bool wasVisibleBefore = Visible;

            ApplyStyle(StyleManager.Style);

            SuspendLayout();
            optionsHeading.Text = replace ? "Quick Replace" : "Quick Find";

            BringToFront();
            Show();

            // populate the Find term from the current selection
            if (!wasVisibleBefore)
            {
                if (string.IsNullOrEmpty(codeBox.SelectedText))
                {
                    // if no selection, use word under cursor
                    int wordStart = codeBox.WordStartPosition(codeBox.CurrentPosition, false);
                    int wordEnd = codeBox.WordEndPosition(codeBox.CurrentPosition, false);
                    if (!wasVisibleBefore)
                    {
                        codeBox.TargetStart = wordStart;
                        findTextBox.Text = codeBox.GetWordFromPosition(codeBox.CurrentPosition);
                    }
                }
                else if (!codeBox.SelectedText.Contains('\r') && !codeBox.SelectedText.Contains('\n'))
                {
                    // if there is a selection, use it as the search term unless it contains newlines
                    codeBox.TargetStart = codeBox.SelectionStart;
                    findTextBox.Text = codeBox.SelectedText;
                }
                else
                {
                    findTextBox.Text = "";
                }
                if (!string.IsNullOrEmpty(findTextBox.Text))
                    PerformFind();
            }

            findTextBox.Focus();
            findTextBox.SelectAll();
            replaceTextBox.Visible = replace;
            replaceButton.Visible = replace;
            replaceAllButton.Visible = replace;
            if (replace)
                Height = fullHeight;
            else
                Height = fullHeight - replaceTextBox.Height;

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
            codeBox.TargetStart = codeBox.CurrentPosition;
            codeBox.TargetEnd = codeBox.TextLength;
            if (!string.IsNullOrEmpty(findTextBox.Text))
            {
                if (!PerformFind())
                {
                    string message = string.Format("No matches were found for the following {1}:\n\n{0}",
                        findTextBox.Text, regexButton.Checked ? "regular expression" : "text");
                    MessageBox.Show(this, message, "Quick Find", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                Open();
        }

        public void ApplyStyle(UIStyle style)
        {
            style.AsUIElement(this);
            style.AsTextView(findTextBox);
            style.AsTextView(replaceTextBox);
            style.AsAccent(findButton);
            style.AsAccent(replaceButton);
            style.AsAccent(replaceAllButton);
            style.AsAccent(matchCaseButton);
            style.AsAccent(wholeWordButton);
            style.AsAccent(regexButton);
            style.AsAccent(optionsPanel);

            Left = parentControl.ClientSize.Width - Width
                - SystemInformation.VerticalScrollBarWidth
                - SystemInformation.BorderSize.Width;
            Top = SystemInformation.BorderSize.Height;
        }

        private bool PerformFind()
        {
            codeBox.SearchFlags = SearchFlags.None;
            if (matchCaseButton.Checked)
                codeBox.SearchFlags |= SearchFlags.MatchCase;
            if (wholeWordButton.Checked)
                codeBox.SearchFlags |= SearchFlags.WholeWord;
            if (regexButton.Checked)
                codeBox.SearchFlags |= SearchFlags.Regex | SearchFlags.Posix;

            codeBox.TargetEnd = codeBox.TextLength;
            int pos = codeBox.SearchInTarget(findTextBox.Text);
            if (pos == Scintilla.InvalidPosition)
            {
                codeBox.TargetStart = 0;
                pos = codeBox.SearchInTarget(findTextBox.Text);
            }
            if (pos != Scintilla.InvalidPosition)
            {
                findTextBox.ForeColor = StyleManager.Style.TextColor;
                findTextBox.BackColor = StyleManager.Style.BackColor;
                replaceButton.Enabled = true;
                replaceAllButton.Enabled = true;
                int line = codeBox.LineFromPosition(codeBox.TargetStart);
                if (line < codeBox.FirstVisibleLine || line >= codeBox.FirstVisibleLine + codeBox.LinesOnScreen)
                    codeBox.FirstVisibleLine = line - codeBox.LinesOnScreen / 2;
                codeBox.SelectionStart = codeBox.TargetStart;
                codeBox.SelectionEnd = codeBox.TargetEnd;
            }
            else
            {
                findTextBox.ForeColor = Color.Black;
                findTextBox.BackColor = Color.MistyRose;
                replaceButton.Enabled = false;
                replaceAllButton.Enabled = false;
            }

            return pos != Scintilla.InvalidPosition;
        }

        private void PerformReplace()
        {
            if (regexButton.Checked)
                codeBox.ReplaceTargetRe(replaceTextBox.Text);
            else
                codeBox.ReplaceTarget(replaceTextBox.Text);
            codeBox.TargetStart = codeBox.TargetEnd;
            PerformFind();
        }

        private void PerformReplaceAll()
        {
            codeBox.TargetStart = 0;
            codeBox.TargetEnd = codeBox.TextLength;
            codeBox.BeginUndoAction();
            int numChanges = 0;
            while (PerformFind())
            {
                PerformReplace();
                ++numChanges;
            }
            codeBox.EndUndoAction();
            MessageBox.Show(this,
                string.Format("{0} replacement(s) were made.", numChanges), "Quick Replace",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FindTextBox_TextChanged(object sender, EventArgs e)
        {
            if (codeBox == null)
                return;

            findButton.Enabled = !string.IsNullOrEmpty(findTextBox.Text);
            replaceButton.Enabled = findButton.Enabled;
            replaceAllButton.Enabled = findButton.Enabled;
            if (findButton.Enabled)
            {
                PerformFind();
            }
            else
            {
                findTextBox.BackColor = SystemColors.Window;
            }
        }

        private void FindTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if (e.KeyChar == '\r')
                findButton.PerformClick();
            else
                e.Handled = false;
        }

        private void ReplaceTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if (e.KeyChar == '\r')
                replaceButton.PerformClick();
            else
                e.Handled = false;
        }

        private void MatchCaseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PerformFind();
            lastTextBox.Focus();
        }

        private void RegexCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            wholeWordButton.Enabled = !regexButton.Checked;
            if (regexButton.Checked)
                wholeWordButton.Checked = false;
            PerformFind();
            lastTextBox.Focus();
        }

        private void WholeWordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PerformFind();
            lastTextBox.Focus();
        }

        private void FindButton_Click(object sender, EventArgs e)
        {
            FindNext();
            lastTextBox.Focus();
        }

        private void ReplaceButton_Click(object sender, EventArgs e)
        {
            PerformReplace();
            lastTextBox.Focus();
        }

        private void FindTextBox_Enter(object sender, EventArgs e)
        {
            // don't Select All unless we came from a different textbox
            if (lastTextBox != findTextBox)
                findTextBox.SelectAll();
            lastTextBox = findTextBox;
        }

        private void ReplaceTextBox_Enter(object sender, EventArgs e)
        {
            // don't Select All unless we came from a different textbox
            if (lastTextBox != replaceTextBox)
                replaceTextBox.SelectAll();
            lastTextBox = replaceTextBox;
        }

        private void ReplaceAllButton_Click(object sender, EventArgs e)
        {
            PerformReplaceAll();
            lastTextBox.Focus();
        }
    }
}
