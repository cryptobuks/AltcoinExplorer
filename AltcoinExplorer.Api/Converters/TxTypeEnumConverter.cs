using System;
using AltcoinExplorer.Api.Enums;
using Newtonsoft.Json;

namespace AltcoinExplorer.Api.Converters
{
    internal class TxTypeEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(TxTypeEnum) || t == typeof(TxTypeEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;

            var value = serializer.Deserialize<string>(reader);

            if (value == "vout")
            {
                return TxTypeEnum.Vout;
            }

            if (value == "vin")
            {
                return TxTypeEnum.Vin;
            }

            throw new Exception("Cannot unmarshal type TypeEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }

            var value = (TxTypeEnum)untypedValue;

            if (value == TxTypeEnum.Vout)
            {
                serializer.Serialize(writer, "vout");
                return;
            }

            if (value == TxTypeEnum.Vin)
            {
                serializer.Serialize(writer, "vin");
                return;
            }

            throw new Exception("Cannot marshal type TypeEnum");
        }
    }
}