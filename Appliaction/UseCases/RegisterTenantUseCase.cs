using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public class RegisterTenantUseCase
    {
        private readonly ITenantRepository _tenantRepository;

        public RegisterTenantUseCase(ITenantRepository tenantRepository)
        { 
            _tenantRepository = tenantRepository;
        }

        public async Task<Guid> Execute(RegisterTenantRequest request)
        {
            var tenant = new Tenant(request.CNAME, request.OPLAN);

            await _tenantRepository.AddAsync(tenant);

            return tenant.CTENANT_ID;
        }

    }
}
