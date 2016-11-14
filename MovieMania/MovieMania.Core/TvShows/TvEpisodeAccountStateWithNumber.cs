using Newtonsoft.Json;

namespace MovieMania.TvShows
{
    public class TvEpisodeAccountStateWithNumber : TvEpisodeAccountState
    {
        [JsonProperty("episode_number")]
        public int EpisodeNumber { get; set; }
    }
}