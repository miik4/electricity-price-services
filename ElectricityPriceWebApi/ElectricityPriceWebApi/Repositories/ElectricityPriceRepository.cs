using ElectricityPriceWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ElectricityPriceWebApi.Repositories
{
    public class ElectricityPriceRepository : IElectricityPriceRepository
    {
        private readonly ElectricityPriceContext context;

        public ElectricityPriceRepository(ElectricityPriceContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<ElectricityPrice>> GetAll()
        {
            return await context.ElectricityPrices.ToListAsync();
        }
    }
}
