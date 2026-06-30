using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using University.Data.Entities;

namespace University.Data.Configurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            //Table name
            builder.ToTable("Courses");

            //PK
            builder.HasKey(x => x.CourseId);

            builder.Property(x => x.CourseId)
                .UseIdentityColumn(1, 1);

            builder.Property(x => x.CourseName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.StartDate)
                .IsRequired();
            builder.Property(x => x.EndDate)
                .IsRequired();
            builder.Property(x => x.Weight)
                 .IsRequired();


        }
    }
}
