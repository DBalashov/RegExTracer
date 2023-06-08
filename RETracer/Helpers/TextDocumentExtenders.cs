using System.Text.RegularExpressions;
using Nabu.Forms;
using Nabu.Forms.TextObjectModel;
using RegExTracer;

namespace RETracer;

static class TextDocumentExtenders
{
    public static void ClearHighlightInput(this RichTextBoxEx txREGEX, RichTextBoxEx txDATA)
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

    public static void ClearHighlightRegEx(this RichTextBoxEx txREGEX)
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

    public static void ClearHighlightResult(this RichTextBoxEx txRESULT, string? errorMessage)
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

    public static void ApplyHighlightInput(this RichTextBoxEx txREGEX,   RichTextBoxEx txDATA,    bool   lineBreaks,
                                           Settings           _settings, Range[][][]   matchList, string textInput, string[] textInputLineList)
    {
        txREGEX.ClearHighlightInput(txDATA);
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
        switch (lineBreaks)
        {
            case false:
                numArray = new int[txDATA.TextLength + 1];
                for (var j = 0; j < numArray.Length; j++) numArray[j] = j;
                break;

            case true:
            {
                numArray = new int[txDATA.TextLength + textInputLineList.Length + 1];
                var nextVal = 0;
                for (var k = 0; k < textInputLineList.Length; k++)
                {
                    var length = textInputLineList[k].Length;
                    for (int m = 0; m < length; m++)
                        numArray[(nextVal + m) + k] = nextVal + m;
                    numArray[(nextVal + length) + k] =  nextVal + length;
                    nextVal                          += length  + 1;
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

    public static void ApplyHighlightResult(this RichTextBoxEx txRESULT, ListView lvRESULT, Settings _settings, Range[][][] matchList, string textInput)
    {
        txRESULT.ClearHighlightResult(null);
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
                for (var i = 1; i < row.Count; i++)
                    lvi.SubItems.Add(row[i]);
                lvRESULT.Items.Add(lvi);
            }
        }

        textDocument.Unfreeze();
        txRESULT.ReadOnly = true;
    }

    public static bool BuildMatchList(string textRegEx, string textInput, RegexOptions flags, out Range[][][] matchList, out string errorMessage)
    {
        matchList    = Array.Empty<Range[][]>();
        errorMessage = null!;
        try
        {
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

    public static void ApplyHighlightRegEx(this RichTextBoxEx txREGEX, Settings _settings)
    {
        txREGEX.ClearHighlightRegEx();
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
            var transparent = Color.Transparent;
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
}

enum HighlightingRegEx
{
    None,
    Braces,
    Groups
}

enum RegExParserState
{
    Default,
    Group,
    EscapeSequense,
    SymbolSet
}

enum HighlightingInput
{
    None,
    Unicolor,
    MulticolorSinglePass,
    MulticolorMultiPass
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

enum BuildReason
{
    Document,
    RegEx,
    Input
}