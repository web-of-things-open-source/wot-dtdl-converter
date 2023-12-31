﻿using Newtonsoft.Json;
using WotConverterCore.Models.Common;
using WotConverterCore.Models.Common.Serializers;
using WotConverterCore.Models.Serializers;
using WotConverterDTDL.DigitalTwin.Schema;
using WotConverterDTDL.DigitalTwin.Serializers;

namespace WotConverterDTDL.DigitalTwin
{
    public partial class DTDL
    {
        private static JsonSerializerSettings SerializationSettings = new JsonSerializerSettings
        {
            Converters =
            {
                GenericStringEnumSerializer<DTDLSchemaType>.Serializer,
                GenericStringArraySerializer<string>.Serializer,
                GenericStringIntSerializer.Serializer,
                GenericStringDictionarySerializer<string>.Serializer,
                DTDLBaseSchemaSerializer.Serializer,
                DTDLBaseContentSerializer.Serializer
            },
            NullValueHandling = NullValueHandling.Ignore,
            Formatting = Formatting.Indented
        };

        public string Serialize() =>
            JsonConvert.SerializeObject(this, SerializationSettings);

        public static DTDL? Deserialize(string inputString) =>
            JsonConvert.DeserializeObject<DTDL>(inputString, SerializationSettings);

        public static DTDL? Deserialize(StreamReader stream) =>
            JsonConvert.DeserializeObject<DTDL>(stream.ReadToEnd(), SerializationSettings);
    }
}
