using Microsoft.EntityFrameworkCore;
using RSMEnterpriseIntegrationsAPI.Domain.Interfaces;
using RSMEnterpriseIntegrationsAPI.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RSMEnterpriseIntegrationsAPI.Infrastructure.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly AdvWorksDbContext _context;

        public ProductCategoryRepository(AdvWorksDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateProductCategory(ProductCategory productCategory)
        {
            await _context.AddAsync(productCategory);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteProductCategory(int productCategoryId)
        {
            var productCategory = await _context.ProductCategories.FindAsync(productCategoryId);
            if (productCategory != null)
            {
                _context.Remove(productCategory);
                return await _context.SaveChangesAsync();
            }
            return 0; // Opcional: Puedes manejar el caso donde la categoría no existe
        }

        public async Task<IEnumerable<ProductCategory>> GetAllProductCategories()
        {
            return await _context.ProductCategories
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ProductCategory?> GetProductCategoryById(int id)
        {
            return await _context.ProductCategories
                .AsNoTracking()
                .FirstOrDefaultAsync(pc => pc.ProductCategoryID == id);
        }

        public async Task<int> UpdateProductCategory(ProductCategory productCategory)
        {
            _context.Update(productCategory);
            return await _context.SaveChangesAsync();
        }
    }
}
