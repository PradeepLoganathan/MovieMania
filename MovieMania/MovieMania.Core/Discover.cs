using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MovieMania.Core
{
    public class Discover
    {
        public int page { get; set; }
        public DiscoverResponse[] results { get; set; }
        public int total_results { get; set; }
        public int total_pages { get; set; }

        public async Task<Discover> GoDiscover()
        {
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync("http://api.themoviedb.org/3/discover/movie?"))
            using (HttpContent content = response.Content)
            {
                string result = await content.ReadAsStringAsync();
                Discover discover = JsonConvert.DeserializeObject<Discover>(result);
                return discover;                
            }
        }
    }

    public class DiscoverResponse
    {
        public string poster_path { get; set; }
        public bool adult { get; set; }
        public string overview { get; set; }
        public string release_date { get; set; }
        public int[] genre_ids { get; set; }
        public int id { get; set; }
        public string original_title { get; set; }
        public string original_language { get; set; }
        public string title { get; set; }
        public string backdrop_path { get; set; }
        public float popularity { get; set; }
        public int vote_count { get; set; }
        public bool video { get; set; }
        public float vote_average { get; set; }
    }

   

}
