﻿using MovieMania.Core.Collections;
using MovieMania.Core.Discover;
using MovieMania.Core.General;
using MovieMania.Core.Rest;
using MovieMania.Discover;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieMania.Core.Client
{
    public partial class MovieManiaClient
    {
        /// <summary>
        /// Can be used to discover movies matching certain criteria
        /// </summary>
        public DiscoverMovie DiscoverMoviesAsync()
        {
            return new DiscoverMovie(this);
        }

        internal async Task<SearchContainer<T>> DiscoverPerformAsync<T>(string endpoint, string language, int page, SimpleNamedValueCollection parameters)
        {
            RestRequest request = _client.Create(endpoint);

            if (page != 1 && page > 1)
                request.AddParameter("page", page.ToString());

            if (!string.IsNullOrWhiteSpace(language))
                request.AddParameter("language", language);

            foreach (KeyValuePair<string, string> pair in parameters)
                request.AddParameter(pair.Key, pair.Value);

            RestResponse<SearchContainer<T>> response = await request.ExecuteGet<SearchContainer<T>>().ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// Can be used to discover new tv shows matching certain criteria
        /// </summary>
        public DiscoverTv DiscoverTvShowsAsync()
        {
            return new DiscoverTv(this);
        }
    }
}