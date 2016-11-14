
using Newtonsoft.Json;
using System;

namespace MovieMania.Core.General
{
    public class DateRange
    {
        [JsonProperty("maximum")]
        public DateTime Maximum { get; set; }

        [JsonProperty("minimum")]
        public DateTime Minimum { get; set; }
    }
}
