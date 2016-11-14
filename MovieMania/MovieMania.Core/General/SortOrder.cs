using MovieMania.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMania.Core.General
{
    public enum SortOrder
    {
        Undefined = 0,
        [EnumValue("asc")]
        Ascending = 1,
        [EnumValue("desc")]
        Descending = 2
    }
}
