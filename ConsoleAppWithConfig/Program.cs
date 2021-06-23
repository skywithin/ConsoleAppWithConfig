using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace ConsoleAppWithConfig
{
    class Program
    {
        static void Main(string[] args)
        {
            var configBuilder = new ConfigurationBuilder();

            PrimeConfigBuilder(configBuilder);

            var config = configBuilder.Build();

            DisplayConfig(config);

            Console.WriteLine("Hello World!");
        }

        static void PrimeConfigBuilder(IConfigurationBuilder configBuilder)
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            configBuilder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appSettings.{env ?? "Development"}.json", optional: true)
                .AddEnvironmentVariables();
        }

        static void DisplayConfig(IConfigurationRoot config)
        {
            foreach (var x in config.AsEnumerable())
            {
                Console.WriteLine($"{x.Key} -- {x.Value}");
            }
        }
    }
}
