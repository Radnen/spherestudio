using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI.Docking;

using Sphere.Core;
using Sphere.Core.Editor;
using Sphere.Plugins;
using Sphere.Plugins.Interfaces;
using Sphere.Plugins.Views;
using SphereStudio.DockPanes;
using SphereStudio.Forms;
using SphereStudio.Properties;
using SphereStudio.SettingsPages;
using SphereStudio.Views;

namespace SphereStudio
{
    /// <summary>
    /// Represents an instance of the Sphere Studio IDE.
    /// </summary>
    partial class MainWindow : Form, ICore, IStyleable
    {
        private DocumentTab _activeTab;
        private string _defaultActiveName;
        private DockManager _dock = null;
        private bool _isFirstDebugStop;
        private bool _loadingPresets = false;
        private ProjectTree _projectTree;
        private StartPageView _startPage = null;
        private DocumentTab _startTab = null;
        private List<DocumentTab> _tabs = new List<DocumentTab>();

        public MainWindow()
        {
            InitializeComponent();

            PluginManager.Core = this;
            PluginManager.Register(null, new DefaultStyles(), "Sphere Studio");
            PluginManager.Register(null, new SettingsPage(), "Sphere Studio IDE");

            InitializeDocking();
            PluginManager.Register(null, _projectTree, "Project Tree");

            Text = string.Format("{0} {1} {2}", Versioning.Name, Versioning.Version,
                Environment.Is64BitProcess ? "x64" : "x86");
            toolNew.DropDown = menuNew.DropDown;

            BuildEngine.Initialize();
            Core.Settings.Apply();

            Docking.Show(_projectTree);
            Docking.Activate(_projectTree);
            Refresh();

            if (Core.Settings.AutoOpenLastProject)
                menuOpenLastProject_Click(null, EventArgs.Empty);

            Styler.AutoStyle(this);
        }

        public event EventHandler LoadProject;
        public event EventHandler TestGame;
        public event EventHandler UnloadProject;

        public DocumentView ActiveDocument { get { return _activeTab.View; } }
        public IDebugger Debugger { get; private set; }
        public IDock Docking { get { return _dock; } }
        public IProject Project { get { return Core.Project; } }
        public ICoreSettings Settings { get { return Core.Settings; } }

        protected bool StartVisible
        {
            // This is kind of hacky, but it beats working with the Weifen Luo controls
            // directly.
            get
            {
                if (_startTab != null && !_tabs.Contains(_startTab))
                {
                    _startTab.Dispose();
                    _startTab = null;
                }
                return _startTab != null;
            }
            set
            {
                if (value && !StartVisible)
                {
                    _startPage = new StartPageView(this) { HelpLabel = HelpLabel };
                    _startPage.PopulateGameList();
                    _startTab = AddDocument(_startPage, "Start Page");
                    _startTab.Restyle();
                }
                else if (!value && StartVisible)
                {
                    _startTab.Close(true);
                    _startTab.Dispose();
                    _startTab = null;
                }
            }
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
        /// Adds a subitem to an existing menu.
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

        public DocumentView OpenFile(string filePath)
        {
            return OpenFile(filePath, false);
        }

        public DocumentView OpenFile(string filePath, bool restoreView)
        {
            string extension = Path.GetExtension(filePath);

            // is it a project?
            if (extension.ToUpper() == ".SSPROJ")
            {
                OpenProject(filePath);
                return null;
            }

            // if the file is already open, just switch to it
            DocumentTab tab = GetDocument(filePath);
            if (tab != null)
            {
                tab.Activate();
                return tab.View;
            }

            // the IDE will look for a file opener explicitly declaring the file extension.
            // if that fails, then use the default opener (if any).
            DocumentView view = null;
            try
            {
                string fileExtension = Path.GetExtension(filePath);
                if (fileExtension.StartsWith("."))  // remove dot from extension
                    fileExtension = fileExtension.Substring(1);
                var plugins = from name in PluginManager.GetNames<IFileOpener>()
                              let plugin = PluginManager.Get<IFileOpener>(name)
                              where plugin.FileExtensions.Contains(fileExtension)
                              select plugin;
                IFileOpener defaultOpener = PluginManager.Get<IFileOpener>(Core.Settings.FileOpener);
                IFileOpener opener = plugins.FirstOrDefault() ?? defaultOpener;
                if (opener != null)
                    view = opener.Open(filePath);
                else
                {
                    MessageBox.Show(string.Format("Sphere Studio doesn't know how to open that type of file and no default file opener is available.  Tip: Open Configuration Manager and check your plugins.\n\nFile Type: {0}\n\nPath to File:\n{1}", fileExtension.ToLower(), filePath),
                        @"Unable to Open File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (IOException)
            {
                return null;
            }

            if (view != null)
                AddDocument(view, filePath, restoreView);
            return view;
        }

        /// <summary>
        /// Loads a Sphere Studio project into the IDE.
        /// </summary>
        /// <param name="fileName">The filename of the project.</param>
        /// <param name="usePluginWarning">Whether to show a warning if required plugins are missing.</param>
        public void OpenProject(string fileName, bool usePluginWarning = true)
        {
            if (string.IsNullOrEmpty(fileName))
                return;

            Project pj = SphereStudio.Project.Open(fileName);
            IStarter starter = PluginManager.Get<IStarter>(pj.User.Engine);
            ICompiler compiler = PluginManager.Get<ICompiler>(pj.Compiler);
            if (usePluginWarning && (starter == null || compiler == null))
            {
                var answer = MessageBox.Show(
                    string.Format("One or more plugins required to work on '{0}' are either disabled or not installed.  Please open Configuration Manager and check your plugins.\n\nCompiler required:\n{1}\n\nIf you continue, data may be lost.  Open this project anyway?", pj.Name, pj.Compiler),
                    "Proceed with Caution", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (answer == DialogResult.No)
                    return;
            }

            if (!CloseCurrentProject()) return;
            Core.Project = pj;

            RefreshProject();

            if (LoadProject != null) LoadProject(null, EventArgs.Empty);

            HelpLabel.Text = @"Game project loaded successfully!";

            StartVisible = true;

            string[] docs = Core.Project.User.Documents;
            foreach (string s in docs)
            {
                if (string.IsNullOrWhiteSpace(s)) continue;
                try { OpenFile(s, true); }
                catch (Exception) { }
            }

            // if the form is not visible, don't try to mess with the panels.
            // it will be done in Form_Load.
            if (Visible)
            {
                if (Core.Project.User.StartHidden)
                    StartVisible = false;

                DocumentTab tab = GetDocument(Core.Project.User.ActiveDocument);
                if (tab != null)
                    tab.Activate();
            }

            Text = string.Format("{3} - {0} {1} {2}",
                Versioning.Name, Versioning.Version, Environment.Is64BitProcess ? "x64" : "x86",
                Project.Name);

            UpdateEngineList();
            UpdateControls();
        }

        public override void Refresh()
        {
            base.Refresh();

            foreach (DocumentTab tab in _tabs)
                tab.Restyle();
            _dock.Refresh();
            UpdateEngineList();
            UpdateControls();
        }

        public void ApplyStyle(UIStyle style)
        {
            style.AsHeading(MainMenuStrip);
            style.AsUIElement(EditorTools);
            style.AsHeading(EditorStatus);
            UpdateMenuItems();
        }

        #region Main IDE form event handlers
        private void IDEForm_Load(object sender, EventArgs e)
        {
            Location = new Point(Properties.Settings.Default.WindowX, Properties.Settings.Default.WindowY);
            Size = new Size(Properties.Settings.Default.WindowWidth, Properties.Settings.Default.WindowHeight);
            WindowState = Properties.Settings.Default.WindowMaxed ? FormWindowState.Maximized : FormWindowState.Normal;

            // this works around glitchy WeifenLuo behavior when messing with panel
            // visibility before the form loads.
            if (Core.Settings.AutoOpenLastProject && Core.Project != null)
            {
                StartVisible = !Core.Project.User.StartHidden;
                DocumentTab tab = GetDocument(Core.Project.User.ActiveDocument);
                if (tab != null)
                    tab.Activate();
            }
            else
            {
                StartVisible = Core.Settings.UseStartPage;
            }
        }

        private void IDEForm_Shown(object sender, EventArgs e)
        {
            bool isFirstRun = !Core.Settings.GetBoolean("setupComplete", false);
            if (isFirstRun)
            {
                MessageBox.Show(@"Hello! It's your first time here! I would love to help you " +
                                @"set a few things up!", @"Welcome First Timer", MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                Core.Settings.SetValue("setupComplete", true);
                menuConfigManager_Click(null, EventArgs.Empty);
            }

            if (!String.IsNullOrWhiteSpace(_defaultActiveName))
            {
                DocumentTab tab = GetDocument(_defaultActiveName);
                if (tab != null) tab.Activate();
            }
        }

        private void IDEForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.Cancel) return;

            Rectangle savedBounds = WindowState != FormWindowState.Normal ? RestoreBounds : Bounds;
            Properties.Settings.Default.WindowX = savedBounds.X;
            Properties.Settings.Default.WindowY = savedBounds.Y;
            Properties.Settings.Default.WindowWidth = savedBounds.Width;
            Properties.Settings.Default.WindowHeight = savedBounds.Height;
            Properties.Settings.Default.WindowMaxed = WindowState == FormWindowState.Maximized;
            Properties.Settings.Default.Save();

            Size = new Size(Properties.Settings.Default.WindowWidth, Properties.Settings.Default.WindowHeight);
            WindowState = Properties.Settings.Default.WindowMaxed ? FormWindowState.Maximized : FormWindowState.Normal;

            if (!CloseCurrentProject(true))
                e.Cancel = true;
            else
            {
                _dock.Persist();
            }
        }

        void menu_DropDownOpening(object sender, EventArgs e)
        {
            Color c = ((ToolStripMenuItem) sender).DropDown.BackColor;
            if (c.R + c.G + c.B > 380)
                ((ToolStripMenuItem) sender).ForeColor = Color.Black;
            else
                ((ToolStripMenuItem) sender).ForeColor = Color.White;
        }

        void menu_DropDownClosed(object sender, EventArgs e)
        {
            Color c = MainMenuStrip.BackColor;
            if (c.R + c.G + c.B > 380) // find contrast level.
                ((ToolStripMenuItem) sender).ForeColor = Color.Black;
            else
                ((ToolStripMenuItem) sender).ForeColor = Color.White;
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
            UpdateControls();
        }
        #endregion

        #region File menu Click handlers
        private void menuFile_DropDownOpening(object sender, EventArgs e)
        {
            menuSaveAs.Enabled = menuSave.Enabled = (_activeTab != null);
            menuCloseProject.Enabled = IsProjectOpen;
            menuOpenLastProject.Enabled = (!IsProjectOpen ||
                Core.Settings.LastProject != Core.Project.RootPath);
            menu_DropDownOpening(sender, e);
        }

        internal void menuNew_DropDownOpening(object sender, EventArgs e)
        {
            ToolStripDropDown dropdown = ((ToolStripDropDownItem) sender).DropDown;

            string[] pluginNames = PluginManager.GetNames<INewFileOpener>();
            if (pluginNames.Length > 0)
                dropdown.Items.Add(new ToolStripSeparator() { Name = "8:12" });
            var plugins = from name in pluginNames
                          let plugin = PluginManager.Get<INewFileOpener>(name)
                          orderby plugin.FileTypeName ascending
                          select plugin;
            foreach (var plugin in plugins)
            {
                ToolStripMenuItem item = new ToolStripMenuItem(plugin.FileTypeName) { Name = "8:12" };
                item.Image = plugin.FileIcon;
                item.Click += (s, ea) =>
                {
                    DocumentView view = plugin.New();
                    if (view != null)
                        AddDocument(view);
                };
                dropdown.Items.Add(item);
            }
        }

        internal void menuNew_DropDownClosed(object sender, EventArgs e)
        {
            ToolStripDropDown dropdown = ((ToolStripDropDownItem) sender).DropDown;

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
            NewProjectForm npf = new NewProjectForm() { RootFolder = rootPath };

            var starter = PluginManager.Get<IStarter>(Core.Settings.Engine);
            var compiler = PluginManager.Get<ICompiler>(Core.Settings.Compiler);
            if (starter == null || compiler == null)
            {
                MessageBox.Show(
                    "Unable to create a new Sphere Studio project.\n\nDefault engine and/or compiler plugins have not yet been selected.  Please open Configuration Manager and select a default engine and compiler plugin, then try again.",
                    "Operation Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (npf.ShowDialog() == DialogResult.OK)
            {
                if (!CloseCurrentProject()) return;
                if (BuildEngine.Prep(npf.NewProject))
                {
                    npf.NewProject.Save();
                    OpenProject(npf.NewProject.FileName, false);
                    _startPage.PopulateGameList();
                }
                else
                {
                    Directory.Delete(npf.NewProject.RootPath, true);
                }
            }
        }

        private void menuOpen_Click(object sender, EventArgs e)
        {
            string[] fileNames = GetFilesToOpen(false);
            if (fileNames == null) return;
            OpenFile(fileNames[0]);
        }

        private void menuOpenProject_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog projDiag = new OpenFileDialog())
            {
                projDiag.Title = @"Open Project";
                projDiag.Filter = @"All Supported Projects|*.ssproj;game.sgm|Sphere Studio Projects|*.ssproj|Sphere 1.x Game Manifest|game.sgm";
                projDiag.InitialDirectory = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    "Sphere Studio", "Projects");

                if (projDiag.ShowDialog() == DialogResult.OK)
                    OpenProject(projDiag.FileName);
            }
        }

        private void menuOpenLastProject_Click(object sender, EventArgs e)
        {
            if (File.Exists(Core.Settings.LastProject))
                OpenProject(Core.Settings.LastProject, false);
            else
                UpdateControls();
        }

        private void menuSave_Click(object sender, EventArgs e)
        {
            string savePath = IsProjectOpen ? Core.Project.RootPath : null;
            if (_activeTab != null)
                _activeTab.Save(savePath);
        }

        private void menuSaveAs_Click(object sender, EventArgs e)
        {
            string savePath = IsProjectOpen ? Core.Project.RootPath : null;
            if (_activeTab != null)
                _activeTab.SaveAs(savePath);
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
            var panelNames = from name in PluginManager.GetNames<IDockPane>()
                             let plugin = PluginManager.Get<IDockPane>(name)
                             where plugin.ShowInViewMenu
                             select name;
            if (panelNames.Any())
            {
                ToolStripSeparator ts = new ToolStripSeparator { Name = "zz_v" };
                menuView.DropDownItems.Add(ts);
                foreach (string title in panelNames)
                {
                    var plugin = PluginManager.Get<IDockPane>(title);
                    ToolStripMenuItem item = new ToolStripMenuItem(title) { Name = "zz_v" };
                    item.Image = plugin.DockIcon;
                    item.Checked = _dock.IsVisible(plugin);
                    item.Click += (o, ev) => _dock.Toggle(plugin);
                    menuView.DropDownItems.Add(item);
                }
            }

            menuStartPage.Checked = _activeTab == _startTab;
            var tabList = from tab in _tabs where tab != _startTab
                          select tab;
            if (tabList.Count() > 0)
            {
                ToolStripSeparator ts = new ToolStripSeparator { Name = "zz_v" };
                menuView.DropDownItems.Add(ts);
                foreach (DocumentTab tab in tabList)
                {
                    ToolStripMenuItem item = new ToolStripMenuItem(tab.Title) { Name = "zz_v" };
                    item.Click += menuDocumentItem_Click;
                    item.Image = tab.View.Icon.ToBitmap();
                    item.Tag = tab.FileName;
                    item.Checked = tab == _activeTab;
                    menuView.DropDownItems.Add(item);
                }
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
            DocumentTab tab = GetDocument(((ToolStripItem) sender).Tag as string);
            if (tab != null)
                tab.Activate();
            else
                SelectDockPane((string) ((ToolStripMenuItem) sender).Tag);
        }

        private void menuClosePane_Click(object sender, EventArgs e)
        {
            if (MainDock.ActiveDocument == null) return;

            if (MainDock.ActiveDocument is DockContent &&
                ((DockContent) MainDock.ActiveDocument).Controls[0] is StartPageView)
            {
                menuStartPage_Click(null, EventArgs.Empty);
            }
            else MainDock.ActiveDocument.DockHandler.Close();
        }

        private void menuStartPage_Click(object sender, EventArgs e)
        {
            StartVisible = true;
            _startTab.Activate();
        }
        #endregion

        #region Project menu Click handlers
        private void menuGameSettings_Click(object sender, EventArgs e)
        {
            OpenProjectProps();
        }

        private void menuOpenGameDir_Click(object sender, EventArgs e)
        {
            string path = Core.Project.RootPath;
            var proc = Process.Start("explorer.exe", string.Format(@"/select, ""{0}\game.sgm""", path));
            proc.Dispose();
        }

        private async void menuTestGame_Click(object sender, EventArgs e)
        {
            if (IsProjectOpen)
            {
                menuTestGame.Enabled = toolTestGame.Enabled = false;
                menuDebug.Enabled = toolDebug.Enabled = false;

                // save all non-untitled documents
                foreach (DocumentTab tab in
                    from tab in _tabs where tab.FileName != null
                    select tab)
                {
                    tab.SaveIfDirty();
                }

                if (TestGame != null)
                    TestGame(null, EventArgs.Empty);

                await BuildEngine.Test(Core.Project);
            }

            UpdateControls();
        }

        private void menuRefreshProject_Click(object sender, EventArgs e)
        {
            RefreshProject();
        }
        #endregion

        #region Tools menu Click handlers
        private void menuConfigEngine_Click(object sender, EventArgs e)
        {
            PluginManager.Get<IStarter>(Core.Project.User.Engine)
                .Configure();
        }

        private void menuConfigManager_Click(object sender, EventArgs e)
        {
            new ConfigManager().ShowDialog(this);
            UpdateEngineList();
            UpdateControls();
        }

        private void menuEditorSettings_Click(object sender, EventArgs e)
        {
            OpenEditorSettings();
        }
        #endregion

        #region Help menu Click handlers
        private void menuAbout_Click(object sender, EventArgs e)
        {
            using (AboutBox about = new AboutBox())
            {
                about.ShowDialog();
            }
        }
        #endregion

        #region Configuration Selector handlers
        private void toolEngineCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_loadingPresets) return;

            // user selected Configure (always at bottom)
            if (toolEngineCombo.SelectedIndex == toolEngineCombo.Items.Count - 1)
            {
                menuConfigManager_Click(null, EventArgs.Empty);
                UpdateEngineList();
                return;
            }

            Core.Project.User.Engine = toolEngineCombo.Text;
            UpdateControls();
            UpdateEngineList();
        }
        #endregion

        #region Private IDE routines
        private void InitializeDocking()
        {
            _projectTree = new ProjectTree(this);
            _dock = new DockManager(MainDock);
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
                var plugins = from name in PluginManager.GetNames<IFileOpener>()
                              let plugin = PluginManager.Get<IFileOpener>(name)
                              where plugin.FileExtensions != null
                              orderby plugin.FileTypeName ascending
                              select plugin;
                foreach (IFileOpener plugin in plugins)
                {
                    StringBuilder filter = new StringBuilder();
                    foreach (string extension in plugin.FileExtensions)
                    {
                        if (filter.Length > 0) filter.Append(";");
                        filter.AppendFormat("*.{0}", extension);
                    }
                    filterString += String.Format("{0}|{1}|", plugin.FileTypeName, filter);
                }
                filterString += @"All Files|*.*";
                dialog.Filter = filterString;
                dialog.FilterIndex = plugins.Count() + 1;
                dialog.InitialDirectory = Core.Project.RootPath;
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
            _defaultActiveName = name;
        }

        private bool IsProjectOpen
        {
            get { return Core.Project != null; }
        }

        internal DocumentTab AddDocument(DocumentView view, string filepath = null, bool restoreView = false)
        {
            DocumentTab tab = new DocumentTab(this, view, filepath, restoreView);
            tab.Closed += (sender, e) => _tabs.Remove(tab);
            tab.Activate();
            _tabs.Add(tab);
            return tab;
        }

        /// <summary>
        /// Refreshes the GUI.
        /// </summary>
        private void ApplyRefresh(bool ignore_presets = false)
        {
            if (!ignore_presets)
                UpdateEngineList();

            UpdateControls();
            SuspendLayout();
            _startPage.PopulateGameList();
            UpdateMenuItems();
            Invalidate(true);
            ResumeLayout();
        }

        /// <summary>
        /// Closes all opened documents; optionally saving them as well.
        /// </summary>
        /// <param name="forceClose">If true, closes unsaved documents without prompting.</param>
        /// <returns>true if all documents were closed, false if a save prompt was canceled.</returns>
        private bool CloseAllDocuments(bool forceClose = false)
        {
            DocumentTab[] toClose = (from tab in _tabs select tab).ToArray();
            if (!forceClose)
            {
                foreach (DocumentTab tab in toClose)
                    if (!tab.PromptSave()) return false;
            }
            foreach (DocumentTab tab in toClose)
                tab.Close(true);

            StartVisible = false;
            return true;
        }

        /// <summary>
        /// Closes the current project and all open documents.
        /// </summary>
        /// <param name="forceClose">If true, closes unsaved documents without prompting.</param>
        /// <returns>'true' if the project was closed; 'false' on cancel.</returns>
        private bool CloseCurrentProject(bool forceClose = false)
        {
            if (Core.Project == null)
                return true;

            // if the debugger is active, prevent closing the project.
            if (Debugger != null)
            {
                MessageBox.Show(this,
                    "There is an active debugging session.  Please stop the debugger before closing the project or IDE.",
                    "Debugging in Progress", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // user values will be lost if we don't record them now.
            Core.Project.User.StartHidden = !StartVisible;
            Core.Project.User.Documents = _tabs
                .Where(tab => tab.FileName != null)
                .Select(tab => tab.FileName).ToArray();
            Core.Project.User.ActiveDocument = _activeTab != null
                ? _activeTab.FileName : "";

            // close all open document tabs
            if (!CloseAllDocuments(forceClose))
                return false;

            // save and unload the project
            if (Core.Project != null)
            {
                if (UnloadProject != null)
                    UnloadProject(null, EventArgs.Empty);
                Core.Project.Save();
            }

            // clear the project tree
            _projectTree.Close();
            _projectTree.ProjectName = "Project Name";
            menuOpenLastProject.Enabled = (Core.Settings.LastProject.Length > 0);

            // all clear!
            Core.Project = null;
            Text = string.Format("{0} {1} {2}", Versioning.Name, Versioning.Version,
                Environment.Is64BitProcess ? "x64" : "x86");
            UpdateEngineList();
            UpdateControls();
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
            SettingsCenter sc = new SettingsCenter();
            if (sc.ShowDialog() == DialogResult.OK)
            {
                Core.Settings.Apply();
                ApplyRefresh();
            }
        }

        private void OpenProjectProps(bool editBuild = false)
        {
            using (var form = new ProjectPropsForm(Core.Project, editBuild))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    UpdateEngineList();
                    UpdateControls();
                }
            }
        }

        private void RefreshProject()
        {
            _projectTree.Open();
            _projectTree.Refresh();
            if (Core.Project != null)
                Core.Settings.LastProject = Core.Project.FileName;
            UpdateControls();
            _projectTree.ProjectName = "Project: " + Core.Project.Name;
        }

        private void SaveAllDocuments()
        {
            foreach (DocumentTab tab in _tabs)
            {
                tab.Save();
            }
        }

        /// <summary>
        /// Selects a dock pane by tab name, this is not ideal for documents but useful for
        /// persistent panes like the project tree and plugins.
        /// </summary>
        /// <param name="name">The registered name of the dock pane to select.</param>
        private void SelectDockPane(string name)
        {
            foreach (IDockContent content in MainDock.Contents)
                if (content.DockHandler.TabText == name)
                    content.DockHandler.Activate();
        }

        private async Task StartDebugger()
        {
            foreach (DocumentTab tab in
                from tab in _tabs
                where tab.FileName != null
                select tab)
            {
                tab.SaveIfDirty();
            }
            menuTestGame.Enabled = toolTestGame.Enabled = false;
            menuDebug.Enabled = toolDebug.Enabled = false;

            if (TestGame != null)
                TestGame(null, EventArgs.Empty);

            Debugger = await BuildEngine.Debug(Core.Project);
            if (Debugger != null)
            {
                Debugger.Detached += debugger_Detached;
                Debugger.Paused += debugger_Paused;
                Debugger.Resumed += debugger_Resumed;
                menuTestGame.Enabled = false;
                toolTestGame.Enabled = false;
                _isFirstDebugStop = true;
                if (await Debugger.Attach())
                {
                    menuDebug.Text = "&Resume";
                    toolDebug.Text = "Resume";
                    var breaks = Core.Project.GetAllBreakpoints();
                    foreach (string filename in breaks.Keys)
                        foreach (int lineNumber in breaks[filename])
                            await Debugger.SetBreakpoint(filename, lineNumber);
                    await Debugger.Resume();
                }
                else
                {
                    Activate();
                    MessageBox.Show("Sphere Studio failed to start a debugging session.", "Unable to Start Debugging",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Debugger = null;
                    UpdateControls();
                }
            }
            
            UpdateControls();
        }

        private void UpdateControls()
        {
            var starter = IsProjectOpen
                ? PluginManager.Get<IStarter>(Core.Project.User.Engine)
                : null;
            bool haveConfig = starter != null && starter.CanConfigure;
            bool haveLastProject = !string.IsNullOrEmpty(Core.Settings.LastProject);

            toolConfigEngine.Enabled = menuConfigEngine.Enabled = haveConfig;

            menuBuildPackage.Enabled = Core.Project != null
                && BuildEngine.CanPackage(Core.Project);

            menuTestGame.Enabled = toolTestGame.Enabled = Core.Project != null
                && BuildEngine.CanTest(Core.Project) && Debugger == null;
            menuDebug.Enabled = toolDebug.Enabled = Core.Project != null
                && BuildEngine.CanDebug(Core.Project)
                && (Debugger == null || !Debugger.Running);
            menuBreakNow.Enabled = toolPauseDebug.Enabled = Debugger != null && Debugger.Running;
            menuStopDebug.Enabled = toolStopDebug.Enabled = Debugger != null;
            menuStepInto.Enabled = Debugger != null && !Debugger.Running;
            menuStepOut.Enabled = Debugger != null && !Debugger.Running;
            menuStepOver.Enabled = Debugger != null && !Debugger.Running;

            menuOpenLastProject.Enabled = haveLastProject;

            menuProjectProps.Enabled = GameToolButton.Enabled = IsProjectOpen;
            menuOpenGameDir.Enabled = menuRefreshProject.Enabled = IsProjectOpen;

            SaveToolButton.Enabled = _activeTab != null && _activeTab.View.CanSave;
            CutToolButton.Enabled = _activeTab != null;
            CopyToolButton.Enabled = _activeTab != null;

            if (_dock != null) _dock.Refresh();
        }

        private void UpdateMenuItems()
        {
            foreach (ToolStripMenuItem item in MainMenuStrip.Items)
                menu_DropDownClosed(item, null);
        }

        private void UpdateEngineList()
        {
            bool wasLoadingPresets = _loadingPresets;
            _loadingPresets = true;

            toolEngineCombo.Items.Clear();
            string[] engines = PluginManager.GetNames<IStarter>();
            if (IsProjectOpen && engines.Length > 0)
            {
                foreach (string name in engines)
                    toolEngineCombo.Items.Add(name);
                toolEngineCombo.Items.Add("Configuration Manager...");
                toolEngineCombo.Text = Core.Project.User.Engine;
                toolEngineCombo.Enabled = true;
            }
            else
            {
                toolEngineCombo.Enabled = false;
            }

            _loadingPresets = wasLoadingPresets;
        }
        #endregion

        private void debugger_Detached(object sender, EventArgs e)
        {
            var scriptViews = from tab in _tabs
                              where tab.View is ScriptView
                              select tab.View;
            foreach (ScriptView view in scriptViews)
            {
                view.ActiveLine = 0;
                view.ErrorLine = 0;
            }
            Debugger = null;
            menuDebug.Text = "Start &Debugging";
            toolDebug.Text = "Debug";
            UpdateControls();
        }

        private void debugger_Paused(object sender, PausedEventArgs e)
        {
            if (_isFirstDebugStop)
            {
                // ignore first pause
                _isFirstDebugStop = false;
                return;
            }

            ScriptView view = null;
            view = OpenFile(Debugger.FileName) as ScriptView;
            if (view != null)
            {
                view.ActiveLine = Debugger.LineNumber;
                if (e.Reason == PauseReason.Exception)
                    view.ErrorLine = Debugger.LineNumber;
            }
            if (!Debugger.Running)
                Activate();
            UpdateControls();
        }

        private void debugger_Resumed(object sender, EventArgs e)
        {
            var scriptViews = from tab in _tabs
                              where tab.View is ScriptView
                              select tab.View;
            foreach (ScriptView view in scriptViews)
            {
                view.ActiveLine = 0;
                view.ErrorLine = 0;
            }
            UpdateControls();
        }

        private void menuStepInto_Click(object sender, EventArgs e)
        {
            Debugger.StepInto();
        }

        private void menuStepOut_Click(object sender, EventArgs e)
        {
            Debugger.StepOut();
        }

        private void menuStepOver_Click(object sender, EventArgs e)
        {
            Debugger.StepOver();
        }

        private async void menuDebug_Click(object sender, EventArgs e)
        {
            if (Debugger != null)
                await Debugger.Resume();
            else
                await StartDebugger();
        }

        private void debugBreakNow_Click(object sender, EventArgs e)
        {
            Debugger.Pause();
        }

        private void menuStopDebug_Click(object sender, EventArgs e)
        {
            Debugger.Detach();
        }

        private async void menuBuildPackage_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog()
            {
                Title = "Build Game Package",
                InitialDirectory = Core.Project.RootPath,
                Filter = BuildEngine.GetSaveFileFilters(Core.Project),
                DefaultExt = "spk",
                AddExtension = true,
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                await BuildEngine.Package(Core.Project, sfd.FileName);
            }
        }
    }
}