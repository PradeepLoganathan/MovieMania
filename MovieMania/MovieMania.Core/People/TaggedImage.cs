﻿using MovieMania.Core.General;
using MovieMania.Core.Search;
using MovieMania.Core.Utilities.Converters;
using Newtonsoft.Json;

namespace MovieMania.Core.People
{
    [JsonConverter(typeof(TaggedImageConverter))]
    public class TaggedImage
    {
        [JsonProperty("aspect_ratio")]
        public double AspectRatio { get; set; }

        [JsonProperty("file_path")]
        public string FilePath { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("image_type")]
        public string ImageType { get; set; } // TODO: Turn into enum

        /// <summary>
        /// A language code, e.g. en
        /// </summary>
        [JsonProperty("iso_639_1")]
        public string Iso_639_1 { get; set; }

        [JsonIgnore]
        [JsonProperty("media")]
        public SearchBase Media { get; set; }

        [JsonProperty("media_type")]
        public MediaType MediaType { get; set; }

        [JsonProperty("vote_average")]
        public double VoteAverage { get; set; }

        [JsonProperty("vote_count")]
        public int VoteCount { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }
    }
}