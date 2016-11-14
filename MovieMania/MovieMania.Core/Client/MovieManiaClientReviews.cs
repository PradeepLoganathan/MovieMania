using MovieMania.Core.Rest;
using MovieMania.Reviews;
using System.Threading.Tasks;

namespace MovieMania.Core.Client
{
    public partial class MovieManiaClient
    {
        public async Task<Review> GetReviewAsync(string reviewId)
        {
            RestRequest request  = _client.Create("review/{reviewId}");
            request.AddUrlSegment("reviewId", reviewId);

            // TODO: Dateformat?
            //request.DateFormat = "yyyy-MM-dd";

            RestResponse<Review> resp = await request.ExecuteGet<Review>().ConfigureAwait(false);

            return resp;
        }
    }
}
