using ToDoApp.Data.Entities;

namespace ToDoApp.Data.Repositories.Contracts
{
    public interface ITaskRepository : IBaseRepository<TaskEntity>
    {
        Task<IEnumerable<TaskEntity>> GetAllUserTasksAsync(int appUserId);
        Task<IEnumerable<TaskEntity>> GetUserCompletedTasksAsync(int appUserId);
        Task<IEnumerable<TaskEntity>> GetUserUncompletedTasksAsync(int appUserId);
    }
}
