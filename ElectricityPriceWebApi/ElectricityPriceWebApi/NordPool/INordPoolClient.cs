namespace ElectricityPriceWebApi.NordPool;

public interface INordPoolClient
{
    Task GetFinlandDayAheadHourlyPrices();
}