using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RSMEnterpriseIntegrationsAPI.Domain.Interfaces;
using RSMEnterpriseIntegrationsAPI.Domain.Models;
using RSMEnterpriseIntegrationsAPI.Domain.Repositories;

namespace RSMEnterpriseIntegrationsAPI.Infrastructure.Repositories
{
    public class SalesOrderHeaderRepository<TEntity> : ISalesOrderHeaderRepository <TEntity> where TEntity : class
    {
        protected readonly AdvWorksDbContext _context;

        public SalesOrderHeaderRepository(AdvWorksDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().AsNoTracking();
        }

            public async Task<TEntity?> GetByIdAsync(int id)
            {
                return await _context.Set<TEntity>().FindAsync(id);
            }

        public async Task CreateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

    public interface ISalesOrderHeaderRepository<TEntity> where TEntity : class
    {
    }
}
