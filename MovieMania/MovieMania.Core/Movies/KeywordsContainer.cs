using System.Collections.Generic;
using Newtonsoft.Json;
using MovieMania.Core.General;

namespace MovieMania.Movies
{
    public class KeywordsContainer
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("keywords")]
        public List<Keyword> Keywords { get; set; }
    }
}