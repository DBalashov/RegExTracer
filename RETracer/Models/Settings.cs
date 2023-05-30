using System.Text.Json;

namespace RegExTracer;

public class Settings
{
    static readonly string settingsFilename = Application.UserAppDataPath + @"\Settings.json";

    static readonly Color BackColorDefault = Color.FromArgb(0xef, 0xef, 0xef);
    static readonly Color ForeColorDefault = Color.FromArgb(0,    0,    0);

    static readonly Color[] HighlightColorListDefault =
    {
        Color.FromArgb(0x7f, 0xcf, 0xff), Color.FromArgb(0xff, 0x7f, 0x7f), Color.FromArgb(0x7f, 0xff, 0x7f),
        Color.FromArgb(0xff, 0xcf, 0x7f), Color.FromArgb(0x7f, 0xff, 0xff), Color.FromArgb(0xff, 0xff, 0x7f),
        Color.FromArgb(0x7f, 0x7f, 0xff), Color.FromArgb(0xbf, 0xbf, 0xbf)
    };

    private Settings()
    {
        
    }

    public static Settings Load()
    {
        if (!File.Exists(settingsFilename)) return new Settings();

        var settingsData = JsonSerializer.Deserialize<Settings>(settingsFilename)!;
        if (settingsData.TextSize < 2) settingsData.TextSize = 10f;
        return settingsData;
    }

    public void Save() => File.WriteAllText(settingsFilename, JsonSerializer.Serialize(this, new JsonSerializerOptions() {WriteIndented = true}));

    public Color           BackColor          { get; set; } = BackColorDefault;
    public Color           ForeColor          { get; set; } = ForeColorDefault;
    public HighlighingType HighlighingType    { get; set; }=HighlighingType.BackGround;
    public List<Color>     HighlightColorList { get; set; } = HighlightColorListDefault.ToList();
    public float           TextSize           { get; set; } = 10f;
}