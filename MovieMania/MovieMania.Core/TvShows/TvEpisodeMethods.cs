﻿using MovieMania.Core.Utilities;
using System;


namespace MovieMania.TvShows
{
    [Flags]
    public enum TvEpisodeMethods
    {
        [EnumValue("Undefined")]
        Undefined = 0,
        [EnumValue("credits")]
        Credits = 1,
        [EnumValue("images")]
        Images = 2,
        [EnumValue("external_ids")]
        ExternalIds = 4,
        [EnumValue("videos")]
        Videos = 8,
        [EnumValue("account_states")]
        AccountStates = 16,
    }
}
