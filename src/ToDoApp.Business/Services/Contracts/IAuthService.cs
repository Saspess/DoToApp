using ToDoApp.Business.DTOs.AppUser;

namespace ToDoApp.Business.Services.Contracts
{
    public interface IAuthService
    {
        Task<AppUserViewDto> RegisterAsync(AppUserRegisterDto appUserRegisterDto);

        Task<string> LoginAsync(AppUserLoginDto appUserLoginDto);
    }
}
