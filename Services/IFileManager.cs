using ChallengeB.Models;
using System.Collections.Generic;

namespace ChallengeB.Services
{
    public interface IFileManager
    {
        List<FileViewModel> GetFiles();
        bool ViewCSVFile(string csvFileName);
    }
}
