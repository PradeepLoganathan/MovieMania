using Newtonsoft.Json;
using System.Collections.Generic;

namespace MovieMania.Core.General
{
    public class TranslationsContainer
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("translations")]
        public List<TranslationWithCountry> Translations { get; set; }
    }
}
