using LucasTimetable.Data.Entities;
using LucasTimetable.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LucasTimetable.Data.Configurations
{
    public class WorkConfiguration : IEntityTypeConfiguration<Work>
    {
        public void Configure(EntityTypeBuilder<Work> builder)
        {
            builder.ToTable("Works");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasMaxLength(10);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Description).HasMaxLength(100);
            builder.Property(x => x.Status).HasDefaultValue(Status.todo);
            builder.Property(x => x.Priority).HasDefaultValue(Priority.yes);


        }
    }
}
