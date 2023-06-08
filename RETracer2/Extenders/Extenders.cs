using Common;
using Nabu.Forms;
using Nabu.Forms.TextObjectModel;

namespace RETracer2.Extenders;

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

    public static int toRTFColor(this Color color) => ((color.B << 0x10) | (color.G << 8)) | color.R;

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
        {
            var range = doc.Range(group.StartOffset, group.EndOffset + 1);
            var font  = range.Font;
            font.ForeColor = Colors[group.Index % Colors.Length].toRTFColor();
            font.Bold      = selectedGroupIndex == group.Index ? FormatFlags.True : FormatFlags.False;
            font.Underline = selectedGroupIndex == group.Index ? UnderlineFlags.Dotted : UnderlineFlags.None;
        }

        doc.Unfreeze();
    }

    public static void UpdateHLInput(this RichTextBoxEx txINPUT, SourceMatchData[] matchGroups, int selectedGroupIndex, int selectedMatchIndex)
    {
        txINPUT.ClearHighlight();
        var doc = txINPUT.TextDocument!;
        doc.Freeze();

        foreach (var group in matchGroups)
        {
            foreach (var item in group.Values)
            {
                var range = doc.Range(item.Offset, item.Offset + item.Length);
                var font  = range.Font;
                font.ForeColor = Colors[item.InMatchIndex % Colors.Length].toRTFColor();
                font.Bold      = selectedGroupIndex == item.InMatchIndex ? FormatFlags.True : FormatFlags.False;
                font.Underline = group.MatchIndex   == selectedMatchIndex ? UnderlineFlags.Double : UnderlineFlags.None;
            }
        }

        doc.Unfreeze();
    }

    #region UpdateResult

    const int NUMBER_COL_WIDTH = 70;

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
            {
                var si = lvi.SubItems.Add(item.Value);
                si.ForeColor = Colors[item.InMatchIndex % Colors.Length];
            }

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