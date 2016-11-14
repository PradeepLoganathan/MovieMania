using Newtonsoft.Json;

namespace MovieMania.Core.General
{
    public class ExternalIdsPerson : ExternalIds
    {
        [JsonProperty("facebook_id")]
        public string FacebookId { get; set; }

        [JsonProperty("imdb_id")]
        public string ImdbId { get; set; }

        [JsonProperty("twitter_id")]
        public string TwitterId { get; set; }
    }
}
