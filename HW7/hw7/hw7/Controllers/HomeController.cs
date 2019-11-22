using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace hw7.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string apiKey = WebConfigurationManager.AppSettings["credentials"];
            string uri = "https://api.github.com/user";
            string username = "jgillespie17";

            string jsonString = SendRequest(uri, apiKey, username);
            //JArray jsonArray = JArray.Parse(jsonString);
            //dynamic obj = JObject.Parse(jsonArray[0].ToString());
            var obj = JObject.Parse(jsonString);
            UserInfo userinfo = new UserInfo
            {
                Username = (string)obj.SelectToken("login"),
                AvatarURL = (string)obj.SelectToken("avatar_url"),
                HtmlUrl = (string)obj.SelectToken("html_url"),
                Name = (string)obj.SelectToken("name"),
                Company = (string)obj.SelectToken("company"),
                Location = (string)obj.SelectToken("location"),
                Email = (string)obj.SelectToken("email")
            };
            return View(userinfo);
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

        public class UserInfo
        {
            public string Username { get; set; }

            public string AvatarURL { get; set; }

            public string HtmlUrl { get; set; }

            public string  Name { get; set; }

            public string Company { get; set; }

            public string Location { get; set; }

            public string Email { get; set; }

        }
    }
}