using Newtonsoft.Json;

namespace MovieMania.Core.General
{
    public class ExternalIdsTvSeason : ExternalIds
    {
        [JsonProperty("tvdb_id")]
        public string TvdbId { get; set; }
    }
}
