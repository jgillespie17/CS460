using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace hw7.Models
{
    public class RepoInfo
    {
        public string RepoName { get; set; }
        public string Owner { get; set; }
        public string RepoHtmlUrl { get; set; }
        public string OwnerAvatarURL { get; set; }
        public DateTime LastUpdated { get; set; }

        [Display(Name = "Last Updated: ")]
        public int RepoLastUpdated { get; set; }

    }
}