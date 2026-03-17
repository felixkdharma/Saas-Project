using Application.DTOs;
using Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace SaasApplication.Controllers
{
    [ApiController]
    [Route("api/login")]
    public class LoginController : Controller
    {
        private readonly LoginUserUseCase _loginUserUseCase;

        public LoginController(LoginUserUseCase loginUserUseCase)
        {
            _loginUserUseCase = loginUserUseCase;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        { 
            var result = await _loginUserUseCase.ExecuteAsync(request);
            return Ok(result);
        }
    }
}
