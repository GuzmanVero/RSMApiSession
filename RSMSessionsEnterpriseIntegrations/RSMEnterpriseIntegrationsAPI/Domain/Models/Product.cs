namespace RSMEnterpriseIntegrationsAPI.Domain.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string? Name { get; set; }
        public string? ProductNumber { get; set; }
        public int DaysToManufacture { get; set; }
        public DateTime SellStartDate { get; set; } = DateTime.Now;
    }
}
