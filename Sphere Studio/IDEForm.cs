using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI.Docking;

using Sphere.Core.Editor;
using Sphere.Core.Settings;
using Sphere.Plugins;
using SphereStudio.Components;
using SphereStudio.Forms;
using SphereStudio.IDE;
using SphereStudio.Settings;

namespace SphereStudio
{
    partial class IDEForm : Form, IIDE, IStyleable
    {
        // uninitialized data:
        private DockContent _treeContent;
        private DockContent _startContent;
        private readonly StartPage _startPage;
        private readonly ProjectTree _tree;
        private bool _firsttime;
        private readonly Dictionary<IEditorPlugin, string> _newHandlers = new Dictionary<IEditorPlugin, string>();
        private readonly Dictionary<string, string> _openFileTypes = new Dictionary<string, string>();
        private readonly Dictionary<EditorType, IEditorPlugin> _editors = new Dictionary<EditorType, IEditorPlugin>();
        private string _default_active;
        private bool _loadingPresets = false;

        private DocumentTab _activeTab;
        private List<DocumentTab> _tabs = new List<DocumentTab>();

        public event EventHandler LoadProject;
        public event EventHandler TestGame;
        public event EventHandler UnloadProject;

        /// <summary>
        /// Represents the main window for the Sphere Studio IDE.
        /// </summary>
        public IDEForm()
        {
            InitializeComponent();

            _firsttime = !Global.Settings.GetBoolean("setupComplete", false);

            _tree = new ProjectTree() { Dock = DockStyle.Fill, EditorForm = this };

            _startPage = new StartPage(this) { Dock = DockStyle.Fill, HelpLabel = HelpLabel };
            _startPage.PopulateGameList();

            NewToolButton.DropDown = menuNew.DropDown;
            OpenToolButton.DropDown = menuOpen.DropDown;

            InitializeDocking();

            PluginManager.IDE = this;
            Global.EvalPlugins();
            Global.Settings.Apply();

            SuspendLayout();
            UpdateStyle();
            Invalidate(true);
            ResumeLayout();

            UpdatePresetList();

            // make sure this is active only when we use it.
            if (_treeContent != null) _treeContent.Activate();

            var Is64 = System.Environment.Is64BitProcess;
            Text = string.Format("{0} {1} v{2}", Application.ProductName,
                (Is64) ? "x64" : "x86", Application.ProductVersion);

            ConfigSelectTool.SelectedIndexChanged += ConfigSelectTool_SelectedIndexChanged;

            if (Global.Settings.AutoOpenProject)
                menuOpenLastProject_Click(null, EventArgs.Empty);
        }

        #region Main IDE form event handlers
        private void IDEForm_Load(object sender, EventArgs e)
        {
            // this works around glitchy WeifenLuo behavior when messing with panel
            // visibility before the form loads.
            if (Global.Settings.AutoOpenProject)
            {
                if (Global.CurrentUser.StartHidden)
                {
                    _startContent.Hide();
                }

                DocumentTab tab = GetDocument(Global.CurrentUser.CurrentDocument);
                if (tab != null)
                    tab.Activate();
                else
                    _startContent.Show();
            }
        }

        private void IDEForm_Shown(object sender, EventArgs e)
        {
            if (_firsttime)
            {
                MessageBox.Show(@"Hello! It's your first time here! I would love to help you " +
                                @"set a few things up!", @"Welcome First Timer", MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                Global.Settings.SetValue("setupComplete", true);
                menuConfigManager_Click(null, EventArgs.Empty);
                _firsttime = false;
            }

            if (!String.IsNullOrWhiteSpace(_default_active))
            {
                DocumentTab tab = GetDocument(_default_active);
                if (tab != null) tab.Activate();
            }
        }

        private void IDEForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel |= !CloseCurrentProject();
        }

        void menu_DropDownOpening(object sender, EventArgs e)
        {
            Color c = ((ToolStripMenuItem)sender).DropDown.BackColor;
            if (c.R + c.G + c.B > 380)
                ((ToolStripMenuItem)sender).ForeColor = Color.Black;
            else
                ((ToolStripMenuItem)sender).ForeColor = Color.White;
        }

        void menu_DropDownClosed(object sender, EventArgs e)
        {
            Color c = MainMenuStrip.BackColor;
            if (c.R + c.G + c.B > 380) // find contrast level.
                ((ToolStripMenuItem)sender).ForeColor = Color.Black;
            else
                ((ToolStripMenuItem)sender).ForeColor = Color.White;
        }

        private void MainDock_ActiveDocumentChanged(object sender, EventArgs e)
        {
            if (MainDock.ActiveDocument == null) return;
            DockContent content = MainDock.ActiveDocument as DockContent;
            if (content.Tag is DocumentTab)
            {
                if (_activeTab != null) _activeTab.Deactivate();
                _activeTab = content.Tag as DocumentTab;
                _activeTab.Activate();
            }
            UpdateButtons();
        }
        #endregion

        #region File menu Click handlers
        private void menuFile_DropDownOpening(object sender, EventArgs e)
        {
            menuSaveAs.Enabled = menuSave.Enabled = (_activeTab != null);
            menuCloseProject.Enabled = IsProjectOpen;
            menuOpenLastProject.Enabled = (!IsProjectOpen ||
                Global.Settings.LastProject != Global.CurrentProject.RootPath);
            menu_DropDownOpening(sender, e);
        }

        private void menuNew_DropDownOpening(object sender, EventArgs e)
        {
            ToolStripDropDown dropdown = ((ToolStripDropDownItem)sender).DropDown;
            
            if (_newHandlers.Count > 0)
                dropdown.Items.Add(new ToolStripSeparator() { Name = "8:12" });
            foreach (var kv in (from kv in _newHandlers orderby kv.Value select kv))
            {
                ToolStripMenuItem item = new ToolStripMenuItem(kv.Value) { Name = "8:12" };
                item.Image = kv.Key.Icon.ToBitmap();
                item.Click += (sender1, e1) =>
                {
                    AddDocument(kv.Key.NewDocument());
                };
                dropdown.Items.Add(item);
            }
        }

        private void menuNew_DropDownClosed(object sender, EventArgs e)
        {
            ToolStripDropDown dropdown = ((ToolStripDropDownItem)sender).DropDown;

            while (dropdown.Items.ContainsKey("8:12"))
            {
                dropdown.Items.RemoveByKey("8:12");
            }
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void menuCloseProject_Click(object sender, EventArgs e)
        {
            CloseCurrentProject();
        }

        private void menuNewProject_Click(object sender, EventArgs e)
        {
            string sphereDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Sphere Studio");
            string rootPath = Path.Combine(sphereDir, "Projects");
            NewProjectForm myProject = new NewProjectForm { RootFolder = rootPath };

            if (!CloseCurrentProject()) return;

            if (myProject.ShowDialog() == DialogResult.OK)
            {
                Directory.CreateDirectory(rootPath);

                if (Global.CurrentProject == null)
                    Global.CurrentProject = new ProjectSettings();

                Global.CurrentProject.SetSettings(myProject.GetSettings());
                Global.CurrentProject.Create();
                Global.CurrentProject.Script = "main.js";
                Global.CurrentProject.SaveSettings();

                // automatically create the starting script //
                using (StreamWriter startscript = new StreamWriter(File.Open(Global.CurrentProject.RootPath + "\\scripts\\main.js", FileMode.CreateNew)))
                {
                    const string header = "/**\n* Script: main.js\n* Written by: {0}\n* Updated: {1}\n**/\n\nfunction game()\n{{\n\t\n}}";
                    startscript.Write(string.Format(header, Global.CurrentProject.Author, DateTime.Today.ToShortDateString()));
                    startscript.Flush();
                }

                menuRefreshProject_Click(null, EventArgs.Empty);
                _startPage.PopulateGameList();
                OpenDocument(Global.CurrentProject.RootPath + "\\scripts\\main.js");
            }
        }

        private void menuOpen_Click(object sender, EventArgs e)
        {
            string[] fileNames = GetFilesToOpen(false);
            if (fileNames == null) return;
            OpenDocument(fileNames[0]);
        }

        private void menuOpenProject_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog projDiag = new OpenFileDialog())
            {
                projDiag.Title = @"Open Project";
                projDiag.Filter = @"Game Files|*.sgm|All Files|*.*";

                string[] paths = Global.Settings.GetStringArray("gamePaths");
                if (paths.Length > 0)
                    projDiag.InitialDirectory = paths[0];

                if (projDiag.ShowDialog() == DialogResult.OK)
                    OpenProject(projDiag.FileName);
            }
        }

        private void menuOpenLastProject_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Global.Settings.LastProject) &&
                Directory.Exists(Global.Settings.LastProject))
            {
                OpenProject(Global.Settings.LastProject + "\\game.sgm");
            }
            else UpdateButtons();
        }

        private void menuSave_Click(object sender, EventArgs e)
        {
            if (_activeTab != null) _activeTab.Save();
        }

        private void menuSaveAs_Click(object sender, EventArgs e)
        {
            if (_activeTab != null) _activeTab.SaveAs();
        }

        private void menuSaveAll_Click(object sender, EventArgs e)
        {
            SaveAllDocuments();
        }
        #endregion

        #region Edit menu Click handlers
        private void menuEdit_DropDownOpening(object sender, EventArgs e)
        {
            menuCut.Enabled = menuSelectAll.Enabled = _activeTab != null;
            CopyToolButton.Enabled = menuCopy.Enabled = menuRedo.Enabled = menuUndo.Enabled = _activeTab != null;
            menuPaste.Enabled = PasteToolButton.Enabled = true;
            menuZoomIn.Enabled = menuZoomOut.Enabled = _activeTab != null;
            menu_DropDownOpening(sender, e);
        }

        private void menuCopy_Click(object sender, EventArgs e)
        {
            if (_activeTab != null) _activeTab.Copy();
        }

        private void menuCut_Click(object sender, EventArgs e)
        {
            if (_activeTab != null) _activeTab.Cut();
        }

        private void menuPaste_Click(object sender, EventArgs e)
        {
            if (_activeTab != null) _activeTab.Paste();
        }

        private void menuRedo_Click(object sender, EventArgs e)
        {
            if (_activeTab != null) _activeTab.Redo();
        }

        private void menuSelectAll_Click(object sender, EventArgs e)
        {
            //if (_activeTab != null) _activeTab.SelectAll();
        }

        private void menuUndo_Click(object sender, EventArgs e)
        {
            if (_activeTab != null) _activeTab.Undo();
        }

        private void menuZoomIn_Click(object sender, EventArgs e)
        {
            if (_activeTab != null) _activeTab.ZoomIn();
        }

        private void menuZoomOut_Click(object sender, EventArgs e)
        {
            if (_activeTab != null) _activeTab.ZoomOut();
        }
        #endregion

        #region View menu Click handlers
        private void menuView_DropDownOpening(object sender, EventArgs e)
        {
            if (_tabs.Count > 0)
            {
                ToolStripSeparator ts = new ToolStripSeparator { Name = "zz_v" };
                menuView.DropDownItems.Add(ts);
            }
            foreach (DocumentTab tab in _tabs)
            {
                ToolStripMenuItem item = new ToolStripMenuItem(tab.Title) { Name = "zz_v" };
                item.Click += menuDocumentItem_Click;
                item.Image = tab.View.Icon.ToBitmap();
                item.Tag = tab.FileName;
                item.Checked = tab == _activeTab;
                menuView.DropDownItems.Add(item);
            }
            menu_DropDownOpening(sender, e);
        }

        private void menuView_DropDownClosed(object sender, EventArgs e)
        {
            for (int i = 0; i < menuView.DropDownItems.Count; ++i)
            {
                if (menuView.DropDownItems[i].Name == "zz_v")
                {
                    menuView.DropDownItems.RemoveAt(i);
                    i--;
                }
            }
            menu_DropDownClosed(sender, e);
        }

        void menuDocumentItem_Click(object sender, EventArgs e)
        {
            DocumentTab tab = GetDocument(((ToolStripItem)sender).Tag as string);
            if (tab != null) 
                tab.Activate();
            else
                SelectDocument((string)((ToolStripMenuItem)sender).Tag);
        }

        private void menuClosePane_Click(object sender, EventArgs e)
        {
            if (MainDock.ActiveDocument == null) return;

            if (MainDock.ActiveDocument is DockContent &&
                ((DockContent)MainDock.ActiveDocument).Controls[0] is StartPage)
            {
                menuStartPage_Click(null, EventArgs.Empty);
            }
            else MainDock.ActiveDocument.DockHandler.Close();
        }

        private void menuProjectTree_Click(object sender, EventArgs e)
        {
            if (_treeContent.IsHidden) _treeContent.Show(MainDock, DockState.DockLeft);
            else _treeContent.Hide();
        }

        private void menuStartPage_Click(object sender, EventArgs e)
        {
            if (_startContent.IsHidden) _startContent.Show();
            else _startContent.Hide();
        }
        #endregion

        #region Project menu Click handlers
        private void menuGameSettings_Click(object sender, EventArgs e)
        {
            OpenGameSettings();
        }

        private void menuOpenGameDir_Click(object sender, EventArgs e)
        {
            string path = Global.CurrentProject.RootPath;
            var proc = Process.Start("explorer.exe", string.Format("/select, \"{0}\\game.sgm\"", path));
            proc.Dispose();
        }

        private void menuTestGame_Click(object sender, EventArgs e)
        {
            if (TestGame != null) TestGame(null, EventArgs.Empty);

            if (IsProjectOpen)
            {
                Global.CurrentProject.SaveSettings();
                string args = string.Format("-game \"{0}\"", Global.CurrentProject.RootPath);
                string enginePath = ((ToolStripItem)sender).Tag as string ??
                    (PlatformTool.Text == "x64" ? Global.Settings.EnginePath64 : Global.Settings.EnginePath);
                Process.Start(enginePath, args);
            }
            else
                Process.Start(Global.Settings.EnginePath);
        }

        private void menuRefreshProject_Click(object sender, EventArgs e)
        {
            RefreshProject();
        }
        #endregion

        #region Tools menu Click handlers
        private void menuConfigEngine_Click(object sender, EventArgs e)
        {
            string path = Path.GetDirectoryName(Global.Settings.EngineConfigPath);
            if (path != null) Directory.SetCurrentDirectory(path);
            if (File.Exists(Global.Settings.EngineConfigPath))
                Process.Start(Global.Settings.EngineConfigPath);
            Directory.SetCurrentDirectory(Application.StartupPath);
        }

        private void menuConfigManager_Click(object sender, EventArgs e)
        {
            new ConfigManagerForm().ShowDialog(this);
            UpdatePresetList();
        }

        private void menuEditorSettings_Click(object sender, EventArgs e)
        {
            OpenEditorSettings();
        }
        #endregion

        #region Help menu Click handlers
        private void menuAbout_Click(object sender, EventArgs e)
        {
            using (AboutBoxForm about = new AboutBoxForm())
            {
                about.ShowDialog();
            }
        }

        private void menuAPI_Click(object sender, EventArgs e)
        {
            OpenDocument(Path.Combine(Application.StartupPath, "Docs/api.txt"));
        }
        #endregion

        #region Configuration Selector handlers
        private void ConfigSelectTool_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_loadingPresets) return;

            if (ConfigSelectTool.SelectedIndex == 0 && Global.Settings.Preset == null)
                return;

            // user selected Configuration Manager (always at bottom)
            if (ConfigSelectTool.SelectedIndex == ConfigSelectTool.Items.Count - 1)
            {
                menuConfigManager_Click(null, EventArgs.Empty);
                return;
            }

            Global.Settings.Preset = ConfigSelectTool.Text;
            UpdatePresetList();
        }

        private void PlatformTool_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_loadingPresets) return;

            Global.Settings.TestPlatform = PlatformTool.Text;
            UpdatePresetList();
        }
        #endregion

        public DocumentView CurrentDocument
        {
            get { return _activeTab.View; }
        }

        public ProjectSettings CurrentGame
        {
            get { return Global.CurrentProject; }
        }

        /// <summary>
        /// Gets a list of filenames of opened documents. Unsaved documents
        /// without filenames will be excluded.
        /// </summary>
        public string[] Documents
        {
            get
            {
                var q = from tab in _tabs
                        where tab.FileName != null
                        select tab.FileName;
                return q.ToArray();
            }
        }

        public ISettings Settings
        {
            get { return Global.Settings; }
        }

        /// <summary>
        /// Adds a new top-level menu to the IDE menu bar.
        /// </summary>
        /// <param name="item">The menu item to add.</param>
        /// <param name="before">The name of the menu before which this one will be inserted.</param>
        public void AddMenuItem(ToolStripMenuItem item, string before = "")
        {
            if (string.IsNullOrEmpty(before)) EditorMenu.Items.Add(item);
            int insertion = -1;
            foreach (ToolStripItem menuitem in EditorMenu.Items)
            {
                if (menuitem.Text.Replace("&", "") == before)
                    insertion = EditorMenu.Items.IndexOf(menuitem);
            }
            CreateRootMenuItem(item);
            EditorMenu.Items.Insert(insertion, item);
        }

        /// <summary>
        /// Adds a subitem to an existing menu
        /// </summary>
        /// <param name="location">The menu to add the item to. Use dots to drill down, e.g. "File.New"</param>
        /// <param name="newItem">The ToolStripItem of the menu item to add.</param>
        public void AddMenuItem(string location, ToolStripItem newItem)
        {
            string[] items = location.Split('.');
            ToolStripMenuItem item = GetMenuItem(EditorMenu.Items, items[0]);
            if (item == null)
            {
                item = new ToolStripMenuItem(items[0]);
                CreateRootMenuItem(item);
                EditorMenu.Items.Add(item);
            }

            for (int i = 1; i < items.Length; ++i)
            {
                ToolStripMenuItem menuitem = GetMenuItem(item.DropDownItems, items[i]);
                if (menuitem == null)
                {
                    menuitem = new ToolStripMenuItem(items[i]);
                    item.DropDownItems.Add(menuitem);
                }
                item = menuitem;
            }

            item.DropDownItems.Add(newItem);
        }

        public void DockControl(DockDescription description)
        {
            if (description.Control == null) return;

            DockContent ctrl = new DockContent() { Text = description.TabText, Icon = description.Icon };
            ctrl.Controls.Add(description.Control);

            DockAreas areas = DockAreas.Document;

            if (description.DockAreas == DockDescAreas.Sides)
            {
                areas = DockAreas.DockBottom | DockAreas.DockLeft | DockAreas.DockRight | DockAreas.DockTop;
            }
            else if (description.DockAreas == (DockDescAreas.Document | DockDescAreas.Sides))
            {
                areas |= DockAreas.DockBottom | DockAreas.DockLeft | DockAreas.DockRight | DockAreas.DockTop;
            }

            ctrl.DockAreas = areas;

            description.OnShow += new EventHandler(delegate(object o, EventArgs e)
            {
                ctrl.Show();
            });

            description.OnHide += new EventHandler(delegate(object o, EventArgs e)
            {
                ctrl.Hide();
            });

            description.OnToggle += new EventHandler(delegate(object o, EventArgs e)
            {
                if (ctrl.IsHidden) ctrl.Show();
                else ctrl.Hide();
            });

            DockState state = DockState.Document;
            if (description.DockState == DockDescStyle.Side && areas.HasFlag(DockAreas.DockLeft))
                state = DockState.DockLeft;

            ctrl.Show(MainDock, state);
        }

        public void OpenDocument(string filePath, bool restoreView = false)
        {
            // the IDE will try to open the file through the plugin manager first.
            // if that fails, then use the current default editor (if any).
            DocumentView view;
            if (!PluginManager.OpenDocument(filePath, out view))
            {
                // nobody claimed the file, so find the current default editor plugin
                string wildcard = Global.Settings.DefaultEditor;
                var q = from plugin in PluginManager.GetWildcards()
                        where wildcard == plugin.Name
                        select plugin;
                IEditorPlugin wcPlugin = q.FirstOrDefault();
                
                // if there's a default editor, use it.
                if (wcPlugin != null)
                    view = wcPlugin.OpenDocument(filePath);
                else
                {
                    string extension = Path.GetExtension(filePath);
                    MessageBox.Show(String.Format("Sphere Studio doesn't know how to open that type of file and no wildcard plugin is currently set.\n\nFile Type: {0}\n\nPath to File:\n{1}", extension.ToLower(), filePath),
                        @"Unable to Open File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (view != null)
            {
                AddDocument(view, filePath, restoreView);
            }
        }

        /// <summary>
        /// Opens a Sphere project for editor use.
        /// </summary>
        /// <param name="filename">The filename of the project.</param>
        public void OpenProject(string filename)
        {
            if (string.IsNullOrEmpty(filename)) return;
            if (!CloseCurrentProject()) return;

            Global.CurrentProject = new ProjectSettings();
            Global.CurrentProject.LoadSettings(filename);

            RefreshProject();

            if (LoadProject != null) LoadProject(null, EventArgs.Empty);
            if (_treeContent != null) _treeContent.Activate();

            HelpLabel.Text = @"Game project loaded successfully!";

            Global.CurrentUser = new UserSettings();
            Global.CurrentUser.LoadSettings(Path.GetDirectoryName(filename));

            _startContent.Show();
            
            string[] docs = Global.CurrentUser.Documents;
            foreach (string s in docs)
            {
                if (String.IsNullOrWhiteSpace(s)) continue;
                try { OpenDocument(s, true); }
                catch (Exception) { }
            }

            // if the form is not visible, don't try to mess with the panels.
            // it will be done in Form_Load.
            if (Visible)
            {
                if (Global.CurrentUser.StartHidden)
                    _startContent.Hide();

                DocumentTab tab = GetDocument(Global.CurrentUser.CurrentDocument);
                if (tab != null)
                    tab.Activate();
                else
                    _startContent.Show();
            }

            UpdateButtons();
        }

        public ISettings OpenSettings(string section)
        {
            return new INISettings("Sphere Studio.ini", section);
        }

        public void RegisterNewHandler(IEditorPlugin plugin, string name)
        {
            _newHandlers[plugin] = name;
        }

        public void RegisterOpenFileType(string typeName, string filters)
        {
            _openFileTypes[filters] = typeName;
        }

        public void RemoveControl(string name)
        {
            DockContent c = FindDocument(name);
            if (c != null) c.DockHandler.Close();
        }

        public void RemoveMenuItem(ToolStripItem item)
        {
            ToolStripMenuItem menuItem = item.OwnerItem as ToolStripMenuItem;
            if (menuItem != null) menuItem.DropDownItems.Remove(item);
        }

        public void RemoveMenuItem(string name)
        {
            ToolStripMenuItem item = GetMenuItem(EditorMenu.Items, name);
            if (item != null) item.Dispose();
        }

        /// <summary>
        /// Calls the restyle method on all loaded editors.
        /// </summary>
        public void RestyleEditors()
        {
            foreach (DocumentTab tab in _tabs)
            {
                tab.Restyle();
            }
        }

        public void UnregisterNewHandler(IEditorPlugin plugin)
        {
            _newHandlers.Remove(plugin);
        }
        
        public void UnregisterOpenFileType(string filters)
        {
            if (!_openFileTypes.ContainsKey(filters)) return;
            _openFileTypes.Remove(filters);
        }

        public void UpdateStyle()
        {
            StyleSettings.ApplyStyle(MainMenuStrip);
            StyleSettings.ApplyStyle(EditorTools);
            StyleSettings.ApplyStyle(EditorStatus);
            UpdateMenuItems();
        }

        #region Private IDE routines
        private void InitializeDocking()
        {
            _treeContent = new DockContent();
            _treeContent.Controls.Add(_tree);
            _treeContent.Text = @"Project Explorer";
            _treeContent.DockAreas = DockAreas.DockLeft | DockAreas.DockRight;
            _treeContent.HideOnClose = true;
            _treeContent.Icon = Icon.FromHandle(Properties.Resources.SphereEditor.GetHicon());
            _treeContent.Show(MainDock, DockState.DockLeft);

            _startContent = new DockContent
            {
                Icon = Icon.FromHandle(Properties.Resources.SphereEditor.GetHicon()),
                Text = @"Start Page",
                HideOnClose = true
            };
            _startContent.Controls.Add(_startPage);
            _startContent.Show(MainDock);
        }

        /// <summary>
        /// Searches open document tabs for one with a specified filename.
        /// </summary>
        /// <param name="filepath">The name of the file to search for.</param>
        /// <returns>The DocumentTab of the document, or null if none was found.</returns>
        internal DocumentTab GetDocument(string filepath)
        {
            foreach (DocumentTab tab in _tabs)
            {
                if (tab.FileName == filepath) return tab;
            }
            return null;
        }

        internal string[] GetFilesToOpen(bool multiselect)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                string filterString = "";
                foreach (string filterID in from key in _openFileTypes.Keys orderby _openFileTypes[key] select key)
                {
                    filterString += String.Format("{0}|{1}|", _openFileTypes[filterID], filterID);
                }
                filterString += @"All Files|*.*";
                dialog.Filter = filterString;
                dialog.FilterIndex = 5 + _openFileTypes.Count;
                dialog.InitialDirectory = Global.CurrentProject.RootPath;
                dialog.Multiselect = multiselect;
                return dialog.ShowDialog() == DialogResult.OK ? dialog.FileNames : null;
            }
        }

        /// <summary>
        /// Sets the default active document when the editor first starts up.
        /// Used internally when dragging a file onto the executable.
        /// </summary>
        /// <param name="name">File path of the document to set.</param>
        internal void SetDefaultActive(string name)
        {
            _default_active = name;
        }

        private bool IsProjectOpen
        {
            get { return Global.CurrentProject != null; }
        }

        private void AddDocument(DocumentView view, string filepath = null, bool restoreView = false)
        {
            DocumentTab tab = new DocumentTab(this, view, filepath, restoreView);
            tab.Closed += (sender, e) => _tabs.Remove(tab);
            tab.Activate();
            _tabs.Add(tab);
        }

        private DockContent FindDocument(string name)
        {
            return MainDock.Contents.Cast<DockContent>().FirstOrDefault(content => content.DockHandler.TabText == name);
        }

        /// <summary>
        /// Saves all currently opened documents.
        /// </summary>
        private void ApplyRefresh(bool ignore_presets = false)
        {
            if (!ignore_presets)
                UpdatePresetList();

            UpdateButtons();
            SuspendLayout();
            _startPage.PopulateGameList();
            UpdateMenuItems();
            UpdateStyle();
            Invalidate(true);
            ResumeLayout();
        }

        /// <summary>
        /// Closes all opened documents; optionally saving them as well.
        /// </summary>
        /// <param name="save">Set to true to invoke save routines.</param>
        /// <returns>true if all documents were closed, false if a save prompt was canceled.</returns>
        private bool CloseAllDocuments()
        {
            DocumentTab[] toClose = (from tab in _tabs select tab).ToArray();
            foreach (DocumentTab tab in toClose)
                if (!tab.PromptSave()) return false;
            foreach (DocumentTab tab in toClose)
                tab.Close(true, true);

            _startContent.Hide();
            return true;
        }

        /// <summary>
        /// Closes the current project and all open documents.
        /// </summary>
        /// <returns>'true' if the project was closed; 'false' on cancel.</returns>
        private bool CloseCurrentProject()
        {
            // user values will be lost if we don't record them now.
            if (Global.CurrentUser != null)
            {
                Global.CurrentUser.ProjectName = Global.CurrentProject.Name;
                Global.CurrentUser.Author = Global.CurrentProject.Author;
                Global.CurrentUser.StartHidden = !_startContent.Visible;
                Global.CurrentUser.Documents = Documents;
                if (_activeTab != null)
                    Global.CurrentUser.CurrentDocument = _activeTab.FileName;
            }

            // close all open document tabs
            if (!CloseAllDocuments())
                return false;
            
            // save and unload the project
            if (Global.CurrentProject != null)
            {
                if (UnloadProject != null)
                    UnloadProject(null, EventArgs.Empty);
                Global.CurrentProject.SaveSettings();
            }
            if (Global.CurrentUser != null)
            {
                Global.CurrentUser.SaveSettings(Global.CurrentProject.RootPath);
            }
            
            // clear the project tree
            _tree.Close();
            _tree.ProjectName = "Project Name";
            menuOpenLastProject.Enabled = (Global.Settings.LastProject.Length > 0);
            
            // all clear!
            Global.CurrentUser = null;
            Global.CurrentProject = null;
            UpdateButtons();
            return true;
        }

        // Needed to make sure menu items are visible on a variety of
        // color themes. Eg, White text on a white theme = unreadable.
        private void CreateRootMenuItem(ToolStripMenuItem item)
        {
            item.DropDownOpening += menu_DropDownOpening;
            item.DropDownClosed += menu_DropDownClosed;
        }

        private ToolStripMenuItem GetMenuItem(ToolStripItemCollection collection, string name)
        {
            return collection.OfType<ToolStripMenuItem>().FirstOrDefault(item => item.Text.Replace("&", "") == name);
        }

        public void OpenEditorSettings()
        {
            if (Global.EditSettings()) ApplyRefresh();
        }

        private void OpenGameSettings()
        {
            using (GameSettings settings = new GameSettings(Global.CurrentProject))
            {
                if (settings.ShowDialog() == DialogResult.OK)
                {
                    Global.CurrentProject.SetSettings(settings.GetSettings());
                    Global.CurrentProject.SaveSettings();
                }
            }
        }

        private void RefreshProject()
        {
            _tree.Open();
            _tree.Refresh();
            if (Global.CurrentProject.RootPath != null)
                Global.Settings.LastProject = Global.CurrentProject.RootPath;
            UpdateButtons();
            _tree.ProjectName = "Project: " + Global.CurrentProject.Name;
        }

        private void RemoveRootMenuItem(ToolStripMenuItem item)
        {
            item.DropDownOpening -= menu_DropDownOpening;
            item.DropDownClosed -= menu_DropDownClosed;
        }

        private void SaveAllDocuments()
        {
            foreach (DocumentTab tab in _tabs)
            {
                tab.Save();
            }
        }

        /// <summary>
        /// Saves and closes all project related files.
        /// </summary>
        /// <param name="save_docs">Optional, because sometimes you want to do this before the final closure.</param>
        private void SaveAndCloseProject(bool save_docs = true)
        {
        }

        /// <summary>
        /// Selects a document by tab name, this is not ideal for editors but useful for
        /// persistent objects like the project tree and plugins.
        /// </summary>
        /// <param name="name">The content's tab text to look for.</param>
        private void SelectDocument(string name)
        {
            foreach (IDockContent content in MainDock.Contents)
                if (content.DockHandler.TabText == name)
                    content.DockHandler.Activate();
        }

        private void UpdateButtons()
        {
            bool config = File.Exists(Global.Settings.EngineConfigPath);
            OptionsToolButton.Enabled = menuConfigEngine.Enabled = config;

            bool sphereFound = File.Exists(Global.Settings.EnginePath)
                || (File.Exists(Global.Settings.EnginePath64) && Environment.Is64BitOperatingSystem);
            toolTestGame.Enabled = menuTestGame.Enabled = sphereFound;

            bool last = !string.IsNullOrEmpty(Global.Settings.LastProject);
            menuOpenLastProject.Enabled = last;

            menuGameSettings.Enabled = GameToolButton.Enabled = IsProjectOpen;
            menuOpenGameDir.Enabled = menuRefreshProject.Enabled = IsProjectOpen;

            SaveToolButton.Enabled = _activeTab != null;
            CutToolButton.Enabled = _activeTab != null;
            CopyToolButton.Enabled = _activeTab != null;

        }

        private void UpdateMenuItems()
        {
            foreach (ToolStripMenuItem item in MainMenuStrip.Items)
                menu_DropDownClosed(item, null);
        }

        private void UpdatePresetList()
        {
            bool wasLoadingPresets = _loadingPresets;
            _loadingPresets = true;

            toolTestGame.DropDown.Items.Clear();
            PlatformTool.Items.Clear();
            if (Environment.Is64BitOperatingSystem && File.Exists(Global.Settings.EnginePath64))
            {
                string engineName = String.Format("x64 {0}", Path.GetFileName(Global.Settings.EnginePath64));
                ToolStripMenuItem item = new ToolStripMenuItem(engineName);
                item.Click += menuTestGame_Click;
                item.Tag = Global.Settings.EnginePath64;
                toolTestGame.DropDown.Items.Add(item);
                PlatformTool.Items.Add("x64");
            }
            if (File.Exists(Global.Settings.EnginePath))
            {
                string engineName = String.Format("x86 {0}", Path.GetFileName(Global.Settings.EnginePath));
                ToolStripMenuItem item = new ToolStripMenuItem(engineName);
                item.Click += menuTestGame_Click;
                item.Tag = Global.Settings.EnginePath;
                toolTestGame.DropDown.Items.Add(item);
                PlatformTool.Items.Add("x86");
            }
            PlatformTool.Enabled = PlatformTool.Items.Count > 0;
            if (PlatformTool.Items.Contains(Global.Settings.TestPlatform))
                PlatformTool.Text = Global.Settings.TestPlatform;
            else if (PlatformTool.Enabled)
                PlatformTool.SelectedIndex = 0;

            ConfigSelectTool.Items.Clear();

            string sphereDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Sphere Studio");
            string path = Path.Combine(sphereDir, @"Presets");
            if (Directory.Exists(path))
            {
                var presetFiles = from filename in Directory.GetFiles(path, "*.preset")
                                  orderby filename ascending
                                  select filename;
                foreach (string s in presetFiles)
                {
                    ConfigSelectTool.Items.Add(Path.GetFileNameWithoutExtension(s));
                }
                if (Global.Settings.Preset != null)
                    ConfigSelectTool.SelectedItem = Global.Settings.Preset;
            }
            ConfigSelectTool.Items.Add("Configuration Manager...");

            // if no active preset selected, settings were edited manually
            if (ConfigSelectTool.SelectedIndex == -1)
            {
                ConfigSelectTool.Items.Insert(0, "Custom Settings");
                ConfigSelectTool.SelectedIndex = 0;
            }

            _loadingPresets = wasLoadingPresets;
        }
        #endregion
    }
}