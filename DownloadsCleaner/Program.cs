using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DownloadsCleaner;
using DownloadsCleaner.Processor;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddHostedService<Worker>();
        services.AddSingleton<FilePathValidator>();
        services.AddSingleton<FileProcessor>();
    })
    .Build();

await host.RunAsync();