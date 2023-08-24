using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoApp.Data.Entities;

namespace ToDoApp.Data.Configurations
{
    public class TaskConfiguration : IEntityTypeConfiguration<TaskEntity>
    {
        public void Configure(EntityTypeBuilder<TaskEntity> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).UseIdentityColumn(1, 1)
                .ValueGeneratedOnAdd();

            builder.Property(t => t.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(t => t.Description)
                .HasMaxLength(255);

            builder.Property(t => t.IsCompleted)
                .IsRequired();

            builder.Property(t => t.CreationDatetime)
                .HasColumnType("datetime2")
                .HasPrecision(0)
                .IsRequired();

            builder.Property(t => t.AppUserId)
                .IsRequired();
        }
    }
}
