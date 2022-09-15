using ElectricityPriceWebApi.Dto;
using ElectricityPriceWebApi.Models;

namespace ElectricityPriceWebApi.Repositories;

public interface IElectricityPriceRepository
{
    Task<List<ElectricityPrice>> GetDayAheadAndWeekPrices();
    Task UpdatePrices(List<ElectricityPriceDto> prices);
}