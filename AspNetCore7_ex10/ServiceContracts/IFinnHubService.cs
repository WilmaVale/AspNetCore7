namespace AspNetCore7_ex10.ServiceContracts
{
    public interface IFinnHubService
    {
        Task<Dictionary<string, object>?> GetStockPriceQuotes(string stockSymbol);
    }
}
