using AspNetCore7_ex10.ServiceContracts;
using System.Text.Json;

namespace AspNetCore7_ex10.Services
{
    public class FinnHubService: IFinnHubService
    {
        // CreateClient() ti permette di creare una classe HttpCLient
        // e chiudere la connessione finito l'utilizzo
        private readonly IHttpClientFactory _httpClientFactory;

        // per poter accedere gli user secrets
        private readonly IConfiguration _config;

        public FinnHubService(IHttpClientFactory httpClientFactory, IConfiguration config)
        {
            _httpClientFactory = httpClientFactory;
            _config = config;
        }

        public async Task<Dictionary<string, object>?> GetStockPriceQuotes(string stockSymbol)
        {
            // usando lo using chiuderà la connessione in automatico
            using (HttpClient httpClient = _httpClientFactory.CreateClient())
            {
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage()
                {
                    RequestUri = new Uri($"https://finnhub.io/api/v1/quote?symbol={stockSymbol}&token={_config["FinnHubToken"]}"),
                    Method = HttpMethod.Get,
                };

                HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

                Stream stream = httpResponseMessage.Content.ReadAsStream();

                StreamReader streamReader = new StreamReader(stream);

                string response = streamReader.ReadToEnd();

                Dictionary<string, object>? responseDictionary = JsonSerializer.Deserialize<Dictionary<string, object>>(response);

                if (responseDictionary == null)
                {
                    throw new InvalidOperationException("No response from FinnHub server");
                }

                if (responseDictionary.ContainsKey("error"))
                {
                    throw new InvalidOperationException(Convert.ToString(responseDictionary["error"]));
                }
                return responseDictionary;
            }
        }
    }
}
