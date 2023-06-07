using System;
using System.Collections.Generic;
using System.Linq;
using AvaloniaEdit.Document;
using AvaloniaEdit.Rendering;

namespace RegExpTracerAvalonia.Helpers;

class PatternLineColorTransformer : DocumentColorizingTransformer
{
    RegexParsedGroup[]? parsedGroups;

    public PatternLineColorTransformer(string pattern) => UpdatePattern(pattern);

    public void UpdatePattern(string pattern) => parsedGroups = parseRegex(pattern);

    RegexParsedGroup[]? parseRegex(string source)
    {
        var r = new List<RegexParsedGroup>();
        if (string.IsNullOrWhiteSpace(source)) return r.ToArray();

        var currentIndex = 0;
        while (currentIndex != -1 && currentIndex < source.Length)
        {
            var startIndex = source.IndexOf('(', currentIndex);
            if (startIndex < 0) break;

            if (startIndex > 0 && source[startIndex - 1] == '\\') // escaped: \(
            {
                currentIndex = startIndex + 1;
                continue;
            }

            var endIndex = -1;
            while (true)
            {
                endIndex = source.IndexOf(')', startIndex);

                if (endIndex < 0) return null; // no closing ) -> error
                if (endIndex <= 0 || source[endIndex - 1] != '\\') break;

                startIndex = endIndex + 1;
            }

            r.Add(new RegexParsedGroup(0, r.Count, startIndex, endIndex));
            currentIndex = endIndex + 1;
        }

        return r.ToArray();
    }

    protected override void ColorizeLine(DocumentLine line)
    {
        if (parsedGroups == null) return;
        foreach (var pg in parsedGroups.Where(p => p.LineNumber == line.LineNumber - 1))
            ChangeLinePart(pg.StartOffset,
                           pg.EndOffset + 1,
                           visualLine => visualLine.TextRunProperties.BackgroundBrush = UsedColors.Brushes[pg.Index % UsedColors.Brushes.Length]);
    }

    record RegexParsedGroup(int LineNumber, int Index, int StartOffset, int EndOffset);
}