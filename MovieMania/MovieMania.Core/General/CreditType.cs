using MovieMania.Core.Utilities;

namespace MovieMania.Core.General
{
    public enum CreditType
    {
        Unknown,

        [EnumValue("crew")]
        Crew = 1,

        [EnumValue("cast")]
        Cast = 2
    }
}
