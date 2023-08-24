using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Business.DTOs.AppUser;
using ToDoApp.Business.Services.Contracts;

namespace ToDoApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AppUserController : ControllerBase
    {
        private IAppUserService _appUserService;

        public AppUserController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _appUserService.GetAllAsync();

            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var result = await _appUserService.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> GetByEmailAsync([FromRoute] string email)
        {
            var result = await _appUserService.GetByEmailAsync(email);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] AppUserUpdateDto appUserUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _appUserService.UpdateAsync(appUserUpdateDto);

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _appUserService.DeleteAsync(id);

            return Ok();
        }
    }
}
