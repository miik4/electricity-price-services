using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text.Json;
using ElectricityPriceWebApi.Dto;
using ElectricityPriceWebApi.NordPool.Models;
using Newtonsoft.Json;

namespace ElectricityPriceWebApi.NordPool
{
    public class NordPoolClient : INordPoolClient
    {
        private readonly IHttpClientFactory httpClientFactory;

        public NordPoolClient(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<List<ElectricityPriceDto>> GetFinlandDayAheadHourlyPrices()
        {
            // Hardcoded only for demo purposes. This simple query doesn't require authorization (keys for building different queries can be found from https://www.nordpoolgroup.com/api/marketdata/queries/).
            // Otherwise we should build token provider and get clientId & password provided by NordPool. NordPool is providing required authentication only for their customers.
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get,
                "https://www.nordpoolgroup.com/api/marketdata/page/35?currency=EUR");

            var httpClient = httpClientFactory.CreateClient();

            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var jsonString = await httpResponseMessage.Content.ReadAsStringAsync();

                var nordPoolResponse = JsonConvert.DeserializeObject<NordPoolResponse>(jsonString);

                if (nordPoolResponse == null)
                {
                    throw new ArgumentException(
                        "Failed to deserialize NordPoolResponse. Deserialization result is null.");

                }

                var rows = nordPoolResponse.Data.Rows.SelectMany(x => x.Columns.Select(y => new
                    {
                        StartHour = x.StartTime.Hour,
                        EndHour = x.EndTime.Hour,
                        Date = ParseDateFromNordPoolColumnName(y.Name) ?? default,
                        Price = decimal.Parse(y.Value)
                    }))
                    // Filter "summary" data created from response because currently no need for that
                    .Where(x => x.Date != default && x.StartHour != x.EndHour)
                    .ToList();

                return rows.Select(x => new ElectricityPriceDto
                {
                    CountryCode = "FI",
                    InEffectFrom = new DateTime(x.Date.Year, x.Date.Month, x.Date.Day, x.StartHour, 0, 0, 0),
                    InEffectTo = new DateTime(x.Date.Year, x.Date.Month, x.Date.Day, x.EndHour, 0, 0, 0),
                    Price = x.Price
                }).ToList();
            }

            throw new ArgumentException($"Fetching prices from NordPool failed. Status code: {httpResponseMessage.StatusCode}");
        }

        private DateTime? ParseDateFromNordPoolColumnName(string name)
        {
            if (DateTime.TryParseExact(name, "dd-MM-yyyy", CultureInfo.CurrentCulture, DateTimeStyles.None, out var date))
            {
                return date;
            }

            return null;
        }
    }
}
