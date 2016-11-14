using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using MovieMania.Core.People;
using MovieMania.Core.General;
using MovieMania.Core.Search;

namespace MovieMania.Core.Utilities.Converters
{
    internal class TaggedImageConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(TaggedImage);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);

            TaggedImage result = new TaggedImage();
            serializer.Populate(jObject.CreateReader(), result);

            JToken mediaJson = jObject["media"];
            switch (result.MediaType)
            {
                case MediaType.Movie:
                    result.Media = mediaJson.ToObject<SearchMovie>();
                    break;
                case MediaType.Tv:
                    result.Media = mediaJson.ToObject<SearchTv>();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return result;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}