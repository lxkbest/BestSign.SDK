using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BestSignSDK
{
    public class HttpService : IHttpService
    {
        public HttpService()
        {
            HttpMethod = new HttpMethods();
        }

        public IHttpMethod HttpMethod { get; private set; }

        public T HttpGet<T>(string url) where T : class
        {
            var json = HttpMethod.HttpGet(url);
            return json.ToEntity<T>("json");
        }

        public T HttpPost<T>(string url, Dictionary<string, object> dictionary) where T : class
        {
            var paramsData = JsonConvert.SerializeObject(dictionary);
            var json = HttpMethod.HttpPost(url, paramsData);
            return json.ToEntity<T>();
        }

        public bool HttpDownload(string url, string path)
        {
            var flag = HttpMethod.HttpDownload(url, path);
            return flag;
        }
    }
}
