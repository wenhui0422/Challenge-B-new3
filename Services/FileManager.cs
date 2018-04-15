using ChallengeB.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace ChallengeB.Services
{
    public class FileManager : IFileManager
    {
        public IConfiguration _configuration;

        public FileManager(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                            .SetBasePath(env.ContentRootPath)
                            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            _configuration = builder.Build();
        }

        public string FetchedFolder
        {
            get
            {
                return _configuration.GetSection("DownloadFolder:Fetched").Value;
            }
        }

        public List<FileViewModel> GetFiles()
        {
            List<FileViewModel> files = new List<FileViewModel>();

            string fetchedFolder = FetchedFolder;

            if (Directory.Exists(fetchedFolder))
            {
                var dirs = Directory.GetDirectories(fetchedFolder);

                var sorteddirs = dirs.OrderByDescending(x => new DirectoryInfo(x).CreationTime);

                foreach (var dir in sorteddirs)
                {
                    var dfiles = Directory.GetFiles(dir, "*.csv");

                    foreach (var file in dfiles)
                    {
                        var currFile = new FileInfo(file);

                        files.Add(new FileViewModel { FileName = currFile.Name, FilePath = currFile.FullName, CreatedDate = currFile.LastWriteTime });
                    }
                }
            }

            return files;
        }

        public bool ViewCSVFile(string csvFileName)
        {
            //try
            //{
            //    Process proc = new Process();

            //    //Define location of adobe reader/command line
            //    proc.StartInfo.FileName = csvFileName;

            //    proc.Start();
            //    proc.EnableRaisingEvents = true;

            //    proc.Close();
            //    return true;
            //}
            //catch
            //{
            //    return false;
            //}
            return true;
        }

    }
}
