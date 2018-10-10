using System;

namespace AltcoinExplorer.TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var explorer = new Api.AltcoinExplorer("http://explorer.exuscoin.com:3333");

            var test = explorer.GetAddress("73TBBsXuFmzrmoPfxwFKq1gmRVg2gnLRT5").Result;

            Console.WriteLine(test.Balance);
        }
    }
}
