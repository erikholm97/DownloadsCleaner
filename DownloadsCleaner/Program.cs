using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DownloadsCleaner;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();