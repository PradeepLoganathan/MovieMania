using Newtonsoft.Json;
using System.Collections.Generic;

namespace MovieMania.Core.General
{
    public class StillImages
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("stills")]
        public List<ImageData> Stills { get; set; }
    }
}
