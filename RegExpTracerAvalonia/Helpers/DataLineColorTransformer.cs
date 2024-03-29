﻿using System;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using Avalonia.Media;
using AvaloniaEdit.Document;
using AvaloniaEdit.Rendering;
using Common;

namespace RegExpTracerAvalonia.Helpers;

sealed class DataLineColorTransformer : DocumentColorizingTransformer
{
    Match[]           matches;
    Regex             rx;
    SourceMatchData[] selected = Array.Empty<SourceMatchData>();

    readonly SourceHelper sourceHelper;

    public DataLineColorTransformer(string pattern, RegexOptions options, string input)
    {
        rx           = new Regex(pattern, options);
        sourceHelper = new SourceHelper(input);
        matches      = rx.Matches(input).ToArray();
    }

    protected override void ColorizeLine(DocumentLine line)
    {
        var r = sourceHelper.GetMatchesInLine(matches, line.LineNumber - 1);
        foreach (var item in r)
            try
            {
                ChangeLinePart(line.Offset + item.Offset,
                               Math.Min(line.Offset + item.Offset + item.Length, line.EndOffset),
                               visualLine =>
                               {
                                   if (IsSelected(item))
                                       visualLine.TextRunProperties.SetTypeface(new Typeface(visualLine.TextRunProperties.Typeface.FontFamily, FontStyle.Italic, FontWeight.Heavy));

                                   visualLine.TextRunProperties.SetForegroundBrush(UsedColors.ForegroundBrushes[item.InMatchIndex % UsedColors.BackgroundBrushes.Length]);
                               });
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
    }

    bool IsSelected(SourceMatchItem m) =>
        selected.Any(c => c.LineNumber == m.LineNumber && c.MatchIndex == m.MatchIndex);

    public bool TryUpdatePattern(string pattern, RegexOptions options, out Exception? error)
    {
        error = null;
        try
        {
            rx      = new Regex(pattern, options);
            matches = rx.Matches(sourceHelper.Source).ToArray();
            return true;
        }
        catch (Exception e)
        {
            matches = Array.Empty<Match>();
            error   = e;
            return false;
        }
    }

    public bool UpdateSource(string source)
    {
        sourceHelper.UpdateSource(source);
        matches = rx.Matches(sourceHelper.Source).ToArray();
        return matches.Length > 0;
    }

    public SourceMatchData[] GetMatches() => sourceHelper.GetMatches(matches);

    public void UpdateSelected(SourceMatchData[] newSelected) =>
        selected = newSelected;
}