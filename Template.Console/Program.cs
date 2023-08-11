using Microsoft.Extensions.Hosting;
using Serilog;
using Template.Console.Startup;
using ZirconNet.Core.Hosting;

try
{
    //Create
    var host = Host.CreateDefaultBuilder(args);

    //Configure
    host.ConfigureServices(x => x.RegisterServices());

    //Add
    host.AddEnvironmentManager(args);
    host.AddAndUseLoggers();

    //Start
    await host.RunConsoleAsync();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Template.Console crashed:");
    throw;
}
finally
{
    Log.CloseAndFlush();
}