using Newtonsoft.Json;

namespace MovieMania.Core.Account
{
    public class Avatar
    {
        [JsonProperty("gravatar")]
        public Gravatar Gravatar { get; set; }
    }
}
