using Newtonsoft.Json;
using System.Collections.Generic;

namespace MovieMania.Core.General
{
    public class PosterImages
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("posters")]
        public List<ImageData> Posters { get; set; }
    }
}
