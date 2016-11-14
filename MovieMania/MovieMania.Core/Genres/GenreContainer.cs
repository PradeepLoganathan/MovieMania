using MovieMania.Core.General;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMania.Core.Genres
{
    public class GenreContainer
    {
        [JsonProperty("genres")]
        public List<Genre> Genres { get; set; }
    }
}
