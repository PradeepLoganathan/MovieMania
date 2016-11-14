using Newtonsoft.Json;

namespace MovieMania.Movies
{
    public class ProductionCompany
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
