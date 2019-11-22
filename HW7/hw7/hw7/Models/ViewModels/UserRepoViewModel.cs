using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace hw7.Models.ViewModels
{
    public class UserRepoViewModel
    {
        public UserRepoViewModel(UserInfo userInfo, RepoInfo repoInfo)
        {
            Username = userInfo.Username;
            UserAvatarURL = userInfo.AvatarURL;
            UserHtmlUrl = userInfo.HtmlUrl;
            PersonName = userInfo.Name;
            UserCompany = userInfo.Company;
            UserLocation = userInfo.Location;
            UserEmail = userInfo.Email;

            RepoName = repoInfo.RepoName;
            RepoOwner = repoInfo.Owner;
            RepoHtmlUrl = repoInfo.RepoHtmlUrl;
            RepoOwnerAvatarURL = repoInfo.OwnerAvatarURL;
            RepoLastUpdated = (DateTime.Now - repoInfo.LastUpdated).Days;
        }
        //Userinfo
        public string Username { get; set; }
        public string UserAvatarURL { get; set; }
        public string UserHtmlUrl { get; set; }
        public string PersonName { get; set; }
        public string UserCompany { get; set; }
        public string UserLocation { get; set; }
        public string UserEmail { get; set; }

        //RepoInfo
        public string RepoName { get; set; }
        public string RepoOwner { get; set; }
        public string RepoHtmlUrl { get; set; }
        public string RepoOwnerAvatarURL { get; set; }

        [Display(Name = "Last Updated: ") ]
        public int RepoLastUpdated { get; set; }
    }
}