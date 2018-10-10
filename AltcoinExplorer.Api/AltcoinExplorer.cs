using System.Threading.Tasks;
using AltcoinExplorer.Api.Classes;
using AltcoinExplorer.Api.Response;
using RestSharp;

namespace AltcoinExplorer.Api
{
    public class AltcoinExplorer
    {
        private RestClient _client;

        public AltcoinExplorer(string serverAddress)
        {
            _client = ClientsFactory.Create(serverAddress);
        }

        public async Task<GetAddressResponse> GetAddress(string address)
        {
            var request = new RestRequest(Consts.GetAddressUri, Method.GET);
            request.AddUrlSegment("id", address);

            var response = await _client.ExecuteTaskAsync(request);

            if (!response.IsSuccessful)
            {
                return new GetAddressResponse()
                {
                    Error = response.ErrorMessage
                };
            }

            return GetAddressResponse.FromJson(response.Content);
        }

        public async Task<GetBalanceResponse> GetBalance(string address)
        {
            var request = new RestRequest(Consts.GetBalanceUri, Method.GET);
            request.AddUrlSegment("id", address);

            var response = await _client.ExecuteTaskAsync(request);

            if (!response.IsSuccessful)
            { 
                return new GetBalanceResponse()
                {
                    Error = response.ErrorMessage
                };
            }

            // Successful response returns String Value with HttpCode 200,
            // Unsuccessful response return Json with HttpCode 200, so there are no correct way to detect error 
            if (response.Content.Contains("\"error\""))
                return GetBalanceResponse.FromJson(response.Content);

            if (double.TryParse(response.Content, out double balance))
                return new GetBalanceResponse(balance);

            return new GetBalanceResponse()
            {
                Error = "Failed to parse balance"
            };
        }
    }
}
