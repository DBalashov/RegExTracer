using System.Linq;
using Avalonia.Media;

namespace RegExpTracerAvalonia.Helpers;

static class UsedColors
{
    public static readonly SolidColorBrush[] ForegroundBrushes =
    {
        new(Colors.Red),
        new(Colors.Green),
        new(Colors.Fuchsia),
        new(Colors.Indigo),
        new(Colors.Coral),
        new(Colors.Blue),
        new(Colors.SaddleBrown),
        new(Colors.DarkGoldenrod),
    };

    public static readonly SolidColorBrush[] BackgroundBrushes =
        ForegroundBrushes.Select(p => new SolidColorBrush(p.Color, 0.4)).ToArray();
}