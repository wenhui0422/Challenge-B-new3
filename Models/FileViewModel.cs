using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChallengeB.Models
{
    public class FileViewModel
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}