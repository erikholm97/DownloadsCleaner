using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloadsCleaner.Processor
{
    public class FilePathValidator
    {
        private string pathToValidate;

        public void BeginValidationOfPath(string pathToValidate)
        {
            this.pathToValidate = pathToValidate;
            CheckIfPathIsCDrive();
        }

        private void CheckIfPathIsCDrive()
        {
            if(pathToValidate is @"C:\")
            {
                throw new Exception(@"It is not allowed to delete files inside the C:\ drive folder.");
            }

            if (string.IsNullOrWhiteSpace(pathToValidate) is true)
            {
                throw new Exception(@"Provided path was empty.");
            }
        }
    }
}
