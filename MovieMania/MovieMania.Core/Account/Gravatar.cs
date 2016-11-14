using Newtonsoft.Json;

namespace MovieMania.Core.Account
{
    public class Gravatar
    {
        [JsonProperty("hash")]
        public string Hash { get; set; }
    }
}
