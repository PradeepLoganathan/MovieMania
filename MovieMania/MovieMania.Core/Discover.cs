using Android.Graphics;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace MovieMania.Core
{
    public class Discover:IEnumerable<DiscoverResponse>
    {
        public int page { get; set; }
        public DiscoverResponse[] results { get; set; }
        public int total_results { get; set; }
        public int total_pages { get; set; }

        public async Task<Discover> GoDiscover()
        {
            Discover discresp;

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = LoadConfig.ConfigValues["BaseURL"] + "discover/movie" + "?api_key=" + LoadConfig.ConfigValues["APPID"];
                    using (HttpResponseMessage response = await client.GetAsync(url))
                    using (HttpContent content = response.Content)
                    {
                        string result = await content.ReadAsStringAsync();
                        discresp = JsonConvert.DeserializeObject<Discover>(result);
                        foreach (DiscoverResponse dr in discresp)
                            dr.InflateImages();
                        
                        return discresp;
                    }
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public IEnumerator<DiscoverResponse> GetEnumerator()
        {
            yield return (DiscoverResponse)results.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            yield return results.GetEnumerator();
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
        public Bitmap Screen_Image { get; set; }

        private async Task<Bitmap> GetImageBitmapFromUrlAsync(string url)
        {
            Bitmap imageBitmap = null;

            using (var httpClient = new HttpClient())
            {
                var imageBytes = await httpClient.GetByteArrayAsync(url);
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                    this.Screen_Image = imageBitmap;
                }
            }

            return imageBitmap;
        }

        public async void InflateImages()
        {
            await this.GetImageBitmapFromUrlAsync(this.backdrop_path);
        }
    }

}
