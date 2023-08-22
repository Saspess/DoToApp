using Microsoft.EntityFrameworkCore;
using ToDoApp.Data.Entities;

namespace ToDoApp.Data.Contexts.Contracts
{
    public interface IApplicationDbContext
    {
        DbSet<AppUserEntity> AppUsers { get; set; }
        DbSet<TaskEntity> Tasks { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        Task<int> SaveChangesAsync();
    }
}
