using Application.DTOs;
using Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace SaasApplication.Controllers.Tenants
{
    [ApiController]
    [Route("api/tenant")]
    public class TenantController : ControllerBase
    {
        private readonly RegisterTenantUseCase _registerTenantUseCase;

        public TenantController(RegisterTenantUseCase registerTenantUseCase)
        {
             _registerTenantUseCase = registerTenantUseCase;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterTenantRequest request)
        {
            var lcTenantId = await _registerTenantUseCase.Execute(request);

            return Ok(new
            {
                TenantId = lcTenantId
            });
        }
    }
}
