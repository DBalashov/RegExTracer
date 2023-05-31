using System;
using System.IO;
using System.Text.Json;
#pragma warning disable CS8618

namespace RegExpTracerAvalonia.Models;

public class Settings
{
    const string FILE_NAME = "regexp-tracer-avalonia.json";

    public string Input   { get; set; }
    public string Pattern { get; set; }

    public static Settings Load()
    {
        var fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), FILE_NAME);
        if (File.Exists(fileName))
            return JsonSerializer.Deserialize<Settings>(File.ReadAllText(fileName))!;

        return new Settings()
               {
                   Input = @"Variables which should not be set for a specific installation are explicitly set to an empty value," + Environment.NewLine +
                           " so that startup script correctly detects which installation you are aiming at.",
                   Pattern = @"(\S{4,5})(\s+)(\S+)"
               };
    }

    public void Save()
    {
        var fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), FILE_NAME);
        File.WriteAllText(fileName, JsonSerializer.Serialize(this, new JsonSerializerOptions() {WriteIndented = true}));
    }
}