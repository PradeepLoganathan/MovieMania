using MovieMania.Core.Utilities;
using System;

namespace MovieMania.Collections
{
    [Flags]
    public enum CollectionMethods
    {
        [EnumValue("Undefined")]
        Undefined = 0,
        [EnumValue("images")]
        Images = 1
    }
}