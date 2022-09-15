namespace ElectricityPriceWebApi.NordPool.Models
{
    public class Attribute
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public bool HasRoles { get; set; }
        public List<string> Values { get; set; }
        public string Value { get; set; }
    }
}
