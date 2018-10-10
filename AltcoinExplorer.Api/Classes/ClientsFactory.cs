namespace AltcoinExplorer.Api.Classes
{
    using System;
    using RestSharp;

    internal static class ClientsFactory
    {
        public static RestClient Create(string serverAddress)
        {
            return new RestClient(serverAddress);
        }

        public static RestClient Create(Uri serverAddress)
        {
            return Create(serverAddress.ToString());
        }
    }
}
