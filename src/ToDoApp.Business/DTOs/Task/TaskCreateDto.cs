namespace ToDoApp.Business.DTOs.Task
{
    public class TaskCreateDto
    {
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public int AppUserId { get; set; }
    }
}
