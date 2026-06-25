using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UniversityDB2.Models;

namespace UniversityDB2.ClassMapping
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            // Table
            builder.ToTable("Courses");

            // PK
            builder.HasKey(co => co.CourseId);
            builder.Property(co => co.CourseId)
                   .UseIdentityColumn(1, 1);

            // Properties
            builder.Property(x => x.CourseName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.StartDate)
                   .IsRequired();

            builder.Property(x => x.EndDate)
                   .IsRequired();

            // Relationships
            builder.HasOne(co => co.Syllabus)
                    .WithOne(s => s.Course)
                    .HasForeignKey<Syllabus>(s => s.CourseId);

            builder.HasOne(co => co.Teacher)
                    .WithMany(u => u.Courses)
                    .HasForeignKey(co => co.TeacherId);

            builder.HasMany(co => co.Assignments)
                    .WithOne(a => a.Course)
                    .HasForeignKey(a => a.CourseId);

        }
    }

}
