using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface ITenantRepository
    {
        Task AddAsync(Tenant poTenant);
        Task<Tenant?> GetTenantByIdAsync(Guid pcTenantId);
    }
}
