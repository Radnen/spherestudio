using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using Sphere.Plugins;
using Sphere.Plugins.Views;

using SphereStudio.ScriptEditor.Components;
using SphereStudio.ScriptEditor.Properties;
using ScintillaNET;

namespace SphereStudio.ScriptEditor
{
    public partial class ScriptEditView : ScriptView
    {
        private Scintilla _codeBox = new Scintilla();

        private int _activeLine = 0;
        private int _errorLine = 0;
        private int _lastCaretPos = Scintilla.InvalidPosition;
        private bool _highlightLine = true;
        private int _lineMarginWidth = -1;
        private PluginMain _main;
        private QuickFind _quickFind;
        private bool _useAutoComplete;

        // avoid an automatic byte-order mark being added to saved scripts.
        private readonly Encoding UTF_8_NOBOM = new UTF8Encoding(false);

        public ScriptEditView(PluginMain main)
        {
            InitializeComponent();

            InitializeMargins();
            InitializeAutoComplete();

            Icon = Icon.FromHandle(Resources.ScriptIcon.GetHicon());

            _main = main;
            _quickFind = new QuickFind(this, _codeBox);

            _codeBox.Dock = DockStyle.Fill;
            _codeBox.Styles[Style.Default].Font = "Consolas";
            _codeBox.Styles[Style.Default].SizeF = 10.25F;
            _codeBox.CharAdded += codeBox_CharAdded;
            _codeBox.InsertCheck += codeBox_InsertCheck;
            _codeBox.KeyDown += codebox_KeyDown;
            _codeBox.MarginClick += codeBox_MarginClick;
            _codeBox.SavePointLeft += codeBox_SavePointLeft;
            _codeBox.SavePointReached += codeBox_SavePointReached;
            _codeBox.TextChanged += codeBox_TextChanged;
            _codeBox.UpdateUI += codeBox_UpdateUI;
            Controls.Add(_codeBox);

            Restyle();
        }

        private void codeBox_TextChanged(object sender, EventArgs e)
        {
            int lastLineNum = _codeBox.Lines.Count - 1;
            int newMarginWidth = _codeBox.TextWidth(Style.LineNumber, lastLineNum.ToString()) + 8;
            if (_codeBox.Lexer == Lexer.Null)
                newMarginWidth = 0;
            if (newMarginWidth != _lineMarginWidth)
                _codeBox.Margins[1].Width = newMarginWidth;
            _lineMarginWidth = newMarginWidth;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                    if (_quickFind.Visible) {
                        _quickFind.Close();
                        return true;
                    }
                    break;
                case Keys.F3:
                    _quickFind.FindNext();
                    return true;
                case Keys.Control | Keys.A:
                    if (!_codeBox.ContainsFocus)
                        break;
                    _codeBox.SelectAll();
                    return true;
                case Keys.Control | Keys.F:
                    _quickFind.Open();
                    return true;
                case Keys.Control | Keys.H:
                    _quickFind.Open(true);
                    return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void codeBox_SavePointReached(object sender, EventArgs e)
        {
            IsDirty = false;
        }

        private void codeBox_SavePointLeft(object sender, EventArgs e)
        {
            IsDirty = true;
        }

        public override int ActiveLine
        {
            get { return _activeLine; }
            set
            {
                if (_activeLine > 0)
                    _codeBox.Lines[_activeLine - 1].MarkerDelete(1);
                _activeLine = value;
                if (_activeLine > 0)
                {
                    _codeBox.Lines[_activeLine - 1].MarkerAdd(1);
                    _codeBox.GotoPosition(_codeBox.Lines[_activeLine - 1].Position);
                    var parent = _codeBox.Lines[_activeLine - 1].FoldParent;
                    if (parent >= 0 && !_codeBox.Lines[parent].Expanded)
                    {
                        _codeBox.Lines[parent].ToggleFold();
                    }
                }
            }
        }

        public override int ErrorLine
        {
            get { return _errorLine; }
            set
            {
                if (_errorLine > 0)
                    _codeBox.Lines[_errorLine - 1].MarkerDelete(2);
                _errorLine = value;
                if (_errorLine > 0)
                {
                    _codeBox.Lines[_errorLine - 1].MarkerAdd(2);
                    _codeBox.GotoPosition(_codeBox.Lines[_errorLine - 1].Position);
                    var parent = _codeBox.Lines[_activeLine - 1].FoldParent;
                    if (parent >= 0 && !_codeBox.Lines[parent].Expanded)
                    {
                        _codeBox.Lines[parent].ToggleFold();
                    }
                }
            }
        }

        public override int[] Breakpoints
        {
            get
            {
                var q = from Line line in _codeBox.Lines
                        where (line.MarkerGet() & 0x01) != 0
                        select line.Index + 1;
                return q.ToArray();
            }
            set
            {
                _codeBox.MarkerDeleteAll(0);
                foreach (int line in value)
                {
                    _codeBox.Lines[line - 1].MarkerAdd(0);
                }
            }
        }

        public override string[] FileExtensions
        {
            get { return new[] { "js", "ts", "coffee", "json" }; }
        }

        public override bool ReadOnly
        {
            get { return _codeBox.ReadOnly; }
            set { _codeBox.ReadOnly = value; }
        }

        public override string Text
        {
            get
            {
                return _codeBox.Text;
            }
            set
            {
                _codeBox.Text = value;
                _codeBox.EmptyUndoBuffer();
            }
        }

        public override string ViewState
        {
            get
            {
                return string.Format("{0}|{1}|{2}",
                    _codeBox.CurrentPosition,
                    _codeBox.AnchorPosition,
                    _codeBox.FirstVisibleLine);
            }
            set
            {
                string[] parse = value.Split('|');
                _codeBox.CurrentPosition = Convert.ToInt32(parse[0]);
                _codeBox.AnchorPosition = Convert.ToInt32(parse[1]);
                _codeBox.FirstVisibleLine = Convert.ToInt32(parse[2]);
            }
        }

        public override bool NewDocument()
        {
            _codeBox.Text = "";
            if (_main.Settings.GetBoolean("autoScriptHeader", false))
            {
                string author = (PluginManager.Core.Project != null) ? PluginManager.Core.Project.Author : "Unnamed";
                const string header = "/**\n* Script: Untitled.js\n* Written by: {0}\n* Updated: {1}\n**/";
                _codeBox.Text = string.Format(header, author, DateTime.Today.ToShortDateString());
            }

            _codeBox.Lexer = Lexer.Cpp;
            InitializeHighlighting();
            InitializeFolding();

            _codeBox.EmptyUndoBuffer();
            _codeBox.SetSavePoint();
            return true;
        }

        public override void Load(string filename)
        {
            using (StreamReader fileReader = new StreamReader(File.OpenRead(filename), true))
            {
                var extSansDot = Path.GetExtension(filename).StartsWith(".")
                    ? Path.GetExtension(filename).Substring(1) : "";
                _codeBox.Lexer = FileExtensions.Contains(extSansDot) ? Lexer.Cpp : Lexer.Null;
                _codeBox.Text = fileReader.ReadToEnd();
                _codeBox.EmptyUndoBuffer();
                if (_codeBox.Lexer == Lexer.Cpp)
                {
                    InitializeHighlighting();
                    InitializeFolding();
                }

                int[] breaks = new int[0];
                if (PluginManager.Core.Project != null)
                    breaks = PluginManager.Core.Project.GetBreakpoints(filename);
                Breakpoints = breaks;
            }

            _codeBox.SetSavePoint();
        }

        public override void Save(string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename, false, UTF_8_NOBOM))
            {
                writer.Write(_codeBox.Text);
            }
            _codeBox.SetSavePoint();
        }

        public override void GoToLine(int lineNumber)
        {
            _codeBox.GotoPosition(_codeBox.Lines[lineNumber - 1].Position);
        }

        public override void Restyle()
        {
            _codeBox.TabWidth = _main.Settings.GetInteger("script-spaces", 4);
            _codeBox.IndentWidth = _codeBox.TabWidth;
            _codeBox.UseTabs = _main.Settings.GetBoolean("script-tabs", true);

            _useAutoComplete = _main.Settings.GetBoolean("script-autocomplete", true);
            _highlightLine = _main.Settings.GetBoolean("script-hiline", true);

            bool useFolding = _main.Settings.GetBoolean("script-fold", true);
            _codeBox.Margins[2].Width = useFolding ? 16 : 0;

            /*string fontstring = PluginManager.IDE.EditorSettings.GetString("script-font");
            if (!String.IsNullOrEmpty(fontstring))
            {
                TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
                SetFont((Font)converter.ConvertFromString(fontstring));
            }*/
        }

        public override void Activate()
        {
            _main.ShowMenus(true);
        }

        public override void Deactivate()
        {
            _main.ShowMenus(false);
        }

        public override void Cut()
        {
            _codeBox.Cut();
        }

        public override void Copy()
        {
            _codeBox.Copy();
        }

        public override void Paste()
        {
            if (_codeBox.CanPaste)
                _codeBox.Paste();
        }

        public override void Undo()
        {
            if (_codeBox.CanUndo)
                _codeBox.Undo();
        }

        public override void Redo()
        {
            if (_codeBox.CanRedo)
                _codeBox.Redo();
        }

        public override void ZoomIn()
        {
            _codeBox.ZoomIn();
        }

        public override void ZoomOut()
        {
            _codeBox.ZoomOut();
        }

        private void InitializeAutoComplete()
        {
            _codeBox.AutoCCancelAtStart = true;
            _codeBox.AutoCChooseSingle = false;
            _codeBox.AutoCIgnoreCase = true;
            _codeBox.AutoCSeparator = ';';
            _codeBox.AutoCSetFillUps("");
            _codeBox.AutoCStops("(");
        }

        private void InitializeFolding()
        {
            _codeBox.SetProperty("fold", "1");
            _codeBox.SetProperty("fold.compact", "1");
            _codeBox.AutomaticFold = AutomaticFold.Show | AutomaticFold.Click | AutomaticFold.Change;
            _codeBox.SetFoldFlags(FoldFlags.LineAfterContracted);
            _codeBox.SetFoldMarginColor(true, Color.White);
        }

        private void InitializeHighlighting()
        {
            // define colors for syntax highlighting.  the colors below were chosen to be very
            // similar to the Sphere 1.x editor.
            _codeBox.Styles[Style.BraceLight].BackColor = Color.Pink;
            _codeBox.Styles[Style.BraceBad].ForeColor = Color.Red;
            _codeBox.Styles[Style.Cpp.Character].ForeColor = Color.DarkRed;
            _codeBox.Styles[Style.Cpp.Comment].ForeColor = Color.Green;
            _codeBox.Styles[Style.Cpp.CommentDoc].ForeColor = Color.Green;
            _codeBox.Styles[Style.Cpp.CommentLine].ForeColor = Color.Green;
            _codeBox.Styles[Style.Cpp.CommentLineDoc].ForeColor = Color.DimGray;
            _codeBox.Styles[Style.Cpp.GlobalClass].ForeColor = Color.DarkMagenta;
            _codeBox.Styles[Style.Cpp.Number].ForeColor = Color.DarkRed;
            _codeBox.Styles[Style.Cpp.Operator].ForeColor = Color.Gray;
            _codeBox.Styles[Style.Cpp.Regex].ForeColor = Color.SteelBlue;
            _codeBox.Styles[Style.Cpp.String].ForeColor = Color.Teal;
            _codeBox.Styles[Style.Cpp.StringEol].ForeColor = Color.Black;
            _codeBox.Styles[Style.Cpp.StringEol].BackColor = Color.Pink;
            _codeBox.Styles[Style.Cpp.Word].ForeColor = Color.Blue;
            _codeBox.Styles[Style.Cpp.Word2].ForeColor = Color.DimGray;

            // tell Scintilla about JS keywords.  a generic lexer is used for C-like languages
            // so this unfortunately isn't done for us.
            _codeBox.SetKeywords(0, "as async await break case catch class const continue debugger default delete do else enum export extends false finally for from function get if implements import in instanceof interface let of new null package private protected public return set static super switch this throw true try typeof var void while with yield");
            _codeBox.SetKeywords(1, "arguments eval exports global module require undefined Infinity NaN"
                + " Array ArrayBuffer Boolean DataView Date Error EvalError Float32Array Float64Array Function Int8Array Int16Array Int32Array JSON Map Math Number Object Promise Proxy RangeError ReferenceError Reflect RegExp Set String Symbol SyntaxError TypeError Uint8Array Uint8ClampedArray Uint16Array Uint32Array URIError WeakMap WeakSet"
                + " decodeURI decodeURIComponent encodeURI encodeURIComponent escape isFinite isNaN parseFloat parseInt unescape");

            // load Sphere API keywords
            try
            {
                string[] apiList = File.ReadAllLines(Path.Combine(Application.StartupPath, "Dictionary/SphereAPI.txt"));
                var keywords = from line in apiList
                               let keyword = line.Trim()
                               where keyword != "" && !keyword.StartsWith("#")
                               select keyword;
                _codeBox.SetKeywords(3, string.Join(" ", keywords));
            }
            catch
            {
                // no harm done if an error occurs, we just won't get custom coloring
                // for Sphere API calls.
            }
        }

        private void InitializeMargins()
        {
            // define folding icons.  why this isn't done for us is completely beyond me.
            for (int i = Marker.FolderEnd; i <= Marker.FolderOpen; i++)
            {
                _codeBox.Markers[i].SetForeColor(SystemColors.ControlLightLight);
                _codeBox.Markers[i].SetBackColor(SystemColors.ControlDark);
            }
            _codeBox.Markers[Marker.Folder].Symbol = MarkerSymbol.BoxPlus;
            _codeBox.Markers[Marker.FolderOpen].Symbol = MarkerSymbol.BoxMinus;
            _codeBox.Markers[Marker.FolderEnd].Symbol = MarkerSymbol.BoxPlusConnected;
            _codeBox.Markers[Marker.FolderMidTail].Symbol = MarkerSymbol.TCorner;
            _codeBox.Markers[Marker.FolderOpenMid].Symbol = MarkerSymbol.BoxMinusConnected;
            _codeBox.Markers[Marker.FolderSub].Symbol = MarkerSymbol.VLine;
            _codeBox.Markers[Marker.FolderTail].Symbol = MarkerSymbol.LCorner;

            // debugging margin
            _codeBox.Margins[0].Type = MarginType.Symbol;
            _codeBox.Margins[0].Mask = Marker.MaskAll & ~Marker.MaskFolders;
            _codeBox.Margins[0].Width = 20;
            _codeBox.Margins[0].Sensitive = true;
            _codeBox.Markers[0].Symbol = MarkerSymbol.Circle;  // breakpoint marker
            _codeBox.Markers[0].SetBackColor(Color.Red);
            _codeBox.Markers[0].SetForeColor(Color.DarkRed);
            _codeBox.Markers[1].Symbol = MarkerSymbol.ShortArrow;  // next line to execute
            _codeBox.Markers[1].SetBackColor(Color.Yellow);
            _codeBox.Markers[1].SetForeColor(Color.Black);
            _codeBox.Markers[2].Symbol = MarkerSymbol.Background;  // error highlight
            _codeBox.Markers[2].SetBackColor(Color.OrangeRed);
            _codeBox.Markers[3].Symbol = MarkerSymbol.Background;  // current line highlight
            _codeBox.Markers[3].SetBackColor(Color.LightGoldenrodYellow);

            // line number margin.  dynamically resized as content changes.
            _codeBox.Margins[1].Type = MarginType.Number;
            _codeBox.Margins[1].Mask = 0x0;
            _codeBox.Styles[Style.LineNumber].ForeColor = Color.DarkCyan;
            _codeBox.Styles[Style.LineNumber].BackColor = Color.White;

            // code folding margin
            _codeBox.Margins[2].Type = MarginType.Symbol;
            _codeBox.Margins[2].Mask = Marker.MaskFolders;
            _codeBox.Margins[2].Width = 20;
            _codeBox.Margins[2].Sensitive = true;

        }

        private void codeBox_CharAdded(object sender, CharAddedEventArgs e)
        {
            if (char.IsLetter((char)e.Char) && _useAutoComplete && _codeBox.Lexer == Lexer.Cpp)
            {
                string word = _codeBox.GetWordFromPosition(_codeBox.CurrentPosition).ToLower();
                var q = from s in _main.Functions
                        where s.ToLower().Contains(word)
                        select s.Replace(";", "");
                string filter = string.Join(";", q);

                if (filter.Length > 0)
                {
                    _codeBox.AutoCShow(word.Length, filter);
                }
            }
            else if (e.Char == '}')
            {
                int curLine = _codeBox.LineFromPosition(_codeBox.CurrentPosition);

                if (_codeBox.Lines[curLine].Text.Trim() == "}")
                {
                    _codeBox.Lines[curLine].Indentation -= _codeBox.IndentWidth;
                }
            }
        }

        private void codeBox_InsertCheck(object sender, InsertCheckEventArgs e)
        {
            if (e.Text.EndsWith("\r") || e.Text.EndsWith("\n"))
            {
                int startPos = _codeBox.Lines[_codeBox.LineFromPosition(_codeBox.CurrentPosition)].Position;
                int endPos = e.Position;
                string curLineText = _codeBox.GetTextRange(startPos, (endPos - startPos));

                Match indent = Regex.Match(curLineText, "^[ \\t]*");
                e.Text = (e.Text + indent.Value);
                if (Regex.IsMatch(curLineText, "{\\s*$"))
                {
                    e.Text = (e.Text + "\t");
                }
            }
        }

        private void codebox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9 && e.Modifiers == 0x0)
            {
                e.Handled = true;
                var line = _codeBox.Lines[_codeBox.CurrentLine];
                var markers = line.MarkerGet();
                bool isSet = (markers & 0x01) == 0;
                OnBreakpointChanged(new BreakpointChangedEventArgs(line.Index + 1, isSet));
                if (isSet)
                    line.MarkerAdd(0);
                else
                    line.MarkerDelete(0);
            }
        }

        private void codeBox_MarginClick(object sender, MarginClickEventArgs e)
        {
            if (e.Margin == 0)
            {
                var line = _codeBox.Lines[_codeBox.LineFromPosition(e.Position)];
                bool isSet = (line.MarkerGet() & 0x01) == 0;
                OnBreakpointChanged(new BreakpointChangedEventArgs(line.Index + 1, isSet));
                if (isSet)
                    line.MarkerAdd(0);
                else
                    line.MarkerDelete(0);
            }
        }

        private void codeBox_UpdateUI(object sender, UpdateUIEventArgs e)
        {
            const string openBraces = "([{";
            const string closeBraces = ")]}";

            var caretPos = _codeBox.CurrentPosition;
            if (caretPos != _lastCaretPos)
            {
                int lastLine = _codeBox.LineFromPosition(_lastCaretPos);
                int currentLine = _codeBox.LineFromPosition(caretPos);
                _codeBox.MarkerDeleteAll(3);
                if (_highlightLine)
                    _codeBox.Lines[currentLine].MarkerAdd(3);
                char charBefore = (char)_codeBox.GetCharAt(caretPos - 1);
                char charAfter = (char)_codeBox.GetCharAt(caretPos);
                int brace1Pos = Scintilla.InvalidPosition;
                if (closeBraces.Contains(charBefore))
                    brace1Pos = caretPos - 1;
                else if (openBraces.Contains(charAfter))
                    brace1Pos = caretPos;
                if (brace1Pos != Scintilla.InvalidPosition)
                {
                    int brace2Pos = _codeBox.BraceMatch(brace1Pos);
                    if (brace2Pos != Scintilla.InvalidPosition)
                        _codeBox.BraceHighlight(brace1Pos, brace2Pos);
                    else
                        _codeBox.BraceBadLight(brace1Pos);
                }
                else
                {
                    _codeBox.BraceHighlight(Scintilla.InvalidPosition, Scintilla.InvalidPosition);
                }
                _lastCaretPos = caretPos;
            }
        }
    }
}
