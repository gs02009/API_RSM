using RSMEnterpriseIntegrationsAPI.Application.DTOs;
using RSMEnterpriseIntegrationsAPI.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RSMEnterpriseIntegrationsAPI.Domain.Interfaces
{
    public interface IProductService
    {
        Task<int> CreateProduct(CreateProductDto productDto);
        Task<int> DeleteProduct(int productId);
        Task<IEnumerable<GetProductDto>> GetAllProducts();
        Task<GetProductDto?> GetProductById(int productId);
        Task<int> UpdateProduct(UpdateProductDto productDto);
    }
}