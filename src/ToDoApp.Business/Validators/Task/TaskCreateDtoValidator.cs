using FluentValidation;
using ToDoApp.Business.DTOs.Task;

namespace ToDoApp.Business.Validators.Task
{
    public class TaskCreateDtoValidator : AbstractValidator<TaskCreateDto>
    {
        public TaskCreateDtoValidator()
        {
            RuleFor(t => t.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(t => t.Description)
                .NotNull()
                .NotEmpty()
                .MaximumLength(255);

            RuleFor(t => t.AppUserId)
                .NotNull();
        }
    }
}
