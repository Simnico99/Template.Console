using Microsoft.Extensions.Hosting;
using Serilog;
using System.Reflection;

namespace Template.Console.Startup;

public static partial class IHostBuilderExtension
{
    public static IHostBuilder AddAndUseLoggers(this IHostBuilder builder)
    {
        builder.UseSerilog((hostContext, loggerConfiguration) => 
        Log.Logger = loggerConfiguration
            .ReadFrom
            .Configuration(hostContext.Configuration)
            .CreateLogger());



        Log.Information("Starting {SoftwareName} up!", AppDomain.CurrentDomain.FriendlyName);
        Log.Information("Environment: {Environment}", Environment.GetEnvironmentVariable("DOTNET_") ?? "Production");
        Log.Information("Version: {CurrentVersion}", Assembly.GetExecutingAssembly().GetName().Version);

        return builder;
    }
}
