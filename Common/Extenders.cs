namespace Common;

public static class Extenders
{
    public static RegexParsedGroup[] ParseRegex(this string source)
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

    public sealed record RegexParsedGroup(int LineNumber, int Index, int StartOffset, int EndOffset);
}