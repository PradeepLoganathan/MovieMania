using System.Collections.Generic;
using Newtonsoft.Json;
using MovieMania.Core.General;

namespace MovieMania.Movies
{
    public class AlternativeTitles
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("titles")]
        public List<AlternativeTitle> Titles { get; set; }
    }
}