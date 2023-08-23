using ToDoApp.Business.DTOs.Task;

namespace ToDoApp.Business.Services.Contracts
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskViewDto>> GetAllAsync();
        Task<IEnumerable<TaskViewDto>> GetByAppUserIdAsync(int appUserId);
        Task<IEnumerable<TaskViewDto>> GetAppUserComplitedTasksAsync(int appUserId);
        Task<IEnumerable<TaskViewDto>> GetAppUserUncomplitedTasksAsync(int appUserId);
        Task<TaskViewDto> GetByIdAsync(int id);
        Task<TaskViewDto> CreateAsync(TaskCreateDto taskCreateDto);
        Task UpdateAsync(TaskUpdateDto taskUpdateDto);
        Task DeleteAsync(int id);
    }
}
