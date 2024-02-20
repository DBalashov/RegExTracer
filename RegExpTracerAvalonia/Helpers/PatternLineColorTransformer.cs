using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Media;
using AvaloniaEdit.Document;
using AvaloniaEdit.Rendering;

namespace RegExpTracerAvalonia.Helpers;

sealed class PatternLineColorTransformer : DocumentColorizingTransformer
{
    RegexParsedGroup[] parsedGroups = Array.Empty<RegexParsedGroup>();

    public PatternLineColorTransformer(string pattern) => UpdatePattern(pattern);

    public void UpdatePattern(string pattern) => parsedGroups = parseRegex(pattern);

    RegexParsedGroup[] parseRegex(string source)
    {
        if (string.IsNullOrWhiteSpace(source))
            return Array.Empty<RegexParsedGroup>();

        var r     = new List<RegexParsedGroup>();
        var stack = new Stack<int>();

        var lineIndex = 0;
        for (var i = 0; i < source.Length; i++)
        {
            switch (source[i])
            {
                case '(' when i == 0 || (i > 0 && source[i - 1] != '\\'): // escaped: \(
                    stack.Push(i);
                    break;
                case ')' when stack.Count == 0 && (i == 0 || (i > 0 && source[i - 1] == '\\')): // escaped: \)
                    continue;
                case ')':
                {
                    if (stack.Count == 0) continue;
                    var startIndex = stack.Pop();
                    if (stack.Count == 0)
                        r.Add(new RegexParsedGroup(lineIndex, r.Count, startIndex, i));
                    break;
                }
                case '\n':
                    lineIndex++;
                    break;
            }
        }

        return r.ToArray();
    }

    protected override void ColorizeLine(DocumentLine line)
    {
        foreach (var pg in parsedGroups.Where(p => p.LineNumber == line.LineNumber - 1))
            ChangeLinePart(pg.StartOffset,
                           pg.EndOffset + 1,
                           visualLine =>
                           {
                               visualLine.TextRunProperties.SetTypeface(new Typeface(visualLine.TextRunProperties.Typeface.FontFamily, FontStyle.Normal, FontWeight.Bold));
                               visualLine.TextRunProperties.SetForegroundBrush(UsedColors.ForegroundBrushes[pg.Index % UsedColors.BackgroundBrushes.Length]);
                           });
    }

    sealed record RegexParsedGroup(int LineNumber, int Index, int StartOffset, int EndOffset);
}