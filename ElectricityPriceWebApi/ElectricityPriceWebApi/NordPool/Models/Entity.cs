namespace ElectricityPriceWebApi.NordPool.Models;

public class Entity
{
    public ProductType ProductType { get; set; }
    public SecondaryProductType SecondaryProductType { get; set; }
    public int SecondaryProductBehavior { get; set; }
    public string Id { get; set; }
    public string Name { get; set; }
    public string GroupHeader { get; set; }
    public DateTime DataUpdated { get; set; }
    public List<Attribute> Attributes { get; set; }
    public bool Drillable { get; set; }
    public List<object> DateRanges { get; set; }
    public int Index { get; set; }
    public int IndexForColumn { get; set; }
    public bool MinMaxDisabled { get; set; }
    public int DisableNumberGroupSeparator { get; set; }
    public object TimeserieID { get; set; }
    public string SecondaryTimeserieID { get; set; }
    public bool HasPreliminary { get; set; }
    public object TimeseriePreliminaryID { get; set; }
    public int Scale { get; set; }
    public int SecondaryScale { get; set; }
    public int DataType { get; set; }
    public int SecondaryDataType { get; set; }
    public DateTime LastUpdate { get; set; }
    public string Unit { get; set; }
    public bool IsDominatingDirection { get; set; }
    public bool DisplayAsSeparatedColumn { get; set; }
    public bool EnableInChart { get; set; }
    public bool BlueNegativeValues { get; set; }
}