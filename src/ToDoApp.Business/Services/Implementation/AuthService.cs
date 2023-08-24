using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ToDoApp.Business.DTOs.AppUser;
using ToDoApp.Business.Exceptions;
using ToDoApp.Business.Services.Contracts;
using ToDoApp.Data.Entities;
using ToDoApp.Data.Repositories.Contracts;

namespace ToDoApp.Business.Services.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<IdentityUser> _userManager;

        private IConfiguration _configuration;
        private readonly IAppUserRepository _appUserReopsitory;
        private readonly IMapper _mapper;

        public AuthService(UserManager<IdentityUser> userManager, IConfiguration configuration, IAppUserRepository appUserRepository, IMapper mapper) 
        { 
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _appUserReopsitory = appUserRepository ?? throw new ArgumentNullException(nameof(appUserRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<AppUserViewDto> RegisterAsync(AppUserRegisterDto appUserRegisterDto)
        {
            if (appUserRegisterDto == null)
            {
                throw new ArgumentNullException(nameof(appUserRegisterDto));
            }

            var identityUser = new IdentityUser
            {
                Email = appUserRegisterDto.Email,
                UserName = appUserRegisterDto.Email
            };

            var identityResult = await _userManager.CreateAsync(identityUser, appUserRegisterDto.Password);

            if (!identityResult.Succeeded)
            {
                throw new RegistrationFailedException(String.Join(",", identityResult.Errors));
            }

            var appUserEntity = _mapper.Map<AppUserEntity>(appUserRegisterDto);
            var createdAppUserEntity = await _appUserReopsitory.CreateAsync(appUserEntity);
            var createdAppUserViewDto = _mapper.Map<AppUserViewDto>(createdAppUserEntity);

            return createdAppUserViewDto;
        }

        public async Task<string> LoginAsync(AppUserLoginDto appUserLoginDto)
        {
            var existingUser = await _userManager.FindByEmailAsync(appUserLoginDto.Email)
                ?? throw new UserNotFoundException(appUserLoginDto.Email);

            var loginResult = await _userManager.CheckPasswordAsync(existingUser, appUserLoginDto.Password);

            if (!loginResult)
            {
                throw new LoginFailedException("Invalid password.");
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.Email, appUserLoginDto.Email),
                new Claim(ClaimTypes.NameIdentifier, existingUser.Id)
            };
            
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthSettings:Key"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["AuthSettings:Issuer"],
                audience: _configuration["AuthSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

            var stringToken = new JwtSecurityTokenHandler().WriteToken(token);

            return stringToken;
        }
    }
}
