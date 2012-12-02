using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ScintillaNET;

namespace Sphere_Editor.SubEditors
{
    public partial class ScriptEditor : EditorObject
    {
        private string filename = null;
        Scintilla code_box = new Scintilla();
        readonly Encoding ISO_8859_1 = System.Text.Encoding.GetEncoding("iso-8859-1");

        public ScriptEditor()
        {
            code_box.ConfigurationManager.CustomLocation = Application.StartupPath + "\\SphereLexer.xml";
            code_box.ConfigurationManager.Language = "js";
            code_box.AutoComplete.SingleLineAccept = false;
            code_box.AutoComplete.FillUpCharacters = " ";
            code_box.AutoComplete.StopCharacters = "(";
            code_box.AutoComplete.ListSeparator = '&';
            code_box.AutoComplete.IsCaseSensitive = false;
            code_box.AutoCompleteAccepted += new EventHandler<AutoCompleteAcceptedEventArgs>(code_box_AutoCompleteAccepted);
            code_box.SupressControlCharacters = true;
            code_box.Margins[0].Width = 36;
            code_box.Indentation.SmartIndentType = SmartIndent.CPP;
            code_box.Indentation.TabWidth = 2;
            code_box.CharAdded += new EventHandler<CharAddedEventArgs>(CodeBox_CharAdded);
            code_box.TextDeleted += new EventHandler<TextModifiedEventArgs>(code_box_TextChanged);
            code_box.TextInserted += new EventHandler<TextModifiedEventArgs>(code_box_TextChanged);
            code_box.Dock = DockStyle.Fill;
            code_box.Commands.AddBinding(Keys.D, Keys.Control, BindableCommand.LineDuplicate);
            Controls.Add(code_box);
        }

        private static string keywords = "var while if const function";

        /// <summary>
        /// Grabs the last applicable JS keyword. Returns true if one has been found.
        /// </summary>
        /// <returns>True if a keyword was found immediately to the left.</returns>
        private bool HasLastKeyword()
        {
            string word = code_box.GetWordFromPosition(code_box.CurrentPos);
            string[] words = GetWords(code_box.GetCurrentLine());

            for (int i = 0; i < words.Length; ++i)
            {
                if (words[i] == word && i > 0 && keywords.Contains(words[i - 1]))
                    return true;
            }

            return false;
        }

        // splits a string into individual lexemes:
        static string[] GetWords(string host)
        {
            string word = null;
            List<string> words = new List<string>();

            for (int i = 0; i < host.Length; ++i)
            {
                if (host[i] == '\t') continue; // \t is not technically whitespace!
                if (char.IsWhiteSpace(host[i]) && !string.IsNullOrEmpty(word))
                {
                    words.Add(word);
                    word = null;
                }
                else word += host[i];
            }

            return words.ToArray();
        }

        void code_box_AutoCompleteAccepted(object sender, AutoCompleteAcceptedEventArgs e)
        {
            if (HasLastKeyword()) e.Cancel = true;
        }

        void code_box_TextChanged(object sender, EventArgs e)
        {
            if (!Parent.Text.Contains("*")) Parent.Text += "*";
        }

        public override void CreateNew()
        {
            if (Global.CurrentEditor.UseScriptUpdate)
            {
                string author = "Unnamed";
                if (Global.CurrentProject != null) author = Global.CurrentProject.Author;

                code_box.Text += "/**\n* Script: Untitled.js" +
                       "\n* Written by: " + author + "\n* Updated: " +
                       DateTime.Today.ToShortDateString() + "\n**/";
                code_box.UndoRedo.EmptyUndoBuffer();
            }
        }

        public string FileName
        {
            get { return filename; }
            set { filename = value; }
        }

        public override void LoadFile(string filename)
        {
            this.filename = filename;
            try
            {
                using (StreamReader FileReader = new StreamReader(File.OpenRead(filename), ISO_8859_1))
                {
                    code_box.UndoRedo.IsUndoEnabled = false;
                    code_box.Text = FileReader.ReadToEnd();
                    code_box.UndoRedo.IsUndoEnabled = true;
                    if (!Global.IsScript(ref filename)) CodeBox.ConfigurationManager.Language = "default";
                    Parent.Text = Path.GetFileName(filename);
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
            if (this.filename == null) SaveAs();
            else
            {
                using (StreamWriter writer = new StreamWriter(File.OpenWrite(filename), ISO_8859_1))
                {
                    if (Global.CurrentEditor.UseScriptUpdate)
                    {
                        code_box.UndoRedo.IsUndoEnabled = false;
                        if (code_box.Lines.Count > 1 && code_box.Lines[1].Text[0] == '*')
                            code_box.Lines[1].Text = "* Script: " + Path.GetFileName(filename);
                        if (code_box.Lines.Count > 2 && code_box.Lines[2].Text[0] == '*')
                            code_box.Lines[2].Text = "* Written by: " + Global.CurrentProject.Author;
                        if (code_box.Lines.Count > 3 && code_box.Lines[3].Text[0] == '*')
                            code_box.Lines[3].Text = "* Updated: " + DateTime.Today.ToShortDateString();
                        code_box.UndoRedo.IsUndoEnabled = true;
                    }

                    writer.Write(code_box.Text);
                }
                Parent.Text = Path.GetFileName(filename);
            }
        }

        public override void SaveAs()
        {
            using (SaveFileDialog diag = new SaveFileDialog())
            {
                diag.Filter = "Sphere Script Files (.js)|*.js";

                if (Global.CurrentProject != null)
                    diag.InitialDirectory = Global.CurrentProject.RootPath + "\\scripts";

                if (diag.ShowDialog() == DialogResult.OK)
                {
                    this.filename = diag.FileName;
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
            if (!Global.CurrentEditor.ShowAutoComplete) return;

            string word = code_box.GetWordFromPosition(code_box.CurrentPos);
            string lword = word.ToLower();
            if (char.IsLetter(e.Ch))
            {
                List<string> filter = new List<string>();

                foreach (string s in Global.CurrentScriptSettings.FunctionList)
                {
                    if (s.ToLower().Contains(lword)) filter.Add(s);
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
