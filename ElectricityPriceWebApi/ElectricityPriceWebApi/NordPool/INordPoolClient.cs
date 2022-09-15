using ElectricityPriceWebApi.Dto;

namespace ElectricityPriceWebApi.NordPool;

public interface INordPoolClient
{
    Task<List<ElectricityPriceDto>> GetFinlandDayAheadHourlyPrices();
}