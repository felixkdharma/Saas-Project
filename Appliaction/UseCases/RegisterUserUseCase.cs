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
    public class RegisterUserUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly ITenantRepository _tenantRepository;
        private readonly IPasswordHasher _passwordHasher;

        public RegisterUserUseCase(IUserRepository userRepository, ITenantRepository tenantRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _tenantRepository = tenantRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<Guid> Execute(RegisterUserRequest request)
        {
            var tenant = await _tenantRepository.GetTenantByIdAsync(request.CTENANT_ID);

            if (tenant == null)
                throw new Exception("Tenant not found");

            var lcHashedPassword = _passwordHasher.CHASH(request.CPASSWORD);    

            var user = new User(
                request.CTENANT_ID,
                request.CEMAIL,
                lcHashedPassword,
                request.CROLE
                );

            user.ValidatePassword(request.CPASSWORD, tenant.CSUBSCRIPTION_PLAN);

            await _userRepository.AddAsync(user);

            return user.CUSER_ID;
        }
    }
}
