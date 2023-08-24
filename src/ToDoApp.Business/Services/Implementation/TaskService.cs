using AutoMapper;
using ToDoApp.Business.DTOs.AppUser;
using ToDoApp.Business.DTOs.Task;
using ToDoApp.Business.Exceptions;
using ToDoApp.Business.Services.Contracts;
using ToDoApp.Data.Entities;
using ToDoApp.Data.Repositories.Contracts;
using ToDoApp.Data.Repositories.Implementation;

namespace ToDoApp.Business.Services.Implementation
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public TaskService(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository ?? throw new ArgumentNullException(nameof(taskRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<TaskViewDto>> GetAllAsync()
        {
            var taskEntities = await _taskRepository.GetAllAsync();
            var taskViewDtos = _mapper.Map<IEnumerable<TaskViewDto>>(taskEntities);

            return taskViewDtos;
        }

        public async Task<IEnumerable<TaskViewDto>> GetByAppUserIdAsync(int appUserId)
        {
            var taskEntities = await _taskRepository.GetAllUserTasksAsync(appUserId);
            var taskViewDtos = _mapper.Map<IEnumerable<TaskViewDto>>(taskEntities);

            return taskViewDtos;
        }

        public async Task<IEnumerable<TaskViewDto>> GetAppUserCompletedTasksAsync(int appUserId)
        {
            var taskEntities = await _taskRepository.GetUserCompletedTasksAsync(appUserId);
            var taskViewDtos = _mapper.Map<IEnumerable<TaskViewDto>>(taskEntities);

            return taskViewDtos;
        }

        public async Task<IEnumerable<TaskViewDto>> GetAppUserUncompletedTasksAsync(int appUserId)
        {
            var taskEntities = await _taskRepository.GetUserUncompletedTasksAsync(appUserId);
            var taskViewDtos = _mapper.Map<IEnumerable<TaskViewDto>>(taskEntities);

            return taskViewDtos;
        }

        public async Task<TaskViewDto> GetByIdAsync(int id)
        {
            var taskEntity = await _taskRepository.GetByIdAsync(id)
                ?? throw new NotFoundException("Task was not found.");

            var taskViewDto = _mapper.Map<TaskViewDto>(taskEntity);

            return taskViewDto;
        }

        public async Task<TaskViewDto> CreateAsync(TaskCreateDto taskCreateDto)
        {
            if (taskCreateDto == null)
            {
                throw new ArgumentNullException(nameof(taskCreateDto));
            }

            var taskEntity = _mapper.Map<TaskEntity>(taskCreateDto);

            var createdTaskEntity = await _taskRepository.CreateAsync(taskEntity);
            var taskViewDto = _mapper.Map<TaskViewDto>(createdTaskEntity);

            return taskViewDto;
        }

        public async Task UpdateAsync(TaskUpdateDto taskUpdateDto)
        {
            if (taskUpdateDto == null)
            {
                throw new ArgumentNullException(nameof(taskUpdateDto));
            }

            var existingTask = await _taskRepository.GetByIdAsync(taskUpdateDto.Id)
                ?? throw new NotFoundException("Task was not found.");

            var taskEntity = _mapper.Map<TaskEntity>(taskUpdateDto);

            await _taskRepository.UpdateAsync(taskEntity);
        }

        public async Task DeleteAsync(int id)
        {
            var existingTask = await _taskRepository.GetByIdAsync(id)
                ?? throw new NotFoundException("Task was not found.");

            await _taskRepository.DeleteAsync(id);
        }
    }
}
