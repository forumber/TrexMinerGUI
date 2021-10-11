using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace TrexMinerGUI
{
    public static class GithubAPI
    {
        private class Json
        {
            public class Asset
            {
                public string browser_download_url { get; set; }
            }

            public string tag_name { get; set; }
            public List<Asset> assets { get; set; }

        }

        private static Json DownloadAndParseJson(string JsonURL)
        {
            string json;

            using (WebClient wc = new WebClient())
            {
                wc.Headers.Add("user-agent", "Github does not give permission without this header, lol");
                json = wc.DownloadString(JsonURL);
            }

            return JsonConvert.DeserializeObject<Json>(json);
        }

        public static (Version, string) GetLatestTrexRelease()
        {
            Json JsonResult = DownloadAndParseJson("https://api.github.com/repos/trexminer/T-Rex/releases/latest");

            string WindowsDownloadLink = JsonResult.assets.Where(s => s.browser_download_url.Contains("win")).FirstOrDefault().browser_download_url;

            return (new Version(JsonResult.tag_name), WindowsDownloadLink);
        }

    }
}
