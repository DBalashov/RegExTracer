using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
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

    void CheckOption_CheckedChanged(object sender, EventArgs e)
    {
        if (sender == coLINE_BREAKS) txDATA.WordWrap = coLINE_BREAKS.Checked;
        if (!_isHighlighting)
        {
            _isHighlighting = true;
            buildResult(BuildReason.Document);
            _isHighlighting = false;
        }

        _documentIsUnsaved = true;
    }

    void buildResult(BuildReason buildReason)
    {
        var lines     = txDATA.Lines;
        var textInput = string.Join(!coLINE_BREAKS.Checked ? "\n" : "\r\n", lines);

        var flags = (coECMA.Checked ? RegexOptions.ECMAScript : RegexOptions.None)          |
                    (coSINGLE_LINE.Checked ? RegexOptions.Singleline : RegexOptions.None)   |
                    (coEXPLICIT.Checked ? RegexOptions.ExplicitCapture : RegexOptions.None) |
                    (coGNORE_CASE.Checked ? RegexOptions.IgnoreCase : RegexOptions.None)    |
                    (coMULTILINE.Checked ? RegexOptions.Multiline : RegexOptions.None)      |
                    (coIGNORE.Checked ? RegexOptions.IgnorePatternWhitespace : RegexOptions.None);

        if (TextDocumentExtenders.BuildMatchList(txREGEX.Text.Replace("\r", "").Replace("\n", ""), textInput, flags, out var rangeArray, out var errMessage))
        {
            if (buildReason is BuildReason.Document or BuildReason.RegEx) txREGEX.ApplyHighlightRegEx(_settings);
            if (buildReason is BuildReason.Document or BuildReason.Input) txREGEX.ApplyHighlightInput(txDATA, coLINE_BREAKS.Checked, _settings, rangeArray, textInput, lines);
            txRESULT.ApplyHighlightResult(lvRESULT, _settings, rangeArray, textInput);
        }
        else
        {
            txREGEX.ClearHighlightRegEx();
            txREGEX.ClearHighlightInput(txDATA);
            txRESULT.ClearHighlightResult(errMessage);
        }
    }

    #region documentOpen / documentSave

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

    #endregion

    void FormMain_FormClosing(object sender, FormClosingEventArgs e)
    {
        var r = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "RegEx");
        if (!Directory.Exists(r)) Directory.CreateDirectory(r);

        File.WriteAllText(Path.Combine(r, FILE_REGEX), txREGEX.Text);
        File.WriteAllText(Path.Combine(r, FILE_INPUT), txDATA.Text);
    }

    #region menu

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
        buildResult(BuildReason.Document);
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
        buildResult(BuildReason.Document);
        _isHighlighting = false;
    }

    #endregion

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
            buildResult(BuildReason.Input);
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
            buildResult(BuildReason.Document);
            _isHighlighting = false;
        }

        _documentIsUnsaved            = true;
        _menuItemEditUndo.ToolTipText = string.Format((string) _menuItemEditUndo.Tag, txREGEX.UndoActionName);
        _menuItemEditRedo.ToolTipText = string.Format((string) _menuItemEditRedo.Tag, txREGEX.RedoActionName);
    }

    void FormMain_Load(object sender, EventArgs e)
    {
        if (DesignMode) return;

        txREGEX.Text = "";

        txDATA.Text = "";

        var r = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "RegEx");
        if (!Directory.Exists(r)) return;

        var f                            = Path.Combine(r, FILE_REGEX);
        if (File.Exists(f)) txREGEX.Text = File.ReadAllText(f);
        f = Path.Combine(r, FILE_INPUT);
        if (File.Exists(f)) txDATA.Text = File.ReadAllText(f);

        TextRegEx_TextChanged(sender, e);
    }

    void btnCOLLAPSE_Click(object sender, EventArgs e) => spcRESULT.Panel2Collapsed = !spcRESULT.Panel2Collapsed;

    void lvRESULT_KeyDown(object sender, KeyEventArgs e)
    {
        if (e is {KeyCode: Keys.A, Control: true})
        {
            lvRESULT.SelectedItems.Clear();
            for (var i = 0; i < lvRESULT.Items.Count; i++)
                lvRESULT.SelectedIndices.Add(i);
        }
        else if (e.KeyCode is Keys.Insert or Keys.C && e.Control)
        {
            var sb = new StringBuilder();
            foreach (var row in lvRESULT.Items.OfType<ListViewItem>())
                sb.AppendLine(row.SubItems.OfType<ListViewItem.ListViewSubItem>().Select(p => p.Text).Aggregate((acc, sel) => acc + "\t" + sel));
            if (sb.Length == 0) Clipboard.Clear();
            else Clipboard.SetText(sb.ToString(), TextDataFormat.Text);
        }
    }

    void lvRESULT_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
    {
        var a = lvRESULT.SelectedItems.OfType<ListViewItem>().ToArray();
    }
}