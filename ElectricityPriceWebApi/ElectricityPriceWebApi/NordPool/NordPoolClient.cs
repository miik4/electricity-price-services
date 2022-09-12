using System.Net.Http;
using System.Text.Json;

namespace ElectricityPriceWebApi.NordPool
{
    public class NordPoolClient : INordPoolClient
    {
        private readonly IHttpClientFactory httpClientFactory;

        public NordPoolClient(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task GetFinlandDayAheadHourlyPrices()
        {
            // Hardcoded only for demo purposes. This simple query doesn't require authorization (keys for building different queries can be found from https://www.nordpoolgroup.com/api/marketdata/queries/).
            // Otherwise we should build token provider and get clientId & password provided by NordPool. NordPool is providing required authentication only for their customers.
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get,
                "https://www.nordpoolgroup.com/api/marketdata/page/35?currency=EUR");

            var httpClient = httpClientFactory.CreateClient();

            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                await using var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();

                // TODO: Json deserialization to class models
                //var nordPoolPrices = await JsonSerializer.DeserializeAsync
                //    <IEnumerable<NordPoolResponse>>(contentStream);
            }
        }
    }
}
