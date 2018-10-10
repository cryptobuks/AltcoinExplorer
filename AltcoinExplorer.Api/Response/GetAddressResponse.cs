using AltcoinExplorer.Api.Classes;
using AltcoinExplorer.Api.Converters;
using Newtonsoft.Json;

namespace AltcoinExplorer.Api.Response
{
    public class GetAddressResponse : BaseResponse
    {
        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("sent")]
        public double Sent { get; set; }

        [JsonProperty("received")]
        public double Received { get; set; }

        [JsonProperty("balance")]
        public double Balance { get; set; }

        [JsonProperty("last_txs")]
        public LastTx[] LastTxs { get; set; }

        public static GetAddressResponse FromJson(string json) => JsonConvert.DeserializeObject<GetAddressResponse>(json, Converter.Settings);
    }
}