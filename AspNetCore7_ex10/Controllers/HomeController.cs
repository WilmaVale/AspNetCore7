using AspNetCore7_ex10.Models;
using AspNetCore7_ex10.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AspNetCore7_ex10.Controllers
{
    public class HomeController : Controller
    {
        private readonly FinnHubService _finnHubService;
        private readonly IOptions<TradingOptions> _tradingOptions;

        public HomeController(FinnHubService finnHubService, IOptions<TradingOptions> tradingOptions)
        {
            _finnHubService = finnHubService;
            _tradingOptions = tradingOptions;
        }

        [Route("/")]
        public async Task<IActionResult> Index()
        {
            if (_tradingOptions.Value.DefaultStockSymbol == null)
            {
                _tradingOptions.Value.DefaultStockSymbol ="MSFT";
            }
            Dictionary<string, object>? response = await _finnHubService.GetStockPriceQuotes(_tradingOptions.Value.DefaultStockSymbol);

            Stock stock = new()
            { 
                StockSymbol= _tradingOptions.Value.DefaultStockSymbol,
                CurrentPrice= Convert.ToDouble( response["c"].ToString()),
                LowestPrice= Convert.ToDouble(response["h"].ToString()),
                HighestPrice = Convert.ToDouble(response["l"].ToString()),
                OpenPrice = Convert.ToDouble(response["o"].ToString()),
            };
            return View(stock);
        }
    }
}
