using MovieMania.Core.Utilities;
using System;

namespace MovieMania.Companies
{
    [Flags]
    public enum CompanyMethods
    {
        [EnumValue("Undefined")]
        Undefined = 0,
        [EnumValue("movies")]
        Movies = 1
    }
}