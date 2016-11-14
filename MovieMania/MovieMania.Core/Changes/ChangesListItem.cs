using Newtonsoft.Json;

namespace MovieMania.Changes
{
    public class ChangesListItem
    {
        [JsonProperty("adult")]
        public bool? Adult { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }
    }
}