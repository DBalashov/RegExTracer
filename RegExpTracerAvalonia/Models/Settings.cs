using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;

#pragma warning disable CS8618

namespace RegExpTracerAvalonia.Models;

public class SettingsItem
{
    public string       Input    { get; set; }
    public string       Pattern  { get; set; }
    public RegexOptions Options  { get; set; }
    public bool         WordWrap { get; set; }
}

public class Settings : SettingsItem
{
    const string FILE_NAME = "regexp-tracer-avalonia.json";

    public List<SettingsItem> Items { get; set; }

    public static Settings Load()
    {
        var fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), FILE_NAME);

        var s = File.Exists(fileName)
                    ? JsonSerializer.Deserialize<Settings>(File.ReadAllText(fileName))!
                    : new Settings()
                      {
                          Input = "Variables which should not be set for a specific installation are explicitly set to an empty value," + Environment.NewLine +
                                  " so that startup script correctly detects which installation you are aiming at.",
                          Pattern = @"(\S{4,5})(\s+)(\S+)"
                      };

        if (s.Items == null!)
            s.Items = new List<SettingsItem>();

        return s;
    }

    public void Save()
    {
        var index = Items.FindIndex(c => c.Pattern == Pattern);
        if (index >= 0)
            Items.RemoveAt(index);
        
        Items.Insert(0, new SettingsItem()
                        {
                            Input    = Input,
                            Pattern  = Pattern,
                            Options  = Options,
                            WordWrap = WordWrap
                        });

        while (Items.Count > 10)
            Items.RemoveAt(Items.Count - 1);

        var fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), FILE_NAME);
        File.WriteAllText(fileName, JsonSerializer.Serialize(this, new JsonSerializerOptions() {WriteIndented = true}));
    }
}