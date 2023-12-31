﻿using Newtonsoft.Json;
using WotConverterCore.Models.Common.Serializers;
using WotConverterCore.Models.Serializers;
using WotConverterCore.Models.ThingModel.DataSchema;
using WotConverterCore.Models.ThingModel.Serializers;

namespace WotConverterCore.Models.ThingModel
{
    public partial class TM
    {
        private static JsonSerializerSettings SerializationSettings = new JsonSerializerSettings
        {
            Converters =
            {
                GenericStringArraySerializer<string>.Serializer,
                GenericStringArraySerializer<OpEnum>.Serializer,
                GenericStringArraySerializer<Uri>.Serializer,
                GenericStringArraySerializer<Link>.Serializer,
                GenericStringArraySerializer<BaseDataSchema>.Serializer,
                GenericStringArraySerializer<Form>.Serializer,
                GenericStringDictionarySerializer<string>.Serializer,
                GenericStringDictionarySerializer<BaseDataSchema>.Serializer,
                GenericStringDictionarySerializer<Event>.Serializer,
                GenericStringDictionarySerializer<Property>.Serializer,
                GenericStringDictionarySerializer<Action>.Serializer,
                GenericStringDoubleSerializer.Serializer,
                GenericStringIntSerializer.Serializer,
                GenericStringBoolSerializer.Serializer,
                GenericStringUriSerializer.Serializer,
                BaseDataSchemaSerializer.Serializer,
                PropertySerializer.Serializer
            },
            NullValueHandling = NullValueHandling.Ignore,
            Formatting = Formatting.Indented
        };

        public string Serialize() =>
            JsonConvert.SerializeObject(this, SerializationSettings);

        public static TM? Deserialize(string inputString) =>
            JsonConvert.DeserializeObject<TM>(inputString, SerializationSettings);

        public static TM? Deserialize(StreamReader stream) =>
            JsonConvert.DeserializeObject<TM>(stream.ReadToEnd(), SerializationSettings);

    }
}
