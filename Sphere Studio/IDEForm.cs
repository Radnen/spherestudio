using Sphere.Core.Editor;
using Sphere.Core.Settings;
using Sphere.Plugins;
using SphereStudio.Components;
using SphereStudio.Forms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace SphereStudio
{
    internal partial class IDEForm : Form, IIDE, IStyleable
    {
        // uninitialized data:
        private DockContent _treeContent;
        private DockContent _startContent;
        private readonly StartPage _startPage;
        private EditorObject _currentControl;
        private readonly ProjectTree _tree;
        private bool _firsttime;
        private readonly Dictionary<string, string> _openFileTypes = new Dictionary<string, string>();
        private readonly Dictionary<EditorType, IEditorPlugin> _editors = new Dictionary<EditorType, IEditorPlugin>();
        private string _default_active;
        private bool _loadingPresets = false;

        public event EventHandler LoadProject;
        public event EventHandler TestGame;
        public event EditFileEventHandler TryEditFile;
        public event EventHandler UnloadProject;

        public IDEForm()
        {
            InitializeComponent();

            _firsttime = !Global.CurrentEditor.LoadSettings();

            _tree = new ProjectTree() { Dock = DockStyle.Fill, EditorForm = this };

            _startPage = new StartPage(this) { Dock = DockStyle.Fill, HelpLabel = HelpLabel };
            _startPage.PopulateGameList();

            NewToolButton.DropDown = NewMenuItem.DropDown;
            OpenToolButton.DropDown = OpenMenuItem.DropDown;

            InitializeDocking();

            PluginManager.IDE = this;
            Global.EvalPlugins();
            Global.ActivatePlugins(Global.CurrentEditor.GetArray("plugins"));

            SuspendLayout();
            StyleSettings.CurrentStyle = Global.CurrentEditor.Style;
            UpdateStyle();
            Invalidate(true);
            ResumeLayout();

            if (Global.CurrentEditor.AutoOpen)
                OpenLastProject(null, EventArgs.Empty);

            // make sure this is active only when we use it.
            if (_treeContent != null) _treeContent.Activate();

            var Is64 = System.Environment.Is64BitProcess;
            Text = string.Format("{0} ({1}) - v{2}", Application.ProductName,
                (Is64) ? "x64" : "x86", Application.ProductVersion);

            TryEditFile += IDEForm_TryEditFile;
            ConfigSelectTool.SelectedIndexChanged += ConfigSelectTool_SelectedIndexChanged;
            UpdatePresetList();
        }

        private void UpdatePresetList()
        {
            bool wasLoadingPresets = _loadingPresets;
            _loadingPresets = true;
            
            ConfigSelectTool.Items.Clear();
            ConfigSelectTool.Items.Add("[Select a Preset]");
            ConfigSelectTool.SelectedIndex = 0;

            string sphereDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Sphere Studio");
            string path = Path.Combine(sphereDir, @"Presets");
            if (Directory.Exists(path))
            {
                string[] presetFiles = Directory.GetFiles(path, "*.preset");
                foreach (string s in presetFiles)
                {
                    ConfigSelectTool.Items.Add(Path.GetFileNameWithoutExtension(s));
                }
                ConfigSelectTool.SelectedItem = Global.CurrentEditor.LastPreset;
            }
            ConfigSelectTool.Items.Add("Settings Manager...");

            _loadingPresets = wasLoadingPresets;
        }

        void IDEForm_TryEditFile(object sender, EditFileEventArgs e)
        {
            if (e.Extension == ".sgm")
            {
                OpenGameSettings();
                e.Handled = true;
            }
        }

        public override sealed string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        bool IsProjectOpen { get { return Global.CurrentProject != null; } }

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

        internal void OpenDocument(string filePath)
        {
            // raise a TryEditFile event first to see if any plugins take the bait
            EditFileEventArgs e = new EditFileEventArgs(filePath);
            if (TryEditFile != null) TryEditFile(null, e);

            // if someone took the bait, then we don't have to do anything else
            if (e.Handled) return;

            // nothing huh? try fishing for plugins again, maybe we were using the
            // wrong lure... fish like stars right? (i.e. try wildcard extension "*")
            e = new EditFileEventArgs(filePath, true);
            if (TryEditFile != null) TryEditFile(null, e);
            if (!e.Handled)
            {
                string extension = Path.GetExtension(filePath);
                if (extension == null) return;
                MessageBox.Show(String.Format("Sphere Studio doesn't know how to open that type of file.\n\n\nFile Type: {0}\n\nPath to File:\n{1}", extension.ToUpper(), filePath),
                                @"Unable to Open File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateButtons()
        {
            bool config = File.Exists(Global.CurrentEditor.ConfigPath);
            OptionsToolButton.Enabled = ConfigureSphereMenuItem.Enabled = config;

            bool sphereFound = File.Exists(Global.CurrentEditor.SpherePath)
                || File.Exists(Global.CurrentEditor.Sphere64Path);
            RunToolButton.Enabled = TestGameMenuItem.Enabled = sphereFound;

            bool last = !string.IsNullOrEmpty(Global.CurrentEditor.LastProjectPath);
            OpenLastProjectMenuItem.Enabled = last;

            GameSettingsMenuItem.Enabled = GameToolButton.Enabled = IsProjectOpen;
            OpenDirectoryMenuItem.Enabled = RefreshMenuItem.Enabled = IsProjectOpen;

            SaveToolButton.Enabled = _currentControl != null;
            CutToolButton.Enabled = _currentControl != null;
            CopyToolButton.Enabled = _currentControl != null;

        }

        #region interfaces
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
            if (EditorSettings.UseStartPage) _startContent.Show(MainDock, DockState.Document);
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

            if (description.Control is EditorObject)
            {
                // adds an event to find dirtied forms and notifies the user.
                ctrl.FormClosing += Content_FormClosing;

                ((EditorObject)description.Control).OnTabTextChange += new EventHandler<string>(delegate(object o, string e)
                {
                    ctrl.Text = e;
                });
            }

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

        public string[] Documents
        {
            get
            {
                List<string> strings = new List<string>();
                foreach (DockContent dc in MainDock.Contents)
                {
                    strings.Add(dc.TabText);
                }
                return strings.ToArray();
            }
        }

        public void RemoveControl(string name)
        {
            DockContent c = FindDocument(name);
            if (c != null) c.DockHandler.Close();
        }

        public EditorObject CurrentDocument
        {
            get { return _currentControl; }
        }

        public ProjectSettings CurrentGame
        {
            get { return Global.CurrentProject; }
        }

        public SphereSettings EditorSettings
        {
            get { return Global.CurrentEditor; }
        }

        // used for supplying an entirely new menu and it's children
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

        private ToolStripMenuItem GetMenuItem(ToolStripItemCollection collection, string name)
        {
            return collection.OfType<ToolStripMenuItem>().FirstOrDefault(item => item.Text.Replace("&", "") == name);
        }

        // used for adding children to existing menus
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

        public void RegisterOpenFileType(string typeName, string filters)
        {
            _openFileTypes[filters] = typeName;
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

        public void UnregisterOpenFileType(string filters)
        {
            if (!_openFileTypes.ContainsKey(filters)) return;
            _openFileTypes.Remove(filters);
        }
        #endregion

        private void EditorForm_Shown(object sender, EventArgs e)
        {
            if (_firsttime)
            {
                MessageBox.Show(@"Hello! It's your first time here! I would love to help you " +
                                @"set a few things up!", @"Welcome First Timer", MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                OpenEditorSettings(this, null);
                _firsttime = false;
            }

            if (!String.IsNullOrWhiteSpace(_default_active))
            {
                var doc = GetDocument(_default_active);
                if (doc != null) doc.DockHandler.Activate();
            }
        }

        /// <summary>
        /// Opens a Sphere project for editor use.
        /// </summary>
        /// <param name="filename">The filename of the project.</param>
        public void OpenProject(string filename)
        {
            if (string.IsNullOrEmpty(filename)) return;
            CloseProject(null, EventArgs.Empty);
            Global.CurrentProject = new ProjectSettings();
            Global.CurrentProject.LoadSettings(filename);
            RefreshProject();
            if (LoadProject != null) LoadProject(null, EventArgs.Empty);
            if (_treeContent != null) _treeContent.Activate();
            HelpLabel.Text = @"Game project loaded successfully!";
            UpdateButtons();
        }

        // Loads and adds a new document to the editor.
        private void LoadDocument(Control control, string path)
        {
            AddDocument(control, Path.GetFileName(path));
            if (_currentControl != null) _currentControl.LoadFile(path);
        }

        // adds a new document to the form.
        #region document addition handling
        private void AddNewDocument(Control control, string name)
        {
            AddDocument(control, name);
            if (_currentControl != null) _currentControl.CreateNew();
        }

        private void AddDocument(Control control, string text)
        {
            DockContent content;
            control.Dock = DockStyle.Fill;
            content = new DockContent();
            content.Controls.Add(control);
            if (MainDock.DocumentsCount == 0) content.Show(MainDock, DockState.Document);
            else content.Show(MainDock.Panes[0], null);
            content.DockState = DockState.Document;
            content.DockAreas = DockAreas.Document;
            content.Text = text;
            content.FormClosing += Content_FormClosing;

            SetCurrentControl(control);

            if (text == "Sphere") { content.AllowEndUserDocking = false; }
            else
                content.Icon = Icon.FromHandle(Properties.Resources.page_white_edit.GetHicon());

            if (_currentControl != null) _currentControl.HelpLabel = HelpLabel;
        }
        #endregion

        // used to process modified forms when closing:
        void Content_FormClosing(object sender, FormClosingEventArgs e)
        {
            DockContent obj = (DockContent)sender;
            if (obj.Text.EndsWith("*"))
            {
                switch (MessageBox.Show(@"File has been modified, save?", obj.Text,
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button3))
                {
                    case DialogResult.Yes:
                        SaveMenuItem_Click(null, EventArgs.Empty);
                        break;
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                }
            }

            if (!e.Cancel) obj.Dispose();
        }

        /// <summary>
        /// Searches any EditorObject controls in the dock contents for a file.
        /// </summary>
        /// <param name="filepath">The name to search against.</param>
        /// <returns>null if none found, or the IDockContent.</returns>
        public IDockContent GetDocument(string filepath)
        {
            foreach (IDockContent content in MainDock.Contents)
            {
                Form form = content.DockHandler.Form;
                if (form.Controls.Count <= 0 || !(form.Controls[0] is EditorObject)) continue;
                if (((EditorObject)form.Controls[0]).FileName == filepath) return content;
            }
            return null;
        }

        private DockContent FindDocument(string name)
        {
            return MainDock.Contents.Cast<DockContent>().FirstOrDefault(content => content.DockHandler.TabText == name);
        }

        /// <summary>
        /// Selects a document by tab name, this is not ideal for editors but useful for
        /// persistent objects like the project tree and plugins.
        /// </summary>
        /// <param name="name">The content's tab text to look for.</param>
        public void SelectDocument(string name)
        {
            foreach (IDockContent content in MainDock.Contents)
                if (content.DockHandler.TabText == name)
                    content.DockHandler.Activate();
        }

        /// <summary>
        /// Calls the restyle method on all loaded editors.
        /// </summary>
        public void RestyleEditors()
        {
            foreach (DockContent dc in MainDock.Contents)
                if (dc.Controls.Count > 0 && dc.Controls[0] is EditorObject)
                    ((EditorObject)dc.Controls[0]).Restyle();
        }

        /// <summary>
        /// Sets the default active document when the editor first starts up.
        /// Used internally when dragging a file onto the executable.
        /// </summary>
        /// <param name="name">File path of the document to set.</param>
        public void SetDefaultActive(string name)
        {
            _default_active = name;
        }

        private void SaveAllDocuments()
        {
            foreach (IDockContent content in MainDock.Contents)
            {
                Form f = content.DockHandler.Form;
                if (f.Controls.Count > 0 && f.Controls[0] is EditorObject)
                    ((EditorObject)content.DockHandler.Form.Controls[0]).Save();
            }
        }

        #region file menu options
        private void FileMenu_DropDownOpened(object sender, EventArgs e)
        {
            SaveAsMenuItem.Enabled = SaveMenuItem.Enabled = (_currentControl != null);
            CloseProjectMenuItem.Enabled = IsProjectOpen;
            OpenLastProjectMenuItem.Enabled = (!IsProjectOpen ||
                Global.CurrentEditor.LastProjectPath != Global.CurrentProject.RootPath);
        }

        public void CallNewProject(object sender, EventArgs e)
        {
            string[] paths = Global.CurrentEditor.GetArray("games_path");
            string sphereDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Sphere Studio");
            string rootPath = Path.Combine(sphereDir, "Projects");
            Directory.CreateDirectory(rootPath);
            NewProjectForm myProject = new NewProjectForm { RootFolder = rootPath };

            if (myProject.ShowDialog() == DialogResult.OK)
            {
                CloseProject(null, EventArgs.Empty);

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

                RefreshProject(null, EventArgs.Empty);
                _startPage.PopulateGameList();
                OpenDocument(Global.CurrentProject.RootPath + "\\scripts\\main.js");
            }
        }

        private void OpenProjectMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog projDiag = new OpenFileDialog())
            {
                projDiag.Title = @"Open Project";
                projDiag.Filter = @"Game Files|*.sgm|All Files|*.*";

                string[] paths = Global.CurrentEditor.GetArray("games_paths");
                if (paths.Length > 0)
                    projDiag.InitialDirectory = paths[0];

                if (projDiag.ShowDialog() == DialogResult.OK)
                    OpenProject(projDiag.FileName);
            }
        }

        // remember to clear opened tabs!
        private void CloseProject(object sender, EventArgs e)
        {
            if (UnloadProject != null) UnloadProject(null, EventArgs.Empty);
            _tree.Close();
            Global.CurrentProject = null;
            _tree.ProjectName = "Project Name";
            OpenLastProjectMenuItem.Enabled = (Global.CurrentEditor.LastProjectPath.Length > 0);
            UpdateButtons();
        }

        private void OpenLastProject(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Global.CurrentEditor.LastProjectPath) &&
                Directory.Exists(Global.CurrentEditor.LastProjectPath))
            {
                OpenProject(Global.CurrentEditor.LastProjectPath + "\\game.sgm");
            }
            else UpdateButtons();
        }

        private void SaveMenuItem_Click(object sender, EventArgs e)
        {
            if (_currentControl != null) _currentControl.Save();
        }

        private void SaveAsMenuItem_Click(object sender, EventArgs e)
        {
            if (_currentControl != null) _currentControl.SaveAs();
        }

        private void SaveOpenedItem_Click(object sender, EventArgs e)
        {
            SaveAllDocuments();
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region open sub-menu items

        #endregion

        #region edit items
        private void PasteMenuItem_Click(object sender, EventArgs e)
        {
            if (_currentControl != null) _currentControl.Paste();
        }

        private void CopyMenuItem_Click(object sender, EventArgs e)
        {
            if (_currentControl != null) _currentControl.Copy();
        }

        private void CutMenuItem_Click(object sender, EventArgs e)
        {
            if (_currentControl != null) _currentControl.Cut();
        }

        private void EditMenu_DropDownOpening(object sender, EventArgs e)
        {
            CutMenuItem.Enabled = SelectAllMenuItem.Enabled = _currentControl is IScriptEditor;
            CopyToolButton.Enabled = CopyMenuItem.Enabled = RedoMenuItem.Enabled = UndoMenuItem.Enabled = _currentControl != null;
            SaveLayoutMenuItem.Enabled = CutMenuItem.Enabled = CutToolButton.Enabled = _currentControl != null;
            PasteMenuItem.Enabled = PasteToolButton.Enabled = true;
            ZoomInMenuItem.Enabled = ZoomOutMenuItem.Enabled = !(_currentControl is IScriptEditor);
            item_DropDownOpening(sender, e);
        }

        private void SelectAllMenuItem_Click(object sender, EventArgs e)
        {
            if (_currentControl != null) _currentControl.SelectAll();
        }

        private void UndoMenuItem_Click(object sender, EventArgs e)
        {
            if (_currentControl != null) _currentControl.Undo();
        }

        private void RedoMenuItem_Click(object sender, EventArgs e)
        {
            if (_currentControl != null) _currentControl.Redo();
        }

        private void ZoomInMenuItem_Click(object sender, EventArgs e)
        {
            if (_currentControl != null) _currentControl.ZoomIn();
        }

        private void ZoomOutMenuItem_Click(object sender, EventArgs e)
        {
            if (_currentControl != null) _currentControl.ZoomOut();
        }
        #endregion

        #region project menu items
        private void OptionsToolButton_Click(object sender, EventArgs e)
        {
            string path = Path.GetDirectoryName(Global.CurrentEditor.ConfigPath);
            if (path != null) Directory.SetCurrentDirectory(path);
            if (File.Exists(Global.CurrentEditor.ConfigPath))
                Process.Start(Global.CurrentEditor.ConfigPath);
            Directory.SetCurrentDirectory(Application.StartupPath);
        }

        private void OpenEditorSettings(object sender, EventArgs e)
        {
            OpenEditorSettings();
        }

        private void ViewGameSettings(object sender, EventArgs e)
        {
            OpenGameSettings();
        }

        public void ApplyRefresh(bool ignore_presets = false)
        {
            if (!ignore_presets)
                UpdatePresetList();

            UpdateButtons();
            SuspendLayout();
            _startPage.PopulateGameList();
            UpdateMenuItems();
            StyleSettings.CurrentStyle = Global.CurrentEditor.Style;
            UpdateStyle();
            Invalidate(true);
            ResumeLayout();
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

        private void OpenDirectoryMenuItem_Click(object sender, EventArgs e)
        {
            string path = Global.CurrentProject.RootPath;
            var proc = Process.Start("explorer.exe", string.Format("/select, \"{0}\\game.sgm\"", path));
            proc.Dispose();
        }

        private void RunToolButton_Click(object sender, EventArgs e)
        {
            if (!File.Exists(Global.CurrentEditor.SpherePath)
                && !File.Exists(Global.CurrentEditor.Sphere64Path))
            {
                return;
            }

            if (TestGame != null) TestGame(null, EventArgs.Empty);

            if (IsProjectOpen)
            {
                Global.CurrentProject.SaveSettings();
                string args = string.Format("-game \"{0}\"", Global.CurrentProject.RootPath);
                string enginePath = File.Exists(Global.CurrentEditor.Sphere64Path) && System.Environment.Is64BitOperatingSystem
                    ? Global.CurrentEditor.Sphere64Path
                    : Global.CurrentEditor.SpherePath;
                Process.Start(enginePath, args);
            }
            else
                Process.Start(Global.CurrentEditor.SpherePath);
        }

        public void RefreshProject()
        {
            _tree.Open();
            _tree.Refresh();
            if (Global.CurrentProject.RootPath != null)
                Global.CurrentEditor.LastProjectPath = Global.CurrentProject.RootPath;
            Global.CurrentEditor.SaveSettings();
            UpdateButtons();
            _tree.ProjectName = "Project: " + Global.CurrentProject.Name;
        }

        private void RefreshProject(object sender, EventArgs e)
        {
            RefreshProject();
        }
        #endregion

        #region view menu items
        private void StartPageMenuItem_Click(object sender, EventArgs e)
        {
            if (_startContent.IsHidden) _startContent.Show(MainDock);
            else _startContent.Hide();
        }

        private void ProjectExplorerMenuItem_Click(object sender, EventArgs e)
        {
            if (_treeContent.IsHidden) _treeContent.Show(MainDock, DockState.DockLeft);
            else _treeContent.Hide();
        }
        #endregion

        #region help items
        private void AboutMenuItem_Click(object sender, EventArgs e)
        {
            using (AboutSphereEditor about = new AboutSphereEditor())
            {
                about.ShowDialog();
            }
        }
        #endregion

        private void SetCurrentControl(Control value)
        {
            if (_currentControl != null) _currentControl.Deactivate();

            _currentControl = (value is EditorObject) ? (EditorObject)value : null;

            if (_currentControl != null) _currentControl.Activate();
        }

        private void DockTest_ActiveDocumentChanged(object sender, EventArgs e)
        {
            if (MainDock.ActiveDocument == null) return;
            Form form = MainDock.ActiveDocument.DockHandler.Form;
            if (form.Controls.Count == 0) return;
            SetCurrentControl(form.Controls[0]);
            UpdateButtons();
        }

        private void EditorForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Global.CurrentEditor.SaveSettings();
            CloseProject(null, EventArgs.Empty);
        }

        private void SaveLayoutMenuItem_Click(object sender, EventArgs e)
        {
            if (_currentControl != null) _currentControl.SaveLayout();
        }

        private void ViewMenu_DropDownOpening(object sender, EventArgs e)
        {
            if (MainDock.Contents.Count == 0) return;
            ToolStripSeparator ts = new ToolStripSeparator { Name = "zz_v" };
            ViewMenu.DropDownItems.Add(ts);
            foreach (IDockContent content in MainDock.Contents)
            {
                Form f = content.DockHandler.Form;
                ToolStripMenuItem item = new ToolStripMenuItem(content.DockHandler.TabText) { Name = "zz_v" };
                item.Click += ViewItem_Click;

                if (f.Controls.Count > 0 && f.Controls[0] is EditorObject)
                    item.Tag = ((EditorObject)f.Controls[0]).FileName;
                else
                    item.Tag = content.DockHandler.TabText;

                if (content.DockHandler.IsActivated) item.CheckState = CheckState.Checked;
                ViewMenu.DropDownItems.Add(item);
            }
            item_DropDownOpening(sender, e);
        }

        void ViewItem_Click(object sender, EventArgs e)
        {
            IDockContent content = GetDocument((string)((ToolStripItem)sender).Tag);
            if (content != null) content.DockHandler.Activate();
            else SelectDocument((string)((ToolStripMenuItem)sender).Tag);
        }

        private void ViewMenu_DropDownClosed(object sender, EventArgs e)
        {
            for (int i = 0; i < ViewMenu.DropDownItems.Count; ++i)
            {
                if (ViewMenu.DropDownItems[i].Name == "zz_v")
                {
                    ViewMenu.DropDownItems.RemoveAt(i);
                    i--;
                }
            }
            item_DropDownClosed(sender, e);
        }

        private void ClosePaneItem_Click(object sender, EventArgs e)
        {
            if (MainDock.ActiveDocument == null) return;

            if (MainDock.ActiveDocument is DockContent &&
                ((DockContent)MainDock.ActiveDocument).Controls[0] is StartPage)
            {
                StartPageMenuItem_Click(null, EventArgs.Empty);
            }
            else MainDock.ActiveDocument.DockHandler.Close();
        }

        private void OpenMenuItem_Click(object sender, EventArgs e)
        {
            string[] fileNames = GetFilesToOpen(false);
            if (fileNames == null) return;
            OpenDocument(fileNames[0]);
        }

        private void ApiDocsMenuItem_Click(object sender, EventArgs e)
        {
            OpenDocument(Path.Combine(Application.StartupPath, "Docs/api.txt"));
        }

        public void UpdateStyle()
        {
            StyleSettings.ApplyStyle(MainMenuStrip);
            StyleSettings.ApplyStyle(EditorTools);
            StyleSettings.ApplyStyle(EditorStatus);
            UpdateMenuItems();
        }

        // Needed to make sure menu items are visible on a variety of
        // color themes. Eg, White text on a white theme = unreadable.
        private void CreateRootMenuItem(ToolStripMenuItem item)
        {
            item.DropDownOpening += item_DropDownOpening;
            item.DropDownClosed += item_DropDownClosed;
        }

        private void RemoveRootMenuItem(ToolStripMenuItem item)
        {
            item.DropDownOpening -= item_DropDownOpening;
            item.DropDownClosed -= item_DropDownClosed;
        }

        private void UpdateMenuItems()
        {
            foreach (ToolStripMenuItem item in MainMenuStrip.Items)
                item_DropDownClosed(item, null);
        }

        void item_DropDownClosed(object sender, EventArgs e)
        {
            Color c = MainMenuStrip.BackColor;
            if (c.R + c.G + c.B > 380) // find contrast level.
                ((ToolStripMenuItem)sender).ForeColor = Color.Black;
            else
                ((ToolStripMenuItem)sender).ForeColor = Color.White;
        }

        void item_DropDownOpening(object sender, EventArgs e)
        {
            Color c = ((ToolStripMenuItem)sender).DropDown.BackColor;
            if (c.R + c.G + c.B > 380)
                ((ToolStripMenuItem)sender).ForeColor = Color.Black;
            else
                ((ToolStripMenuItem)sender).ForeColor = Color.White;
        }

        private void ConfigSelectTool_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_loadingPresets) return;
            
            // open settings if Settings Manager selected, ignore cue banner item
            if (ConfigSelectTool.SelectedIndex == 0 || ConfigSelectTool.SelectedIndex == ConfigSelectTool.Items.Count - 1)
            {
                if (ConfigSelectTool.SelectedIndex != 0)
                    OpenEditorSettings();
                UpdatePresetList();
                return;
            }

            string sphereDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Sphere Studio");
            string path = Path.Combine(sphereDir, @"Presets", (string)ConfigSelectTool.SelectedItem + ".preset");
            Global.CurrentEditor.LoadSettings(path);
            Global.CurrentEditor.LastPreset = ConfigSelectTool.Text;
            Global.CurrentEditor.LastProjectPath = Global.CurrentProject != null ? Global.CurrentProject.RootPath : "";

            var plugins = new List<string>(Global.CurrentEditor.GetArray("plugins"));
            foreach (var plugin in Global.Plugins)
            {
                if (plugins.Contains(plugin.Key))
                    plugin.Value.Activate();
                else
                    plugin.Value.Deactivate();
            }

            Global.CurrentEditor.SaveSettings();
            ApplyRefresh(true);

            _loadingPresets = false;
        }
    }
}