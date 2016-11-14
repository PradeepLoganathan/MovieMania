using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MovieMania.Changes
{
    public class ChangeItemDeleted : ChangeItemBase
    {
        public ChangeItemDeleted()
        {
            Action = ChangeAction.Deleted;
        }

        [JsonProperty("original_value")]
        public JToken OriginalValue { get; set; }
    }
}