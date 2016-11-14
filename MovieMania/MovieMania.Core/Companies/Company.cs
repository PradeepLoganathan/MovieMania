using MovieMania.Core.General;
using MovieMania.Core.Search;
using Newtonsoft.Json;

namespace MovieMania.Companies
{
    public class Company
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("headquarters")]
        public string Headquarters { get; set; }

        [JsonProperty("homepage")]
        public string Homepage { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("logo_path")]
        public string LogoPath { get; set; }

        [JsonProperty("movies")]
        public SearchContainer<SearchMovie> Movies { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("parent_company")]
        public SearchCompany ParentCompany { get; set; }
    }
}