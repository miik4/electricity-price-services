using AutoMapper;
using ElectricityPriceWebApi.Dto;
using ElectricityPriceWebApi.Models;

namespace ElectricityPriceWebApi.Config.MappingProfiles
{
    public class ElectricityPriceMappingProfile: Profile
    {
        public ElectricityPriceMappingProfile()
        {
            CreateMap<ElectricityPrice, ElectricityPriceDto>();
        }
    }
}
