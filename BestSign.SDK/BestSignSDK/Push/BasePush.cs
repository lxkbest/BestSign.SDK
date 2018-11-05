using Newtonsoft.Json;

namespace BestSign.SDK.BestSignSDK.Push
{
    public class BasePush<T> where T : class, IPush
    {
        [JsonProperty("action")]
        public string action { get; set; }

        [JsonProperty("params")]
        public T parametes { get;set;}
    }
}
