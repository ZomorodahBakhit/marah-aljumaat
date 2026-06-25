using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UniversityDB2.Models;

namespace UniversityDB2.ClassMapping
{
    internal class AssignmentConfiguration : IEntityTypeConfiguration<Assignment>
    {
        public void Configure(EntityTypeBuilder<Assignment> builder)
        {
            // Table
            builder.ToTable("Assignments");

            // PK
            builder.HasKey(a => a.AssignmentId);
            builder.Property(a => a.AssignmentId)
                   .UseIdentityColumn(1, 1);

            // Properties
            builder.Property(x => x.AssignmentTitle)
                   .IsRequired()
                   .HasMaxLength(128);

            builder.Property(x => x.AssignmentDescription)
                   .IsRequired(false)
                   .HasMaxLength(128);

            builder.Property(x => x.Weight)
                   .IsRequired()
                   .HasPrecision(18, 2);

            builder.Property(x => x.MaxGrade)
                   .IsRequired();

            builder.Property(x => x.DueDate)
                   .IsRequired();

            // Relationships
            builder.HasOne(a => a.Course)
                    .WithMany(c => c.Assignments)
                    .HasForeignKey(a => a.CourseId);

            builder.HasMany(a => a.Comments)
                    .WithOne(c => c.Assignment)
                    .HasForeignKey(c => c.AssignmentId);

            builder.HasMany(a=>a.Grades)
                .WithOne(g=>g.Assignment)
                .HasForeignKey(g => g.AssignmentId);

        }
    }
}
