using Newtonsoft.Json;

namespace MovieMania.TvShows
{
    public class Network
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
