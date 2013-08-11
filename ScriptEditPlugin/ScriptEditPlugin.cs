using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Sphere.Core.Editor;
using Sphere.Plugins;
using WeifenLuo.WinFormsUI.Docking;

namespace ScriptEditPlugin
{
    public class ScriptEditPlugin : IEditorPlugin
    {
        public string Name { get { return "Script Editor"; } }
        public string Author { get { return "Radnen"; } }
        public string Description { get { return "Sphere Studio default script editor"; } }
        public string Version { get { return "1.1.6.0"; } }
        public Icon Icon { get; private set; }

        private readonly List<string> _extensionList = new List<string>(new[] { ".js", ".txt", ".log", ".md", ".sgm", ".gitignore", ".ini", ".sav" });
        private const string _openFileFilters = "*.js;*.txt;*.log;*.md;*.sgm;*.ini;*.sav";

        readonly ToolStripMenuItem _rootMenu, _indentMenu, _newScriptItem;
        readonly ToolStripMenuItem _autoCompleteItem, _codeFoldItem;
        readonly ToolStripMenuItem _highlightLineItem, _highlightBracesItem;
        readonly ToolStripMenuItem _useTabsItem, _changeFontItem;
        readonly ToolStripMenuItem _twoUnitItem, _fourUnitItem, _eightUnitItem;
        readonly ToolStripItem _separator1, _separator2;

        public ScriptEditPlugin()
        {
            Icon = Icon.FromHandle(Properties.Resources.script_edit.GetHicon());

            #region menu items
            _autoCompleteItem = new ToolStripMenuItem("Auto Complete") {CheckOnClick = true};
            _autoCompleteItem.Click += AutoCompleteItem_Click;

            _codeFoldItem = new ToolStripMenuItem("Code Folding") {CheckOnClick = true};
            _codeFoldItem.Click += CodeFoldItem_Click;

            _highlightLineItem = new ToolStripMenuItem("Highlight Current Line") {CheckOnClick = true};
            _highlightLineItem.Click += HighlightLineItem_Click;

            _highlightBracesItem = new ToolStripMenuItem("Highlight Braces") {CheckOnClick = true};
            _highlightBracesItem.Click += HighlightBracesItem_Click;

            _separator1 = new ToolStripSeparator();
            _separator2 = new ToolStripSeparator();

            _useTabsItem = new ToolStripMenuItem("Use Tabs") {CheckOnClick = true};
            _useTabsItem.Click += UseTabsItem_Click;

            _twoUnitItem = new ToolStripMenuItem("2 units");
            _twoUnitItem.Click += TwoUnitItem_Click;

            _fourUnitItem = new ToolStripMenuItem("4 units");
            _fourUnitItem.Click += FourUnitItem_Click;

            _eightUnitItem = new ToolStripMenuItem("8 units");
            _eightUnitItem.Click += EightUnitItem_Click;

            _changeFontItem = new ToolStripMenuItem("Change Font...", Properties.Resources.style);
            _changeFontItem.Click += ChangeFontItem_Click;
            _changeFontItem.Enabled = false;

            _rootMenu = new ToolStripMenuItem("&Script");
            _rootMenu.DropDownItems.Add(_autoCompleteItem);
            _rootMenu.DropDownItems.Add(_codeFoldItem);
            _rootMenu.DropDownItems.Add(_highlightLineItem);
            _rootMenu.DropDownItems.Add(_highlightBracesItem);
            _rootMenu.DropDownItems.Add(_separator1);

            _indentMenu = new ToolStripMenuItem("Indentation");
            _indentMenu.DropDownItems.Add(_useTabsItem);
            _indentMenu.DropDown.Items.Add(_separator2);
            _indentMenu.DropDown.Items.Add(_twoUnitItem);
            _indentMenu.DropDown.Items.Add(_fourUnitItem);
            _indentMenu.DropDown.Items.Add(_eightUnitItem);

            _rootMenu.DropDownItems.Add(_indentMenu);
            _rootMenu.DropDownItems.Add(_changeFontItem);
            _rootMenu.Visible = false;

            _newScriptItem = new ToolStripMenuItem("Script", Properties.Resources.script_edit);
            _newScriptItem.Click += NewScriptItem_Click;
            #endregion
        }

        public void Initialize()
        {
            LoadFunctions();

            // register this plugin as a script editor
            PluginManager.RegisterEditor(EditorType.Script, this);
            
            // register event handlers
            PluginManager.IDE.TryEditFile += IDE_TryEditFile;

            // register Open dialog file types
            PluginManager.IDE.RegisterOpenFileType("Script/Text Files", _openFileFilters);

            // Show the root menu for this control; appearing before the 'View' menu.
            PluginManager.IDE.AddMenuItem(_rootMenu, "View");
            PluginManager.IDE.AddMenuItem("File.New", _newScriptItem);

            _autoCompleteItem.Checked = PluginManager.IDE.EditorSettings.GetBool("script-autocomplete", true);
            _codeFoldItem.Checked = PluginManager.IDE.EditorSettings.GetBool("script-fold", true);
            _highlightLineItem.Checked = PluginManager.IDE.EditorSettings.GetBool("script-hiline", true);
            _highlightBracesItem.Checked = PluginManager.IDE.EditorSettings.GetBool("script-hibraces", true);
            _useTabsItem.Checked = PluginManager.IDE.EditorSettings.GetBool("script-tabs", true);

            int spaces = PluginManager.IDE.EditorSettings.GetInt("script-spaces", 2);
            _twoUnitItem.Checked = spaces == 2;
            _fourUnitItem.Checked = spaces == 4;
            _eightUnitItem.Checked = spaces == 8;
        }

        public void Destroy()
        {
            PluginManager.UnregisterEditor(this);
            PluginManager.IDE.UnregisterOpenFileType(_openFileFilters);
            Functions.Clear();
            PluginManager.IDE.RemoveMenuItem("Script");
            PluginManager.IDE.TryEditFile -= IDE_TryEditFile;
        }

        public EditorObject CreateEditControl()
        {
            return new ScriptEditor();
        }

        private void IDE_TryEditFile(object sender, EditFileEventArgs e)
        {
            if (e.Handled) return;
            if (_extensionList.Contains(e.Extension.ToLowerInvariant()))
            {
                PluginManager.IDE.DockControl(OpenEditor(e.Path), DockState.Document);
                e.Handled = true;
            }
        }

        void NewScriptItem_Click(object sender, EventArgs e)
        {
            PluginManager.IDE.DockControl(OpenEditor(), DockState.Document);
        }

        void EightUnitItem_Click(object sender, EventArgs e)
        {
            _eightUnitItem.Checked = true;
            _twoUnitItem.Checked = _fourUnitItem.Checked = false;
            PluginManager.IDE.EditorSettings.SaveObject("script-spaces", 8);
            UpdateScriptControls();
        }

        void FourUnitItem_Click(object sender, EventArgs e)
        {
            _fourUnitItem.Checked = true;
            _twoUnitItem.Checked = _eightUnitItem.Checked = false;
            PluginManager.IDE.EditorSettings.SaveObject("script-spaces", 4);
            UpdateScriptControls();
        }

        void TwoUnitItem_Click(object sender, EventArgs e)
        {
            _twoUnitItem.Checked = true;
            _fourUnitItem.Checked = _eightUnitItem.Checked = false;
            PluginManager.IDE.EditorSettings.SaveObject("script-spaces", 2);
            UpdateScriptControls();
        }

        void ChangeFontItem_Click(object sender, EventArgs e)
        {
            using (FontDialog diag = new FontDialog())
            {
                TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
                string fontstring = PluginManager.IDE.EditorSettings.GetString("script-font");

                if (!String.IsNullOrEmpty(fontstring))
                    diag.Font = (Font)converter.ConvertFromString(fontstring);

                try
                {
                    if (diag.ShowDialog() == DialogResult.OK)
                    {
                        fontstring = converter.ConvertToString(diag.Font);
                        PluginManager.IDE.EditorSettings.SaveObject("script-font", fontstring);
                        UpdateScriptControls();
                    }
                }
                catch (ArgumentException)
                {
                    MessageBox.Show(@"GDI+ only uses TrueType fonts.", @"Type Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void UseTabsItem_Click(object sender, EventArgs e)
        {
            PluginManager.IDE.EditorSettings.SaveObject("script-tabs", _useTabsItem.Checked);
            UpdateScriptControls();
        }

        void HighlightBracesItem_Click(object sender, EventArgs e)
        {
            PluginManager.IDE.EditorSettings.SaveObject("script-hibraces", _highlightBracesItem.Checked);
            UpdateScriptControls();
        }

        void HighlightLineItem_Click(object sender, EventArgs e)
        {
            PluginManager.IDE.EditorSettings.SaveObject("script-hiline", _highlightLineItem.Checked);
            UpdateScriptControls();
        }

        void CodeFoldItem_Click(object sender, EventArgs e)
        {
            PluginManager.IDE.EditorSettings.SaveObject("script-fold", _codeFoldItem.Checked);
            UpdateScriptControls();
        }

        void AutoCompleteItem_Click(object sender, EventArgs e)
        {
            PluginManager.IDE.EditorSettings.SaveObject("script-autocomplete", _autoCompleteItem.Checked);
            UpdateScriptControls();
        }

        internal static List<String> Functions = new List<string>();

        public static void LoadFunctions()
        {
            FileInfo file = new FileInfo(Application.StartupPath + "/docs/functions.txt");
            if (!file.Exists) return;

            using (StreamReader reader = file.OpenText())
            {
                while (!reader.EndOfStream)
                    Functions.Add(reader.ReadLine());
            }
        }

        public DockContent OpenEditor(string filename = "")
        {
            // Creates a new editor instance:
            ScriptEditor editor = new ScriptEditor() { CanDirty = true, Dock = DockStyle.Fill };

            editor.OnActivate += document_Activate;
            editor.OnDeactivate += document_Deactivate;

            // And creates + styles a dock panel:
            DockContent content = new DockContent() { Text = @"Untitled" };
            content.Controls.Add(editor);
            content.DockAreas = DockAreas.Document;
            content.Icon = Icon;

            if (!string.IsNullOrEmpty(filename)) editor.LoadFile(filename);

            return content;
        }

        void document_Activate(object sender, EventArgs e)
        {
            _rootMenu.Visible = true;
        }

        void document_Deactivate(object sender, EventArgs e)
        {
            _rootMenu.Visible = false;
        }

        private void UpdateScriptControls()
        {
            DockContentCollection docs = PluginManager.IDE.Documents;
            foreach (DockContent content in docs)
            {
                ScriptEditor editor = content.Controls[0] as ScriptEditor;
                if (editor != null) editor.UpdateStyle();
            }
        }
    }
}
