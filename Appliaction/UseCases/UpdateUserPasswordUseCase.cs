using Application.DTOs;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public class UpdateUserPasswordUseCase

    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public UpdateUserPasswordUseCase(IUserRepository userRepository, IPasswordHasher passwordHasher)
        { 
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task ExecuteAsync(UpdatePasswordRequest request)
        {
            var lcNewHashedPassword = "";
            var user = await _userRepository.GetUserByEmailAsync(request.CEMAIL);

            if (user == null)
            {
                throw new Exception("User not Found!");
            }

            if (!_passwordHasher.LVERIFY(request.CCURRENT_PASSWORD, user.CPASSWORD))
            {
                throw new Exception("Current password is incorrect");
            }

            if (request.CCURRENT_PASSWORD.ToLower() != request.CCONFIRM_NEW_PASSWORD.ToLower())
            {
                throw new Exception("Confirm password is incorrect!");
            }
            else
            { 
                lcNewHashedPassword = _passwordHasher.CHASH(request.CNEW_PASSWORD);
            }

            user.UpdatePassword(lcNewHashedPassword);
            await _userRepository.UpdateAsync(user);

        }
    }
}
