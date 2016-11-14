using Newtonsoft.Json;
using System.Collections.Generic;

namespace MovieMania.Core.TimeZone
{
    public class Timezones
    {
        [JsonProperty("list")]
        public Dictionary<string, List<string>> List { get; set; }
    }
}
