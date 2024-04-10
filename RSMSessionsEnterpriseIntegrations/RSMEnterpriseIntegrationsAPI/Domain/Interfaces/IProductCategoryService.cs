namespace RSMEnterpriseIntegrationsAPI.Domain.Interfaces
{
    using RSMEnterpriseIntegrationsAPI.Application.DTOs;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IProductCategoryService
    {
        Task<GetProductCategoryDto?> GetProductCategoryById(int id);
        Task<IEnumerable<GetProductCategoryDto>> GetAllProductCategories();
        Task<int> CreateProductCategory(CreateProductCategoryDto productCategoryDto);
        Task<int> UpdateProductCategory(UpdateProductCategoryDto productCategoryDto);
        Task<int> DeleteProductCategory(int id);
    }
}
