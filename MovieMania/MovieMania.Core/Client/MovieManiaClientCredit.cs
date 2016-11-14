using MovieMania.Core.Rest;
using System.Threading.Tasks;
using MovieMania.Core.Credit;

namespace MovieMania.Core.Client
{
    public partial class MovieManiaClient
    {
        public async Task<cCredit> GetCreditsAsync(string id)
        {
            return await GetCreditsAsync(id, DefaultLanguage).ConfigureAwait(false);
        }

        public async Task<cCredit> GetCreditsAsync(string id, string language)
        {
            RestRequest req = _client.Create("credit/{id}");

            if (!string.IsNullOrEmpty(language))
                req.AddParameter("language", language);

            req.AddUrlSegment("id", id);

            RestResponse<cCredit> resp = await req.ExecuteGet<cCredit>().ConfigureAwait(false);

            return resp;
        }
    }
}
