using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using BingDailyUWP.Model;

namespace BingDailyUWP.Model
{
    class JsonHelper
    {
        private static string _pictureWidth;
        private static string _pictureHeight;

        public JsonHelper(string width,string height)
        {
            _pictureWidth = width;
            _pictureHeight = height;
        }

        public async Task<string> GetJsonTask()
        {
            Uri uri = new Uri("https://api.ioliu.cn/bing/json/");
            HttpWebRequest webReq = (HttpWebRequest) WebRequest.Create(uri);
            string received;

            using (
                var webResp =
                    (HttpWebResponse)
                        (await Task<WebResponse>.Factory.FromAsync(webReq.BeginGetResponse,webReq.EndGetResponse,null))
                )
            {
                using (var webRespStream = webResp.GetResponseStream())
                {
                    using (var stream = new StreamReader(webRespStream))
                    {
                        received = await stream.ReadToEndAsync();
                    }
                }
            }
            return received;
        }

        public PictureModel TransJson(string oriJson)
        {
            Hashtable json = JsonConvert.DeserializeObject(oriJson,typeof(Hashtable)) as Hashtable;
            // make a new json
            string pictureId = json?["id"].ToString();
            string pictureTitle = json?["title"].ToString();
            string pictureAttr = json?["attribute"].ToString();
            string pictureDescription = json?["description"].ToString();
            string pictureStartdate = json?["startdate"].ToString();
            string pictureEnddate = json?["enddate"].ToString();
            string pictureFullstartdate = json?["fullstartdate"].ToString();
            string pictureUrl = json?["url"].ToString();
            string pictureUrlbase = json?["urlbase"].ToString();
            string pictureCopyright = json?["copyright"].ToString();
            string pictureCopyrightlink = json?["copyrightlink"].ToString();
            string pictureHsh = json?["hsh"].ToString();
            string pictureQiniuUrl = json?["qiniu_url"].ToString();
            string pictureDate = json?["date"].ToString();

            string newJson = $"{{'PictureId':'{pictureId}','PictureTitle':'{pictureTitle}','PictureAttr':'{pictureAttr}','PictureDescription':'{pictureDescription}'," +
                             $"'PictureStartdate':'{pictureStartdate}','PictureEnddate':'{pictureEnddate}','PictureFullstartdate':'{pictureFullstartdate}','PictureUrl':'{pictureUrl}'," +
                             $"'PictureUrlbase':'{pictureUrlbase}','PictureCopyright':'{pictureCopyright}','PictureCopyrightlink':'{pictureCopyrightlink}','PictureHsh':'{pictureHsh}'," +
                             $"'PictureQiniuUrl':'{pictureQiniuUrl}','PictureDate':'{pictureDate}'}}";

            // Deserialize JSON TO Object
            PictureModel pm = JsonConvert.DeserializeObject<PictureModel>(newJson);
            return pm;
        }
    }
}