using AltcoinExplorer.Api.Converters;
using AltcoinExplorer.Api.Enums;
using Newtonsoft.Json;

namespace AltcoinExplorer.Api.Response
{
    public class LastTx
    {
        [JsonProperty("addresses")]
        public string Addresses { get; set; }

        [JsonProperty("type")]
        [JsonConverter(typeof(TxTypeEnumConverter))]
        public TxTypeEnum Type { get; set; }
    }
}