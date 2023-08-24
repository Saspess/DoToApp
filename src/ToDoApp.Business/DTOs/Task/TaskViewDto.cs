namespace ToDoApp.Business.DTOs.Task
{
    public class TaskViewDto
    {
        public int Id { get; set; }

        public string AuthorsFirstName { get; set; } = null!;

        public string AuthorsLastName { get; set; } = null!;

        public string AuthorsEmail { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public bool IsCompleted { get; set; }

        public DateTime CreationDatetime { get; set; }

        public int AppUserId { get; set; }
    }
}
