﻿namespace ToDoApp.Data.Entities
{
    public class TaskEntity : BaseEntity
    {
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public bool IsCompleted { get; set; }

        public DateTime CreationDatetime { get; set; }

        public int AppUserId { get; set; }

        public AppUserEntity AppUser { get; set; } = null!;
    }
}
