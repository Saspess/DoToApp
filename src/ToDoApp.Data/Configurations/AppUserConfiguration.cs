﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoApp.Data.Entities;

namespace ToDoApp.Data.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUserEntity>
    {
        public void Configure(EntityTypeBuilder<AppUserEntity> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).UseIdentityColumn(1, 1)
                .ValueGeneratedOnAdd();

            builder.Property(u => u.FirstName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(u => u.LastName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(u => u.Email)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
