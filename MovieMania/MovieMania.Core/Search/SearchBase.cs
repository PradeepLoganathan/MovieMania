using Newtonsoft.Json;
using MovieMania.Core.Utilities.Converters;
using MovieMania.Core.General;

namespace MovieMania.Core.Search
{
    [JsonConverter(typeof(SearchBaseConverter))]
    public class SearchBase
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonIgnore]
        [JsonProperty("media_type")]
        public MediaType MediaType { get; set; }

        [JsonProperty("popularity")]
        public double Popularity { get; set; }
    }
}