using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hw7.Models
{
    public class CommitInfo
    {
        public string Sha { get; set; }
        public string Commiter { get; set; }
        public DateTime WhenCommited { get; set; }
        public string CommitMessage { get; set; }
        public string CommitHtmlURL { get; set; }
    }
}