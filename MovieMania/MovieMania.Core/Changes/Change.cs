using System.Collections.Generic;
using Newtonsoft.Json;

namespace MovieMania.Changes
{
    public class Change
    {
        [JsonProperty("items")]
        public List<ChangeItemBase> Items { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }
    }
}