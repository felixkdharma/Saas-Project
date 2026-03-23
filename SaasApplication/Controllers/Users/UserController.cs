using Application.DTOs;
using Application.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SaasApplication.Controllers.Users
{
    [ApiController]
    [Route("api/user")]
    public class UserController : Controller
    {
        private readonly RegisterUserUseCase _registerUserUseCase;
        private readonly UpdateUserPasswordUseCase _updateUserPasswordUseCase;

        public UserController(RegisterUserUseCase registerUserUseCase, UpdateUserPasswordUseCase updatePasswordUseCase)
        {
            _registerUserUseCase = registerUserUseCase;
            _updateUserPasswordUseCase = updatePasswordUseCase;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserRequest request)
        {
            var userId = await _registerUserUseCase.Execute(request);

            return Ok(new { UserId = userId });
        }

        //[Authorize]
        [HttpPost("update-password")]
        public async Task<IActionResult> UpdatePassword(UpdatePasswordRequest request)
        {
            var userId = Guid.Parse(User.FindFirst("userId")!.Value);

            await _updateUserPasswordUseCase.ExecuteAsync(request);

            return Ok("Password updated successfully");
        }

    }
}
