using Newtonsoft.Json;

namespace MovieMania.Core.Search
{
    public class AccountSearchTvEpisode : SearchTvEpisode
    {
        [JsonProperty("rating")]
        public double Rating { get; set; }
    }
}