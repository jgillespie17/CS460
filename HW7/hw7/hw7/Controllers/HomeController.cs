using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web.Mvc;
using System.Web.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using hw7.Models;
using hw7.Models.ViewModels;

namespace hw7.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string apiKey = WebConfigurationManager.AppSettings["credentials"];
            string UserUri = "https://api.github.com/user";

            string username = "jgillespie17";
            string jsonString = SendRequest(UserUri, apiKey, username);


            var UserObj = JObject.Parse(jsonString);
            UserInfo userinfo = new UserInfo
            {
                Username = (string)UserObj.SelectToken("login"),
                AvatarURL = (string)UserObj.SelectToken("avatar_url"),
                HtmlUrl = (string)UserObj.SelectToken("html_url"),
                Name = (string)UserObj.SelectToken("name"),
                Company = (string)UserObj.SelectToken("company"),
                Location = (string)UserObj.SelectToken("location"),
                Email = (string)UserObj.SelectToken("email")
            };

            string RepoUri = "https://api.github.com/user/repos";
            string jsonArrayString = SendRequest(RepoUri, apiKey, username);
            JArray jsonArray = JArray.Parse(jsonArrayString);
            JObject RepoObj = JObject.Parse(jsonArray[0].ToString());

            RepoInfo repoInfo = new RepoInfo
            {
                RepoName = (string)RepoObj.SelectToken("name"),
                Owner = (string)RepoObj.SelectToken("owner.login"),
                RepoHtmlUrl = (string)RepoObj.SelectToken("html_url"),
                OwnerAvatarURL = (string)RepoObj.SelectToken("owner.avatar_url"),
                LastUpdated = (DateTime)RepoObj.SelectToken("updated_at")

            };
            UserRepoViewModel viewModel = new UserRepoViewModel(userinfo, repoInfo);
            
            return View(viewModel);
        }

        private string SendRequest(string uri, string credentials, string username)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Headers.Add("Authorization", "token " + credentials);
            request.UserAgent = username;
            request.Accept = "application/json";

            string jsonString = null;
            using (WebResponse response = request.GetResponse())
            {
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                jsonString = reader.ReadToEnd();
                reader.Close();
                stream.Close();
            }
            return jsonString;
        }
    }
}