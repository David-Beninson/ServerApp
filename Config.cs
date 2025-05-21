using Microsoft.Extensions.Configuration;

public static class Config
{
    // Responsible for loading and accessing settings from appsettings.json
    private static IConfigurationRoot configuration;

    // Static constructor runs once when the class is first used
    static Config()
    {
        configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory()) // Use the project's root folder
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true) // Load the JSON config file
            .Build(); // Build the configuration object
    }

    // Retrieve a connection string by name (default is "DefaultConnection")
    public static string GetConnectionString(string name = "DefaultConnection")
    {
        return configuration.GetConnectionString(name);
    }
}