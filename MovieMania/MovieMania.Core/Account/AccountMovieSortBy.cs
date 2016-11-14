using MovieMania.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMania.Core.Account
{
    public enum AccountSortBy
    {
        Undefined = 0,
        [EnumValue("created_at")]
        CreatedAt = 1,
    }
}
