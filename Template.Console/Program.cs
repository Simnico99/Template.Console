using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using TaskForceUtilities.Startup;
using ZirconNet.WPF.DependencyInjection;

try
{
    //Create
    var host = new HostBuilder();
    var config = new ConfigurationBuilder().RegisterConfigurations().Build();

    //Configure
    host.ConfigureAppConfiguration(x => x.AddConfiguration(config));
    host.ConfigureServices(x => x.RegisterServices());
    host.ConfigureLoggers(config);

    //Use
    host.UseSerilog();
    host.UseBackgroundServices();
    host.UseConsoleLifetime();

    //Start
    await host.StartAsync();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Software crashed: {Exception}");
    throw;
}
finally
{
    Log.CloseAndFlush();
    Environment.Exit(0);
}