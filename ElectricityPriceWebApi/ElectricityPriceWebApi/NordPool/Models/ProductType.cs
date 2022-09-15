namespace ElectricityPriceWebApi.NordPool.Models;

public class ProductType
{
    public string Id { get; set; }
    public List<Attribute> Attributes { get; set; }
    public string Name { get; set; }
    public string DisplayName { get; set; }
}