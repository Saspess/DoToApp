using ToDoApp.Data.Entities;

namespace ToDoApp.Data.Repositories.Contracts
{
    public interface IAppUserRepository : IBaseRepository<AppUserEntity>
    {
        Task<AppUserEntity?> GetByEmailAsync(string email);
    }
}
