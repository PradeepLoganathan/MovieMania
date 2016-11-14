using Newtonsoft.Json;

namespace MovieMania.Core.General
{
    public class ExternalIdsTvShow : ExternalIds
    {
        [JsonProperty("imdb_id")]
        public string ImdbId { get; set; }

        [JsonProperty("tvdb_id")]
        public string TvdbId { get; set; }
    }
}
