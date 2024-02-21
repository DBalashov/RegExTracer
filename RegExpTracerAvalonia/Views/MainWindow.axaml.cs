using System;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Layout;
using Common;
using RegExpTracerAvalonia.Helpers;
using RegExpTracerAvalonia.Models;
using RegExpTracerAvalonia.ViewModels;

namespace RegExpTracerAvalonia.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    void OnWindowOpened(object? sender, EventArgs e)
    {
        var settings = Settings.Load();

        DataContext = new MainWindowViewModel()
                      {
                          Options  = settings.Options,
                          WordWrap = settings.WordWrap
                      };

        edInput.TextArea.TextView.LineTransformers.Clear();
        edInput.TextArea.TextView.LineTransformers.Add(new DataLineColorTransformer(edPattern.Text, settings.Options, edInput.Text));

        edPattern.TextArea.TextView.LineTransformers.Clear();
        edPattern.TextArea.TextView.LineTransformers.Add(new PatternLineColorTransformer(edPattern.Text));

        edInput.Text   = settings.Input;
        edPattern.Text = settings.Pattern;
    }

    protected override void OnClosed(EventArgs e)
    {
        base.OnClosed(e);
        if (DataContext is MainWindowViewModel vm)
            new Settings()
            {
                Input    = edInput.Text,
                Pattern  = edPattern.Text,
                Options  = vm.Options,
                WordWrap = vm.WordWrap
            }.Save();
    }

    void edPattern_OnTextChanged(object? sender, EventArgs e)
    {
        var lct = edInput.TextArea.TextView.LineTransformers.OfType<DataLineColorTransformer>().First();
        if (DataContext is MainWindowViewModel vm)
        {
            if (!lct.TryUpdatePattern(edPattern.Text, vm.Options, out var ex))
            {
                if (ex != null) vm.Error = ex.Message;
                else vm.Data             = Array.Empty<SourceMatchData>();
            }
            else
            {
                vm.Data = lct.GetMatches();
                updateDataHeader(vm.Data);

                vm.ItemTemplate = new FuncDataTemplate<SourceMatchData>((value, _) =>
                                                                        {
                                                                            var grid = new Grid() {HorizontalAlignment = HorizontalAlignment.Stretch, MaxHeight = 20};
                                                                            if (value == null!) return grid;

                                                                            grid.ColumnDefinitions.Add(new ColumnDefinition(45, GridUnitType.Pixel));
                                                                            for (var i = 0; i < value.Values.Length; i++)
                                                                                grid.ColumnDefinitions.Add(new ColumnDefinition(GridLength.Star));

                                                                            grid.Children.Add(new TextBlock
                                                                                              {
                                                                                                  Text     = value.MatchIndex.ToString(),
                                                                                                  FontSize = 11
                                                                                              });
                                                                            for (var i = 0; i < value.Values.Length; i++)
                                                                            {
                                                                                var item = value.Values[i];
                                                                                var tb = new TextBlock
                                                                                         {
                                                                                             Text                = item.Value,
                                                                                             HorizontalAlignment = HorizontalAlignment.Stretch,
                                                                                             FontSize            = 11
                                                                                         };
                                                                                Grid.SetColumn(tb, i + 1);
                                                                                grid.Children.Add(tb);
                                                                            }

                                                                            return grid;
                                                                        });
            }
        }

        edInput.TextArea.TextView.Redraw();

        var pct = edPattern.TextArea.TextView.LineTransformers.OfType<PatternLineColorTransformer>().First();
        pct.UpdatePattern(edPattern.Text);
        edPattern.TextArea.TextView.Redraw();
    }

    void edInput_OnTextChanged(object? sender, EventArgs e)
    {
        var lct = edInput.TextArea.TextView.LineTransformers.OfType<DataLineColorTransformer>().First();
        if (DataContext is MainWindowViewModel vm)
            vm.Data = !lct.UpdateSource(edInput.Text) ? Array.Empty<SourceMatchData>() : lct.GetMatches();

        edInput.TextArea.TextView.Redraw();
    }

    void updateDataHeader(SourceMatchData[]? data)
    {
        gridDataHeader.Children.Clear();
        gridDataHeader.ColumnDefinitions.Clear();
        if (data == null || !data.Any()) return; // todo add "No data"

        var first = data.First();

        gridDataHeader.ColumnDefinitions.Add(new ColumnDefinition(45, GridUnitType.Pixel));
        for (var i = 0; i < first.Values.Length; i++)
            gridDataHeader.ColumnDefinitions.Add(new ColumnDefinition(GridLength.Star));

        gridDataHeader.Children.Add(new TextBlock
                                    {
                                        Text              = "#",
                                        Margin            = new Thickness(0, 0, 0, 0),
                                        VerticalAlignment = VerticalAlignment.Center
                                    });
        for (var i = 0; i < first.Values.Length; i++)
        {
            var tb = new TextBlock
                     {
                         Text                = "#" + (i + 1),
                         Background          = UsedColors.BackgroundBrushes[i % first.Values.Length],
                         HorizontalAlignment = HorizontalAlignment.Stretch,
                         Margin              = new Thickness(0, 0, 0, 0)
                     };
            Grid.SetColumn(tb, i + 1);
            gridDataHeader.Children.Add(tb);
        }
    }

    void lbDATA_OnKeyDown(object? sender, KeyEventArgs e)
    {
        if (e is not {Key: Key.C, KeyModifiers: KeyModifiers.Control}) return;

        var data = string.Join(Environment.NewLine,
                               lbDATA.SelectedItems!
                                     .OfType<SourceMatchData>()
                                     .OrderBy(p => p.MatchIndex)
                                     .Select(p => p.MatchIndex + "\t" + string.Join('\t', p.Values.Select(c => c.Value))));
        Clipboard?.SetTextAsync(data).ConfigureAwait(false).GetAwaiter().GetResult();
    }

    void lbDATA_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        var m   = lbDATA.SelectedItems!.OfType<SourceMatchData>().ToArray();
        var lct = edInput.TextArea.TextView.LineTransformers.OfType<DataLineColorTransformer>().First();
        lct.UpdateSelected(m);
        edInput.TextArea.TextView.Redraw();
    }

    void options_OnClick(object? sender, RoutedEventArgs e)
    {
        edPattern_OnTextChanged(sender, e);
        edInput_OnTextChanged(sender, e);
    }
}