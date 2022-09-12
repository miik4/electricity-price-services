using ElectricityPriceWebApi.Models;
using ElectricityPriceWebApi.Repositories;

namespace ElectricityPriceWebApi.Services
{
    public class ElectricityPriceService : IElectricityPriceService
    {
        private readonly IElectricityPriceRepository repository;

        public ElectricityPriceService(IElectricityPriceRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<ElectricityPrice>> GetAll()
        {
            return await repository.GetAll();
        }
    }
}
