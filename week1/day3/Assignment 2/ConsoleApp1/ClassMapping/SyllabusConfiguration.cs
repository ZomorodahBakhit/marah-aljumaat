using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UniversityDB2.Models;

namespace UniversityDB2.ClassMapping
{
    public class SyllabusConfiguration : IEntityTypeConfiguration<Syllabus>
    {
        public void Configure(EntityTypeBuilder<Syllabus> builder)
        {
            // Table
            builder.ToTable("Syllabus");

            // PK
            builder.HasKey(s => s.SyllabusId);
            builder.Property(s => s.SyllabusId)
                   .UseIdentityColumn(1, 1);

            // Properties
            builder.Property(x => x.SyllabusDescription)
                   .IsRequired(false)
                   .HasMaxLength(250);


            // Relationships
            builder.HasOne(s => s.Course)
                    .WithOne(c => c.Syllabus)
                    .HasForeignKey<Syllabus>(s => s.CourseId)
                    .OnDelete(DeleteBehavior.Restrict);




        }
    }
}
