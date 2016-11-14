using System;
using Newtonsoft.Json.Linq;
using MovieMania.Core.Search;
using MovieMania.Core.General;

namespace MovieMania.Core.Utilities.Converters
{
    internal class KnownForConverter : JsonCreationConverter<KnownForBase>
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(KnownForBase);
        }

        protected override KnownForBase GetInstance(JObject jObject)
        {
            MediaType mediaType = jObject["media_type"].ToObject<MediaType>();

            switch (mediaType)
            {
                case MediaType.Movie:
                    return new KnownForMovie();
                case MediaType.Tv:
                    return new KnownForTv();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}