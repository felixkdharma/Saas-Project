using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;

namespace Infrastructure.Persistence
{
    public class TenantRepository : ITenantRepository
    {
        private readonly AppDbContext _context;

        public TenantRepository(AppDbContext context)
        { 
            _context = context;
        }

        public async Task AddAsync(Tenant poTenant)
        {
            await _context.Tenants.AddAsync(poTenant);
            await _context.SaveChangesAsync();
        }

        public async Task<Tenant?> GetTenantByIdAsync(Guid pcTenantId)
        {
            return await _context.Tenants.FirstOrDefaultAsync(t => t.CTENANT_ID == pcTenantId);
        }
    }
}
