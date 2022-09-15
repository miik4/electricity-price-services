namespace ElectricityPriceWebApi.NordPool.Models;

public class Row
{
    public List<Column> Columns { get; set; }
    public string Name { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public DateTime DateTimeForData { get; set; }
    public int DayNumber { get; set; }
    public DateTime StartTimeDate { get; set; }
    public bool IsExtraRow { get; set; }
    public bool IsNtcRow { get; set; }
    public string EmptyValue { get; set; }
    public object Parent { get; set; }
}