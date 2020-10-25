using System.IO;
using Etechnosoft.Common.Enums;
using Etechnosoft.Common.Exceptions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Etechnosoft.Common.Infrastructure
{
    
    public class FileManagerHelper
    {
        public string RootFolder { get; set; }
        public FileManagerHelper(IConfiguration configuration, IHostingEnvironment environment)
        {
            var config = configuration.GetSection("UploadDir");
            RootFolder = config.Value ?? Path.Combine(environment.ContentRootPath, "Uploads");
            SetupMainFolderPath();
        }
      
        public string GetTempFolderPath()
        {
            var folderPath = Path.Combine(RootFolder, FolderNameEnum.AppTemporary.ToString());
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);
            return folderPath;
        }

        public void SetupMainFolderPath()
        {
            if (!Directory.Exists(RootFolder))
                Directory.CreateDirectory(RootFolder);
        }
        public string ToDirectoryPath(string category)
        {
            var directory = Path.Combine(RootFolder, category);
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);
            return directory;
        }
        public string GetFolderPath(string dirName)
        {
            var folderPath = Path.Combine(RootFolder, dirName);
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);
            return folderPath;
        }

    }
}