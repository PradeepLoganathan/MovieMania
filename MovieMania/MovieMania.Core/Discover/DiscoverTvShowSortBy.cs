using MovieMania.Core.Utilities;
using System;

namespace MovieMania.Discover
{
    public enum DiscoverTvShowSortBy
    {
        [Obsolete]
        Undefined,
        [EnumValue("vote_average.asc")]
        VoteAverage,
        [EnumValue("vote_average.desc")]
        VoteAverageDesc,
        [EnumValue("first_air_date.asc")]
        FirstAirDate,
        [EnumValue("first_air_date.desc")]
        FirstAirDateDesc,
        [EnumValue("popularity.asc")]
        Popularity,
        [EnumValue("popularity.desc")]
        PopularityDesc
    }
}
