namespace ToDoApp.Business.DTOs.Task
{
    public class TaskUpdateDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public bool IsCompleted { get; set; }

        public DateTime CreationDatetime { get; set; }

        public int AppUserId { get; set; }
    }
}
