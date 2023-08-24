using ToDoApp.Business.DTOs.AppUser;

namespace ToDoApp.Business.Services.Contracts
{
    public interface IAppUserService
    {
        Task<IEnumerable<AppUserViewDto>> GetAllAsync();
        Task<AppUserViewDto> GetByIdAsync(int id);
        Task<AppUserViewDto> GetByEmailAsync(string email);
        Task UpdateAsync(AppUserUpdateDto appUserUpdateDto);
        Task DeleteAsync(int id);
    }
}
