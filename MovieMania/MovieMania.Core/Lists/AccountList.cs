using MovieMania.Core.General;
using Newtonsoft.Json;

namespace MovieMania.Lists
{
    public class AccountList : List
    {
        [JsonProperty("list_type")]
        public MediaType ListType { get; set; }
    }
}