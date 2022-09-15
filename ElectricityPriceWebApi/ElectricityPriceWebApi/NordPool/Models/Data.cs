namespace ElectricityPriceWebApi.NordPool.Models;

public class Data
{
    public List<Row> Rows { get; set; }
    public bool IsDivided { get; set; }
    public object SectionNames { get; set; }
    public List<string> EntityIDs { get; set; }
    public DateTime DataStartdate { get; set; }
    public DateTime DataEnddate { get; set; }
    public DateTime MinDateForTimeScale { get; set; }
    public List<object> AreaChanges { get; set; }
    public List<string> Units { get; set; }
    public DateTime LatestResultDate { get; set; }
    public bool ContainsPreliminaryValues { get; set; }
    public bool ContainsExchangeRates { get; set; }
    public string ExchangeRateOfficial { get; set; }
    public string ExchangeRatePreliminary { get; set; }
    public object ExchangeUnit { get; set; }
    public DateTime DateUpdated { get; set; }
    public bool CombinedHeadersEnabled { get; set; }
    public int DataType { get; set; }
    public int TimeZoneInformation { get; set; }
}