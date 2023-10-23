﻿using Newtonsoft.Json;
using WotConverterCore.Extensions;
using WotConverterCore.Interfaces;
using WotConverterCore.Models.Common;
using WotConverterCore.Models.ThingModel;
using WotConverterDTDL.Converters;

namespace WotConverterDTDL.DigitalTwin
{
    public partial class DTDL : IConvertible<DTDL>
    {
        [JsonProperty("@context")]
        public string Context { get; set; }

        [JsonProperty("@id")]
        public string Id { get; set; }

        [JsonProperty("@type")]
        public string Type { get; set; } = "Interface";

        [JsonProperty("displayName")]
        public GenericStringDictionary? DisplayName { get; set; }
        public bool ShouldSerializeDisplayName() => !DisplayName.IsEmpty();
        
        [JsonProperty("description")]
        public GenericStringDictionary? Description { get; set; }
        public bool ShouldSerializeDescription() => !Description.IsEmpty();

        [JsonProperty("comment")]
        public string? Comment { get; set; }

        [JsonProperty("contents")]
        private List<DTDLBaseContent>? Contents { get; set; }

        public List<DTDLBaseContent> GetDTDLContents(Func<DTDLBaseContent, bool>? query = null)
        {
            if (query != null)
                return Contents?.Where(query)?.ToList() ?? new();

            return Contents?.ToList() ?? new();

        }

        public void Addcontent(DTDLBaseContent content)
        {
            if (Contents == null)
                Contents = new List<DTDLBaseContent>();

            Contents.Add(content);
        }

        public static DTDL? ConvertFromTm(TM thingModel)
        {
            var dtdl = TM2DTDL.ThingModel2DTDL(thingModel);

            if (dtdl is null)
                return null;

            return dtdl;
        }

        public TM ConvertToTm()
        {
            throw new NotImplementedException();
        }

    }

}