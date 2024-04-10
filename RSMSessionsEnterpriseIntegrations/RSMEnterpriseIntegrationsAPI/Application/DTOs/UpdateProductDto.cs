namespace RSMEnterpriseIntegrationsAPI.Application.DTOs
{
    public class UpdateProductDto
    {
        public int ProductID { get; set; }
        public string? Name { get; set; } = string.Empty;
        public string? ProductNumber { get; set; } = string.Empty;
        public int DaysToManufacture { get; set; }
    }
}
