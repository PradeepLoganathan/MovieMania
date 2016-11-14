using Newtonsoft.Json;

namespace MovieMania.Lists
{
    public class ListStatus
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("item_present")]
        public bool ItemPresent { get; set; }
    }
}
