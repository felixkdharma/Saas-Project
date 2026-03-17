using Application.DTOs;
using Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace SaasApplication.Controllers.Users
{
    [ApiController]
    [Route("api/user")]
    public class UserController : Controller
    {
        private readonly RegisterUserUseCase _registerUserUseCase;

        public UserController(RegisterUserUseCase registerUserUseCase)
        {
            _registerUserUseCase = registerUserUseCase;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserRequest request)
        {
            var userId = await _registerUserUseCase.Execute(request);

            return Ok(new { UserId = userId });
        }
    }
}
