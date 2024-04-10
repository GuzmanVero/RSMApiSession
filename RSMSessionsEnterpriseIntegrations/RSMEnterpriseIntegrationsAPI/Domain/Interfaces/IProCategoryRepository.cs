namespace RSMEnterpriseIntegrationsAPI.Domain.Interfaces
{
    using RSMEnterpriseIntegrationsAPI.Domain.Models;

    public interface IProCategoryRepository
    {
        Task<ProductCategory?> GetProCategoryById(int id);
        Task<IEnumerable<ProductCategory>> GetAllProCategory();
        Task<int> CreateProCategory(ProductCategory proCategory);
        Task<int> UpdateProCategory(ProductCategory proCategory);
        Task<int> DeleteProCategory(ProductCategory proCategory);
        Task<IEnumerable<object>> GetProCategoryById();
    }
}
