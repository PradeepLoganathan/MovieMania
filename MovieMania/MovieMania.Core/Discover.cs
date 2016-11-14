using Android.Graphics;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections;

using System.Diagnostics;
using Newtonsoft.Json.Linq;

namespace MovieMania.Core
{
   /* public class Discover:IEnumerable<DiscoverResponse>
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
                //TODO : Make HTTPClient into a singleton or static instance
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.TryAddWithoutValidation("accept", "application/json");
                    string url = LoadConfig.ConfigValues["BaseURL"] + "discover/movie" + "?api_key=" + LoadConfig.ConfigValues["APPID"];
                    using (HttpResponseMessage response = await client.GetAsync(url))
                    using (HttpContent content = response.Content)
                    {
                        string convertresponse = await content.ReadAsStringAsync();
                        dynamic dynObj = JsonConvert.DeserializeObject(convertresponse);
                        

                        //JContainer is the base class
                        var jObj = (JObject)dynObj;

                        var dict = JsonConvert.DeserializeObject<Dictionary<string, object>>(jObj.ToString());

                        Debug.WriteLine("===============================================================================================");

                        foreach (JToken token in jObj.Children())
                        {
                            if (token is JProperty)
                            {
                                var prop = token as JProperty;
                                Debug.WriteLine("{0}={1}", prop.Name, prop.Value);
                            }
                        }

                        Debug.WriteLine("===============================================================================================");

                        Debug.WriteLine("***********************************************************************************************");

                        foreach (var token in dict)
                        {
                            Debug.WriteLine("{0}={1}", token.Key, token.Value);
                            if (token.Key.Contains("[0:] page"))
                                this.page = (int)token.Value;
                            else if (token.Key.Contains("[0:] results"))
                                this.results = (DiscoverResponse[])token.Value;
                        }

                        Debug.WriteLine("***********************************************************************************************");

                        /*foreach (DiscoverResponse dr in discresp1)
                            dr.InflateImages();

                        return (Discover)dynObj;
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

        private async Task GetImageBitmapFromUrlAsync(string url)
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

          
        }

        public async void InflateImages()
        {
            await this.GetImageBitmapFromUrlAsync(LoadConfig.ConfigValues["BaseURL"] + this.backdrop_path);
        }
    }*/

}
