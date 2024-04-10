namespace RSMEnterpriseIntegrationsAPI.Application.Services
{
    using RSMEnterpriseIntegrationsAPI.Application.DTOs;
    using RSMEnterpriseIntegrationsAPI.Application.Exceptions;
    using RSMEnterpriseIntegrationsAPI.Domain.Interfaces;
    using RSMEnterpriseIntegrationsAPI.Domain.Models;

    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> CreateProduct(CreateProductDto productDto)
        {
            if (productDto is null
                || string.IsNullOrWhiteSpace(productDto.Name)
                || string.IsNullOrWhiteSpace(productDto.ProductNumber)
                || productDto.DaysToManufacture == null || productDto.DaysToManufacture == 0)
            {
                throw new BadRequestException("Product info is not valid.");
            }

            Product product = new()
            {
                ProductNumber = productDto.ProductNumber,
                Name = productDto.Name,
                DaysToManufacture = productDto.DaysToManufacture
            };

            return await _repository.CreateProduct(product);
        }

        public async Task<int> DeleteProduct(int id)
        {
            if (id <= 0)
            {
                throw new BadRequestException("Id is not valid.");
            }
            var product = await ValidateProductExistence(id);
            return await _repository.DeleteProduct(product);
        }

        public async Task<IEnumerable<GetProductDto>> GetAll()
        {
            var products = await _repository.GetAllProducts();
            List<GetProductDto> productsDto = [];

            foreach (var product in products)
            {
                GetProductDto dto = new()
                {
                    Name = product.Name,
                    ProductNumber = product.ProductNumber,
                    DaysToManufacture = product.DaysToManufacture,
                    ProductID = product.ProductID
                };

                productsDto.Add(dto);
            }
            return productsDto;
        }

        public async Task<GetProductDto?> GetProductById(int id)
        {
            if (id <= 0)
            {
                throw new BadRequestException("ProductID is not valid");
            }

            var product = await ValidateProductExistence(id);

            GetProductDto dto = new()
            {
                ProductID = product.ProductID,
                Name = product.Name,
                ProductNumber = product.ProductNumber,
                DaysToManufacture = product.DaysToManufacture
            };
            return dto;
        }

        public async Task<int> UpdateProduct(UpdateProductDto productDto)
        {
            if (productDto is null)
            {
                throw new BadRequestException("Product info is not valid.");
            }
            var product = await ValidateProductExistence(productDto.ProductID);

            product.Name = string.IsNullOrWhiteSpace(productDto.Name) ? product.Name : productDto.Name;
            product.ProductNumber = string.IsNullOrWhiteSpace(productDto.ProductNumber) ? product.ProductNumber : productDto.ProductNumber;
            product.DaysToManufacture = productDto.DaysToManufacture;

            return await _repository.UpdateProduct(product);
        }

        private async Task<Product> ValidateProductExistence(int id)
        {
            var existingDepartment = await _repository.GetProductById(id)
                ?? throw new NotFoundException($"Product with Id: {id} was not found.");

            return existingDepartment;
        }

    }
}
