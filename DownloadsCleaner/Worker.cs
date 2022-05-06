using DownloadsCleaner.Processor;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Configuration;
using DownloadsCleaner.Helper;

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
            while (stoppingToken.IsCancellationRequested is false)
            {
                _logger.LogInformation($"DownloadsCleaner started running at: {DateTimeOffset.Now}");
                ExecuteFileProcessor();
                _logger.LogInformation($"DownloadsCleaner finished running at: {DateTimeOffset.Now}");

                _logger.LogInformation($"DownloadsCleaner will start processing of new files to remove one week from now.");

                await Task.Delay(TaskDelayHelper.AddOneWeek());
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
