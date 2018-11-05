using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BestSignSDK
{
    public interface IHttpService
    {
        T HttpGet<T>(string url) where T : class;

        T HttpPost<T>(string url, Dictionary<string, object> dictionary) where T : class;

        bool HttpDownload(string url, string path); 
    }
}
