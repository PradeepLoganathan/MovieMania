using System.Collections.Generic;
using Newtonsoft.Json;
using MovieMania.Core.Search;

namespace MovieMania.Lists
{
    public class GenericList : List
    {
        [JsonProperty("created_by")]
        public string CreatedBy { get; set; }

        [JsonProperty("items")]
        public List<SearchMovie> Items { get; set; }
    }
}