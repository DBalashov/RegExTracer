using System.Text.Json;
using System.Text.RegularExpressions;

namespace RETracer2.Extenders;

public class Settings
{
    static readonly string settingsFilename = Application.UserAppDataPath + @"\Settings.json";

    public string Text    { get; set; } = "";
    public string Pattern { get; set; } = "";

    public bool         WordWrap { get; set; }
    public RegexOptions Options  { get; set; } = RegexOptions.IgnoreCase | RegexOptions.NonBacktracking;

    public static Settings Load() => !File.Exists(settingsFilename) ? new Settings() : JsonSerializer.Deserialize<Settings>(File.ReadAllText(settingsFilename))!;

    public void Save() => File.WriteAllText(settingsFilename, JsonSerializer.Serialize(this, new JsonSerializerOptions() {WriteIndented = true}));
}