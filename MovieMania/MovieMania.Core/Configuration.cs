using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MovieMania.Core
{
      
    public class Configuration
    {
        public Images images { get; set; }
        public string[] change_keys { get; set; }

        public async void GetConfiguration()
        {
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync("http://api.themoviedb.org/3/configuration?"))
            using (HttpContent content = response.Content)
            {
                string result = await content.ReadAsStringAsync();
                //Movie Movielist = JsonConvert.DeserializeObject<Movie>(result);
                //await context.Response.WriteAsync(result);
            }
        }
    }

    public class Images
    {
        public string base_url { get; set; }
        public string secure_base_url { get; set; }
        public string[] backdrop_sizes { get; set; }
        public string[] logo_sizes { get; set; }
        public string[] poster_sizes { get; set; }
        public string[] profile_sizes { get; set; }
        public string[] still_sizes { get; set; }
    }
}
