using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hw7.Models
{
    public class CommitInfo
    {
        public string Sha { get; set; }
        public string Committer { get; set; }
        public DateTime TimeStamp { get; set; }
        public string CommitMessage { get; set; }
        public string CommitHtmlURL { get; set; }
    }
}