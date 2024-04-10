using RSMEnterpriseIntegrationsAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RSMEnterpriseIntegrationsAPI.Domain.Repositories
{
    public interface ISalesOrderHeaderRepository
    {
        Task<IEnumerable<SalesOrderHeader>> ListAsync();
        Task AddAsync(SalesOrderHeader salesOrderHeader);
        Task<SalesOrderHeader> FindByIdAsync(int id);
        void Update(SalesOrderHeader salesOrderHeader);
        void Remove(SalesOrderHeader salesOrderHeader);
        Task CompleteAsync();
    }
}
