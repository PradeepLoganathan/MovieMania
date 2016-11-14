﻿using System;
using Newtonsoft.Json;
using MovieMania.Core.Helpers;
using MovieMania.Core.Utilities.Converters;

namespace MovieMania.Changes
{
    [JsonConverter(typeof(ChangeItemConverter))]
    public abstract class ChangeItemBase
    {
        [JsonIgnore]
        [JsonProperty("action")]
        public ChangeAction Action { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// A language code, e.g. en
        /// This field is not always set
        /// </summary>
        [JsonProperty("iso_639_1")]
        public string Iso_639_1 { get; set; }

        [JsonProperty("time")]
        [JsonConverter(typeof(TmdbUtcTimeConverter))]
        public DateTime Time { get; set; }
    }
}