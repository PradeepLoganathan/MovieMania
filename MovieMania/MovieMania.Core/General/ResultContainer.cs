using Newtonsoft.Json;
using System.Collections.Generic;

namespace MovieMania.Core.General
{
    public class ResultContainer<T>
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("results")]
        public List<T> Results { get; set; }
    }
}
