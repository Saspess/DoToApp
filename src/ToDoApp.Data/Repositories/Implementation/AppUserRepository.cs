using Microsoft.EntityFrameworkCore;
using ToDoApp.Data.Contexts.Contracts;
using ToDoApp.Data.Entities;
using ToDoApp.Data.Repositories.Contracts;

namespace ToDoApp.Data.Repositories.Implementation
{
    public class AppUserRepository : BaseRepository<AppUserEntity>, IAppUserRepository
    {
        public AppUserRepository(IApplicationDbContext appContext) : base(appContext) { }

        public async Task<AppUserEntity?> GetByEmailAsync(string email) =>
            await appContext.Set<AppUserEntity>()
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Email == email);
    }
}
