using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Sphere.Plugins;
using Sphere.Core;
using WeifenLuo.WinFormsUI.Docking;
using System.ComponentModel;

namespace ScriptPlugin
{
    public class ScriptPlugin : IEditorPlugin
    {
        public string Name { get { return "Scintilla Script Editor"; } }
        public string Author { get { return "Radnen"; } }
        public string Description { get { return "A Scintilla based script editor."; } }
        public string Version { get { return "1.1"; } }

        public IPluginHost Host { get; set; }
        public Icon Icon { get; private set; }

        private string[] _filetypes = { ".js" };

        ToolStripMenuItem RootMenu, IndentMenu;
        ToolStripMenuItem AutoCompleteItem, CodeFoldItem, HighlightLineItem;
        ToolStripMenuItem HighlightBracesItem, UseTabsItem, ChangeFontItem;
        ToolStripMenuItem TwoUnitItem, FourUnitItem, EightUnitItem;
        ToolStripItem Separator1, Separator2;

        public ScriptPlugin()
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

            HighlightBracesItem = new ToolStripMenuItem("Highlight Braces");
            HighlightBracesItem.CheckOnClick = true;
            HighlightBracesItem.Click += new EventHandler(HighlightBracesItem_Click);

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
            RootMenu.DropDownItems.Add(HighlightBracesItem);
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
            #endregion
        }

        void EightUnitItem_Click(object sender, EventArgs e)
        {
            EightUnitItem.Checked = true;
            TwoUnitItem.Checked = FourUnitItem.Checked = false;
            Host.EditorSettings.SaveObject("script-spaces", 8);
            UpdateScriptControls();
        }

        void FourUnitItem_Click(object sender, EventArgs e)
        {
            FourUnitItem.Checked = true;
            TwoUnitItem.Checked = EightUnitItem.Checked = false;
            Host.EditorSettings.SaveObject("script-spaces", 4);
            UpdateScriptControls();
        }

        void TwoUnitItem_Click(object sender, EventArgs e)
        {
            TwoUnitItem.Checked = true;
            FourUnitItem.Checked = EightUnitItem.Checked = false;
            Host.EditorSettings.SaveObject("script-spaces", 2);
            UpdateScriptControls();
        }

        void ChangeFontItem_Click(object sender, EventArgs e)
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

        void UseTabsItem_Click(object sender, EventArgs e)
        {
            Host.EditorSettings.SaveObject("script-tabs", UseTabsItem.Checked);
            UpdateScriptControls();
        }

        void HighlightBracesItem_Click(object sender, EventArgs e)
        {
            Host.EditorSettings.SaveObject("script-hibraces", HighlightBracesItem.Checked);
            UpdateScriptControls();
        }

        void HighlightLineItem_Click(object sender, EventArgs e)
        {
            Host.EditorSettings.SaveObject("script-hiline", HighlightLineItem.Checked);
            UpdateScriptControls();
        }

        void CodeFoldItem_Click(object sender, EventArgs e)
        {
            Host.EditorSettings.SaveObject("script-fold", CodeFoldItem.Checked);
        }

        void AutoCompleteItem_Click(object sender, EventArgs e)
        {
            Host.EditorSettings.SaveObject("script-autocomplete", AutoCompleteItem.Checked);
            UpdateScriptControls();
        }

        internal static List<String> functions = new List<string>();

        public static void LoadFunctions()
        {
            FileInfo file = new FileInfo(Application.StartupPath + "/docs/functions.txt");
            if (!file.Exists) return;

            using (StreamReader reader = file.OpenText())
            {
                while (!reader.EndOfStream)
                    functions.Add(reader.ReadLine());
            }
        }

        public DockContent OpenEditor(string filename)
        {
            // Creates a new editor instance:
            ScriptEditor editor = new ScriptEditor(Host);

            editor.OnActivate += new EventHandler(editor_OnActivate);
            editor.OnDeactivate += new EventHandler(editor_OnDeactivate);

            editor.Dock = DockStyle.Fill;

            // And creates + styles a dock panel:
            DockContent content = new DockContent();
            content.Text = "Script Editor";
            content.Controls.Add(editor);
            content.DockAreas = DockAreas.Document;
            content.Icon = Icon;

            if (!string.IsNullOrEmpty(filename)) editor.LoadFile(filename);

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

        public void Initialize()
        {
            LoadFunctions();
            Host.Register(_filetypes, "ScriptPlugin");

            // Show thie root menu for this control; appearing before the 'View' menu.
            Host.AddMenuItem(RootMenu, "View");

            AutoCompleteItem.Checked = Host.EditorSettings.ShowAutoComplete;
            CodeFoldItem.Checked = Host.EditorSettings.GetBool("script-fold", true);
            HighlightLineItem.Checked = Host.EditorSettings.GetBool("script-hiline", true);
            HighlightBracesItem.Checked = Host.EditorSettings.GetBool("script-hibraces", true);
            UseTabsItem.Checked = Host.EditorSettings.GetBool("script-tabs", true);

            int spaces = Host.EditorSettings.GetInt("script-spaces", 2);
            TwoUnitItem.Checked = spaces == 2;
            FourUnitItem.Checked = spaces == 4;
            EightUnitItem.Checked = spaces == 8;
        }

        public void Destroy()
        {
            functions.Clear();
            Host.Unregister(_filetypes);
            Host.RemoveMenuItem("ScriptPlugin");
        }

        private void UpdateScriptControls()
        {
            DockContentCollection docs = Host.GetDocuments();
            foreach (DockContent content in docs)
                if (content.Controls[0] is ScriptEditor)
                    ((ScriptEditor)content.Controls[0]).UpdateStyle();
        }
    }
}
