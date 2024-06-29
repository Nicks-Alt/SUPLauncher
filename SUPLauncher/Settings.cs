using System.Configuration;

public static class Settings
{
    private static Configuration config;
    private static KeyValueConfigurationCollection settings => config.AppSettings.Settings;

    static Settings()
    {
        config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
    }

    private static void Set(string name, object value)
    {
        settings.Remove(name);
        settings.Add(name, value.ToString());
        config.Save();
    }

    public static bool UpdatePopup
    {
        get => bool.Parse(settings["UpdatePopup"]?.Value ?? "False");
        set => Set("UpdatePopup", value);
    }

    public static bool OverlayEnabled
    {
        get => bool.Parse(settings["OverlayEnabled"]?.Value ?? "False");
        set => Set("OverlayEnabled", value);
    }

    public static bool ProfileOverlayEnabled
    {
        get => bool.Parse(settings["ProfileOverlayEnabled"]?.Value ?? "False");
        set => Set("ProfileOverlayEnabled", value);
    }

    public static bool DiscordStatus
    {
        get => bool.Parse(settings["DiscordStatus"]?.Value ?? "true");
        set => Set("DiscordStatus", value);
    }
    public static uint OverlayModifierKey
    {
        get => uint.Parse(settings["OverlayModifierKey"]?.Value ?? "1");
        set => Set("OverlayModifierKey", value);
    }

    public static Keys OverlayKey
    {
        get => (Keys)int.Parse("83");
        set => Set("OverlayKey", value);
    }
    public static bool AFKStatus
    {
        get => bool.Parse(settings["AFKStatus"]?.Value ?? "False");
        set => Set("AFKStatus", value);
    }
}