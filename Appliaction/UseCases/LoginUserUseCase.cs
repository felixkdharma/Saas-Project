using Application.DTOs;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public class LoginUserUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IJWTService _jwtService;

        public LoginUserUseCase(IUserRepository userRepository, IJWTService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        public async Task<LoginResponse> ExecuteAsync(LoginRequest request)
        {
            var user = await _userRepository.GetUserByEmailAsync(request.CEMAIL);

            if (user == null)
            {
                throw new Exception("User Not Found");
            }

            if (user.CPASSWORD != request.CPASSWORD)
            {
                throw new Exception("Invalid Password");
            }

            var token = _jwtService.GenerateToken(user);

            return new LoginResponse
            {
                CTOKEN = token
            };
        }
    }
}
