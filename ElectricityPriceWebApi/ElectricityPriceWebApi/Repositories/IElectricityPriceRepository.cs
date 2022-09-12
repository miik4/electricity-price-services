using ElectricityPriceWebApi.Models;

namespace ElectricityPriceWebApi.Repositories;

public interface IElectricityPriceRepository
{
    Task<IEnumerable<ElectricityPrice>> GetAll();
}