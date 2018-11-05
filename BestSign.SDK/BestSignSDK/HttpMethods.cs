using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace BestSignSDK
{
    public class HttpMethods : IHttpMethod
    {
        public virtual string HttpGet(string url)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Method = "GET";
            //request.ContentType = "application/x-www-form-urlencoded";
            request.Accept = "*/*";
            request.Timeout = 150000;
            request.AllowAutoRedirect = false;

            WebResponse response = null;
            string responseStr = null;

            try
            {
                response = request.GetResponse();

                if (response != null)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                    responseStr = reader.ReadToEnd();
                    reader.Close();
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                request = null;
                response = null;
            }

            return responseStr;
        }

        public virtual string HttpPost(string url, string param)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Accept = "*/*";
            request.Timeout = 5000;
            request.AllowAutoRedirect = false;
            StreamWriter requestStream = null;
            WebResponse response = null;
            string responseStr = null;

            try
            {
                requestStream = new StreamWriter(request.GetRequestStream());
                requestStream.Write(param);
                requestStream.Close();

                response = request.GetResponse();
                if (response != null)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                    responseStr = reader.ReadToEnd();
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
               var msg = ex.Message.ToString();
            }
            finally
            {
                request = null;
                requestStream = null;
                response = null;
            }

            return responseStr;
        }

        public virtual bool HttpDownload(string url, string path)
        {
            bool flag = false;
            long startPosition = 0;
            FileStream writeStream;
            if (File.Exists(path))
            {
                writeStream = File.OpenWrite(path);
                startPosition = writeStream.Length;
                writeStream.Seek(startPosition, SeekOrigin.Current);
            }
            else
            {
                writeStream = new FileStream(path, FileMode.Create);
                startPosition = 0;
            }

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Method = "GET";
            request.Accept = "*/*";
            request.Timeout = 150000;
            request.AllowAutoRedirect = false;
            try
            {
                if (startPosition > 0)
                {
                    request.AddRange((int)startPosition);
                }
                Stream readStream = request.GetResponse().GetResponseStream();
                byte[] btArray = new byte[512];
                int contentSize = readStream.Read(btArray, 0, btArray.Length);
                while (contentSize > 0)
                {
                    writeStream.Write(btArray, 0, contentSize);
                    contentSize = readStream.Read(btArray, 0, btArray.Length);
                }

                writeStream.Close();
                readStream.Close();

                flag = true;
            }
            catch (Exception)
            {
                writeStream.Close();
                flag = false;
            }
            return flag;
        }
    }
}
