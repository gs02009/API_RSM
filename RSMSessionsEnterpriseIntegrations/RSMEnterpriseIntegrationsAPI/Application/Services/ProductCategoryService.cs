using RSMEnterpriseIntegrationsAPI.Application.DTOs;
using RSMEnterpriseIntegrationsAPI.Application.Exceptions;
using RSMEnterpriseIntegrationsAPI.Domain.Interfaces;
using RSMEnterpriseIntegrationsAPI.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RSMEnterpriseIntegrationsAPI.Application.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryService(IProductCategoryRepository repository)
        {
            _productCategoryRepository = repository;
        }

        public async Task<int> CreateProductCategory(CreateProductCategoryDto productCategoryDto)
        {
            if (productCategoryDto is null || string.IsNullOrWhiteSpace(productCategoryDto.Name))
            {
                throw new BadRequestException("Product category info is not valid.");
            }

            ProductCategory productCategory = new ProductCategory
            {
                Name = productCategoryDto.Name,
                rowguid = Guid.NewGuid() // Generar un nuevo GUID
            };

            return await _productCategoryRepository.CreateProductCategory(productCategory);
        }


        public async Task<int> DeleteProductCategory(int id)
        {
            if (id <= 0)
            {
                throw new BadRequestException("Id is not valid.");
            }

            var productCategory = await ValidateProductCategoryExistence(id);
            return await _productCategoryRepository.DeleteProductCategory(productCategory.ProductCategoryID);
        }

        public async Task<IEnumerable<GetProductCategoryDto>> GetAllProductCategories()
        {
            var productCategories = await _productCategoryRepository.GetAllProductCategories();
            List<GetProductCategoryDto> productCategoriesDto = new List<GetProductCategoryDto>();

            foreach (var productCategory in productCategories)
            {
                GetProductCategoryDto dto = new GetProductCategoryDto
                {
                    ProductCategoryID = productCategory.ProductCategoryID,
                    Name = productCategory.Name
                };

                productCategoriesDto.Add(dto);
            }

            return productCategoriesDto;
        }

        public async Task<GetProductCategoryDto?> GetProductCategoryById(int id)
        {
            if (id <= 0)
            {
                throw new BadRequestException("ProductCategoryID is not valid");
            }

            var productCategory = await ValidateProductCategoryExistence(id);

            GetProductCategoryDto dto = new GetProductCategoryDto
            {
                ProductCategoryID = productCategory.ProductCategoryID,
                Name = productCategory.Name
            };
            return dto;
        }

        public async Task<int> UpdateProductCategory(UpdateProductCategoryDto productCategoryDto)
        {
            if (productCategoryDto is null)
            {
                throw new BadRequestException("Product category info is not valid.");
            }

            var productCategory = await ValidateProductCategoryExistence(productCategoryDto.ProductCategoryID);

            productCategory.Name = string.IsNullOrWhiteSpace(productCategoryDto.Name) ? productCategory.Name : productCategoryDto.Name;

            return await _productCategoryRepository.UpdateProductCategory(productCategory);
        }

        private async Task<ProductCategory> ValidateProductCategoryExistence(int id)
        {
            var existingProductCategory = await _productCategoryRepository.GetProductCategoryById(id)
                ?? throw new NotFoundException($"Product category with Id: {id} was not found.");

            return existingProductCategory;
        }
    }
}
