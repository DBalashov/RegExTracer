using System.Text.Json;
using System.Text.RegularExpressions;

namespace RETracer.Extenders;

public class Settings
{
    static readonly string settingsFilename = Path.Combine(Application.UserAppDataPath, "settings.json");

    public string       Text     { get; set; } = "";
    public string       Pattern  { get; set; } = "";
    public int          Timeout  { get; set; }
    public bool         WordWrap { get; set; }
    public RegexOptions Options  { get; set; } = RegexOptions.IgnoreCase | RegexOptions.NonBacktracking;

    public static Settings Load()
    {
        var r = !File.Exists(settingsFilename)
                    ? new Settings()
                    : JsonSerializer.Deserialize<Settings>(File.ReadAllText(settingsFilename))!;
        if (r.Timeout <= 0) r.Timeout = 3000;
        return r;
    }

    public void Save() =>
        File.WriteAllText(settingsFilename, JsonSerializer.Serialize(this, new JsonSerializerOptions() {WriteIndented = true}));
}