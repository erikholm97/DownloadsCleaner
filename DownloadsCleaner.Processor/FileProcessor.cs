using System;
using System.IO;
using System.Threading.Tasks;

namespace DownloadsCleaner.Processor
{
    public class FileProcessor
    {
        private string pathToProcess;
        private FilePathValidator _filePathValidator;

        public FileProcessor(FilePathValidator filePathValidator)
        {
            this._filePathValidator = filePathValidator;
        }

        public void InitializeFileProcessor(string pathToProcess)
        {
            _filePathValidator.BeginValidationOfPath(pathToProcess);


            this.pathToProcess = pathToProcess;
        }

        public void InitProcessForRemovalOfFiles()
        {
            var filesToRemove = Directory.GetFiles(pathToProcess);

            foreach (var fileToRemove in filesToRemove)
            {
                Console.WriteLine($"Processing file: {fileToRemove}.");

                File.Delete(fileToRemove);

                Console.WriteLine($"Successfully deleted file: {fileToRemove}.");
            }
        }
    }
}
