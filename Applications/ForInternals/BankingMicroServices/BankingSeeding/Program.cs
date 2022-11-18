// See https://aka.ms/new-console-template for more information

// Init Runner class

using BankingSeeding;
using BankingSeeding.Services.Settings;
using Microsoft.Extensions.Configuration;

ConfigurationBuilder builder = new ConfigurationBuilder();

ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
IConfiguration c = configurationBuilder.AddJsonFile("appsettings.Development.json").AddEnvironmentVariables().Build();



IConfigurationSection configurationSection = c.GetSection("AppSettings");

var appSettings = configurationSection.Get<AppSettings>();



new Runner(appSettings).Run();

Console.WriteLine("Hello, World!");