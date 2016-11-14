using Newtonsoft.Json;

namespace MovieMania.Core.General
{
    public class Keyword
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
