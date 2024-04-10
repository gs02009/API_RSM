using RSMEnterpriseIntegrationsAPI.Application.DTOs;
using RSMEnterpriseIntegrationsAPI.Application.Exceptions;
using RSMEnterpriseIntegrationsAPI.Domain.Interfaces;
using RSMEnterpriseIntegrationsAPI.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RSMEnterpriseIntegrationsAPI.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<int> CreateProduct(CreateProductDto productDto)
        {
            if (productDto is null || string.IsNullOrWhiteSpace(productDto.Name))
            {
                throw new BadRequestException("Product info is not valid.");
            }

            Product product = new Product
            {
                Name = productDto.Name,
                ProductNumber = productDto.ProductNumber,
                MakeFlag = productDto.MakeFlag,
                FinishedGoodsFlag = productDto.FinishedGoodsFlag,
                Color = productDto.Color,
                SafetyStockLevel = productDto.SafetyStockLevel,
                ReorderPoint = productDto.ReorderPoint,
                StandardCost = productDto.StandardCost,
                ListPrice = productDto.ListPrice,
                Size = productDto.Size,
                SizeUnitMeasureCode = productDto.SizeUnitMeasureCode,
                WeightUnitMeasureCode = productDto.WeightUnitMeasureCode,
                Weight = productDto.Weight,
                DaysToManufacture = productDto.DaysToManufacture,
                ProductLine = productDto.ProductLine,
                Class = productDto.Class,
                Style = productDto.Style,
                ProductSubcategoryID = productDto.ProductSubcategoryID,
                ProductModelID = productDto.ProductModelID,
                SellStartDate = productDto.SellStartDate,
                SellEndDate = productDto.SellEndDate,
                DiscontinuedDate = productDto.DiscontinuedDate,
                rowguid = Guid.NewGuid(), // Generar un nuevo GUID
                ModifiedDate = productDto.ModifiedDate 

            };

            return await _productRepository.CreateProduct(product);
        }

        public async Task<int> DeleteProduct(int productId)
        {
            if (productId <= 0)
            {
                throw new BadRequestException("ProductId is not valid.");
            }

            var product = await ValidateProductExistence(productId);
            return await _productRepository.DeleteProduct(product.ProductID);
        }

        public async Task<IEnumerable<GetProductDto>> GetAllProducts()
        {
            var products = await _productRepository.GetAllProducts();
            List<GetProductDto> productDtos = new List<GetProductDto>();

            foreach (var product in products)
            {
                GetProductDto dto = new GetProductDto
                {
                    ProductID = product.ProductID,
                    Name = product.Name,
                    // Mapea otras propiedades según sea necesario
                };

                productDtos.Add(dto);
            }

            return productDtos;
        }

        public async Task<GetProductDto?> GetProductById(int productId)
        {
            if (productId <= 0)
            {
                throw new BadRequestException("ProductId is not valid.");
            }

            var product = await ValidateProductExistence(productId);

            GetProductDto dto = new GetProductDto
            {
                ProductID = product.ProductID,
                Name = product.Name,
                // Mapea otras propiedades según sea necesario
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
            // Actualiza otras propiedades según sea necesario

            return await _productRepository.UpdateProduct(product);
        }

        private async Task<Product> ValidateProductExistence(int productId)
        {
            var existingProduct = await _productRepository.GetProductById(productId)
                ?? throw new NotFoundException($"Product with Id: {productId} was not found.");

            return existingProduct;
        }
    }
}
