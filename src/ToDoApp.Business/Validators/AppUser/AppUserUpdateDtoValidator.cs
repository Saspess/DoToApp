using FluentValidation;
using ToDoApp.Business.DTOs.AppUser;

namespace ToDoApp.Business.Validators.AppUser
{
    public class AppUserUpdateDtoValidator : AbstractValidator<AppUserUpdateDto>
    {
        public AppUserUpdateDtoValidator()
        {
            RuleFor(u => u.Id)
                .NotNull();

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
        }
    }
}
