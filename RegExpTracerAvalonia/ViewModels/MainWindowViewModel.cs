using System.Linq;
using System.Text.RegularExpressions;
using Avalonia.Controls.Templates;
using Common;
using ReactiveUI;

namespace RegExpTracerAvalonia.ViewModels;

public class MainWindowViewModel : ReactiveObject
{
    SourceMatchData[]?                 data;
    string?                            error;
    bool                               errorVisible;
    bool                               dataVisible;
    FuncDataTemplate<SourceMatchData>? itemTemplate;
    bool                               wordWrap;
    RegexOptions                       options;

    public RegexOptions Options
    {
        get => options;
        set
        {
            this.RaiseAndSetIfChanged(ref options, value);
            this.RaisePropertyChanged(nameof(PatternExplicit));
            this.RaisePropertyChanged(nameof(PatternMultiline));
            this.RaisePropertyChanged(nameof(PatternSingleLine));
            this.RaisePropertyChanged(nameof(PatternIgnoreCase));
            this.RaisePropertyChanged(nameof(WordWrap));
        }
    }

    public bool PatternExplicit
    {
        get => options.HasFlag(RegexOptions.ExplicitCapture);
        set => Options = value ? Options | RegexOptions.ExplicitCapture : Options & ~RegexOptions.ExplicitCapture;
    }

    public bool PatternIgnoreCase
    {
        get => options.HasFlag(RegexOptions.IgnoreCase);
        set => Options = value ? Options | RegexOptions.IgnoreCase : Options & ~RegexOptions.IgnoreCase;
    }

    public bool PatternMultiline
    {
        get => options.HasFlag(RegexOptions.Multiline);
        set => Options = value ? Options | RegexOptions.Multiline : Options & ~RegexOptions.Multiline;
    }

    public bool PatternSingleLine
    {
        get => options.HasFlag(RegexOptions.Singleline);
        set => Options = value ? Options | RegexOptions.Singleline : Options & ~RegexOptions.Singleline;
    }

    public bool WordWrap
    {
        get => wordWrap;
        set => this.RaiseAndSetIfChanged(ref wordWrap, value);
    }

    public string? Error
    {
        get => error;
        set
        {
            this.RaiseAndSetIfChanged(ref error, value);
            ErrorVisible = !string.IsNullOrEmpty(value);
            DataVisible  = string.IsNullOrEmpty(value);
        }
    }

    public bool ErrorVisible
    {
        get => errorVisible;
        set => this.RaiseAndSetIfChanged(ref errorVisible, value);
    }

    public bool DataVisible
    {
        get => dataVisible;
        set => this.RaiseAndSetIfChanged(ref dataVisible, value);
    }

    public SourceMatchData[]? Data
    {
        get => data;
        set
        {
            this.RaiseAndSetIfChanged(ref data, value);
            DataVisible = value != null && value.Any();
            Error       = value != null && value.Any() ? null : "No data";
        }
    }

    public FuncDataTemplate<SourceMatchData>? ItemTemplate
    {
        get => itemTemplate;
        set => this.RaiseAndSetIfChanged(ref itemTemplate, value);
    }
}