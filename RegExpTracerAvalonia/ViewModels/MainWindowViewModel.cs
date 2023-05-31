using System.Linq;
using Avalonia.Controls.Templates;
using ReactiveUI;
using RegExpTracerAvalonia.Helpers;

namespace RegExpTracerAvalonia.ViewModels;

public class MainWindowViewModel : ReactiveObject
{
    SourceMatchData[]?                 _data;
    string?                            _error;
    bool                               _errorVisible;
    bool                               _dataVisible;
    FuncDataTemplate<SourceMatchData>? _dataTemplate;
    bool                               _wordWrap;

    public bool PatternExplicit   { get; set; }
    public bool PatternIgnoreCase { get; set; }
    public bool PatternMultiline  { get; set; }
    public bool PatternSingleLine { get; set; }
    public bool PatternLineBreaks { get; set; }
    
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