using System.Runtime.CompilerServices;
using ElectricityPriceWebApi.Dto;
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

        public async Task<List<ElectricityPrice>> GetDayAheadAndWeekPrices()
        {
            var startDate = DateTime.Now.Date.AddDays(1);
            var endDate = DateTime.Now.Date.AddDays(-7);

            return await context.ElectricityPrices
                .Where(x => x.InEffectFrom.Date <= startDate && x.InEffectTo.Date >= endDate).ToListAsync();
        }

        public async Task UpdatePrices(List<ElectricityPriceDto> updatedPrices)
        {
            var updatedInEffectFromMin = updatedPrices.Min(x=>x.InEffectFrom);
            var updatedInEffectFromMax = updatedPrices.Max(x=>x.InEffectFrom);

            var updatedInEffectToMin = updatedPrices.Min(x => x.InEffectTo);
            var updatedInEffectToMax = updatedPrices.Max(x => x.InEffectTo);

            var existingPrices = await context.ElectricityPrices.Where(x =>
                x.InEffectFrom >= updatedInEffectFromMin && x.InEffectFrom <= updatedInEffectFromMax &&
                x.InEffectTo >= updatedInEffectToMin && x.InEffectTo <= updatedInEffectToMax).ToListAsync();

            var newPrices = updatedPrices.Where(x =>
                !existingPrices.Any(y => y.InEffectFrom == x.InEffectFrom && y.InEffectTo == x.InEffectTo)).ToList();

            existingPrices.ForEach(existingPrice =>
            {
                var updatedPrice = updatedPrices.Single(x =>
                    x.InEffectFrom == existingPrice.InEffectFrom && x.InEffectTo == existingPrice.InEffectTo);
                existingPrice.Price = updatedPrice.Price;
                existingPrice.UpdatedAt = DateTime.Now;
            });

            newPrices.ForEach(newPrice =>
            {
                context.ElectricityPrices.Add(new ElectricityPrice
                {
                    InEffectFrom = newPrice.InEffectFrom,
                    InEffectTo = newPrice.InEffectTo,
                    Price = newPrice.Price,
                    UpdatedAt = DateTime.Now,
                    CountryCode = newPrice.CountryCode
                });
            });

            await context.SaveChangesAsync();
        }
    }
}
