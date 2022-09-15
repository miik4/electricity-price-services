using ElectricityPriceWebApi.Dto;
using ElectricityPriceWebApi.Models;

namespace ElectricityPriceWebApi.Services;

public interface IElectricityPriceService
{
    Task<List<ElectricityPriceDto>> GetDayAheadAndWeekPrices();
}