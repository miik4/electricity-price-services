namespace ElectricityPriceWebApi.NordPool.Models;

public class Column
{
    public int Index { get; set; }
    public int Scale { get; set; }
    public object SecondaryValue { get; set; }
    public bool IsDominatingDirection { get; set; }
    public bool IsValid { get; set; }
    public bool IsAdditionalData { get; set; }
    public int Behavior { get; set; }
    public string Name { get; set; }
    public string Value { get; set; }
    public object GroupHeader { get; set; }
    public bool DisplayNegativeValueInBlue { get; set; }
    public string CombinedName { get; set; }
    public DateTime DateTimeForData { get; set; }
    public string DisplayName { get; set; }
    public string DisplayNameOrDominatingDirection { get; set; }
    public bool IsOfficial { get; set; }
    public bool UseDashDisplayStyle { get; set; }
}