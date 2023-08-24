using AutoMapper;
using Microsoft.AspNetCore.Identity;
using ToDoApp.Business.DTOs.AppUser;
using ToDoApp.Business.Exceptions;
using ToDoApp.Business.Services.Contracts;
using ToDoApp.Data.Entities;
using ToDoApp.Data.Repositories.Contracts;

namespace ToDoApp.Business.Services.Implementation
{
    public class AppUserService : IAppUserService
    {
        private readonly UserManager<IdentityUser> _userManager;

        private readonly IAppUserRepository _appUserRepository;
        private readonly IMapper _mapper;

        public AppUserService(UserManager<IdentityUser> userManager, IAppUserRepository appUserRepository, IMapper mapper)
        {
            _userManager = userManager;
            _appUserRepository = appUserRepository ?? throw new ArgumentNullException(nameof(appUserRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<AppUserViewDto>> GetAllAsync()
        {
            var appUserEntities = await _appUserRepository.GetAllAsync();
            var appUserViewDtos = _mapper.Map<IEnumerable<AppUserViewDto>>(appUserEntities);

            return appUserViewDtos;
        }

        public async Task<AppUserViewDto> GetByIdAsync(int id)
        {
            var appUserEntity = await _appUserRepository.GetByIdAsync(id)
                ?? throw new NotFoundException("User was not found.");

            var appUserViewDto = _mapper.Map<AppUserViewDto>(appUserEntity);

            return appUserViewDto;
        }

        public async Task<AppUserViewDto> GetByEmailAsync(string email)
        {
            var appUserEntity = await _appUserRepository.GetByEmailAsync(email)
                ?? throw new NotFoundException("User was not found.");

            var appUserViewDto = _mapper.Map<AppUserViewDto>(appUserEntity);

            return appUserViewDto;
        }

         public async Task UpdateAsync(AppUserUpdateDto appUserUpdateDto)
         {
             if (appUserUpdateDto == null)
             {
                 throw new ArgumentNullException(nameof(appUserUpdateDto));
             }

             var existingAppUser = await _appUserRepository.GetByIdAsync(appUserUpdateDto.Id)
                 ?? throw new NotFoundException("User was not found.");

             var appUserEntity = _mapper.Map<AppUserEntity>(appUserUpdateDto);

             await _appUserRepository.UpdateAsync(appUserEntity);
         }

        public async Task DeleteAsync(int id)
        {
            var existingAppUser = await _appUserRepository.GetByIdAsync(id)
                ?? throw new NotFoundException("User was not found.");

            var existingUser = await _userManager.FindByEmailAsync(existingAppUser.Email)
                ?? throw new UserNotFoundException(existingAppUser.Email);

            await _userManager.DeleteAsync(existingUser);

            await _appUserRepository.DeleteAsync(id);
        }
    }
}
