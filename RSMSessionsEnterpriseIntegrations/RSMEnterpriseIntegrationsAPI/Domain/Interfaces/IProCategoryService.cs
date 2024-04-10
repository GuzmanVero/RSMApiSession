using RSMEnterpriseIntegrationsAPI.Application.DTOs;
using RSMEnterpriseIntegrationsAPI.Domain.Models;

namespace RSMEnterpriseIntegrationsAPI.Domain.Interfaces
{
    public interface IProCategoryService
    {
        Task<GetProCategoryDto?> GetProCategoryById(int id);
        Task<IEnumerable<GetProCategoryDto>> GetAll();
        Task<int> CreateProCategory(CreateProCategoryDto ProCategoryDto);
        Task<int> UpdateProCategory(UpdateProCateogoryDto ProCategoryDto);
        Task<int> DeleteProCategory(int id);
        Task<int> CreateProCategory(ProductCategory productCategory);
    }
}
