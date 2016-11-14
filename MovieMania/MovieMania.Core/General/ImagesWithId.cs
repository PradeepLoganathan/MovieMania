using Newtonsoft.Json;

namespace MovieMania.Core.General
{
    public class ImagesWithId : Images
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
