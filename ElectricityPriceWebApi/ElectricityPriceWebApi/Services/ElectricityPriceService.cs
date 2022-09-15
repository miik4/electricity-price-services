using AutoMapper;
using ElectricityPriceWebApi.Dto;
using ElectricityPriceWebApi.Models;
using ElectricityPriceWebApi.NordPool;
using ElectricityPriceWebApi.Repositories;

namespace ElectricityPriceWebApi.Services;

public class ElectricityPriceService : IElectricityPriceService
{
    private readonly IElectricityPriceRepository repository;
    private readonly INordPoolClient nordPoolClient;
    private readonly IMapper mapper;

    public ElectricityPriceService(IElectricityPriceRepository repository, INordPoolClient nordPoolClient,
        IMapper mapper)
    {
        this.repository = repository;
        this.nordPoolClient = nordPoolClient;
        this.mapper = mapper;
    }

    public async Task<List<ElectricityPriceDto>> GetDayAheadAndWeekPrices()
    {
        var prices =
            mapper.Map<List<ElectricityPrice>, List<ElectricityPriceDto>>(await repository.GetDayAheadAndWeekPrices());

        // We should return 8 day hourly price. If prices are found from database -> no need to update those and make unnecessary request to NordPool API
        const int expectedPricesCount = 8 * 24;

        if (prices.Count == expectedPricesCount)
        {
            return prices;
        }

        // If any of prices is missing -> fetch prices from NordPool API and update to database
        prices = await nordPoolClient.GetFinlandDayAheadHourlyPrices();

        await repository.UpdatePrices(prices);

        return prices;
    }
}