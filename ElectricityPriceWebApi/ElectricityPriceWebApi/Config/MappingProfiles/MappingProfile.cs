using AutoMapper;

namespace ElectricityPriceWebApi.Config.MappingProfiles
{
    public static class MappingProfile
    {
        public static MapperConfiguration InitializeAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ElectricityPriceMappingProfile());
            });

            return config;
        }
    }
}
