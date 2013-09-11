using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Sphere.Core.Editor;
using Sphere.Plugins;
using WeifenLuo.WinFormsUI.Docking;

namespace SphereStudio.Plugins
{
    public class FastScriptEditPlugin : IEditorPlugin
    {
        public string Name { get { return "Fast Script Editor"; } }
        public string Author { get { return "Radnen"; } }
        public string Description { get { return "An experimental script editor, not as fast as it's namesake."; } }
        public string Version { get { return "1.0b"; } }
        public Icon Icon { get; private set; }

        private const string _openFileFilters = "*.js;*.txt;*.log;*.md;*.sgm;*.ini;*.sav";
        private readonly List<string> _extensionList = new List<string>(new[] { ".js", ".txt", ".log", ".md", ".sgm", ".gitignore", ".ini", ".sav" });

        private ToolStripMenuItem RootMenu, IndentMenu, NewScriptItem;
        private ToolStripMenuItem AutoCompleteItem, HighlightLineItem, CodeFoldItem;
        private ToolStripMenuItem UseTabsItem, ChangeFontItem;
        private ToolStripMenuItem TwoUnitItem, FourUnitItem, EightUnitItem;
        private ToolStripItem Separator1, Separator2;

        public FastScriptEditPlugin()
        {
            Icon = Icon.FromHandle(Properties.Resources.script_edit.GetHicon());

            #region menu items
            AutoCompleteItem = new ToolStripMenuItem("Auto Complete") {CheckOnClick = true};
            AutoCompleteItem.Click += AutoCompleteItem_Click;

            CodeFoldItem = new ToolStripMenuItem("Code Folding") {CheckOnClick = true};
            CodeFoldItem.Click += CodeFoldItem_Click;

            HighlightLineItem = new ToolStripMenuItem("Highlight Current Line") {CheckOnClick = true};
            HighlightLineItem.Click += HighlightLineItem_Click;

            Separator1 = new ToolStripSeparator();
            Separator2 = new ToolStripSeparator();

            UseTabsItem = new ToolStripMenuItem("Use Tabs") {CheckOnClick = true};
            UseTabsItem.Click += UseTabsItem_Click;

            TwoUnitItem = new ToolStripMenuItem("2 units");
            TwoUnitItem.Click += TwoUnitItem_Click;

            FourUnitItem = new ToolStripMenuItem("4 units");
            FourUnitItem.Click += FourUnitItem_Click;

            EightUnitItem = new ToolStripMenuItem("8 units");
            EightUnitItem.Click += EightUnitItem_Click;

            ChangeFontItem = new ToolStripMenuItem("Change Font...", Properties.Resources.style);
            ChangeFontItem.Click += ChangeFontItem_Click;

            RootMenu = new ToolStripMenuItem("&Script");
            RootMenu.DropDownItems.Add(AutoCompleteItem);
            RootMenu.DropDownItems.Add(CodeFoldItem);
            RootMenu.DropDownItems.Add(HighlightLineItem);
            RootMenu.DropDownItems.Add(Separator1);

            IndentMenu = new ToolStripMenuItem("Indentation");
            IndentMenu.DropDownItems.Add(UseTabsItem);
            IndentMenu.DropDown.Items.Add(Separator2);
            IndentMenu.DropDown.Items.Add(TwoUnitItem);
            IndentMenu.DropDown.Items.Add(FourUnitItem);
            IndentMenu.DropDown.Items.Add(EightUnitItem);

            RootMenu.DropDownItems.Add(IndentMenu);
            RootMenu.DropDownItems.Add(ChangeFontItem);
            RootMenu.Visible = false;

            NewScriptItem = new ToolStripMenuItem("Script", Properties.Resources.script_edit);
            NewScriptItem.Click += NewScriptItem_Click;
            #endregion
        }

        public void Initialize()
        {
            PluginManager.RegisterEditor(EditorType.Script, this);

            PluginManager.IDE.TryEditFile += IDE_TryEditFile;
            PluginManager.IDE.RegisterOpenFileType("Script/Text Files", _openFileFilters);

            PluginManager.IDE.AddMenuItem(RootMenu, "View");
            PluginManager.IDE.AddMenuItem("File.New", NewScriptItem);

            AutoCompleteItem.Checked = PluginManager.IDE.EditorSettings.GetBool("script-autocomplete", true);
            CodeFoldItem.Checked = PluginManager.IDE.EditorSettings.GetBool("script-fold", true);
            UseTabsItem.Checked = PluginManager.IDE.EditorSettings.GetBool("script-tabs", true);
            HighlightLineItem.Checked = PluginManager.IDE.EditorSettings.GetBool("script-hiline", true);

            int spaces = PluginManager.IDE.EditorSettings.GetInt("script-spaces", 2);
            TwoUnitItem.Checked = spaces == 2;
            FourUnitItem.Checked = spaces == 4;
            EightUnitItem.Checked = spaces == 8;
        }

        public void Destroy()
        {
            PluginManager.UnregisterEditor(this);
            PluginManager.IDE.UnregisterOpenFileType(_openFileFilters);
            PluginManager.IDE.RemoveMenuItem("Script");
            PluginManager.IDE.RemoveMenuItem(NewScriptItem);
            PluginManager.IDE.TryEditFile -= IDE_TryEditFile;
        }

        public EditorObject CreateEditControl()
        {
            return new Scripter();
        }

        private void AutoCompleteItem_Click(object sender, EventArgs e)
        {
            PluginManager.IDE.EditorSettings.SaveObject("script-autocomplete", AutoCompleteItem.Checked);
            UpdateScriptControls();
        }

        private void CodeFoldItem_Click(object sender, EventArgs e)
        {
            PluginManager.IDE.EditorSettings.SaveObject("script-fold", CodeFoldItem.Checked);
            UpdateScriptControls();
        }

        void HighlightLineItem_Click(object sender, EventArgs e)
        {
            PluginManager.IDE.EditorSettings.SaveObject("script-hiline", HighlightLineItem.Checked);
            UpdateScriptControls();
        }

        private void UseTabsItem_Click(object sender, EventArgs e)
        {
            PluginManager.IDE.EditorSettings.SaveObject("script-tabs", UseTabsItem.Checked);
            UpdateScriptControls();
        }

        private void TwoUnitItem_Click(object sender, EventArgs e)
        {
            TwoUnitItem.Checked = true;
            FourUnitItem.Checked = EightUnitItem.Checked = false;
            PluginManager.IDE.EditorSettings.SaveObject("script-spaces", 2);
            UpdateScriptControls();
        }

        private void FourUnitItem_Click(object sender, EventArgs e)
        {
            FourUnitItem.Checked = true;
            TwoUnitItem.Checked = EightUnitItem.Checked = false;
            PluginManager.IDE.EditorSettings.SaveObject("script-spaces", 4);
            UpdateScriptControls();
        }

        private void EightUnitItem_Click(object sender, EventArgs e)
        {
            EightUnitItem.Checked = true;
            TwoUnitItem.Checked = FourUnitItem.Checked = false;
            PluginManager.IDE.EditorSettings.SaveObject("script-spaces", 8);
            UpdateScriptControls();
        }

        private void ChangeFontItem_Click(object sender, EventArgs e)
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

        private void NewScriptItem_Click(object sender, EventArgs e)
        {
            PluginManager.IDE.DockControl(OpenEditor(), DockState.Document);
        }

        public DockContent OpenEditor(string filename = "")
        {
            Scripter scriptEditor = new Scripter() { CanDirty = true, Dock = DockStyle.Fill };
            scriptEditor.OnActivate += editor_OnActivate;
            scriptEditor.OnDeactivate += editor_OnDeactivate;

            DockContent content = new DockContent {Text = @"Untitled.js"};
            content.Controls.Add(scriptEditor);
            content.DockAreas = DockAreas.Document;
            content.Icon = Icon;

            if (!string.IsNullOrEmpty(filename)) scriptEditor.LoadFile(filename);

            return content;
        }

        void editor_OnDeactivate(object sender, EventArgs e)
        {
            RootMenu.Visible = false;
        }

        void editor_OnActivate(object sender, EventArgs e)
        {
            RootMenu.Visible = true;
        }
        
        void IDE_TryEditFile(object sender, EditFileEventArgs e)
        {
            if (e.Handled) return;
            if (_extensionList.Contains(e.Extension.ToLowerInvariant()))
            {
                PluginManager.IDE.DockControl(OpenEditor(e.Path), DockState.Document);
                e.Handled = true;
            }
        }

        private void UpdateScriptControls()
        {
            DockContentCollection docs = PluginManager.IDE.Documents;
            foreach (DockContent content in docs)
            {
                Scripter scripter = content.Controls[0] as Scripter;
                if (scripter != null)
                    scripter.UpdateStyle();
            }
        }
    }
}
