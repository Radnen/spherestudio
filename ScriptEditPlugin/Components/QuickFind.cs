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

        private Scintilla m_codeBox = null;
        private int m_fullHeight;
        private TextBox m_lastTextBox;
        private Control m_parent;

        /// <summary>
        /// Constructs a new Quick Find control.  Initially it's invisible.
        /// </summary>
        /// <param name="parent">The parent control.  Quick Find will show in the top-right corner.</param>
        /// <param name="codeBox">The Scintilla control whose contents will be searched.</param>
        public QuickFind(Control parent, Scintilla codeBox)
        {
            InitializeComponent();
            Visible = false;

            m_fullHeight = Height;
            m_codeBox = codeBox;
            m_parent = parent;
            m_parent.Controls.Add(this);

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
            TitleLabel.Text = replace ? "Quick Replace" : "Quick Find";

            BringToFront();
            Show();

            // populate the Find term from the current selection
            if (!wasVisibleBefore)
            {
                if (string.IsNullOrEmpty(m_codeBox.SelectedText))
                {
                    // if no selection, use word under cursor
                    int wordStart = m_codeBox.WordStartPosition(m_codeBox.CurrentPosition, false);
                    int wordEnd = m_codeBox.WordEndPosition(m_codeBox.CurrentPosition, false);
                    if (!wasVisibleBefore)
                    {
                        m_codeBox.TargetStart = wordStart;
                        FindTextBox.Text = m_codeBox.GetWordFromPosition(m_codeBox.CurrentPosition);
                    }
                }
                else if (!m_codeBox.SelectedText.Contains('\r') && !m_codeBox.SelectedText.Contains('\n'))
                {
                    // if there is a selection, use it as the search term unless it contains newlines
                    m_codeBox.TargetStart = m_codeBox.SelectionStart;
                    FindTextBox.Text = m_codeBox.SelectedText;
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
                Height = m_fullHeight;
            else
                Height = m_fullHeight - ReplaceTextBox.Height;

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
            m_codeBox.TargetStart = m_codeBox.CurrentPosition;
            m_codeBox.TargetEnd = m_codeBox.TextLength;
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

        public void ApplyStyle(UIStyle style)
        {
            style.AsUIElement(this);
            style.AsTextView(FindTextBox);
            style.AsTextView(ReplaceTextBox);
            style.AsAccent(FindButton);
            style.AsAccent(ReplaceButton);
            style.AsAccent(ReplaceAllButton);
            style.AsUIElement(MatchCaseCheckBox);
            style.AsUIElement(WholeWordCheckBox);
            style.AsUIElement(RegexCheckBox);
            style.AsUIElement(OptionsPanel);

            Left = m_parent.ClientSize.Width - Width
                - SystemInformation.VerticalScrollBarWidth
                - SystemInformation.BorderSize.Width;
            Top = SystemInformation.BorderSize.Height;
        }

        private bool PerformFind()
        {
            m_codeBox.SearchFlags = SearchFlags.None;
            if (MatchCaseCheckBox.Checked)
                m_codeBox.SearchFlags |= SearchFlags.MatchCase;
            if (WholeWordCheckBox.Checked)
                m_codeBox.SearchFlags |= SearchFlags.WholeWord;
            if (RegexCheckBox.Checked)
                m_codeBox.SearchFlags |= SearchFlags.Regex | SearchFlags.Posix;

            m_codeBox.TargetEnd = m_codeBox.TextLength;
            int pos = m_codeBox.SearchInTarget(FindTextBox.Text);
            if (pos == Scintilla.InvalidPosition)
            {
                m_codeBox.TargetStart = 0;
                pos = m_codeBox.SearchInTarget(FindTextBox.Text);
            }
            if (pos != Scintilla.InvalidPosition)
            {
                FindTextBox.ForeColor = StyleManager.Style.TextColor;
                FindTextBox.BackColor = StyleManager.Style.BackColor;
                ReplaceButton.Enabled = true;
                ReplaceAllButton.Enabled = true;
                int line = m_codeBox.LineFromPosition(m_codeBox.TargetStart);
                if (line < m_codeBox.FirstVisibleLine || line >= m_codeBox.FirstVisibleLine + m_codeBox.LinesOnScreen)
                    m_codeBox.FirstVisibleLine = line - m_codeBox.LinesOnScreen / 2;
                m_codeBox.SelectionStart = m_codeBox.TargetStart;
                m_codeBox.SelectionEnd = m_codeBox.TargetEnd;
            }
            else
            {
                FindTextBox.ForeColor = Color.Black;
                FindTextBox.BackColor = Color.MistyRose;
                ReplaceButton.Enabled = false;
                ReplaceAllButton.Enabled = false;
            }

            return pos != Scintilla.InvalidPosition;
        }

        private void PerformReplace()
        {
            if (RegexCheckBox.Checked)
                m_codeBox.ReplaceTargetRe(ReplaceTextBox.Text);
            else
                m_codeBox.ReplaceTarget(ReplaceTextBox.Text);
            m_codeBox.TargetStart = m_codeBox.TargetEnd;
            PerformFind();
        }

        private void PerformReplaceAll()
        {
            m_codeBox.TargetStart = 0;
            m_codeBox.TargetEnd = m_codeBox.TextLength;
            m_codeBox.BeginUndoAction();
            int numChanges = 0;
            while (PerformFind())
            {
                PerformReplace();
                ++numChanges;
            }
            m_codeBox.EndUndoAction();
            MessageBox.Show(this,
                string.Format("{0} replacement(s) were made.", numChanges), "Quick Replace",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FindTextBox_TextChanged(object sender, EventArgs e)
        {
            if (m_codeBox == null)
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
            m_lastTextBox.Focus();
        }

        private void RegexCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            WholeWordCheckBox.Enabled = !RegexCheckBox.Checked;
            if (RegexCheckBox.Checked)
                WholeWordCheckBox.Checked = false;
            PerformFind();
            m_lastTextBox.Focus();
        }

        private void WholeWordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PerformFind();
            m_lastTextBox.Focus();
        }

        private void FindButton_Click(object sender, EventArgs e)
        {
            FindNext();
            m_lastTextBox.Focus();
        }

        private void ReplaceButton_Click(object sender, EventArgs e)
        {
            PerformReplace();
            m_lastTextBox.Focus();
        }

        private void FindTextBox_Enter(object sender, EventArgs e)
        {
            // don't Select All unless we came from a different textbox
            if (m_lastTextBox != FindTextBox)
                FindTextBox.SelectAll();
            m_lastTextBox = FindTextBox;
        }

        private void ReplaceTextBox_Enter(object sender, EventArgs e)
        {
            // don't Select All unless we came from a different textbox
            if (m_lastTextBox != ReplaceTextBox)
                ReplaceTextBox.SelectAll();
            m_lastTextBox = ReplaceTextBox;
        }

        private void ReplaceAllButton_Click(object sender, EventArgs e)
        {
            PerformReplaceAll();
            m_lastTextBox.Focus();
        }
    }
}
