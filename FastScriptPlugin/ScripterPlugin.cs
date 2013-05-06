using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Sphere.Plugins;
using WeifenLuo.WinFormsUI.Docking;

namespace FastScriptPlugin
{
    public class ScripterPlugin : IPlugin
    {

        public string Name { get { return "Fast Script Editor"; } }
        public string Author { get { return "Radnen"; } }
        public string Description { get { return "A faster, neater code editor for the Sphere Studio."; } }
        public string Version { get { return "1.0b"; } }

        public IPluginHost Host { get; set; }
        public Icon Icon { get; private set; }

        private string[] _fileTypes = { ".js", ".txt", ".log", ".md", ".sgm", ".gitignore" };
        private string _openFileFilters = "*.js;*.txt;*.log;*.md;*.sgm";

        ToolStripMenuItem RootMenu, IndentMenu, NewScriptItem, OpenScriptItem;
        ToolStripMenuItem AutoCompleteItem, HighlightLineItem, CodeFoldItem;
        ToolStripMenuItem UseTabsItem, ChangeFontItem;
        ToolStripMenuItem TwoUnitItem, FourUnitItem, EightUnitItem;
        ToolStripItem Separator1, Separator2;

        public ScripterPlugin()
        {
            Icon = Icon.FromHandle(Properties.Resources.script_edit.GetHicon());

            #region menu items
            AutoCompleteItem = new ToolStripMenuItem("Auto Complete");
            AutoCompleteItem.CheckOnClick = true;
            AutoCompleteItem.Click += new EventHandler(AutoCompleteItem_Click);

            CodeFoldItem = new ToolStripMenuItem("Code Folding");
            CodeFoldItem.CheckOnClick = true;
            CodeFoldItem.Click += new EventHandler(CodeFoldItem_Click);

            HighlightLineItem = new ToolStripMenuItem("Highlight Current Line");
            HighlightLineItem.CheckOnClick = true;
            HighlightLineItem.Click += new EventHandler(HighlightLineItem_Click);

            Separator1 = new ToolStripSeparator();
            Separator2 = new ToolStripSeparator();

            UseTabsItem = new ToolStripMenuItem("Use Tabs");
            UseTabsItem.CheckOnClick = true;
            UseTabsItem.Click += new EventHandler(UseTabsItem_Click);

            TwoUnitItem = new ToolStripMenuItem("2 units");
            TwoUnitItem.Click += new EventHandler(TwoUnitItem_Click);

            FourUnitItem = new ToolStripMenuItem("4 units");
            FourUnitItem.Click += new EventHandler(FourUnitItem_Click);

            EightUnitItem = new ToolStripMenuItem("8 units");
            EightUnitItem.Click += new EventHandler(EightUnitItem_Click);

            ChangeFontItem = new ToolStripMenuItem("Change Font...", Properties.Resources.style);
            ChangeFontItem.Click += new EventHandler(ChangeFontItem_Click);

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
            NewScriptItem.Click += new EventHandler(NewScriptItem_Click);

            OpenScriptItem = new ToolStripMenuItem("Script", Properties.Resources.script_edit);
            OpenScriptItem.Click += new EventHandler(OpenScriptItem_Click);
            #endregion
        }

        private void AutoCompleteItem_Click(object sender, EventArgs e)
        {
            Host.EditorSettings.SaveObject("script-autocomplete", AutoCompleteItem.Checked);
            UpdateScriptControls();
        }

        private void CodeFoldItem_Click(object sender, EventArgs e)
        {
            Host.EditorSettings.SaveObject("script-fold", CodeFoldItem.Checked);
            UpdateScriptControls();
        }

        void HighlightLineItem_Click(object sender, EventArgs e)
        {
            Host.EditorSettings.SaveObject("script-hiline", HighlightLineItem.Checked);
            UpdateScriptControls();
        }

        private void UseTabsItem_Click(object sender, EventArgs e)
        {
            Host.EditorSettings.SaveObject("script-tabs", UseTabsItem.Checked);
            UpdateScriptControls();
        }

        private void TwoUnitItem_Click(object sender, EventArgs e)
        {
            TwoUnitItem.Checked = true;
            FourUnitItem.Checked = EightUnitItem.Checked = false;
            Host.EditorSettings.SaveObject("script-spaces", 2);
            UpdateScriptControls();
        }

        private void FourUnitItem_Click(object sender, EventArgs e)
        {
            FourUnitItem.Checked = true;
            TwoUnitItem.Checked = EightUnitItem.Checked = false;
            Host.EditorSettings.SaveObject("script-spaces", 4);
            UpdateScriptControls();
        }

        private void EightUnitItem_Click(object sender, EventArgs e)
        {
            EightUnitItem.Checked = true;
            TwoUnitItem.Checked = FourUnitItem.Checked = false;
            Host.EditorSettings.SaveObject("script-spaces", 8);
            UpdateScriptControls();
        }

        private void ChangeFontItem_Click(object sender, EventArgs e)
        {
            using (FontDialog diag = new FontDialog())
            {
                TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
                string fontstring = Host.EditorSettings.GetString("script-font");

                if (!String.IsNullOrEmpty(fontstring))
                    diag.Font = (Font)converter.ConvertFromString(fontstring);

                try
                {
                    if (diag.ShowDialog() == DialogResult.OK)
                    {
                        fontstring = converter.ConvertToString(diag.Font);
                        Host.EditorSettings.SaveObject("script-font", fontstring);
                        UpdateScriptControls();
                    }
                }
                catch (ArgumentException)
                {
                    MessageBox.Show("GDI+ only uses TrueType fonts.", "Type Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void NewScriptItem_Click(object sender, EventArgs e)
        {
            Host.DockControl(OpenEditor(), DockState.Document);
        }

        private void OpenScriptItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog diag = new OpenFileDialog())
            {
                diag.Filter = _openFileFilters;

                if (Host.CurrentGame != null)
                    diag.InitialDirectory = Host.CurrentGame.RootPath + "\\scripts";

                if (diag.ShowDialog() == DialogResult.OK)
                    Host.DockControl(OpenEditor(diag.FileName), DockState.Document);
            }
        }

        public DockContent OpenEditor(string filename = "")
        {
            Scripter script_editor = new Scripter(Host);
            
            script_editor.OnActivate += new EventHandler(editor_OnActivate);
            script_editor.OnDeactivate += new EventHandler(editor_OnDeactivate);

            script_editor.Dock = System.Windows.Forms.DockStyle.Fill;

            DockContent content = new DockContent();
            content.Text = "Untitled.js";
            content.Controls.Add(script_editor);
            content.DockAreas = DockAreas.Document;
            content.Icon = Icon;

            if (!string.IsNullOrEmpty(filename)) script_editor.LoadFile(filename);

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
        
        void Host_TryEditFile(object sender, EditFileEventArgs e)
        {
            if (e.IsAlreadyMatched) return;
            foreach (string type in _fileTypes)
            {
                if (e.FileExtension == type)
                {
                    Host.DockControl(OpenEditor(e.FileFullPath), DockState.Document);
                    e.IsAlreadyMatched = true;
                }
            }
        }

        public void Initialize()
        {
            Host.TryEditFile += Host_TryEditFile;
            Host.RegisterOpenFileType("Script/Text Files", _openFileFilters);

            Host.AddMenuItem(RootMenu, "View");
            Host.AddMenuItem("File.New", NewScriptItem);
            Host.AddMenuItem("File.Open", OpenScriptItem);

            AutoCompleteItem.Checked = Host.EditorSettings.GetBool("script-autocomplete", true);
            CodeFoldItem.Checked = Host.EditorSettings.GetBool("script-fold", true);
            UseTabsItem.Checked = Host.EditorSettings.GetBool("script-tabs", true);
            HighlightLineItem.Checked = Host.EditorSettings.GetBool("script-hiline", true);

            int spaces = Host.EditorSettings.GetInt("script-spaces", 2);
            TwoUnitItem.Checked = spaces == 2;
            FourUnitItem.Checked = spaces == 4;
            EightUnitItem.Checked = spaces == 8;
        }

        public void Destroy()
        {
            Host.TryEditFile -= Host_TryEditFile;
            Host.UnregisterOpenFileType(_openFileFilters);
            Host.RemoveMenuItem("Script");
            Host.RemoveMenuItem(NewScriptItem);
            Host.RemoveMenuItem(OpenScriptItem);
        }

        private void UpdateScriptControls()
        {
            DockContentCollection docs = Host.GetDocuments();
            foreach (DockContent content in docs)
                if (content.Controls[0] is Scripter)
                    ((Scripter)content.Controls[0]).UpdateStyle();
        }
    }
}
