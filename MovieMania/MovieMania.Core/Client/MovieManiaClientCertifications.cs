using MovieMania.Certifications;
using MovieMania.Core.Rest;
using System.Threading.Tasks;

namespace MovieMania.Core.Client
{
    public partial class MovieManiaClient
    {
        public async Task<CertificationsContainer> GetMovieCertificationsAsync()
        {
            RestRequest req =  _client.Create("certification/movie/list");

            RestResponse<CertificationsContainer> resp = await req.ExecuteGet<CertificationsContainer>().ConfigureAwait(false);

            return resp;}

        public async Task<CertificationsContainer> GetTvCertificationsAsync()
        {
            RestRequest req =  _client.Create("certification/tv/list");

            RestResponse<CertificationsContainer> resp = await req.ExecuteGet<CertificationsContainer>().ConfigureAwait(false);

            return resp;
        }
    }
}
