using Newtonsoft.Json;
using System.Collections.Generic;

namespace MovieMania.Core.General
{
    public class TranslationsContainerTv
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("translations")]
        public List<Translation> Translations { get; set; }
    }
}
