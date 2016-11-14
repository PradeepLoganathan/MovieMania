using Newtonsoft.Json;

namespace MovieMania.Core.General
{
    public class SearchContainerWithDates<T> : SearchContainer<T>
    {
        [JsonProperty("dates")]
        public DateRange Dates { get; set; }
    }
}
