using MovieMania.Core.General;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMania.Core.Credit
{
    public class cCredit
    {
        [JsonProperty("credit_type")]
        public CreditType CreditType { get; set; }

        [JsonProperty("department")]
        public string Department { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("job")]
        public string Job { get; set; }

        [JsonProperty("media")]
        public CreditMedia Media { get; set; }

        [JsonProperty("media_type")]
        public MediaType MediaType { get; set; }

        [JsonProperty("person")]
        public CreditPerson Person { get; set; }
    }
 }
