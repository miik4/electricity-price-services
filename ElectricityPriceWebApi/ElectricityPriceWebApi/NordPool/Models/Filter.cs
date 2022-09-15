namespace ElectricityPriceWebApi.NordPool.Models;

public class Filter
{
    public string Id { get; set; }
    public string AttributeName { get; set; }
    public List<string> Values { get; set; }
    public string DefaultValue { get; set; }
}