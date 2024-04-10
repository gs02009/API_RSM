namespace RSMEnterpriseIntegrationsAPI.Domain.Interfaces
{
    using RSMEnterpriseIntegrationsAPI.Domain.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IProductCategoryRepository
    {
        Task<ProductCategory?> GetProductCategoryById(int id);
        Task<IEnumerable<ProductCategory>> GetAllProductCategories();
        Task<int> CreateProductCategory(ProductCategory productCategory);
        Task<int> UpdateProductCategory(ProductCategory productCategory);
        Task<int> DeleteProductCategory(int productCategoryId);
    }
}
