using Newtonsoft.Json;

namespace MovieMania.Core.Search
{
    public class AccountSearchTv : SearchTv
    {
        [JsonProperty("rating")]
        public float Rating { get; set; }
    }
}