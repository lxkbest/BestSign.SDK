using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace BestSignSDK
{
    public class SignUtils
    {
        public static string GenerateMD5(Dictionary<string, object> bodyData)
        {
            string json = JsonConvert.SerializeObject(bodyData);
            var md5 = CreateMD5Hash(json);
            return md5;
        }

        public static string GenerateSign(string path, string paramsMD5, SortedDictionary<string, object> keyValues)
        {
            string sign = string.Empty;
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<string, object> item in keyValues)
            {
                sb.Append(item.Key + "=" + item.Value);
            }
            sb.Append(path);
            sb.Append(paramsMD5);
            return sb.ToString();
        }

        public static string GenerateUrl(string requestUrl, SortedDictionary<string, object> keyValues)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var key in keyValues.Keys)
            {
                var value = keyValues[key];
                if (value != null)
                {
                    sb.Append(key + "=" + value + "&");
                }
            }
            return requestUrl + "?" + sb.ToString().TrimEnd('&');
        }

        public static string SignUrlEncode(string signBase64)
        {
            return HttpUtility.UrlEncode(signBase64, Encoding.UTF8);
        }

        public static string CreateMD5Hash(string input)
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("x2"));
            }
            return sb.ToString();
        }

        public static string CreateMD5Hex(byte[] inputBytes)
        {
            MD5 md5 = MD5.Create();
            byte[] hashBytes = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("x2"));
            }
            return sb.ToString();
        }

        public static long ToUnixEpochDate(DateTime date) => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds); // (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000;

        public static int ToRandom(int min, int max) => new Random().Next(min, max);

        public static Stream FileToStream(string fileName)
        {
            FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            byte[] bytes = new byte[fileStream.Length];
            fileStream.Read(bytes, 0, bytes.Length);
            fileStream.Dispose();
            Stream stream = new MemoryStream(bytes);
            return stream;
        }

        public static Stream BytesToStream(byte[] bytes)
        {
            Stream stream = new MemoryStream(bytes);
            return stream;
        }

        public static byte[] StreamToBytes(Stream stream)
        {
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            stream.Seek(0, SeekOrigin.Begin);
            return bytes;
        }
    }
}
