using Newtonsoft.Json;

namespace ElectricityPriceWebApi.NordPool.Models;

public class NordPoolResponse
{
    [JsonProperty("data")]
    public Data Data { get; set; }

    [JsonProperty("cacheKey")]
    public string CacheKey { get; set; }

    [JsonProperty("conf")]
    public Conf Conf { get; set; }

    [JsonProperty("header")]
    public Header Header { get; set; }

    [JsonProperty("endDate")]
    public object EndDate { get; set; }

    [JsonProperty("currency")]
    public string Currency { get; set; }

    [JsonProperty("pageId")]
    public int PageId { get; set; }
}