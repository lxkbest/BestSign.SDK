using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BestSignSDK
{
    public interface IHttpMethod
    {
        string HttpGet(string url);
        string HttpPost(string url, string param);
        bool HttpDownload(string url, string path);

        //string HttpPost(string url, IDictionary<string, object> param, byte[] fileByte);

    }
}
