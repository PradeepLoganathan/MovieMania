using MovieMania.Core.Utilities.Converters;
using Newtonsoft.Json;

namespace MovieMania.TvShows
{
    [JsonConverter(typeof(AccountStateConverter))]
    public class TvAccountState
    {
        [JsonProperty("rating")]
        public double? Rating { get; set; }
    }
}