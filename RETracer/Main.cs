using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using Nabu.Forms.TextObjectModel;
using RegExTracer;

#pragma warning disable CS0162

namespace RETracer;

public partial class Main : Form
{
    const string FILE_REGEX = "regex.txt";
    const string FILE_INPUT = "input.txt";

    string?      _documentFile;
    bool         _documentIsUnsaved;
    bool         _isHighlighting;
    RichTextBox? _textBoxCurrent;

    readonly Settings _settings = Settings.Load();

    public Main()
    {
        InitializeComponent();
        setCurrentTextBox(null);
        txREGEX.ForeColor  = _settings.ForeColor;
        txREGEX.BackColor  = _settings.BackColor;
        txREGEX.Font       = new Font(txREGEX.Font.FontFamily, _settings.TextSize);
        txDATA.ForeColor   = _settings.ForeColor;
        txDATA.BackColor   = _settings.BackColor;
        txDATA.Font        = new Font(txDATA.Font.FontFamily, _settings.TextSize);
        txRESULT.ForeColor = _settings.ForeColor;
        txRESULT.BackColor = _settings.BackColor;
        txRESULT.Font      = new Font(txRESULT.Font.FontFamily, _settings.TextSize);
        _isHighlighting    = true;
        _isHighlighting    = false;
        _documentIsUnsaved = false;
    }

    void ApplyHighlightInput(Range[][][] matchList, string textInput, string[] textInputLineList)
    {
        clearHighlightInput();
        var inputArray = new HighlightingInput[4];
        inputArray[1] = HighlightingInput.Unicolor;
        inputArray[2] = HighlightingInput.MulticolorSinglePass;
        inputArray[3] = HighlightingInput.MulticolorMultiPass;
        var input = inputArray[2];

        var textDocument = txDATA.TextDocument;
        textDocument!.Freeze();
        var range = textDocument.Range(0, txDATA.TextLength);
        range.Para.SpaceBefore = 1f;
        range.Para.SpaceAfter  = 1f;
        int[] numArray;
        switch (coLINE_BREAKS.Checked)
        {
            case false:
                numArray = new int[txDATA.TextLength + 1];
                for (int j = 0; j < numArray.Length; j++) numArray[j] = j;
                break;

            case true:
            {
                numArray = new int[txDATA.TextLength + textInputLineList.Length + 1];
                int num2 = 0;
                for (var k = 0; k < textInputLineList.Length; k++)
                {
                    int length                                                = textInputLineList[k].Length;
                    for (int m = 0; m < length; m++) numArray[(num2 + m) + k] = num2 + m;
                    numArray[(num2 + length) + k] =  num2   + length;
                    num2                          += length + 1;
                }

                break;
            }
        }

        var flagArray = new bool[textInput.Length];
        foreach (var match in matchList)
        {
            for (var n = 1; n < match.Length; n++)
            {
                for (var num8 = 0; num8 < match[n].Length; num8++)
                {
                    ITextFont font;
                    int       num11;
                    Range     range2   = match[n][num8];
                    int       charFrom = numArray[range2.From];
                    int       charTo   = numArray[range2.To];
                    switch (input)
                    {
                        case HighlightingInput.None: continue;
                        case HighlightingInput.Unicolor:
                        {
                            font = textDocument.Range(charFrom, charTo).Font;
                            if (_settings.HighlighingType == HighlighingType.ForeGround) goto Label_01F4;

                            continue;
                        }
                        case HighlightingInput.MulticolorSinglePass:
                            num11 = charFrom;
                            goto Label_02D1;

                        case HighlightingInput.MulticolorMultiPass:
                        {
                            font = textDocument.Range(charFrom, charTo).Font;
                            switch (_settings.HighlighingType)
                            {
                                case HighlighingType.BackGround:
                                    goto Label_0312;

                                case HighlighingType.ForeGround:
                                    goto Label_0346;
                            }

                            continue;
                        }
                        default:
                        {
                            continue;
                        }
                    }

                    font.BackColor = _settings.HighlightColorList[0].RtfColor();
                    continue;
                Label_01F4:
                    font.ForeColor = _settings.HighlightColorList[0].RtfColor();
                    continue;
                Label_0220:
                    if (!flagArray[num11])
                    {
                        font = textDocument.Range(num11, num11 + 1).Font;
                        switch (_settings.HighlighingType)
                        {
                            case HighlighingType.BackGround:
                                font.BackColor = _settings.HighlightColorList[(n - 1) % _settings.HighlightColorList.Count].RtfColor();
                                break;

                            case HighlighingType.ForeGround:
                                font.ForeColor = _settings.HighlightColorList[(n - 1) % _settings.HighlightColorList.Count].RtfColor();
                                break;
                        }

                        flagArray[num11] = true;
                    }

                    num11++;
                Label_02D1:
                    if (num11 < charTo) goto Label_0220;
                    continue;
                Label_0312:
                    font.BackColor = _settings.HighlightColorList[(n - 1) % _settings.HighlightColorList.Count].RtfColor();
                    continue;
                Label_0346:
                    font.ForeColor = _settings.HighlightColorList[(n - 1) % _settings.HighlightColorList.Count].RtfColor();
                }
            }
        }

        textDocument.Unfreeze();
    }

    void ApplyHighlightRegEx()
    {
        clearHighlightRegEx();
        var exArray = new HighlightingRegEx[3];
        exArray[1] = HighlightingRegEx.Braces;
        exArray[2] = HighlightingRegEx.Groups;
        var ex           = exArray[2];
        var textDocument = txREGEX.TextDocument!;
        textDocument.Freeze();
        var range = textDocument.Range(0, txREGEX.TextLength);
        range.Para.SpaceBefore = 1f;
        range.Para.SpaceAfter  = 1f;
        var text  = txREGEX.Text;
        var stack = new Stack<RegExParserState>();
        stack.Push(RegExParserState.Default);
        int num = 0;
        for (int i = 0; i < text.Length; i++)
        {
            Color transparent = Color.Transparent;
            switch (stack.Peek())
            {
                case RegExParserState.Default:
                    switch (text[i])
                    {
                        case '[': goto Label_00F3;
                        case '(': goto Label_0100;
                    }

                    goto Label_023D;

                case RegExParserState.Group:
                    switch (text[i])
                    {
                        case '(':  goto Label_0177;
                        case ')':  goto Label_01A1;
                        case '[':  goto Label_016A;
                        case '\\': goto Label_015D;
                    }

                    goto Label_023D;

                case RegExParserState.EscapeSequense:
                    stack.Pop();
                    goto Label_023D;

                case RegExParserState.SymbolSet:
                    switch (text[i])
                    {
                        case '[':  goto Label_022B;
                        case '\\': goto Label_0221;
                        case ']':  goto Label_0235;
                    }

                    goto Label_023D;

                default:
                    goto Label_023D;
            }

            stack.Push(RegExParserState.EscapeSequense);
            goto Label_023D;
        Label_00F3:
            stack.Push(RegExParserState.SymbolSet);
            goto Label_023D;
        Label_0100:
            if (ex == HighlightingRegEx.Braces)
                transparent = _settings.HighlightColorList[0];

            stack.Push(RegExParserState.Group);
            num++;
            goto Label_023D;
        Label_015D:
            stack.Push(RegExParserState.EscapeSequense);
            goto Label_023D;
        Label_016A:
            stack.Push(RegExParserState.SymbolSet);
            goto Label_023D;
        Label_0177:
            if (ex == HighlightingRegEx.Braces)
                transparent = _settings.HighlightColorList[0];

            stack.Push(RegExParserState.Group);
            num++;
            goto Label_023D;
        Label_01A1:
            switch (ex)
            {
                case HighlightingRegEx.Braces:
                    transparent = _settings.HighlightColorList[0];
                    break;

                case HighlightingRegEx.Groups:
                    transparent = _settings.HighlightColorList[(num - 1) % _settings.HighlightColorList.Count];
                    break;
            }

            stack.Pop();
            num--;
            goto Label_023D;
        Label_0221:
            stack.Push(RegExParserState.EscapeSequense);
            goto Label_023D;
        Label_022B:
            stack.Push(RegExParserState.SymbolSet);
            goto Label_023D;
        Label_0235:
            stack.Pop();
        Label_023D:
            var range2 = textDocument.Range(i, i + 1);
            if (num == 0)
            {
                if (transparent == Color.Transparent)
                    switch (_settings.HighlighingType)
                    {
                        case HighlighingType.BackGround:
                            transparent = txREGEX.BackColor;
                            goto Label_031B;

                        case HighlighingType.ForeGround:
                            transparent = txREGEX.ForeColor;
                            goto Label_031B;
                    }
            }
            else if (transparent == Color.Transparent)
                switch (ex)
                {
                    case HighlightingRegEx.Braces:
                        switch (_settings.HighlighingType)
                        {
                            case HighlighingType.BackGround:
                                transparent = txREGEX.BackColor;
                                goto Label_031B;

                            case HighlighingType.ForeGround:
                                transparent = txREGEX.ForeColor;
                                goto Label_031B;
                        }

                        goto Label_031B;

                    case HighlightingRegEx.Groups:
                        transparent = _settings.HighlightColorList[(num - 1) % _settings.HighlightColorList.Count];
                        goto Label_031B;
                }

        Label_031B:
            switch (_settings.HighlighingType)
            {
                case HighlighingType.BackGround:
                    range2.Font.BackColor = transparent.RtfColor();
                    break;

                case HighlighingType.ForeGround:
                    range2.Font.ForeColor = transparent.RtfColor();
                    break;
            }
        }

        textDocument.Unfreeze();
    }

    void ApplyHighlightResult(Range[][][] matchList, string textInput)
    {
        clearHighlightResult(null);
        txRESULT.ReadOnly = false;

        var textDocument = txRESULT.TextDocument!;
        textDocument.Freeze();
        textDocument.New();

        var selection = textDocument.Selection;
        selection.Para.SpaceBefore = 1f;
        selection.Para.SpaceAfter  = 1f;

        var r = new List<List<string>>();

        for (int i = 0; i < matchList.Length; i++)
        {
            var font = selection.Font;
            font.BackColor = txRESULT.BackColor.RtfColor();
            font.Size      = 1.0f * txRESULT.Font.Size;

            selection.Text      = textInput.Substring(matchList[i][0][0].From, matchList[i][0][0].Length) + "\r\n";
            selection.Start     = selection.End;
            selection.Font.Size = txRESULT.Font.Size;
            selection.Text      = "\t";
            selection.Start     = selection.End;

            var l = new List<string>();
            for (int j = 1; j < matchList[i].Length; j++)
            {
                var color = _settings.HighlightColorList[(j - 1) % _settings.HighlightColorList.Count];

                for (int k = 0; k < matchList[i][j].Length; k++)
                {
                    if (k > 0)
                    {
                        font            = selection.Font;
                        font.ForeColor  = txRESULT.ForeColor.RtfColor();
                        font.BackColor  = txRESULT.BackColor.RtfColor();
                        selection.Text  = " ";
                        selection.Start = selection.End;
                    }

                    Range range = matchList[i][j][k];
                    switch (_settings.HighlighingType)
                    {
                        case HighlighingType.BackGround:
                            selection.Font.BackColor = color.RtfColor();
                            break;
                        case HighlighingType.ForeGround:
                            selection.Font.ForeColor = color.RtfColor();
                            break;
                    }

                    font      = selection.Font;
                    font.Size = txRESULT.Font.Size;
                    if (range.Length != 0)
                    {
                        font.Italic = FormatFlags.False;
                        l.Add((selection.Text = $" {textInput.Substring(range.Offset, range.Length)} ").Trim());
                    }
                    else
                    {
                        font.Italic    = FormatFlags.True;
                        selection.Text = " <empty> ";
                        l.Add("");
                    }

                    selection.Start = selection.End;
                }
            }

            selection.Text  = "\r\n";
            selection.Start = selection.End;
            r.Add(l);
        }

        lvRESULT.Items.Clear();
        lvRESULT.Columns.Clear();
        if (r.Any())
        {
            var maxCols = r.Max(p => p.Count());
            for (var i = 0; i < maxCols; i++)
                lvRESULT.Columns.Add("C" + i, "#" + i, lvRESULT.Width / maxCols);

            foreach (var row in r.Where(p => p.Any()))
            {
                var first = row[0];
                var lvi   = new ListViewItem(first);
                for (var i = 1; i < row.Count; i++) lvi.SubItems.Add(row[i]);
                lvRESULT.Items.Add(lvi);
            }
        }

        textDocument.Unfreeze();
        txRESULT.ReadOnly = true;
    }

    bool buildMatchList(string textRegEx, string textInput, out Range[][][] matchList, out string errorMessage)
    {
        matchList    = Array.Empty<Range[][]>();
        errorMessage = null!;
        try
        {
            var flags = (coECMA.Checked ? RegexOptions.ECMAScript : RegexOptions.None)          |
                        (coSINGLE_LINE.Checked ? RegexOptions.Singleline : RegexOptions.None)   |
                        (coEXPLICIT.Checked ? RegexOptions.ExplicitCapture : RegexOptions.None) |
                        (coGNORE_CASE.Checked ? RegexOptions.IgnoreCase : RegexOptions.None)    |
                        (coMULTILINE.Checked ? RegexOptions.Multiline : RegexOptions.None)      |
                        (coIGNORE.Checked ? RegexOptions.IgnorePatternWhitespace : RegexOptions.None);

            var matches = new Regex(textRegEx, flags).Matches(textInput);
            matchList = new Range[matches.Count][][];
            for (int i = 0; i < matches.Count; i++)
            {
                var match = matches[i];
                matchList[i] = new Range[match.Groups.Count][];
                for (int j = 0; j < match.Groups.Count; j++)
                {
                    var group = match.Groups[j];
                    matchList[i][j] = new Range[group.Captures.Count];
                    for (var k = 0; k < group.Captures.Count; k++)
                        matchList[i][j][k] = new Range(group.Captures[k].Index, group.Captures[k].Length);
                }
            }
        }
        catch (Exception exception)
        {
            errorMessage = exception.Message;
        }

        return errorMessage == null;
    }

    void BuildResult(BuildReason buildReason)
    {
        var lines     = txDATA.Lines;
        var textInput = string.Join(!coLINE_BREAKS.Checked ? "\n" : "\r\n", lines);

        if (buildMatchList(txREGEX.Text.Replace("\r", "").Replace("\n", ""), textInput, out var rangeArray, out var errMessage))
        {
            if (buildReason is BuildReason.Document or BuildReason.RegEx) ApplyHighlightRegEx();
            if (buildReason is BuildReason.Document or BuildReason.Input) ApplyHighlightInput(rangeArray, textInput, lines);
            ApplyHighlightResult(rangeArray, textInput);
        }
        else
        {
            clearHighlightRegEx();
            clearHighlightInput();
            clearHighlightResult(errMessage);
        }
    }

    void CheckOption_CheckedChanged(object sender, EventArgs e)
    {
        if (sender == coLINE_BREAKS) txDATA.WordWrap = coLINE_BREAKS.Checked;
        if (!_isHighlighting)
        {
            _isHighlighting = true;
            BuildResult(BuildReason.Document);
            _isHighlighting = false;
        }

        _documentIsUnsaved = true;
    }

    void clearHighlightInput()
    {
        var range = txDATA.TextDocument!.Range(0, txDATA.TextLength);
        var font  = range.Font;
        var para  = range.Para;
        para.SpaceBefore = 0f;
        para.SpaceAfter  = 0f;
        font.BackColor   = txREGEX.BackColor.RtfColor();
        font.ForeColor   = txREGEX.ForeColor.RtfColor();
        font.Bold        = FormatFlags.False;
    }

    void clearHighlightRegEx()
    {
        var range = txREGEX.TextDocument!.Range(0, txREGEX.TextLength);
        var font  = range.Font;
        var para  = range.Para;
        para.SpaceBefore = 0f;
        para.SpaceAfter  = 0f;
        font.BackColor   = txREGEX.BackColor.RtfColor();
        font.ForeColor   = txREGEX.ForeColor.RtfColor();
        font.Bold        = FormatFlags.False;
    }

    void clearHighlightResult(string? errorMessage)
    {
        txRESULT.ReadOnly = false;
        var textDocument = txRESULT.TextDocument!;
        textDocument.New();
        var selection = textDocument.Selection;
        var font      = selection.Font;
        var para      = selection.Para;

        if (errorMessage == null)
        {
            para.SpaceBefore = 0f;
            para.SpaceAfter  = 0f;
            para.Alignment   = AlignmentFlags.AlignLeft;
            font.ForeColor   = txRESULT.ForeColor.RtfColor();
            font.BackColor   = txRESULT.BackColor.RtfColor();
            font.Italic      = FormatFlags.False;
            font.Bold        = FormatFlags.False;
        }
        else
        {
            para.SpaceBefore = 1f;
            para.SpaceAfter  = 1f;
            para.Alignment   = AlignmentFlags.AlignCenter;
            font.Size        = 1.0f * txRESULT.Font.Size;
            font.ForeColor   = txRESULT.BackColor.RtfColor();
            font.BackColor   = txRESULT.ForeColor.RtfColor();
            font.Bold        = FormatFlags.True;
            font.Italic      = FormatFlags.False;
            selection.Text   = $" {errorMessage} ";
        }

        txRESULT.ReadOnly = true;
    }

    bool documentOpen(string? filename)
    {
        if (filename == null)
        {
            if (_openFileDialog.ShowDialog(this) != DialogResult.OK) return false;
            filename = _openFileDialog.FileName;
        }

        var serializer = new XmlSerializer(typeof(RegExDocument));
        using (Stream stream = new FileStream(filename, FileMode.Open, FileAccess.Read))
        {
            var document = (RegExDocument) serializer.Deserialize(stream)!;
            txREGEX.Lines         = document.RegExValue.Split(new char[] {'\r', '\n'}, StringSplitOptions.RemoveEmptyEntries);
            txDATA.Lines          = document.InputValue.Split(new char[] {'\r', '\n'}, StringSplitOptions.RemoveEmptyEntries);
            coECMA.Checked        = document.OptionECMAScript;
            coSINGLE_LINE.Checked = document.OptionSingleLine;
            coEXPLICIT.Checked    = document.OptionExplicitCapture;
            coGNORE_CASE.Checked  = document.OptionIgnoreCase;
            coMULTILINE.Checked   = document.OptionMultiline;
            coIGNORE.Checked      = document.OptionIgnoreWhitespace;
        }

        _documentFile = filename;
        return true;
    }

    bool documentSave(string? filename)
    {
        if (filename == null)
        {
            if (_saveFileDialog.ShowDialog() != DialogResult.OK) return false;
            filename = _saveFileDialog.FileName;
        }

        XmlSerializer serializer = new XmlSerializer(typeof(RegExDocument));
        using (Stream stream = new FileStream(filename, FileMode.Create, FileAccess.Write))
        {
            var o = new RegExDocument(txREGEX.Text, txDATA.Text, 2,
                                      coECMA.Checked, coSINGLE_LINE.Checked, coEXPLICIT.Checked, coGNORE_CASE.Checked, false, coMULTILINE.Checked, coLINE_BREAKS.Checked, coIGNORE.Checked);
            serializer.Serialize(stream, o);
        }

        _documentFile = filename;
        return true;
    }

    void FormMain_FormClosing(object sender, FormClosingEventArgs e)
    {
        var r = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "RegEx");
        if (!Directory.Exists(r)) Directory.CreateDirectory(r);

        File.WriteAllText(Path.Combine(r, FILE_REGEX), txREGEX.Text);
        File.WriteAllText(Path.Combine(r, FILE_INPUT), txDATA.Text);
    }

    void MenuItemEditCopy_Click(object sender, EventArgs e)
    {
        var currentTextBox = _textBoxCurrent;
        if (currentTextBox != null)
            Clipboard.SetDataObject(currentTextBox.SelectionLength > 0 ? currentTextBox.SelectedText : currentTextBox.Text);
    }

    void MenuItemEditCopyCSharpCode_Click(object sender, EventArgs e)
    {
        var box = txREGEX;
        if (box == null) return;

        var selectedText = box.SelectionLength > 0 ? box.SelectedText : box.Text;
        selectedText = selectedText.Replace("\r", "").Replace("\n", "").Replace("\"", "\"\"");
        string str2 = "0";
        if (coECMA.Checked)
            str2 = str2 + " | RegexOptions.ECMAScript";

        if (coSINGLE_LINE.Checked)
            str2 = str2 + " | RegexOptions.Singleline";

        if (coEXPLICIT.Checked)
            str2 = str2 + " | RegexOptions.ExplicitCapture";

        if (coGNORE_CASE.Checked)
            str2 = str2 + " | RegexOptions.IgnoreCase";

        if (coMULTILINE.Checked)
            str2 = str2 + " | RegexOptions.Multiline";

        if (coIGNORE.Checked)
            str2 = str2 + " | RegexOptions.IgnorePatternWhitespace";

        if (str2.StartsWith("0 | "))
            str2 = str2.Substring(4);

        Clipboard.SetDataObject($"Regex regEx = new Regex(@\"{selectedText}\", {str2});");
    }

    void MenuItemEditCut_Click(object sender, EventArgs e)
    {
        var currentTextBox = _textBoxCurrent;
        if (currentTextBox is not {SelectionLength: > 0}) return;

        Clipboard.SetDataObject(currentTextBox.SelectedText);
        currentTextBox.SelectedText = string.Empty;
    }

    void MenuItemEditPaste_Click(object sender, EventArgs e)
    {
        if (_textBoxCurrent == null) return;
        if (Clipboard.ContainsText(TextDataFormat.UnicodeText)) _textBoxCurrent.SelectedText = Clipboard.GetText(TextDataFormat.UnicodeText);
        else if (Clipboard.ContainsText(TextDataFormat.Text)) _textBoxCurrent.SelectedText   = Clipboard.GetText(TextDataFormat.Text);
    }

    void MenuItemEditRedo_Click(object sender, EventArgs e) => _textBoxCurrent?.Redo();

    void MenuItemEditSelectAll_Click(object sender, EventArgs e)
    {
        if (_textBoxCurrent == null) return;
        _textBoxCurrent.SelectionStart  = 0;
        _textBoxCurrent.SelectionLength = _textBoxCurrent.TextLength;
    }

    void MenuItemEditUndo_Click(object sender, EventArgs e) => _textBoxCurrent?.Undo();

    void MenuItemFileExit_Click(object sender, EventArgs e) => Close();

    void MenuItemFileNew_Click(object sender, EventArgs e)
    {
        txREGEX.Text   = string.Empty;
        txDATA.Text    = string.Empty;
        coECMA.Checked = coSINGLE_LINE.Checked = coEXPLICIT.Checked = coGNORE_CASE.Checked = coMULTILINE.Checked = coLINE_BREAKS.Checked = coIGNORE.Checked = false;
    }

    void MenuItemFileOpen_Click(object sender, EventArgs e)
    {
        if (_documentIsUnsaved && (MessageBox.Show(this, "Do you want to save changes you made?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes))
            _menuItemFileSave.PerformClick();

        _isHighlighting = true;
        documentOpen(null);
        BuildResult(BuildReason.Document);
        _isHighlighting    = false;
        _documentIsUnsaved = false;
    }

    void MenuItemFileSave_Click(object sender, EventArgs e)
    {
        documentSave(_documentFile);
        _documentIsUnsaved = false;
    }

    void MenuItemFileSaveAs_Click(object sender, EventArgs e)
    {
        documentSave(null);
        _documentIsUnsaved = false;
    }

    void MenuItemToolsOptions_Click(object sender, EventArgs e)
    {
        if (new OptionsForm(_settings).ShowDialog(this) != DialogResult.OK) return;

        txREGEX.ForeColor  = _settings.ForeColor;
        txREGEX.BackColor  = _settings.BackColor;
        txREGEX.Font       = new Font(txREGEX.Font.FontFamily, _settings.TextSize);
        txDATA.ForeColor   = _settings.ForeColor;
        txDATA.BackColor   = _settings.BackColor;
        txDATA.Font        = new Font(txDATA.Font.FontFamily, _settings.TextSize);
        txRESULT.ForeColor = _settings.ForeColor;
        txRESULT.BackColor = _settings.BackColor;
        txRESULT.Font      = new Font(txRESULT.Font.FontFamily, _settings.TextSize);

        _isHighlighting = true;
        BuildResult(BuildReason.Document);
        _isHighlighting = false;
    }


    void setCurrentTextBox(RichTextBox? textBox)
    {
        _textBoxCurrent = textBox;
        if (_textBoxCurrent != null)
        {
            _menuItemEditUndo.Enabled     = _menuItemEditRedo.Enabled = _menuItemEditCut.Enabled = _menuItemEditCopy.Enabled = _menuItemEditPaste.Enabled = _menuItemEditSelectAll.Enabled = true;
            _menuItemEditUndo.ToolTipText = string.Format((string) _menuItemEditUndo.Tag, _textBoxCurrent.UndoActionName);
            _menuItemEditRedo.ToolTipText = string.Format((string) _menuItemEditRedo.Tag, _textBoxCurrent.RedoActionName);
        }
        else
        {
            _menuItemEditUndo.Enabled     = _menuItemEditRedo.Enabled = _menuItemEditCut.Enabled = _menuItemEditCopy.Enabled = _menuItemEditPaste.Enabled = _menuItemEditSelectAll.Enabled = false;
            _menuItemEditUndo.ToolTipText = string.Empty;
            _menuItemEditRedo.ToolTipText = string.Empty;
        }
    }

    void textInput_Enter(object sender, EventArgs e) => setCurrentTextBox(txDATA);

    void textInput_Leave(object sender, EventArgs e) => setCurrentTextBox(null);

    void TextInput_TextChanged(object sender, EventArgs e)
    {
        if (!_isHighlighting)
        {
            _isHighlighting = true;
            BuildResult(BuildReason.Input);
            _isHighlighting = false;
        }

        _documentIsUnsaved            = true;
        _menuItemEditUndo.ToolTipText = string.Format((string) _menuItemEditUndo.Tag, txDATA.UndoActionName);
        _menuItemEditRedo.ToolTipText = string.Format((string) _menuItemEditRedo.Tag, txDATA.RedoActionName);
    }

    void TextRegEx_Enter(object sender, EventArgs e) => setCurrentTextBox(txREGEX);

    void TextRegEx_Leave(object sender, EventArgs e) => setCurrentTextBox(null);

    void TextRegEx_TextChanged(object sender, EventArgs e)
    {
        if (!_isHighlighting)
        {
            _isHighlighting = true;
            BuildResult(BuildReason.Document);
            _isHighlighting = false;
        }

        _documentIsUnsaved            = true;
        _menuItemEditUndo.ToolTipText = string.Format((string) _menuItemEditUndo.Tag, txREGEX.UndoActionName);
        _menuItemEditRedo.ToolTipText = string.Format((string) _menuItemEditRedo.Tag, txREGEX.RedoActionName);
    }

    void FormMain_Load(object sender, EventArgs e)
    {
        if (DesignMode) return;
        var r = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "RegEx");
        if (!Directory.Exists(r)) return;

#if DEBUG
        var f                            = Path.Combine(r, FILE_REGEX);
        if (File.Exists(f)) txREGEX.Text = File.ReadAllText(f);
        f = Path.Combine(r, FILE_INPUT);
        if (File.Exists(f)) txDATA.Text = File.ReadAllText(f);
#else
            txREGEX.Text = "";
            txDATA.Text = "";
#endif
        TextRegEx_TextChanged(sender, e);
    }

    void btnCOLLAPSE_Click(object sender, EventArgs e)
    {
        spcRESULT.Panel2Collapsed = !spcRESULT.Panel2Collapsed;
    }

    void lvRESULT_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.A && e.Control)
        {
            lvRESULT.SelectedItems.Clear();
            for (var i = 0; i < lvRESULT.Items.Count; i++) lvRESULT.SelectedIndices.Add(i);
        }
        else if ((e.KeyCode == Keys.Insert || e.KeyCode == Keys.C) && e.Control)
        {
            var sb = new StringBuilder();
            foreach (var row in lvRESULT.Items.Cast<ListViewItem>())
                sb.AppendLine(row.SubItems.Cast<ListViewItem.ListViewSubItem>().Select(p => p.Text).Aggregate((acc, sel) => acc + "\t" + sel));
            if (sb.Length > 0) Clipboard.Clear();
            else Clipboard.SetText(sb.ToString(), TextDataFormat.Text);
        }
    }

    #region internals

    enum BuildReason
    {
        Document,
        RegEx,
        Input
    }

    enum HighlightingInput
    {
        None,
        Unicolor,
        MulticolorSinglePass,
        MulticolorMultiPass
    }

    enum HighlightingRegEx
    {
        None,
        Braces,
        Groups
    }

    class Range
    {
        public Range(int offset, int length)
        {
            From   = offset;
            Length = length;
        }

        public int From   { get; set; }
        public int Length { get; set; }

        public int Offset => From;
        public int To     => (From + Length);
    }

    enum RegExParserState
    {
        Default,
        Group,
        EscapeSequense,
        SymbolSet
    }

    #endregion
}