namespace ElectricityPriceWebApi.Dto
{
    public class ElectricityPriceDto
    {
        public DateTime InEffectFrom { get; set; }
        public DateTime InEffectTo { get; set; }
        public decimal Price { get; set; }
        public string CountryCode { get; set; }
        public int PriceType { get; set; }
    }
}
