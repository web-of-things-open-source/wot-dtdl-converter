﻿using WotConverterCore.Models.Common.Interfaces;
using WotConverterCore.Models.Common.Serializers;
using WotConverterCore.Models.Serializers;

namespace WotConverterCore.Models.Common
{
    internal class GenericStringDictionary : IGenericString, ISerializable<GenericStringDoubleSerializer>
    {

        private Dictionary<string, string>? dictionary;
        private string? stringValue;
        public Dictionary<string, string>? Dictionary { get { return dictionary; } set { stringValue = null; dictionary = value; } }

        public string? String { get { return stringValue; } set { dictionary = null; stringValue = value; } }

        public static implicit operator GenericStringDictionary(Dictionary<string, string> dictionary) => new GenericStringDictionary { Dictionary = dictionary };
        public static implicit operator GenericStringDictionary(string value) => new GenericStringDictionary { stringValue = value };

        public static readonly GenericStringDictionarySerializer Serializer = new GenericStringDictionarySerializer();
        public bool isString() => String != null;

        public override string ToString()
        {
            if (String != null)
                return String;

            return "";
        }

    }
}
