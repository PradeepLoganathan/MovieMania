using MovieMania.Core.Utilities;

namespace MovieMania.Changes
{
    public enum ChangeAction
    {
        Unknown,

        [EnumValue("added")]
        Added = 1,

        [EnumValue("created")]
        Created = 2,

        [EnumValue("updated")]
        Updated = 3,

        [EnumValue("deleted")]
        Deleted = 4
    }
}