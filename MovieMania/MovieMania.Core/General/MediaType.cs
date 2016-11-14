using MovieMania.Core.Utilities;

namespace MovieMania.Core.General
{
    public enum MediaType
    {
        Unknown,

        [EnumValue("movie")]
        Movie = 1,

        [EnumValue("tv")]
        Tv = 2,

        [EnumValue("person")]
        Person = 3
    }
}
