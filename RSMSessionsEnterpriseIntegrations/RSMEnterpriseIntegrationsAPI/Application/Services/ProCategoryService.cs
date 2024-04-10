namespace RSMEnterpriseIntegrationsAPI.Application.Services
{
    using RSMEnterpriseIntegrationsAPI.Application.DTOs;
    using RSMEnterpriseIntegrationsAPI.Application.Exceptions;
    using RSMEnterpriseIntegrationsAPI.Domain.Interfaces;
    using RSMEnterpriseIntegrationsAPI.Domain.Models;
    using RSMEnterpriseIntegrationsAPI.Infrastructure.Repositories;

    public class ProCategoryService : IProCategoryService 
    {
        private readonly IProCategoryRepository _proCategoryRepository;
        public ProCategoryService(IProCategoryRepository proCategoryRepository)
        {
            _proCategoryRepository = proCategoryRepository;
        }

        public async Task<int> CreateProCategory(CreateProCategoryDto proCategoryDto)
        {
            if (proCategoryDto is null
                || string.IsNullOrWhiteSpace(proCategoryDto.Name)
                || string.IsNullOrWhiteSpace(proCategoryDto.rowguid))
            {
                throw new BadRequestException("Department info is not valid.");
            }

            ProductCategory proCategory = new()
            {
                rowguid = proCategoryDto.rowguid,
                Name = proCategoryDto.Name,
            };

            return await _proCategoryRepository.CreateProCategory(proCategory);
        }

        public async Task<int> DeleteProCategory(int id)
        {
            if (id <= 0)
            {
                throw new BadRequestException("Id is not valid.");
            }
            var proCategory = await ValidateProCategoryExistence(id);
            return await _proCategoryRepository.DeleteProCategory(proCategory);
        }

        public async Task<IEnumerable<GetProCategoryDto>> GetAll()
        {
            var proCategories = await _proCategoryRepository.GetProCategoryById();
            List<GetProCategoryDto> proCategoryDto = [];

            foreach (var procategory in proCategories)
            {
                GetProCategoryDto dto = new()
                {
                    ProductCategoryID = procategory.ProductCategoryID,
                    Name = procategory.Name,
                    rowguid = procategory.rowguid
                };

                proCategoryDto.Add(dto);
            }

            return proCategoryDto;
        }

        public async Task<GetProCategoryDto?> GetProCategoryById(int id)
        {
            if (id <= 0)
            {
                throw new BadRequestException("DepartmentId is not valid");
            }

            var proCategory = await ValidateProCategoryExistence(id);

            GetProCategoryDto dto = new()
            {
                ProductCategoryID = proCategory.ProductCategoryID,
                Name = proCategory.Name,
                rowguid = proCategory.rowguid
            };
            return dto;
        }

        public async Task<int> UpdateProCategory(UpdateProCateogoryDto proCateogoryDto)
        {
            if (proCateogoryDto is null)
            {
                throw new BadRequestException("ProductCategory info is not valid.");
            }
            var procategory = await ValidateProCategoryExistence(proCateogoryDto.ProductCategoryID);

            procategory.Name = string.IsNullOrWhiteSpace(proCateogoryDto.Name) ? procategory.Name : proCateogoryDto.Name;
            procategory.rowguid = string.IsNullOrWhiteSpace(proCateogoryDto.rowguid) ? procategory.rowguid : proCateogoryDto.rowguid;

            return await _proCategoryRepository.UpdateProCategory(procategory);
        }

        private async Task<ProductCategory> ValidateProCategoryExistence(int id)
        {
            var existingProcategory = await _proCategoryRepository.GetProCategoryById(id)
                ?? throw new NotFoundException($"ProducCategory with Id: {id} was not found.");

            return existingProcategory;
        }
    }
}
