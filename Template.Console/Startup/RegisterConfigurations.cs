using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TaskForceUtilities.Startup
{
    public static partial class IConfigurationBuilderExtension
    {
        public static IConfigurationBuilder RegisterConfigurations(this IConfigurationBuilder configuration)
        {
            configuration.SetBasePath(Directory.GetCurrentDirectory());
            configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            configuration.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("DOTNET_") ?? "Production"}.json", optional: true);
            configuration.AddEnvironmentVariables();
            configuration.Build();

            return configuration;
        }
    }
}
