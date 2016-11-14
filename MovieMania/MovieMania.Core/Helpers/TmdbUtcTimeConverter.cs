using Newtonsoft.Json.Converters;
using System;
using Newtonsoft.Json;

namespace MovieMania.Core.Helpers
{
    public class TmdbUtcTimeConverter : DateTimeConverterBase
    {
        const string Format = "yyyy-MM-dd HH:mm:ss 'UTC'";

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return DateTime.ParseExact(reader.Value.ToString(), Format, null);
        }

      
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(((DateTime)value).ToString(Format));
        }

    }
}
