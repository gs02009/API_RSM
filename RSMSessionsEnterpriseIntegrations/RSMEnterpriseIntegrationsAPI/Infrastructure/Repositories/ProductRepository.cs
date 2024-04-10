using Microsoft.EntityFrameworkCore;
using RSMEnterpriseIntegrationsAPI.Domain.Interfaces;
using RSMEnterpriseIntegrationsAPI.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RSMEnterpriseIntegrationsAPI.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AdvWorksDbContext _dbContext;

        public ProductRepository(AdvWorksDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateProduct(Product product)
        {
            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();
            return product.ProductID;
        }

        public async Task<int> DeleteProduct(int productId)
        {
            var product = await _dbContext.Products.FindAsync(productId);
            if (product == null)
                return 0;

            _dbContext.Products.Remove(product);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<Product?> GetProductById(int productId)
        {
            return await _dbContext.Products.FindAsync(productId);
        }

        public async Task<int> UpdateProduct(Product product)
        {
            _dbContext.Entry(product).State = EntityState.Modified;
            return await _dbContext.SaveChangesAsync();
        }
    }
}
