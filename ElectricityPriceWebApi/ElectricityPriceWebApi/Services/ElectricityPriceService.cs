using ElectricityPriceWebApi.Models;
using ElectricityPriceWebApi.NordPool;
using ElectricityPriceWebApi.Repositories;

namespace ElectricityPriceWebApi.Services
{
    public class ElectricityPriceService : IElectricityPriceService
    {
        private readonly IElectricityPriceRepository repository;
        private readonly INordPoolClient nordPoolClient;

        public ElectricityPriceService(IElectricityPriceRepository repository, INordPoolClient nordPoolClient)
        {
            this.repository = repository;
            this.nordPoolClient = nordPoolClient;
        }

        public async Task<IEnumerable<ElectricityPrice>> GetAll()
        {
            await nordPoolClient.GetFinlandDayAheadHourlyPrices();

            return await repository.GetAll();
        }
    }
}
