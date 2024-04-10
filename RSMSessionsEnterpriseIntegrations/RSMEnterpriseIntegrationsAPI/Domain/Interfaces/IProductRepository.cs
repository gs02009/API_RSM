using RSMEnterpriseIntegrationsAPI.Domain.Models;

namespace RSMEnterpriseIntegrationsAPI.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<int> CreateProduct(Product product);
        Task<int> DeleteProduct(int productId);
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product?> GetProductById(int productId);
        Task<int> UpdateProduct(Product product);
    }
}