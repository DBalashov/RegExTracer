using System.Linq;
using System.Text.RegularExpressions;
using Avalonia.Controls.Templates;
using Common;
using ReactiveUI;

namespace RegExpTracerAvalonia.ViewModels;

public class MainWindowViewModel : ReactiveObject
{
    SourceMatchData[]?                 _data;
    string?                            _error;
    bool                               _errorVisible;
    bool                               _dataVisible;
    FuncDataTemplate<SourceMatchData>? _dataTemplate;
    bool                               _wordWrap;
    RegexOptions                       _options;

    public RegexOptions Options
    {
        get => _options;
        set
        {
            this.RaiseAndSetIfChanged(ref _options, value);
            this.RaisePropertyChanged(nameof(PatternExplicit));
            this.RaisePropertyChanged(nameof(PatternMultiline));
            this.RaisePropertyChanged(nameof(PatternSingleLine));
            this.RaisePropertyChanged(nameof(PatternIgnoreCase));

        }
    }

    public bool PatternExplicit
    {
        get => _options.HasFlag(RegexOptions.ExplicitCapture);
        set => Options = value ? Options | RegexOptions.ExplicitCapture : Options & ~RegexOptions.ExplicitCapture;
    }

    public bool PatternIgnoreCase
    {
        get => _options.HasFlag(RegexOptions.IgnoreCase);
        set => Options = value ? Options | RegexOptions.IgnoreCase : Options & ~RegexOptions.IgnoreCase;
    }

    public bool PatternMultiline
    {
        get => _options.HasFlag(RegexOptions.Multiline);
        set => Options = value ? Options | RegexOptions.Multiline : Options & ~RegexOptions.Multiline;
    }

    public bool PatternSingleLine
    {
        get => _options.HasFlag(RegexOptions.Singleline);
        set => Options = value ? Options | RegexOptions.Singleline : Options & ~RegexOptions.Singleline;
    }

    public bool WordWrap
    {
        get => _wordWrap;
        set => this.RaiseAndSetIfChanged(ref _wordWrap, value);
    }

    public string? Error
    {
        get => _error;
        set
        {
            this.RaiseAndSetIfChanged(ref _error, value);
            ErrorVisible = !string.IsNullOrEmpty(value);
            DataVisible  = string.IsNullOrEmpty(value);
        }
    }

    public bool ErrorVisible
    {
        get => _errorVisible;
        set => this.RaiseAndSetIfChanged(ref _errorVisible, value);
    }

    public bool DataVisible
    {
        get => _dataVisible;
        set => this.RaiseAndSetIfChanged(ref _dataVisible, value);
    }

    public SourceMatchData[]? Data
    {
        get => _data;
        set
        {
            this.RaiseAndSetIfChanged(ref _data, value);
            DataVisible = value != null;
            Error       = value != null && value.Any() ? null : "No data";
        }
    }

    public FuncDataTemplate<SourceMatchData>? DataTemplate
    {
        get => _dataTemplate;
        set => this.RaiseAndSetIfChanged(ref _dataTemplate, value);
    }
}