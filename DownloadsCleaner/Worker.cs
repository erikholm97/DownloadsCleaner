using DownloadsCleaner.Processor;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Configuration;

namespace DownloadsCleaner
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private FileProcessor _fileProcessor;

        public Worker(ILogger<Worker> logger, FileProcessor fileProcessor)
        {
            _logger = logger;
            _fileProcessor = fileProcessor;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("DownloadsCleaner started running at: {time}", DateTimeOffset.Now);
                ExecuteFileProcessor();
                _logger.LogInformation("DownloadsCleaner finished running at: {time}", DateTimeOffset.Now);
            }
        }

        private void ExecuteFileProcessor()
        {
            try
            {
                _fileProcessor.InitializeFileProcessor(@"C:\Test");
                _fileProcessor.InitProcessForRemovalOfFiles();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
    }
}
