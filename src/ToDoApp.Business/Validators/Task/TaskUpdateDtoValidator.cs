using FluentValidation;
using ToDoApp.Business.DTOs.Task;

namespace ToDoApp.Business.Validators.Task
{
    public class TaskUpdateDtoValidator : AbstractValidator<TaskUpdateDto>
    {
        public TaskUpdateDtoValidator()
        {
            RuleFor(t => t.Id)
                .NotNull();

            RuleFor(t => t.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(t => t.Description)
                .NotNull()
                .NotEmpty()
                .MaximumLength(255);

            RuleFor(t => t.IsCompleted)
                .NotNull();

            RuleFor(t => t.AppUserId)
                .NotNull();
        }
    }
}
