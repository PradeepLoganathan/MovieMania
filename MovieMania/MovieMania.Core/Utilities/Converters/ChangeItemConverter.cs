using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using MovieMania.Changes;

namespace MovieMania.Core.Utilities.Converters
{
    internal class ChangeItemConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ChangeItemBase);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);

            ChangeItemBase result;
            if (jObject["action"] == null)
            {
                // We cannot determine the correct type, let's hope we were provided one
                result = (ChangeItemBase)Activator.CreateInstance(objectType);
            }
            else
            {
                // Determine the type based on the media_type
                ChangeAction mediaType = jObject["action"].ToObject<ChangeAction>();

                switch (mediaType)
                {
                    case ChangeAction.Added:
                        result = new ChangeItemAdded();
                        break;
                    case ChangeAction.Created:
                        result = new ChangeItemCreated();
                        break;
                    case ChangeAction.Updated:
                        result = new ChangeItemUpdated();
                        break;
                    case ChangeAction.Deleted:
                        result = new ChangeItemDeleted();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            // Populate the result
            serializer.Populate(jObject.CreateReader(), result);

            return result;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}