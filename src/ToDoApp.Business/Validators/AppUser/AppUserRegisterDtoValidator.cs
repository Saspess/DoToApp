using FluentValidation;
using ToDoApp.Business.DTOs.AppUser;

namespace ToDoApp.Business.Validators.AppUser
{
    public class AppUserRegisterDtoValidator : AbstractValidator<AppUserRegisterDto>
    {
        public AppUserRegisterDtoValidator()
        {
            RuleFor(u => u.FirstName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(255);

            RuleFor(u => u.LastName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(255);

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

            RuleFor(u => u.ConfirmedPassword)
                .NotNull()
                .NotEmpty()
                .Equal(u => u.Password);
        }
    }
}
