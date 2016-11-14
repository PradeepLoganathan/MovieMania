using MovieMania.Core.Jobs;
using MovieMania.Core.Rest;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieMania.Core.Client
{
    public partial class MovieManiaClient
    {
        /// <summary>
        /// Retrieves a list of departments and positions within
        /// </summary>
        /// <returns>Valid jobs and their departments</returns>
        public async Task<List<Job>> GetJobsAsync()
        {
            RestRequest req = _client.Create("job/list");

            RestResponse<JobContainer> response = await req.ExecuteGet<JobContainer>().ConfigureAwait(false);

            return (await response.GetDataObject().ConfigureAwait(false)).Jobs;
        }
    }
}
