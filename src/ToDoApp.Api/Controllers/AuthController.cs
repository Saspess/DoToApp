using Microsoft.AspNetCore.Mvc;
using ToDoApp.Business.DTOs.AppUser;
using ToDoApp.Business.Services.Contracts;

namespace ToDoApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync([FromBody] AppUserLoginDto appUserLoginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await _authService.LoginAsync(appUserLoginDto);

            return Ok(result);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody] AppUserRegisterDto appUserRegisterDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(appUserRegisterDto);
            }

            var result = await _authService.RegisterAsync(appUserRegisterDto);

            return Ok(result);
        }
    }
}
