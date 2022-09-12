using ElectricityPriceWebApi.Models;

namespace ElectricityPriceWebApi.Services;

public interface IElectricityPriceService
{
    Task<IEnumerable<ElectricityPrice>> GetAll();
}