using Newtonsoft.Json;

namespace MovieMania.Core.Credit
{
    public class CreditPerson
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}