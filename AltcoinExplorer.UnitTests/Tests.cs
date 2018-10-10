using System;
using System.Threading.Tasks;
using AltcoinExplorer.Api.Response;
using Xunit;

namespace AltcoinExplorer.UnitTests
{
    public class Tests
    {
        // TODO: several servers
        private string server = "http://explorer.exuscoin.com:3333";
        private string _wallet = "73TBBsXuFmzrmoPfxwFKq1gmRVg2gnLRT5";

        [Fact]
        public async Task GetBalanceSuccess()
        {
            GetBalanceResponse response = await GetExplorer().GetBalance(_wallet);
            Assert.True(response.Success);
            Assert.True(response.Balance > 0);
        }

        [Fact]
        public async Task GetAddressSuccess()
        {
            GetAddressResponse response = await GetExplorer().GetAddress(_wallet);
            Assert.True(response.Success);
            Assert.True(response.Balance > 0);
        }

        private Api.AltcoinExplorer GetExplorer()
        {
            return new Api.AltcoinExplorer(server);
        }
    }
}
