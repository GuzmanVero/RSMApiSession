namespace RSMEnterpriseIntegrationsAPI.Application.DTOs
{
    public class GetProductDto
    {
        public int ProductID { get; set; }
        public string? Name { get; set; }
        public string? ProductNumber { get; set; }
        public int DaysToManufacture { get; set; }
    }
}
