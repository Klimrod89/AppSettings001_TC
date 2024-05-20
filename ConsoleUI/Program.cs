
using Microsoft.Extensions.Configuration;

IConfigurationBuilder builder = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json", false, true)
                                .AddJsonFile("appSettings.Development.json", true, true)
                                .AddJsonFile("appSettings.Production.json", true, true)
                                .AddUserSecrets<Program>()
                                .AddCommandLine(args);

IConfigurationRoot config = builder.Build();

Console.WriteLine(config["MySetting"] ?? "There is no settings");
Console.WriteLine(config.GetValue<string>("MainSetting:SubSetting"));
Console.WriteLine(config.GetValue<string>("MainSetting:SubSection:SubSubSetting"));
Console.WriteLine(config.GetConnectionString("Default"));
Console.ReadLine();