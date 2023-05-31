using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace RegExpTracerAvalonia.Helpers;

class SourceHelper
{
    public SourceLineItem[] LineInfos { get; private set; }
    public string           Source    { get; private set; }

    public SourceHelper(string src)
    {
        Source    = src;
        LineInfos = getSourceLines(src);
    }

    public void UpdateSource(string src)
    {
        Source    = src;
        LineInfos = getSourceLines(src);
    }

    SourceLineItem? getLineIndexByOffset(int offset)
    {
        foreach (var item in LineInfos)
            if (item.Offset <= offset && offset < item.Offset + item.Length)
                return item;

        return null;
    }

    SourceLineItem[] getSourceLines(string src)
    {
        var r          = new List<SourceLineItem>();
        var startIndex = 0;
        while (true)
        {
            var nextIndex = src.IndexOf(Environment.NewLine, startIndex, StringComparison.Ordinal);
            if (nextIndex < 0)
            {
                r.Add(new SourceLineItem(r.Count, startIndex, src.Length - startIndex));
                break;
            }

            r.Add(new SourceLineItem(r.Count, startIndex, nextIndex - startIndex + Environment.NewLine.Length));
            startIndex = nextIndex + Environment.NewLine.Length;
        }

        return r.ToArray();
    }

    public SourceMatchItem[] GetMatchesInLine(Match[] matches, int lineNumber) =>
        matches.SelectMany((p, matchIndex) =>
                           {
                               var l = getLineIndexByOffset(p.Index);
                               if (l == null || l.Number != lineNumber) return Array.Empty<SourceMatchItem>();

                               var r = new List<SourceMatchItem>();
                               for (var i = 1; i < p.Groups.Count; i++)
                               {
                                   var g = p.Groups[i];
                                   r.Add(new SourceMatchItem(l.Number, matchIndex, i - 1, g.Index - l.Offset, g.Length));
                               }

                               return r.ToArray();
                           })
               .ToArray();

    public SourceMatchData[] GetMatches(Match[] matches)
    {
        var r = matches.Select((p, matchIndex) =>
                               {
                                   var l = getLineIndexByOffset(p.Index);
                                   if (l == null) return null;

                                   var r = new List<SourceMatchDataItem>();
                                   for (var i = 1; i < p.Groups.Count; i++)
                                   {
                                       var g = p.Groups[i];
                                       r.Add(new SourceMatchDataItem(i - 1, g.Index - l.Offset, g.Length, g.Value));
                                   }

                                   return new SourceMatchData(l.Number, matchIndex, r.ToArray());
                               })
                       .Where(p => p != null)
                       .ToArray();
        return r!;
    }
}

record SourceLineItem(int Number, int Offset, int Length);

record SourceMatchItem(int LineNumber, int MatchIndex, int InMatchIndex, int Offset, int Length);

public record SourceMatchData(int LineNumber, int MatchIndex, SourceMatchDataItem[] Values);

public record SourceMatchDataItem(int InMatchIndex, int Offset, int Length, string Value);