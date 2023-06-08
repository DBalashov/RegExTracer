using System.Text;
using System.Text.RegularExpressions;
using Common;
using RETracer2.Extenders;

namespace RETracer2;

public partial class FMain : Form
{
    readonly SourceHelper _sourceHelper = new("");
    readonly Settings _settings = Settings.Load();

    bool inUpdating;
    SourceMatchData[] matches = Array.Empty<SourceMatchData>();
    Common.Extenders.RegexParsedGroup[] groups = Array.Empty<Common.Extenders.RegexParsedGroup>();
    int selectedGroupIndex = -1;
    int selectedMatchIndex = -1;

    public FMain() => InitializeComponent();

    void FMain_Load(object sender, EventArgs e)
    {
        inUpdating = true;
        txPATTERN.Text = _settings.Pattern;
        txINPUT.Text = _settings.Text;
        cbECMA.Checked = _settings.Options.HasFlag(RegexOptions.ECMAScript);
        cbEXPLICIT.Checked = _settings.Options.HasFlag(RegexOptions.ExplicitCapture);
        cbMULTILINE.Checked = _settings.Options.HasFlag(RegexOptions.Multiline);
        cbLINE_BREAKS.Checked = _settings.Options.HasFlag(RegexOptions.Singleline);
        cbIGNORE_CASE.Checked = _settings.Options.HasFlag(RegexOptions.IgnoreCase);
        cbNOBACK.Checked = _settings.Options.HasFlag(RegexOptions.NonBacktracking);
        cbWORDWRAP.Checked = txINPUT.WordWrap = _settings.WordWrap;
        inUpdating = false;

        updateMatches();
    }

    #region txPATTERN

    void txPATTERN_TextChanged(object sender, EventArgs e)
    {
        _sourceHelper.UpdateSource(txPATTERN.Text);
        updateMatches();
        _settings.Pattern = txPATTERN.Text;
        _settings.Save();
    }

    void txPATTERN_SelectionChanged(object sender, EventArgs e)
    {
        var newSelectedGroupIndex = getSelectedRegexGroupIndex(txPATTERN.SelectionStart);
        if (newSelectedGroupIndex == selectedGroupIndex) return;

        selectedGroupIndex = newSelectedGroupIndex;
        inUpdating = true;
        txPATTERN.UpdateHLPattern(groups, selectedGroupIndex);
        txINPUT.UpdateHLInput(matches, selectedGroupIndex, selectedMatchIndex);
        inUpdating = false;
    }

    #endregion

    #region txINPUT

    void txINPUT_TextChanged(object sender, EventArgs e)
    {
        updateMatches();
        _settings.Text = txINPUT.Text;
        _settings.Save();
    }

    void txINPUT_SelectionChanged(object sender, EventArgs e)
    {
        var newSelectedGroupIndex = getSelectedInputGroupIndex(txINPUT.SelectionStart);
        if (newSelectedGroupIndex == selectedGroupIndex) return;

        selectedGroupIndex = newSelectedGroupIndex;
        inUpdating = true;
        txPATTERN.UpdateHLPattern(groups, selectedGroupIndex);
        txINPUT.UpdateHLInput(matches, selectedGroupIndex, selectedMatchIndex);
        inUpdating = false;
    }

    #endregion

    void updateMatches()
    {
        if (inUpdating) return;
        try
        {
            inUpdating = true;

            if (string.IsNullOrWhiteSpace(txPATTERN.Text) || string.IsNullOrWhiteSpace(txINPUT.Text)) throw new Exception("No pattern or input data");

            var m = new Regex(txPATTERN.Text, 0, matchTimeout: TimeSpan.FromSeconds(3)).Matches(txINPUT.Text).ToArray();
            matches = _sourceHelper.GetMatchesWithoutLines(m);
            groups = txPATTERN.Text.ParseRegex();
            selectedGroupIndex = getSelectedRegexGroupIndex(txPATTERN.SelectionStart);
            selectedMatchIndex = 0;
            txPATTERN.UpdateHLPattern(groups, selectedGroupIndex);
            txINPUT.UpdateHLInput(matches, selectedGroupIndex, selectedMatchIndex);
            if (matches.Any())
                lvRESULT.UpdateResult(matches);
            else lvRESULT.UpdateResult("No data matched");
        }
        catch (Exception e)
        {
            matches = Array.Empty<SourceMatchData>();
            selectedGroupIndex = -1;

            txPATTERN.ClearHighlight();
            txINPUT.ClearHighlight();
            lvRESULT.UpdateResult(e.Message);
        }
        finally
        {
            inUpdating = false;
        }
    }

    #region lvRESULT

    void lvRESULT_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (lvRESULT.SelectedIndices.Count == 0) return;

        selectedMatchIndex = -1;
        var index = lvRESULT.SelectedIndices[0];
        if (index < 0 || index >= matches.Length) return;

        if (selectedMatchIndex == index) return;
        selectedMatchIndex = index;

        inUpdating = true;
        txINPUT.UpdateHLInput(matches, selectedGroupIndex, selectedMatchIndex);
        inUpdating = false;
    }

    void lvRESULT_KeyDown(object sender, KeyEventArgs e)
    {
        if (e is { KeyCode: Keys.A, Control: true })
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

    #endregion

    #region getSelectedRegexGroupIndex / getSelectedInputGroupIndex

    int getSelectedRegexGroupIndex(int currentIndex)
    {
        foreach (var g in groups)
            if (g.Index <= g.StartOffset && currentIndex <= g.EndOffset)
                return g.Index;
        return -1;
    }

    int getSelectedInputGroupIndex(int currentIndex)
    {
        foreach (var g in matches)
            foreach (var item in g.Values)
                if (item.Offset <= currentIndex && currentIndex <= item.Offset + item.Length)
                    return item.InMatchIndex;
        return -1;
    }

    #endregion

    void cbECMA_CheckedChanged(object sender, EventArgs e)
    {
        if (inUpdating) return;
        _settings.Options = (cbECMA.Checked ? RegexOptions.ECMAScript : 0) |
                            (cbEXPLICIT.Checked ? RegexOptions.ExplicitCapture : 0) |
                            (cbMULTILINE.Checked ? RegexOptions.Multiline : 0) |
                            (cbLINE_BREAKS.Checked ? RegexOptions.Singleline : 0) |
                            (cbIGNORE_CASE.Checked ? RegexOptions.IgnoreCase : 0) |
                            (cbNOBACK.Checked ? RegexOptions.NonBacktracking : 0);
        _settings.Save();
        updateMatches();
    }

    void cbWORDWRAP_CheckedChanged(object sender, EventArgs e)
    {
        txINPUT.WordWrap = _settings.WordWrap = cbNOBACK.Checked;
        _settings.Save();
    }
}