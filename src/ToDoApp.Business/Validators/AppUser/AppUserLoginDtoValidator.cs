using FluentValidation;
using ToDoApp.Business.DTOs.AppUser;

namespace ToDoApp.Business.Validators.AppUser
{
    public class AppUserLoginDtoValidator : AbstractValidator<AppUserLoginDto>
    {
        public AppUserLoginDtoValidator()
        {
            RuleFor(u => u.Email)
               .NotNull()
               .NotEmpty()
               .EmailAddress();

            RuleFor(u => u.Password)
               .NotNull()
               .NotEmpty()
               .MinimumLength(8)
               .Matches(@"[0-9]+")
               .Matches(@"[A-Z]+")
               .Matches(@"[a-z]+")
               .MaximumLength(100);
        }
    }
}
