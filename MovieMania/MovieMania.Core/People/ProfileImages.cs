using System.Collections.Generic;
using Newtonsoft.Json;
using MovieMania.Core.General;

namespace MovieMania.Core.People
{
    public class ProfileImages
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("profiles")]
        public List<ImageData> Profiles { get; set; }
    }
}