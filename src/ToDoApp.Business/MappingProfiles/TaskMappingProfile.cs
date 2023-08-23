using AutoMapper;
using ToDoApp.Business.DTOs.Task;
using ToDoApp.Data.Entities;

namespace ToDoApp.Business.MappingProfiles
{
    public class TaskMappingProfile : Profile
    {
        public TaskMappingProfile()
        {
            CreateMap<TaskEntity, TaskViewDto>()
                .ForMember(dest => dest.AuthorsFirstName, opt => opt.MapFrom(src => src.AppUser.FirstName))
                .ForMember(dest => dest.AuthorsLastName, opt => opt.MapFrom(src => src.AppUser.LastName))
                .ForMember(dest => dest.AuthorsEmail, opt => opt.MapFrom(src => src.AppUser.Email));

            CreateMap<TaskCreateDto, TaskEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreationDatetime, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.IsCompleted, opt => opt.MapFrom(src => false));

            CreateMap<TaskUpdateDto, TaskEntity>();
        }
    }
}
