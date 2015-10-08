using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI.Docking;

using Sphere.Plugins;
using Sphere.Plugins.Views;

namespace SphereStudio.IDE
{
    /// <summary>
    /// Represents an open document in the IDE.
    /// </summary>
    class DocumentTab
    {
        private static uint _unsavedID = 1;
        
        private DockContent _content;
        private IDEForm _ide;
        private string _tabText;
        
        /// <summary>
        /// Creates a new Sphere Studio document tab.
        /// </summary>
        /// <param name="ide">The IDE form that the tab will be created in.</param>
        /// <param name="view">The IDocumentView the tab is hosting.</param>
        /// <param name="filename">The fully-qualified filename of the document, or null if untitled.</param>
        /// <param name="restoreView">'true' to restore the last saved view state. Has no effect on untitled tabs.</param>
        public DocumentTab(IDEForm ide, DocumentView view, string filename = null, bool restoreView = false)
        {
            FileName = filename;
            View = view;

            View.Dock = DockStyle.Fill;
            
            _tabText = filename != null ? Path.GetFileName(filename)
                : string.Format("Untitled{0}", _unsavedID++);
            _ide = ide;
            _content = new DockContent();
            _content.FormClosing += on_FormClosing;
            _content.FormClosed += on_FormClosed;
            _content.Tag = this;
            _content.Icon = View.Icon;
            _content.TabText = _tabText;
            _content.ToolTipText = FileName;
            _content.Controls.Add(View);
            _content.Show(ide.MainDock, DockState.Document);
            View.DirtyChanged += on_DirtyChanged;

            // is the file writable?
            if (filename != null)
            {
                try
                {
                    FileIOPermission fp = new FileIOPermission(
                        FileIOPermissionAccess.Write, filename);
                    fp.Demand();
                }
                catch (SecurityException)
                {
                    View.ReadOnly = true;
                }
            }

            UpdateTabText();

            if (View is ScriptView)
            {
                ScriptView scriptView = View as ScriptView;
                scriptView.Breakpoints = Global.Project.GetBreakpoints(FileName);
                scriptView.BreakpointSet += on_BreakpointSet;
            }

            if (restoreView && FileName != null)
            {
                string setting = string.Format("viewState:{0:X8}", FileName.GetHashCode());
                try { View.ViewState = Global.Project.User.GetString(setting, ""); }
                catch (Exception) { } // *munch*
            }
        }

        public void Dispose()
        {
            _content.Dispose();
        }

        public event EventHandler Closed;
        
        /// <summary>
        /// Gets the fully-qualified file path for the document. If the document
        /// hasn't been saved yet, this will be null.
        /// </summary>
        public string FileName { get; private set; }

        /// <summary>
        /// Gets the tab's title text, including the trailing asterisk if the
        /// document has been modified.
        /// </summary>
        public string Title
        {
            get { return _content.TabText; }
        }
        
        /// <summary>
        /// Gets the underlying IDocumentView for the tab.
        /// </summary>
        public DocumentView View { get; private set; }

        /// <summary>
        /// Prompts the user to save a modified document. The document will
        /// remain open afterwards.
        /// </summary>
        /// <returns>'true' if the user saved, answered No, or if the file is clean; 'false' on cancel.</returns>
        public bool PromptSave()
        {
            if (View.IsDirty)
            {
                Activate();
                DialogResult result = MessageBox.Show(
                    string.Format("{0}\n\nThis document has been modified. Any unsaved changes will be lost if you continue. Do you want to save it now?", _tabText),
                    "Unsaved Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Cancel) return false;
                if (result == DialogResult.Yes)
                {
                    if (!Save()) return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Saves the document in this tab. If the document hasn't been saved yet,
        /// the user will be asked to provide a filename.
        /// </summary>
        /// <param name="path">The default directory for the Save As dialog.</param>
        public bool Save(string path = null)
        {
            if (View.ReadOnly) return true;
            if (FileName == null)
                return SaveAs(path);

            View.Save(FileName);
            SaveViewState();
            return true;
        }

        public bool SaveIfDirty()
        {
            if (FileName == null) return true;

            if (!View.IsDirty)
            {
                SaveViewState();
                return true;
            }
            else
            {
                return Save();
            }
        }

        /// <summary>
        /// Saves the document in this tab with a filename provided by the user.
        /// </summary>
        /// <param name="path">The default directory for the Save As dialog.</param>
        /// <returns>true if the file was saved, false on cancel.</returns>
        public bool SaveAs(string path = null)
        {
            using (var diag = new SaveFileDialog())
            {
                // set up the dialog parameters
                string filterString = "";
                foreach (string ext in View.FileExtensions)
                {
                    if (filterString != "") filterString += "|";
                    filterString += string.Format(".{0} File|*.{0}", ext);
                }
                diag.Title = "Save As";
                diag.InitialDirectory = path;
                diag.FileName = _tabText;
                diag.Filter = filterString;
                diag.DefaultExt = View.FileExtensions[0];

                // show the Save As dialog
                if (diag.ShowDialog() == DialogResult.OK)
                {
                    FileName = diag.FileName;
                    _tabText = Path.GetFileName(FileName);
                    UpdateTabText();
                    Save(path);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Closes the tab.
        /// </summary>
        /// <param name="forceClose">'true' to bypass the Unsaved Changes prompt.</param>
        /// <returns>'true' if the tab was closed; 'false' on cancel.</returns>
        public bool Close(bool forceClose = false)
        {
            if (forceClose || PromptSave())
            {
                // unsubscribe FormClosing event to prevent duplicate prompt
                _content.FormClosing -= on_FormClosing;
                
                // save view state and close tab
                SaveViewState();
                _content.Close();
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Notifies the document that a styling option changed.
        /// </summary>
        public void Restyle()
        {
            View.Restyle();
        }

        /// <summary>
        /// Makes the tab active and notifies the underlying document that it has
        /// received focus.
        /// </summary>
        public void Activate()
        {
            _content.DockHandler.Activate();
            View.Activate();
        }

        /// <summary>
        /// Notifies the underlying document that it has lost focus.
        /// </summary>
        public void Deactivate()
        {
            View.Deactivate();
        }

        /// <summary>
        /// Sends a Cut command to the document view.
        /// </summary>
        public void Cut()
        {
            View.Cut();
        }

        /// <summary>
        /// Sends a Copy command to the document view.
        /// </summary>
        public void Copy()
        {
            View.Copy();
        }

        /// <summary>
        /// Sends a Paste command to the document view.
        /// </summary>
        public void Paste()
        {
            View.Paste();
        }

        /// <summary>
        /// Sends an Undo command to the document view.
        /// </summary>
        public void Undo()
        {
            View.Undo();
        }

        /// <summary>
        /// Sends a Redo command to the document view.
        /// </summary>
        public void Redo()
        {
            View.Redo();
        }

        /// <summary>
        /// Sends a Zoom In command to the document view.
        /// </summary>
        public void ZoomIn()
        {
            View.ZoomIn();
        }

        /// <summary>
        /// Sends a Zoom Out command to the document view.
        /// </summary>
        public void ZoomOut()
        {
            View.ZoomOut();
        }

        private void SaveViewState()
        {
            if (FileName == null || View.IsDirty)
                return;  // save view only if clean

            // record breakpoints if script tab
            if (View is ScriptView)
                Global.Project.SetBreakpoints(FileName, ((ScriptView)View).Breakpoints);

            // save view (cursor position, etc.)
            Global.Project.User.SetValue(
                string.Format("viewState:{0:X8}", FileName.GetHashCode()),
                View.ViewState);
        }

        private void UpdateTabText()
        {
            _content.TabText = View.IsDirty ? _tabText + "*" : _tabText;
            if (View.ReadOnly)
                _content.TabText += " (read-only)";
            _content.ToolTipText = FileName;
        }

        private async void on_BreakpointSet(object sender, BreakpointSetEventArgs e)
        {
            if (FileName == null) return;
            ScriptView view = View as ScriptView;
            Global.Project.SetBreakpoints(FileName, view.Breakpoints);
            if (_ide.Debugger != null)
            {
                await _ide.Debugger.SetBreakpoint(FileName, e.LineNumber, e.Active);
            }
        }

        private void on_DirtyChanged(object sender, EventArgs e)
        {
            UpdateTabText();
        }

        private void on_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !PromptSave();
            if (!e.Cancel)
            {
                SaveViewState();
            }
        }

        private void on_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Closed != null) Closed(this, EventArgs.Empty);
            Dispose();
        }
    }
}
