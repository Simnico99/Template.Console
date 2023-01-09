using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Template.Console.Startup;
using ZirconNet.Console.DependencyInjection;

try
{
    //Create
    var host = new HostBuilder();
    var config = new ConfigurationBuilder().RegisterConfigurations().Build();

    //Configure
    host.ConfigureAppConfiguration(x => x.AddConfiguration(config));
    host.ConfigureServices(x => x.RegisterServices());
@*#if (EnableSerilog)
    host.ConfigureLoggers(config);
#endif*@

    //Use
@*#if (EnableSerilog)
    host.UseSerilog();
#endif*@
    host.UseBackgroundServices();

    //Start
    await host.RunConsoleAsync();
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