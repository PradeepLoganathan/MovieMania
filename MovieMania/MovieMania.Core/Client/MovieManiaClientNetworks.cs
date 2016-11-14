using MovieMania.Core.Rest;
using MovieMania.TvShows;
using System.Globalization;
using System.Threading.Tasks;

namespace MovieMania.Core.Client
{
    public partial class MovieManiaClient
    {
        /// <summary>
        /// Retrieves a network by it's TMDb id. A network is a distributer of media content ex. HBO, AMC
        /// </summary>
        /// <param name="networkId">The id of the network object to retrieve</param>
        public async Task<Network> GetNetworkAsync(int networkId)
        {
            RestRequest req = _client.Create("network/{networkId}");
            req.AddUrlSegment("networkId", networkId.ToString(CultureInfo.InvariantCulture));

            RestResponse<Network> response = await req.ExecuteGet<Network>().ConfigureAwait(false);

            return response;
        }
    }
}
