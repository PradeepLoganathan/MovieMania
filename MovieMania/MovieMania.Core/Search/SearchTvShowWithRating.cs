using Newtonsoft.Json;

namespace MovieMania.Core.Search
{
    public class SearchTvShowWithRating : SearchTv
    {
        [JsonProperty("rating")]
        public double Rating { get; set; }
    }
}