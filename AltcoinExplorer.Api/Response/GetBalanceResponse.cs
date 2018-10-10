using AltcoinExplorer.Api.Converters;
using Newtonsoft.Json;

namespace AltcoinExplorer.Api.Response
{    
    public class GetBalanceResponse : BaseResponse
    {
        public GetBalanceResponse()
        {
        }

        public GetBalanceResponse(double balance)
        {
            Balance = balance;
        }

        public double Balance { get; set; }

        public static GetBalanceResponse FromJson(string json) => JsonConvert.DeserializeObject<GetBalanceResponse>(json, Converter.Settings);
    }
}
