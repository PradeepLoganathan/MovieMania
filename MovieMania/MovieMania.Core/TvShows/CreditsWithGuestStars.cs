using System.Collections.Generic;
using Newtonsoft.Json;

namespace MovieMania.TvShows
{
    public class CreditsWithGuestStars : Credits
    {
        [JsonProperty("guest_stars")]
        public List<Cast> GuestStars { get; set; }
    }
}