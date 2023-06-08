using Common;
using Nabu.Forms;
using Nabu.Forms.TextObjectModel;

namespace RETracer.Extenders;

static class Extenders
{
    static readonly Color[] Colors =
    {
        Color.Red,
        Color.Fuchsia,
        Color.Green,
        Color.Indigo,
        Color.Coral,
        Color.Blue,
        Color.SaddleBrown,
        Color.DarkGoldenrod
    };

    static int toRTFColor(this Color color) => (color.B << 0x10) | (color.G << 8) | color.R;

    public static void ClearHighlight(this RichTextBoxEx txREGEX)
    {
        var range = txREGEX.TextDocument!.Range(0, txREGEX.TextLength);
        var font  = range.Font;
        var para  = range.Para;
        para.SpaceBefore = 0f;
        para.SpaceAfter  = 0f;
        font.BackColor   = txREGEX.BackColor.toRTFColor();
        font.ForeColor   = txREGEX.ForeColor.toRTFColor();
        font.Bold        = FormatFlags.False;
    }

    public static void UpdateHLPattern(this RichTextBoxEx txPATTERN, Common.Extenders.RegexParsedGroup[] groups, int selectedGroupIndex)
    {
        txPATTERN.ClearHighlight();

        var doc = txPATTERN.TextDocument!;
        doc.Freeze();

        foreach (var group in groups)
            doc.Range(group.StartOffset, group.EndOffset + 1)
               .Font.updateStyle(group.Index, selectedGroupIndex == group.Index, selectedGroupIndex == group.Index, UnderlineFlags.Dotted);

        doc.Unfreeze();
    }

    public static void UpdateHLInput(this RichTextBoxEx txINPUT, SourceMatchData[] matchGroups, int selectedGroupIndex, HashSet<int> selectedMatchIndexes)
    {
        txINPUT.ClearHighlight();
        var doc = txINPUT.TextDocument!;
        doc.Freeze();

        foreach (var group in matchGroups)
        foreach (var item in group.Values)
            doc.Range(item.Offset, item.Offset + item.Length)
               .Font
               .updateStyle(item.InMatchIndex, selectedGroupIndex == item.InMatchIndex, selectedMatchIndexes.Contains(group.MatchIndex), UnderlineFlags.Double);

        doc.Unfreeze();
    }

    static void updateStyle(this ITextFont font, int colorIndex, bool bold, bool underline, UnderlineFlags flags)
    {
        font.ForeColor = Colors[colorIndex % Colors.Length].toRTFColor();
        font.Shadow    = FormatFlags.True;
        font.Bold      = bold ? FormatFlags.True : FormatFlags.False;
        font.Underline = underline ? flags : UnderlineFlags.None;
    }

    #region UpdateResult

    public const int NUMBER_COL_WIDTH = 70;

    public static void UpdateResult(this ListView lv, SourceMatchData[] matchGroups)
    {
        lv.BeginUpdate();
        lv.Columns.Clear();
        lv.Items.Clear();

        var cols = matchGroups[0].Values.Length;
        lv.Columns.Add("#", NUMBER_COL_WIDTH).TextAlign = HorizontalAlignment.Center;
        for (var i = 0; i < cols; i++)
            lv.Columns.Add($"#{i + 1}", (lv.Width - NUMBER_COL_WIDTH) / cols);

        var row = 0;
        foreach (var matchGroup in matchGroups)
        {
            var lvi = new ListViewItem(row.ToString());
            foreach (var item in matchGroup.Values)
                lvi.SubItems.Add(item.Value);
            lv.Items.Add(lvi);
            row++;
        }

        lv.EndUpdate();
    }

    public static void UpdateResult(this ListView lv, string error)
    {
        lv.BeginUpdate();
        lv.Columns.Clear();
        lv.Items.Clear();

        lv.Columns.Add("#", lv.Width - 10);
        lv.Items.Add(new ListViewItem(error));

        lv.EndUpdate();
    }

    #endregion
}