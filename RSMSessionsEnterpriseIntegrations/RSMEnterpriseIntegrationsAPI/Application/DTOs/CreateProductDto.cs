namespace RSMEnterpriseIntegrationsAPI.Application.DTOs
{
    public class CreateProductDto
    {
        public string? Name { get; set; } = string.Empty;
        public string? ProductNumber { get; set; } = string.Empty;
        public int DaysToManufacture { get; set; }
    }
}
