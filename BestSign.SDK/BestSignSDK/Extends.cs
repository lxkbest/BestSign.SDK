using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BestSignSDK
{
    public static class Extends
    {

        public static string ToValue(this System.Enum obj)
        {
            return obj.GetHashCode().ToString();
        }

        public static string ToQueryString(this IDictionary<string, object> dictionary)
        {
            var sb = new StringBuilder();
            foreach (var key in dictionary.Keys)
            {
                var value = dictionary[key];
                if (value != null)
                {
                    sb.Append(key + "=" + value + "&");
                }
            }
            return sb.ToString().TrimEnd('&');
        }

        public static string ToQueryString(this IList<object> list, string key)
        {
            var sb = new StringBuilder();
            foreach (var val in list)
            {
                if (val != null)
                {
                    sb.Append(key + "=" + Uri.EscapeDataString(val.ToString()) + "&");
                }
            }
            return sb.ToString().TrimEnd('&').Substring(key.Length + 1);
        }

        public static T ToEntity<T>(this string str) where T : class
        {
            return ToEntity<T>(str, "json");
        }

        public static T ToEntity<T>(this string str, object format) where T : class
        {
            T t = default(T);
            t = JsonConvert.DeserializeObject<T>(str);
            return t;
        }

    }
}
