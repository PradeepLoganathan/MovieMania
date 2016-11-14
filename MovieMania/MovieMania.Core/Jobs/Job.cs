using Newtonsoft.Json;
using System.Collections.Generic;

namespace MovieMania.Core.Jobs
{
    public class Job
    {
        [JsonProperty("department")]
        public string Department { get; set; }

        [JsonProperty("job_list")]
        public List<string> JobList { get; set; }
    }
}
