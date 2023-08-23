using AutoMapper;
using ToDoApp.Business.DTOs.AppUser;
using ToDoApp.Data.Entities;

namespace ToDoApp.Business.MappingProfiles
{
    public class AppUserMappingProfile : Profile
    {
        public AppUserMappingProfile()
        {
            CreateMap<AppUserEntity, AppUserViewDto>();

            CreateMap<AppUserRegisterDto, AppUserEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<AppUserUpdateDto, AppUserEntity>();
        }
    }
}
