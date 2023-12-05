using System;
using System.Collections.Generic;

public sealed class ConfigurationManager
{
    private static ConfigurationManager instance;
    private Dictionary<string, string> settings;

    private ConfigurationManager()
    {
        settings = new Dictionary<string, string>();
    }

    public static ConfigurationManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ConfigurationManager();
            }
            return instance;
        }
    }

    public void SetSetting(string name, string value)
    {
        settings[name] = value;
    }

    public string GetSetting(string name)
    {
        return settings.ContainsKey(name) ? settings[name] : "Setting not found";
    }

    public void DisplaySettings()
    {
        Console.WriteLine("Current Configuration Settings:");
        foreach (var setting in settings)
        {
            Console.WriteLine($"{setting.Key}: {setting.Value}");
        }
    }
}

class Program
{
    static void Main()
    {
        ConfigurationManager configManager = ConfigurationManager.Instance;

        configManager.DisplaySettings();

        Console.ReadLine();
    }
}
