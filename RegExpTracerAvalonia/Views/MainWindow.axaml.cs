using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
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
    const int FONT_RESULT_SIZE = 11;

    public MainWindow() => InitializeComponent();

    void OnWindowOpened(object? sender, EventArgs e)
    {
        var settings = Settings.Load();
        if (settings.Items.Any())
            rebuildHistory(settings.Items);

        DataContext = new MainWindowViewModel()
                      {
                          Options  = settings.Options,
                          WordWrap = settings.WordWrap
                      };

        edInput.BeginChange();
        edInput.TextArea.TextView.LineTransformers.Clear();
        edInput.TextArea.TextView.LineTransformers.Add(new DataLineColorTransformer(edPattern.Text, settings.Options, edInput.Text));
        edInput.EndChange();
        
        edPattern.BeginChange();
        edPattern.TextArea.TextView.LineTransformers.Clear();
        edPattern.TextArea.TextView.LineTransformers.Add(new PatternLineColorTransformer(edPattern.Text));
        edPattern.EndChange();
        
        edInput.Text   = settings.Input;
        edPattern.Text = settings.Pattern;
    }

    void rebuildHistory(List<SettingsItem> items)
    {
        if (DataContext is not MainWindowViewModel vm) return;

        menuItemHistory.Items.Clear();

        var subItemHistory = new MenuItem() {Header = "Clear"};
        subItemHistory.Click += subItemHistoryClear_Click;
        menuItemHistory.Items.Add(subItemHistory);
        menuItemHistory.Items.Add(new Separator());
        foreach (var item in items)
        {
            var subsub = new MenuItem() {Header = item.Pattern};
            subsub.Click += (sender, args) =>
                            {
                                vm.Options     = item.Options;
                                vm.WordWrap    = item.WordWrap;
                                edInput.Text   = item.Input;
                                edPattern.Text = item.Pattern;
                            };
            
            menuItemHistory.Items.Add(subsub);
        }
    }

    void subItemHistoryClear_Click(object? sender, RoutedEventArgs e)
    {
        if (DataContext is not MainWindowViewModel vm) return;

        var settings = Settings.Load();
        settings.Items.Clear();
        settings.Input    = edInput.Text;
        settings.Pattern  = edPattern.Text;
        settings.Options  = vm.Options;
        settings.WordWrap = vm.WordWrap;
        settings.Save();

        rebuildHistory(settings.Items);
    }

    protected override void OnClosed(EventArgs e)
    {
        base.OnClosed(e);
        if (DataContext is not MainWindowViewModel vm) return;

        var settings = Settings.Load();
        settings.Input    = edInput.Text;
        settings.Pattern  = edPattern.Text;
        settings.Options  = vm.Options;
        settings.WordWrap = vm.WordWrap;
        settings.Save();
    }

    void edPattern_OnTextChanged(object? sender, EventArgs e)
    {
        var lct = edInput.TextArea.TextView.LineTransformers.OfType<DataLineColorTransformer>().First();
        if (DataContext is MainWindowViewModel vm)
        {
            if (!lct.TryUpdatePattern(edPattern.Text, vm.Options, out var ex))
            {
                if (ex != null) vm.Error = ex.Message;
                else vm.Data             = [];
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
                                                                                                  FontSize = FONT_RESULT_SIZE
                                                                                              });
                                                                            for (var i = 0; i < value.Values.Length; i++)
                                                                            {
                                                                                var item = value.Values[i];
                                                                                var tb = new TextBlock
                                                                                         {
                                                                                             Text                = item.Value,
                                                                                             HorizontalAlignment = HorizontalAlignment.Stretch,
                                                                                             FontSize            = FONT_RESULT_SIZE
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

    void onMenuItem_About(object? sender, RoutedEventArgs e) =>
        MessageBox.Show(this, "dbalashov@gmail.com", "About", MessageBox.MessageBoxButtons.Ok);

    void onMenuItem_Exit(object? sender, RoutedEventArgs e)
    {
        switch (Application.Current?.ApplicationLifetime)
        {
            case IClassicDesktopStyleApplicationLifetime desktopApp:
                desktopApp.Shutdown();
                break;
            case ISingleViewApplicationLifetime viewApp:
                viewApp.MainView = null;
                break;
        }
    }
}