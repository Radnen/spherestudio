using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ScintillaNET;
using Sphere.Core;
using Sphere.Plugins;

namespace ScriptPlugin
{
    public partial class ScriptEditor : EditorObject
    {
        Scintilla code_box = new Scintilla();
        readonly Encoding ISO_8859_1 = Encoding.GetEncoding("iso-8859-1");
        public IPluginHost Host { get; set; }
        private bool _autocomplete;

        public ScriptEditor(IPluginHost host)
        {
            Host = host;
            string config_path = Application.StartupPath + "\\SphereLexer.xml";
            if (File.Exists(config_path))
                code_box.ConfigurationManager.CustomLocation = config_path;

            code_box.ConfigurationManager.Language = "js";
            code_box.AutoComplete.SingleLineAccept = false;
            code_box.AutoComplete.FillUpCharacters = "";
            code_box.AutoComplete.StopCharacters = "(";
            code_box.AutoComplete.ListSeparator = ';';
            code_box.AutoComplete.IsCaseSensitive = false;
            code_box.SupressControlCharacters = true;

            code_box.Folding.MarkerScheme = FoldMarkerScheme.Custom;
            code_box.Folding.Flags = FoldFlag.LineAfterContracted;
            code_box.Folding.UseCompactFolding = false;
            code_box.Margins.Margin1.IsClickable = true;
            code_box.Margins.Margin1.IsFoldMargin = true;

            code_box.Indentation.SmartIndentType = SmartIndent.CPP;
            code_box.Styles.BraceLight.ForeColor = Color.Black;
            code_box.Styles.BraceLight.BackColor = Color.LightGray;

            code_box.Caret.CurrentLineBackgroundColor = Color.LightGoldenrodYellow;

            code_box.CharAdded += new EventHandler<CharAddedEventArgs>(CodeBox_CharAdded);
            code_box.TextDeleted += new EventHandler<TextModifiedEventArgs>(code_box_TextChanged);
            code_box.TextInserted += new EventHandler<TextModifiedEventArgs>(code_box_TextChanged);
            code_box.Dock = DockStyle.Fill;

            Controls.Add(code_box);

            UpdateStyle();
        }

        /// <summary>
        /// Styles the code box per the options specified in the editor settings.
        /// </summary>
        public void UpdateStyle()
        {
            code_box.Indentation.TabWidth = Host.EditorSettings.GetInt("script-spaces", 2);
            code_box.Indentation.UseTabs = Host.EditorSettings.GetBool("script-tabs", true);
            code_box.Caret.HighlightCurrentLine = Host.EditorSettings.GetBool("script-hiline", true);
            code_box.IsBraceMatching = Host.EditorSettings.GetBool("script-hibraces", true);
            
            _autocomplete = Host.EditorSettings.GetBool("script-autocomplete", true);

            bool fold = Host.EditorSettings.GetBool("script-fold", true);
            if (fold) code_box.Margins.Margin1.Width = 16;
            else code_box.Margins.Margin1.Width = 0;

            /*string fontstring = Host.EditorSettings.GetString("script-font");
            if (!String.IsNullOrEmpty(fontstring))
            {
                TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
                SetFont((Font)converter.ConvertFromString(fontstring));
            }*/
        }

        void code_box_TextChanged(object sender, EventArgs e)
        {
            MakeDirty();
            SetMarginSize(code_box.Styles[StylesCommon.LineNumber].Font);
        }

        public override void CreateNew()
        {
            if (Host.EditorSettings.GetBool("use_script_update"))
            {
                string author = (Host.CurrentGame != null) ? Host.CurrentGame.Author: "Unnamed";
                string header = "/**\n* Script: Untitled.js\n* Written by: {0}\n* Updated: {1}\n**/";
                code_box.Text = string.Format(header, author, DateTime.Today.ToShortDateString());
                code_box.UndoRedo.EmptyUndoBuffer();
            }
        }

        private void SetFont(Font font)
        {
            for (int i = 0; i < 128; ++i)
                code_box.Styles[i].Font = font;
            SetMarginSize(font);
        }

        private void SetMarginSize(Font font)
        {
            int spaces = (int)Math.Log10(code_box.Lines.Count) + 1;
            code_box.Margins[0].Width = 2 + spaces * (int)font.SizeInPoints;
        }

        public override void LoadFile(string filename)
        {
            FileName = filename;
            try
            {
                using (StreamReader FileReader = new StreamReader(File.OpenRead(filename), ISO_8859_1))
                {
                    code_box.UndoRedo.IsUndoEnabled = false;
                    code_box.Text = FileReader.ReadToEnd();
                    code_box.UndoRedo.IsUndoEnabled = true;
                    
                    if (Path.GetExtension(filename) != ".js")
                        CodeBox.ConfigurationManager.Language = "default";
                    
                    Parent.Text = Path.GetFileName(filename);
                    SetMarginSize(code_box.Styles[0].Font);
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("File: " + filename + " not found!", "File Not Found");
                Parent.Controls.Remove(this);
            }
        }

        public override void Save()
        {
            if (!IsSaved()) SaveAs();
            else
            {
                using (StreamWriter writer = new StreamWriter(FileName, false, ISO_8859_1))
                {
                    if (Host.EditorSettings.UseScriptUpdate)
                    {
                        code_box.UndoRedo.IsUndoEnabled = false;
                        if (code_box.Lines.Count > 1 && code_box.Lines[1].Text[0] == '*')
                            code_box.Lines[1].Text = "* Script: " + Path.GetFileName(FileName);
                        if (code_box.Lines.Count > 2 && code_box.Lines[2].Text[0] == '*')
                            code_box.Lines[2].Text = "* Written by: " + Host.CurrentGame.Author;
                        if (code_box.Lines.Count > 3 && code_box.Lines[3].Text[0] == '*')
                            code_box.Lines[3].Text = "* Updated: " + DateTime.Today.ToShortDateString();
                        code_box.UndoRedo.IsUndoEnabled = true;
                    }

                    writer.Write(code_box.Text);
                }
                Parent.Text = Path.GetFileName(FileName);
            }
        }

        public override void SaveAs()
        {
            using (SaveFileDialog diag = new SaveFileDialog())
            {
                diag.Filter = "Sphere Script Files (.js)|*.js";

                if (Host.CurrentGame != null)
                    diag.InitialDirectory = Host.CurrentGame.RootPath + "\\scripts";

                if (diag.ShowDialog() == DialogResult.OK)
                {
                    FileName = diag.FileName;
                    Save();
                }
            }
        }

        public override void Copy()
        {
            code_box.Clipboard.Copy();
        }

        public override void Paste()
        {
            if (code_box.Clipboard.CanPaste)
                code_box.Clipboard.Paste();
        }

        public override void Cut()
        {
            code_box.Clipboard.Cut();
        }

        public override void SelectAll()
        {
            code_box.Selection.SelectAll();
        }

        public override void Undo()
        {
            if (code_box.UndoRedo.CanUndo) code_box.UndoRedo.Undo();
        }

        public override void Redo()
        {
            if (code_box.UndoRedo.CanRedo) code_box.UndoRedo.Redo();
        }

        public override string Text
        {
            get { return code_box.Text; }
            set
            {
                code_box.Text = value;
                code_box.UndoRedo.EmptyUndoBuffer();
            }
        }

        public void CodeBox_CharAdded(object sender, CharAddedEventArgs e)
        {
            if (!_autocomplete) return;

            if (char.IsLetter(e.Ch))
            {
                string word = code_box.GetWordFromPosition(code_box.CurrentPos).ToLower();
                List<string> filter = new List<string>();

                foreach (string s in ScriptPlugin.functions)
                {
                    if (s.ToLower().Contains(word)) filter.Add(s.Replace(";", ""));
                }

                if (filter.Count != 0)
                {
                    code_box.AutoComplete.List = filter;
                    code_box.AutoComplete.Show(word.Length);
                }
            }
        }

        public Scintilla CodeBox
        {
            get { return code_box; }
            set { code_box = value; }
        }
    }
}
