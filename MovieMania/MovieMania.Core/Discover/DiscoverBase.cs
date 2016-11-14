using MovieMania.Core.Client;
using MovieMania.Core.Collections;
using MovieMania.Core.General;
using System.Threading.Tasks;

namespace MovieMania.Discover
{
    public abstract class DiscoverBase<T>
    {
        private readonly MovieManiaClient _client;
        private readonly string _endpoint;
        protected readonly SimpleNamedValueCollection Parameters;

        public DiscoverBase(string endpoint, MovieManiaClient client)
        {
            _endpoint = endpoint;
            _client = client;
            Parameters = new SimpleNamedValueCollection();
        }

        public async Task<SearchContainer<T>> Query(int page = 0)
        {
            return await Query(_client.DefaultLanguage, page).ConfigureAwait(false);
        }

        public async Task<SearchContainer<T>> Query(string language, int page = 0)
        {
            return await _client.DiscoverPerformAsync<T>(_endpoint, language, page, Parameters).ConfigureAwait(false);
        }
    }
}