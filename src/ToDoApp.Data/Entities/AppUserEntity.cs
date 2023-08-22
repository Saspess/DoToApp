namespace ToDoApp.Data.Entities
{
    public class AppUserEntity : BaseEntity
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public IEnumerable<TaskEntity> Tasks { get; set; }
    }
}
