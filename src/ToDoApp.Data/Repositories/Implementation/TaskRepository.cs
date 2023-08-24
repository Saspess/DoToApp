using Microsoft.EntityFrameworkCore;
using ToDoApp.Data.Contexts.Contracts;
using ToDoApp.Data.Entities;
using ToDoApp.Data.Repositories.Contracts;

namespace ToDoApp.Data.Repositories.Implementation
{
    public class TaskRepository : BaseRepository<TaskEntity>, ITaskRepository
    {
        public TaskRepository(IApplicationDbContext appContext) : base(appContext) { }

        public override async Task<IEnumerable<TaskEntity>> GetAllAsync() =>
           await appContext.Set<TaskEntity>()
           .AsNoTracking()
           .Include(t => t.AppUser)
           .ToListAsync();

        public override async Task<TaskEntity?> GetByIdAsync(int id) =>
            await appContext.Set<TaskEntity>()
            .AsNoTracking()
            .Include(t => t.AppUser)
            .FirstOrDefaultAsync(e => e.Id == id);

        public async Task<IEnumerable<TaskEntity>> GetAllUserTasksAsync(int appUserId) =>
            await appContext.Set<TaskEntity>()
            .AsNoTracking()
            .Where(t => t.AppUserId == appUserId)
            .Include(t => t.AppUser)
            .ToListAsync();

        public async Task<IEnumerable<TaskEntity>> GetUserComplitedTasksAsync(int appUserId) =>
            await appContext.Set<TaskEntity>()
            .AsNoTracking()
            .Where(t => t.AppUserId == appUserId && t.IsCompleted == true)
            .Include(t => t.AppUser)
            .ToListAsync();

        public async Task<IEnumerable<TaskEntity>> GetUserUncomplitedTasksAsync(int appUserId) =>
            await appContext.Set<TaskEntity>()
            .AsNoTracking()
            .Where(t => t.AppUserId == appUserId && t.IsCompleted == false)
            .Include(t => t.AppUser)
            .ToListAsync();

        public override async Task<TaskEntity?> CreateAsync(TaskEntity taskEntity)
        {
            var created = await appContext.Set<TaskEntity>().AddAsync(taskEntity);
            await appContext.SaveChangesAsync();

            var createdEntity = await appContext.Set<TaskEntity>()
            .AsNoTracking()
            .Include(t => t.AppUser)
            .FirstOrDefaultAsync(t => t.Id == created.Entity.Id);

            return createdEntity;
        }
    }
}
