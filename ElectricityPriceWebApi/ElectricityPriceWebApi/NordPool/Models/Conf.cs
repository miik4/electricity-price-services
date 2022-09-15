namespace ElectricityPriceWebApi.NordPool.Models;

public class Conf
{
    public string Id { get; set; }
    public object Name { get; set; }
    public DateTime Published { get; set; }
    public bool ShowGraph { get; set; }
    public ResolutionPeriod ResolutionPeriod { get; set; }
    public ResolutionPeriodY ResolutionPeriodY { get; set; }
    public List<Entity> Entities { get; set; }
    public int TableType { get; set; }
    public List<ExtraRow> ExtraRows { get; set; }
    public List<Filter> Filters { get; set; }
    public bool IsDrillDownEnabled { get; set; }
    public int DrillDownMode { get; set; }
    public bool IsMinValueEnabled { get; set; }
    public bool IsMaxValueEnabled { get; set; }
    public int ValidYearsBack { get; set; }
    public string TimeScaleUnit { get; set; }
    public bool IsNtcEnabled { get; set; }
    public NtcProductType NtcProductType { get; set; }
    public string NtcHeader { get; set; }
    public int ShowTimelineGraph { get; set; }
    public int ExchangeMode { get; set; }
    public int IsPivotTable { get; set; }
    public int IsCombinedHeadersEnabled { get; set; }
    public int NtcFormat { get; set; }
    public bool DisplayHourAlsoInUKTime { get; set; }
}